namespace smart_notes_backend.Helpers.AI.Chunking
{
    public class WordChunkingStrategy : IChunkingStrategy
    {
        private readonly int _chunkSize;
        private readonly int _overlap;
        public WordChunkingStrategy(int chunkSize = 500, int overlap = 100)
        {
            if (overlap >= chunkSize)
                throw new ArgumentException("Overlap must be smaller than chunks size");

            _chunkSize = chunkSize;
            _overlap = overlap;
        }

        public IEnumerable<string> Chunk(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                yield break;

            var words = content.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i += (_chunkSize - _overlap))
            {
                yield return string.Join(" ",
                    words.Skip(i).Take(_chunkSize));
            }
        }
    }
}
