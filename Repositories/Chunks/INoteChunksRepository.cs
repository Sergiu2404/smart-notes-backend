using smart_notes_backend.Entities;

namespace smart_notes_backend.Repositories.Chunks
{
    public interface INoteChunksRepository
    {
        Task CreateRangeAsync(IEnumerable<NoteChunk> chunks);
        Task<IEnumerable<NoteChunk>> GetAllUserChunksAsync(Guid userId);
        Task<IEnumerable<NoteChunk>> GetChunksByNoteIdAsync(Guid noteId, Guid userId);
        Task DeleteChunksByNoteIdAsync(Guid noteId, Guid userId);
        Task<bool> SaveChangesAsync();
    }
}
