using System.Text.Json.Serialization;

namespace SocialNetworkAPI.Dtos.PostDto
{
    public class GetPostDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;

        //Navigation property
        public int UserId { get; set; }

        public List<GetCommentDto> Comments { get; set; }
    }
}
