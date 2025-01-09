using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Simulator.Creatures;
using static Simulator.Directions;


namespace Simulator.Maps;

public class SmallSquareMap : SmallMap
{
    public SmallSquareMap(int size) : base(size, size)
    {
    }


    public override bool Exist(Creatures.Point p)
    {
        Rectangle m = new(0, 0, SizeX, SizeY);
        return m.Contains(p);
    }

    public override Creatures.Point Next(Creatures.Point p, Directions.Direction d)
    {
        if (Exist(p.Next(d))) { return p.Next(d); }
        else return p;


    }

    public override Creatures.Point NextDiagonal(Creatures.Point p, Directions.Direction d)
    {
        if (Exist(p.NextDiagonal(d))) { return p.NextDiagonal(d); }
        else return p;
    }
}


