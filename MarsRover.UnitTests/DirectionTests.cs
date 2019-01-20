using NUnit.Framework;

namespace MarsRover.UnitTests
{
    [TestFixture]
    public class DirectionTests
    {
        [TestCase('N', 'W')]
        [TestCase('S', 'E')]
        [TestCase('E', 'N')]
        [TestCase('W', 'S')]
        public void Left_Method_ShouldFindTheCorrectDirection(char compassDirection, char expectedDirection)
        {
            var direction = Direction.CreateDirection(compassDirection);
            direction = direction.Left();
            Assert.That(direction.ToString() == expectedDirection + "");
        }
        [TestCase('N', 'E')]
        [TestCase('S', 'W')]
        [TestCase('E', 'S')]
        [TestCase('W', 'N')]
        public void Right_Method_ShouldFindTheCorrectDirection(char compassDirection, char expectedDirection)
        {
            var direction = Direction.CreateDirection(compassDirection);
            direction = direction.Right();
            Assert.That(direction.ToString() == expectedDirection + "");
        }
    }
}
