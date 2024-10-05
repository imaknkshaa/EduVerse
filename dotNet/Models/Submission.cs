using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduVerseApi.Models
{
    public class Submission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int submissionId { get; set; }

        public int assignmentId {  get; set; }
        [ForeignKey("assignmentId")]
        public Assignment assignment { get; set; }

        public int userId {  get; set; }
        [ForeignKey("userId")]
        public User user { get; set; }

        [Required]
        public string filePath {  get; set; }

        [Required]
        [StringLength(50)]
        public string remark { get; set; }

        [Required]
        [Range(0,10,ErrorMessage ="Grade must be between 0 and 10.")]
        public int grades {  get; set; }

        [Required]
        public bool isSubmitted { get; set; }
    }
}
