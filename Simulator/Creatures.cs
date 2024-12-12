
namespace Simulator;

public class Creatures
{
    public string? Name { get; set; }
    public int Level { get; set; }

    public Creatures(string name, int level = 1)
    {
        this.Name = name;
        this.Level = level;

    }


    public Creatures (){}

    public string Info
    {
        get { return $"{Name} [{Level}]"; }
    }

    public void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
    }



}

