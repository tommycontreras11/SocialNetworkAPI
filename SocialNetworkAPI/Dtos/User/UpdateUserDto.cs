using System.ComponentModel.DataAnnotations;

namespace SocialNetworkAPI.Dtos.User
{
    public class UpdateUserDto
    {
        [Required(ErrorMessage = "The field id is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Value must be start with 1")]
        public int Id { get; set; }

        [Required(ErrorMessage = "The field firstname is required")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "The field lastname is required")]
        [DataType(DataType.Text)]
        public string LastName { get; set; } = string.Empty;

        [Range(1, 120, ErrorMessage = "The field age must be between 1 to 120")]
        public int Age { get; set; }

        [Required(ErrorMessage = "The field gender is required")]
        public Gender Gender { get; set; }
    }
}
