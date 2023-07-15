namespace SocialNetworkAPI.Dtos.CommentDto
{
    public class GetCommentDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;

        //Navigation property
        public int PostId { get; set; }
        public Post Post { get; set; } = null!;

        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
