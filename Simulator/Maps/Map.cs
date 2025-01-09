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

    public abstract void Add(Creatures creature,Point position);
    public abstract void Del(Creatures creature, Point position);

    public void Move(Point from, Point to, Creatures creature)
    {
                if (!mapArea.Contains(from) || !mapArea.Contains(to))
        {
            throw new ArgumentOutOfRangeException("Punkty muszą znajdować się w obrębie mapy.");
        }


        Del(creature, from);
        Add(creature, to);

    }

    public abstract List<Creatures> At(Point point);

    public abstract List<Creatures> At(int x, int y);

    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < 5 || sizeY < 5)
        {
            throw new ArgumentOutOfRangeException("Map dimensions must be at least 5x5.");
        }

        SizeX = sizeX;
        SizeY = sizeY;

        new Rectangle(0, 0, SizeX - 1, SizeY - 1);
    }

    


    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public abstract bool Exist(Point p);

    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point Next(Point p, Direction d);

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);
}
