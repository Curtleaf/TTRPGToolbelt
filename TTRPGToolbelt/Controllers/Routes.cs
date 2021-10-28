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
            return Attributes.AttributeArray(system, type);
        }
    }
}
