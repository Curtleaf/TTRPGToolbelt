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
        private readonly IConfiguration _config;

        public DatabaseCalls(IConfiguration config)
        {
            _config = config;
        }
        #endregion

        #region Database
        public IMongoDatabase GetMongodbRepository()
        {
            var mongodbApiKey = _config["TTRPGToolBeltDB:ConnectionString"];

            MongoClient dbClient = new(mongodbApiKey);

            return dbClient.GetDatabase("TTRPG_Data_Repository");
        } 
        #endregion

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
                var searchSystem = builder.Eq(Background => Background.System, system);
                filter &= searchSystem;
            }

            var backgrounds = backgroundsCollection.Find(filter).ToList();


            return backgrounds;
        }
        


    }
}
