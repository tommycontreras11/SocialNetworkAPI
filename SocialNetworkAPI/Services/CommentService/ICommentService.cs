namespace SocialNetworkAPI.Services.CommentService
{
    public interface ICommentService
    {
        Task<ServiceResponse<List<GetCommentDto>>> GetAllComments();
        Task<ServiceResponse<GetCommentDto>> GetCommentById(int id);
        Task<ServiceResponse<GetCommentDto>> AddComment(AddCommentDto request);
        Task<ServiceResponse<GetCommentDto>> UpdateComment(UpdateCommentDto request);
        Task<ServiceResponse<List<GetCommentDto>>> DeleteComment(int id);
        Task<Comment> FindComment(int id);
    }
}
