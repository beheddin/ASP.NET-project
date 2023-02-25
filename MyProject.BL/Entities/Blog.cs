//15
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProject.BL.Entities
{
    public class Blog
    {
        //18. add annotations
        [Key]
        public int BlogId { get; set; }

        [Required]
        public string? Title { get; set; }

        public string? Author { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PublishedDateTime { get; set; } = DateTime.Now;
        public virtual List<Post>? Posts { get; set; }
    }
}
