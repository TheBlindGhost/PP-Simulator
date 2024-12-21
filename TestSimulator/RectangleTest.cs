using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;
using Simulator.Map;
using static Simulator.Creatures;

namespace TestSimulator;

public class RectangleTest
{
    [Theory]
    [InlineData(2, 5, 20, 15, 2, 5, 20, 15)]
    [InlineData(20, 15, 2, 5, 2, 5, 20, 15)]
    public void Ractangle_should_return_proper_points
        (int x1,int y1, int x2, int y2, int x1t, int y1t, int x2t, int y2t )
    {
       var point = new Rectangle(x1,y1,x2,y2);
        Assert.Equal(point.X1, x1t);
        Assert.Equal(point.Y1, y1t);
        Assert.Equal(point.X2, x2t);
        Assert.Equal(point.Y2, y2t);

    }
    [Theory]
    [InlineData(2, 5, 2, 5)]
    public void Ractangle_should_return_exception
      (int x1, int y1, int x2, int y2)
    {
        Assert.Throws<ArgumentException>(() => new Rectangle(x1, y1, x2, y2));

    }
    [Theory]
    [InlineData(2, 5, 20, 15,4,10,true)]
    [InlineData(20, 15, 2, 5,1,1,false)]
    public void Ractangle_contain_point
    (int x1, int y1, int x2, int y2,int p1, int p2,bool expected)
    {

        var point = new Rectangle(x1, y1, x2, y2);
        var p = new Point(p1,p2);        
        Assert.Equal(point.Contains(p),expected);



    }


    [Theory]
    [InlineData(2, 5, 20, 15,"(2, 5):(20, 15)")]
    public void Ractangle_tostring
    (int x1, int y1, int x2, int y2,string expected)
    {

        var point = new Rectangle(x1, y1, x2, y2);
        Assert.Equal(point.ToString(), expected);



    }




 



}
