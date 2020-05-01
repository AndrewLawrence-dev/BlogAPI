using BlogAPI.Data.Context;
using BlogAPI.Data.Models;
using BlogAPI.Data.Models.DTOS;
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

        public async Task<IEnumerable<BlogToList_DTO>> GetBlogPosts()
        {
            return await this._db_Context.Posts
                                         .Include(p => p.Author)
                                         .Include(p => p.Comments)
                                         .Include(p => p.PostsTopics)
                                         .ThenInclude(pt => pt.Topic)
                                         .Select(p => new BlogToList_DTO() {
                                            Id           = p.Id,
                                            Author       = p.Author,
                                            Created      = p.Created,
                                            LastModified = p.LastModified,
                                            Timezone     = p.Timezone,
                                            Title        = p.Title,
                                            Content      = p.Content,
                                            Topics       = p.PostsTopics.Select(pt => new TopicsList_DTO() {
                                                                            Id   = pt.Topic.Id,
                                                                            Name = pt.Topic.Name
                                                                        })
                                         })
                                         .OrderByDescending(p => p.Created)
                                         .ToListAsync();
        }

        public async Task<Author> GetAuthor(string Id)
        {
            return await this._db_Context.Authors.FirstOrDefaultAsync(a => a.Id == Id);
        }

        public async Task<ICollection<TopicsList_DTO>> GetTopics()
        {
            return await this._db_Context.Topics.Select(t => new TopicsList_DTO()
                                                { 
                                                    Id   = t.Id,
                                                    Name = t.Name
                                                })
                                                .OrderBy(t => t.Name)
                                                .ToListAsync();
        }

        public async Task<Topic> GetTopic(string Id)
        {
            return await this._db_Context.Topics.FirstOrDefaultAsync(t => t.Id == Id);
        }
    }
}
