namespace EduVerseApi.DTOs.User
{
    public class UserDetailDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string MobileNumber { get; set; }
        public string EmailId { get; set; }
        public int CourseId { get; set; }
        public bool IsActive { get; set; }
    }

}
