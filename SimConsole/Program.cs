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
        SmallSquareMap map = new(5);
        List<Creatures> creatures = [new Orc("Gorbag"), new Elf("Elandor")];
        List<Point> points = [new(3, 3), new(4, 4)];
        string moves = "dlrludl";

        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);


        Console.WriteLine("Welcome to the SIMULATION");
       
        mapVisualizer.Draw();
        while (simulation.Finished == false)
        {

       

            Console.WriteLine("Press a button for next turn");

            Console.ReadKey();

            Console.WriteLine($"{simulation.CurrentCreature} {simulation.CurrentCreature.Position} goes {simulation.CurrentMoveName}:");

            simulation.Turn();
            
            


            mapVisualizer.Draw();

        }

    }

}