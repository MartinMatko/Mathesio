using System.ComponentModel.DataAnnotations;

namespace InternetDiscussion.Models
{
    public class TopicForCreationDto
    {

        [Required(ErrorMessage = "Title is mandatory.")]
        [MaxLength(100, ErrorMessage = "Title cannot have more than 100 characters.")]
        public string Title { get; set; }

        [MaxLength(1500, ErrorMessage = "Description cannot have more than 1500 characters.")]
        public string Description { get; set; }
    }
}
