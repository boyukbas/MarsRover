namespace MarsRover
{
    public class Rover
    {
        public int X { private set; get; }
        public int Y { private set; get; }
        public char CompassDirection { private set; get; }

        /// <summary>
        /// Rover constructor
        /// </summary>
        /// <param name="x">x co-ordinate</param>
        /// <param name="y">y co-ordinate</param>
        /// <param name="compassDirection">Can have one of these values 'N','S','W','E'. N -> North, S -> South, W -> West, E -> East</param>
        public Rover(int x, int y, char compassDirection)
        {
            this.X = x;
            this.Y = y;
            this.CompassDirection = compassDirection;
        }

        /// <summary>
        /// Changes the CompassDirection property by direction input
        /// </summary>
        /// <param name="action">Can have 2 value. 'L' and 'R'. L means Left and R for Right</param>
        /// <returns></returns>
        public Rover Action(char action)
        {
            if (action == 'L')
                RotateLeft();
            else if (action == 'R')
                RotateRight();
            else if (action == 'M')
                Move();
            return this;
        }

        private void RotateLeft()
        {
            if (CompassDirection == 'N')
                CompassDirection = 'W';
            else if (CompassDirection == 'W')
                CompassDirection = 'S';
            else if (CompassDirection == 'S')
                CompassDirection = 'E';
            else if (CompassDirection == 'E')
                CompassDirection = 'N';
        }

        private void RotateRight()
        {
            if (CompassDirection == 'N')
                CompassDirection = 'E';
            else if (CompassDirection == 'E')
                CompassDirection = 'S';
            else if (CompassDirection == 'S')
                CompassDirection = 'W';
            else if (CompassDirection == 'W')
                CompassDirection = 'N';
        }

        private void Move()
        {
            if (CompassDirection == 'N')
                Y++;
            else if (CompassDirection == 'W')
                X++;
            else if (CompassDirection == 'S')
                Y--;
            else if (CompassDirection == 'E')
                X--;
        }

        public override string ToString()
        {
            return $"{X} {Y} {CompassDirection}";
        }
    }
}
