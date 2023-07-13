namespace SocialNetworkAPI.Dtos.User
{
    public class AddUserDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
        public Gender Gender { get; set; }
    }
}
