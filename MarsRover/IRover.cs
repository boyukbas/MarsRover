using System.Collections.Generic;

namespace MarsRover
{
   public interface IRover
    {
        int X();

        int Y();

        IRover MakeAllMoves(string moves = "");
    }
}
