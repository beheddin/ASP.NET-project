//15
using System.ComponentModel.DataAnnotations;

namespace MyProject.BL.Entities
{
    public class Blog
    {
        //18. add annotations
        [Key]
        public int BlogId { get; set; }

        [Required]
        public string? Title { get; set; }
        public string? Url { get; set; }

        [Required]
        public string? Author { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PublishedDateTime { get; set; }
        public virtual List<Post>? Post { get; set; }
    }
}
