using BlogAPI.Data.Managers.Interfaces;
using BlogAPI.Data.Models;
using BlogAPI.Data.Models.DTOS;
using BlogAPI.Data.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Data.Managers
{
    public class BlogManager : IBlogManager
    {
        private readonly IBlogRepository _repo;
        private readonly IAuthorManager _authorManager;
        private readonly IPostTimeManger _post_time_Manager;

        public BlogManager(IBlogRepository repo)
        {
            this._repo              = repo;
            this._authorManager     = new AuthorManager(this._repo);
            this._post_time_Manager = new PostTimeManager();
        }
        public string GetNewBlogID()
        {
            return Guid.NewGuid().ToString();
        }

        public async Task<Author> GetDefaultPostAuthor()
        {
            return await this._authorManager.GetDefaultAuthor();
        }

        public string GetDefaultTimezone()
        {
            return this._post_time_Manager.GetDefaultTimezone();
        }

        public DateTime GetCurrentDateAndTime()
        {
            return this._post_time_Manager.GetCurrentDateAndTime();
        }

        public IEnumerable<PostsTopics> GetTopicsFromCreateDTO(IEnumerable<TopicsList_DTO> topics_from_dto)
        {
            if (topics_from_dto == null) return null;

            return topics_from_dto.Select(t => new PostsTopics() {
                TopicId = t.Id,
                Topic   = new Topic()
                {
                    Id   = t.Id,
                    Name = t.Name
                }
            });
        }
    }
}
