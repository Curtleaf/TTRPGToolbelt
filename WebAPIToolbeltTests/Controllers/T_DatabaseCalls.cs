using NUnit.Framework;
using WebAPIToolBelt.Controllers;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace WebAPIToolBeltTests.Controllers
{
    class T_DatabaseCalls
    {
        private ConfigurationBuilder _configuration = new ConfigurationBuilder();

        #region Configuration
        IConfiguration Configuration { get; set; }

        public T_DatabaseCalls()
        {
            // the type specified here is just so the secrets library can 
            // find the UserSecretId we added in the csproj file
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<T_DatabaseCalls>();

            Configuration = builder.Build();
        } 
        #endregion

        [SetUp]
        public void Setup()
        {
        }

        [TestCase("Barbarian", null, null)]
        [TestCase(null, "Talk-0", null)]
        [TestCase(null, null, "SWN")]
        [TestCase("Barbarian", null, "WWN")]
        public void GetAttributeArrayTest(string name, string free_skill, string system)
        {
            var configuration = Configuration;

            DatabaseCalls dbc = new DatabaseCalls(configuration);

            var getBackgrounds = dbc.GetBackgrounds(name, free_skill, system);

        }

    }
}
