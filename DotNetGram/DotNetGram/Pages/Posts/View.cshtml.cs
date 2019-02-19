using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetGram.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DotNetGram.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using DotNetGram.Models.Util;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.WindowsAzure.Storage.Blob;

namespace DotNetGram.Pages.Posts
{
    public class ViewModel : PageModel
    {

        private readonly IPostManager _postMinion;
        private readonly ICommentManager _commentMinion;


        public ViewModel(IPostManager postMinion, ICommentManager commentMinion, IConfiguration configuration)
        {
            _postMinion = postMinion;
            _commentMinion = commentMinion;
            BlobRoss = new TheBlob(configuration);
        }


        [FromRoute]
        public int? ID { get; set; }

        [BindProperty]
        public Post Post { get; set; }

        [BindProperty]
        public IFormFile ImageUpload { get; set; }

        public TheBlob BlobRoss { get; set; }

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
                post.Description = Post.Description;

                if (ImageUpload != null)
                {
                    string tempFilePath = Path.GetTempFileName();
                    using (FileStream stream = new FileStream(tempFilePath, FileMode.Create))
                    {
                        await ImageUpload.CopyToAsync(stream);
                    }

                    post.ImageUrl = await BlobRoss.UploadBlob("images", ImageUpload.FileName, tempFilePath);
                    
                }

                await _postMinion.SaveAsync(post);

                return RedirectToPage("/Posts/View", new { id = post.ID });

            } catch (Exception e)
            {
                ViewData["ErrorMessage"] = e.Message;
                return RedirectToPage("/Posts/View", new { id = ID });
            }
                
        }

        public async Task<IActionResult> OnPostDelete()
        {
            try
            {
                if (ID != null && ID > 0)
                    await _postMinion.DeleteAsync((int)ID);

                return RedirectToPage("../Index");

            } catch (Exception e)
            {
                ViewData["ErrorMessage"] = e.Message;
                return RedirectToPage("/", new { id = ID});
            }
        }
    }
}