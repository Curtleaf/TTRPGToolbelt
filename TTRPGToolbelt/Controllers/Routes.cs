using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIToolbelt.Controllers
{
    [ApiController]
    public class Routes : ControllerBase
    {

        [Route("/GetAttributeArray")]
        [HttpGet]
        public int[] GetAttributeArray(string system, string type)
        {
            return Attributes.GetAttributeArray(system, type);
        }

        [Route("/GetAttributeModifiers")]
        [HttpGet]
        public int[] GetAttributeModifiers(string system, int[] attributes)
        {
            return Attributes.GetAttributeModifiers(system, attributes);

        }
    }
}
