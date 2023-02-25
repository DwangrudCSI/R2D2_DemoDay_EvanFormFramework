namespace FRRobotDemoCSharp
{
    partial class frmFTP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFTP));
            this.cmdFind = new System.Windows.Forms.Button();
            this.ftpDetails = new System.Windows.Forms.GroupBox();
            this.txtHostName = new System.Windows.Forms.TextBox();
            this._lblStatic_10 = new System.Windows.Forms.Label();
            this.lstFilter = new System.Windows.Forms.ListBox();
            this._lblStatic_8 = new System.Windows.Forms.Label();
            this.cmbRbtDir = new System.Windows.Forms.ComboBox();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.chkWaitForLoad = new System.Windows.Forms.CheckBox();
            this.cmdLoad = new System.Windows.Forms.Button();
            this.cmdCreateDir = new System.Windows.Forms.Button();
            this.cmdRemoveDir = new System.Windows.Forms.Button();
            this.lblTransferFTP = new System.Windows.Forms.Label();
            this.cmdUpload = new System.Windows.Forms.Button();
            this.transferFTP = new System.Windows.Forms.ProgressBar();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdBackup = new System.Windows.Forms.Button();
            this.chkPassive = new System.Windows.Forms.CheckBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this._lblStatic_7 = new System.Windows.Forms.Label();
            this._lblStatic_6 = new System.Windows.Forms.Label();
            this._lblStatic_5 = new System.Windows.Forms.Label();
            this.cmdConnect = new System.Windows.Forms.Button();
            this.treeFTP = new System.Windows.Forms.TreeView();
            this._lblStatic_9 = new System.Windows.Forms.Label();
            this.ftpDetails.SuspendLayout();
            this.SuspendLayout();
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
            // ftpDetails
            // 
            resources.ApplyResources(this.ftpDetails, "ftpDetails");
            this.ftpDetails.BackColor = System.Drawing.SystemColors.Control;
            this.ftpDetails.Controls.Add(this.txtHostName);
            this.ftpDetails.Controls.Add(this._lblStatic_10);
            this.ftpDetails.Controls.Add(this.lstFilter);
            this.ftpDetails.Controls.Add(this._lblStatic_8);
            this.ftpDetails.Controls.Add(this.cmbRbtDir);
            this.ftpDetails.Controls.Add(this.cmdRefresh);
            this.ftpDetails.Controls.Add(this.chkWaitForLoad);
            this.ftpDetails.Controls.Add(this.cmdLoad);
            this.ftpDetails.Controls.Add(this.cmdCreateDir);
            this.ftpDetails.Controls.Add(this.cmdRemoveDir);
            this.ftpDetails.Controls.Add(this.lblTransferFTP);
            this.ftpDetails.Controls.Add(this.cmdUpload);
            this.ftpDetails.Controls.Add(this.transferFTP);
            this.ftpDetails.Controls.Add(this.cmdFind);
            this.ftpDetails.Controls.Add(this.cmdDelete);
            this.ftpDetails.Controls.Add(this.cmdBackup);
            this.ftpDetails.Controls.Add(this.chkPassive);
            this.ftpDetails.Controls.Add(this.txtPort);
            this.ftpDetails.Controls.Add(this.txtPassword);
            this.ftpDetails.Controls.Add(this.txtUserName);
            this.ftpDetails.Controls.Add(this._lblStatic_7);
            this.ftpDetails.Controls.Add(this._lblStatic_6);
            this.ftpDetails.Controls.Add(this._lblStatic_5);
            this.ftpDetails.Controls.Add(this.cmdConnect);
            this.ftpDetails.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ftpDetails.Name = "ftpDetails";
            this.ftpDetails.TabStop = false;
            // 
            // txtHostName
            // 
            this.txtHostName.AcceptsReturn = true;
            this.txtHostName.BackColor = System.Drawing.SystemColors.Window;
            this.txtHostName.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtHostName, "txtHostName");
            this.txtHostName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtHostName.Name = "txtHostName";
            this.txtHostName.Click += new System.EventHandler(this.txtHostName_Click);
            this.txtHostName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtHostName_KeyUp);
            this.txtHostName.Leave += new System.EventHandler(this.txtHostName_Leave);
            // 
            // _lblStatic_10
            // 
            this._lblStatic_10.BackColor = System.Drawing.SystemColors.Control;
            this._lblStatic_10.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this._lblStatic_10, "_lblStatic_10");
            this._lblStatic_10.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblStatic_10.Name = "_lblStatic_10";
            // 
            // lstFilter
            // 
            resources.ApplyResources(this.lstFilter, "lstFilter");
            this.lstFilter.FormattingEnabled = true;
            this.lstFilter.MultiColumn = true;
            this.lstFilter.Name = "lstFilter";
            this.lstFilter.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstFilter.Click += new System.EventHandler(this.lstFilter_Click);
            // 
            // _lblStatic_8
            // 
            this._lblStatic_8.BackColor = System.Drawing.SystemColors.Control;
            this._lblStatic_8.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this._lblStatic_8, "_lblStatic_8");
            this._lblStatic_8.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblStatic_8.Name = "_lblStatic_8";
            // 
            // cmbRbtDir
            // 
            this.cmbRbtDir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbRbtDir, "cmbRbtDir");
            this.cmbRbtDir.FormattingEnabled = true;
            this.cmbRbtDir.Name = "cmbRbtDir";
            this.cmbRbtDir.SelectedIndexChanged += new System.EventHandler(this.cmbRbtDir_SelectedIndexChanged);
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
            // chkWaitForLoad
            // 
            this.chkWaitForLoad.BackColor = System.Drawing.SystemColors.Control;
            this.chkWaitForLoad.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.chkWaitForLoad, "chkWaitForLoad");
            this.chkWaitForLoad.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkWaitForLoad.Name = "chkWaitForLoad";
            this.chkWaitForLoad.UseVisualStyleBackColor = false;
            // 
            // cmdLoad
            // 
            resources.ApplyResources(this.cmdLoad, "cmdLoad");
            this.cmdLoad.BackColor = System.Drawing.SystemColors.Control;
            this.cmdLoad.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdLoad.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdLoad.Name = "cmdLoad";
            this.cmdLoad.UseVisualStyleBackColor = false;
            this.cmdLoad.Click += new System.EventHandler(this.cmdLoad_Click);
            // 
            // cmdCreateDir
            // 
            resources.ApplyResources(this.cmdCreateDir, "cmdCreateDir");
            this.cmdCreateDir.BackColor = System.Drawing.SystemColors.Control;
            this.cmdCreateDir.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdCreateDir.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdCreateDir.Name = "cmdCreateDir";
            this.cmdCreateDir.UseVisualStyleBackColor = false;
            this.cmdCreateDir.Click += new System.EventHandler(this.cmdCreateDir_Click);
            // 
            // cmdRemoveDir
            // 
            resources.ApplyResources(this.cmdRemoveDir, "cmdRemoveDir");
            this.cmdRemoveDir.BackColor = System.Drawing.SystemColors.Control;
            this.cmdRemoveDir.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdRemoveDir.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdRemoveDir.Name = "cmdRemoveDir";
            this.cmdRemoveDir.UseVisualStyleBackColor = false;
            this.cmdRemoveDir.Click += new System.EventHandler(this.cmdRemoveDir_Click);
            // 
            // lblTransferFTP
            // 
            resources.ApplyResources(this.lblTransferFTP, "lblTransferFTP");
            this.lblTransferFTP.BackColor = System.Drawing.SystemColors.Control;
            this.lblTransferFTP.Name = "lblTransferFTP";
            // 
            // cmdUpload
            // 
            this.cmdUpload.BackColor = System.Drawing.SystemColors.Control;
            this.cmdUpload.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.cmdUpload, "cmdUpload");
            this.cmdUpload.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdUpload.Name = "cmdUpload";
            this.cmdUpload.UseVisualStyleBackColor = false;
            this.cmdUpload.Click += new System.EventHandler(this.cmdUpload_Click);
            // 
            // transferFTP
            // 
            resources.ApplyResources(this.transferFTP, "transferFTP");
            this.transferFTP.Name = "transferFTP";
            this.transferFTP.Step = 1;
            // 
            // cmdDelete
            // 
            this.cmdDelete.BackColor = System.Drawing.SystemColors.Control;
            this.cmdDelete.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.cmdDelete, "cmdDelete");
            this.cmdDelete.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.UseVisualStyleBackColor = false;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdBackup
            // 
            this.cmdBackup.BackColor = System.Drawing.SystemColors.Control;
            this.cmdBackup.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.cmdBackup, "cmdBackup");
            this.cmdBackup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdBackup.Name = "cmdBackup";
            this.cmdBackup.UseVisualStyleBackColor = false;
            this.cmdBackup.Click += new System.EventHandler(this.cmdBackup_Click);
            // 
            // chkPassive
            // 
            this.chkPassive.BackColor = System.Drawing.SystemColors.Control;
            this.chkPassive.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.chkPassive, "chkPassive");
            this.chkPassive.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkPassive.Name = "chkPassive";
            this.chkPassive.UseVisualStyleBackColor = false;
            // 
            // txtPort
            // 
            this.txtPort.AcceptsReturn = true;
            this.txtPort.BackColor = System.Drawing.SystemColors.Window;
            this.txtPort.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtPort, "txtPort");
            this.txtPort.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPort.Name = "txtPort";
            // 
            // txtPassword
            // 
            this.txtPassword.AcceptsReturn = true;
            this.txtPassword.BackColor = System.Drawing.SystemColors.Window;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtPassword, "txtPassword");
            this.txtPassword.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPassword.Name = "txtPassword";
            // 
            // txtUserName
            // 
            this.txtUserName.AcceptsReturn = true;
            this.txtUserName.BackColor = System.Drawing.SystemColors.Window;
            this.txtUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtUserName, "txtUserName");
            this.txtUserName.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Click += new System.EventHandler(this.txtUserName_Click);
            this.txtUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserName_KeyDown);
            this.txtUserName.Leave += new System.EventHandler(this.txtUserName_Leave);
            // 
            // _lblStatic_7
            // 
            this._lblStatic_7.BackColor = System.Drawing.SystemColors.Control;
            this._lblStatic_7.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this._lblStatic_7, "_lblStatic_7");
            this._lblStatic_7.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblStatic_7.Name = "_lblStatic_7";
            // 
            // _lblStatic_6
            // 
            this._lblStatic_6.BackColor = System.Drawing.SystemColors.Control;
            this._lblStatic_6.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this._lblStatic_6, "_lblStatic_6");
            this._lblStatic_6.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblStatic_6.Name = "_lblStatic_6";
            // 
            // _lblStatic_5
            // 
            this._lblStatic_5.BackColor = System.Drawing.SystemColors.Control;
            this._lblStatic_5.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this._lblStatic_5, "_lblStatic_5");
            this._lblStatic_5.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblStatic_5.Name = "_lblStatic_5";
            // 
            // cmdConnect
            // 
            this.cmdConnect.BackColor = System.Drawing.SystemColors.Control;
            this.cmdConnect.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.cmdConnect, "cmdConnect");
            this.cmdConnect.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdConnect.Name = "cmdConnect";
            this.cmdConnect.UseVisualStyleBackColor = false;
            this.cmdConnect.Click += new System.EventHandler(this.cmdConnect_Click);
            // 
            // treeFTP
            // 
            resources.ApplyResources(this.treeFTP, "treeFTP");
            this.treeFTP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeFTP.Name = "treeFTP";
            this.treeFTP.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeFTP_AfterExpand);
            this.treeFTP.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeFTP_AfterSelect);
            this.treeFTP.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeFTP_NodeMouseClick);
            // 
            // _lblStatic_9
            // 
            resources.ApplyResources(this._lblStatic_9, "_lblStatic_9");
            this._lblStatic_9.BackColor = System.Drawing.SystemColors.Control;
            this._lblStatic_9.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblStatic_9.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblStatic_9.Name = "_lblStatic_9";
            // 
            // frmFTP
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._lblStatic_9);
            this.Controls.Add(this.ftpDetails);
            this.Controls.Add(this.treeFTP);
            this.KeyPreview = true;
            this.Name = "frmFTP";
            this.ShowIcon = false;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmFTP_FormClosed);
            this.Load += new System.EventHandler(this.frmFTP_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmFTP_KeyPress);
            this.ftpDetails.ResumeLayout(false);
            this.ftpDetails.PerformLayout();
            this.ResumeLayout(false);

        }
        public System.Windows.Forms.Button cmdFind;
        public System.Windows.Forms.GroupBox ftpDetails;
        public System.Windows.Forms.TextBox txtPort;
        public System.Windows.Forms.TextBox txtPassword;
        public System.Windows.Forms.TextBox txtUserName;
        public System.Windows.Forms.Label _lblStatic_7;
        public System.Windows.Forms.Label _lblStatic_6;
        public System.Windows.Forms.Label _lblStatic_5;
        public System.Windows.Forms.TreeView treeFTP;
        public System.Windows.Forms.Button cmdConnect;
        public System.Windows.Forms.CheckBox chkPassive;
        public System.Windows.Forms.Button cmdBackup;
        public System.Windows.Forms.Button cmdDelete;
        public System.Windows.Forms.Button cmdUpload;
        private System.Windows.Forms.ProgressBar transferFTP;
        private System.Windows.Forms.Label lblTransferFTP;
        public System.Windows.Forms.Button cmdRemoveDir;
        public System.Windows.Forms.Button cmdCreateDir;
        public System.Windows.Forms.Label _lblStatic_9;
        public System.Windows.Forms.Button cmdLoad;
        public System.Windows.Forms.CheckBox chkWaitForLoad;
        public System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.ComboBox cmbRbtDir;
        public System.Windows.Forms.Label _lblStatic_8;
        private System.Windows.Forms.ListBox lstFilter;
        public System.Windows.Forms.TextBox txtHostName;
        public System.Windows.Forms.Label _lblStatic_10;
    }
}