using SocialNetworkAPI.Dtos.Post;

namespace SocialNetworkAPI.Services.PostService
{
    public class PostService : IPostService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PostService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetPostDto>>> GetAllPosts()
        {
            var serviceResponse = new ServiceResponse<List<GetPostDto>>();
            serviceResponse.Data = await _context.Posts.Select(p => _mapper.Map<GetPostDto>(p)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPostDto>> GetPostById(int id)
        {
            var serviceResponse = new ServiceResponse<GetPostDto>();
            var post = await FindPost(id);
            serviceResponse.Data = _mapper.Map<GetPostDto>(post);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetPostDto>>> AddPost(AddPostDto request)
        {
            var serviceResponse = new ServiceResponse<List<GetPostDto>>();
            _context.Posts.Add(_mapper.Map<Post>(request));
            await _context.SaveChangesAsync();
            serviceResponse.Data = _context.Posts.Select(p => _mapper.Map<GetPostDto>(p)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPostDto>> UpdatePost(int id, UpdatePostDto request)
        {
            var serviceResponse = new ServiceResponse<GetPostDto>();
            var post = await FindPost(id);
            
            post.Data.Title = request.Title;
            post.Data.Description = request.Description;
            post.Data.ImageUrl = request.ImageUrl;

            serviceResponse.Data = _mapper.Map<GetPostDto>(post);
            return serviceResponse;    
        }

        public async Task<ServiceResponse<List<GetPostDto>>> DeletePost(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetPostDto>>();

            var post = await FindPost(id);
            _context.Posts.Remove(_mapper.Map<Post>(post));
            await _context.SaveChangesAsync();

            serviceResponse.Data = _context.Posts.Select(p => _mapper.Map<GetPostDto>(p)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPostDto>> FindPost(int id)
        {
            var serviceResponse = new ServiceResponse<GetPostDto>();

            try
            {
                var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
                if (post is null)
                    throw new Exception($"Post with the Id '{id}' not found.");

                serviceResponse.Data = _mapper.Map<GetPostDto>(post);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}
