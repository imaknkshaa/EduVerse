using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduVerseApi.Models
{
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int questionId { get; set; }

        public int quizId { get; set; }
        [ForeignKey("quizId")]
        public Quiz quiz { get; set; }

        [Required]
        [StringLength(100)]
        public string questionText { get; set; }

        [Required]
        [StringLength(50)]
        public string option1 { get; set; }

        [Required]
        [StringLength(50)]
        public string option2 { get; set; }

        [Required]
        [StringLength(50)]
        public string option3 { get; set; }

        [Required]
        [StringLength(50)]
        public string option4 { get; set; }

        [Required]
        [StringLength(1)]
        [RegularExpression("^[A-D]$",ErrorMessage ="Answer must be A, B, C or D.")]
        public string answer { get; set; }
    }
}
