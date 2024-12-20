using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Simulator.Creatures;

namespace Simulator;





public class Rectangle
{


    public readonly int X1, Y1, X2, Y2;


    public Rectangle(int x1, int y1, int x2, int y2)

    {
        if (x1 == x2 || y1 == y2) { throw new ArgumentException("nie chcemy chudych prostokątów"); }
        if (y2 < y1 && x2 < x1)
        {
            (X2, Y2, X1, Y1) = (x1, y1, x2, y2);
        }
        else (X1, Y1, X2, Y2) = (x1, y1, x2, y2);
    }


    public bool Contains(Point point) 
    { 
       if(point.X < X2 && point.X > X1 && point.Y < Y2 && point.Y > Y1) {return true;}
       else return false;
    }
    public override string ToString()
    {
        return $"({X1}, {Y1}):({X2}, {Y2})";
    }


}
