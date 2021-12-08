using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIToolBelt.Models
{
    public class Skill
    {
        public object _id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool combat { get; set; }
        public bool psychic { get; set; }
        public string system { get; set; }
    }
}
