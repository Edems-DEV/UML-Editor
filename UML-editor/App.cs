using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UML_editor;

internal class App
{
    public List<Diagram> Diagrams = new List<Diagram>();
    public Diagram ActiveDiagram { get; private set; } = null;
    public int Width { get; set; }
    public int Height { get; set; } //only for extra space (wont be smaller than text needs)
    public Graphics g { get; set; }


    public App(Graphics g, int width, int height)
    {
        this.Width = width;
        this.Height = height;
        this.g = g; //TODO: temp (re-think)
        
        Diagrams.Add(new Diagram(g) { Title = "Diagram1", X = 10, Y = 10, Width = 300, Height = 200 });

        Diagrams.Add(new Diagram(g) { Title = "Diagram2", X = 400, Y = 10, Width = 300, Height = 300 }); //TODO: Height rensposible, no static
    }
    public void Draw(Graphics g)
    {
        foreach (var diagram in Diagrams)
        {
            diagram.Draw(g);
        }
    }
    public void Add(Graphics g) //AddNew <= Btn
    {
        int diagramWidth = 300; // Set the width of the Diagram
        int diagramHeight = 200; // Set the height of the Diagram

        int centerX = (Width - diagramWidth) / 2;
        int centerY = (Height - diagramHeight) / 2;

        Diagrams.Add(new Diagram(g) { Title = "New Diagram", X = centerX, Y = centerY, Width = diagramWidth, Height = diagramHeight });
        Draw(g);
    }

    public void Edit(Point location)
    {
        SelectDiagram(location);
        if (ActiveDiagram == null)
            return;

        EditWin form = new EditWin(ActiveDiagram);

        form.OkButtonClicked += (sender, e) =>
        {
            form.Close();

            Draw(g);
        };

        form.ShowDialog();
    }

    public Diagram SelectDiagram(Point loc)
    {
        Diagram newActiveDiagram = null;

        foreach (var diagram in Diagrams)
        {
            // Calculate the center of the diagram
            int centerX = diagram.X + diagram.Width / 2;
            int centerY = diagram.Y + diagram.Height / 2;

            // Calculate half of the diagram's width and height
            int halfWidth = diagram.Width / 2;
            int halfHeight = diagram.Height / 2;

            // Check if the point is within the diagram's bounding box
            if (Math.Abs(loc.X - centerX) <= halfWidth && Math.Abs(loc.Y - centerY) <= halfHeight)
            {
                newActiveDiagram = diagram;
                break; // Exit the loop as soon as one diagram is found within the bounding box
            }
        }

        //deselect old
        if (ActiveDiagram != null)
            ActiveDiagram.Selected = false;
        //select new
        ActiveDiagram = newActiveDiagram;
        // select new
        if (ActiveDiagram != null)
            ActiveDiagram.Selected = true;

        return ActiveDiagram;
    }

    #region Save/Load
    //TODO: move to FileService
    public void Save() 
    {
        string filePath = "C:/Users/root/Desktop/M/diagrams.json";

        string json = JsonSerializer.Serialize(Diagrams, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(filePath, json);
    }
    public void Load(Graphics g, string filePath) //load file
    {
        if (File.Exists(filePath))
        {
            try
            {
                string json = File.ReadAllText(filePath);

                Diagrams = JsonSerializer.Deserialize<List<Diagram>>(json);

                Draw(g); //refresh
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading the JSON file: {ex.Message}");
            }
        }
    }
    #endregion

    public void RemoveActiveDiagram()
    {
        MessageBox.Show("Delete key is pressed!");
        if (ActiveDiagram != null)
            Diagrams.RemoveAll(diagram => diagram.Selected);
        Draw(g);
    }
}
