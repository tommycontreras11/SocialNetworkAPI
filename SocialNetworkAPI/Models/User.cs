using SocialNetworkAPI.Common;
using System.Text.Json.Serialization;

namespace SocialNetworkAPI.Models
{
    public class User : AuditableBaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int? Age { get; set; }
        public Gender Gender { get; set; }

        //Navigation property
        public List<Post> Posts { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
