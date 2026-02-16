namespace smart_notes_backend.Entities.User
{
    public enum UserRole
    {
        Admin,
        User
    }
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public UserRole Role { get; set; }
    }
}
