using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAPI.Data.Models;
using BlogAPI.Data.Repo.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class BlogPostsController : ControllerBase
    {
        private readonly IBlogRepository _repo;

        public BlogPostsController(IBlogRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await this._repo.GetBlogPosts());
        }

        [HttpPost]
        public IActionResult Create(BlogPost post)
        {
            this._repo.Add<BlogPost>(post);
            this._repo.SaveAll();

            return Ok();
        }
    }
}