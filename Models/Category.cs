// using System.ComponentModel.DataAnnotations.Schema;

namespace UmbracoBlog.Data
{
    // [Table("Category")]
    public class Category
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Slug { get; set; }
        public ICollection<BlogPost> BlogPosts { get; set; }

        public Category()
        {
            BlogPosts = new List<BlogPost>();
        }
    }
}
