using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_editor;

public class Diagram
{
    //public Rectangle rect; // => replace X,Y,Width,Height
    public int X { get; set; }
    public int Y { get; set; }
    public int Width { get; set; }
    public int Height { get; set; } //only for extra space (wont be smaller than text needs)

    public string Title { get; set; } = ""; //diagram title
    public BindingList<Property> properties { get; set; }  = new BindingList<Property>();
    public BindingList<Method> methods { get; set; } = new BindingList<Method>();

    public bool Selected { get; set; } = false;
    public List<Rectangle> GrapPoints { get; set; }

    public Graphics g;

    #region Options
    Pen PenBorder = new Pen(Color.Black, 2); //Border
    SolidBrush BrushFont = new SolidBrush(Color.Black); //Text
    SolidBrush BrushPrimary = new SolidBrush(Color.AliceBlue); //Primary
    SolidBrush BrushBg = new SolidBrush(Color.White); //Background
    string FontFamily = "Arial";
    int SizeTitle = 16;
    int SizeOther = 12;
    int YOffset = 5;
    #endregion

    public Diagram()
    {
        //this.g = g; //then i can't load JSON
        #region Test data
        properties.Add(new Property() { Attribute = "+", Name = "name", Type = "string" });
        properties.Add(new Property() { Attribute = "+", Name = "suername", Type = "string" });

        methods.Add(new Method() { Attribute = "+", Name = "getFullName", Type = "string"});
        Parametr a = new Parametr() { Name = "code", Type = "string" };
        BindingList<Parametr> b = new BindingList<Parametr>();
        b.Add(a);
        methods.Add(new Method() { Attribute = "+", Name = "verify", Type = "bool", Parametrs = b });
        #endregion
    }
    public void AddG(Graphics gg)
    {
        this.g = gg;
    }

    public void Draw(Graphics g)
    {
        //Calc size
        SizeF x1 = SizeCalc(g, Title, SizeTitle);
        SizeF x2 = SizeCalc(g, string.Join("\n", properties.Cast<Parametr>().ToList()), SizeOther);
        SizeF x3 = SizeCalc(g, string.Join("\n", properties.Cast<Parametr>().ToList()), SizeOther);

        int a = (int)x1.Height;
        int b = (int)x2.Height + YOffset;
        int c = (int)x3.Height + YOffset;

        int h = a + b + c; //a,b,c => dont calcul twice

        //Add calulated bonus space
        int bonusSpace = Math.Max((Height - h)/2, 0);
        b = b + bonusSpace;
        c = c + bonusSpace;

        h = a + b + c;
        Height = h;

        List<float> xxx = new List<float>() { x1.Width, x2.Width, x3.Width };
        int minWidth = Math.Max((int)xxx.Max(), Width);
        Width = minWidth;

        //Draw
        Rectangle rect = new Rectangle(X, Y, minWidth, Height);
        rect.Height = a;
        DrawTitle(g, rect);
        rect.Y += a;
        rect.Height = b;
        DrawSection(g, rect, properties.Cast<Parametr>().ToList());
        rect.Y += b;
        rect.Height = c;
        DrawSection(g, rect, methods.Cast<Parametr>().ToList());

        if (Selected)
            DrawSelection(g, new Point(minWidth, h));
    }
    private SizeF SizeCalc(Graphics g, string text, int fontSize)
    {
        Font font = new Font(FontFamily, fontSize);
        
        SizeF textSize = g.MeasureString(text, font);
        return textSize;
    }
    #region Draw
    private void DrawTitle(Graphics g, Rectangle rect)
    {
        Font font = new Font(FontFamily, SizeTitle);
        
        StringFormat format = new StringFormat();             
        format.Alignment = StringAlignment.Center;
        format.LineAlignment = StringAlignment.Center;

        g.FillRectangle(BrushPrimary, rect);
        g.DrawRectangle(PenBorder, rect);
        g.DrawString(Title, font, BrushFont, rect, format);
    }
    private void DrawSection(Graphics g, Rectangle rect, List<Parametr> list)
    {
        string MergedText = string.Join("\n", list);                       

        Font font = new Font(FontFamily, SizeOther);                              

        g.FillRectangle(BrushBg, rect); 
        g.DrawRectangle(PenBorder, rect);

        Rectangle rect2 = rect;
        rect2.Offset(2, YOffset);
        g.DrawString(MergedText, font, BrushFont, rect2);
    }
    private void DrawSelection(Graphics g, Point farthestPoint)
    {
        int size = 10; //can be made larger in App.SelectDiagram() to keep good look

        //points = new SelectPoints(X, Y, farthestPoint, size);
        CalcSelection(size);

        foreach (var point in GrapPoints)
        {
            g.FillRectangle(BrushFont, point);
        }

        //return points;
    }

    public List<Rectangle> CalcSelection(int size)
    {
        Point farthestPoint = new Point(Width, Height);

        // Calculate center points for columns (Y)
        int c1 = Y - (size / 2);
        int c2 = Y + (farthestPoint.Y / 2) - (size / 2);
        int c3 = Y + farthestPoint.Y - (size / 2);

        // Calculate center points for rows (X)
        int r1 = X - (size / 2);
        int r2 = X + (farthestPoint.X / 2) - (size / 2);
        int r3 = X + farthestPoint.X - (size / 2);

        List<Rectangle> points = new List<Rectangle>();

        //Column 1
        points.Add(new Rectangle(r1, c1, size, size));
        points.Add(new Rectangle(r2, c1, size, size));
        points.Add(new Rectangle(r3, c1, size, size));

        //Column 2
        points.Add(new Rectangle(r1, c2, size, size));
        points.Add(new Rectangle(r3, c2, size, size));

        //Column 3
        points.Add(new Rectangle(r1, c3, size, size));
        points.Add(new Rectangle(r2, c3, size, size));
        points.Add(new Rectangle(r3, c3, size, size));

        // Indexes
        //0 - 1 - 2
        //3 - x - 4
        //5 - 6 - 7

        GrapPoints = points;
        return points;
    }
    #endregion
}
