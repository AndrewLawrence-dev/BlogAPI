using BlogAPI.Data.Models;
using BlogAPI.Data.Models.DTOS;
using BlogAPI.Data.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Data.Managers
{
    public class BlogManager
    {
        private readonly IBlogRepository _repo;

        public BlogManager(IBlogRepository repo)
        {
            this._repo = repo;
        }
        public string GetNewBlogID()
        {
            return Guid.NewGuid().ToString();
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
