using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UML_editor;

public partial class Main : Form
{
    private App app;

    public Main()
    {
        InitializeComponent();

        app = new App(this.pictureBox1.Width, this.pictureBox1.Height);

        pictureBox1.AllowDrop = true;
    }

    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        app.Draw(e.Graphics);
    }

    private void btn_Add_Click(object sender, EventArgs e)
    {
        app.Add(pictureBox1.CreateGraphics());
    }

    private void btn_Save_Click(object sender, EventArgs e)
    {
        app.Save();
    }

    private void btn_Load_Click(object sender, EventArgs e)
    {
        app.Load(pictureBox1.CreateGraphics(), "C:/Users/root/Desktop/M/diagrams.json");
        this.pictureBox1.Refresh();
    }

    private void pictureBox1_DragDrop(object sender, DragEventArgs e)
    {
        string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

        if (files != null && files.Length > 0)
        {
            app.Load(pictureBox1.CreateGraphics(), files[0]);
            this.pictureBox1.Refresh();
        }
    }

    private void pictureBox1_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files != null && files.Length > 0)
            {
                foreach (string filePath in files)
                {
                    if (Path.GetExtension(filePath).Equals(".json", StringComparison.OrdinalIgnoreCase))
                    {
                        e.Effect = DragDropEffects.Copy;
                        return;
                    }
                }
            }
        }

        e.Effect = DragDropEffects.None;
    }
    private void pictureBox1_MouseDoubleClick_1(object sender, MouseEventArgs e)
    {
        app.Edit(e.Location);
    }

    private bool isDragging = false;
    private Point offset;
    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        if (app.SelectDiagram(e.Location) != null)
        {
            isDragging = true;
            offset = new Point(e.X - app.ActiveDiagram.X, e.Y - app.ActiveDiagram.Y);
        }
    }
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if (isDragging)
        {
            app.ActiveDiagram.X = e.X - offset.X;
            app.ActiveDiagram.Y = e.Y - offset.Y;

            app.Draw(pictureBox1.CreateGraphics());

            pictureBox1.Invalidate(); // Redraw the PictureBox
        }
    }
    private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
        isDragging = false;
    }
}
