namespace FRRobotDemoCSharp
{
    partial class frmSysVars
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysVars));
            this.treSysVars = new System.Windows.Forms.TreeView();
            this.cmdFind = new System.Windows.Forms.Button();
            this.cmdAddToScattAccess = new System.Windows.Forms.Button();
            this.chkNoUpdate = new System.Windows.Forms.CheckBox();
            this.chkNoRefresh = new System.Windows.Forms.CheckBox();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.lblEvent = new System.Windows.Forms.Label();
            this.picEvent = new System.Windows.Forms.PictureBox();
            this.picMonitor = new System.Windows.Forms.PictureBox();
            this.lblMonitor = new System.Windows.Forms.Label();
            this.txtLatency = new System.Windows.Forms.TextBox();
            this.lblLatency = new System.Windows.Forms.Label();
            this.cmdStopMon = new System.Windows.Forms.Button();
            this.cmdMonitor = new System.Windows.Forms.Button();
            this.txtMax = new System.Windows.Forms.TextBox();
            this._lblStatic_1 = new System.Windows.Forms.Label();
            this.txtMin = new System.Windows.Forms.TextBox();
            this._lblStatic_0 = new System.Windows.Forms.Label();
            this._lblStatic_8 = new System.Windows.Forms.Label();
            this.txtTypeCode = new System.Windows.Forms.TextBox();
            this.txtTypeName = new System.Windows.Forms.TextBox();
            this._lblStatic_2 = new System.Windows.Forms.Label();
            this._lblStatic_7 = new System.Windows.Forms.Label();
            this.txtFieldName = new System.Windows.Forms.TextBox();
            this._lblStatic_6 = new System.Windows.Forms.Label();
            this.txtVarName = new System.Windows.Forms.TextBox();
            this._lblStatic_5 = new System.Windows.Forms.Label();
            this.cmdEditValue = new System.Windows.Forms.Button();
            this.txtVarValue = new System.Windows.Forms.TextBox();
            this.tmrUpdateLight = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picEvent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMonitor)).BeginInit();
            this.SuspendLayout();
            // 
            // treSysVars
            // 
            resources.ApplyResources(this.treSysVars, "treSysVars");
            this.treSysVars.Name = "treSysVars";
            this.treSysVars.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treSysVars_AfterExpand);
            this.treSysVars.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treSysVars_AfterSelect);
            // 
            // cmdFind
            // 
            resources.ApplyResources(this.cmdFind, "cmdFind");
            this.cmdFind.BackColor = System.Drawing.SystemColors.Control;
            this.cmdFind.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdFind.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdFind.Name = "cmdFind";
            this.cmdFind.UseVisualStyleBackColor = false;
            this.cmdFind.Click += new System.EventHandler(this.cmdFind_Click);
            // 
            // cmdAddToScattAccess
            // 

            // 
            // chkNoUpdate
            // 
            resources.ApplyResources(this.chkNoUpdate, "chkNoUpdate");
            this.chkNoUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.chkNoUpdate.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkNoUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkNoUpdate.Name = "chkNoUpdate";
            this.chkNoUpdate.UseVisualStyleBackColor = false;
            this.chkNoUpdate.CheckedChanged += new System.EventHandler(this.chkNoUpdate_CheckedChanged);
            // 
            // chkNoRefresh
            // 
            resources.ApplyResources(this.chkNoRefresh, "chkNoRefresh");
            this.chkNoRefresh.BackColor = System.Drawing.SystemColors.Control;
            this.chkNoRefresh.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkNoRefresh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkNoRefresh.Name = "chkNoRefresh";
            this.chkNoRefresh.UseVisualStyleBackColor = false;
            this.chkNoRefresh.CheckedChanged += new System.EventHandler(this.chkNoRefresh_CheckedChanged);
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
            // lblEvent
            // 
            resources.ApplyResources(this.lblEvent, "lblEvent");
            this.lblEvent.BackColor = System.Drawing.SystemColors.Control;
            this.lblEvent.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblEvent.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblEvent.Name = "lblEvent";
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
            // lblMonitor
            // 
            resources.ApplyResources(this.lblMonitor, "lblMonitor");
            this.lblMonitor.BackColor = System.Drawing.SystemColors.Control;
            this.lblMonitor.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblMonitor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMonitor.Name = "lblMonitor";
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
            // lblLatency
            // 
            resources.ApplyResources(this.lblLatency, "lblLatency");
            this.lblLatency.BackColor = System.Drawing.SystemColors.Control;
            this.lblLatency.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblLatency.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLatency.Name = "lblLatency";
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
            // txtMax
            // 
            this.txtMax.AcceptsReturn = true;
            resources.ApplyResources(this.txtMax, "txtMax");
            this.txtMax.BackColor = System.Drawing.SystemColors.Window;
            this.txtMax.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMax.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtMax.Name = "txtMax";
            this.txtMax.ReadOnly = true;
            // 
            // _lblStatic_1
            // 
            resources.ApplyResources(this._lblStatic_1, "_lblStatic_1");
            this._lblStatic_1.BackColor = System.Drawing.SystemColors.Control;
            this._lblStatic_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblStatic_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblStatic_1.Name = "_lblStatic_1";
            // 
            // txtMin
            // 
            this.txtMin.AcceptsReturn = true;
            resources.ApplyResources(this.txtMin, "txtMin");
            this.txtMin.BackColor = System.Drawing.SystemColors.Window;
            this.txtMin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMin.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtMin.Name = "txtMin";
            this.txtMin.ReadOnly = true;
            // 
            // _lblStatic_0
            // 
            resources.ApplyResources(this._lblStatic_0, "_lblStatic_0");
            this._lblStatic_0.BackColor = System.Drawing.SystemColors.Control;
            this._lblStatic_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblStatic_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblStatic_0.Name = "_lblStatic_0";
            // 
            // _lblStatic_8
            // 
            resources.ApplyResources(this._lblStatic_8, "_lblStatic_8");
            this._lblStatic_8.BackColor = System.Drawing.SystemColors.Control;
            this._lblStatic_8.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblStatic_8.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblStatic_8.Name = "_lblStatic_8";
            // 
            // txtTypeCode
            // 
            this.txtTypeCode.AcceptsReturn = true;
            resources.ApplyResources(this.txtTypeCode, "txtTypeCode");
            this.txtTypeCode.BackColor = System.Drawing.SystemColors.Window;
            this.txtTypeCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTypeCode.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTypeCode.Name = "txtTypeCode";
            this.txtTypeCode.ReadOnly = true;
            // 
            // txtTypeName
            // 
            this.txtTypeName.AcceptsReturn = true;
            resources.ApplyResources(this.txtTypeName, "txtTypeName");
            this.txtTypeName.BackColor = System.Drawing.SystemColors.Window;
            this.txtTypeName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTypeName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTypeName.Name = "txtTypeName";
            this.txtTypeName.ReadOnly = true;
            // 
            // _lblStatic_2
            // 
            resources.ApplyResources(this._lblStatic_2, "_lblStatic_2");
            this._lblStatic_2.BackColor = System.Drawing.SystemColors.Control;
            this._lblStatic_2.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblStatic_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblStatic_2.Name = "_lblStatic_2";
            // 
            // _lblStatic_7
            // 
            resources.ApplyResources(this._lblStatic_7, "_lblStatic_7");
            this._lblStatic_7.BackColor = System.Drawing.SystemColors.Control;
            this._lblStatic_7.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblStatic_7.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblStatic_7.Name = "_lblStatic_7";
            // 
            // txtFieldName
            // 
            this.txtFieldName.AcceptsReturn = true;
            resources.ApplyResources(this.txtFieldName, "txtFieldName");
            this.txtFieldName.BackColor = System.Drawing.SystemColors.Window;
            this.txtFieldName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFieldName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFieldName.Name = "txtFieldName";
            this.txtFieldName.ReadOnly = true;
            // 
            // _lblStatic_6
            // 
            resources.ApplyResources(this._lblStatic_6, "_lblStatic_6");
            this._lblStatic_6.BackColor = System.Drawing.SystemColors.Control;
            this._lblStatic_6.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblStatic_6.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblStatic_6.Name = "_lblStatic_6";
            // 
            // txtVarName
            // 
            this.txtVarName.AcceptsReturn = true;
            resources.ApplyResources(this.txtVarName, "txtVarName");
            this.txtVarName.BackColor = System.Drawing.SystemColors.Window;
            this.txtVarName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtVarName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtVarName.Name = "txtVarName";
            this.txtVarName.ReadOnly = true;
            // 
            // _lblStatic_5
            // 
            resources.ApplyResources(this._lblStatic_5, "_lblStatic_5");
            this._lblStatic_5.BackColor = System.Drawing.SystemColors.Control;
            this._lblStatic_5.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblStatic_5.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblStatic_5.Name = "_lblStatic_5";
            // 
            // cmdEditValue
            // 
            resources.ApplyResources(this.cmdEditValue, "cmdEditValue");
            this.cmdEditValue.BackColor = System.Drawing.SystemColors.Control;
            this.cmdEditValue.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdEditValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdEditValue.Name = "cmdEditValue";
            this.cmdEditValue.UseVisualStyleBackColor = false;
            this.cmdEditValue.Click += new System.EventHandler(this.cmdEditValue_Click);
            // 
            // txtVarValue
            // 
            this.txtVarValue.AcceptsReturn = true;
            resources.ApplyResources(this.txtVarValue, "txtVarValue");
            this.txtVarValue.BackColor = System.Drawing.SystemColors.Window;
            this.txtVarValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtVarValue.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtVarValue.Name = "txtVarValue";
            this.txtVarValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVarValue_KeyPress);
            // 
            // tmrUpdateLight
            // 
            this.tmrUpdateLight.Interval = 250;
            this.tmrUpdateLight.Tick += new System.EventHandler(this.tmrUpdateLight_Tick);
            // 
            // frmSysVars
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdFind);
            this.Controls.Add(this.treSysVars);
            this.Controls.Add(this.cmdAddToScattAccess);
            this.Controls.Add(this.chkNoUpdate);
            this.Controls.Add(this._lblStatic_5);
            this.Controls.Add(this.chkNoRefresh);
            this.Controls.Add(this.txtVarValue);
            this.Controls.Add(this.cmdUpdate);
            this.Controls.Add(this.cmdEditValue);
            this.Controls.Add(this.cmdRefresh);
            this.Controls.Add(this.txtVarName);
            this.Controls.Add(this.lblEvent);
            this.Controls.Add(this._lblStatic_6);
            this.Controls.Add(this.picEvent);
            this.Controls.Add(this.txtFieldName);
            this.Controls.Add(this.picMonitor);
            this.Controls.Add(this._lblStatic_7);
            this.Controls.Add(this.lblMonitor);
            this.Controls.Add(this._lblStatic_2);
            this.Controls.Add(this.txtLatency);
            this.Controls.Add(this.txtTypeName);
            this.Controls.Add(this.lblLatency);
            this.Controls.Add(this.txtTypeCode);
            this.Controls.Add(this.cmdStopMon);
            this.Controls.Add(this._lblStatic_8);
            this.Controls.Add(this.cmdMonitor);
            this.Controls.Add(this._lblStatic_0);
            this.Controls.Add(this.txtMax);
            this.Controls.Add(this.txtMin);
            this.Controls.Add(this._lblStatic_1);
            this.Name = "frmSysVars";
            this.ShowIcon = false;
            this.Activated += new System.EventHandler(this.frmSysVars_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSysVars_FormClosing);
            this.Load += new System.EventHandler(this.frmSysVars_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picEvent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMonitor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        internal System.Windows.Forms.TreeView treSysVars;
        public System.Windows.Forms.Button cmdFind;
        public System.Windows.Forms.Button cmdAddToScattAccess;
        public System.Windows.Forms.CheckBox chkNoUpdate;
        public System.Windows.Forms.CheckBox chkNoRefresh;
        public System.Windows.Forms.Button cmdUpdate;
        public System.Windows.Forms.Button cmdRefresh;
        public System.Windows.Forms.Label lblEvent;
        public System.Windows.Forms.PictureBox picEvent;
        public System.Windows.Forms.PictureBox picMonitor;
        public System.Windows.Forms.Label lblMonitor;
        public System.Windows.Forms.TextBox txtLatency;
        public System.Windows.Forms.Label lblLatency;
        public System.Windows.Forms.Button cmdStopMon;
        public System.Windows.Forms.Button cmdMonitor;
        public System.Windows.Forms.TextBox txtMax;
        public System.Windows.Forms.Label _lblStatic_1;
        public System.Windows.Forms.TextBox txtMin;
        public System.Windows.Forms.Label _lblStatic_0;
        public System.Windows.Forms.TextBox txtVarValue;
        public System.Windows.Forms.Label _lblStatic_8;
        public System.Windows.Forms.TextBox txtTypeCode;
        public System.Windows.Forms.TextBox txtTypeName;
        public System.Windows.Forms.Label _lblStatic_2;
        public System.Windows.Forms.Label _lblStatic_7;
        public System.Windows.Forms.TextBox txtFieldName;
        public System.Windows.Forms.Label _lblStatic_6;
        public System.Windows.Forms.TextBox txtVarName;
        public System.Windows.Forms.Label _lblStatic_5;
        public System.Windows.Forms.Button cmdEditValue;
        internal System.Windows.Forms.Timer tmrUpdateLight;
    }
}