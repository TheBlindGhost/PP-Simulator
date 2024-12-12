

using System.Reflection.Emit;
using System.Xml.Linq;

namespace Simulator;

public class Animals
{
    private string description = "Unknown";
    public required string Description {
        get { return description; }
        init
        {
                string a = value.Trim();
                value = a;
                if (value.Length < 3)
                {
                    for (int i = value.Length; i <= 2; i++)
                    {
                        value += "#";
                    }

                }
                else if (value.Length > 15)
                {
                    value = value.Substring(0, 15);
                    value = value.Trim();
                }
                string temp = value.Substring(0, 1);
                description = temp.ToUpper() + value.Substring(1, value.Length - 1);

        }
        }
    public uint Size { get; set; } = 3;

    public string Info
    {
        get { return $"{Description} [{Size}]"; }
    }


}
