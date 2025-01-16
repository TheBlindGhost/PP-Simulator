using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator.Maps;
using static Simulator.Creatures;
namespace Simulator;

internal class SimulationHistory
{

        private Simulation _simulation { get; }
        public int SizeX { get; }
        public int SizeY { get; }
        public List<SimulationTurnLog> TurnLogs { get; } = [];
        // store starting positions at index 0

        public SimulationHistory(Simulation simulation)
        {
            _simulation = simulation ??
                throw new ArgumentNullException(nameof(simulation));
            SizeX = _simulation.Map.SizeX;
            SizeY = _simulation.Map.SizeY;
            Run();
        }

        private void Run()
        {

        while (!_simulation.Finished)
        {
            var currentMappable = _simulation.CurrentMappable;
            var currentMove = _simulation.CurrentMoveName;
            var symbolsPos = new Dictionary<Point, char>();

            _simulation.Turn();

            for (int row = 1; row < SizeY+1; row++)
            {
                for (int col = 1; col < SizeX+1; col++)
                {
                    if (_simulation.Map.At(col, row).Count > 1)
                    {
                        symbolsPos.Add(new Point(col, row), 'X');
                    }
                    else if (_simulation.Map.At(col, row).Count == 1)
                    {
                        symbolsPos.Add(new Point(col, row), _simulation.Map.At(col, row)[0].Symbol);
                    }
                }
            }
            TurnLogs.Add(new SimulationTurnLog { Mappable = currentMappable.ToString(), Move = currentMove, Symbols = symbolsPos });
        }
    }

}
    



}
