namespace smart_notes_backend.Helpers.Authentication
{
    public interface IUserContext
    {
        Guid UserId { get; }
        bool IsAuthenticated { get; }
    }
}
