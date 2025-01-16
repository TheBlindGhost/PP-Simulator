using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Simulator.Directions;
using Simulator.Maps;
using Simulator;
using static Simulator.Creatures;

namespace Simulator.Maps;

public interface IMappable
{



        void AssignMap(Map map, Point point);
        string Go(Direction direction);
        string ToString();
        Point GetPos();
    
}
