using DotNetGram.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetGram.Data
{
    public class NetGramDbContext : DbContext
    {
        public NetGramDbContext(DbContextOptions<NetGramDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Post>().HasData(
                new Post
                {
                    ID = 1,
                    Title = "Best Ever Coffee Pic",
                    Description = "Flavored Latte with a pretty little swirleydoo",
                    ImageUrl = "https://via.placeholder.com/150",
                    Author = "Sally"
                },
                new Post
                {
                    ID = 2,
                    Title = "MY DOG IS THE CUTEST",
                    Description = "We were worried hey might eat them but Max has happily adopted this horde of super-fluffy baby chicks and also kittens!!!!",
                    ImageUrl = "https://via.placeholder.com/150",
                    Author = "Bob The Doggo Owner"
                },
                new Post
                {
                    ID = 3,
                    Title = "Sweet Graffiti Someone Painted On My Car",
                    Description = "Work of art! So subversive! Banksy Original?!?",
                    ImageUrl = "https://via.placeholder.com/150",
                    Author = "Maybe I'M Banksy and forgot?!?"
                },
                new Post
                {
                    ID = 4,
                    Title = "Tattoo That I Do Not In Any Way, Shape or Form Regret",
                    Description = "No really, I put a lot of thought into this. I am very cautious about getting tattoos and I am following my genuine passion for body modifications.",
                    ImageUrl = "https://via.placeholder.com/150",
                    Author = "Sally's Cool Older Sister"
                },
                new Post
                {
                    ID = 5,
                    Title = "Picture of Food You're Not Eating!",
                    Description = "**Insert Cliche Satire of Instagram Food Pics",
                    ImageUrl = "https://via.placeholder.com/150",
                    Author = "Guy who actually really cares about food and/or my dad"
                });

            builder.Entity<Comment>().HasData(
                new Comment
                {
                    ID = 1,
                    PostID = 4,
                    Author = "Sally",
                    Content = "Wow. So proud of your conviction and style, sis! You are the coolest!"

                },
                new Comment
                {
                    ID = 2,
                    PostID = 5,
                    Author = "Bob the Doggo Owner",
                    Content = "Nice! Going to have to try and recreate this for Max. Substituting in kibble, of course!"
                },
                new Comment
                {
                    ID = 3,
                    PostID = 5,
                    Author = "Sally's Cool Older Sister",
                    Content = "I just made a gluten-free version of this dish for my friend Amanda, who is also Totally Cool."
                });
        }
        

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}
