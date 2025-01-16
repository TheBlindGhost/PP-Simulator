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
    public readonly List<IMappable>?[,] fields;
    private readonly Dictionary<Point, List<IMappable>> _creaturePositions = new();

    public SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20 || sizeY > 20)
            throw new ArgumentOutOfRangeException("Map dimensions must be at least 20x20.");

        SizeX = sizeX;
        SizeY = sizeY;

        fields = new List<IMappable>?[sizeX, sizeY];

    }

    public override void Add(IMappable inter, Point position)
    {

        if (!_creaturePositions.ContainsKey(position))
        {
            _creaturePositions[position] = new List<IMappable>();
        }

        _creaturePositions[position].Add(inter);
    }



    public override void Del(IMappable inter, Point position)
    {
        if (_creaturePositions.ContainsKey(position))
        {
            _creaturePositions[position].Remove(inter);
            if (_creaturePositions[position].Count == 0)
            {
                _creaturePositions.Remove(position);
            }
        }
    }

    public override List<IMappable> At(Point point)
    {

        return _creaturePositions.ContainsKey(point) ? _creaturePositions[point] : new List<IMappable>();
    }

    public override List<IMappable> At(int x, int y)
    {
        return At(new Point(x, y));
    }



    public override bool Exist(Point p)
    {
        return p.X >= 1 && p.X < SizeX+1 && p.Y >= 1 && p.Y < SizeY+1;
    }

    public override Point Next(Point p, Directions.Direction d)
    {
        if (Exist(p.Next(d))) { return p.Next(d); }
        else return p;


    }
    public override Point NextDiagonal(Point p, Directions.Direction d)
    {
        if (Exist(p.NextDiagonal(d))) { return p.NextDiagonal(d); }
        else return p;
    }


}

