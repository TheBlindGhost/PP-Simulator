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


}

