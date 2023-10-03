using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UML_editor;

internal class App
{
    public List<Diagram> Diagrams = new List<Diagram>();
    public Diagram ActiveDiagram { get; private set; } = null;
    Rectangle GrapPoint = new Rectangle(); //vypočítám z celého main ractaglu neni třeba //TODO: remove
    public int pointIndex { get; set; } = -1;
    
    public int Width { get; set; } //for centering new diagram
    public int Height { get; set; } //for centering new diagram
    public Graphics g { get; set; }

    public App(Graphics g, int width, int height)
    {
        this.Width = width;
        this.Height = height;
        this.g = g; //TODO: temp (re-think)

        Diagram newDiagram1 = new Diagram() { Title = "Diagram1", X = -563, Y = -258, Width = 300, Height = 200 };
        Diagram newDiagram2 = new Diagram() { Title = "Diagram2", X = -248, Y = -258, Width = 300, Height = 300 };
        Diagrams.Add(newDiagram1);
        Diagrams.Add(newDiagram2);
        newDiagram1.AddG(g);
        newDiagram2.AddG(g);
    }
    public void Draw(Graphics g)
    {
        //still need new g, because of the refresh
        
        g.TranslateTransform(Width / 2 - zoomOrigin.X, Height / 2 - zoomOrigin.Y);
        g.ScaleTransform(zoom, zoom);
        foreach (var diagram in Diagrams)
        {
            diagram.Draw(g);
        }
    }
    public void Draw()
    {
        g.TranslateTransform(Width / 2 - zoomOrigin.X, Height / 2 - zoomOrigin.Y);
        g.ScaleTransform(zoom, zoom);
        foreach (var diagram in Diagrams)
        {
            diagram.Draw(g);
        }
    }

    public float zoom = 1.0f; // Initial zoom level
    public Point zoomOrigin = new Point(0, 0); // Zoom center point
    public void Zoom(int Delta, Point Location)
    {
        if (Delta > 0) // Zoom in
        {
            zoom *= 1.1f;
        }
        else if (Delta < 0) // Zoom out
        {
            zoom /= 1.1f;
        }

        zoomOrigin = Location;
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

        float GrapPointRadius = 25 * zoom; // Adjust this as needed

        // Reverse transform
        Point inverseLoc = new Point(
            (int)((loc.X - Width / 2 + zoomOrigin.X) / zoom),
            (int)((loc.Y - Height / 2 + zoomOrigin.Y) / zoom)
        );

        foreach (var diagram in Diagrams)
        {
            // Reverse transform
            Rectangle diagramBounds = new Rectangle(
                (int)(diagram.X - GrapPointRadius / zoom),
                (int)(diagram.Y - GrapPointRadius / zoom),
                (int)(diagram.Width + GrapPointRadius * 2 / zoom),
                (int)(diagram.Height + GrapPointRadius * 2 / zoom)
            );

            //g.DrawRectangle(Pens.Red, diagramBounds); //debug (broken)

            if (diagramBounds.Contains(inverseLoc))
            {
                List<Rectangle> points = diagram.CalcSelection((int)(GrapPointRadius / zoom));

                foreach (var point in points)
                {
                    //g.DrawRectangle(Pens.Blue, point); //debug (broken)

                    if (point.Contains(inverseLoc))
                    {
                        pointIndex = points.IndexOf(point);
                        GrapPoint = point;
                        break;
                    }
                }

                if (diagramBounds.Contains(inverseLoc))
                {
                    newActiveDiagram = diagram;
                }
            }
        }

        // Deselect old
        if (ActiveDiagram != null)
            ActiveDiagram.Selected = false;

        // Select new
        ActiveDiagram = newActiveDiagram;

        // Select new
        if (ActiveDiagram != null)
            ActiveDiagram.Selected = true;

        return pointIndex;
    }

    public void SelectPoint(Point Loc, Point Offset)
    {
        Point dragPoint = Offset;
        Rectangle oldRect = new Rectangle(ActiveDiagram.X, ActiveDiagram.Y, ActiveDiagram.Width, ActiveDiagram.Height);
        //g.DrawRectangle(Pens.Red, oldRect); //debug

        float diff_Xx = ((dragPoint.X - Loc.X) / zoom);
        float diff_Yy = ((dragPoint.Y - Loc.Y) / zoom);

        int diff_X = (int)Math.Round(diff_Xx);
        int diff_Y = (int)Math.Round(diff_Yy);


        switch (pointIndex)
        {
            case 1: // Top
                oldRect.Y -= diff_Y;
                oldRect.Height += diff_Y;
                break;
            case 6: // Down
                oldRect.Height -= diff_Y;
                break;
            case 3: // Left
                oldRect.X -= diff_X;
                oldRect.Width += diff_X;
                break;
            case 4: // Right
                oldRect.Width -= diff_X;
                break;
            case 0: // Scale: Top Left
                oldRect.X -= diff_X;
                oldRect.Width += diff_X;
                oldRect.Y -= diff_Y;
                oldRect.Height += diff_Y;
                break;
            case 7: // Scale: Bottom Right
                oldRect.Width -= diff_X;
                oldRect.Height -= diff_Y;
                break;
            case 2: // Scale: Top Right
                 oldRect.Width += diff_X;
                oldRect.Y -= diff_Y;
                oldRect.Height += diff_Y;
                break;
            case 5: // Scale: Bottom Left
                oldRect.X -= diff_X;
                oldRect.Width += diff_X;
                oldRect.Height -= diff_Y;
                break;
        }

        ActiveDiagram.X = oldRect.X;
        ActiveDiagram.Y = oldRect.Y;
        ActiveDiagram.Width = oldRect.Width;
        ActiveDiagram.Height = oldRect.Height;
        //MessageBox.Show($"X: {diff_X};Y: {diff_Y}"); //debug
    }

    public void Move(Point e, Point offset)
    {
        //ActiveDiagram.X = e.X - offset.X;
        //ActiveDiagram.Y = e.Y - offset.Y;

        //stick but fly away
        //need flow, int is broken
        float diff_X = (e.X - offset.X) / zoom;
        float diff_Y = (e.Y - offset.Y) / zoom;

        ActiveDiagram.X = (int)Math.Round(diff_X);
        ActiveDiagram.Y = (int)Math.Round(diff_Y);
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

                //MessageBox.Show(string.Join(", ", Diagrams.Select(diagram => diagram.Title))); //debug
                Draw(g); //refresh
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading the JSON file: {ex.Message}");
            }
        }
    }
    public void SavePictureBoxToPng(PictureBox pictureBox, string filePath)
    {
        #region -
        float oldZoom = zoom;
        Point oldozoom = zoomOrigin;
        
        zoom = 1;
        zoomOrigin = new Point(0, 0);
        Draw(g);

        //relativní jako mouse-click na viditelný picturebox (nelze použít diagram X;Y)
        #endregion
        using (Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height))
        {
            pictureBox.DrawToBitmap(bmp, new Rectangle(0, 0, pictureBox.Width, pictureBox.Height));
            bmp.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
        }
        #region -
        zoom = oldZoom;
        zoomOrigin = oldozoom;
        Draw(g);
        #endregion
    }
    #endregion

    public void RemoveActiveDiagram()
    {
        if (ActiveDiagram != null)
            Diagrams.RemoveAll(diagram => diagram.Selected);
    }
}
