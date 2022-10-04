using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LvvlStarterNetApi.Core.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LvvlStarterNetApi.SharedKernel.Interfaces
{
    public interface IBlogService
    {
        Task<List<Blog>> GetAsync();
        Task<Blog> GetByIdAsync(string id);
        Task<string> PostBlogAsync(Blog blog);
        Task DeleteBlogAsync(string id);
        Task<List<Comment>> GetCommentsAsync(string id);
        Task PostCommentAsync(Comment comment, string id);
    }
}
