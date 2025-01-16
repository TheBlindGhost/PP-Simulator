

using System;
using System.Reflection.Emit;
using System.Xml.Linq;
using Simulator.Maps;
using static Simulator.Creatures;

namespace Simulator;

public class Animals : IMappable
{

    public virtual char Symbol => 'A';

    private string description = "Unknown";
    public Point Position { get; set; }
    public Map CurrentMap { get; set; }

    public string Name { get; set; }

    public Animals(string name, int level = 1)
    {
        Name = name;
    }
    public override string ToString()
    {
        Type objtype = this.GetType();
        string temp = objtype.Name;
        string temp2 = Info;
        string value = temp.ToUpper() + ": " + temp2;
        return value;   
    }

    public void AssignMap(Map map, Creatures.Point point)
    {
        CurrentMap = map;
        Position = point;
        map.Add(this, point);
    }

    public virtual string Go(Directions.Direction direction)
    {
        if (CurrentMap == null)
            throw new InvalidOperationException("No map chosen");

        var newPosition = CurrentMap.Next(Position, direction);

        CurrentMap.Move(Position, newPosition, this);

        Position = newPosition;

        return $"{direction.ToString().ToLower()}";
    }

    public Creatures.Point GetPos()
    {
        return Position;
    }

    public string Description {
        get { return description; }
        init
        {
            description = Validator.Shortener(value, 3, 15, '#');
        }
        }
    public uint Size { get; set; } = 3;

    public virtual string Info
    {
        get { return $"{Description} <{Size}>"; }
        set { }
    }


}
