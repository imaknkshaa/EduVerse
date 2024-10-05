using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduVerseApi.Models
{
    public class StudentAnswer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentAnswerId { get; set; }

        [Required]
        public int userId {  get; set; }
        [ForeignKey("userId")]
        public User user { get; set; }

        [Required]
        public int questionId {  get; set; }
        [ForeignKey("questionId")]
        public Question question { get; set; }

        [Required]
        public int quizId { get; set; }
        [ForeignKey("quizId")]
        public Quiz quiz { get; set; }

        [Required]
        [StringLength(1)]
        [RegularExpression("^[A-D]$",ErrorMessage ="Answer must be A, B, C or D.")]
        public string answer { get; set; }

        [Required]
        public bool isCorrected { get; set; }
    }
}
