//15
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProject.BL.Entities
{
    public class Comment
    {
        //18. add annotations
        [Key]
        public int CommentId { get; set; }
        public string? Content { get; set; }
        
        [Required]
        public string? Author { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PublishedDateTime { get; set; }

        [ForeignKey("PostId")]
        public int PostId { get; set; }
        public Post? Post { get; set; }
    }
}
