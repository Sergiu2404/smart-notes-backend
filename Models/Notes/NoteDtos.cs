using System.ComponentModel.DataAnnotations;

namespace smart_notes_backend.Models.Notes
{
    public record CreateNoteDto(
        [Required][StringLength(100)] string Title,
        [Required] string Content,
        [Required] string Category
    );

    public record UpdateNoteDto(
        [Required][StringLength(100)] string Title,
        [Required] string Content,
        [Required] string Category
    );

    public record NoteResponseDto(
        Guid Id,
        string Title,
        string Content,
        string Category,
        DateTime UpdatedAt
    );
}
