﻿namespace AsynchronousProgramming
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
            this.btnTaskRun = new System.Windows.Forms.Button();
            this.tbTicker = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnContinuetion = new System.Windows.Forms.Button();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStayOut = new System.Windows.Forms.Button();
            this.btnOneByOne = new System.Windows.Forms.Button();
            this.btnMock = new System.Windows.Forms.Button();
            this.tbTickers = new System.Windows.Forms.TextBox();
            this.btnManyTasks = new System.Windows.Forms.Button();
            this.btnWithCancel = new System.Windows.Forms.Button();
            this.btnException = new System.Windows.Forms.Button();
            this.btnAsyncAsync = new System.Windows.Forms.Button();
            this.btnParallel = new System.Windows.Forms.Button();
            this.btnParallelForEach = new System.Windows.Forms.Button();
            this.btnSharedVar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearchFiles
            // 
            this.btnSearchFiles.Location = new System.Drawing.Point(265, 37);
            this.btnSearchFiles.Name = "btnSearchFiles";
            this.btnSearchFiles.Size = new System.Drawing.Size(94, 25);
            this.btnSearchFiles.TabIndex = 0;
            this.btnSearchFiles.Text = "Search Files";
            this.btnSearchFiles.UseVisualStyleBackColor = true;
            this.btnSearchFiles.Click += new System.EventHandler(this.btnSearchFiles_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(365, 1);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(527, 61);
            this.textBox1.TabIndex = 2;
            // 
            // btnTaskRun
            // 
            this.btnTaskRun.Location = new System.Drawing.Point(6, 76);
            this.btnTaskRun.Name = "btnTaskRun";
            this.btnTaskRun.Size = new System.Drawing.Size(99, 25);
            this.btnTaskRun.TabIndex = 3;
            this.btnTaskRun.Text = "2 Task.Run";
            this.btnTaskRun.UseVisualStyleBackColor = true;
            this.btnTaskRun.Click += new System.EventHandler(this.btnTaskRun_Click);
            // 
            // tbTicker
            // 
            this.tbTicker.Location = new System.Drawing.Point(6, 19);
            this.tbTicker.Name = "tbTicker";
            this.tbTicker.Size = new System.Drawing.Size(247, 20);
            this.tbTicker.TabIndex = 4;
            this.tbTicker.Text = "MSFT";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(265, 68);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(627, 244);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // btnContinuetion
            // 
            this.btnContinuetion.Location = new System.Drawing.Point(6, 107);
            this.btnContinuetion.Name = "btnContinuetion";
            this.btnContinuetion.Size = new System.Drawing.Size(99, 25);
            this.btnContinuetion.TabIndex = 7;
            this.btnContinuetion.Text = "3 Continuetion";
            this.btnContinuetion.UseVisualStyleBackColor = true;
            this.btnContinuetion.Click += new System.EventHandler(this.btnContinuetion_Click);
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Location = new System.Drawing.Point(6, 45);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(99, 25);
            this.btnLoadFile.TabIndex = 8;
            this.btnLoadFile.Text = "1 Load File";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSharedVar);
            this.groupBox1.Controls.Add(this.btnParallelForEach);
            this.groupBox1.Controls.Add(this.btnParallel);
            this.groupBox1.Controls.Add(this.btnStayOut);
            this.groupBox1.Controls.Add(this.btnOneByOne);
            this.groupBox1.Controls.Add(this.btnMock);
            this.groupBox1.Controls.Add(this.tbTickers);
            this.groupBox1.Controls.Add(this.btnManyTasks);
            this.groupBox1.Controls.Add(this.btnWithCancel);
            this.groupBox1.Controls.Add(this.btnException);
            this.groupBox1.Controls.Add(this.btnAsyncAsync);
            this.groupBox1.Controls.Add(this.tbTicker);
            this.groupBox1.Controls.Add(this.btnContinuetion);
            this.groupBox1.Controls.Add(this.btnLoadFile);
            this.groupBox1.Controls.Add(this.btnTaskRun);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 317);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Load prices";
            // 
            // btnStayOut
            // 
            this.btnStayOut.Location = new System.Drawing.Point(117, 75);
            this.btnStayOut.Name = "btnStayOut";
            this.btnStayOut.Size = new System.Drawing.Size(135, 25);
            this.btnStayOut.TabIndex = 18;
            this.btnStayOut.Text = "10 Stay Out";
            this.btnStayOut.UseVisualStyleBackColor = true;
            this.btnStayOut.Click += new System.EventHandler(this.btnStayOut_Click);
            // 
            // btnOneByOne
            // 
            this.btnOneByOne.Location = new System.Drawing.Point(117, 46);
            this.btnOneByOne.Name = "btnOneByOne";
            this.btnOneByOne.Size = new System.Drawing.Size(135, 23);
            this.btnOneByOne.TabIndex = 17;
            this.btnOneByOne.Text = "9 One By One";
            this.btnOneByOne.UseVisualStyleBackColor = true;
            this.btnOneByOne.Click += new System.EventHandler(this.btnOneByOne_Click);
            // 
            // btnMock
            // 
            this.btnMock.Location = new System.Drawing.Point(6, 287);
            this.btnMock.Name = "btnMock";
            this.btnMock.Size = new System.Drawing.Size(98, 25);
            this.btnMock.TabIndex = 16;
            this.btnMock.Text = "8 Use Mock";
            this.btnMock.UseVisualStyleBackColor = true;
            this.btnMock.Click += new System.EventHandler(this.btnMock_Click);
            // 
            // tbTickers
            // 
            this.tbTickers.Location = new System.Drawing.Point(7, 230);
            this.tbTickers.Name = "tbTickers";
            this.tbTickers.Size = new System.Drawing.Size(137, 20);
            this.tbTickers.TabIndex = 15;
            this.tbTickers.Text = "MSFT ABC AXL AAL AAN";
            // 
            // btnManyTasks
            // 
            this.btnManyTasks.Location = new System.Drawing.Point(6, 257);
            this.btnManyTasks.Name = "btnManyTasks";
            this.btnManyTasks.Size = new System.Drawing.Size(97, 25);
            this.btnManyTasks.TabIndex = 14;
            this.btnManyTasks.Text = "7 Many Tasks";
            this.btnManyTasks.UseVisualStyleBackColor = true;
            this.btnManyTasks.Click += new System.EventHandler(this.btnManyTasks_Click);
            // 
            // btnWithCancel
            // 
            this.btnWithCancel.Location = new System.Drawing.Point(6, 200);
            this.btnWithCancel.Name = "btnWithCancel";
            this.btnWithCancel.Size = new System.Drawing.Size(98, 25);
            this.btnWithCancel.TabIndex = 13;
            this.btnWithCancel.Text = "6 With Cancel";
            this.btnWithCancel.UseVisualStyleBackColor = true;
            this.btnWithCancel.Click += new System.EventHandler(this.btnWithCancel_Click);
            // 
            // btnException
            // 
            this.btnException.Location = new System.Drawing.Point(6, 169);
            this.btnException.Name = "btnException";
            this.btnException.Size = new System.Drawing.Size(99, 25);
            this.btnException.TabIndex = 11;
            this.btnException.Text = "5 Exception";
            this.btnException.UseVisualStyleBackColor = true;
            this.btnException.Click += new System.EventHandler(this.btnException_Click);
            // 
            // btnAsyncAsync
            // 
            this.btnAsyncAsync.Location = new System.Drawing.Point(6, 138);
            this.btnAsyncAsync.Name = "btnAsyncAsync";
            this.btnAsyncAsync.Size = new System.Drawing.Size(99, 25);
            this.btnAsyncAsync.TabIndex = 10;
            this.btnAsyncAsync.Text = "4 Async(async())";
            this.btnAsyncAsync.UseVisualStyleBackColor = true;
            this.btnAsyncAsync.Click += new System.EventHandler(this.btnAsyncAsync_Click);
            // 
            // btnParallel
            // 
            this.btnParallel.Location = new System.Drawing.Point(118, 107);
            this.btnParallel.Name = "btnParallel";
            this.btnParallel.Size = new System.Drawing.Size(133, 25);
            this.btnParallel.TabIndex = 19;
            this.btnParallel.Text = "11 Parallel";
            this.btnParallel.UseVisualStyleBackColor = true;
            this.btnParallel.Click += new System.EventHandler(this.btnParallel_Click);
            // 
            // btnParallelForEach
            // 
            this.btnParallelForEach.Location = new System.Drawing.Point(118, 138);
            this.btnParallelForEach.Name = "btnParallelForEach";
            this.btnParallelForEach.Size = new System.Drawing.Size(132, 24);
            this.btnParallelForEach.TabIndex = 20;
            this.btnParallelForEach.Text = "12 ParallelForEach";
            this.btnParallelForEach.UseVisualStyleBackColor = true;
            this.btnParallelForEach.Click += new System.EventHandler(this.btnParallelForEach_Click);
            // 
            // btnSharedVar
            // 
            this.btnSharedVar.Location = new System.Drawing.Point(118, 169);
            this.btnSharedVar.Name = "btnSharedVar";
            this.btnSharedVar.Size = new System.Drawing.Size(131, 25);
            this.btnSharedVar.TabIndex = 21;
            this.btnSharedVar.Text = "13 Shared Var";
            this.btnSharedVar.UseVisualStyleBackColor = true;
            this.btnSharedVar.Click += new System.EventHandler(this.btnSharedVar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 317);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnSearchFiles);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearchFiles;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnTaskRun;
        private System.Windows.Forms.TextBox tbTicker;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnContinuetion;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAsyncAsync;
        private System.Windows.Forms.Button btnException;
        private System.Windows.Forms.Button btnWithCancel;
        private System.Windows.Forms.Button btnManyTasks;
        private System.Windows.Forms.TextBox tbTickers;
        private System.Windows.Forms.Button btnMock;
        private System.Windows.Forms.Button btnOneByOne;
        private System.Windows.Forms.Button btnStayOut;
        private System.Windows.Forms.Button btnParallel;
        private System.Windows.Forms.Button btnParallelForEach;
        private System.Windows.Forms.Button btnSharedVar;
    }
}

