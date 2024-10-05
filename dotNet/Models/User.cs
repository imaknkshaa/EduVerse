using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduVerseApi.Models
{
    public class User
    {
        public User() {
            role = "Student";
            isActive = false;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userId { get; set; }

        [Required]
        [StringLength(16, MinimumLength =2)]
        [RegularExpression("^[A-Z]+$",ErrorMessage ="Only UpperCase letters allowed.")]
        public string firstName { get; set; }

        [Required]
        [StringLength(16, MinimumLength =2)]
        [RegularExpression("^[A-Z]+$",ErrorMessage ="Only UpperCase letters allowed.")]
        public string middleName {  get; set; }

        [Required]
        [StringLength(16, MinimumLength = 2)]
        [RegularExpression("^[A-Z]+$", ErrorMessage = "Only UpperCase letters allowed.")]
        public string lastName { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 3)]
        [RegularExpression("^[A-Z]+$", ErrorMessage = "Only UpperCase letters allowed.")]
        public string role { get; set; } = "Student";

        [Required]
        [StringLength(10)]
        [RegularExpression("^[0-9]{10}",ErrorMessage ="Mobile Number must be 10 digits.")]
        public string mobileNumber { get; set; }

        [Required]
        [StringLength(25)]
        [EmailAddress(ErrorMessage ="Invalid email format.")]
        public string emailId { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 2)]
        [RegularExpression("^[A-Z]+$", ErrorMessage = "Only UpperCase letters allowed.")]
        public int courseId { get; set; }
        [ForeignKey("courseId")]
        public Course course { get; set; }

        [Required]
        [StringLength(2000)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",ErrorMessage ="Password must be at least 8 characters long and include atleast 1 UpperCase letter, 1 LowerCase letter, 1 number and 1 special character.")]
        public string password { get; set; }

        [Required]
        public bool isActive {  get; set; }=false;

        public ICollection<Assignment> assignments { get; set; }
        public ICollection<Note> notes { get; set; }
        public ICollection<Quiz> quizzes { get; set; }
        public ICollection<StudentAnswer> studentAnswers{ get; set; }
    }
}
