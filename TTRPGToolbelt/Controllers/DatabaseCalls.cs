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
        public IMongoDatabase GetMongodb()
        {
            var mongodbApiKey = _config["TTRPGToolBeltDB:ConnectionString"];

            MongoClient dbClient = new(mongodbApiKey);

            return dbClient.GetDatabase("TTRPG_Data_Repository");
        } 
        #endregion

        public List<Background> GetBackgrounds(string name, string free_skill, string system)
        {

            IMongoCollection<Background> backgroundsCollection = GetMongodb().GetCollection<Background>("Backgrounds");

            var builder = Builders<Background>.Filter;
            var filter = builder.Or(
                builder.Eq(Background => Background.name, name),
                builder.Eq(Background => Background.free_skill, free_skill),
                builder.Eq(Background => Background.System, system)
            );
            var backgrounds = backgroundsCollection.Find(filter).ToList();


            return backgrounds;
        }
        


    }
}
