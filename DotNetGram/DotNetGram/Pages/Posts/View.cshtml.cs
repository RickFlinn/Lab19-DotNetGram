using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetGram.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DotNetGram.Models.Interfaces;

namespace DotNetGram.Pages.Posts
{
    public class ViewModel : PageModel
    {

        private readonly IPostManager _postMinion;
        private readonly ICommentManager _commentMinion;


        public ViewModel(IPostManager postMinion, ICommentManager commentMinion)
        {
            _postMinion = postMinion;
            _commentMinion = commentMinion;
        }


        [FromRoute]
        public int? ID { get; set; }

        [BindProperty]
        public Post Post { get; set; }


        public async Task OnGet()
        {   
            try
            {
                Post = await _postMinion.GetAsync(ID??0) ?? new Post();

            } catch (Exception e)
            {
                ViewData["ErrorMessage"] = e.Message;
                Post = new Post();
            }
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                Post post = await _postMinion.GetAsync(ID??0) ?? new Post();
                post.Title = Post.Title;
                post.Author = Post.Author;
                post.ImageUrl = Post.ImageUrl;
                post.Description = Post.Description;

                await _postMinion.SaveAsync(post);

                return RedirectToPage("/", new { id = post.ID });

            } catch (Exception e)
            {
                ViewData["ErrorMessage"] = e.Message;
                return RedirectToPage("/", new { id = ID });
            }
                
        }

        public async Task<IActionResult> OnPostDelete()
        {
            
            try
            {
                await _postMinion.DeleteAsync(ID??0);
                return RedirectToPage("../Index");

            } catch (Exception e)
            {
                ViewData["ErrorMessage"] = e.Message;
                return RedirectToPage("/", new { id = ID});
            }
            

        }
    }
}