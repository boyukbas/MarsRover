namespace MarsRover
{
    class CompassPoint
    {
        public char CompassDirection { get; set; }

        public void Left()
        {

        }
    }

    public enum CompassDirection
    {
        North,
        East,
        South,
        West
    }
}
