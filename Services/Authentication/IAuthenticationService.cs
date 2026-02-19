using smart_notes_backend.Entities;
using smart_notes_backend.Models.Authentication;

namespace smart_notes_backend.Services.Authentication
{
    public interface IAuthenticationService
    {
        string CreateToken(User user);
        Task<User?> RegisterAsync(UserRegisterDto request);
        Task<string?> LoginAsync(UserLoginDto request);
    }
}
