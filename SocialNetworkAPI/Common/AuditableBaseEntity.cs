namespace SocialNetworkAPI.Common
{
    public class AuditableBaseEntity
    {
        public virtual int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
