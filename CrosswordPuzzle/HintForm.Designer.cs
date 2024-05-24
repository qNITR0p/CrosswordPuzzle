
namespace CrosswordPuzzle
{
    partial class HintForm
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
            this.hintsTable = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.hintsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // hintsTable
            // 
            this.hintsTable.AllowUserToAddRows = false;
            this.hintsTable.AllowUserToDeleteRows = false;
            this.hintsTable.AllowUserToResizeColumns = false;
            this.hintsTable.AllowUserToResizeRows = false;
            this.hintsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.hintsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.hintsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hintsTable.Location = new System.Drawing.Point(0, 0);
            this.hintsTable.Name = "hintsTable";
            this.hintsTable.RowHeadersVisible = false;
            this.hintsTable.Size = new System.Drawing.Size(772, 552);
            this.hintsTable.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "№";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 35;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Направление";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Подсказка";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // HintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 552);
            this.Controls.Add(this.hintsTable);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HintForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Подсказки";
            this.LocationChanged += new System.EventHandler(this.HintForm_LocationChanged);
            ((System.ComponentModel.ISupportInitialize)(this.hintsTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.DataGridView hintsTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}