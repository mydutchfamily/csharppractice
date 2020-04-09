namespace MobilePhoneWfT3
{
    partial class SendSms
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
            this.components = new System.ComponentModel.Container();
            this.smsFormatting = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.receivedSms = new System.Windows.Forms.RichTextBox();
            this.timerSms = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // smsFormatting
            // 
            this.smsFormatting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.smsFormatting.FormattingEnabled = true;
            this.smsFormatting.Location = new System.Drawing.Point(11, 12);
            this.smsFormatting.Name = "smsFormatting";
            this.smsFormatting.Size = new System.Drawing.Size(154, 21);
            this.smsFormatting.TabIndex = 0;
            this.smsFormatting.SelectedIndexChanged += new System.EventHandler(this.smsFormatting_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(171, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 33);
            this.button1.TabIndex = 2;
            this.button1.Text = "Start sending sms";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // receivedSms
            // 
            this.receivedSms.Location = new System.Drawing.Point(1, 48);
            this.receivedSms.Name = "receivedSms";
            this.receivedSms.Size = new System.Drawing.Size(291, 224);
            this.receivedSms.TabIndex = 3;
            this.receivedSms.Text = "";
            // 
            // timerSms
            // 
            this.timerSms.Interval = 2000;
            this.timerSms.Tick += new System.EventHandler(this.timerSms_Tick);
            // 
            // SendSms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.receivedSms);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.smsFormatting);
            this.MaximizeBox = false;
            this.Name = "SendSms";
            this.Text = "Send SMS";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox smsFormatting;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox receivedSms;
        private System.Windows.Forms.Timer timerSms;
    }
}

