using BlogAPI.Data.Models;
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

        public async Task<IEnumerable<Topic>> GetTopicsFromIds(IEnumerable<string> topicIds)
        {
            List<Topic> topics = new List<Topic>();

            foreach (string topicId in topicIds)
            {
                topics.Add(await this._repo.GetTopic(topicId));
            }

            return topics;
        }
    }
}
