
using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;
using static Simulator.Directions;

namespace Simulator;

public abstract class Creatures
{

    private string name = "Unknown";
    private int level = 1;
    private int power = 0;

    public override string ToString()
    {
        Type objtype = this.GetType();
        string temp = objtype.Name;
        string temp2 = this.Info();
        string value = temp.ToUpper() + ": " + temp2;
        return value;   
    }


    public int Pow { 
        get {  return power; }
        set {  power = value; } 
    }

    public string? Name
    {
        get { return name; }
        init
        {
            name = Validator.Shortener(value, 3, 25, '#');

        }
    }


    public int Level
    {
        get { return level; }
        init
        {
            level = Validator.Limiter(value, 0, 10);

        }


    }



    public Creatures(string name, int level = 1)
    {
        this.Name = name;
        this.Level = level;

    }

    public Creatures() { }

    public abstract string Info();

    public abstract void SayHi();

    public abstract void Power();
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





