using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator.Maps;
using static Simulator.Directions;
using static Simulator.Creatures;


namespace TestSimulator;

public class PointTest
{

    [Fact]
    public void Constructor_ValidSize_Point()
    {
        // Arrange
        int x = 3;
        int y = 5;
        // Act
        var point = new Point(x,y);
        // Assert
        Assert.Equal(x, point.X);
        Assert.Equal(y, point.Y);
    }



    [Theory]
    [InlineData(5, 10, Direction.Up, 5, 11)]
    [InlineData(0, 0, Direction.Down, 0, -1)]
    [InlineData(0, 8, Direction.Left, -1, 8)]
    [InlineData(19, 10, Direction.Right, 20, 10)]
    public void Next_ShouldReturnCorrectNextPoint(int x, int y,
        Direction direction, int expectedX, int expectedY)
    {
        var point = new Point(x, y);
        var nextPoint = point.Next(direction);
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    [Theory]
    [InlineData(5, 10, Direction.Up, 6, 11)]
    [InlineData(0, 0, Direction.Down, -1, -1)]
    [InlineData(0, 8, Direction.Left, -1, 9)]
    [InlineData(19, 10, Direction.Right, 20, 9)]
    public void NextDiagonal_ShouldReturnCorrectNextPoint(int x, int y,
        Direction direction, int expectedX, int expectedY)
    {
        var point = new Point(x, y);
        var nextPoint = point.NextDiagonal(direction);
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);

    }
    }
