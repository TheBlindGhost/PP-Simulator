
using System.Data;
using System.Diagnostics.Tracing;
using static Simulator.Directions;

namespace Simulator;




public static class DirectionParser
{
    public static List<Direction> Parse(string dire)
    {
        var directions = new List<Direction>();

        foreach (char c in dire.ToUpper())
        {
            if (c == 'U')
            {
                directions.Add(Direction.Up);
            }
            if (c == 'R')
            {
                directions.Add(Direction.Right);
            }
            if (c == 'D')
            {
                directions.Add(Direction.Down);
            }
            if (c == 'L')
            {
                directions.Add(Direction.Left);
            }


        }

        return directions;
    }
}
    



