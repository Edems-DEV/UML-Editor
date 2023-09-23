using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_editor.Services;

internal class FileService
{
    public string Path { get; set; }

    //public List<Diagram> JsonToDiagram(string json)
    //{
    //    List<Diagram> Diagrams = new List<Diagram>();
    //    return Diagrams;
    //}
    public List<Diagram> Load(string path)
    {
        //OpenFileDialog
        //load json filer
        return new List<Diagram>();
    }
    public void Save(App app)
    {

    }
}
