namespace SocialNetworkAPI.Dtos.CommentDto
{
    public class UpdateCommentDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? ImageUrl { get; set; } = string.Empty;
        public int PostId { get; set; }
        public int UserId { get; set; }
    }
}
