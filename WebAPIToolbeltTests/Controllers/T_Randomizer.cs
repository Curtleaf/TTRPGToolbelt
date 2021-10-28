using NUnit.Framework;
using WebAPIToolbelt.Controllers;

namespace WebAPIToolbeltTests.Controllers
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {

        }

        [TestCase("SWN","Standard Array", new[]{14,12,11,10,9,7})]
        [TestCase("5e", "Standard Array", new[]{15,14,13,12,10,8})]
        [TestCase("5e", "Point Buy", new[]{0,0,0,0,0,0})]
        public void GetAttributeArrayTest(string system, string type, int[] expectedResult)
        {
            Assert.That(Attributes.AttributeArray(system, type), Is.EqualTo(expectedResult));
        }
        
        [TestCase("SWN", "Random")]
        [TestCase("5e", "Random")]
        [TestCase("SWN", "Random")]
        [TestCase("5e", "Random")]
        [TestCase("SWN", "Random")]
        [TestCase("5e", "Random")]
        [TestCase("SWN", "Random")]
        [TestCase("5e", "Random")]
        [TestCase("SWN", "Random")]
        [TestCase("5e", "Random")]
        public void GetRandomAttributeArrayTest(string system, string type)
        {
            var tempArray = Attributes.AttributeArray(system, type);

            Assert.That(tempArray[0], Is.InRange(3,18));
            Assert.That(tempArray[1], Is.InRange(3,18));
            Assert.That(tempArray[2], Is.InRange(3,18));
            Assert.That(tempArray[3], Is.InRange(3,18));
            Assert.That(tempArray[4], Is.InRange(3,18));
            Assert.That(tempArray[5], Is.InRange(3,18));
        }
    }
}