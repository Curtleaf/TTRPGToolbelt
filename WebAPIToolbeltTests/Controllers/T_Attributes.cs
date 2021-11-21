using NUnit.Framework;
using WebAPIToolbelt.Controllers;

namespace WebAPIToolbeltTests.Controllers
{
    public class T_Attributes
    {

        [SetUp]
        public void Setup()
        {

        }

        [TestCase("SWN","Standard Array", new[]{14,12,11,10,9,7})]
        [TestCase("SWN", "Custom", new[] { 0, 0, 0, 0, 0, 0 })]
        [TestCase("5E", "Standard Array", new[]{15,14,13,12,10,8})]
        [TestCase("5E", "Point Buy", new[]{0,0,0,0,0,0})]
        public void GetAttributeArrayTest(string system, string type, int[] expectedResult)
        {
            Assert.That(Attributes.GetAttributeArray(system, type), Is.EqualTo(expectedResult));
        }
        
        [TestCase("SWN", "Random")]
        [TestCase("5E", "Random")]
        public void GetRandomAttributeArrayTest(string system, string type)
        {
            var tempArray = Attributes.GetAttributeArray(system, type);
            var count = 8;

            while (count > 0)
            {
                count--;
                Assert.That(tempArray[0], Is.InRange(3, 18));
            }
        }

        [TestCase("SWN", new[] { 15, 14, 13, 3, 10, 7 }, new[] { 1, 1, 0, -2, 0, -1 })]
        [TestCase("SWN", new[] { 14, 12, 11, 10, 9, 7 }, new[] { 1, 0, 0, 0, 0, -1 })]
        [TestCase("SWN", new[] { 0, 0, 0, 0, 0, 0 }, new[] { -2, -2, -2, -2, -2, -2 })]
        [TestCase("SWN", new[] { 15, 14, 13}, new[] { 1, 1, 0 })]
        [TestCase("SWN", new[] {26}, new[] {2})]
        [TestCase("5e", new[] { 26, 14, 13, 3, 10, 7 }, new[] { 8, 2, 1, -4, 0, -2 })]
        [TestCase("5e", new[] { 15, 14, 13, 12, 10, 8 }, new[] { 2, 2, 1, 1, 0, -1 })]
        [TestCase("5e", new[] { 0, 0, 0, 0, 0, 0 }, new[] { -5, -5, -5, -5, -5, -5 })]
        [TestCase("5e", new[] { 35, -5,  10}, new[] { 10,-5, 0 })]
        public void GetStarsWithoutNumberAttributeModifiersTest(string system, int[] attributeArray, int[] expectedResult)
        {

            Assert.That(Attributes.GetAttributeModifiers(system ,attributeArray), Is.EqualTo(expectedResult));

        }
    }
}