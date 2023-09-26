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
    public int Width { get; set; } //for centering new diagram
    public int Height { get; set; } //for centering new diagram
    public Graphics g { get; set; }

    public App(Graphics g, int width, int height)
    {
        this.Width = width;
        this.Height = height;
        this.g = g; //TODO: temp (re-think)

        Diagram newDiagram1 = new Diagram() { Title = "Diagram1", X = 10, Y = 10, Width = 300, Height = 200 };
        Diagram newDiagram2 = new Diagram() { Title = "Diagram2", X = 400, Y = 10, Width = 300, Height = 300 };
        Diagrams.Add(newDiagram1);
        Diagrams.Add(newDiagram2);
        newDiagram1.AddG(g);
        newDiagram2.AddG(g);
    }
    public void Draw(Graphics g)
    {
        //still need new g, because of the refresh
        foreach (var diagram in Diagrams)
        {
            diagram.Draw(g);
        }
    }
    public void Draw()
    {
        foreach (var diagram in Diagrams)
        {
            diagram.Draw(g);
        }
    }
    #region Btn
    public void Add(Graphics g) //AddNew <= Btn
    {
        int diagramWidth = 300; // Set the width of the Diagram
        int diagramHeight = 200; // Set the height of the Diagram

        int centerX = (Width - diagramWidth) / 2;
        int centerY = (Height - diagramHeight) / 2;

        Diagram newDiagram = new Diagram() { Title = "New Diagram", X = centerX, Y = centerY, Width = diagramWidth, Height = diagramHeight };
        Diagrams.Add(newDiagram);
        newDiagram.AddG(g);
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
    #endregion

    public int SelectDiagram(Point loc)
    {
        Diagram newActiveDiagram = null;
        int pointIndex = -1;
        int x = 0;

        int GrapPoinSize = 5;

        foreach (var diagram in Diagrams)
        {
            Rectangle temp = new Rectangle(diagram.X, diagram.Y, diagram.Width + GrapPoinSize, diagram.Height + GrapPoinSize);

            if (temp.Contains(loc)) //large
            {
                //List<Rectangle> points = diagram.CalcSelection(10);
                //foreach (var point in points)
                //{
                //    if (point.Contains(loc))
                //    {
                //        pointIndex = points.IndexOf(point);
                //        //MessageBox.Show("Index:" + pointIndex);
                //        break;
                //    }
                //    x++;
                //}

                temp = new Rectangle(diagram.X, diagram.Y, diagram.Width, diagram.Height); //remove Poit size
                if (temp.Contains(loc)) //can be outside (remove point padding)
                    newActiveDiagram = diagram;
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

        return pointIndex;
    }
    public void SelectPoint(int index, Point Loc) //TODO:
    {
        Point DragPoint = new Point(0, 0); //TODO: replace with real colusion point
        int Xdiff = DragPoint.X - Loc.X;
        int YDiff = DragPoint.Y - Loc.Y;

        if (index == 1){

        }else if(index == 2){

        }else if(index == 3){

        }else if (index == 4){

        }else if (index == 5){

        }else if (index == 6){

        }else if (index == 7){

        }else if (index == 8){

        }
    }

    #region Save/Load
    //TODO: move to FileService
    public void Save(string filePath) 
    {
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

                //MessageBox.Show(string.Join(", ", Diagrams.Select(diagram => diagram.Title)));
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
        if (ActiveDiagram != null)
            Diagrams.RemoveAll(diagram => diagram.Selected);
    }
}
