namespace MarsRover
{
    public class RoverCuriosity : IRover
    {
        private int _x;
        private int _y;
        private IDirection _compassDirection;
        public string MoveList { get; set; }

        /// <summary>
        /// Rover constructor
        /// </summary>
        /// <param name="x">x co-ordinate</param>
        /// <param name="y">y co-ordinate</param>
        /// <param name="compassDirection">Can have one of these values 'N','S','W','E'. N -> North, S -> South, W -> West, E -> East</param>
        public RoverCuriosity(int x, int y, char compassDirection)
        {
            _x = x;
            _y = y;
            _compassDirection = Direction.CreateDirection(compassDirection);
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
            if (_compassDirection.ToString() == "N")
                _y++;
            else if (_compassDirection.ToString() == "W")
                _x--;
            else if (_compassDirection.ToString() == "S")
                _y--;
            else if (_compassDirection.ToString() == "E")
                _x++;
        }

        public override string ToString()
        {
            return $"{_x} {_y} {_compassDirection}";
        }
    }
}
