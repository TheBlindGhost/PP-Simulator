using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public static class Validator
{
    public static int Limiter(int value, int min, int max) 
    { 
        if (value < min) {value = min;}
        if (value > max) {value = max;}
        return value;      
    }

    public static string Shortener(string value, int min, int max, char placeholder)
    {
        string resault = "";
        value = value.Trim();
        if (value.Length < min)
        {
            for (int i = value.Length + 1; i <= min ; i++)
            {
                value += placeholder;
            }

        }
        else if (value.Length > max)
        {
            value = value.Substring(0, max);
            value = value.Trim();
        }
        string temp = value.Substring(0, 1);
        resault = temp.ToUpper() + value.Substring(1, value.Length - 1);
        return resault;

    }



}
