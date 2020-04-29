using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAPI.Data.Managers;
using BlogAPI.Data.Models;
using BlogAPI.Data.Models.DTOS;
using BlogAPI.Data.Repo.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class BlogPostsController : ControllerBase
    {
        private readonly IBlogRepository _repo;
        private BlogManager _blog_manager;

        public BlogPostsController(IBlogRepository repo)
        {
            this._repo         = repo;
            this._blog_manager = new BlogManager(this._repo);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await this._repo.GetBlogPosts());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BlogToCreateDTO post)
        {
            DateTime current_date_and_time = DateTime.Now;
            BlogPost post_to_create        = new BlogPost()
            {
                Id           = this._blog_manager.GetNewBlogID(),
                Author       = await this._repo.GetAuthor("0B745330-A6E9-4C62-96AA-261AB95B28D1"),
                Created      = current_date_and_time,
                LastModified = null,
                Timezone     = "EST",
                Title        = post.Title,
                Content      = post.Content//,
                //Topics       = await this._blog_manager.GetTopicsFromIds(post.TopicIds)
            };

            try
            {
                this._repo.Add<BlogPost>(post_to_create);

                if (await this._repo.SaveAll())
                {
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to create blog." + ex.Message);
            }

            return BadRequest("Failed to create blog");
        }
    }
}