using smart_notes_backend.Entities;
using System.ComponentModel.DataAnnotations;

namespace smart_notes_backend.Models.Authentication
{
    public record UserLoginDto(
        [Required] string Username,
        [Required] string Password  
    );

    public record UserRegisterDto(
        [Required] string Username,
        [Required] string Password,
        [Required] UserRole Role
    );

    public record AuthResponseDto(
        string Token,
        string Username,
        DateTime ExpiredAt
    );
}
