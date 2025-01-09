using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Map;

public class SmallTorusMap : SmallMap
{

    public SmallTorusMap(int size) : base(size, size)
    {
    }




    public override bool Exist(Creatures.Point p)
    {
        Rectangle m = new(0,0, SizeX, SizeY);
        return m.Contains(p);
    }

    public override Creatures.Point Next(Creatures.Point p, Directions.Direction d)
    {


        if (Exist(p.Next(d))) { return p.Next(d); }
        else if (p.Next(d).X > SizeX-1) { return new Creatures.Point(0, p.Next(d).Y); }
        else if (p.Next(d).X < 0) { return new Creatures.Point(SizeX - 1, p.Next(d).Y); }
        else if (p.Next(d).Y > SizeY - 1) { return new Creatures.Point(p.Next(d).X, 0); }
        else if (p.Next(d).Y < 0) { return new Creatures.Point(p.Next(d).X, SizeY - 1); }
        else return p;
    }

    public override Creatures.Point NextDiagonal(Creatures.Point p, Directions.Direction d)
    {
        if (Exist(p.NextDiagonal(d))) { return p.NextDiagonal(d); }
        else if (p.NextDiagonal(d).Y < 0 && p.NextDiagonal(d).X < 0) { return new Creatures.Point(SizeX -1, SizeY - 1); }
        else if (p.NextDiagonal(d).Y >SizeY - 1 && p.NextDiagonal(d).X > SizeX - 1) { return new Creatures.Point(0, SizeY - 1); }
        else if (p.NextDiagonal(d).X > SizeX - 1) { return new Creatures.Point(0, p.NextDiagonal(d).Y); }
        else if (p.NextDiagonal(d).X < 0) { return new Creatures.Point(SizeX - 1, p.NextDiagonal(d).Y); }
        else if (p.NextDiagonal(d).Y > SizeY - 1) { return new Creatures.Point(p.NextDiagonal(d).X, 0); }
        else if (p.NextDiagonal(d).Y < 0) { return new Creatures.Point(p.NextDiagonal(d).X, SizeY - 1); }
        
        else return p;
    }
}
