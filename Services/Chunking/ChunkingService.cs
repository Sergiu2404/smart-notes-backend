
using smart_notes_backend.Helpers.AI.Chunking;
using static System.Net.Mime.MediaTypeNames;

namespace smart_notes_backend.Services.Chunking
{
    public class ChunkingService : IChunkingService
    {
        private readonly IChunkingStrategy _chunkingStrategy;
        public ChunkingService(IChunkingStrategy chunkingStrategy)
        {
            this._chunkingStrategy = chunkingStrategy;
        }

        public IEnumerable<string> ChunkText(string content)
        {
            return _chunkingStrategy.Chunk(content);
        }
    }
}
