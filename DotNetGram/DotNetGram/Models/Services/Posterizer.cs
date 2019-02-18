using DotNetGram.Data;
using DotNetGram.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetGram.Models.Services
{
    public class Posterizer : IPostManager
    {
        private readonly NetGramDbContext _context;

        public Posterizer(NetGramDbContext context)
        {
            _context = context;
        }

        public async Task<Post> GetAsync(int postID)
        {
            return await _context.Posts.Where(p => p.ID == postID)
                                        .Include(p => p.Comments)
                                        .FirstOrDefaultAsync();
        }
        
        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await _context.Posts.ToListAsync();          
        }

        public async Task SaveAsync(Post nuPost)
        {
            Post post = await _context.Posts.FindAsync(nuPost.ID);
            if (post == null)
            {
                _context.Add(nuPost);
            } else
            {
                _context.Update(nuPost);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int postID)
        {
            Post post = await _context.Posts.FindAsync(postID);
            if (post != null)
            {
                _context.Remove(post);
                await _context.SaveChangesAsync();
            }
        }
    }
}
