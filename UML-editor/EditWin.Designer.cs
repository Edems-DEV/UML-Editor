namespace UML_editor
{
    partial class EditWin
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
            Grid_Methods = new DataGridView();
            Attribute = new DataGridViewTextBoxColumn();
            Name = new DataGridViewTextBoxColumn();
            Type = new DataGridViewTextBoxColumn();
            btn_Ok = new Button();
            btn_Storno = new Button();
            Grid_Props = new DataGridView();
            V = new DataGridViewTextBoxColumn();
            Names = new DataGridViewTextBoxColumn();
            Type2 = new DataGridViewTextBoxColumn();
            textBox_Title = new TextBox();
            ((System.ComponentModel.ISupportInitialize)Grid_Methods).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Grid_Props).BeginInit();
            SuspendLayout();
            // 
            // Grid_Methods
            // 
            Grid_Methods.AllowUserToOrderColumns = true;
            Grid_Methods.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Grid_Methods.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Grid_Methods.Columns.AddRange(new DataGridViewColumn[] { Attribute, Name, Type });
            Grid_Methods.Location = new Point(13, 219);
            Grid_Methods.Name = "Grid_Methods";
            Grid_Methods.RowHeadersVisible = false;
            Grid_Methods.RowTemplate.Height = 25;
            Grid_Methods.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Grid_Methods.Size = new Size(240, 177);
            Grid_Methods.TabIndex = 0;
            // 
            // Attribute
            // 
            Attribute.DataPropertyName = "Attribute";
            Attribute.FillWeight = 140F;
            Attribute.HeaderText = "V";
            Attribute.MaxInputLength = 1;
            Attribute.Name = "Attribute";
            Attribute.ToolTipText = "Visibility (+,-,#)";
            Attribute.Width = 22;
            // 
            // Name
            // 
            Name.DataPropertyName = "Name";
            Name.HeaderText = "Name";
            Name.Name = "Name";
            Name.Width = 140;
            // 
            // Type
            // 
            Type.DataPropertyName = "Type";
            Type.HeaderText = "Type";
            Type.Name = "Type";
            Type.ToolTipText = "Return type";
            Type.Width = 75;
            // 
            // btn_Ok
            // 
            btn_Ok.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btn_Ok.Location = new Point(13, 402);
            btn_Ok.Name = "btn_Ok";
            btn_Ok.Size = new Size(75, 23);
            btn_Ok.TabIndex = 1;
            btn_Ok.Text = "Ok";
            btn_Ok.UseVisualStyleBackColor = true;
            btn_Ok.Click += btn_Ok_Click;
            // 
            // btn_Storno
            // 
            btn_Storno.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btn_Storno.Location = new Point(94, 402);
            btn_Storno.Name = "btn_Storno";
            btn_Storno.Size = new Size(75, 23);
            btn_Storno.TabIndex = 2;
            btn_Storno.Text = "Storno";
            btn_Storno.UseVisualStyleBackColor = true;
            btn_Storno.Click += btn_Storno_Click;
            // 
            // Grid_Props
            // 
            Grid_Props.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Grid_Props.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Grid_Props.Columns.AddRange(new DataGridViewColumn[] { V, Names, Type2 });
            Grid_Props.Location = new Point(13, 41);
            Grid_Props.Name = "Grid_Props";
            Grid_Props.RowHeadersVisible = false;
            Grid_Props.RowTemplate.Height = 25;
            Grid_Props.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Grid_Props.Size = new Size(240, 172);
            Grid_Props.TabIndex = 3;
            Grid_Props.KeyDown += Grid_Props_KeyDown;
            // 
            // V
            // 
            V.DataPropertyName = "Attribute";
            V.HeaderText = "V";
            V.Name = "V";
            V.ToolTipText = "+ / - / #";
            V.Width = 22;
            // 
            // Names
            // 
            Names.DataPropertyName = "Name";
            Names.HeaderText = "Name";
            Names.Name = "Names";
            Names.Width = 140;
            // 
            // Type2
            // 
            Type2.DataPropertyName = "Type";
            Type2.HeaderText = "Type";
            Type2.Name = "Type2";
            Type2.Width = 75;
            // 
            // textBox_Title
            // 
            textBox_Title.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox_Title.Location = new Point(13, 12);
            textBox_Title.Name = "textBox_Title";
            textBox_Title.Size = new Size(240, 23);
            textBox_Title.TabIndex = 4;
            textBox_Title.TextAlign = HorizontalAlignment.Center;
            // 
            // EditWin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(265, 437);
            Controls.Add(textBox_Title);
            Controls.Add(Grid_Props);
            Controls.Add(btn_Storno);
            Controls.Add(btn_Ok);
            Controls.Add(Grid_Methods);
            MaximizeBox = false;
            MaximumSize = new Size(500, 476);
            MinimumSize = new Size(281, 476);
            //Name = "EditWin";
            Text = "UML Editor";
            ((System.ComponentModel.ISupportInitialize)Grid_Methods).EndInit();
            ((System.ComponentModel.ISupportInitialize)Grid_Props).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView Grid_Methods;
        private Button btn_Ok;
        private Button btn_Storno;
        private DataGridView Grid_Props;
        private TextBox textBox_Title;
        private DataGridViewTextBoxColumn Attribute;
        private DataGridViewTextBoxColumn Name;
        private DataGridViewTextBoxColumn Type;
        private DataGridViewTextBoxColumn V;
        private DataGridViewTextBoxColumn Names;
        private DataGridViewTextBoxColumn Type2;
    }
}