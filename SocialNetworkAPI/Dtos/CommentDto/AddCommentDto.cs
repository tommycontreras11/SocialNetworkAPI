namespace SocialNetworkAPI.Dtos.CommentDto
{
    public class AddCommentDto
    {
        public string Description { get; set; } = string.Empty;
        public string? ImageUrl { get; set; } = string.Empty;
        public int PostId { get; set; }
        public int UserId { get; set; }
    }
}
