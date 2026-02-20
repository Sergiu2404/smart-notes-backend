
using System.Security.Claims;

namespace smart_notes_backend.Helpers.Authentication
{
    public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
    {
        public Guid UserId
        {
            get
            {
                var userIdClaim = httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
                return Guid.TryParse(userIdClaim, out var id) ? id : Guid.Empty;
            }
        }

        public bool IsAuthenticated =>
            httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
    }
}
