using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAPI.Data.Managers;
using BlogAPI.Data.Managers.Interfaces;
using BlogAPI.Data.Models;
using BlogAPI.Data.Models.DTOS;
using BlogAPI.Data.Repo.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BlogAPI.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class BlogPostsController : ControllerBase
    {
        private readonly IBlogRepository _repo;
        private readonly IBlogManager _blog_manager;

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
            DateTime current_date_and_time = this._blog_manager.GetCurrentDateAndTime();
            string new_blog_id             = this._blog_manager.GetNewBlogID();

            BlogPost post_to_create        = new BlogPost()
            {
                Id           = new_blog_id,
                Author       = await this._blog_manager.GetDefaultPostAuthor(),
                Created      = current_date_and_time,
                LastModified = null,
                Timezone     = this._blog_manager.GetDefaultTimezone(),
                Title        = post.Title?.Trim(),
                Content      = post.Content?.Trim(),
                PostsTopics  = post.Topics.Select(t => new PostsTopics {
                                                PostId  = new_blog_id,
                                                TopicId = t.Id
                                          }).ToList()
            };

            try
            {
                this._repo.Add<BlogPost>(post_to_create);

                if (await this._repo.SaveAll())
                {
                    return Ok(JsonSerializer.Serialize(new {
                            RequestMet = true,
                            Message    = "Post Created"
                        }
                    ));
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