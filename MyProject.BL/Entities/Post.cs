//15
using Microsoft.AspNetCore.Identity;
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

        public string? Author { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PublishedDateTime { get; set; } = DateTime.Now;

        [Display(Name = "Select a picture")]
        public string? PicturePath { get; set; }   //26

        [ForeignKey("BlogId")]
        public int BlogId { get; set; }
        public Blog? Blog { get; set; }  //reference navigation prop
        public virtual List<Comment>? Comments { get; set; }    //collection navigation property
    }
}
