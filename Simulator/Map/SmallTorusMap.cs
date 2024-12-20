using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Map;

public class SmallTorusMap : Map
{

    public int Size;
    public SmallTorusMap(int size)
    {
        if (size < 5 || size > 20) { throw new ArgumentOutOfRangeException("The map has the wrong size"); }
        else Size = size;
    }





    public override bool Exist(Creatures.Point p)
    {
        Rectangle m = new(0,0, Size, Size);
        return m.Contains(p);
    }

    public override Creatures.Point Next(Creatures.Point p, Directions.Direction d)
    {


        if (Exist(p.Next(d))) { return p.Next(d); }
        else if (p.Next(d).X > Size-1) { return new Creatures.Point(0, p.Next(d).Y); }
        else if (p.Next(d).X < 0) { return new Creatures.Point(Size - 1, p.Next(d).Y); }
        else if (p.Next(d).Y > Size - 1) { return new Creatures.Point(p.Next(d).X, 0); }
        else if (p.Next(d).Y < 0) { return new Creatures.Point(p.Next(d).X, Size - 1); }
        else return p;
    }

    public override Creatures.Point NextDiagonal(Creatures.Point p, Directions.Direction d)
    {
        if (Exist(p.NextDiagonal(d))) { return p.NextDiagonal(d); }
        else if (p.NextDiagonal(d).Y < 0 && p.NextDiagonal(d).X < 0) { return new Creatures.Point(Size -1, Size - 1); }
        else if (p.NextDiagonal(d).Y >Size - 1 && p.NextDiagonal(d).X > Size - 1) { return new Creatures.Point(0, Size - 1); }
        else if (p.NextDiagonal(d).X > Size - 1) { return new Creatures.Point(0, p.NextDiagonal(d).Y); }
        else if (p.NextDiagonal(d).X < 0) { return new Creatures.Point(Size - 1, p.NextDiagonal(d).Y); }
        else if (p.NextDiagonal(d).Y > Size - 1) { return new Creatures.Point(p.NextDiagonal(d).X, 0); }
        else if (p.NextDiagonal(d).Y < 0) { return new Creatures.Point(p.NextDiagonal(d).X, Size - 1); }
        
        else return p;
    }
}
