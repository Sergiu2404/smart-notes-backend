using smart_notes_backend.Entities;
using smart_notes_backend.Migrations;

namespace smart_notes_backend.Repositories.Notes
{
    public interface INotesRepository
    {
        Task<Note?> GetByIdAsync(Guid id);
        Task<IEnumerable<Note>> GetAllUserNotesAsync(Guid userId);
        Task CreateAsync(Note note);
        Task UpdateAsync(Note note);
        Task DeleteAsync(Guid noteId);
        Task<IEnumerable<Note>> SearchSimilarAsync(float[] queryEmbedding, int limit = 5);
        Task<IEnumerable<Note>> GetByCategoryAsync(string category);
        Task<IEnumerable<Note>> SearchBySubTitle(string titleSubstring);
        Task<bool> SaveChangesAsync();
    }
}
