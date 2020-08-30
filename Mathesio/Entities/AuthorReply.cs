using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetDiscussion.Entities
{
    public class AuthorReply
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("AuthorId")]
        public Author Author { get; set; }

        public int AuthorId { get; set; }

        [ForeignKey("ReplyId")]
        public Reply Reply { get; set; }

        public int ReplyId { get; set; }
    }
}
