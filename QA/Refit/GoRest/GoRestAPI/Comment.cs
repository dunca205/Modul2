using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoRestAPI
{
    public class Comment
    {
        public int Id { get; set; }
        public int post_id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
    }
}
