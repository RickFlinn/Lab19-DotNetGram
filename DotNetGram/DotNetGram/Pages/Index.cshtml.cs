using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetGram.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DotNetGram.Models.Interfaces;

namespace DotNetGram.Pages
{
    public class IndexModel : PageModel
    {

        // Setup and services
        private readonly IPostManager _postMinion;
        
        public IndexModel(IPostManager postMinion)
        {
            _postMinion = postMinion;
        }
        
        // Page data models
        public IEnumerable<Post> Posts { get; set; }
        
        // Endpoints
        public async Task OnGet()
        {
            try
            {
                Posts = await _postMinion.GetAllAsync();
                if (Posts == null)
                {
                    List<Post> None = new List<Post>();
                    Post nope = new Post();
                    nope.Author = "nope";
                    nope.Title = "nada";
                    None.Add(nope);
                    Posts = None;
                    throw new NullReferenceException("Couldn't find any posts");
                }

            } catch (Exception e)
            {
                ViewData["ErrorMessage"] = e.Message;
                List<Post> None = new List<Post>();
                Post nope = new Post();
                nope.Author = "ERROR";
                nope.Title = "ERROR";
                None.Add(nope);
                Posts = None;
            }
        }
        
    }
}