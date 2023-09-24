using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
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

    private void Grid_Methods_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        //if (e.ColumnIndex == Grid_Methods.Columns["Parametrs"].Index && e.Value is List<Parametr> parameters)
        //{
        //    // Format the parameters as a string, e.g., "Name1 (Type1), Name2 (Type2), ..."
        //    e.Value = string.Join(", ", parameters.Select(p => $"{p.Name} ({p.Type})"));
        //    e.FormattingApplied = true;
        //}
    }

    private void Grid_Methods_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        //if (e.ColumnIndex == Grid_Methods.Columns["Parametrs"].Index && e.RowIndex >= 0)
        //{
        //    var editedValue = Grid_Methods.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        //    var parameters = ParseParametersFromString(editedValue);

        //    // Update the underlying data (e.g., methods list)
        //    ((Method)Grid_Methods.Rows[e.RowIndex].DataBoundItem).Parametrs = parameters;
        //}
    }

    private BindingList<Parametr> ParseParametersFromString(string paramString)
    {
        // Implement logic to parse the edited string and create a List<Parameter> from it
        // Example: "Name1 (Type1), Name2 (Type2), ..." -> List<Parameter>
        var parameterList = new BindingList<Parametr>();
        // Parse the paramString and populate parameterList
        return parameterList;
    }

    private void Grid_Methods_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
        {
            // Check if the clicked column is the "Parametrs" column
            if (Grid_Methods.Columns[e.ColumnIndex].HeaderText == "Parametrs")
            {
                // Get the selected method
                var selectedMethod = Grid_Methods.Rows[e.RowIndex].DataBoundItem as Method;

                if (selectedMethod != null)
                {
                    // Create a new form to display the parameters
                    var paramForm = new ListWin(selectedMethod);
                    //paramForm.Text = selectedMethod.Name + " Parametrs";
                    paramForm.ShowDialog();
                }
            }
        }
    }
}
