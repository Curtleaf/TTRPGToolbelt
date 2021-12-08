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
        public void GetBackgroundsTest(string name, string[] skill, string[] stat, string system)
        {
            var configuration = Configuration;

            DatabaseCalls dbc = new DatabaseCalls(configuration);

            var getBackgrounds = dbc.GetBackgrounds(name, skill, stat, system);

            Assert.That(getBackgrounds.Count > 0);
        }

        [TestCase("Administer", null, null, null)]
        [TestCase(null, false, null, null)]
        [TestCase(null, null, true, null)]
        [TestCase(null, null, null, "WWN")]
        [TestCase(null, null, false, null)]
        [TestCase(null, true, false, null)]
        [TestCase("Administer", null, null, "WWN")]
        [TestCase("Stab", true, null, "SWN")]
        [TestCase("Metapsionics", false, true, "SWN")]
        public void GetSkillsTest(string name, bool? combat, bool? psychic, string system)
        {
            var configuration = Configuration;

            DatabaseCalls dbc = new DatabaseCalls(configuration);

            var getBackgrounds = dbc.GetSkills(name, combat, psychic, system);

            Assert.That(getBackgrounds.Count > 0);
        }
    }
}
