using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace UML_editor;
public class SelectPoints
{
    public int X { get; set; }
    public int Y { get; set; }
    public Point farthestPoint { get; set; }

    #region Points
    //Top
    public Rectangle TL { get; set; }
    public Rectangle TM { get; set; }
    public Rectangle TR { get; set; }

    //Mid
    public Rectangle ML { get; set; }
    public Rectangle MR { get; set; }
    //Mid
    public Rectangle BL { get; set; }
    public Rectangle BM { get; set; }
    public Rectangle BR { get; set; }
    #endregion

    public SelectPoints(int X, int Y, Point farthestPoint, int size)
    {
        this.X = X;
        this.Y = Y;
        this.farthestPoint = farthestPoint;

        // Calculate center points for columns (Y)
        int c1 = Y - (size / 2);
        int c2 = Y + (farthestPoint.Y / 2) - (size / 2);
        int c3 = Y + farthestPoint.Y - (size / 2);

        // Calculate center points for rows (X)
        int r1 = X - (size / 2);
        int r2 = X + (farthestPoint.X / 2) - (size / 2);
        int r3 = X + farthestPoint.X - (size / 2);

        //Top
        TL = new Rectangle(r1, c1, size, size);
        TM = new Rectangle(r1, c2, size, size);
        TR = new Rectangle(r1, c3, size, size);

        //Mid
        ML = new Rectangle(r2, c1, size, size);
        MR = new Rectangle(r2, c3, size, size);

        //Bottom
        BL = new Rectangle(r3, c1, size, size);
        BM = new Rectangle(r3, c2, size, size);
        BR = new Rectangle(r3, c3, size, size);
    }
    public List<Rectangle> MakeList()
    {
        List<Rectangle> points = new List<Rectangle>();
        //Top
        points.Add(TL);
        points.Add(TM);
        points.Add(TR);

        //Mid
        points.Add(ML);
        points.Add(MR);

        //Bottom
        points.Add(BL);
        points.Add(BM);
        points.Add(BR);

        return points;
    }
}
