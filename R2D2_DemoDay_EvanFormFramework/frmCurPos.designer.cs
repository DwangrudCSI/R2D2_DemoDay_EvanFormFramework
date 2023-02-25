namespace FRRobotDemoCSharp
{
    partial class frmCurPos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCurPos));
            this.tabsCurPos = new System.Windows.Forms.TabControl();
            this.JointTab = new System.Windows.Forms.TabPage();
            this.lblJointNum_0 = new System.Windows.Forms.Label();
            this.lblJointNum_1 = new System.Windows.Forms.Label();
            this.lblJointNum_2 = new System.Windows.Forms.Label();
            this.lblJointNum_3 = new System.Windows.Forms.Label();
            this.lblJointNum_4 = new System.Windows.Forms.Label();
            this.lblJointNum_5 = new System.Windows.Forms.Label();
            this.lblJointNum_6 = new System.Windows.Forms.Label();
            this.lblJointNum_7 = new System.Windows.Forms.Label();
            this.lblJointNum_8 = new System.Windows.Forms.Label();
            this.txtJoint_0 = new System.Windows.Forms.TextBox();
            this.txtJoint_1 = new System.Windows.Forms.TextBox();
            this.txtJoint_2 = new System.Windows.Forms.TextBox();
            this.txtJoint_3 = new System.Windows.Forms.TextBox();
            this.txtJoint_4 = new System.Windows.Forms.TextBox();
            this.txtJoint_5 = new System.Windows.Forms.TextBox();
            this.txtJoint_6 = new System.Windows.Forms.TextBox();
            this.txtJoint_7 = new System.Windows.Forms.TextBox();
            this.txtJoint_8 = new System.Windows.Forms.TextBox();
            this.WorldTab = new System.Windows.Forms.TabPage();
            this._lblWrdCurPos_0 = new System.Windows.Forms.Label();
            this._lblWrdCurPos_1 = new System.Windows.Forms.Label();
            this._lblWrdCurPos_2 = new System.Windows.Forms.Label();
            this._lblWrdCurPos_3 = new System.Windows.Forms.Label();
            this._lblWrdCurPos_4 = new System.Windows.Forms.Label();
            this._lblWrdCurPos_5 = new System.Windows.Forms.Label();
            this.lblWorldExtAxes_0 = new System.Windows.Forms.Label();
            this.lblWorldExtAxes_1 = new System.Windows.Forms.Label();
            this.lblWorldExtAxes_2 = new System.Windows.Forms.Label();
            this.txtWorld_0 = new System.Windows.Forms.TextBox();
            this.txtWorld_1 = new System.Windows.Forms.TextBox();
            this.txtWorld_2 = new System.Windows.Forms.TextBox();
            this.txtWorld_3 = new System.Windows.Forms.TextBox();
            this.txtWorld_4 = new System.Windows.Forms.TextBox();
            this.txtWorld_5 = new System.Windows.Forms.TextBox();
            this.txtWorldExtAxes_0 = new System.Windows.Forms.TextBox();
            this.txtWorldExtAxes_1 = new System.Windows.Forms.TextBox();
            this.txtWorldExtAxes_2 = new System.Windows.Forms.TextBox();
            this.UserTab = new System.Windows.Forms.TabPage();
            this.lblUser_0 = new System.Windows.Forms.Label();
            this.lblUser_1 = new System.Windows.Forms.Label();
            this.lblUser_2 = new System.Windows.Forms.Label();
            this.lblUser_3 = new System.Windows.Forms.Label();
            this.lblUser_4 = new System.Windows.Forms.Label();
            this.lblUser_5 = new System.Windows.Forms.Label();
            this.lblUserExtAxes_0 = new System.Windows.Forms.Label();
            this.lblUserExtAxes_1 = new System.Windows.Forms.Label();
            this.lblUserExtAxes_2 = new System.Windows.Forms.Label();
            this.txtUser_0 = new System.Windows.Forms.TextBox();
            this.txtUser_1 = new System.Windows.Forms.TextBox();
            this.txtUser_2 = new System.Windows.Forms.TextBox();
            this.txtUser_3 = new System.Windows.Forms.TextBox();
            this.txtUser_4 = new System.Windows.Forms.TextBox();
            this.txtUser_5 = new System.Windows.Forms.TextBox();
            this.txtUserExtAxes_0 = new System.Windows.Forms.TextBox();
            this.txtUserExtAxes_1 = new System.Windows.Forms.TextBox();
            this.txtUserExtAxes_2 = new System.Windows.Forms.TextBox();
            this.cmdSetCurPosAsCopySource = new System.Windows.Forms.Button();
            this.cmdSetCurGrpPosAsCopySource = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.cboGroupSel = new System.Windows.Forms.ComboBox();
            this.grpMonitor = new System.Windows.Forms.GroupBox();
            this.cmdStartMon = new System.Windows.Forms.Button();
            this.picUpdate = new System.Windows.Forms.PictureBox();
            this.picMonitor = new System.Windows.Forms.PictureBox();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.cmdStopMon = new System.Windows.Forms.Button();
            this.txtLatency = new System.Windows.Forms.TextBox();
            this.lblMonitor = new System.Windows.Forms.Label();
            this.lblLatency = new System.Windows.Forms.Label();
            this.tmrUpdateDisplay = new System.Windows.Forms.Timer(this.components);
            this.tmrBlinkUpdate = new System.Windows.Forms.Timer(this.components);
            this.tabsCurPos.SuspendLayout();
            this.JointTab.SuspendLayout();
            this.WorldTab.SuspendLayout();
            this.UserTab.SuspendLayout();
            this.grpMonitor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMonitor)).BeginInit();
            this.SuspendLayout();
            // 
            // tabsCurPos
            // 
            this.tabsCurPos.Controls.Add(this.JointTab);
            this.tabsCurPos.Controls.Add(this.WorldTab);
            this.tabsCurPos.Controls.Add(this.UserTab);
            resources.ApplyResources(this.tabsCurPos, "tabsCurPos");
            this.tabsCurPos.Name = "tabsCurPos";
            this.tabsCurPos.SelectedIndex = 0;
            this.tabsCurPos.SelectedIndexChanged += new System.EventHandler(this.tabsCurPos_SelectedIndexChanged);
            // 
            // JointTab
            // 
            this.JointTab.Controls.Add(this.lblJointNum_0);
            this.JointTab.Controls.Add(this.lblJointNum_1);
            this.JointTab.Controls.Add(this.lblJointNum_2);
            this.JointTab.Controls.Add(this.lblJointNum_3);
            this.JointTab.Controls.Add(this.lblJointNum_4);
            this.JointTab.Controls.Add(this.lblJointNum_5);
            this.JointTab.Controls.Add(this.lblJointNum_6);
            this.JointTab.Controls.Add(this.lblJointNum_7);
            this.JointTab.Controls.Add(this.lblJointNum_8);
            this.JointTab.Controls.Add(this.txtJoint_0);
            this.JointTab.Controls.Add(this.txtJoint_1);
            this.JointTab.Controls.Add(this.txtJoint_2);
            this.JointTab.Controls.Add(this.txtJoint_3);
            this.JointTab.Controls.Add(this.txtJoint_4);
            this.JointTab.Controls.Add(this.txtJoint_5);
            this.JointTab.Controls.Add(this.txtJoint_6);
            this.JointTab.Controls.Add(this.txtJoint_7);
            this.JointTab.Controls.Add(this.txtJoint_8);
            resources.ApplyResources(this.JointTab, "JointTab");
            this.JointTab.Name = "JointTab";
            // 
            // lblJointNum_0
            // 
            this.lblJointNum_0.BackColor = System.Drawing.SystemColors.Control;
            this.lblJointNum_0.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblJointNum_0, "lblJointNum_0");
            this.lblJointNum_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblJointNum_0.Name = "lblJointNum_0";
            // 
            // lblJointNum_1
            // 
            this.lblJointNum_1.BackColor = System.Drawing.SystemColors.Control;
            this.lblJointNum_1.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblJointNum_1, "lblJointNum_1");
            this.lblJointNum_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblJointNum_1.Name = "lblJointNum_1";
            // 
            // lblJointNum_2
            // 
            this.lblJointNum_2.BackColor = System.Drawing.SystemColors.Control;
            this.lblJointNum_2.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblJointNum_2, "lblJointNum_2");
            this.lblJointNum_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblJointNum_2.Name = "lblJointNum_2";
            // 
            // lblJointNum_3
            // 
            this.lblJointNum_3.BackColor = System.Drawing.SystemColors.Control;
            this.lblJointNum_3.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblJointNum_3, "lblJointNum_3");
            this.lblJointNum_3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblJointNum_3.Name = "lblJointNum_3";
            // 
            // lblJointNum_4
            // 
            this.lblJointNum_4.BackColor = System.Drawing.SystemColors.Control;
            this.lblJointNum_4.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblJointNum_4, "lblJointNum_4");
            this.lblJointNum_4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblJointNum_4.Name = "lblJointNum_4";
            // 
            // lblJointNum_5
            // 
            this.lblJointNum_5.BackColor = System.Drawing.SystemColors.Control;
            this.lblJointNum_5.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblJointNum_5, "lblJointNum_5");
            this.lblJointNum_5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblJointNum_5.Name = "lblJointNum_5";
            // 
            // lblJointNum_6
            // 
            this.lblJointNum_6.BackColor = System.Drawing.SystemColors.Control;
            this.lblJointNum_6.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblJointNum_6, "lblJointNum_6");
            this.lblJointNum_6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblJointNum_6.Name = "lblJointNum_6";
            // 
            // lblJointNum_7
            // 
            this.lblJointNum_7.BackColor = System.Drawing.SystemColors.Control;
            this.lblJointNum_7.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblJointNum_7, "lblJointNum_7");
            this.lblJointNum_7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblJointNum_7.Name = "lblJointNum_7";
            // 
            // lblJointNum_8
            // 
            this.lblJointNum_8.BackColor = System.Drawing.SystemColors.Control;
            this.lblJointNum_8.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblJointNum_8, "lblJointNum_8");
            this.lblJointNum_8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblJointNum_8.Name = "lblJointNum_8";
            // 
            // txtJoint_0
            // 
            this.txtJoint_0.AcceptsReturn = true;
            this.txtJoint_0.BackColor = System.Drawing.SystemColors.Window;
            this.txtJoint_0.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtJoint_0, "txtJoint_0");
            this.txtJoint_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtJoint_0.Name = "txtJoint_0";
            // 
            // txtJoint_1
            // 
            this.txtJoint_1.AcceptsReturn = true;
            this.txtJoint_1.BackColor = System.Drawing.SystemColors.Window;
            this.txtJoint_1.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtJoint_1, "txtJoint_1");
            this.txtJoint_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtJoint_1.Name = "txtJoint_1";
            // 
            // txtJoint_2
            // 
            this.txtJoint_2.AcceptsReturn = true;
            this.txtJoint_2.BackColor = System.Drawing.SystemColors.Window;
            this.txtJoint_2.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtJoint_2, "txtJoint_2");
            this.txtJoint_2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtJoint_2.Name = "txtJoint_2";
            // 
            // txtJoint_3
            // 
            this.txtJoint_3.AcceptsReturn = true;
            this.txtJoint_3.BackColor = System.Drawing.SystemColors.Window;
            this.txtJoint_3.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtJoint_3, "txtJoint_3");
            this.txtJoint_3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtJoint_3.Name = "txtJoint_3";
            // 
            // txtJoint_4
            // 
            this.txtJoint_4.AcceptsReturn = true;
            this.txtJoint_4.BackColor = System.Drawing.SystemColors.Window;
            this.txtJoint_4.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtJoint_4, "txtJoint_4");
            this.txtJoint_4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtJoint_4.Name = "txtJoint_4";
            // 
            // txtJoint_5
            // 
            this.txtJoint_5.AcceptsReturn = true;
            this.txtJoint_5.BackColor = System.Drawing.SystemColors.Window;
            this.txtJoint_5.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtJoint_5, "txtJoint_5");
            this.txtJoint_5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtJoint_5.Name = "txtJoint_5";
            // 
            // txtJoint_6
            // 
            this.txtJoint_6.AcceptsReturn = true;
            this.txtJoint_6.BackColor = System.Drawing.SystemColors.Window;
            this.txtJoint_6.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtJoint_6, "txtJoint_6");
            this.txtJoint_6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtJoint_6.Name = "txtJoint_6";
            // 
            // txtJoint_7
            // 
            this.txtJoint_7.AcceptsReturn = true;
            this.txtJoint_7.BackColor = System.Drawing.SystemColors.Window;
            this.txtJoint_7.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtJoint_7, "txtJoint_7");
            this.txtJoint_7.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtJoint_7.Name = "txtJoint_7";
            // 
            // txtJoint_8
            // 
            this.txtJoint_8.AcceptsReturn = true;
            this.txtJoint_8.BackColor = System.Drawing.SystemColors.Window;
            this.txtJoint_8.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtJoint_8, "txtJoint_8");
            this.txtJoint_8.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtJoint_8.Name = "txtJoint_8";
            // 
            // WorldTab
            // 
            this.WorldTab.Controls.Add(this._lblWrdCurPos_0);
            this.WorldTab.Controls.Add(this._lblWrdCurPos_1);
            this.WorldTab.Controls.Add(this._lblWrdCurPos_2);
            this.WorldTab.Controls.Add(this._lblWrdCurPos_3);
            this.WorldTab.Controls.Add(this._lblWrdCurPos_4);
            this.WorldTab.Controls.Add(this._lblWrdCurPos_5);
            this.WorldTab.Controls.Add(this.lblWorldExtAxes_0);
            this.WorldTab.Controls.Add(this.lblWorldExtAxes_1);
            this.WorldTab.Controls.Add(this.lblWorldExtAxes_2);
            this.WorldTab.Controls.Add(this.txtWorld_0);
            this.WorldTab.Controls.Add(this.txtWorld_1);
            this.WorldTab.Controls.Add(this.txtWorld_2);
            this.WorldTab.Controls.Add(this.txtWorld_3);
            this.WorldTab.Controls.Add(this.txtWorld_4);
            this.WorldTab.Controls.Add(this.txtWorld_5);
            this.WorldTab.Controls.Add(this.txtWorldExtAxes_0);
            this.WorldTab.Controls.Add(this.txtWorldExtAxes_1);
            this.WorldTab.Controls.Add(this.txtWorldExtAxes_2);
            resources.ApplyResources(this.WorldTab, "WorldTab");
            this.WorldTab.Name = "WorldTab";
            // 
            // _lblWrdCurPos_0
            // 
            this._lblWrdCurPos_0.BackColor = System.Drawing.SystemColors.Control;
            this._lblWrdCurPos_0.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this._lblWrdCurPos_0, "_lblWrdCurPos_0");
            this._lblWrdCurPos_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblWrdCurPos_0.Name = "_lblWrdCurPos_0";
            // 
            // _lblWrdCurPos_1
            // 
            this._lblWrdCurPos_1.BackColor = System.Drawing.SystemColors.Control;
            this._lblWrdCurPos_1.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this._lblWrdCurPos_1, "_lblWrdCurPos_1");
            this._lblWrdCurPos_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblWrdCurPos_1.Name = "_lblWrdCurPos_1";
            // 
            // _lblWrdCurPos_2
            // 
            this._lblWrdCurPos_2.BackColor = System.Drawing.SystemColors.Control;
            this._lblWrdCurPos_2.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this._lblWrdCurPos_2, "_lblWrdCurPos_2");
            this._lblWrdCurPos_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblWrdCurPos_2.Name = "_lblWrdCurPos_2";
            // 
            // _lblWrdCurPos_3
            // 
            this._lblWrdCurPos_3.BackColor = System.Drawing.SystemColors.Control;
            this._lblWrdCurPos_3.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this._lblWrdCurPos_3, "_lblWrdCurPos_3");
            this._lblWrdCurPos_3.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblWrdCurPos_3.Name = "_lblWrdCurPos_3";
            // 
            // _lblWrdCurPos_4
            // 
            this._lblWrdCurPos_4.BackColor = System.Drawing.SystemColors.Control;
            this._lblWrdCurPos_4.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this._lblWrdCurPos_4, "_lblWrdCurPos_4");
            this._lblWrdCurPos_4.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblWrdCurPos_4.Name = "_lblWrdCurPos_4";
            // 
            // _lblWrdCurPos_5
            // 
            this._lblWrdCurPos_5.BackColor = System.Drawing.SystemColors.Control;
            this._lblWrdCurPos_5.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this._lblWrdCurPos_5, "_lblWrdCurPos_5");
            this._lblWrdCurPos_5.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblWrdCurPos_5.Name = "_lblWrdCurPos_5";
            // 
            // lblWorldExtAxes_0
            // 
            this.lblWorldExtAxes_0.BackColor = System.Drawing.SystemColors.Control;
            this.lblWorldExtAxes_0.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblWorldExtAxes_0, "lblWorldExtAxes_0");
            this.lblWorldExtAxes_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblWorldExtAxes_0.Name = "lblWorldExtAxes_0";
            // 
            // lblWorldExtAxes_1
            // 
            this.lblWorldExtAxes_1.BackColor = System.Drawing.SystemColors.Control;
            this.lblWorldExtAxes_1.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblWorldExtAxes_1, "lblWorldExtAxes_1");
            this.lblWorldExtAxes_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblWorldExtAxes_1.Name = "lblWorldExtAxes_1";
            // 
            // lblWorldExtAxes_2
            // 
            this.lblWorldExtAxes_2.BackColor = System.Drawing.SystemColors.Control;
            this.lblWorldExtAxes_2.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblWorldExtAxes_2, "lblWorldExtAxes_2");
            this.lblWorldExtAxes_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblWorldExtAxes_2.Name = "lblWorldExtAxes_2";
            // 
            // txtWorld_0
            // 
            this.txtWorld_0.AcceptsReturn = true;
            this.txtWorld_0.BackColor = System.Drawing.SystemColors.Window;
            this.txtWorld_0.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtWorld_0, "txtWorld_0");
            this.txtWorld_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtWorld_0.Name = "txtWorld_0";
            // 
            // txtWorld_1
            // 
            this.txtWorld_1.AcceptsReturn = true;
            this.txtWorld_1.BackColor = System.Drawing.SystemColors.Window;
            this.txtWorld_1.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtWorld_1, "txtWorld_1");
            this.txtWorld_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtWorld_1.Name = "txtWorld_1";
            // 
            // txtWorld_2
            // 
            this.txtWorld_2.AcceptsReturn = true;
            this.txtWorld_2.BackColor = System.Drawing.SystemColors.Window;
            this.txtWorld_2.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtWorld_2, "txtWorld_2");
            this.txtWorld_2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtWorld_2.Name = "txtWorld_2";
            // 
            // txtWorld_3
            // 
            this.txtWorld_3.AcceptsReturn = true;
            this.txtWorld_3.BackColor = System.Drawing.SystemColors.Window;
            this.txtWorld_3.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtWorld_3, "txtWorld_3");
            this.txtWorld_3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtWorld_3.Name = "txtWorld_3";
            // 
            // txtWorld_4
            // 
            this.txtWorld_4.AcceptsReturn = true;
            this.txtWorld_4.BackColor = System.Drawing.SystemColors.Window;
            this.txtWorld_4.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtWorld_4, "txtWorld_4");
            this.txtWorld_4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtWorld_4.Name = "txtWorld_4";
            // 
            // txtWorld_5
            // 
            this.txtWorld_5.AcceptsReturn = true;
            this.txtWorld_5.BackColor = System.Drawing.SystemColors.Window;
            this.txtWorld_5.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtWorld_5, "txtWorld_5");
            this.txtWorld_5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtWorld_5.Name = "txtWorld_5";
            // 
            // txtWorldExtAxes_0
            // 
            this.txtWorldExtAxes_0.AcceptsReturn = true;
            this.txtWorldExtAxes_0.BackColor = System.Drawing.SystemColors.Window;
            this.txtWorldExtAxes_0.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtWorldExtAxes_0, "txtWorldExtAxes_0");
            this.txtWorldExtAxes_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtWorldExtAxes_0.Name = "txtWorldExtAxes_0";
            // 
            // txtWorldExtAxes_1
            // 
            this.txtWorldExtAxes_1.AcceptsReturn = true;
            this.txtWorldExtAxes_1.BackColor = System.Drawing.SystemColors.Window;
            this.txtWorldExtAxes_1.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtWorldExtAxes_1, "txtWorldExtAxes_1");
            this.txtWorldExtAxes_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtWorldExtAxes_1.Name = "txtWorldExtAxes_1";
            // 
            // txtWorldExtAxes_2
            // 
            this.txtWorldExtAxes_2.AcceptsReturn = true;
            this.txtWorldExtAxes_2.BackColor = System.Drawing.SystemColors.Window;
            this.txtWorldExtAxes_2.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtWorldExtAxes_2, "txtWorldExtAxes_2");
            this.txtWorldExtAxes_2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtWorldExtAxes_2.Name = "txtWorldExtAxes_2";
            // 
            // UserTab
            // 
            this.UserTab.Controls.Add(this.lblUser_0);
            this.UserTab.Controls.Add(this.lblUser_1);
            this.UserTab.Controls.Add(this.lblUser_2);
            this.UserTab.Controls.Add(this.lblUser_3);
            this.UserTab.Controls.Add(this.lblUser_4);
            this.UserTab.Controls.Add(this.lblUser_5);
            this.UserTab.Controls.Add(this.lblUserExtAxes_0);
            this.UserTab.Controls.Add(this.lblUserExtAxes_1);
            this.UserTab.Controls.Add(this.lblUserExtAxes_2);
            this.UserTab.Controls.Add(this.txtUser_0);
            this.UserTab.Controls.Add(this.txtUser_1);
            this.UserTab.Controls.Add(this.txtUser_2);
            this.UserTab.Controls.Add(this.txtUser_3);
            this.UserTab.Controls.Add(this.txtUser_4);
            this.UserTab.Controls.Add(this.txtUser_5);
            this.UserTab.Controls.Add(this.txtUserExtAxes_0);
            this.UserTab.Controls.Add(this.txtUserExtAxes_1);
            this.UserTab.Controls.Add(this.txtUserExtAxes_2);
            resources.ApplyResources(this.UserTab, "UserTab");
            this.UserTab.Name = "UserTab";
            // 
            // lblUser_0
            // 
            this.lblUser_0.BackColor = System.Drawing.SystemColors.Control;
            this.lblUser_0.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblUser_0, "lblUser_0");
            this.lblUser_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUser_0.Name = "lblUser_0";
            // 
            // lblUser_1
            // 
            this.lblUser_1.BackColor = System.Drawing.SystemColors.Control;
            this.lblUser_1.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblUser_1, "lblUser_1");
            this.lblUser_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUser_1.Name = "lblUser_1";
            // 
            // lblUser_2
            // 
            this.lblUser_2.BackColor = System.Drawing.SystemColors.Control;
            this.lblUser_2.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblUser_2, "lblUser_2");
            this.lblUser_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUser_2.Name = "lblUser_2";
            // 
            // lblUser_3
            // 
            this.lblUser_3.BackColor = System.Drawing.SystemColors.Control;
            this.lblUser_3.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblUser_3, "lblUser_3");
            this.lblUser_3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUser_3.Name = "lblUser_3";
            // 
            // lblUser_4
            // 
            this.lblUser_4.BackColor = System.Drawing.SystemColors.Control;
            this.lblUser_4.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblUser_4, "lblUser_4");
            this.lblUser_4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUser_4.Name = "lblUser_4";
            // 
            // lblUser_5
            // 
            this.lblUser_5.BackColor = System.Drawing.SystemColors.Control;
            this.lblUser_5.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblUser_5, "lblUser_5");
            this.lblUser_5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUser_5.Name = "lblUser_5";
            // 
            // lblUserExtAxes_0
            // 
            this.lblUserExtAxes_0.BackColor = System.Drawing.SystemColors.Control;
            this.lblUserExtAxes_0.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblUserExtAxes_0, "lblUserExtAxes_0");
            this.lblUserExtAxes_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUserExtAxes_0.Name = "lblUserExtAxes_0";
            // 
            // lblUserExtAxes_1
            // 
            this.lblUserExtAxes_1.BackColor = System.Drawing.SystemColors.Control;
            this.lblUserExtAxes_1.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblUserExtAxes_1, "lblUserExtAxes_1");
            this.lblUserExtAxes_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUserExtAxes_1.Name = "lblUserExtAxes_1";
            // 
            // lblUserExtAxes_2
            // 
            this.lblUserExtAxes_2.BackColor = System.Drawing.SystemColors.Control;
            this.lblUserExtAxes_2.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblUserExtAxes_2, "lblUserExtAxes_2");
            this.lblUserExtAxes_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUserExtAxes_2.Name = "lblUserExtAxes_2";
            // 
            // txtUser_0
            // 
            this.txtUser_0.AcceptsReturn = true;
            this.txtUser_0.BackColor = System.Drawing.SystemColors.Window;
            this.txtUser_0.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtUser_0, "txtUser_0");
            this.txtUser_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUser_0.Name = "txtUser_0";
            // 
            // txtUser_1
            // 
            this.txtUser_1.AcceptsReturn = true;
            this.txtUser_1.BackColor = System.Drawing.SystemColors.Window;
            this.txtUser_1.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtUser_1, "txtUser_1");
            this.txtUser_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUser_1.Name = "txtUser_1";
            // 
            // txtUser_2
            // 
            this.txtUser_2.AcceptsReturn = true;
            this.txtUser_2.BackColor = System.Drawing.SystemColors.Window;
            this.txtUser_2.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtUser_2, "txtUser_2");
            this.txtUser_2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUser_2.Name = "txtUser_2";
            // 
            // txtUser_3
            // 
            this.txtUser_3.AcceptsReturn = true;
            this.txtUser_3.BackColor = System.Drawing.SystemColors.Window;
            this.txtUser_3.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtUser_3, "txtUser_3");
            this.txtUser_3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUser_3.Name = "txtUser_3";
            // 
            // txtUser_4
            // 
            this.txtUser_4.AcceptsReturn = true;
            this.txtUser_4.BackColor = System.Drawing.SystemColors.Window;
            this.txtUser_4.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtUser_4, "txtUser_4");
            this.txtUser_4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUser_4.Name = "txtUser_4";
            // 
            // txtUser_5
            // 
            this.txtUser_5.AcceptsReturn = true;
            this.txtUser_5.BackColor = System.Drawing.SystemColors.Window;
            this.txtUser_5.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtUser_5, "txtUser_5");
            this.txtUser_5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUser_5.Name = "txtUser_5";
            // 
            // txtUserExtAxes_0
            // 
            this.txtUserExtAxes_0.AcceptsReturn = true;
            this.txtUserExtAxes_0.BackColor = System.Drawing.SystemColors.Window;
            this.txtUserExtAxes_0.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtUserExtAxes_0, "txtUserExtAxes_0");
            this.txtUserExtAxes_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUserExtAxes_0.Name = "txtUserExtAxes_0";
            // 
            // txtUserExtAxes_1
            // 
            this.txtUserExtAxes_1.AcceptsReturn = true;
            this.txtUserExtAxes_1.BackColor = System.Drawing.SystemColors.Window;
            this.txtUserExtAxes_1.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtUserExtAxes_1, "txtUserExtAxes_1");
            this.txtUserExtAxes_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUserExtAxes_1.Name = "txtUserExtAxes_1";
            // 
            // txtUserExtAxes_2
            // 
            this.txtUserExtAxes_2.AcceptsReturn = true;
            this.txtUserExtAxes_2.BackColor = System.Drawing.SystemColors.Window;
            this.txtUserExtAxes_2.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtUserExtAxes_2, "txtUserExtAxes_2");
            this.txtUserExtAxes_2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUserExtAxes_2.Name = "txtUserExtAxes_2";
            // 
            // cmdSetCurPosAsCopySource
            // 
            this.cmdSetCurPosAsCopySource.BackColor = System.Drawing.SystemColors.Control;
            this.cmdSetCurPosAsCopySource.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.cmdSetCurPosAsCopySource, "cmdSetCurPosAsCopySource");
            this.cmdSetCurPosAsCopySource.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdSetCurPosAsCopySource.Name = "cmdSetCurPosAsCopySource";
            this.cmdSetCurPosAsCopySource.UseVisualStyleBackColor = false;
            this.cmdSetCurPosAsCopySource.Click += new System.EventHandler(this.cmdSetCurPosAsCopySource_Click);
            // 
            // cmdSetCurGrpPosAsCopySource
            // 
            this.cmdSetCurGrpPosAsCopySource.BackColor = System.Drawing.SystemColors.Control;
            this.cmdSetCurGrpPosAsCopySource.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.cmdSetCurGrpPosAsCopySource, "cmdSetCurGrpPosAsCopySource");
            this.cmdSetCurGrpPosAsCopySource.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdSetCurGrpPosAsCopySource.Name = "cmdSetCurGrpPosAsCopySource";
            this.cmdSetCurGrpPosAsCopySource.UseVisualStyleBackColor = false;
            this.cmdSetCurGrpPosAsCopySource.Click += new System.EventHandler(this.cmdSetCurGrpPosAsCopySource_Click);
            // 
            // Label1
            // 
            resources.ApplyResources(this.Label1, "Label1");
            this.Label1.Name = "Label1";
            // 
            // cboGroupSel
            // 
            this.cboGroupSel.FormattingEnabled = true;
            resources.ApplyResources(this.cboGroupSel, "cboGroupSel");
            this.cboGroupSel.Name = "cboGroupSel";
            this.cboGroupSel.SelectedIndexChanged += new System.EventHandler(this.cboGroupSel_SelectedIndexChanged);
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
            // lblUpdate
            // 
            this.lblUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.lblUpdate.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblUpdate, "lblUpdate");
            this.lblUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUpdate.Name = "lblUpdate";
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
            // tmrUpdateDisplay
            // 
            this.tmrUpdateDisplay.Tick += new System.EventHandler(this.tmrUpdateDisplay_Tick);
            // 
            // tmrBlinkUpdate
            // 
            this.tmrBlinkUpdate.Interval = 300;
            this.tmrBlinkUpdate.Tick += new System.EventHandler(this.tmrBlinkUpdate_Tick);
            // 
            // frmCurPos
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpMonitor);
            this.Controls.Add(this.cboGroupSel);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.cmdSetCurPosAsCopySource);
            this.Controls.Add(this.cmdSetCurGrpPosAsCopySource);
            this.Controls.Add(this.tabsCurPos);
            this.Name = "frmCurPos";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCurPos_FormClosing);
            this.Load += new System.EventHandler(this.frmCurPos_Load);
            this.tabsCurPos.ResumeLayout(false);
            this.JointTab.ResumeLayout(false);
            this.JointTab.PerformLayout();
            this.WorldTab.ResumeLayout(false);
            this.WorldTab.PerformLayout();
            this.UserTab.ResumeLayout(false);
            this.UserTab.PerformLayout();
            this.grpMonitor.ResumeLayout(false);
            this.grpMonitor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMonitor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        public System.Windows.Forms.TabControl tabsCurPos;
        public System.Windows.Forms.TabPage JointTab;
        public System.Windows.Forms.Label lblJointNum_0;
        public System.Windows.Forms.Label lblJointNum_1;
        public System.Windows.Forms.Label lblJointNum_2;
        public System.Windows.Forms.Label lblJointNum_3;
        public System.Windows.Forms.Label lblJointNum_4;
        public System.Windows.Forms.Label lblJointNum_5;
        public System.Windows.Forms.Label lblJointNum_6;
        public System.Windows.Forms.Label lblJointNum_7;
        public System.Windows.Forms.Label lblJointNum_8;
        public System.Windows.Forms.TextBox txtJoint_0;
        public System.Windows.Forms.TextBox txtJoint_1;
        public System.Windows.Forms.TextBox txtJoint_2;
        public System.Windows.Forms.TextBox txtJoint_3;
        public System.Windows.Forms.TextBox txtJoint_4;
        public System.Windows.Forms.TextBox txtJoint_5;
        public System.Windows.Forms.TextBox txtJoint_6;
        public System.Windows.Forms.TextBox txtJoint_7;
        public System.Windows.Forms.TextBox txtJoint_8;
        public System.Windows.Forms.TabPage WorldTab;
        public System.Windows.Forms.Label _lblWrdCurPos_0;
        public System.Windows.Forms.Label _lblWrdCurPos_1;
        public System.Windows.Forms.Label _lblWrdCurPos_2;
        public System.Windows.Forms.Label _lblWrdCurPos_3;
        public System.Windows.Forms.Label _lblWrdCurPos_4;
        public System.Windows.Forms.Label _lblWrdCurPos_5;
        public System.Windows.Forms.Label lblWorldExtAxes_0;
        public System.Windows.Forms.Label lblWorldExtAxes_1;
        public System.Windows.Forms.Label lblWorldExtAxes_2;
        public System.Windows.Forms.TextBox txtWorld_0;
        public System.Windows.Forms.TextBox txtWorld_1;
        public System.Windows.Forms.TextBox txtWorld_2;
        public System.Windows.Forms.TextBox txtWorld_3;
        public System.Windows.Forms.TextBox txtWorld_4;
        public System.Windows.Forms.TextBox txtWorld_5;
        public System.Windows.Forms.TextBox txtWorldExtAxes_0;
        public System.Windows.Forms.TextBox txtWorldExtAxes_1;
        public System.Windows.Forms.TextBox txtWorldExtAxes_2;
        public System.Windows.Forms.TabPage UserTab;
        public System.Windows.Forms.Label lblUser_0;
        public System.Windows.Forms.Label lblUser_1;
        public System.Windows.Forms.Label lblUser_2;
        public System.Windows.Forms.Label lblUser_3;
        public System.Windows.Forms.Label lblUser_4;
        public System.Windows.Forms.Label lblUser_5;
        public System.Windows.Forms.Label lblUserExtAxes_0;
        public System.Windows.Forms.Label lblUserExtAxes_1;
        public System.Windows.Forms.Label lblUserExtAxes_2;
        public System.Windows.Forms.TextBox txtUser_0;
        public System.Windows.Forms.TextBox txtUser_1;
        public System.Windows.Forms.TextBox txtUser_2;
        public System.Windows.Forms.TextBox txtUser_3;
        public System.Windows.Forms.TextBox txtUser_4;
        public System.Windows.Forms.TextBox txtUser_5;
        public System.Windows.Forms.TextBox txtUserExtAxes_0;
        public System.Windows.Forms.TextBox txtUserExtAxes_1;
        public System.Windows.Forms.TextBox txtUserExtAxes_2;
        public System.Windows.Forms.Button cmdSetCurPosAsCopySource;
        public System.Windows.Forms.Button cmdSetCurGrpPosAsCopySource;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ComboBox cboGroupSel;
        internal System.Windows.Forms.GroupBox grpMonitor;
        public System.Windows.Forms.Button cmdStartMon;
        public System.Windows.Forms.PictureBox picUpdate;
        public System.Windows.Forms.PictureBox picMonitor;
        public System.Windows.Forms.Label lblUpdate;
        public System.Windows.Forms.Button cmdStopMon;
        public System.Windows.Forms.TextBox txtLatency;
        public System.Windows.Forms.Label lblMonitor;
        public System.Windows.Forms.Label lblLatency;
        internal System.Windows.Forms.Timer tmrUpdateDisplay;
        internal System.Windows.Forms.Timer tmrBlinkUpdate;
    }
}