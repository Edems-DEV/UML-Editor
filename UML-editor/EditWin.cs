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
    Diagram diagram;
    public EditWin(Diagram diagram)
    {
        InitializeComponent();

        this.dataGridView1.DataSource = diagram.methods;
    }
}
