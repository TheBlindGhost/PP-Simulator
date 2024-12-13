

using System.Reflection.Emit;
using System.Xml.Linq;

namespace Simulator;

public class Animals
{
    private string description = "Unknown";


        public override string ToString()
    {
        Type objtype = this.GetType();
        string temp = objtype.Name;
        string temp2 = Info;
        string value = temp.ToUpper() + ": " + temp2;
        return value;   
    }


    public required string Description {
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
