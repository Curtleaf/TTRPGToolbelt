using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIToolBelt.Models
{
    public class Background
    {
        public object _id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string free_skill { get; set; }
        public List<string> quick_skills { get; set; }
        public List<string> growth { get; set; }
        public List<string> learning { get; set; }
        public string System { get; set; }
    }
}
