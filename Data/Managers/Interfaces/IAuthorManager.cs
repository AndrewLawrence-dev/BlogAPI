using BlogAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Data.Managers.Interfaces
{
    public interface IAuthorManager
    {
        public Task<Author> GetDefaultAuthor();
    }
}
