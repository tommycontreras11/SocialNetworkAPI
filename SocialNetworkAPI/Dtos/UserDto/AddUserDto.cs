using System.ComponentModel.DataAnnotations;

namespace SocialNetworkAPI.Dtos.UserDto
{
    public class AddUserDto
    {
        [Required(ErrorMessage = "The field firstname is required")]
        [MaxLength(60, ErrorMessage = "Max length for firstname is 60")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "The field lastname is required")]
        [MaxLength(60, ErrorMessage = "Max length for lastname is 60")]
        [DataType(DataType.Text)]
        public string LastName { get; set; } = string.Empty;

        [Range(1, 120, ErrorMessage = "Value must be between 1 to 120")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "The field gender is required")]
        public Gender Gender { get; set; }
    }
}
