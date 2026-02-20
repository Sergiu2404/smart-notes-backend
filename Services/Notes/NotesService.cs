using smart_notes_backend.Entities;
using smart_notes_backend.Helpers.Authentication;
using smart_notes_backend.Models.Notes;
using smart_notes_backend.Repositories.Notes;
using System.Text.Json;

namespace smart_notes_backend.Services.Notes
{
    public class NotesService(
        INotesRepository notesRepository,
        IUserContext userContext
    ) : INotesService
    {
        public async Task<NoteResponseDto> CreateNoteAsync(CreateNoteDto noteDto, float[] embedding)
        {
            var note = new Note
            {
                Id = Guid.NewGuid(),
                UserId = userContext.UserId,
                Title = noteDto.Title,
                Content = noteDto.Content,
                Category = noteDto.Category,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                EmbeddingJson = JsonSerializer.Serialize(embedding)
            };

            await notesRepository.CreateAsync(note);
            await notesRepository.SaveChangesAsync();

            return new NoteResponseDto
            (
                note.Id,
                note.Title,
                note.Content,
                note.Category,
                note.UpdatedAt
            );
        }

        public async Task DeleteNoteAsync(Guid id)
        {
            await notesRepository.DeleteAsync(id, userContext.UserId);
            await notesRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<NoteResponseDto>> GetAllNotesAsync()
        {
            var notes = await notesRepository.GetAllUserNotesAsync(userContext.UserId);
            return notes
                .Select(note =>
                    new NoteResponseDto(
                        note.Id,
                        note.Title,
                        note.Content,
                        note.Category,
                        note.UpdatedAt
                    )
                );
        }

        public async Task<NoteResponseDto?> GetNoteByIdAsync(Guid id)
        {
            var note = await notesRepository.GetByIdAsync(id, userContext.UserId);
            return note == null ?
                null :
                new NoteResponseDto(
                    note.Id,
                    note.Title,
                    note.Content,
                    note.Category,
                    note.UpdatedAt
                );
        }

        public Task<IEnumerable<NoteResponseDto>> SearchSimilarAsync(float[] queryEmbedding, int limit = 5)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateNoteAsync(Guid id, UpdateNoteDto dto)
        {
            var existingNote = await notesRepository.GetByIdAsync(id, userContext.UserId);
            if (existingNote == null)
            {
                throw new Exception("Note not found or no permission to access this note");
            }

            existingNote.Title = dto.Title;
            existingNote.Content = dto.Content;
            existingNote.Category = dto.Category;
            existingNote.UpdatedAt = DateTime.UtcNow;

            await notesRepository.UpdateAsync(existingNote);
            await notesRepository.SaveChangesAsync();
        }
    }
}
