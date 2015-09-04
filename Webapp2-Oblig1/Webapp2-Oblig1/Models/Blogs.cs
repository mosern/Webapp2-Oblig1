using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Webapp2_Oblig1.Models
{
    public class Blogs
    {
        public int BlogsID { get; set; }
        [DisplayName("Navn")]
        public string Name { get; set; }
        [DisplayName("Beskrivelse")]
        public string Description { get; set; }
        [DisplayName("Opprettet av")]
        public string Owner { get; set; }
        public bool IsOpen { get; set; }
        [DisplayName("Opprettet")]
        public DateTime Created { get; set; }
        [DisplayName("Sist Endret")]
        public DateTime LastEdited { get; set; }
        [DisplayName("Sist Endret av")]
        public string LastEditor { get; set; }

        public virtual ICollection<Posts> Posts { get; set; }
    }
}