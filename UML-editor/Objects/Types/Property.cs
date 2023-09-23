using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_editor;

//enum Attributes
//{
//    Public,   //+
//    Private,  //-
//    Protected //#
//}

// + name: string
public class Property : Parametr
{
    public string Attribute { get; set; } = ""; //+, -, #

    public override string ToString() 
    {
        return Attribute + " " + Name + ": " + Type;
    }
}
