using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Simulator.Creatures;


namespace Simulator.Map;

public abstract class SmallMap : Map
{
    private readonly int SizeX;
    private readonly int SizeY;

    public SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20 || sizeY > 20)
            throw new ArgumentOutOfRangeException("Map dimensions must be at least 20x20.");

        SizeX = sizeX;
        SizeY = sizeY;

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

