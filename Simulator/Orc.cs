using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

public class Orc : Creatures
{
    private int rage = 1;
    private int hunt = 0;


    public int Rage { 
        get { return rage; }
        init
        {
            if (value < 0) rage = 0;
            else if (value > 10) rage = 10;
            else rage = value;
        }
            
    }



    public Orc(string name, int level = 1, int rage = 1) : base(name, level)
    {
        Rage = rage;
    }



    public void Hunt()
    {
        Console.WriteLine($"{Name} is hunting.");
        hunt++;
        if (hunt % 2 == 0 && hunt != 0 && rage < 10)
        {
            rage++;
        }
    }



    public override void SayHi() => Console.WriteLine(
    $"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.");

    public override void Power()
    {
        Pow = (Level * 7) + (3 * Rage);
        Console.WriteLine(Pow);
    }


    public Orc() { }




}