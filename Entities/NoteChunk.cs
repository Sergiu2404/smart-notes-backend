namespace smart_notes_backend.Entities
{
    public class NoteChunk
    {
        public Guid Id { get; set; }
        public Guid NoteId { get; set; }
        public virtual Note Note { get; set; }

        public Guid UserId { get; set; }
        public string Content { get; set; }
        public byte[] Embedding { get; set; }
        public int ChunkIndex { get; set; }
    }
}
