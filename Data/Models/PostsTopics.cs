using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Data.Models
{
    public class PostsTopics
    {
        public string PostId { get; set; }
        public string TopicId { get; set; }

        public BlogPost Post { get; set; }
        public Topic Topic { get; set; }
    }
}
