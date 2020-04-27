namespace MobilePhoneWfT4
{
    partial class SendManySms
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
            this.timerSms = new System.Windows.Forms.Timer(this.components);
            this.cbxSubscribers = new System.Windows.Forms.ComboBox();
            this.lblSubscribers = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbpgSmsLog = new System.Windows.Forms.TabPage();
            this.receivedSms = new System.Windows.Forms.RichTextBox();
            this.tbpgFilteredSms = new System.Windows.Forms.TabPage();
            this.lvFilteredSms = new System.Windows.Forms.ListView();
            this.From = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.To = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SmsText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbWords = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.cmbLogic = new System.Windows.Forms.ComboBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.btnResetFilters = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tbpgSmsLog.SuspendLayout();
            this.tbpgFilteredSms.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.button1.Location = new System.Drawing.Point(181, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 26);
            this.button1.TabIndex = 2;
            this.button1.Text = "Start sending sms";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timerSms
            // 
            this.timerSms.Interval = 2000;
            this.timerSms.Tick += new System.EventHandler(this.timerSms_Tick);
            // 
            // cbxSubscribers
            // 
            this.cbxSubscribers.FormattingEnabled = true;
            this.cbxSubscribers.Location = new System.Drawing.Point(74, 16);
            this.cbxSubscribers.Name = "cbxSubscribers";
            this.cbxSubscribers.Size = new System.Drawing.Size(106, 21);
            this.cbxSubscribers.TabIndex = 4;
            this.cbxSubscribers.SelectedValueChanged += new System.EventHandler(this.cbx_SelectedValueChanged);
            // 
            // lblSubscribers
            // 
            this.lblSubscribers.AutoSize = true;
            this.lblSubscribers.Location = new System.Drawing.Point(6, 19);
            this.lblSubscribers.Name = "lblSubscribers";
            this.lblSubscribers.Size = new System.Drawing.Size(62, 13);
            this.lblSubscribers.TabIndex = 5;
            this.lblSubscribers.Text = "Subscribers";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbpgSmsLog);
            this.tabControl1.Controls.Add(this.tbpgFilteredSms);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Location = new System.Drawing.Point(0, 151);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(518, 233);
            this.tabControl1.TabIndex = 6;
            this.tabControl1.Click += new System.EventHandler(this.cbx_SelectedValueChanged);
            // 
            // tbpgSmsLog
            // 
            this.tbpgSmsLog.Controls.Add(this.receivedSms);
            this.tbpgSmsLog.Location = new System.Drawing.Point(4, 22);
            this.tbpgSmsLog.Name = "tbpgSmsLog";
            this.tbpgSmsLog.Padding = new System.Windows.Forms.Padding(3);
            this.tbpgSmsLog.Size = new System.Drawing.Size(510, 207);
            this.tbpgSmsLog.TabIndex = 0;
            this.tbpgSmsLog.Text = "Sms log";
            this.tbpgSmsLog.UseVisualStyleBackColor = true;
            // 
            // receivedSms
            // 
            this.receivedSms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.receivedSms.Location = new System.Drawing.Point(3, 3);
            this.receivedSms.Name = "receivedSms";
            this.receivedSms.Size = new System.Drawing.Size(504, 201);
            this.receivedSms.TabIndex = 4;
            this.receivedSms.Text = "";
            // 
            // tbpgFilteredSms
            // 
            this.tbpgFilteredSms.Controls.Add(this.lvFilteredSms);
            this.tbpgFilteredSms.Location = new System.Drawing.Point(4, 22);
            this.tbpgFilteredSms.Name = "tbpgFilteredSms";
            this.tbpgFilteredSms.Padding = new System.Windows.Forms.Padding(3);
            this.tbpgFilteredSms.Size = new System.Drawing.Size(510, 207);
            this.tbpgFilteredSms.TabIndex = 1;
            this.tbpgFilteredSms.Text = "Filtered sms";
            this.tbpgFilteredSms.UseVisualStyleBackColor = true;
            // 
            // lvFilteredSms
            // 
            this.lvFilteredSms.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip;
            this.lvFilteredSms.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvFilteredSms.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.From,
            this.To,
            this.SmsText});
            this.lvFilteredSms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFilteredSms.FullRowSelect = true;
            this.lvFilteredSms.GridLines = true;
            this.lvFilteredSms.HoverSelection = true;
            this.lvFilteredSms.Location = new System.Drawing.Point(3, 3);
            this.lvFilteredSms.Name = "lvFilteredSms";
            this.lvFilteredSms.Size = new System.Drawing.Size(504, 201);
            this.lvFilteredSms.TabIndex = 0;
            this.lvFilteredSms.UseCompatibleStateImageBehavior = false;
            this.lvFilteredSms.View = System.Windows.Forms.View.Details;
            // 
            // From
            // 
            this.From.Text = "From";
            // 
            // To
            // 
            this.To.Text = "To";
            // 
            // SmsText
            // 
            this.SmsText.Text = "SmsText";
            this.SmsText.Width = 360;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(305, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Word in sms";
            // 
            // cmbWords
            // 
            this.cmbWords.FormattingEnabled = true;
            this.cmbWords.Location = new System.Drawing.Point(376, 16);
            this.cmbWords.Name = "cmbWords";
            this.cmbWords.Size = new System.Drawing.Size(117, 21);
            this.cmbWords.TabIndex = 8;
            this.cmbWords.SelectedValueChanged += new System.EventHandler(this.cbx_SelectedValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpTo);
            this.groupBox1.Controls.Add(this.dtpFrom);
            this.groupBox1.Controls.Add(this.cmbLogic);
            this.groupBox1.Controls.Add(this.lblSubscribers);
            this.groupBox1.Controls.Add(this.cmbWords);
            this.groupBox1.Controls.Add(this.cbxSubscribers);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(11, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(499, 75);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter Options";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(304, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "From";
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(345, 49);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.ShowUpDown = true;
            this.dtpTo.Size = new System.Drawing.Size(148, 20);
            this.dtpTo.TabIndex = 11;
            this.dtpTo.Value = new System.DateTime(2020, 4, 27, 0, 0, 0, 0);
            this.dtpTo.ValueChanged += new System.EventHandler(this.cbx_SelectedValueChanged);
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(74, 49);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.ShowUpDown = true;
            this.dtpFrom.Size = new System.Drawing.Size(135, 20);
            this.dtpFrom.TabIndex = 10;
            this.dtpFrom.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFrom.ValueChanged += new System.EventHandler(this.cbx_SelectedValueChanged);
            // 
            // cmbLogic
            // 
            this.cmbLogic.FormattingEnabled = true;
            this.cmbLogic.Location = new System.Drawing.Point(226, 16);
            this.cmbLogic.Name = "cmbLogic";
            this.cmbLogic.Size = new System.Drawing.Size(55, 21);
            this.cmbLogic.TabIndex = 9;
            this.cmbLogic.SelectedValueChanged += new System.EventHandler(this.cbx_SelectedValueChanged);
            // 
            // btnResetFilters
            // 
            this.btnResetFilters.Location = new System.Drawing.Point(324, 10);
            this.btnResetFilters.Name = "btnResetFilters";
            this.btnResetFilters.Size = new System.Drawing.Size(118, 26);
            this.btnResetFilters.TabIndex = 10;
            this.btnResetFilters.Text = "Reset Filters";
            this.btnResetFilters.UseVisualStyleBackColor = true;
            // 
            // SendManySms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 384);
            this.Controls.Add(this.btnResetFilters);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.smsFormatting);
            this.MaximizeBox = false;
            this.Name = "SendManySms";
            this.Text = "Send many SMS";
            this.tabControl1.ResumeLayout(false);
            this.tbpgSmsLog.ResumeLayout(false);
            this.tbpgFilteredSms.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox smsFormatting;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timerSms;
        private System.Windows.Forms.ComboBox cbxSubscribers;
        private System.Windows.Forms.Label lblSubscribers;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbpgSmsLog;
        private System.Windows.Forms.RichTextBox receivedSms;
        private System.Windows.Forms.TabPage tbpgFilteredSms;
        private System.Windows.Forms.ListView lvFilteredSms;
        private System.Windows.Forms.ColumnHeader From;
        private System.Windows.Forms.ColumnHeader To;
        private System.Windows.Forms.ColumnHeader SmsText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbWords;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbLogic;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button btnResetFilters;
    }
}

