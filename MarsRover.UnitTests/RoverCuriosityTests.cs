using NUnit.Framework;

namespace MarsRover.UnitTests
{
    [TestFixture]
    public class RoverCuriosityTests
    {
        [TestCase(1, 1, 'N', 1, 2)]
        [TestCase(1, 1, 'S', 1, 0)]
        [TestCase(1, 1, 'E', 2, 1)]
        [TestCase(1, 1, 'W', 0, 1)]
        public void Move_Action_ShouldChangeXorYby1(int x, int y, char compassDirection, int expectedX, int expectedY)
        {
            var plateau = new Plateau(5 ,5);
            var rover = new RoverCuriosity(x, y, compassDirection, plateau);
            rover.MoveForward();
            Assert.That(rover.X() == expectedX);
            Assert.That(rover.Y() == expectedY);
        }

        [TestCase(1, 1, 'N', 'W')]
        [TestCase(1, 1, 'S', 'E')]
        [TestCase(1, 1, 'E', 'N')]
        [TestCase(1, 1, 'W', 'S')]
        public void RotateLeft_Action_ShouldChangeCompassDirection(int x, int y, char compassDirection, char expectedCompassDirection)
        {
            var plateau = new Plateau(5, 5);
            var rover = new RoverCuriosity(x, y, compassDirection, plateau);
            rover.RotateLeft();
            Assert.That(rover.CompassDirection() == expectedCompassDirection + "");
        }

        [TestCase(1, 1, 'N', 'E')]
        [TestCase(1, 1, 'S', 'W')]
        [TestCase(1, 1, 'E', 'S')]
        [TestCase(1, 1, 'W', 'N')]
        public void RotateRight_Action_ShouldChangeCompassDirection(int x, int y, char compassDirection, char expectedCompassDirection)
        {
            var plateau = new Plateau(5, 5);
            var rover = new RoverCuriosity(x, y, compassDirection, plateau);
            rover.RotateRight();
            Assert.That(rover.CompassDirection() == expectedCompassDirection + "");
        }
    }
}
