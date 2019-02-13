using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetGram.Models.Interfaces
{
    interface IPostManager
    {

        Task SaveAsync(Post post);

        Task<Post> GetAsync(int postID);

        Task<IEnumerable<Post>> GetAllAsync();

        Task DeleteAsync(int postID);
    }
}
