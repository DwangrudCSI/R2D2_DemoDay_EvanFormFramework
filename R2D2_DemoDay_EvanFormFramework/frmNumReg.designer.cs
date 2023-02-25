namespace FRRobotDemoCSharp
{
    partial class frmNumReg
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNumReg));
            this.chkNoUpdate = new System.Windows.Forms.CheckBox();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.chkNoRefresh = new System.Windows.Forms.CheckBox();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.picMonitor = new System.Windows.Forms.PictureBox();
            this.picEvent = new System.Windows.Forms.PictureBox();
            this.cmdStopMon = new System.Windows.Forms.Button();
            this.txtLatency = new System.Windows.Forms.TextBox();
            this.cmdMonitor = new System.Windows.Forms.Button();
            this.lstNumRegs = new System.Windows.Forms.ListBox();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblMonitor = new System.Windows.Forms.Label();
            this.lblEvent = new System.Windows.Forms.Label();
            this.lblLatency = new System.Windows.Forms.Label();
            this.tmrUpdateLED = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picMonitor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEvent)).BeginInit();
            this.SuspendLayout();
            // 
            // chkNoUpdate
            // 
            resources.ApplyResources(this.chkNoUpdate, "chkNoUpdate");
            this.chkNoUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.chkNoUpdate.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkNoUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkNoUpdate.Name = "chkNoUpdate";
            this.chkNoUpdate.UseVisualStyleBackColor = false;
            this.chkNoUpdate.CheckStateChanged += new System.EventHandler(this.chkNoUpdate_CheckStateChanged);
            // 
            // cmdUpdate
            // 
            resources.ApplyResources(this.cmdUpdate, "cmdUpdate");
            this.cmdUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.cmdUpdate.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.UseVisualStyleBackColor = false;
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // chkNoRefresh
            // 
            resources.ApplyResources(this.chkNoRefresh, "chkNoRefresh");
            this.chkNoRefresh.BackColor = System.Drawing.SystemColors.Control;
            this.chkNoRefresh.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkNoRefresh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkNoRefresh.Name = "chkNoRefresh";
            this.chkNoRefresh.UseVisualStyleBackColor = false;
            this.chkNoRefresh.CheckStateChanged += new System.EventHandler(this.chkNoRefresh_CheckStateChanged);
            // 
            // cmdRefresh
            // 
            resources.ApplyResources(this.cmdRefresh, "cmdRefresh");
            this.cmdRefresh.BackColor = System.Drawing.SystemColors.Control;
            this.cmdRefresh.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdRefresh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.UseVisualStyleBackColor = false;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // picMonitor
            // 
            resources.ApplyResources(this.picMonitor, "picMonitor");
            this.picMonitor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.picMonitor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picMonitor.Cursor = System.Windows.Forms.Cursors.Default;
            this.picMonitor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.picMonitor.Name = "picMonitor";
            this.picMonitor.TabStop = false;
            // 
            // picEvent
            // 
            resources.ApplyResources(this.picEvent, "picEvent");
            this.picEvent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.picEvent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picEvent.Cursor = System.Windows.Forms.Cursors.Default;
            this.picEvent.ForeColor = System.Drawing.SystemColors.ControlText;
            this.picEvent.Name = "picEvent";
            this.picEvent.TabStop = false;
            // 
            // cmdStopMon
            // 
            resources.ApplyResources(this.cmdStopMon, "cmdStopMon");
            this.cmdStopMon.BackColor = System.Drawing.SystemColors.Control;
            this.cmdStopMon.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdStopMon.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdStopMon.Name = "cmdStopMon";
            this.cmdStopMon.UseVisualStyleBackColor = false;
            this.cmdStopMon.Click += new System.EventHandler(this.cmdStopMon_Click);
            // 
            // txtLatency
            // 
            this.txtLatency.AcceptsReturn = true;
            resources.ApplyResources(this.txtLatency, "txtLatency");
            this.txtLatency.BackColor = System.Drawing.SystemColors.Window;
            this.txtLatency.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLatency.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLatency.Name = "txtLatency";
            // 
            // cmdMonitor
            // 
            resources.ApplyResources(this.cmdMonitor, "cmdMonitor");
            this.cmdMonitor.BackColor = System.Drawing.SystemColors.Control;
            this.cmdMonitor.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdMonitor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdMonitor.Name = "cmdMonitor";
            this.cmdMonitor.UseVisualStyleBackColor = false;
            this.cmdMonitor.Click += new System.EventHandler(this.cmdMonitor_Click);
            // 
            // lstNumRegs
            // 
            resources.ApplyResources(this.lstNumRegs, "lstNumRegs");
            this.lstNumRegs.BackColor = System.Drawing.SystemColors.Window;
            this.lstNumRegs.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstNumRegs.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lstNumRegs.Name = "lstNumRegs";
            this.lstNumRegs.SelectedIndexChanged += new System.EventHandler(this.lstNumRegs_SelectedIndexChanged);
            this.lstNumRegs.DoubleClick += new System.EventHandler(this.lstNumRegs_DoubleClick);
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.SystemColors.Control;
            this.lblHeader.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblHeader, "lblHeader");
            this.lblHeader.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblHeader.Name = "lblHeader";
            // 
            // lblMonitor
            // 
            resources.ApplyResources(this.lblMonitor, "lblMonitor");
            this.lblMonitor.BackColor = System.Drawing.SystemColors.Control;
            this.lblMonitor.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblMonitor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMonitor.Name = "lblMonitor";
            // 
            // lblEvent
            // 
            resources.ApplyResources(this.lblEvent, "lblEvent");
            this.lblEvent.BackColor = System.Drawing.SystemColors.Control;
            this.lblEvent.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblEvent.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblEvent.Name = "lblEvent";
            // 
            // lblLatency
            // 
            resources.ApplyResources(this.lblLatency, "lblLatency");
            this.lblLatency.BackColor = System.Drawing.SystemColors.Control;
            this.lblLatency.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblLatency.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLatency.Name = "lblLatency";
            // 
            // tmrUpdateLED
            // 
            this.tmrUpdateLED.Interval = 250;
            this.tmrUpdateLED.Tick += new System.EventHandler(this.tmrUpdateLED_Tick);
            // 
            // frmNumReg
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkNoUpdate);
            this.Controls.Add(this.cmdUpdate);
            this.Controls.Add(this.chkNoRefresh);
            this.Controls.Add(this.cmdRefresh);
            this.Controls.Add(this.picMonitor);
            this.Controls.Add(this.picEvent);
            this.Controls.Add(this.cmdStopMon);
            this.Controls.Add(this.txtLatency);
            this.Controls.Add(this.cmdMonitor);
            this.Controls.Add(this.lstNumRegs);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.lblMonitor);
            this.Controls.Add(this.lblEvent);
            this.Controls.Add(this.lblLatency);
            this.Name = "frmNumReg";
            this.ShowIcon = false;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmNumReg_FormClosed);
            this.Load += new System.EventHandler(this.frmNumReg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picMonitor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEvent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        public System.Windows.Forms.CheckBox chkNoUpdate;
        public System.Windows.Forms.Button cmdUpdate;
        public System.Windows.Forms.CheckBox chkNoRefresh;
        public System.Windows.Forms.Button cmdRefresh;
        public System.Windows.Forms.PictureBox picMonitor;
        public System.Windows.Forms.PictureBox picEvent;
        public System.Windows.Forms.Button cmdStopMon;
        public System.Windows.Forms.TextBox txtLatency;
        public System.Windows.Forms.Button cmdMonitor;
        public System.Windows.Forms.ListBox lstNumRegs;
        public System.Windows.Forms.Label lblHeader;
        public System.Windows.Forms.Label lblMonitor;
        public System.Windows.Forms.Label lblEvent;
        public System.Windows.Forms.Label lblLatency;
        internal System.Windows.Forms.Timer tmrUpdateLED;
    }
}