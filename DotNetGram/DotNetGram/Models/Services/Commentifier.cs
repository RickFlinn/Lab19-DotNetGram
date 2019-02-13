using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetGram.Models.Interfaces;
using DotNetGram.Models;
using DotNetGram.Data;
using Microsoft.EntityFrameworkCore;

namespace DotNetGram.Models.Services
{
    public class Commentifier : ICommentManager
    {
        private readonly NetGramDbContext _context;


        public Commentifier(NetGramDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(int commentID)
        {
            Comment comment = await _context.Comments.FindAsync(commentID);
            if (comment != null)
            {
                _context.Remove(comment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
            
        }

        public async Task<Comment> GetAsync(int commentID)
        {
            return await _context.Comments.FindAsync(commentID);
        }

        public async Task<IEnumerable<Comment>> GetForPostAsync(int postID)
        {
            return await _context.Comments.Where(c => c.PostID == postID)
                                           .ToListAsync();
        }

        public async Task SaveAsync(Comment nuComment)
        {
            Comment comment = await _context.Comments.FindAsync(nuComment.ID);
            if (comment == null)
            {
                _context.Add(nuComment);
            } else
            {
                _context.Update(nuComment);
            }
            await _context.SaveChangesAsync();
        }
    }
}
