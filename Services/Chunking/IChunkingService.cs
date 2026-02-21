namespace smart_notes_backend.Services.Chunking
{
    public interface IChunkingService
    {
        IEnumerable<string> ChunkText(
            string content
        );
    }
}
