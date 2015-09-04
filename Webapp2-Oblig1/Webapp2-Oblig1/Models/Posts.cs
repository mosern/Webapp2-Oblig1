using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Webapp2_Oblig1.Models
{
    public class Posts
    {
        public int PostsID { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public string CreatedBy { get; set; }
        public string EditedBy { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastEdited { get; set; }
        public bool Edited { get; set; }

        public int BlogsID { get; set; }
        public virtual Blogs Blog { get; set; }
    }
}