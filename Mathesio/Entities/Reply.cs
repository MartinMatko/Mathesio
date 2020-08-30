using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetDiscussion.Entities
{
    public class Reply
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(5000)]
        public string Comment { get; set; }

        [ForeignKey("TopicId")]
        public Topic Topic { get; set; }

        public int TopicId { get; set; }
    }
}
