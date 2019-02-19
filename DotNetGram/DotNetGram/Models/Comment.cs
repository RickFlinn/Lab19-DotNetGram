namespace DotNetGram.Models
{
    public class Comment
    {
        // Primary Key
        public int ID { get; set; }

        public string Author { get; set; }
        public string Content { get; set; }
        
        // Navigation Properties

        public int PostID { get; set; }
        public Post Post { get; set; }
    }
}
