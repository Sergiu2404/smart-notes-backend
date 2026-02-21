using Microsoft.EntityFrameworkCore;
using smart_notes_backend.Data;
using smart_notes_backend.Entities;

namespace smart_notes_backend.Repositories.Chunks
{
    public class NoteChunksRepository : INoteChunksRepository
    {
        private readonly SqlServerDbContext _context;
        public NoteChunksRepository(SqlServerDbContext context)
        {
            _context = context;
        }

        public async Task CreateRangeAsync(IEnumerable<NoteChunk> chunks)
        {
            await _context.NoteChunks.AddRangeAsync(chunks);
        }

        public async Task DeleteChunksByNoteIdAsync(Guid noteId, Guid userId)
        {
            var chunks = await _context.NoteChunks
                .Where(chunk => chunk.NoteId == noteId && chunk.UserId == userId)
                .ToListAsync();

            if (chunks.Any())
            {
                _context.NoteChunks.RemoveRange(chunks);
            }
        }

        public async Task<IEnumerable<NoteChunk>> GetAllUserChunksAsync(Guid userId)
        {
            return await _context.NoteChunks
                .Where(chunk => chunk.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<NoteChunk>> GetChunksByNoteIdAsync(Guid noteId, Guid userId)
        {
            return await _context.NoteChunks
                .Where(chunk => chunk.NoteId == noteId && chunk.UserId == userId)
                .ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
