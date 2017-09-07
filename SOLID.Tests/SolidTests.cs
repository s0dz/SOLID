
using NUnit.Framework;
using NUnit.Framework.Internal;
using SOLID.Principles;

namespace SOLID.Tests
{
    [TestFixture]
    public class SolidTests
    {
        [SetUp]
        public void SetUp()
        {
            
        }

        [Test]
        public void Rectangle2x3Test()
        {
            var rectangle = new LiskovSubstitutionPrinciple.Rectangle {Height = 2, Width = 3};
            var result = LiskovSubstitutionPrinciple.AreaCalculator.CalculateArea(rectangle);
            Assert.AreEqual(6, result);
        }

        [Test]
        public void Square3x3Test()
        {
            var square = new LiskovSubstitutionPrinciple.Square {Height = 3, Width = 3};
            var result = LiskovSubstitutionPrinciple.AreaCalculator.CalculateArea(square);
            Assert.AreEqual(result, 9);
        }
    }
}
