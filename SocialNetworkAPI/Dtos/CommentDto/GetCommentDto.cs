using System.Text.Json.Serialization;

namespace SocialNetworkAPI.Dtos.CommentDto
{
    public class GetCommentDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;

        //Navigation property
        //[JsonIgnore]
        public int PostId { get; set; }

        //[JsonIgnore]
        public int UserId { get; set; }
    }
}
