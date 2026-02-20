using smart_notes_backend.Entities;
using smart_notes_backend.Migrations;

namespace smart_notes_backend.Repositories.Notes
{
    public interface INotesRepository
    {
        Task<Note?> GetByIdAsync(Guid id, Guid userId);
        Task<IEnumerable<Note>> GetAllUserNotesAsync(Guid userId);
        Task CreateAsync(Note note);
        Task UpdateAsync(Note note);
        Task DeleteAsync(Guid noteId, Guid userId);
        Task<IEnumerable<Note>> GetByCategoryAsync(string category, Guid userId);
        Task<IEnumerable<Note>> SearchBySubTitle(string titleSubstring, Guid userId);
        Task<bool> SaveChangesAsync();
    }
}
