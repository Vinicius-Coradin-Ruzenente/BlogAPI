namespace BlogAPI.Models
{
    public class Post
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required int AuthorId { get; set; }
    }
}
