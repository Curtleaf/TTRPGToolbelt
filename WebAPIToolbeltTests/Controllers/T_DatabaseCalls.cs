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

        [TestCase("Barbarian", null, null, null)]
        [TestCase(null, new[] { "Talk" }, null, null)]
        [TestCase(null, new[] { "Talk", "Any Combat" }, null, null)]
        [TestCase(null, null, new[] { "+2 Physical" }, null)]
        [TestCase(null, null, null, "SWN")]
        [TestCase("Barbarian", null, null, "WWN")]
        [TestCase(null, new[] { "Talk" }, new[] { "+2 Physical" }, null)]
        [TestCase(null, new[] { "Talk" }, new[] { "+2 Physical" }, "SWN")]
        [TestCase("Criminal", new[] { "Talk" }, new[] { "+2 Physical" }, "SWN")]
        public void GetAttributeArrayTest(string name, string[] skill, string[] stat, string system)
        {
            var configuration = Configuration;

            DatabaseCalls dbc = new DatabaseCalls(configuration);

            var getBackgrounds = dbc.GetBackgrounds(name, skill, stat, system);

            Assert.That(getBackgrounds.Count > 0);
        }

    }
}
