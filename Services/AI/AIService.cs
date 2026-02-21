using smart_notes_backend.Entities;
using smart_notes_backend.Models.AI;
using smart_notes_backend.Models.Notes;

namespace smart_notes_backend.Services.AI
{
    public class AIService : IAIService
    {
        private readonly HttpClient _httpClient;
        public AIService(HttpClient http)
        {
            _httpClient = http;
        }
        public async Task<float[]> GenerateEmbeddingAsync(string content)
        {
            var response = await _httpClient.PostAsJsonAsync(
                "http://localhost:11434/api/embeddings",
                new
                {
                    model = "nomic-embed-text",
                    prompt = content
                }
            );

            var result = await response.Content.ReadFromJsonAsync<OllamaEmbeddingResponse>();

            return result!.Embedding;
        }
    }
}
