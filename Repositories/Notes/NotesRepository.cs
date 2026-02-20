using Microsoft.EntityFrameworkCore;
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

        public async Task CreateAsync(Note note)
        {
            await _context.Notes.AddAsync(note);
            
        }

        public async Task DeleteAsync(Guid noteId, Guid userId)
        {
            var note = await GetByIdAsync(noteId, userId);
            if (note != null)
            {
                _context.Notes.Remove(note);
            }
        }

        public async Task<IEnumerable<Note>> GetAllUserNotesAsync(Guid userId)
        {
            return await _context.Notes
                .Where(note => note.UserId == userId)
                .OrderByDescending(note => note.UpdatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Note>> GetByCategoryAsync(string category, Guid userId)
        {
            return await _context.Notes
                .Where(note => note.Category == category && note.UserId == userId)
                .ToListAsync();
        }

        public async Task<Note?> GetByIdAsync(Guid id, Guid userId)
        {
            return await _context.Notes
                .FirstOrDefaultAsync(note => note.Id == id && note.UserId == userId);
        }

        public async Task<IEnumerable<Note>> SearchBySubTitle(string titleSubstring, Guid userId)
        {
            return await _context.Notes
                .Where(note => note.UserId == userId && note.Title.Contains(titleSubstring))
                .ToListAsync();
        }

        public Task UpdateAsync(Note note)
        {
            _context.Notes.Update(note);
            return Task.CompletedTask;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
