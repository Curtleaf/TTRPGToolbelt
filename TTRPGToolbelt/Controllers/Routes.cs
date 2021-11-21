using Microsoft.AspNetCore.Mvc;

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
        [HttpPost]
        public int[] GetAttributeModifiers(string system, int[] attributes)
        {
            return Attributes.GetAttributeModifiers(system, attributes);

        }
    }
}
