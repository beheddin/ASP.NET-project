//15
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProject.BL.Entities
{
    public class Post
    {
        //18. add annotations
        [Key]
        public int PostId { get; set; }

        [Required]
        public string? Title { get; set; }
        public string? Content { get; set; }

        [Required]
        public string? Author { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PublishedDateTime { get; set; }

        [ForeignKey("BlogId")]
        public int BlogId { get; set; }
        public Blog? Blog { get; set; }
        public virtual List<Comment>? Comments { get; set; }

    }
}
