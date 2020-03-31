using BlogAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Data.Repo.Interfaces
{
    public interface IBlogRepository
    {
        public void Add<T>(T entity) where T : class;
        public void Remove<T>(T entity) where T : class;
        public Task<bool> SaveAll();
        public Task<IEnumerable<BlogPost>> GetBlogPosts();
        public Task<Author> GetAuthor(string Id);
        public Task<Topic> GetTopic(string Id);
    }
}
