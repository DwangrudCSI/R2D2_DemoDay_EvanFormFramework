namespace FRRobotDemoCSharp
{
    partial class frmAlarms
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

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAlarms));
            this.cmdReset = new System.Windows.Forms.Button();
            this.cmdSetMax = new System.Windows.Forms.Button();
            this.txtTimeStamp = new System.Windows.Forms.TextBox();
            this.txtSeverity = new System.Windows.Forms.TextBox();
            this.txtCseText = new System.Windows.Forms.TextBox();
            this.txtCseMnemonic = new System.Windows.Forms.TextBox();
            this.txtErrText = new System.Windows.Forms.TextBox();
            this.txtErrMnemonic = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this._lsvAlarms_ColumnHeader_1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._lsvAlarms_ColumnHeader_2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._lsvAlarms_ColumnHeader_3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._lsvAlarms_ColumnHeader_4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lsvAlarms = new System.Windows.Forms.ListView();
            this.lblActiveAlarms = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.cmdClearAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdReset
            // 
            resources.ApplyResources(this.cmdReset, "cmdReset");
            this.cmdReset.BackColor = System.Drawing.SystemColors.Control;
            this.cmdReset.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdReset.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.UseVisualStyleBackColor = false;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // cmdSetMax
            // 
            resources.ApplyResources(this.cmdSetMax, "cmdSetMax");
            this.cmdSetMax.BackColor = System.Drawing.SystemColors.Control;
            this.cmdSetMax.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdSetMax.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdSetMax.Name = "cmdSetMax";
            this.cmdSetMax.UseVisualStyleBackColor = false;
            this.cmdSetMax.Click += new System.EventHandler(this.cmdSetMax_Click);
            // 
            // txtTimeStamp
            // 
            this.txtTimeStamp.AcceptsReturn = true;
            resources.ApplyResources(this.txtTimeStamp, "txtTimeStamp");
            this.txtTimeStamp.BackColor = System.Drawing.SystemColors.Window;
            this.txtTimeStamp.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimeStamp.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTimeStamp.Name = "txtTimeStamp";
            // 
            // txtSeverity
            // 
            this.txtSeverity.AcceptsReturn = true;
            resources.ApplyResources(this.txtSeverity, "txtSeverity");
            this.txtSeverity.BackColor = System.Drawing.SystemColors.Window;
            this.txtSeverity.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSeverity.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSeverity.Name = "txtSeverity";
            // 
            // txtCseText
            // 
            this.txtCseText.AcceptsReturn = true;
            resources.ApplyResources(this.txtCseText, "txtCseText");
            this.txtCseText.BackColor = System.Drawing.SystemColors.Window;
            this.txtCseText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCseText.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCseText.Name = "txtCseText";
            // 
            // txtCseMnemonic
            // 
            this.txtCseMnemonic.AcceptsReturn = true;
            resources.ApplyResources(this.txtCseMnemonic, "txtCseMnemonic");
            this.txtCseMnemonic.BackColor = System.Drawing.SystemColors.Window;
            this.txtCseMnemonic.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCseMnemonic.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCseMnemonic.Name = "txtCseMnemonic";
            // 
            // txtErrText
            // 
            this.txtErrText.AcceptsReturn = true;
            resources.ApplyResources(this.txtErrText, "txtErrText");
            this.txtErrText.BackColor = System.Drawing.SystemColors.Window;
            this.txtErrText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtErrText.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtErrText.Name = "txtErrText";
            // 
            // txtErrMnemonic
            // 
            this.txtErrMnemonic.AcceptsReturn = true;
            resources.ApplyResources(this.txtErrMnemonic, "txtErrMnemonic");
            this.txtErrMnemonic.BackColor = System.Drawing.SystemColors.Window;
            this.txtErrMnemonic.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtErrMnemonic.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtErrMnemonic.Name = "txtErrMnemonic";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Cursor = System.Windows.Forms.Cursors.Default;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Name = "label8";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Cursor = System.Windows.Forms.Cursors.Default;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Name = "label9";
            // 
            // _lsvAlarms_ColumnHeader_1
            // 
            resources.ApplyResources(this._lsvAlarms_ColumnHeader_1, "_lsvAlarms_ColumnHeader_1");
            // 
            // _lsvAlarms_ColumnHeader_2
            // 
            resources.ApplyResources(this._lsvAlarms_ColumnHeader_2, "_lsvAlarms_ColumnHeader_2");
            // 
            // _lsvAlarms_ColumnHeader_3
            // 
            resources.ApplyResources(this._lsvAlarms_ColumnHeader_3, "_lsvAlarms_ColumnHeader_3");
            // 
            // _lsvAlarms_ColumnHeader_4
            // 
            resources.ApplyResources(this._lsvAlarms_ColumnHeader_4, "_lsvAlarms_ColumnHeader_4");
            // 
            // lsvAlarms
            // 
            resources.ApplyResources(this.lsvAlarms, "lsvAlarms");
            this.lsvAlarms.BackColor = System.Drawing.SystemColors.Window;
            this.lsvAlarms.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._lsvAlarms_ColumnHeader_1,
            this._lsvAlarms_ColumnHeader_2,
            this._lsvAlarms_ColumnHeader_3,
            this._lsvAlarms_ColumnHeader_4});
            this.lsvAlarms.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lsvAlarms.HideSelection = false;
            this.lsvAlarms.Name = "lsvAlarms";
            this.lsvAlarms.UseCompatibleStateImageBehavior = false;
            this.lsvAlarms.View = System.Windows.Forms.View.Details;
            this.lsvAlarms.SelectedIndexChanged += new System.EventHandler(this.lsvAlarms_SelectedIndexChanged);
            // 
            // lblActiveAlarms
            // 
            resources.ApplyResources(this.lblActiveAlarms, "lblActiveAlarms");
            this.lblActiveAlarms.Name = "lblActiveAlarms";
            // 
            // lblCount
            // 
            resources.ApplyResources(this.lblCount, "lblCount");
            this.lblCount.Name = "lblCount";
            // 
            // lblMax
            // 
            resources.ApplyResources(this.lblMax, "lblMax");
            this.lblMax.Name = "lblMax";
            // 
            // cmdClearAll
            // 
            resources.ApplyResources(this.cmdClearAll, "cmdClearAll");
            this.cmdClearAll.BackColor = System.Drawing.SystemColors.Control;
            this.cmdClearAll.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdClearAll.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdClearAll.Name = "cmdClearAll";
            this.cmdClearAll.UseVisualStyleBackColor = false;
            this.cmdClearAll.Click += new System.EventHandler(this.cmdClearAll_Click);
            // 
            // frmAlarms
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdClearAll);
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.lblActiveAlarms);
            this.Controls.Add(this.cmdReset);
            this.Controls.Add(this.cmdSetMax);
            this.Controls.Add(this.txtTimeStamp);
            this.Controls.Add(this.txtSeverity);
            this.Controls.Add(this.txtCseText);
            this.Controls.Add(this.txtCseMnemonic);
            this.Controls.Add(this.txtErrText);
            this.Controls.Add(this.txtErrMnemonic);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lsvAlarms);
            this.Name = "frmAlarms";
            this.ShowIcon = false;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAlarms_FormClosed);
            this.Load += new System.EventHandler(this.frmAlarms_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        public System.Windows.Forms.Button cmdReset;
        public System.Windows.Forms.Button cmdSetMax;
        public System.Windows.Forms.TextBox txtTimeStamp;
        public System.Windows.Forms.TextBox txtSeverity;
        public System.Windows.Forms.TextBox txtCseText;
        public System.Windows.Forms.TextBox txtCseMnemonic;
        public System.Windows.Forms.TextBox txtErrText;
        public System.Windows.Forms.TextBox txtErrMnemonic;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.ColumnHeader _lsvAlarms_ColumnHeader_1;
        public System.Windows.Forms.ColumnHeader _lsvAlarms_ColumnHeader_2;
        public System.Windows.Forms.ColumnHeader _lsvAlarms_ColumnHeader_3;
        public System.Windows.Forms.ColumnHeader _lsvAlarms_ColumnHeader_4;
        public System.Windows.Forms.ListView lsvAlarms;
        internal System.Windows.Forms.Label lblActiveAlarms;
        internal System.Windows.Forms.Label lblCount;
        internal System.Windows.Forms.Label lblMax;
        public System.Windows.Forms.Button cmdClearAll;
    }
}