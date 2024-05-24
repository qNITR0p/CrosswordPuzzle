namespace CrosswordPuzzle
{
    partial class MainForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Genbtn = new System.Windows.Forms.Button();
            this.Loadbtn = new System.Windows.Forms.Button();
            this.Exitbtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.Genbtn, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Loadbtn, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Exitbtn, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(97, 52);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(225, 150);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // Genbtn
            // 
            this.Genbtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Genbtn.Location = new System.Drawing.Point(12, 10);
            this.Genbtn.Name = "Genbtn";
            this.Genbtn.Size = new System.Drawing.Size(200, 30);
            this.Genbtn.TabIndex = 0;
            this.Genbtn.Text = "Сгенерировать новый кроссворд";
            this.Genbtn.UseVisualStyleBackColor = true;
            this.Genbtn.Click += new System.EventHandler(this.Genbtn_Click);
            // 
            // Loadbtn
            // 
            this.Loadbtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Loadbtn.Location = new System.Drawing.Point(12, 59);
            this.Loadbtn.Name = "Loadbtn";
            this.Loadbtn.Size = new System.Drawing.Size(200, 30);
            this.Loadbtn.TabIndex = 1;
            this.Loadbtn.Text = "Загрузить кроссворд";
            this.Loadbtn.UseVisualStyleBackColor = true;
            this.Loadbtn.Click += new System.EventHandler(this.Loadbtn_Click);
            // 
            // Exitbtn
            // 
            this.Exitbtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Exitbtn.Location = new System.Drawing.Point(12, 109);
            this.Exitbtn.Name = "Exitbtn";
            this.Exitbtn.Size = new System.Drawing.Size(200, 30);
            this.Exitbtn.TabIndex = 2;
            this.Exitbtn.Text = " Выход";
            this.Exitbtn.UseVisualStyleBackColor = true;
            this.Exitbtn.Click += new System.EventHandler(this.Exitbtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 261);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(430, 300);
            this.MinimumSize = new System.Drawing.Size(430, 300);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crossword Puzzle";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button Genbtn;
        private System.Windows.Forms.Button Loadbtn;
        private System.Windows.Forms.Button Exitbtn;
    }
}