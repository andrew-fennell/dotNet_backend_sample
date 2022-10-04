using LvvlStarterNetApi.Core.Models;
using LvvlStarterNetApi.SharedKernel;
using LvvlStarterNetApi.SharedKernel.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LvvlStarterNetApi.Core.Services
{
    public class BlogService : IBlogService
    {
        private readonly IMongoCollection<Blog> _blogs;

        public BlogService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _blogs = database.GetCollection<Blog>(settings.BlogsCollectionName);
        }

        public async Task<List<Blog>> GetAsync() =>
            await _blogs.Find(_ => true).ToListAsync();

        public async Task<Blog> GetByIdAsync(string id) =>
            await _blogs.Find(blog => blog.Id == ObjectId.Parse(id.ToString())).FirstOrDefaultAsync();

        public async Task<string> PostBlogAsync(Blog blog)
        {
            await _blogs.InsertOneAsync(blog);
            return blog.Id.ToString();
        }

        public async Task DeleteBlogAsync(string id) =>
            await _blogs.DeleteOneAsync(blog => blog.Id == ObjectId.Parse(id.ToString()));

        public async Task<List<Comment>> GetCommentsAsync(string id)
        {
            Blog blog = await _blogs.Find(blog => blog.Id == ObjectId.Parse(id.ToString())).FirstOrDefaultAsync();
            return blog.Comments;
        }

        public async Task PostCommentAsync(Comment comment, string id)
        {
            var filter = Builders<Blog>.Filter.Eq(x => x.Id, ObjectId.Parse(id.ToString()));
            var update = Builders<Blog>.Update.Push(x => x.Comments, comment);
            await _blogs.UpdateOneAsync(filter, update); ;
        }
    }
}
