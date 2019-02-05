using System;

namespace MarsRover
{
    public class RoverCuriosity : IRover
    {
        private int _x;
        private int _y;
        private IDirection _compassDirection;
        public string MoveList { get; set; }
        public Plateau Plateau { get; set; }

        /// <summary>
        /// Rover constructor
        /// </summary>
        /// <param name="x">x co-ordinate</param>
        /// <param name="y">y co-ordinate</param>
        /// <param name="compassDirection">Can have one of these values 'N','S','W','E'. N -> North, S -> South, W -> West, E -> East</param>
        public RoverCuriosity(int x, int y, char compassDirection, Plateau plateau)
        {
            _x = x;
            _y = y;
            _compassDirection = Direction.CreateDirection(compassDirection);
            Plateau = plateau;
        }

        public int X()
        {
            return _x;
        }

        public int Y()
        {
            return _y;
        }

        public string CompassDirection()
        {
            return _compassDirection.ToString();
        }

        public IRover MakeAllMoves(string moveList = "")
        {
            if (string.IsNullOrWhiteSpace(moveList))
                moveList = this.MoveList;

            foreach (var move in moveList)
            {
                if (move == 'L')
                    RotateLeft();
                else if (move == 'R')
                    RotateRight();
                else if (move == 'M')
                    MoveForward();
            }
            return this;
        }

        public void RotateLeft()
        {
            _compassDirection = _compassDirection.Left();
        }

        public void RotateRight()
        {
            _compassDirection = _compassDirection.Right();

        }

        public void MoveForward()
        {
            var nextX = _x;
            var nextY = _y;

            if (_compassDirection.ToString() == "N")
                nextY = _y + 1;
            else if (_compassDirection.ToString() == "W")
                nextX = _x-1;
            else if (_compassDirection.ToString() == "S")
                nextY = _y-1;
            else if (_compassDirection.ToString() == "E")
                nextX = _x+1;

            if (Plateau.IsPositionAvaible(nextX, nextY))
            {
                _x = nextX;
                _y = nextY;
            }
            else
            {
                throw new InvalidOperationException("Position unavailable");
            }
        }

        public override string ToString()
        {
            return $"{_x} {_y} {_compassDirection}";
        }
    }
}
