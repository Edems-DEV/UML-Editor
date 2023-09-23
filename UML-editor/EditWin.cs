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
    public EditWin(Diagram diagram)
    {
        InitializeComponent();

        this.textBox_Title.Text = diagram.Title;
        this.Grid_Methods.DataSource = diagram.methods;
        this.Grid_Props.DataSource = diagram.properties;

        Grid_Props.RowHeadersVisible = false;
    }
}
