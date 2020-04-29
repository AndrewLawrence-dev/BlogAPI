using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Data.Models
{
    public class BlogPost
    {
        public string Id { get; set; }
        public Author Author { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
        public string Timezone { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public IEnumerable<PostsTopics> PostsTopics { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}
