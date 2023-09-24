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

public partial class EditWin : Form
{
    private Diagram diagram;
    public event EventHandler OkButtonClicked;

    public EditWin(Diagram diagram)
    {
        this.diagram = diagram;

        InitializeComponent();

        this.textBox_Title.Text = diagram.Title;
        this.Grid_Methods.DataSource = diagram.methods;
        this.Grid_Props.DataSource = diagram.properties;

        Grid_Props.RowHeadersVisible = false;
    }

    private void btn_Ok_Click(object sender, EventArgs e)
    {
        diagram.Title = this.textBox_Title.Text;
        diagram.methods = (BindingList<Method>)this.Grid_Methods.DataSource;
        diagram.properties = (BindingList<Property>)this.Grid_Props.DataSource;

        OkButtonClicked?.Invoke(this, EventArgs.Empty);

        this.Close();
    }

    private void btn_Storno_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void Grid_Props_KeyDown(object sender, KeyEventArgs e)
    {
        //if (e.KeyCode == Keys.Delete)
        //{
        //    Grid_Props.Rows.RemoveAt(Grid_Props.SelectedRows[0].Index);
        //}
        //if (e.KeyCode == Keys.Insert || e.Control && e.KeyCode == Keys.N)
        //{
        //    Grid_Props.Rows.RemoveAt(Grid_Props.SelectedRows[0].Index);
        //}

        //binding list fixed grids default add/remove
    }
}
