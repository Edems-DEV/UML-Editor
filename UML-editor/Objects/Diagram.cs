using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_editor;

public class Diagram
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

    public string Title { get; set; } = ""; //diagram title
    public List<Property> properties { get; set; }  = new List<Property>();
    public List<Method> methods { get; set; } = new List<Method>();


    #region Options
    Pen PenBorder = new Pen(Color.Black, 2); //Border
    SolidBrush BrushFont = new SolidBrush(Color.Black); //Text
    SolidBrush BrushPrimary = new SolidBrush(Color.AliceBlue); //Primary
    SolidBrush BrushBg = new SolidBrush(Color.White); //Background
    string FontFamily = "Arial";
    #endregion

    public Diagram()
    {
        #region Test data
        properties.Add(new Property() { Attribute = "+", Name = "name", Type = "string" });
        properties.Add(new Property() { Attribute = "+", Name = "suername", Type = "string" });

        methods.Add(new Method() { Attribute = "+", Name = "getFullName", Type = "string"});
        Parametr a = new Parametr() { Name = "code", Type = "string" };
        List<Parametr> b = new List<Parametr>();
        b.Add(a);
        methods.Add(new Method() { Attribute = "+", Name = "verify", Type = "bool", Parametrs = b });
        #endregion
    }

    public void Draw(Graphics g)
    {
        Rectangle rect = new Rectangle(X, Y, Width, Height);
        int h = Y;
        h += DrawTitle(g,rect);
        rect.Y = h;
        h += DrawSection(g, rect, properties.Cast<Parametr>().ToList());
        rect.Y = h;
        h += DrawSection(g, rect, methods.Cast<Parametr>().ToList());
    }

    private int DrawTitle(Graphics g, Rectangle rect)
    {
        Rectangle rect2 = rect;
        Font font = new Font(FontFamily, 16);
        
        StringFormat format = new StringFormat();                //diff
        format.Alignment = StringAlignment.Center;
        format.LineAlignment = StringAlignment.Center;

        SizeF textSize = g.MeasureString(Title, font);
        int textHeight = (int)textSize.Height;
        rect2.Height = textHeight;

        g.FillRectangle(BrushPrimary, rect2);
        g.DrawRectangle(PenBorder, rect2);
        g.DrawString(Title, font, BrushFont, rect2, format);
        
        return textHeight;
    }
    private int DrawSection(Graphics g, Rectangle rect, List<Parametr> list)
    {
        string MergedText = string.Join("\n", list);                        //text

        Rectangle rect2 = rect;
        Font font = new Font(FontFamily, 12);                               //size
        int YOffset = 5;

        SizeF textSize = g.MeasureString(MergedText, font);
        int textHeight = (int)textSize.Height + YOffset;
        rect2.Height = textHeight;

        g.FillRectangle(BrushBg, rect2); //min(100, text.height)
        g.DrawRectangle(PenBorder, rect2);
        rect2.Offset(2, YOffset);                                                   //diff
        g.DrawString(MergedText, font, BrushFont, rect2);

        return textHeight;
    }

    //string.Join("\n", list);
    //private int DrawUniversal(Graphics g, Rectangle rect, string text, int fontSize, Brush Bg, Point Offset = default)
    //{
    //    Rectangle rect2 = rect;
    //    Font font = new Font(FontFamily, fontSize);                        

    //    SizeF textSize = g.MeasureString(text, font);
    //    int textHeight = (int)textSize.Height;
    //    rect.Height = textHeight + 10;

    //    g.FillRectangle(Bg, rect2);
    //    g.DrawRectangle(PenBorder, rect2);
    //    rect.Offset(Offset);                                                
    //    g.DrawString(text, font, BrushFont, rect2);

    //    return textHeight;
    //}
}
