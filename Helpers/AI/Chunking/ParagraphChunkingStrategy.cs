namespace smart_notes_backend.Helpers.AI.Chunking
{
    public class ParagraphChunkingStrategy : IChunkingStrategy
    {
        public IEnumerable<string> Chunk(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                yield break;

            var paragraphs = content.Split(
                new[] { "\r\n\r\n", "\n\n" },
                StringSplitOptions.RemoveEmptyEntries);

            foreach (var paragraph in paragraphs)
            {
                yield return paragraph.Trim();
            }
        }
    }
}
