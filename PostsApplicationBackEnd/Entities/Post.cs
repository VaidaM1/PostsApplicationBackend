using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostsApplicationBackEnd.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Town { get; set; }
        public string Code { get; set; }
        public int Capacity { get; set; }
    }
}
