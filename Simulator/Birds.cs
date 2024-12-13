using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Birds : Animals
{
    public bool CanFly { get; set; } = true;

    public override string Info
    {
        get {
            char Temp = ' ';
            if (CanFly == true) { Temp = '+'; }
            else { Temp = '-'; }
            return $"{Description} (fly{Temp}) <{Size}>"; 
        }
        set{ Info = value; }
    }



}
