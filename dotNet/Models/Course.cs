using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduVerseApi.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int courseId { get; set; }

        [Required]
        [StringLength(10, MinimumLength =3)]
        [RegularExpression("^[A-Z]+$", ErrorMessage ="Only UpperCase letters allowed.")]
        public string courseName { get; set; }

        public ICollection<Assignment> assignments { get; set; }
        public ICollection<Note> notes { get; set; }
    }
}
