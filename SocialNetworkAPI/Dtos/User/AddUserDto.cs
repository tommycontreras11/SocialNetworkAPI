using System.ComponentModel.DataAnnotations;

namespace SocialNetworkAPI.Dtos.User
{
    public class AddUserDto
    {
        [Required(ErrorMessage = "The field firstname is required")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "The field lastname is required")]
        [DataType(DataType.Text)]
        public string LastName { get; set; } = string.Empty;

        [Range(1, 120, ErrorMessage = "Value must be between 1 to 120")]
        public int Age { get; set; }

        [Required(ErrorMessage = "The field gender is required")]
        public Gender Gender { get; set; }
    }
}
