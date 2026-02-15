using smart_notes_backend.Entities.User;

namespace smart_notes_backend.Services.Authentication
{
    public interface IAuthenticationService
    {
        string CreateToken(User user);
    }
}
