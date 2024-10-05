using System.ComponentModel.DataAnnotations;

namespace EduVerseApi.Models
{
    public class Authentication
    {
        [Required]
        [Key]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }

}
