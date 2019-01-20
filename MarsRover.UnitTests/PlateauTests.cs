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
            var rover = new RoverCuriosity(roverX,roverY,'N');
            Assert.That(() => plateau.AddRover(rover), Throws.InvalidOperationException);
        }

        [TestCase(5, 5, 5, 0)]
        [TestCase(5, 5, 0, 5)]
        public void AddRover_Action_ShouldRunWithoutException(int top, int right, int roverX, int roverY)
        {
            var plateau = new Plateau(top, right);
            var rover = new RoverCuriosity(roverX, roverY, 'N');
            plateau.AddRover(rover);
            Assert.That(plateau.Rovers[0].X() == roverX);
            Assert.That(plateau.Rovers[0].Y() == roverY);
        }
    }
}
