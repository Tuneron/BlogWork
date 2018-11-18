using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogWork.Models
{
    public class CommentModel
    {
        public int CommentId { get; set; }
        public string BlogUserId { get; set; }
        public int PostId { get; set; }
        public string Body { get; set; }
    }
}