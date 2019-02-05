using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class Plateau
    {
        public int Top { get; }

        public int Right { get; }

        public List<IRover> Rovers { get; } = new List<IRover>();

        public Plateau(int top, int right)
        {
            this.Top = top;
            this.Right = right;
        }

        public void AddRover(IRover rover)
        {
            var x = rover.X();
            var y = rover.Y();
            if (x > Right || x < 0)
                throw new System.InvalidOperationException($"X position({x}) of the Rover({x},{y}) is out of the bounds of the Plateau({Right},{Top})");
            if (y > Top || y < 0)
                throw new System.InvalidOperationException($"Y position({y}) of the Rover({x},{y}) is out of the bounds of the Plateau({Right},{Top})");

            Rovers.Add(rover);
        }

        public bool IsPositionAvaible(int x, int y)
        {
            foreach (var rover in Rovers)
            {
                if (rover.X() == x && rover.Y() == y)
                    return false;
            }

            return true;
        }

        public string PrintCurrentStatus()
        {
            var roverList = new StringBuilder();

            foreach (var rover in Rovers)
                roverList.AppendLine(rover.ToString());

            return roverList.ToString();
        }
    }
}
