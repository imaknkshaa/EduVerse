namespace EduVerseApi.DTOs.User
{
    public class UserListDto
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public string EmailId { get; set; }
        public bool IsActive { get; set; }
    }

}
