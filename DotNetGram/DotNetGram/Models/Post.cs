using System.Collections.Generic;

namespace DotNetGram.Models
{
    public class Post
    {
        // Primary Key
        public int ID { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        // To be replaced

        public string ImageUrl { get; set; }


        // Navigation Properties
        public List<Comment> Comments { get; set; }
    }
}
