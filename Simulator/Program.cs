using Simulator.Map;
using static Simulator.Creatures;
using static Simulator.Directions;


namespace Simulator;

internal class Program
{
    static void Lab4b()
    {
        object[] myObjects = {
        new Animals() { Description = "dogs"},
        new Birds { Description = "  eagles ", Size = 10 },
        new Elf("e", 15, -3),
        new Orc("morgash", 6, 4)
    };
        Console.WriteLine("\nMy objects:");
        foreach (var o in myObjects) Console.WriteLine(o);
        /*
            My objects:
            ANIMALS: Dogs <3>
            BIRDS: Eagles (fly+) <10>
            ELF: E## [10][0]
            ORC: Morgash [6][4]
        */
    }
    static void Lab4a()
    {
        Console.WriteLine("HUNT TEST\n");
        var o = new Orc() { Name = "Gorbag", Rage = 7 };
        o.SayHi();
        for (int i = 0; i < 10; i++)
        {
            o.Hunt();
            o.SayHi();
        }

        Console.WriteLine("\nSING TEST\n");
        var e = new Elf("Legolas", agility: 2);
        e.SayHi();
        for (int i = 0; i < 10; i++)
        {
            e.Sing();
            e.SayHi();
        }

        Console.WriteLine("\nPOWER TEST\n");
        Creatures[] creatures = {
        o,
        e,
        new Orc("Morgash", 3, 8),
        new Elf("Elandor", 5, 3)
    };
        foreach (Creatures creature in creatures)
        {
            Console.Write($"{creature.Name,-15}: ");
            creature.Power();

        }
    }
    static void Lab5a()
    {
        Rectangle c = new(-1, -3, 5, 10);
        Point p = new(1, 2);
        Console.WriteLine(c.Contains(p));


        Rectangle b = new(1, 3, -5, -10);
        Console.WriteLine(b.ToString());

        try
        {
            Rectangle d = new(1, 1, 1, 1);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

        

    }
    static void Lab5b()
    {
        SmallSquareMap c = new (10);
        Point p = new(5, 9);

        Console.WriteLine(c.Exist(p));

        Console.WriteLine(c.Next(p, Direction.Down));

        Console.WriteLine(c.NextDiagonal(p, Direction.Up));




    }



    static void Main(string[] args)
    {
        Lab5b();
    }



}


