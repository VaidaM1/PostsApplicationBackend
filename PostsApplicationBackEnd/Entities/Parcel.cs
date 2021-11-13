using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostsApplicationBackEnd.Entities
{
    public class Parcel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public decimal Weight { get; set; }
        public string Phone { get; set; }
        public string Info { get; set; }
        public int? PostId { get; set; }
        public Post Post { get; set; }
    }
}
