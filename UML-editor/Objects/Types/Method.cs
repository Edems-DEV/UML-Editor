using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_editor;

// # verify(): string
// + getFullName(code: string): bool
public class Method : Property
{
    public BindingList<Parametr> Parametrs { get; set; } = new BindingList<Parametr>();
    public override string ToString()
    {
        string a = Attribute + " " + Name + "(" ;
        foreach (var p in Parametrs)
        {
            a += p;
            //add space
        }
        a = a + "): " + Type;
        return a;
    }
}
