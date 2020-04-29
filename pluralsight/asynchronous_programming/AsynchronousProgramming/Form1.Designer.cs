namespace AsynchronousProgramming
{
    partial class Form1
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
            this.btnSearchFiles = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.tbTicker = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearchFiles
            // 
            this.btnSearchFiles.Location = new System.Drawing.Point(301, 3);
            this.btnSearchFiles.Name = "btnSearchFiles";
            this.btnSearchFiles.Size = new System.Drawing.Size(107, 38);
            this.btnSearchFiles.TabIndex = 0;
            this.btnSearchFiles.Text = "Search Files";
            this.btnSearchFiles.UseVisualStyleBackColor = true;
            this.btnSearchFiles.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(414, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(360, 38);
            this.textBox1.TabIndex = 2;
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Location = new System.Drawing.Point(171, 3);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(114, 38);
            this.btnLoadFile.TabIndex = 3;
            this.btnLoadFile.Text = "Load File";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // tbTicker
            // 
            this.tbTicker.Location = new System.Drawing.Point(12, 8);
            this.tbTicker.Name = "tbTicker";
            this.tbTicker.Size = new System.Drawing.Size(133, 20);
            this.tbTicker.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 47);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(774, 265);
            this.dataGridView1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 312);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tbTicker);
            this.Controls.Add(this.btnLoadFile);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnSearchFiles);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearchFiles;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.TextBox tbTicker;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

