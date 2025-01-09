using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Simulator.Creatures;


namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    private readonly int SizeX;
    private readonly int SizeY;
    public readonly List<Creatures>?[,] fields;


 public SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20 || sizeY > 20)
            throw new ArgumentOutOfRangeException("Map dimensions must be at least 20x20.");

        SizeX = sizeX;
        SizeY = sizeY;

        fields = new List<Creatures>?[sizeX, sizeY];

    }

    public override void Add(Creatures creature, Point position)
    {
        if (!Exist(position))
            throw new ArgumentException("Point not on the map");
        if (fields[position.X, position.Y] == null)
        {
            fields[position.X, position.Y] = new List<Creatures>();
        }
        fields[position.X, position.Y].Add(creature);
    }


    public override void Del(Creatures creature, Point position)
    {
        if (!Exist(position))
            throw new ArgumentException("Point not on the map");
        if (fields[position.X, position.Y] != null)
        {
            fields[position.X, position.Y].Remove(creature);
        }
    }

    public override List<Creatures> At(Point point)
    {

        return fields[point.X, point.Y] ?? new List<Creatures>();
    }

    public override List<Creatures> At(int x, int y)
    {
        return At(new Point(x, y));
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

