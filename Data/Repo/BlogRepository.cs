using BlogAPI.Data.Context;
using BlogAPI.Data.Models;
using BlogAPI.Data.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Data.Repo
{
    public class BlogRepository : IBlogRepository
    {
        private readonly AppDB _db_Context;

        public BlogRepository(AppDB db_context)
        {
            _db_Context = db_context;
        }
        public void Add<T>(T entity) where T : class
        {
            this._db_Context.Add(entity);
        }
        public void Remove<T>(T entity) where T : class
        {
            this._db_Context.Remove(entity);
        }

        public async Task<bool> SaveAll()
        {
            return (await this._db_Context.SaveChangesAsync() > 0);
        }

        public async Task<IEnumerable<BlogPost>> GetBlogPosts()
        {
            return await this._db_Context.Posts
                                         .Include(p => p.Author)
                                         .Include(p => p.Comments)
                                         //.Include(p => p.Topics)
                                         .OrderByDescending(p => p.Created)
                                         .ToListAsync();
        }

        public async Task<Author> GetAuthor(string Id)
        {
            return await this._db_Context.Authors.FirstOrDefaultAsync(a => a.Id == Id);
        }

        public async Task<Topic> GetTopic(string Id)
        {
            return await this._db_Context.Topics.FirstOrDefaultAsync(t => t.Id == Id);
        }
    }
}
