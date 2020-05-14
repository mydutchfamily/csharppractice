namespace MobilePhoneWfT6
{
    partial class SendSmsReceiveCalls
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
            this.btnGenerateSms = new System.Windows.Forms.Button();
            this.cbxSubscribers = new System.Windows.Forms.ComboBox();
            this.lblSubscribers = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbpgEventsLog = new System.Windows.Forms.TabPage();
            this.receivedEvents = new System.Windows.Forms.RichTextBox();
            this.tbpgFilteredSms = new System.Windows.Forms.TabPage();
            this.lvFilteredSms = new System.Windows.Forms.ListView();
            this.From = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.To = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SmsText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbpgCharging = new System.Windows.Forms.TabPage();
            this.chbxSwitch = new System.Windows.Forms.CheckBox();
            this.chbxCharger = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tbpgCollsLog = new System.Windows.Forms.TabPage();
            this.lvCalls = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.btnGenerateCalls = new System.Windows.Forms.Button();
            this.popupCalls = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.delCurCall = new System.Windows.Forms.ToolStripMenuItem();
            this.cleanCallHist = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tbpgEventsLog.SuspendLayout();
            this.tbpgFilteredSms.SuspendLayout();
            this.tbpgCharging.SuspendLayout();
            this.tbpgCollsLog.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.popupCalls.SuspendLayout();
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
            this.smsFormatting.SelectionChangeCommitted += new System.EventHandler(this.smsFormatting_SelectedIndexChanged);
            // 
            // btnGenerateSms
            // 
            this.btnGenerateSms.Location = new System.Drawing.Point(181, 10);
            this.btnGenerateSms.Name = "btnGenerateSms";
            this.btnGenerateSms.Size = new System.Drawing.Size(99, 26);
            this.btnGenerateSms.TabIndex = 2;
            this.btnGenerateSms.Text = "Start sending sms";
            this.btnGenerateSms.UseVisualStyleBackColor = true;
            this.btnGenerateSms.Click += new System.EventHandler(this.btnGenerateSms_Click);
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
            this.tabControl1.Controls.Add(this.tbpgEventsLog);
            this.tabControl1.Controls.Add(this.tbpgFilteredSms);
            this.tabControl1.Controls.Add(this.tbpgCharging);
            this.tabControl1.Controls.Add(this.tbpgCollsLog);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Location = new System.Drawing.Point(0, 151);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(518, 233);
            this.tabControl1.TabIndex = 6;
            this.tabControl1.Click += new System.EventHandler(this.cbx_SelectedValueChanged);
            // 
            // tbpgEventsLog
            // 
            this.tbpgEventsLog.Controls.Add(this.receivedEvents);
            this.tbpgEventsLog.Location = new System.Drawing.Point(4, 22);
            this.tbpgEventsLog.Name = "tbpgEventsLog";
            this.tbpgEventsLog.Padding = new System.Windows.Forms.Padding(3);
            this.tbpgEventsLog.Size = new System.Drawing.Size(510, 207);
            this.tbpgEventsLog.TabIndex = 0;
            this.tbpgEventsLog.Text = "Events log";
            this.tbpgEventsLog.UseVisualStyleBackColor = true;
            // 
            // receivedEvents
            // 
            this.receivedEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.receivedEvents.Location = new System.Drawing.Point(3, 3);
            this.receivedEvents.Name = "receivedEvents";
            this.receivedEvents.Size = new System.Drawing.Size(504, 201);
            this.receivedEvents.TabIndex = 4;
            this.receivedEvents.Text = "";
            this.receivedEvents.DoubleClick += new System.EventHandler(this.receivedSms_DoubleClick);
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
            // tbpgCharging
            // 
            this.tbpgCharging.Controls.Add(this.chbxSwitch);
            this.tbpgCharging.Controls.Add(this.chbxCharger);
            this.tbpgCharging.Controls.Add(this.progressBar1);
            this.tbpgCharging.Location = new System.Drawing.Point(4, 22);
            this.tbpgCharging.Name = "tbpgCharging";
            this.tbpgCharging.Padding = new System.Windows.Forms.Padding(3);
            this.tbpgCharging.Size = new System.Drawing.Size(510, 207);
            this.tbpgCharging.TabIndex = 2;
            this.tbpgCharging.Text = "Charging";
            this.tbpgCharging.UseVisualStyleBackColor = true;
            // 
            // chbxSwitch
            // 
            this.chbxSwitch.AutoSize = true;
            this.chbxSwitch.Location = new System.Drawing.Point(9, 76);
            this.chbxSwitch.Name = "chbxSwitch";
            this.chbxSwitch.Size = new System.Drawing.Size(121, 17);
            this.chbxSwitch.TabIndex = 2;
            this.chbxSwitch.Text = "switch phone on/off";
            this.chbxSwitch.UseVisualStyleBackColor = true;
            this.chbxSwitch.CheckedChanged += new System.EventHandler(this.chbxSwitch_CheckedChanged);
            // 
            // chbxCharger
            // 
            this.chbxCharger.AutoSize = true;
            this.chbxCharger.Location = new System.Drawing.Point(10, 46);
            this.chbxCharger.Name = "chbxCharger";
            this.chbxCharger.Size = new System.Drawing.Size(96, 17);
            this.chbxCharger.TabIndex = 1;
            this.chbxCharger.Text = "plug in charger";
            this.chbxCharger.UseVisualStyleBackColor = true;
            this.chbxCharger.CheckedChanged += new System.EventHandler(this.chbxCharger_CheckedChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar1.Location = new System.Drawing.Point(3, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(504, 27);
            this.progressBar1.TabIndex = 0;
            // 
            // tbpgCollsLog
            // 
            this.tbpgCollsLog.Controls.Add(this.lvCalls);
            this.tbpgCollsLog.Location = new System.Drawing.Point(4, 22);
            this.tbpgCollsLog.Name = "tbpgCollsLog";
            this.tbpgCollsLog.Padding = new System.Windows.Forms.Padding(3);
            this.tbpgCollsLog.Size = new System.Drawing.Size(510, 207);
            this.tbpgCollsLog.TabIndex = 3;
            this.tbpgCollsLog.Text = "Calls log";
            this.tbpgCollsLog.UseVisualStyleBackColor = true;
            // 
            // lvCalls
            // 
            this.lvCalls.CheckBoxes = true;
            this.lvCalls.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvCalls.ContextMenuStrip = this.popupCalls;
            this.lvCalls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCalls.Location = new System.Drawing.Point(3, 3);
            this.lvCalls.Name = "lvCalls";
            this.lvCalls.Size = new System.Drawing.Size(504, 201);
            this.lvCalls.TabIndex = 0;
            this.lvCalls.UseCompatibleStateImageBehavior = false;
            this.lvCalls.View = System.Windows.Forms.View.Details;
            this.lvCalls.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvCalls_MouseDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "From";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "To";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Start Time";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Duration";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Direction";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Calls";
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
            this.btnResetFilters.Location = new System.Drawing.Point(430, 10);
            this.btnResetFilters.Name = "btnResetFilters";
            this.btnResetFilters.Size = new System.Drawing.Size(74, 26);
            this.btnResetFilters.TabIndex = 10;
            this.btnResetFilters.Text = "Reset Filters";
            this.btnResetFilters.UseVisualStyleBackColor = true;
            this.btnResetFilters.Click += new System.EventHandler(this.btnResetFilters_Click);
            // 
            // btnGenerateCalls
            // 
            this.btnGenerateCalls.Location = new System.Drawing.Point(307, 10);
            this.btnGenerateCalls.Name = "btnGenerateCalls";
            this.btnGenerateCalls.Size = new System.Drawing.Size(108, 26);
            this.btnGenerateCalls.TabIndex = 11;
            this.btnGenerateCalls.Text = "Start calling";
            this.btnGenerateCalls.UseVisualStyleBackColor = true;
            this.btnGenerateCalls.Click += new System.EventHandler(this.btnGenerateCalls_Click);
            // 
            // popupCalls
            // 
            this.popupCalls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.delCurCall,
            this.cleanCallHist});
            this.popupCalls.Name = "popupCalls";
            this.popupCalls.Size = new System.Drawing.Size(167, 48);
            // 
            // delCurCall
            // 
            this.delCurCall.Name = "delCurCall";
            this.delCurCall.Size = new System.Drawing.Size(166, 22);
            this.delCurCall.Text = "Delete selected call";
            this.delCurCall.Click += new System.EventHandler(this.delCurCall_Click);
            // 
            // cleanCallHist
            // 
            this.cleanCallHist.Name = "cleanCallHist";
            this.cleanCallHist.Size = new System.Drawing.Size(166, 22);
            this.cleanCallHist.Text = "Delete all calls";
            this.cleanCallHist.Click += new System.EventHandler(this.cleanCallHist_Click);
            // 
            // SendSmsReceiveCalls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 384);
            this.Controls.Add(this.btnGenerateCalls);
            this.Controls.Add(this.btnResetFilters);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnGenerateSms);
            this.Controls.Add(this.smsFormatting);
            this.MaximizeBox = false;
            this.Name = "SendSmsReceiveCalls";
            this.Text = "Send SMS, receive calls";
            this.tabControl1.ResumeLayout(false);
            this.tbpgEventsLog.ResumeLayout(false);
            this.tbpgFilteredSms.ResumeLayout(false);
            this.tbpgCharging.ResumeLayout(false);
            this.tbpgCharging.PerformLayout();
            this.tbpgCollsLog.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.popupCalls.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox smsFormatting;
        private System.Windows.Forms.Button btnGenerateSms;
        private System.Windows.Forms.ComboBox cbxSubscribers;
        private System.Windows.Forms.Label lblSubscribers;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbpgEventsLog;
        private System.Windows.Forms.RichTextBox receivedEvents;
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
        private System.Windows.Forms.TabPage tbpgCharging;
        private System.Windows.Forms.CheckBox chbxSwitch;
        private System.Windows.Forms.CheckBox chbxCharger;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnGenerateCalls;
        private System.Windows.Forms.TabPage tbpgCollsLog;
        private System.Windows.Forms.ListView lvCalls;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ContextMenuStrip popupCalls;
        private System.Windows.Forms.ToolStripMenuItem delCurCall;
        private System.Windows.Forms.ToolStripMenuItem cleanCallHist;
    }
}

