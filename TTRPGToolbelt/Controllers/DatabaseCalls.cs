using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using WebAPIToolBelt.Models;

namespace WebAPIToolBelt.Controllers
{
    public class DatabaseCalls : Controller
    {
        #region Configuration
        /// <summary>
        /// Added configuration to accsess development API keys  
        /// </summary>
        private readonly IConfiguration _config;

        public DatabaseCalls(IConfiguration config)
        {
            _config = config;
        }
        #endregion

        #region Database
        /// <summary>
        /// Uses API Key to collect and retund databease info
        /// </summary>
        /// <returns>TTRPG_Data_Repository Mongo Database</returns>
        public IMongoDatabase GetMongodbRepository()
        {
            var mongodbApiKey = _config["TTRPGToolBeltDB:ConnectionString"];

            MongoClient dbClient = new(mongodbApiKey);

            return dbClient.GetDatabase("TTRPG_Data_Repository");
        }
        #endregion

        /// <summary>
        /// Returns a list of backgrounds per the query parameters 
        /// </summary>
        /// <param name="name">Name of background</param>
        /// <param name="skill">Skills associated with backgrounds</param>
        /// <param name="stat">stats associated with backgrounds</param>
        /// <param name="system">Game system</param>
        /// <returns>List of background objects</returns>
        public List<Background> GetBackgrounds(string name, string[] skill, string[] stat, string system)
        {

            IMongoCollection<Background> backgroundsCollection = GetMongodbRepository().GetCollection<Background>("Backgrounds");

            var builder = Builders<Background>.Filter;

            var filter = builder.Empty;

            if (!string.IsNullOrWhiteSpace(name))
            {
                var searchName = builder.Eq(Background => Background.name, name);
                filter &= searchName;
            }
            if (skill != null && skill.Any())
            {
                var searchSkill = builder.Or(
                    builder.In(Background => Background.free_skill, skill)
                    ,builder.AnyIn(Background => Background.quick_skills, skill)
                    , builder.AnyIn(Background => Background.growth, skill)
                );
                filter &= searchSkill;
            }
            if (stat != null && stat.Any())
            {
                var searchSkill = builder.AnyIn(Background => Background.growth, stat);
            
                filter &= searchSkill;
            }
            if (!string.IsNullOrWhiteSpace(system))
            {
                var searchSystem = builder.Eq(Background => Background.system, system);
                filter &= searchSystem;
            }

            var backgrounds = backgroundsCollection.Find(filter).ToList();

            return backgrounds;
        }

        /// <summary>
        /// Returns a list of skills per the query parameters 
        /// </summary>
        /// <param name="name">Name of Skill</param>
        /// <param name="combat">Is combat skill</param>
        /// <param name="psychicMagic">Is psychic or magic skill</param>
        /// <param name="system">Game system</param>
        /// <returns>List of skill objects</returns>
        public List<Skill> GetSkills(string name, bool? combat, bool? psychicMagic, string system)
        {

            IMongoCollection<Skill> skillsCollection = GetMongodbRepository().GetCollection<Skill>("Skills");

            var builder = Builders<Skill>.Filter;

            var filter = builder.Empty;

            if (!string.IsNullOrWhiteSpace(name))
            {
                var searchName = builder.Eq(Skills => Skills.name, name);
                filter &= searchName;
            }
            if (combat != null)
            {
                var searchCombat = builder.Eq(Skills => Skills.combat, combat);
                filter &= searchCombat;
            }
            if (psychicMagic != null)
            {
                var searchPsychic = builder.Eq(Skills => Skills.psychicMagic, psychicMagic);
                filter &= searchPsychic;
            }
            if (!string.IsNullOrWhiteSpace(system))
            {
                var searchSystem = builder.Eq(Skills => Skills.system, system);
                filter &= searchSystem;
            }

            var skills = skillsCollection.Find(filter).ToList();

            return skills;
        }

    }
}
