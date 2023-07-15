using System.ComponentModel.DataAnnotations;

namespace SocialNetworkAPI.Dtos.Post
{
    public class AddPostDto
    {
        [Required(ErrorMessage = "The field lastname is required")]
        [MaxLength(50, ErrorMessage = "Max length for title is 50")]
        [DataType(DataType.Text)]
        public string Title { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "The field lastname is required")]
        [MaxLength(500, ErrorMessage = "Max length for description is 500")]
        [DataType(DataType.Text)]
        public string Description { get; set; } = string.Empty;

        [DataType(DataType.Text)]
        public string ImageUrl { get; set; } = string.Empty;
    }
}
