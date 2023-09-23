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
            dataGridView1 = new DataGridView();
            btn_D_Edit = new Button();
            btn_D_Delete = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(240, 290);
            dataGridView1.TabIndex = 0;
            // 
            // btn_D_Edit
            // 
            btn_D_Edit.Location = new Point(22, 333);
            btn_D_Edit.Name = "btn_D_Edit";
            btn_D_Edit.Size = new Size(75, 23);
            btn_D_Edit.TabIndex = 1;
            btn_D_Edit.Text = "Edit";
            btn_D_Edit.UseVisualStyleBackColor = true;
            // 
            // btn_D_Delete
            // 
            btn_D_Delete.Location = new Point(103, 333);
            btn_D_Delete.Name = "btn_D_Delete";
            btn_D_Delete.Size = new Size(75, 23);
            btn_D_Delete.TabIndex = 2;
            btn_D_Delete.Text = "Delete";
            btn_D_Delete.UseVisualStyleBackColor = true;
            // 
            // EditWin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(265, 368);
            Controls.Add(btn_D_Delete);
            Controls.Add(btn_D_Edit);
            Controls.Add(dataGridView1);
            Name = "EditWin";
            Text = "UML Editor";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btn_D_Edit;
        private Button btn_D_Delete;
    }
}