namespace UmbracoBlog.Data
{
    public class BlogPost
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Slug { get; set; }
        public required string Content { get; set; }
        public required DateTime PublishedDate { get; set; }
        public required int AuthorId { get; set; }
        public required Author Author { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Comment> Comments { get; set; }

        public BlogPost()
        {
            Categories = new List<Category>();
            Comments = new List<Comment>();
        }
    }
}
