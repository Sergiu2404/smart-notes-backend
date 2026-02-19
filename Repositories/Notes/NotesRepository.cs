using smart_notes_backend.Data;
using smart_notes_backend.Entities;

namespace smart_notes_backend.Repositories.Notes
{
    public class NotesRepository : INotesRepository
    {
        private readonly SqlServerDbContext _context;
        public NotesRepository(SqlServerDbContext context)
        {
            _context = context;
        }

        public Task CreateAsync(Note note)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid noteId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Note>> GetAllUserNotesAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Note>> GetByCategoryAsync(string category)
        {
            throw new NotImplementedException();
        }

        public Task<Note?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Note>> SearchBySubTitle(string titleSubstring)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Note>> SearchSimilarAsync(float[] queryEmbedding, int limit = 5)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Note note)
        {
            throw new NotImplementedException();
        }
    }
}
