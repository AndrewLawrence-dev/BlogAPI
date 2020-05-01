using BlogAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Data.Managers.Interfaces
{
    public interface IBlogManager
    {
        public string GetNewBlogID();
        public Task<Author> GetDefaultPostAuthor();
        public string GetDefaultTimezone();
        public DateTime GetCurrentDateAndTime();
    }
}
