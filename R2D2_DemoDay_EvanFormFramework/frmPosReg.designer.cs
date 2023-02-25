namespace FRRobotDemoCSharp
{
    partial class frmPosReg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPosReg));
            this.treePosReg = new System.Windows.Forms.TreeView();
            this.lblNumGroups = new System.Windows.Forms.Label();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.cmdCopy = new System.Windows.Forms.Button();
            this.cmdPaste = new System.Windows.Forms.Button();
            this.cmdMoveto = new System.Windows.Forms.Button();
            this.cmdRecord = new System.Windows.Forms.Button();
            this.cmdUninit = new System.Windows.Forms.Button();
            this.picMonitor = new System.Windows.Forms.PictureBox();
            this.cmdStartMon = new System.Windows.Forms.Button();
            this.cmdStopMon = new System.Windows.Forms.Button();
            this.txtLatency = new System.Windows.Forms.TextBox();
            this.picUpdate = new System.Windows.Forms.PictureBox();
            this.lblMonitor = new System.Windows.Forms.Label();
            this.lblLatency = new System.Windows.Forms.Label();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.grpMonitor = new System.Windows.Forms.GroupBox();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.tmrRunOnce = new System.Windows.Forms.Timer(this.components);
            this.tmrBlinkUpdate = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picMonitor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUpdate)).BeginInit();
            this.grpMonitor.SuspendLayout();
            this.SuspendLayout();
            // 
            // treePosReg
            // 
            resources.ApplyResources(this.treePosReg, "treePosReg");
            this.treePosReg.Name = "treePosReg";
            this.treePosReg.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treePosReg_AfterExpand);
            this.treePosReg.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treePosReg_AfterSelect);
            // 
            // lblNumGroups
            // 
            resources.ApplyResources(this.lblNumGroups, "lblNumGroups");
            this.lblNumGroups.Name = "lblNumGroups";
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
            // cmdCopy
            // 
            resources.ApplyResources(this.cmdCopy, "cmdCopy");
            this.cmdCopy.BackColor = System.Drawing.SystemColors.Control;
            this.cmdCopy.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdCopy.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdCopy.Name = "cmdCopy";
            this.cmdCopy.UseVisualStyleBackColor = false;
            this.cmdCopy.Click += new System.EventHandler(this.cmdCopy_Click);
            // 
            // cmdPaste
            // 
            resources.ApplyResources(this.cmdPaste, "cmdPaste");
            this.cmdPaste.BackColor = System.Drawing.SystemColors.Control;
            this.cmdPaste.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdPaste.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdPaste.Name = "cmdPaste";
            this.cmdPaste.UseVisualStyleBackColor = false;
            this.cmdPaste.Click += new System.EventHandler(this.cmdPaste_Click);
            // 
            // cmdMoveto
            // 
            resources.ApplyResources(this.cmdMoveto, "cmdMoveto");
            this.cmdMoveto.BackColor = System.Drawing.SystemColors.Control;
            this.cmdMoveto.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdMoveto.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdMoveto.Name = "cmdMoveto";
            this.cmdMoveto.UseVisualStyleBackColor = false;
            this.cmdMoveto.Click += new System.EventHandler(this.cmdMoveto_Click);
            // 
            // cmdRecord
            // 
            resources.ApplyResources(this.cmdRecord, "cmdRecord");
            this.cmdRecord.BackColor = System.Drawing.SystemColors.Control;
            this.cmdRecord.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdRecord.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdRecord.Name = "cmdRecord";
            this.cmdRecord.UseVisualStyleBackColor = false;
            this.cmdRecord.Click += new System.EventHandler(this.cmdRecord_Click);
            // 
            // cmdUninit
            // 
            resources.ApplyResources(this.cmdUninit, "cmdUninit");
            this.cmdUninit.BackColor = System.Drawing.SystemColors.Control;
            this.cmdUninit.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdUninit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdUninit.Name = "cmdUninit";
            this.cmdUninit.UseVisualStyleBackColor = false;
            this.cmdUninit.Click += new System.EventHandler(this.cmdUninit_Click);
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
            // cmdStartMon
            // 
            this.cmdStartMon.BackColor = System.Drawing.SystemColors.Control;
            this.cmdStartMon.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.cmdStartMon, "cmdStartMon");
            this.cmdStartMon.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdStartMon.Name = "cmdStartMon";
            this.cmdStartMon.UseVisualStyleBackColor = false;
            this.cmdStartMon.Click += new System.EventHandler(this.cmdStartMon_Click);
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
            // txtLatency
            // 
            this.txtLatency.AcceptsReturn = true;
            this.txtLatency.BackColor = System.Drawing.SystemColors.Window;
            this.txtLatency.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtLatency, "txtLatency");
            this.txtLatency.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLatency.Name = "txtLatency";
            // 
            // picUpdate
            // 
            this.picUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.picUpdate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picUpdate.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.picUpdate, "picUpdate");
            this.picUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.picUpdate.Name = "picUpdate";
            this.picUpdate.TabStop = false;
            // 
            // lblMonitor
            // 
            this.lblMonitor.BackColor = System.Drawing.SystemColors.Control;
            this.lblMonitor.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblMonitor, "lblMonitor");
            this.lblMonitor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMonitor.Name = "lblMonitor";
            // 
            // lblLatency
            // 
            this.lblLatency.BackColor = System.Drawing.SystemColors.Control;
            this.lblLatency.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblLatency, "lblLatency");
            this.lblLatency.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLatency.Name = "lblLatency";
            // 
            // lblUpdate
            // 
            this.lblUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.lblUpdate.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblUpdate, "lblUpdate");
            this.lblUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUpdate.Name = "lblUpdate";
            // 
            // grpMonitor
            // 
            resources.ApplyResources(this.grpMonitor, "grpMonitor");
            this.grpMonitor.Controls.Add(this.cmdStartMon);
            this.grpMonitor.Controls.Add(this.picUpdate);
            this.grpMonitor.Controls.Add(this.picMonitor);
            this.grpMonitor.Controls.Add(this.lblUpdate);
            this.grpMonitor.Controls.Add(this.cmdStopMon);
            this.grpMonitor.Controls.Add(this.txtLatency);
            this.grpMonitor.Controls.Add(this.lblMonitor);
            this.grpMonitor.Controls.Add(this.lblLatency);
            this.grpMonitor.Name = "grpMonitor";
            this.grpMonitor.TabStop = false;
            // 
            // cmdEdit
            // 
            resources.ApplyResources(this.cmdEdit, "cmdEdit");
            this.cmdEdit.BackColor = System.Drawing.SystemColors.Control;
            this.cmdEdit.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdEdit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.UseVisualStyleBackColor = false;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // tmrRunOnce
            // 
            this.tmrRunOnce.Enabled = true;
            this.tmrRunOnce.Tick += new System.EventHandler(this.tmrRunOnce_Tick);
            // 
            // tmrBlinkUpdate
            // 
            this.tmrBlinkUpdate.Interval = 500;
            this.tmrBlinkUpdate.Tick += new System.EventHandler(this.tmrBlinkUpdate_Tick);
            // 
            // frmPosReg
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.grpMonitor);
            this.Controls.Add(this.cmdMoveto);
            this.Controls.Add(this.cmdRecord);
            this.Controls.Add(this.cmdUninit);
            this.Controls.Add(this.cmdRefresh);
            this.Controls.Add(this.cmdUpdate);
            this.Controls.Add(this.cmdCopy);
            this.Controls.Add(this.cmdPaste);
            this.Controls.Add(this.lblNumGroups);
            this.Controls.Add(this.treePosReg);
            this.Name = "frmPosReg";
            this.ShowIcon = false;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPosReg_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.picMonitor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUpdate)).EndInit();
            this.grpMonitor.ResumeLayout(false);
            this.grpMonitor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        internal System.Windows.Forms.TreeView treePosReg;
        internal System.Windows.Forms.Label lblNumGroups;
        public System.Windows.Forms.Button cmdRefresh;
        public System.Windows.Forms.Button cmdUpdate;
        public System.Windows.Forms.Button cmdCopy;
        public System.Windows.Forms.Button cmdPaste;
        public System.Windows.Forms.Button cmdMoveto;
        public System.Windows.Forms.Button cmdRecord;
        public System.Windows.Forms.Button cmdUninit;
        public System.Windows.Forms.PictureBox picMonitor;
        public System.Windows.Forms.Button cmdStartMon;
        public System.Windows.Forms.Button cmdStopMon;
        public System.Windows.Forms.TextBox txtLatency;
        public System.Windows.Forms.PictureBox picUpdate;
        public System.Windows.Forms.Label lblMonitor;
        public System.Windows.Forms.Label lblLatency;
        public System.Windows.Forms.Label lblUpdate;
        internal System.Windows.Forms.GroupBox grpMonitor;
        public System.Windows.Forms.Button cmdEdit;
        internal System.Windows.Forms.Timer tmrRunOnce;
        internal System.Windows.Forms.Timer tmrBlinkUpdate;
    }
}