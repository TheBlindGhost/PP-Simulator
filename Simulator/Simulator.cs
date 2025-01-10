﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator.Maps;
using static Simulator.Creatures;
using static Simulator.Directions;

namespace Simulator;

public class Simulation
{
    private int CurrentCreatureIndex = 0;
    private int CurrentCreatureMove = 0;
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<Creatures> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves, 
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public Creatures CurrentCreature {
        get {  return Creatures[CurrentCreatureIndex]; }
    }

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName
    {
        get{ return Moves[CurrentCreatureMove].ToString().ToLower(); }
    }

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<Creatures> creatures,
        List<Point> positions, string moves)
    {


        if (creatures.Count == 0)
        {
            throw new ArgumentNullException("No creatures");
        }

        if (positions.Count != creatures.Count)
            throw new ArgumentException("Amount of creatures and starting points is different");

        Map = map;
        Creatures = creatures;
        Positions = positions;
        Moves = moves;



        for (int i = 0; i < creatures.Count; i++)
        {

            creatures[i].AssignMap(map, positions[i]);

        }
    }

    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>

    public void Turn()
    {
        if (Finished)
            throw new InvalidOperationException("Simulation is finished.");

        var directions = DirectionParser.Parse(CurrentMoveName);
        if (directions.Count == 0)
            throw new InvalidOperationException("Invalid move in the sequence.");

        var direction = directions[0];

       
        CurrentCreature.Go(direction);
        CurrentCreatureIndex++;
        CurrentCreatureMove++;
        if (CurrentCreatureIndex == Creatures.Count) { CurrentCreatureIndex = 0; }

        if (CurrentCreatureMove >= Moves.Length)
            Finished = true;
    }
}
