namespace EduVerseApi.DTOs.User
{
    public class UserUpdateDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public int CourseId { get; set; }
        public bool IsActive {  get; set; }
    }

}
