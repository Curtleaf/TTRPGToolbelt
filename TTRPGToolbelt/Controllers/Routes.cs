using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using WebAPIToolBelt.Controllers;
using WebAPIToolBelt.Models;

namespace WebAPIToolbelt.Controllers
{
    //[ApiController]
    public class Routes : ControllerBase
    {
        #region Configuration
        private readonly IConfiguration _config;

        public Routes(IConfiguration config)
        {
            _config = config;
        }
        #endregion

        #region Attributes
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
        #endregion

        #region Database Calls
        [Route("/GetBackgrounds")]
        [HttpGet]
        public List<Background> GetBackgrounds(string name, string[] skill, string[] stat, string system)
        {
            DatabaseCalls dbc = new(_config);

            return dbc.GetBackgrounds(name, skill, stat, system);
        }

        [Route("/GetSkills")]
        [HttpGet]
        public List<Skill> GetSkills(string name, bool? combat, bool? psychic, string system)
        {
            DatabaseCalls dbc = new(_config);

            return dbc.GetSkills(name, combat, psychic, system);
        }
        #endregion
    }
}