using SocialNetworkAPI.Common;

namespace SocialNetworkAPI.Models
{
    public class User : AuditableBaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int? Age { get; set; }
        public Gender Gender { get; set; }

        //Navigation property
        public ICollection<Comment> Comments { get; } = new List<Comment>();
    }
}
