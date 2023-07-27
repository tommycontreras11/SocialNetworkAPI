namespace SocialNetworkAPI.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> GetAllUsers()
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            serviceResponse.Data = await _context.Users.Select(u => _mapper.Map<GetUserDto>(u)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> GetUserById(int id)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();

            try
            {
                var user = await FindUser(id);
                serviceResponse.Data = _mapper.Map<GetUserDto>(user);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> AddUser(AddUserDto request)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();
            var user = _mapper.Map<User>(request);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            var foundUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
            serviceResponse.Data = _mapper.Map<GetUserDto>(foundUser);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> UpdateUser(UpdateUserDto request)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();

            try
            {
                var user = await FindUser(request.Id);

                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.Age = request.Age;
                user.Gender = request.Gender;

                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetUserDto>(user);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> DeleteUser(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();

            try
            {
                var user = await FindUser(id);

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _context.Users.Select(u => _mapper.Map<GetUserDto>(u)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<User> FindUser(int id) 
        {
            var user = await _context.Users.Include(u => u.Posts).Include(u => u.Comments)
                .FirstOrDefaultAsync(u => u.Id == id);
            if (user is null)
                throw new Exception($"User with the Id '{id}' not found.");

            return user;
        }
    }
}
