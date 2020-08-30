using System.ComponentModel.DataAnnotations;

namespace InternetDiscussion.Models
{
    public class AuthorForCreationDto
    {
        [MaxLength(50, ErrorMessage = "The first name shouldn't have more than 50 characters.")]
        public string FirstName { get; set; }
        [MaxLength(50, ErrorMessage = "The last name shouldn't have more than 50 characters.")]
        public string LastName { get; set; }

    }
}
