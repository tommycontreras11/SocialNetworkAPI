using System.Text.Json.Serialization;

namespace SocialNetworkAPI.Dtos.UserDto
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int? Age { get; set; }
        public Gender Gender { get; set; }

        //Navigation property
        public List<GetPostDto> Posts { get; set; }

        public List<GetCommentDto> Comments { get; set; }
    }
}
