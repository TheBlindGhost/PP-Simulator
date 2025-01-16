using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

public class Elf : Creatures
{

    public override char Symbol => 'E';
    private int agility = 1;
    private int sing = 0;

    public int Agility { 
        get { return agility; }
        init
        {
            agility = Validator.Limiter(value, 0, 10);
        }
    }

    public Elf(string name, int level = 1, int agility = 1) : base(name, level)
    {  
        Agility = agility; 
    }

    public void Sing()
    {
        sing ++;
        if (sing % 3 == 0 && sing != 0 && agility < 10) 
        {
            agility++;
        }
    }
    public override string Greeting() => $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.";

    public override int Power()
    {
        Pow = (Level * 8) + (2 * Agility);
        return Pow;
    }

    public override string Info()
    {
       string temp = $"{Name} [{Level}] [{Agility}]";
       return temp;
    }


    public Elf() { }

}