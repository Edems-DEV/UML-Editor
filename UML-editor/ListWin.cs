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
public partial class ListWin : Form
{
    public Method method;
    public ListWin(Method method)
    {
        this.method = method;

        InitializeComponent();

        label_Name.Text = method.Name;
        Grid_List.DataSource = method.Parametrs;
    }

    private void btn_Ok_Click(object sender, EventArgs e)
    {
        method.Parametrs = (BindingList<Parametr>)this.Grid_List.DataSource;
        this.Close();
    }

    private void btn_Cancel_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}
