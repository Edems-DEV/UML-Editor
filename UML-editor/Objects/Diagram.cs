using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public BindingList<Property> properties { get; set; }  = new BindingList<Property>();
    public BindingList<Method> methods { get; set; } = new BindingList<Method>();

    public bool Selected { get; set; }

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

    public Diagram(Graphics g)
    {
        this.g = g;
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

    public void Draw(Graphics g)
    {
        int a = SizeCalc(Title, SizeTitle);
        int b = SizeCalc(string.Join("\n", properties.Cast<Parametr>().ToList()), SizeOther) + YOffset;
        int c = SizeCalc(string.Join("\n", properties.Cast<Parametr>().ToList()), SizeOther) + YOffset;
        int h = a + b + c; //a,b,c => dont calcul twice

        int bonusSpace = Math.Max((Height - h)/2, 0);
        b = b + bonusSpace;
        c = c + bonusSpace;

        Rectangle rect = new Rectangle(X, Y, Width, Height);
        rect.Height = a;
        DrawTitle(g, rect);
        rect.Y += a;
        rect.Height = b;
        DrawSection(g, rect, properties.Cast<Parametr>().ToList());
        rect.Y += b;
        rect.Height = c;
        DrawSection(g, rect, methods.Cast<Parametr>().ToList());
    }
    private int SizeCalc(string text, int fontSize)
    {
        Font font = new Font(FontFamily, fontSize);
        
        SizeF textSize = g.MeasureString(text, font);
        return (int)textSize.Height;
    }
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

    //public void draw2(graphics g)
    //{
    //    //rectangle rect = new rectangle(x, y, width, height);
    //    //g.fillrectangle(brushbg, rect); //debug
    //    //int h = y;
    //    //drawtitle(g,rect); //h += 
    //    //rect.y = h;
    //    //h += drawsection(g, rect, properties.cast<parametr>().tolist());
    //    //rect.y = h;
    //    //h += drawsection(g, rect, methods.cast<parametr>().tolist());
    //}
}
