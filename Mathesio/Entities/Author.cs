using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InternetDiscussion.Entities
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        public ICollection<Topic> Topics { get; set; }
            = new List<Topic>();
        public ICollection<Reply> Replies { get; set; }
            = new List<Reply>();
    }
}
