namespace smart_notes_backend.Helpers.AI.Chunking
{
    public interface IChunkingStrategy
    {
        IEnumerable<string> Chunk(string content);
    }
}
