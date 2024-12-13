using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

public class Elf : Creatures
{

    private int agility = 1;
    private int sing = 0;

    public int Agility { 
        get { return agility; }
        init
        {
            if (value < 0) agility = 0;
            else if (value > 10) agility = 10;
            else agility = value;
        }
    }

    public Elf(string name, int level = 1, int agility = 1) : base(name, level)
    {  
        Agility = agility; 
    }

    public void Sing()
    {
        Console.WriteLine($"{Name} is singing.");
        sing ++;
        if (sing % 3 == 0 && sing != 0 && agility < 10) 
        {
            agility++;
        }
    }
    public override void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.");

    public override void Power()
    {
        Pow = (Level * 8) + (2 * Agility);
        Console.WriteLine(Pow);
    }



    public Elf() { }

}