using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduVerseApi.Models
{
    public class Quiz
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int quizId { get; set; }

        public int userId { get; set; }
        [ForeignKey("userId")]
        public User user { get; set; }
        
        public int courseId {  get; set; }
        [ForeignKey("courseId")]
        public Course course { get; set; }

        [Required]
        [StringLength(30)]
        public string title { get; set; }

        public ICollection<StudentAnswer> studentAnswers { get; set; }
    }
}
