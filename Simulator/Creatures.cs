
using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;
using Simulator.Maps;
using static Simulator.Directions;
namespace Simulator;

public abstract class Creatures : IMappable
{

    private string name = "Unknown";
    private int level = 1;
    private int power = 0;
    public Map? CurrentMap { get; private set; } = null;
    public Point Position { get; private set; }


    public void AssignMap(Map map, Point position )
    {
        if (CurrentMap != null)
            throw new InvalidOperationException("Creature already assigned");
        CurrentMap = map;
        Position = position;

        map.Add(this, position);
    }




    public override string ToString()
    {
        Type objtype = this.GetType();
        string temp = objtype.Name;
        string temp2 = this.Info();
        string value = temp.ToUpper() + ": " + temp2;
        return value;   
    }


    public int Pow { 
        get {  return power; }
        set {  power = value; } 
    }

    public string? Name
    {
        get { return name; }
        init
        {
            name = Validator.Shortener(value, 3, 25, '#');

        }
    }


    public int Level
    {
        get { return level; }
        init
        {
            level = Validator.Limiter(value, 0, 10);

        }


    }



    public Creatures(string name, int level = 1)
    {
        this.Name = name;
        this.Level = level;

    }

    public Creatures() { }

    public abstract string Info();

    public abstract string Greeting();

    public abstract int Power();
    public void Upgrade()
    {
        if (level < 10) { level += 1; }

    }

    public void Move(Direction direction)
    {
        if (CurrentMap == null)
            return;

        var newPosition = CurrentMap.Next(Position, direction);
        if (CurrentMap is SmallMap smallMap)
        {
            smallMap.Move(Position, newPosition,this);
        }
        Position = newPosition;
    }
    public string Go(Direction direction)
    {
        if (CurrentMap == null)
            throw new InvalidOperationException("No map chosen");

        var newPosition = CurrentMap.Next(Position, direction);
      
        CurrentMap.Move(Position, newPosition, this);
        
        Position = newPosition;

        return $"{direction.ToString().ToLower()}";
    }


    public Point GetPos() => Position;

    public readonly struct Point
    {
        public readonly int X, Y;
        public Point(int x, int y) => (X, Y) = (x, y);
        public override string ToString() => $"({X}, {Y})";

        public Point Next(Direction direction)
        {
            switch (direction)
            {
                case Direction.Right: return new Point(X + 1, Y);
                case Direction.Left: return new Point(X - 1, Y);
                case Direction.Up: return new Point(X, Y - 1);
                case Direction.Down: return new Point(X, Y + 1);
                default: return new Point(X, Y);
            }

        }

        // rotate given direction 45 degrees clockwise
        public Point NextDiagonal(Direction direction)
        {
            switch (direction)
            {
                case Direction.Right: return new Point(X + 1, Y - 1);
                case Direction.Left: return new Point(X - 1, Y + 1);
                case Direction.Up: return new Point(X + 1, Y + 1);
                case Direction.Down: return new Point(X - 1, Y - 1);
                default: return new Point(X, Y);
            }
        }
    }


}





