namespace UmbracoBlog.Data
{
    public class Author
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Bio { get; set; }
        public required string ProfilePictureUrl { get; set; }
        public ICollection<BlogPost> BlogPosts { get; set; }

        public Author()
        {
            BlogPosts = new List<BlogPost>();
        }
    }
}
