namespace smart_notes_backend.Helpers.AI.Chunking
{
    public class CharacterChunkingStrategy : IChunkingStrategy
    {
        private readonly int _chunkSize;
        private readonly int _overlap;

        public CharacterChunkingStrategy(int chunkSize = 2000, int overlap = 200)
        {
            _chunkSize = chunkSize;
            _overlap = overlap;
        }

        public IEnumerable<string> Chunk(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                yield break;

            for (int i = 0; i < content.Length; i += (_chunkSize - _overlap))
            {
                yield return content.Substring(
                    i,
                    Math.Min(_chunkSize, content.Length - i));
            }
        }
    }
}
