namespace MobilePhoneWfT2
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
            this.label1 = new System.Windows.Forms.Label();
            this.sonyBTH = new System.Windows.Forms.RadioButton();
            this.sony35 = new System.Windows.Forms.RadioButton();
            this.powerbank = new System.Windows.Forms.RadioButton();
            this.Apply = new System.Windows.Forms.Button();
            this.outputTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select device to connect with the phone:";
            // 
            // sonyBTH
            // 
            this.sonyBTH.AutoSize = true;
            this.sonyBTH.Location = new System.Drawing.Point(23, 38);
            this.sonyBTH.Name = "sonyBTH";
            this.sonyBTH.Size = new System.Drawing.Size(230, 17);
            this.sonyBTH.TabIndex = 1;
            this.sonyBTH.TabStop = true;
            this.sonyBTH.Text = "Sony headphones. Connected by bluetooth";
            this.sonyBTH.UseVisualStyleBackColor = true;
            this.sonyBTH.CheckedChanged += new System.EventHandler(this.sonyBTH_CheckedChanged);
            // 
            // sony35
            // 
            this.sony35.AutoSize = true;
            this.sony35.Location = new System.Drawing.Point(23, 61);
            this.sony35.Name = "sony35";
            this.sony35.Size = new System.Drawing.Size(243, 17);
            this.sony35.TabIndex = 2;
            this.sony35.TabStop = true;
            this.sony35.Text = "Sony headphones. Connected by jack 3.5 mm";
            this.sony35.UseVisualStyleBackColor = true;
            this.sony35.CheckedChanged += new System.EventHandler(this.sony35_CheckedChanged);
            // 
            // powerbank
            // 
            this.powerbank.AutoSize = true;
            this.powerbank.Location = new System.Drawing.Point(23, 84);
            this.powerbank.Name = "powerbank";
            this.powerbank.Size = new System.Drawing.Size(235, 17);
            this.powerbank.TabIndex = 3;
            this.powerbank.TabStop = true;
            this.powerbank.Text = "Powerbank supports Usb and TypeC plugins";
            this.powerbank.UseVisualStyleBackColor = true;
            this.powerbank.CheckedChanged += new System.EventHandler(this.powerbank_CheckedChanged);
            // 
            // Apply
            // 
            this.Apply.Location = new System.Drawing.Point(172, 114);
            this.Apply.Name = "Apply";
            this.Apply.Size = new System.Drawing.Size(85, 27);
            this.Apply.TabIndex = 4;
            this.Apply.Text = "Apply";
            this.Apply.UseVisualStyleBackColor = true;
            this.Apply.Click += new System.EventHandler(this.Apply_Click);
            // 
            // outputTextBox
            // 
            this.outputTextBox.Location = new System.Drawing.Point(1, 147);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.Size = new System.Drawing.Size(289, 123);
            this.outputTextBox.TabIndex = 5;
            this.outputTextBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.Apply);
            this.Controls.Add(this.powerbank);
            this.Controls.Add(this.sony35);
            this.Controls.Add(this.sonyBTH);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton sonyBTH;
        private System.Windows.Forms.RadioButton sony35;
        private System.Windows.Forms.RadioButton powerbank;
        private System.Windows.Forms.Button Apply;
        private System.Windows.Forms.RichTextBox outputTextBox;
    }
}

