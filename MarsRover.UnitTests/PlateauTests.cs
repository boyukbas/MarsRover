using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace MarsRover.UnitTests
{
    [TestFixture]
    public class PlateauTests
    {
        [TestCase(5, 5, 6, 0)]
        [TestCase(5, 5, -1, 5)]
        [TestCase(5, 5, -1, 6)]
        public void AddRover_IsOutOfTheBoundsOfThePlateau_ShouldThrowInvalidOperationException(int top, int right, int roverX, int roverY)
        {
            var plateau = new Plateau(top,right);
            var rover = new RoverCuriosity(roverX,roverY,'N', plateau);
            Assert.That(() => plateau.AddRover(rover), Throws.InvalidOperationException);
        }

        [TestCase(1, 0, 'N')]
        [TestCase(1, 2, 'S')]
        [TestCase(0, 1, 'E')]
        [TestCase(2, 1, 'W')]
        public void Move_Action_ShouldThrowException(int x, int y, char compassDirection)
        {
            var plateau = new Plateau(5, 5);
            plateau.AddRover(new RoverCuriosity(1, 1, 'N', plateau));

            var rover = new RoverCuriosity(x, y, compassDirection, plateau);
            plateau.AddRover(rover);

            Assert.That(() => rover.MoveForward(), Throws.InvalidOperationException);
        }

        [TestCase(5, 5, 5, 0)]
        [TestCase(5, 5, 0, 5)]
        public void AddRover_Action_ShouldRunWithoutException(int top, int right, int roverX, int roverY)
        {
            var plateau = new Plateau(top, right);
            var rover = new RoverCuriosity(roverX, roverY, 'N', plateau);
            plateau.AddRover(rover);
            Assert.That(plateau.Rovers[0].X() == roverX);
            Assert.That(plateau.Rovers[0].Y() == roverY);
        }
    }
}
