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
    private readonly Dictionary<Point, List<Creatures>> _creaturePositions = new();

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

        if (!_creaturePositions.ContainsKey(position))
        {
            _creaturePositions[position] = new List<Creatures>();
        }

        _creaturePositions[position].Add(creature);
    }



    public override void Del(Creatures creature, Point position)
    {
        if (_creaturePositions.ContainsKey(position))
        {
            _creaturePositions[position].Remove(creature);
            if (_creaturePositions[position].Count == 0)
            {
                _creaturePositions.Remove(position);
            }
        }
    }

    public override List<Creatures> At(Point point)
    {

        return _creaturePositions.ContainsKey(point) ? _creaturePositions[point] : new List<Creatures>();
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

