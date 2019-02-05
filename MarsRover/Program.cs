using System;

namespace MarsRover
{
    class Program
    {
        private const int InputCount = 2;

        static void Main(string[] args)
        {
            var plateau = ReadPlateau();

            for (var i = 0; i < InputCount; i++)
            {
                try
                {
                    plateau.AddRover(ReadRover(plateau));
                }
                catch (InvalidOperationException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
            foreach (var rover in plateau.Rovers)
                rover.MakeAllMoves();

            Console.WriteLine(plateau.PrintCurrentStatus());
        }

        private static Plateau ReadPlateau()
        {
            var plateauInput = Console.ReadLine().Split(' ');

            var right = Convert.ToInt32(plateauInput[0]);
            var top = Convert.ToInt32(plateauInput[1]);
            return new Plateau(top, right);
        }

        private static RoverCuriosity ReadRover(Plateau plateau)
        {
            var roverInput = Console.ReadLine().Split(' ');

            var x = Convert.ToInt32(roverInput[0]);
            var y = Convert.ToInt32(roverInput[1]);
            var compassDirection = roverInput[2][0];
            var rover = new RoverCuriosity(x, y, compassDirection, plateau)
            {
                MoveList = Console.ReadLine()
            };
            return rover;
        }
    }
}
