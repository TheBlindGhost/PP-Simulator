using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;

namespace TestSimulator;

public class ValidatorTest
{
    [Theory]
    [InlineData(20,10,50,20)]
    [InlineData(10, 1, 5,5)]
    [InlineData(40, 95, 200, 95)]
    public void Validator_Limiter
        (int value,int min, int max, int resault)
    {
        Assert.Equal(Validator.Limiter(value, min, max),resault);

    }

    [Theory]
    [InlineData("  aaa       ", 2, 50,'#',"Aaa")]
    [InlineData("   as ", 20, 30, '.',"As..................")]
    [InlineData("aabbccddeeffgg", 5, 10, '#',"Aabbccddee")]
    public void Validator_Shortener
     (string value, int min, int max, char placeholder, string resault)
    {
        Assert.Equal(Validator.Shortener(value,min,max,placeholder), resault);

    }



}
