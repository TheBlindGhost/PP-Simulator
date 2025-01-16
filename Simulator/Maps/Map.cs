using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Simulator.Creatures;
using static Simulator.Directions;

namespace Simulator.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    public int SizeX { get; }
    public int SizeY { get; }

    public readonly Rectangle mapArea;

    public readonly List<IMappable>?[,] fields;
    private readonly Dictionary<Point, List<IMappable>> _creaturePositions = new();


    public void Move(Point from, Point to, IMappable inter)
    {

        Del(inter, from);
        Add(inter, to);

    }



    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < 5 || sizeY < 5)
        {
            throw new ArgumentOutOfRangeException("Map dimensions must be at least 5x5.");
        }

        SizeX = sizeX;
        SizeY = sizeY;

    }




    public void Add(IMappable inter, Point position)
    {

        if (!_creaturePositions.ContainsKey(position))
        {
            _creaturePositions[position] = new List<IMappable>();
        }

        _creaturePositions[position].Add(inter);
    }



    public void Del(IMappable inter, Point position)
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

    public List<IMappable> At(Point point)
    {

        return _creaturePositions.ContainsKey(point) ? _creaturePositions[point] : new List<IMappable>();
    }

    public List<IMappable> At(int x, int y)
    {
        return At(new Point(x, y));
    }

    public virtual bool Exist(Point p)
    {
        return p.X >= 1 && p.X < SizeX + 1 && p.Y >= 1 && p.Y < SizeY + 1;
    }

    public virtual Point Next(Point p, Directions.Direction d)
    {
        if (Exist(p.Next(d))) { return p.Next(d); }
        else return p;


    }
    public virtual Point NextDiagonal(Point p, Directions.Direction d)
    {
        if (Exist(p.NextDiagonal(d))) { return p.NextDiagonal(d); }
        else return p;
    }

}
