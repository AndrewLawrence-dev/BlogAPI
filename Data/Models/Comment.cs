using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Data.Models
{
    public class Comment
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime Posted { get; set; }
    }
}
