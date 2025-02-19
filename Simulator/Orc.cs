﻿using System;
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
    public override char Symbol => 'O';
    private int rage = 1;
    private int hunt = 0;


    public int Rage { 
        get { return rage; }
        init
        {
            rage = Validator.Limiter(value, 0, 10);
        }
            
    }



    public Orc(string name, int level = 1, int rage = 1) : base(name, level)
    {
        Rage = rage;
    }



    public void Hunt()
    {
        hunt++;
        if (hunt % 2 == 0 && hunt != 0 && rage < 10)
        {
            rage++;
        }
    }



    public override string Greeting() => $"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.";

    public override int Power()
    {
        Pow = (Level * 7) + (3 * Rage);
        return Pow;
    }

    public override string Info()
    {
        string temp = $"{Name} [{Level}] [{Rage}]";
        return temp;
    }


    public Orc() { }




}