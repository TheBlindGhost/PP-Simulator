using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;
using Simulator.Maps;
using static Simulator.Creatures;
namespace SimConsole;

public class LogVisulizer
{
    SimulationHistory Log { get; }
    public LogVisulizer(SimulationHistory log)
    {
        Log = log;
    }

    public void Draw(int turnIndex)
    {
        var turnLog = Log.TurnLogs[turnIndex];




        Console.Write(Box.TopLeft);
        for (int i = 0; i < Log.SizeX - 1; i++)
        {
            Console.Write(Box.Horizontal);
            Console.Write(Box.TopMid);
        }
        Console.Write(Box.Horizontal);
        Console.Write(Box.TopRight + "\n");







        for (int i = 1; i < Log.SizeY + 1; i++)
        {


            for (int j = 1; j < Log.SizeX + 1; j++)
            {
                Console.Write(Box.Vertical);
                Point point = new Point(j, i);
                if (turnLog.Symbols.ContainsKey(point))
                {
                    Console.Write(turnLog.Symbols[point]);
                }
                else
                {
                    Console.Write(" ");
                }


            }
            Console.Write(Box.Vertical);
            Console.WriteLine();


            if (i < Log.SizeY)
            {
                Console.Write(Box.MidLeft);
                for (int j = 1; j < Log.SizeX; j++)
                {
                    Console.Write(Box.Horizontal);
                    Console.Write(Box.Cross);


                }
                Console.Write(Box.Horizontal);
                Console.Write(Box.MidRight);
                Console.WriteLine();
            }

        }








        Console.Write(Box.BottomLeft);
        for (int i = 0; i < Log.SizeX - 1; i++)
        {
            Console.Write(Box.Horizontal);
            Console.Write(Box.BottomMid);
        }
        Console.Write(Box.Horizontal);
        Console.Write(Box.BottomRight + "\n");


















    }
}