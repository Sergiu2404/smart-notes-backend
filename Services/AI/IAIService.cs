using smart_notes_backend.Entities;
using smart_notes_backend.Models.Notes;

namespace smart_notes_backend.Services.AI
{
    public interface IAIService
    {
        Task<float[]> GenerateEmbeddingAsync(string content);
    }
}
