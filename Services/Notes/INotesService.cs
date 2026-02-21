using smart_notes_backend.Entities;
using smart_notes_backend.Models.Notes;

namespace smart_notes_backend.Services.Notes
{
    public interface INotesService
    {
        Task<NoteResponseDto> CreateNoteAsync(CreateNoteDto note);
        Task<IEnumerable<NoteResponseDto>> GetAllNotesAsync();
        Task<NoteResponseDto?> GetNoteByIdAsync(Guid id);
        Task UpdateNoteAsync(Guid id, UpdateNoteDto dto);
        Task DeleteNoteAsync(Guid id);
        Task<IEnumerable<NoteResponseDto>> SearchSimilarAsync(float[] queryEmbedding, int limit = 5);
    }
}
