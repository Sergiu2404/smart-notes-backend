using smart_notes_backend.Entities.User;

namespace smart_notes_backend.Models.Authentication
{
    public class UserRegisterDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
}
