﻿using System;
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
    private int PointIndex = -1;

    public Main()
    {
        InitializeComponent();

        app = new App(pictureBox1.CreateGraphics(), this.pictureBox1.Width, this.pictureBox1.Height);

        pictureBox1.AllowDrop = true;
    }

    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        app.Draw(e.Graphics);
    }

    #region Btn
    private void btn_Add_Click(object sender, EventArgs e)
    {
        app.Add(pictureBox1.CreateGraphics());
    }

    private void btn_Save_Click(object sender, EventArgs e)
    {
        SaveFileDialog FDialog = new SaveFileDialog();
        FDialog.Filter = "Json files (*.json)|*.json";

        if (FDialog.ShowDialog() == DialogResult.OK)
        {
            
            app.Save(FDialog.FileName);
        }
        
    }

    private void btn_Load_Click(object sender, EventArgs e)
    {
        OpenFileDialog FDialog = new OpenFileDialog();
        FDialog.Filter = "Json files (*.json)|*.json";

        if (FDialog.ShowDialog() == DialogResult.OK)
        {
            app.Load(pictureBox1.CreateGraphics(), FDialog.FileName);
            this.pictureBox1.Refresh();
        }

    }
    #endregion

    #region DragDrop
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
    #endregion
    private void pictureBox1_MouseDoubleClick_1(object sender, MouseEventArgs e)
    {
        app.Edit(e.Location);
    }

    #region Mouse handler
    private bool isDragging = false;
    private Point offset;
    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        PointIndex = app.SelectDiagram(e.Location);

        //for deselect
        app.Draw();
        pictureBox1.Refresh();
        
        if (app.ActiveDiagram == null)
            return;

        if (false) //change size
        {
            //(PointIndex != -1) //no point selected
            //change size
        }
        else //move diagram
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

            //pictureBox1.Invalidate(); // Redraw the PictureBox
            pictureBox1.Refresh(); // Redraw the PictureBox
        }
    }
    private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
        isDragging = false;
    }
    #endregion

    private void Main_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Delete)
        {
            app.RemoveActiveDiagram();
            pictureBox1.Refresh(); //just blinks
        }
        else if (e.Control && e.KeyCode == Keys.N
                           || e.KeyCode == Keys.Insert)
        {
            app.Add(pictureBox1.CreateGraphics());
        }
    }
}
