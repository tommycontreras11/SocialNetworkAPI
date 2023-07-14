using SocialNetworkAPI.Dtos.Post;

namespace SocialNetworkAPI.Services.PostService
{
    public interface IPostService
    {
        Task<ServiceResponse<List<GetPostDto>>> GetAllPosts();
        Task<ServiceResponse<GetPostDto>> GetPostById(int id);
        Task<ServiceResponse<List<GetPostDto>>> AddPost(AddPostDto request);
        Task<ServiceResponse<GetPostDto>> UpdatePost(UpdatePostDto request);
        Task<ServiceResponse<List<GetPostDto>>> DeletePost(int id);
        Task<Post> FindPost(int id);
    }
}
