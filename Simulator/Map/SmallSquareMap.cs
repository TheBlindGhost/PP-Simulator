using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Simulator.Creatures;
using static Simulator.Directions;


namespace Simulator.Map;

public class SmallSquareMap : Map
{
    public int Size;
    public SmallSquareMap(int size) 
    {  
        if (size < 5 || size > 25) {  throw new ArgumentOutOfRangeException("The map has the wrong size"); }       
        Size = size; 
    }


    public override bool Exist(Creatures.Point p)
    {
        Rectangle m = new(0,0, Size, Size );
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
