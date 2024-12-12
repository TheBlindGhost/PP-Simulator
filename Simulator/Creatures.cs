
using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;
using static Simulator.Directions;

namespace Simulator;

public class Creatures
{

    private string name = "Unknown";
    private int level = 1;
    public string? Name
    {
        get { return name; }
        init
        {

                value = value.Trim();
                if (value.Length < 3)
                {
                    for (int i = value.Length; i <= 2; i++)
                    {
                        value += "#";
                    }

                }
                else if (value.Length > 25)
                {
                    value = value.Substring(0, 25);
                    value = value.Trim();
                }
                string temp = value.Substring(0, 1);
                name = temp.ToUpper() + value.Substring(1, value.Length - 1);

        }
    }


    public int Level
    {
        get { return level; }
        init
        {
                if (value < 1) { level = 1; }
                else if (value > 10) { level = 10; }
                else { level = value; }

        }


    }



    public Creatures(string name, int level = 1)
    {
        this.Name = name;
        this.Level = level;

    }

    public Creatures() { }

    public string Info
    {
        get { return $"{Name} [{Level}]"; }
    }

    public void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
    }

    public void Upgrade()
    {
        if (level < 10) { level += 1; }

    }

    public void Go(Direction direction)
    {
        Console.WriteLine($"{Name} goes {direction.ToString().ToLower()}.");
    }
    public void Go(Direction[] direction)
    {
        foreach (var Directions in direction)
        {
            Go(Directions);
        }

    }
    public void Go(string directions)
    {
        var parse = DirectionParser.Parse(directions);
        Go(parse);
    }
}





