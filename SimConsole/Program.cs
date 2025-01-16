using Simulator.Maps;
using Simulator;
using System.Text;
using static Simulator.Creatures;

namespace SimConsole;

internal class Program
{
    static void Main(string[] args)
    {

        Console.OutputEncoding = Encoding.UTF8;
        SmallTorusMap map = new SmallTorusMap(8,6);
        List<IMappable> creatures = [
            new Orc("Gorbag"), 
            new Elf("Elandor"),
            new Animals("Rabbits"),
            new Birds("Orły", true),
            new Birds("Strusie",false)
            ];



        List<Point> points = [new(3, 3), new(4, 4), new(8,3), new(5,5), new(1,1)];
        string moves = "udrludl";

        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);

        SimulationHistory history = new(simulation);
        LogVisulizer visualizer = new(history);


        
        int turnIndex = 0;
        while (turnIndex < history.TurnLogs.Count)
        {
            visualizer.Draw(turnIndex);
            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.RightArrow)
            {
                turnIndex++;
            }
            else if (key == ConsoleKey.LeftArrow)
            {
                turnIndex--;
            }


        }
            
 
        


    










    }

}