namespace smart_notes_backend.Entities
{
    public class Note
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Category { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<NoteChunk> Chunks { get; set; } = new List<NoteChunk>();
    }
}
