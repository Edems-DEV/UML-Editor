 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_editor;

// code: string
public class Parametr
{
    public string Name { get; set; } = ""; //verify()
    public string Type { get; set; } = ""; //int, float, class6

    public override string ToString() {
        return Name+": "+Type;
    }
}
