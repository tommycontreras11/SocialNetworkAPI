using SocialNetworkAPI.Common;

namespace SocialNetworkAPI.Models
{
    public class Post : AuditableBaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? ImageUrl { get; set; } = string.Empty;

        //Navigation property
        public ICollection<Comment> Comments { get; } = new List<Comment>();
    }
}
