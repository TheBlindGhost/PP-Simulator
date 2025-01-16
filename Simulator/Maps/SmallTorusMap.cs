using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class SmallTorusMap : SmallMap
{

    public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {

    }



    public override Creatures.Point Next(Creatures.Point p, Directions.Direction d)
    {


        if (Exist(p.Next(d))) { return p.Next(d); }
        else if (p.Next(d).X > SizeX) { return new Creatures.Point(1, p.Next(d).Y); }
        else if (p.Next(d).X < 1) { return new Creatures.Point(SizeX , p.Next(d).Y); }
        else if (p.Next(d).Y > SizeY) { return new Creatures.Point(p.Next(d).X, 1); }
        else if (p.Next(d).Y < 1) { return new Creatures.Point(p.Next(d).X, SizeY); }
        else return p;
    }

    public override Creatures.Point NextDiagonal(Creatures.Point p, Directions.Direction d)
    {
        if (Exist(p.NextDiagonal(d))) { return p.NextDiagonal(d); }

        else if (p.NextDiagonal(d).Y < 1 && p.NextDiagonal(d).X < 1) { return new Creatures.Point(SizeX, SizeY ); }
        
        else if (p.NextDiagonal(d).Y <SizeY && p.NextDiagonal(d).X > SizeX) { return new Creatures.Point(1, SizeY); }

        else if (p.NextDiagonal(d).Y > SizeY && p.NextDiagonal(d).X < SizeX) { return new Creatures.Point(SizeX, 1); }

        else if (p.NextDiagonal(d).X > SizeX ) { return new Creatures.Point(1, p.NextDiagonal(d).Y); }
        
        else if (p.NextDiagonal(d).X < 1) { return new Creatures.Point(SizeX, p.NextDiagonal(d).Y); }
        
        else if (p.NextDiagonal(d).Y > SizeY) { return new Creatures.Point(p.NextDiagonal(d).X, 1); }
        
        else if (p.NextDiagonal(d).Y < 1) { return new Creatures.Point(p.NextDiagonal(d).X, SizeY); }
        
        else return p;
    }
}
