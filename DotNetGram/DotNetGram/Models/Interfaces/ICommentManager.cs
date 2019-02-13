using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetGram.Models.Interfaces
{
    interface ICommentManager
    {
        Task SaveAsync(Comment comment);

        Task<Comment> GetAsync(int commentID);

        Task<IEnumerable<Comment>> GetForPostAsync(int postID);

        Task<IEnumerable<Comment>> GetAllAsync();

        Task DeleteAsync(int commentID);
    }
}
