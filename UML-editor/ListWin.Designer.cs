namespace UML_editor;

partial class ListWin
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        Grid_List = new DataGridView();
        label_Name = new Label();
        btn_Ok = new Button();
        btn_Cancel = new Button();
        Name = new DataGridViewTextBoxColumn();
        Type = new DataGridViewTextBoxColumn();
        ((System.ComponentModel.ISupportInitialize)Grid_List).BeginInit();
        SuspendLayout();
        // 
        // Grid_List
        // 
        Grid_List.AllowUserToResizeRows = false;
        Grid_List.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        Grid_List.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        Grid_List.Columns.AddRange(new DataGridViewColumn[] { Name, Type });
        Grid_List.Location = new Point(12, 27);
        Grid_List.Name = "Grid_List";
        Grid_List.RowHeadersVisible = false;
        Grid_List.RowTemplate.Height = 25;
        Grid_List.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        Grid_List.Size = new Size(233, 166);
        Grid_List.TabIndex = 0;
        // 
        // label_Name
        // 
        label_Name.AutoSize = true;
        label_Name.Location = new Point(12, 9);
        label_Name.Name = "label_Name";
        label_Name.Size = new Size(81, 15);
        label_Name.TabIndex = 1;
        label_Name.Text = "MethodName";
        // 
        // btn_Ok
        // 
        btn_Ok.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        btn_Ok.Location = new Point(12, 199);
        btn_Ok.Name = "btn_Ok";
        btn_Ok.Size = new Size(75, 23);
        btn_Ok.TabIndex = 2;
        btn_Ok.Text = "Ok";
        btn_Ok.UseVisualStyleBackColor = true;
        btn_Ok.Click += btn_Ok_Click;
        // 
        // btn_Cancel
        // 
        btn_Cancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        btn_Cancel.Location = new Point(93, 199);
        btn_Cancel.Name = "btn_Cancel";
        btn_Cancel.Size = new Size(75, 23);
        btn_Cancel.TabIndex = 3;
        btn_Cancel.Text = "Cancel";
        btn_Cancel.UseVisualStyleBackColor = true;
        btn_Cancel.Click += btn_Cancel_Click;
        // 
        // Name
        // 
        Name.DataPropertyName = "Name";
        Name.HeaderText = "Name";
        Name.Name = "Name";
        Name.Width = 130;
        // 
        // Type
        // 
        Type.DataPropertyName = "Type";
        Type.HeaderText = "Type";
        Type.Name = "Type";
        // 
        // ListWin
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.ActiveCaption;
        ClientSize = new Size(270, 237);
        Controls.Add(btn_Cancel);
        Controls.Add(btn_Ok);
        Controls.Add(label_Name);
        Controls.Add(Grid_List);
        Name = "ListWin";
        Text = "ListWin";
        ((System.ComponentModel.ISupportInitialize)Grid_List).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private DataGridView Grid_List;
    private Label label_Name;
    private Button btn_Ok;
    private Button btn_Cancel;
    private DataGridViewTextBoxColumn Name;
    private DataGridViewTextBoxColumn Type;
}