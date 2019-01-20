using System;

namespace MarsRover
{
    public class Direction
    {
        public static IDirection CreateDirection(char initial)
        {
            if (initial == 'N')
                return new DirectionNorth();
            if (initial == 'S')
                return new DirectionSouth();
            if (initial == 'E')
                return new DirectionEast();
            if (initial == 'W')
                return new DirectionWest();
            throw new InvalidCastException($"Invalid Direction initial -> {initial}");
        }
    }

    public class DirectionNorth : IDirection
    {
        public char Initial { get; } = 'N';
        public IDirection Left() => new DirectionWest();
        public IDirection Right() => new DirectionEast();
        public override string ToString() => Initial + "";
    }
    public class DirectionSouth : IDirection
    {
        public char Initial { get; } = 'S';
        public IDirection Left() => new DirectionEast();
        public IDirection Right() => new DirectionWest();
        public override string ToString() => Initial + "";
    }
    public class DirectionEast : IDirection
    {
        public char Initial { get; } = 'E';
        public IDirection Left() => new DirectionNorth();
        public IDirection Right() => new DirectionSouth();
        public override string ToString() => Initial + "";
    }
    public class DirectionWest : IDirection
    {
        public char Initial { get; } = 'W';
        public IDirection Left() => new DirectionSouth();
        public IDirection Right() => new DirectionNorth();
        public override string ToString() => Initial + "";
    }

    #region FactoryPattern. I am not sure
    //    public abstract class DirectionFactory { 
    //        public abstract IDirection GetDirection(char initial);
    //    }
    //    public class ConcreteDirectionFactory : DirectionFactory
    //{
    //        public override IDirection GetDirection(char initial)
    //        {
    //            if (initial == 'N')
    //                return new DirectionNorth();
    //            if (initial == 'S')
    //                return new DirectionSouth();
    //            if (initial == 'E')
    //                return new DirectionEast();
    //            if (initial == 'W')
    //                return new DirectionWest();
    //            throw new InvalidCastException($"Invalid Direction initial -> {initial}");
    //        }
    //    } 
    #endregion

}
