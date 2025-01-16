using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Simulator.Creatures;
using static Simulator.Directions;

namespace Simulator;

public class Birds : Animals
{
    public override char Symbol => CanFly ? 'B' : 'b';

    public bool CanFly { get; set; } = true;


    public Birds(string name, bool canfly) : base(name)
    {
        Name = name;
        CanFly = canfly;
    }

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

    public override string Go(Direction direction)
    {
        Point nextPosition;

        if (CanFly)
        {
         
            nextPosition = CurrentMap.Next(Position, direction);
            nextPosition = CurrentMap.Next(nextPosition, direction);
        }
        else
        {
            nextPosition = CurrentMap.NextDiagonal(Position, direction);
        }

        CurrentMap.Move(Position, nextPosition, this);

        Position = nextPosition;

        return $"{direction.ToString().ToLower()}";
    }

}
