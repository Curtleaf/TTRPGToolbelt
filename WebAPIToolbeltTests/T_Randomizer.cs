using NUnit.Framework;
using WebAPIToolbelt.Controllers;

namespace WebAPIToolbeltTests
{
    public class Tests
    {
        private static readonly Randomizer _ran = new Randomizer();

        [SetUp]
        public void Setup()
        {

        }

        [TestCase("SWN","Standard Array")]
        [TestCase("SWN", "Random")]
        [TestCase("5e", "Standard Array")]
        [TestCase("5e", "Random")]
        public void GetAttributeArrayTest(string system, string type)
        {
            _ran.GetAttributeArray(system, type);
        }
    }
}