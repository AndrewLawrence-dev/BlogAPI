using BlogAPI.Data.Managers.Interfaces;
using BlogAPI.Data.Models;
using BlogAPI.Data.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Data.Managers
{
    public class AuthorManager : IAuthorManager
    {
        private readonly IBlogRepository _repo;

        public AuthorManager(IBlogRepository repo)
        {
            this._repo = repo;
        }

        public async Task<Author> GetDefaultAuthor()
        {
            return await this.AndrewLawrence();
        }

        public async Task<Author> AndrewLawrence()
        {
            return await this._repo.GetAuthor("0B745330-A6E9-4C62-96AA-261AB95B28D1");
        }
    }
}
