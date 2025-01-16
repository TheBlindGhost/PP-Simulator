using System.Globalization;
using Simulator;
using Simulator.Maps;
using static Simulator.Creatures;


namespace SimConsole;


public class MapVisualizer
{
    private readonly Map _map;
    public MapVisualizer(Map map)
    {
        _map = map;
    }

    public void Draw()
    {
        Console.Write(Box.TopLeft);
        for (int i = 0; i < _map.SizeX-1; i++)
        {
            Console.Write(Box.Horizontal);
            Console.Write(Box.TopMid);
        }
        Console.Write(Box.Horizontal);
        Console.Write(Box.TopRight+"\n");







        for (int i = 1; i < _map.SizeY+1; i++)
        {
     

            for (int j = 1; j < _map.SizeX+1; j++)
            {
                Console.Write(Box.Vertical);
                Point point = new Point(j, i);
                var creatures = _map.At(point);
                switch (creatures.Count)
                {
                    case 1:
                        var creature = creatures[0];
                        Console.Write(creature.Symbol);
                        break;
                            
                    case 2:
                        Console.Write("X");
                        break;
                    default:
                        Console.Write(' ');
                        break;
                }


             
            }
            Console.Write(Box.Vertical);
            Console.WriteLine();
            
            
            if (i < _map.SizeY)
            {
                Console.Write(Box.MidLeft);
                for (int j = 1; j < _map.SizeX; j++)
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
        for (int i = 0; i < _map.SizeX - 1; i++)
        {
            Console.Write(Box.Horizontal);
            Console.Write(Box.BottomMid);
        }
        Console.Write(Box.Horizontal);
        Console.Write(Box.BottomRight + "\n");


    }
}