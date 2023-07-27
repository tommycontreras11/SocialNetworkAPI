namespace SocialNetworkAPI.Services.CommentService
{
    public class CommentService : ICommentService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CommentService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetCommentDto>>> GetAllComments()
        {
            var serviceResponse = new ServiceResponse<List<GetCommentDto>>();
            serviceResponse.Data = await _context.Comments.Select(c => _mapper.Map<GetCommentDto>(c)).ToListAsync(); ;
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCommentDto>> GetCommentById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCommentDto>();

            try
            {
                var comment = await FindComment(id);
                
                serviceResponse.Data = _mapper.Map<GetCommentDto>(comment);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCommentDto>> AddComment(AddCommentDto request)
        {
            var serviceResponse = new ServiceResponse<GetCommentDto>();
            var comment = _mapper.Map<Comment>(request);
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            var foundComment = await _context.Comments.Include(c => c.Post).Include(c => c.User).FirstOrDefaultAsync(c => c.Id == comment.Id);
            serviceResponse.Data = _mapper.Map<GetCommentDto>(foundComment);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCommentDto>> UpdateComment(UpdateCommentDto request)
        {
            var serviceResponse = new ServiceResponse<GetCommentDto>();

            try
            {
                var comment = await FindComment(request.Id);

                comment.Description = request.Description;
                comment.PostId = request.PostId;
                comment.UserId = request.UserId;

                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetCommentDto>(comment);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCommentDto>>> DeleteComment(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCommentDto>>();

            try
            {
                var comment = await FindComment(id);

                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();

                serviceResponse.Data = await _context.Comments.Select(c => _mapper.Map<GetCommentDto>(c)).ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<Comment> FindComment(int id)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
            if (comment is null)
                throw new Exception($"Comment with the Id '{id}' not found.");

            return comment;
        }
    }
}
