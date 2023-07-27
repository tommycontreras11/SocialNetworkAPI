using SocialNetworkAPI.Common;

namespace SocialNetworkAPI.Models
{
    public class Post : AuditableBaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? ImageUrl { get; set; } = string.Empty;

        //Navigation property
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
