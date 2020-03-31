using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Data.Models.DTOS
{
    public class BlogToCreateDTO
    {
        public string AuthorId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public IEnumerable<string> TopicIds { get; set; }
    }
}
