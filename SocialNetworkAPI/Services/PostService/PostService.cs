﻿namespace SocialNetworkAPI.Services.PostService
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

            try
            {
                var post = await FindPost(id);

                serviceResponse.Data = _mapper.Map<GetPostDto>(post);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPostDto>> AddPost(AddPostDto request)
        {
            var serviceResponse = new ServiceResponse<GetPostDto>();
            var post = _mapper.Map<Post>(request);
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            var foundPost = await _context.Posts.FirstOrDefaultAsync(p => p.Id == post.Id);
            serviceResponse.Data = _mapper.Map<GetPostDto>(foundPost);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPostDto>> UpdatePost(UpdatePostDto request)
        {
            var serviceResponse = new ServiceResponse<GetPostDto>();

            try
            {
                var post = await FindPost(request.Id);
                
                post.Title = request.Title;
                post.Description = request.Description;
                post.ImageUrl = request.ImageUrl;

                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetPostDto>(post);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;    
        }

        public async Task<ServiceResponse<List<GetPostDto>>> DeletePost(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetPostDto>>();

            try
            {
                var post = await FindPost(id);

                _context.Posts.Remove(_mapper.Map<Post>(post));
                await _context.SaveChangesAsync();

                serviceResponse.Data = _context.Posts.Select(p => _mapper.Map<GetPostDto>(p)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<Post> FindPost(int id)
        {
            var post = await _context.Posts.Include(p => p.Comments).FirstOrDefaultAsync(p => p.Id == id);
            if (post is null)
                throw new Exception($"Post with the Id '{id}' not found.");

            return post;
        }
    }
}
