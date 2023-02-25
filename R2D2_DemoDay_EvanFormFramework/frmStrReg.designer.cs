namespace FRRobotDemoCSharp
{
    partial class frmStrReg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStrReg));
            this.lstStrRegs = new System.Windows.Forms.ListBox();
            this.lblHeader = new System.Windows.Forms.Label();
            this.fraButtons = new System.Windows.Forms.Panel();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.chkNoRefresh = new System.Windows.Forms.CheckBox();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.chkNoUpdate = new System.Windows.Forms.CheckBox();
            this.cmdStopMon = new System.Windows.Forms.Button();
            this.cmdSaveStrReg = new System.Windows.Forms.Button();
            this.cmdMonitor = new System.Windows.Forms.Button();
            this.txtLatency = new System.Windows.Forms.TextBox();
            this.picEvent = new System.Windows.Forms.PictureBox();
            this.picMonitor = new System.Windows.Forms.PictureBox();
            this.cmdAddToScattAccess = new System.Windows.Forms.Button();
            this.lblLatency = new System.Windows.Forms.Label();
            this.lblEvent = new System.Windows.Forms.Label();
            this.lblMonitor = new System.Windows.Forms.Label();
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.fraButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEvent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMonitor)).BeginInit();
            this.SuspendLayout();
            // 
            // lstStrRegs
            // 
            resources.ApplyResources(this.lstStrRegs, "lstStrRegs");
            this.lstStrRegs.BackColor = System.Drawing.SystemColors.Window;
            this.lstStrRegs.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstStrRegs.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lstStrRegs.Name = "lstStrRegs";
            this.lstStrRegs.SelectedIndexChanged += new System.EventHandler(this.lstStrRegs_SelectedIndexChanged);
            this.lstStrRegs.DoubleClick += new System.EventHandler(this.lstStrRegs_DoubleClick);
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.SystemColors.Control;
            this.lblHeader.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblHeader, "lblHeader");
            this.lblHeader.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblHeader.Name = "lblHeader";
            // 
            // fraButtons
            // 
            resources.ApplyResources(this.fraButtons, "fraButtons");
            this.fraButtons.BackColor = System.Drawing.SystemColors.Control;
            this.fraButtons.Controls.Add(this.cmdRefresh);
            this.fraButtons.Controls.Add(this.chkNoRefresh);
            this.fraButtons.Controls.Add(this.cmdUpdate);
            this.fraButtons.Controls.Add(this.chkNoUpdate);
            this.fraButtons.Controls.Add(this.cmdStopMon);
            this.fraButtons.Controls.Add(this.cmdSaveStrReg);
            this.fraButtons.Controls.Add(this.cmdMonitor);
            this.fraButtons.Controls.Add(this.txtLatency);
            this.fraButtons.Controls.Add(this.picEvent);
            this.fraButtons.Controls.Add(this.picMonitor);
            this.fraButtons.Controls.Add(this.cmdAddToScattAccess);
            this.fraButtons.Controls.Add(this.lblLatency);
            this.fraButtons.Controls.Add(this.lblEvent);
            this.fraButtons.Controls.Add(this.lblMonitor);
            this.fraButtons.Cursor = System.Windows.Forms.Cursors.Default;
            this.fraButtons.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fraButtons.Name = "fraButtons";
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.BackColor = System.Drawing.SystemColors.Control;
            this.cmdRefresh.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.cmdRefresh, "cmdRefresh");
            this.cmdRefresh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.UseVisualStyleBackColor = false;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // chkNoRefresh
            // 
            this.chkNoRefresh.BackColor = System.Drawing.SystemColors.Control;
            this.chkNoRefresh.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.chkNoRefresh, "chkNoRefresh");
            this.chkNoRefresh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkNoRefresh.Name = "chkNoRefresh";
            this.chkNoRefresh.UseVisualStyleBackColor = false;
            this.chkNoRefresh.CheckStateChanged += new System.EventHandler(this.chkNoRefresh_CheckStateChanged);
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.cmdUpdate.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.cmdUpdate, "cmdUpdate");
            this.cmdUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.UseVisualStyleBackColor = false;
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // chkNoUpdate
            // 
            this.chkNoUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.chkNoUpdate.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.chkNoUpdate, "chkNoUpdate");
            this.chkNoUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkNoUpdate.Name = "chkNoUpdate";
            this.chkNoUpdate.UseVisualStyleBackColor = false;
            this.chkNoUpdate.CheckStateChanged += new System.EventHandler(this.chkNoUpdate_CheckStateChanged);
            // 
            // cmdStopMon
            // 
            this.cmdStopMon.BackColor = System.Drawing.SystemColors.Control;
            this.cmdStopMon.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.cmdStopMon, "cmdStopMon");
            this.cmdStopMon.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdStopMon.Name = "cmdStopMon";
            this.cmdStopMon.UseVisualStyleBackColor = false;
            this.cmdStopMon.Click += new System.EventHandler(this.cmdStopMon_Click);
            // 
            // cmdSaveStrReg
            // 
            this.cmdSaveStrReg.BackColor = System.Drawing.SystemColors.Control;
            this.cmdSaveStrReg.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.cmdSaveStrReg, "cmdSaveStrReg");
            this.cmdSaveStrReg.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdSaveStrReg.Name = "cmdSaveStrReg";
            this.cmdSaveStrReg.UseVisualStyleBackColor = false;
            this.cmdSaveStrReg.Click += new System.EventHandler(this.cmdSaveStrReg_Click);
            // 
            // cmdMonitor
            // 
            this.cmdMonitor.BackColor = System.Drawing.SystemColors.Control;
            this.cmdMonitor.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.cmdMonitor, "cmdMonitor");
            this.cmdMonitor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdMonitor.Name = "cmdMonitor";
            this.cmdMonitor.UseVisualStyleBackColor = false;
            this.cmdMonitor.Click += new System.EventHandler(this.cmdMonitor_Click);
            // 
            // txtLatency
            // 
            this.txtLatency.AcceptsReturn = true;
            this.txtLatency.BackColor = System.Drawing.SystemColors.Window;
            this.txtLatency.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtLatency, "txtLatency");
            this.txtLatency.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLatency.Name = "txtLatency";
            // 
            // picEvent
            // 
            this.picEvent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.picEvent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picEvent.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.picEvent, "picEvent");
            this.picEvent.ForeColor = System.Drawing.SystemColors.ControlText;
            this.picEvent.Name = "picEvent";
            this.picEvent.TabStop = false;
            // 
            // picMonitor
            // 
            this.picMonitor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.picMonitor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picMonitor.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.picMonitor, "picMonitor");
            this.picMonitor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.picMonitor.Name = "picMonitor";
            this.picMonitor.TabStop = false;
            // 
            // cmdAddToScattAccess
            // 

            // lblLatency
            // 
            this.lblLatency.BackColor = System.Drawing.SystemColors.Control;
            this.lblLatency.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblLatency, "lblLatency");
            this.lblLatency.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLatency.Name = "lblLatency";
            // 
            // lblEvent
            // 
            this.lblEvent.BackColor = System.Drawing.SystemColors.Control;
            this.lblEvent.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblEvent, "lblEvent");
            this.lblEvent.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblEvent.Name = "lblEvent";
            // 
            // lblMonitor
            // 
            this.lblMonitor.BackColor = System.Drawing.SystemColors.Control;
            this.lblMonitor.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblMonitor, "lblMonitor");
            this.lblMonitor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMonitor.Name = "lblMonitor";
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Interval = 250;
            this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
            // 
            // frmStrReg
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fraButtons);
            this.Controls.Add(this.lstStrRegs);
            this.Controls.Add(this.lblHeader);
            this.Name = "frmStrReg";
            this.ShowIcon = false;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmStrReg_FormClosed);
            this.Load += new System.EventHandler(this.frmStrReg_Load);
            this.fraButtons.ResumeLayout(false);
            this.fraButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEvent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMonitor)).EndInit();
            this.ResumeLayout(false);

        }
        public System.Windows.Forms.ListBox lstStrRegs;
        public System.Windows.Forms.Label lblHeader;
        public System.Windows.Forms.Panel fraButtons;
        public System.Windows.Forms.Button cmdRefresh;
        public System.Windows.Forms.CheckBox chkNoRefresh;
        public System.Windows.Forms.Button cmdUpdate;
        public System.Windows.Forms.CheckBox chkNoUpdate;
        public System.Windows.Forms.Button cmdStopMon;
        public System.Windows.Forms.Button cmdSaveStrReg;
        public System.Windows.Forms.Button cmdMonitor;
        public System.Windows.Forms.TextBox txtLatency;
        public System.Windows.Forms.PictureBox picEvent;
        public System.Windows.Forms.PictureBox picMonitor;
        public System.Windows.Forms.Button cmdAddToScattAccess;
        public System.Windows.Forms.Label lblLatency;
        public System.Windows.Forms.Label lblEvent;
        public System.Windows.Forms.Label lblMonitor;
        internal System.Windows.Forms.Timer tmrUpdate;
    }
}