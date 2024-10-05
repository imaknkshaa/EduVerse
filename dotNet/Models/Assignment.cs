using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduVerseApi.Models
{
    public class Assignment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int assignmentId { get; set; }

        public int courseId {  get; set; }
        [ForeignKey("courseId")]
        public Course course { get; set; }

        [Required]
        public int userId {  get; set; }
        [ForeignKey("userId")]
        public User user { get; set; }

        [Required]
        [StringLength(16)]
        public string title { get; set; }

        [Required]
        public DateTime dueDate { get; set; }

        [Required]
        public string filePath {  get; set; }
    }
}
