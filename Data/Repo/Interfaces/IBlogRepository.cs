using BlogAPI.Data.Models;
using BlogAPI.Data.Models.DTOS;
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
        public Task<IEnumerable<BlogToList_DTO>> GetBlogPosts();
        public Task<Author> GetAuthor(string Id);
        public Task<Topic> GetTopic(string Id);
        public Task<ICollection<TopicsList_DTO>> GetTopics();
    }
}
