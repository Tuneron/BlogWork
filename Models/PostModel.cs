using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogWork.Models
{
    public class PostModel
    {
        public int PostId { get; set; }
        public string Date { get; set; }
        public string Theme { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public string Image { get; set; }
        public string AuthorId { get; set; }
    }
}