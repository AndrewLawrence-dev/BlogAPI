using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAPI.Data.Repo.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class TopicsController : ControllerBase
    {
        private readonly IBlogRepository _repo;

        public TopicsController(IBlogRepository repo)
        {
            this._repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await this._repo.GetTopics());
        }
    }
}