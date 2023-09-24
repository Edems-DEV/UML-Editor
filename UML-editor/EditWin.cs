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
        diagram.methods = (List<Method>)this.Grid_Methods.DataSource;
        diagram.properties = (List<Property>)this.Grid_Props.DataSource;

        OkButtonClicked?.Invoke(this, EventArgs.Empty);

        this.Close();
    }
}
