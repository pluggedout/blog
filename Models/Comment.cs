using System.ComponentModel.DataAnnotations.Schema;

namespace UmbracoBlog.Data
{
    // [Table("Comment")]
    public class Comment
    {
        public int Id { get; set; }
        public required string Content { get; set; }
        public DateTime CommentDate { get; set; }
        public int BlogPostId { get; set; }
        public required BlogPost BlogPost { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
    }
}
