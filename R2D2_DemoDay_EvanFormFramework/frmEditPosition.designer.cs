namespace FRRobotDemoCSharp
{
    partial class frmEditPosition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditPosition));
            this.cmdSetAsCopySource = new System.Windows.Forms.Button();
            this.cmdCopyFromSource = new System.Windows.Forms.Button();
            this.cmdIsReachable = new System.Windows.Forms.Button();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.cmdUninit = new System.Windows.Forms.Button();
            this.cmdRecord = new System.Windows.Forms.Button();
            this.cmdMoveto = new System.Windows.Forms.Button();
            this.cmdInv = new System.Windows.Forms.Button();
            this.txtToolNum = new System.Windows.Forms.TextBox();
            this.txtFrameNum = new System.Windows.Forms.TextBox();
            this.Frame1 = new System.Windows.Forms.GroupBox();
            this.optJoint = new System.Windows.Forms.RadioButton();
            this.optXyzWpr = new System.Windows.Forms.RadioButton();
            this.optTransform = new System.Windows.Forms.RadioButton();
            this.lblWithExtAxes = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.lblFrameNum = new System.Windows.Forms.Label();
            this.lblToolNum = new System.Windows.Forms.Label();
            this.lblComment = new System.Windows.Forms.Label();
            this.tabPos = new System.Windows.Forms.TabControl();
            this.TransformTab = new System.Windows.Forms.TabPage();
            this._lblStatic_0 = new System.Windows.Forms.Label();
            this._lblStatic_1 = new System.Windows.Forms.Label();
            this._lblStatic_2 = new System.Windows.Forms.Label();
            this._lblStatic_3 = new System.Windows.Forms.Label();
            this._lblStatic_5 = new System.Windows.Forms.Label();
            this.txtN_0 = new System.Windows.Forms.TextBox();
            this.txtN_1 = new System.Windows.Forms.TextBox();
            this.txtN_2 = new System.Windows.Forms.TextBox();
            this.txtO_0 = new System.Windows.Forms.TextBox();
            this.txtO_1 = new System.Windows.Forms.TextBox();
            this.txtO_2 = new System.Windows.Forms.TextBox();
            this.txtA_0 = new System.Windows.Forms.TextBox();
            this.txtA_1 = new System.Windows.Forms.TextBox();
            this.txtA_2 = new System.Windows.Forms.TextBox();
            this.txtL_0 = new System.Windows.Forms.TextBox();
            this.txtL_1 = new System.Windows.Forms.TextBox();
            this.txtL_2 = new System.Windows.Forms.TextBox();
            this.txtTransConfig = new System.Windows.Forms.TextBox();
            this.frmTransExtAxes = new System.Windows.Forms.GroupBox();
            this.txtTransExtAxes_8 = new System.Windows.Forms.TextBox();
            this.txtTransExtAxes_7 = new System.Windows.Forms.TextBox();
            this.txtTransExtAxes_6 = new System.Windows.Forms.TextBox();
            this.txtTransExtAxes_5 = new System.Windows.Forms.TextBox();
            this.txtTransExtAxes_4 = new System.Windows.Forms.TextBox();
            this.txtTransExtAxes_3 = new System.Windows.Forms.TextBox();
            this.txtTransExtAxes_2 = new System.Windows.Forms.TextBox();
            this.txtTransExtAxes_1 = new System.Windows.Forms.TextBox();
            this.txtTransExtAxes_0 = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.XyzWprTab = new System.Windows.Forms.TabPage();
            this._lblStatic_6 = new System.Windows.Forms.Label();
            this._lblStatic_7 = new System.Windows.Forms.Label();
            this._lblStatic_8 = new System.Windows.Forms.Label();
            this._lblStatic_9 = new System.Windows.Forms.Label();
            this._lblStatic_10 = new System.Windows.Forms.Label();
            this._lblStatic_11 = new System.Windows.Forms.Label();
            this._lblStatic_25 = new System.Windows.Forms.Label();
            this.txtXyzWprConfig = new System.Windows.Forms.TextBox();
            this.txtXyzWpr_0 = new System.Windows.Forms.TextBox();
            this.txtXyzWpr_1 = new System.Windows.Forms.TextBox();
            this.txtXyzWpr_2 = new System.Windows.Forms.TextBox();
            this.txtXyzWpr_3 = new System.Windows.Forms.TextBox();
            this.txtXyzWpr_4 = new System.Windows.Forms.TextBox();
            this.txtXyzWpr_5 = new System.Windows.Forms.TextBox();
            this.frmExtAxis = new System.Windows.Forms.GroupBox();
            this.txtXyzExtAxes_8 = new System.Windows.Forms.TextBox();
            this.txtXyzExtAxes_7 = new System.Windows.Forms.TextBox();
            this.txtXyzExtAxes_6 = new System.Windows.Forms.TextBox();
            this.txtXyzExtAxes_0 = new System.Windows.Forms.TextBox();
            this.txtXyzExtAxes_1 = new System.Windows.Forms.TextBox();
            this.txtXyzExtAxes_2 = new System.Windows.Forms.TextBox();
            this.txtXyzExtAxes_3 = new System.Windows.Forms.TextBox();
            this.txtXyzExtAxes_4 = new System.Windows.Forms.TextBox();
            this.txtXyzExtAxes_5 = new System.Windows.Forms.TextBox();
            this.lblnone = new System.Windows.Forms.Label();
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
            this.lblJointNotValid = new System.Windows.Forms.Label();
            this.cmdOk = new System.Windows.Forms.Button();
            this.Frame1.SuspendLayout();
            this.tabPos.SuspendLayout();
            this.TransformTab.SuspendLayout();
            this.frmTransExtAxes.SuspendLayout();
            this.XyzWprTab.SuspendLayout();
            this.frmExtAxis.SuspendLayout();
            this.JointTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdSetAsCopySource
            // 
            this.cmdSetAsCopySource.BackColor = System.Drawing.SystemColors.Control;
            this.cmdSetAsCopySource.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.cmdSetAsCopySource, "cmdSetAsCopySource");
            this.cmdSetAsCopySource.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdSetAsCopySource.Name = "cmdSetAsCopySource";
            this.cmdSetAsCopySource.UseVisualStyleBackColor = false;
            this.cmdSetAsCopySource.Click += new System.EventHandler(this.cmdSetAsCopySource_Click);
            // 
            // cmdCopyFromSource
            // 
            this.cmdCopyFromSource.BackColor = System.Drawing.SystemColors.Control;
            this.cmdCopyFromSource.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.cmdCopyFromSource, "cmdCopyFromSource");
            this.cmdCopyFromSource.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdCopyFromSource.Name = "cmdCopyFromSource";
            this.cmdCopyFromSource.UseVisualStyleBackColor = false;
            this.cmdCopyFromSource.Click += new System.EventHandler(this.cmdCopyFromSource_Click);
            // 
            // cmdIsReachable
            // 
            this.cmdIsReachable.BackColor = System.Drawing.SystemColors.Control;
            this.cmdIsReachable.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.cmdIsReachable, "cmdIsReachable");
            this.cmdIsReachable.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdIsReachable.Name = "cmdIsReachable";
            this.cmdIsReachable.UseVisualStyleBackColor = false;
            this.cmdIsReachable.Click += new System.EventHandler(this.cmdIsReachable_Click);
            this.cmdIsReachable.Leave += new System.EventHandler(this.cmdIsReachable_Leave);
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
            // txtId
            // 
            this.txtId.AcceptsReturn = true;
            this.txtId.BackColor = System.Drawing.SystemColors.Window;
            this.txtId.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtId, "txtId");
            this.txtId.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtId.Name = "txtId";
            // 
            // cmdUninit
            // 
            this.cmdUninit.BackColor = System.Drawing.SystemColors.Control;
            this.cmdUninit.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.cmdUninit, "cmdUninit");
            this.cmdUninit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdUninit.Name = "cmdUninit";
            this.cmdUninit.UseVisualStyleBackColor = false;
            this.cmdUninit.Click += new System.EventHandler(this.cmdUninit_Click);
            // 
            // cmdRecord
            // 
            this.cmdRecord.BackColor = System.Drawing.SystemColors.Control;
            this.cmdRecord.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.cmdRecord, "cmdRecord");
            this.cmdRecord.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdRecord.Name = "cmdRecord";
            this.cmdRecord.UseVisualStyleBackColor = false;
            this.cmdRecord.Click += new System.EventHandler(this.cmdRecord_Click);
            // 
            // cmdMoveto
            // 
            this.cmdMoveto.BackColor = System.Drawing.SystemColors.Control;
            this.cmdMoveto.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.cmdMoveto, "cmdMoveto");
            this.cmdMoveto.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdMoveto.Name = "cmdMoveto";
            this.cmdMoveto.UseVisualStyleBackColor = false;
            this.cmdMoveto.Click += new System.EventHandler(this.cmdmoveto_Click);
            // 
            // cmdInv
            // 
            this.cmdInv.BackColor = System.Drawing.SystemColors.Control;
            this.cmdInv.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.cmdInv, "cmdInv");
            this.cmdInv.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdInv.Name = "cmdInv";
            this.cmdInv.UseVisualStyleBackColor = false;
            this.cmdInv.Click += new System.EventHandler(this.cmdInv_Click);
            // 
            // txtToolNum
            // 
            this.txtToolNum.AcceptsReturn = true;
            this.txtToolNum.BackColor = System.Drawing.SystemColors.Window;
            this.txtToolNum.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtToolNum, "txtToolNum");
            this.txtToolNum.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtToolNum.Name = "txtToolNum";
            this.txtToolNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtToolNum_KeyPress);
            this.txtToolNum.Leave += new System.EventHandler(this.txtFrameNum_Leave);
            // 
            // txtFrameNum
            // 
            this.txtFrameNum.AcceptsReturn = true;
            this.txtFrameNum.BackColor = System.Drawing.SystemColors.Window;
            this.txtFrameNum.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtFrameNum, "txtFrameNum");
            this.txtFrameNum.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFrameNum.Name = "txtFrameNum";
            this.txtFrameNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFrameNum_KeyPress);
            this.txtFrameNum.Leave += new System.EventHandler(this.txtFrameNum_Leave);
            // 
            // Frame1
            // 
            this.Frame1.BackColor = System.Drawing.SystemColors.Control;
            this.Frame1.Controls.Add(this.optJoint);
            this.Frame1.Controls.Add(this.optXyzWpr);
            this.Frame1.Controls.Add(this.optTransform);
            this.Frame1.Controls.Add(this.lblWithExtAxes);
            resources.ApplyResources(this.Frame1, "Frame1");
            this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Frame1.Name = "Frame1";
            this.Frame1.TabStop = false;
            // 
            // optJoint
            // 
            this.optJoint.BackColor = System.Drawing.SystemColors.Control;
            this.optJoint.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.optJoint, "optJoint");
            this.optJoint.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optJoint.Name = "optJoint";
            this.optJoint.TabStop = true;
            this.optJoint.UseVisualStyleBackColor = false;
            this.optJoint.CheckedChanged += new System.EventHandler(this.optJoint_CheckedChanged);
            // 
            // optXyzWpr
            // 
            this.optXyzWpr.BackColor = System.Drawing.SystemColors.Control;
            this.optXyzWpr.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.optXyzWpr, "optXyzWpr");
            this.optXyzWpr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optXyzWpr.Name = "optXyzWpr";
            this.optXyzWpr.TabStop = true;
            this.optXyzWpr.UseVisualStyleBackColor = false;
            this.optXyzWpr.CheckedChanged += new System.EventHandler(this.optXyzWpr_CheckedChanged);
            // 
            // optTransform
            // 
            this.optTransform.BackColor = System.Drawing.SystemColors.Control;
            this.optTransform.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.optTransform, "optTransform");
            this.optTransform.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optTransform.Name = "optTransform";
            this.optTransform.TabStop = true;
            this.optTransform.UseVisualStyleBackColor = false;
            this.optTransform.CheckedChanged += new System.EventHandler(this.optTransform_CheckedChanged);
            // 
            // lblWithExtAxes
            // 
            this.lblWithExtAxes.BackColor = System.Drawing.SystemColors.Control;
            this.lblWithExtAxes.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblWithExtAxes, "lblWithExtAxes");
            this.lblWithExtAxes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblWithExtAxes.Name = "lblWithExtAxes";
            // 
            // txtComment
            // 
            this.txtComment.AcceptsReturn = true;
            this.txtComment.BackColor = System.Drawing.SystemColors.Window;
            this.txtComment.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtComment, "txtComment");
            this.txtComment.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtComment.Name = "txtComment";
            this.txtComment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtComment_KeyPress);
            this.txtComment.Leave += new System.EventHandler(this.txtComment_Leave);
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.SystemColors.Control;
            this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.Label2, "Label2");
            this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label2.Name = "Label2";
            // 
            // lblFrameNum
            // 
            this.lblFrameNum.BackColor = System.Drawing.SystemColors.Control;
            this.lblFrameNum.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblFrameNum, "lblFrameNum");
            this.lblFrameNum.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFrameNum.Name = "lblFrameNum";
            // 
            // lblToolNum
            // 
            this.lblToolNum.BackColor = System.Drawing.SystemColors.Control;
            this.lblToolNum.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblToolNum, "lblToolNum");
            this.lblToolNum.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblToolNum.Name = "lblToolNum";
            // 
            // lblComment
            // 
            this.lblComment.BackColor = System.Drawing.SystemColors.Control;
            this.lblComment.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblComment, "lblComment");
            this.lblComment.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblComment.Name = "lblComment";
            // 
            // tabPos
            // 
            this.tabPos.Controls.Add(this.TransformTab);
            this.tabPos.Controls.Add(this.XyzWprTab);
            this.tabPos.Controls.Add(this.JointTab);
            resources.ApplyResources(this.tabPos, "tabPos");
            this.tabPos.Name = "tabPos";
            this.tabPos.SelectedIndex = 2;
            this.tabPos.SelectedIndexChanged += new System.EventHandler(this.tabPos_SelectedIndexChanged);
            // 
            // TransformTab
            // 
            this.TransformTab.Controls.Add(this._lblStatic_0);
            this.TransformTab.Controls.Add(this._lblStatic_1);
            this.TransformTab.Controls.Add(this._lblStatic_2);
            this.TransformTab.Controls.Add(this._lblStatic_3);
            this.TransformTab.Controls.Add(this._lblStatic_5);
            this.TransformTab.Controls.Add(this.txtN_0);
            this.TransformTab.Controls.Add(this.txtN_1);
            this.TransformTab.Controls.Add(this.txtN_2);
            this.TransformTab.Controls.Add(this.txtO_0);
            this.TransformTab.Controls.Add(this.txtO_1);
            this.TransformTab.Controls.Add(this.txtO_2);
            this.TransformTab.Controls.Add(this.txtA_0);
            this.TransformTab.Controls.Add(this.txtA_1);
            this.TransformTab.Controls.Add(this.txtA_2);
            this.TransformTab.Controls.Add(this.txtL_0);
            this.TransformTab.Controls.Add(this.txtL_1);
            this.TransformTab.Controls.Add(this.txtL_2);
            this.TransformTab.Controls.Add(this.txtTransConfig);
            this.TransformTab.Controls.Add(this.frmTransExtAxes);
            resources.ApplyResources(this.TransformTab, "TransformTab");
            this.TransformTab.Name = "TransformTab";
            // 
            // _lblStatic_0
            // 
            this._lblStatic_0.BackColor = System.Drawing.SystemColors.Control;
            this._lblStatic_0.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this._lblStatic_0, "_lblStatic_0");
            this._lblStatic_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblStatic_0.Name = "_lblStatic_0";
            // 
            // _lblStatic_1
            // 
            this._lblStatic_1.BackColor = System.Drawing.SystemColors.Control;
            this._lblStatic_1.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this._lblStatic_1, "_lblStatic_1");
            this._lblStatic_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblStatic_1.Name = "_lblStatic_1";
            // 
            // _lblStatic_2
            // 
            this._lblStatic_2.BackColor = System.Drawing.SystemColors.Control;
            this._lblStatic_2.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this._lblStatic_2, "_lblStatic_2");
            this._lblStatic_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblStatic_2.Name = "_lblStatic_2";
            // 
            // _lblStatic_3
            // 
            this._lblStatic_3.BackColor = System.Drawing.SystemColors.Control;
            this._lblStatic_3.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this._lblStatic_3, "_lblStatic_3");
            this._lblStatic_3.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblStatic_3.Name = "_lblStatic_3";
            // 
            // _lblStatic_5
            // 
            this._lblStatic_5.BackColor = System.Drawing.SystemColors.Control;
            this._lblStatic_5.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this._lblStatic_5, "_lblStatic_5");
            this._lblStatic_5.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblStatic_5.Name = "_lblStatic_5";
            // 
            // txtN_0
            // 
            this.txtN_0.AcceptsReturn = true;
            this.txtN_0.BackColor = System.Drawing.SystemColors.Window;
            this.txtN_0.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtN_0, "txtN_0");
            this.txtN_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtN_0.Name = "txtN_0";
            // 
            // txtN_1
            // 
            this.txtN_1.AcceptsReturn = true;
            this.txtN_1.BackColor = System.Drawing.SystemColors.Window;
            this.txtN_1.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtN_1, "txtN_1");
            this.txtN_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtN_1.Name = "txtN_1";
            // 
            // txtN_2
            // 
            this.txtN_2.AcceptsReturn = true;
            this.txtN_2.BackColor = System.Drawing.SystemColors.Window;
            this.txtN_2.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtN_2, "txtN_2");
            this.txtN_2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtN_2.Name = "txtN_2";
            // 
            // txtO_0
            // 
            this.txtO_0.AcceptsReturn = true;
            this.txtO_0.BackColor = System.Drawing.SystemColors.Window;
            this.txtO_0.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtO_0, "txtO_0");
            this.txtO_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtO_0.Name = "txtO_0";
            // 
            // txtO_1
            // 
            this.txtO_1.AcceptsReturn = true;
            this.txtO_1.BackColor = System.Drawing.SystemColors.Window;
            this.txtO_1.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtO_1, "txtO_1");
            this.txtO_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtO_1.Name = "txtO_1";
            // 
            // txtO_2
            // 
            this.txtO_2.AcceptsReturn = true;
            this.txtO_2.BackColor = System.Drawing.SystemColors.Window;
            this.txtO_2.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtO_2, "txtO_2");
            this.txtO_2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtO_2.Name = "txtO_2";
            // 
            // txtA_0
            // 
            this.txtA_0.AcceptsReturn = true;
            this.txtA_0.BackColor = System.Drawing.SystemColors.Window;
            this.txtA_0.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtA_0, "txtA_0");
            this.txtA_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtA_0.Name = "txtA_0";
            // 
            // txtA_1
            // 
            this.txtA_1.AcceptsReturn = true;
            this.txtA_1.BackColor = System.Drawing.SystemColors.Window;
            this.txtA_1.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtA_1, "txtA_1");
            this.txtA_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtA_1.Name = "txtA_1";
            // 
            // txtA_2
            // 
            this.txtA_2.AcceptsReturn = true;
            this.txtA_2.BackColor = System.Drawing.SystemColors.Window;
            this.txtA_2.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtA_2, "txtA_2");
            this.txtA_2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtA_2.Name = "txtA_2";
            // 
            // txtL_0
            // 
            this.txtL_0.AcceptsReturn = true;
            this.txtL_0.BackColor = System.Drawing.SystemColors.Window;
            this.txtL_0.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtL_0, "txtL_0");
            this.txtL_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtL_0.Name = "txtL_0";
            this.txtL_0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtL_0_KeyPress);
            this.txtL_0.Leave += new System.EventHandler(this.txtL_0_Leave);
            // 
            // txtL_1
            // 
            this.txtL_1.AcceptsReturn = true;
            this.txtL_1.BackColor = System.Drawing.SystemColors.Window;
            this.txtL_1.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtL_1, "txtL_1");
            this.txtL_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtL_1.Name = "txtL_1";
            this.txtL_1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtL_1_KeyPress);
            this.txtL_1.Leave += new System.EventHandler(this.txtL_1_Leave);
            // 
            // txtL_2
            // 
            this.txtL_2.AcceptsReturn = true;
            this.txtL_2.BackColor = System.Drawing.SystemColors.Window;
            this.txtL_2.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtL_2, "txtL_2");
            this.txtL_2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtL_2.Name = "txtL_2";
            this.txtL_2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtL_2_KeyPress);
            this.txtL_2.Leave += new System.EventHandler(this.txtL_2_Leave);
            // 
            // txtTransConfig
            // 
            this.txtTransConfig.AcceptsReturn = true;
            this.txtTransConfig.BackColor = System.Drawing.SystemColors.Window;
            this.txtTransConfig.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtTransConfig, "txtTransConfig");
            this.txtTransConfig.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTransConfig.Name = "txtTransConfig";
            this.txtTransConfig.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTransConfig_KeyPress);
            this.txtTransConfig.Leave += new System.EventHandler(this.txtTransConfig_Leave);
            // 
            // frmTransExtAxes
            // 
            this.frmTransExtAxes.BackColor = System.Drawing.SystemColors.Control;
            this.frmTransExtAxes.Controls.Add(this.txtTransExtAxes_8);
            this.frmTransExtAxes.Controls.Add(this.txtTransExtAxes_7);
            this.frmTransExtAxes.Controls.Add(this.txtTransExtAxes_6);
            this.frmTransExtAxes.Controls.Add(this.txtTransExtAxes_5);
            this.frmTransExtAxes.Controls.Add(this.txtTransExtAxes_4);
            this.frmTransExtAxes.Controls.Add(this.txtTransExtAxes_3);
            this.frmTransExtAxes.Controls.Add(this.txtTransExtAxes_2);
            this.frmTransExtAxes.Controls.Add(this.txtTransExtAxes_1);
            this.frmTransExtAxes.Controls.Add(this.txtTransExtAxes_0);
            this.frmTransExtAxes.Controls.Add(this.Label3);
            resources.ApplyResources(this.frmTransExtAxes, "frmTransExtAxes");
            this.frmTransExtAxes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.frmTransExtAxes.Name = "frmTransExtAxes";
            this.frmTransExtAxes.TabStop = false;
            // 
            // txtTransExtAxes_8
            // 
            this.txtTransExtAxes_8.AcceptsReturn = true;
            this.txtTransExtAxes_8.BackColor = System.Drawing.SystemColors.Window;
            this.txtTransExtAxes_8.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtTransExtAxes_8, "txtTransExtAxes_8");
            this.txtTransExtAxes_8.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTransExtAxes_8.Name = "txtTransExtAxes_8";
            this.txtTransExtAxes_8.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTransExtAxes_8_KeyPress);
            this.txtTransExtAxes_8.Leave += new System.EventHandler(this.txtTransExtAxes_8_Leave);
            // 
            // txtTransExtAxes_7
            // 
            this.txtTransExtAxes_7.AcceptsReturn = true;
            this.txtTransExtAxes_7.BackColor = System.Drawing.SystemColors.Window;
            this.txtTransExtAxes_7.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtTransExtAxes_7, "txtTransExtAxes_7");
            this.txtTransExtAxes_7.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTransExtAxes_7.Name = "txtTransExtAxes_7";
            this.txtTransExtAxes_7.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTransExtAxes_7_KeyPress);
            this.txtTransExtAxes_7.Leave += new System.EventHandler(this.txtTransExtAxes_7_Leave);
            // 
            // txtTransExtAxes_6
            // 
            this.txtTransExtAxes_6.AcceptsReturn = true;
            this.txtTransExtAxes_6.BackColor = System.Drawing.SystemColors.Window;
            this.txtTransExtAxes_6.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtTransExtAxes_6, "txtTransExtAxes_6");
            this.txtTransExtAxes_6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTransExtAxes_6.Name = "txtTransExtAxes_6";
            this.txtTransExtAxes_6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTransExtAxes_6_KeyPress);
            this.txtTransExtAxes_6.Leave += new System.EventHandler(this.txtTransExtAxes_6_Leave);
            // 
            // txtTransExtAxes_5
            // 
            this.txtTransExtAxes_5.AcceptsReturn = true;
            this.txtTransExtAxes_5.BackColor = System.Drawing.SystemColors.Window;
            this.txtTransExtAxes_5.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtTransExtAxes_5, "txtTransExtAxes_5");
            this.txtTransExtAxes_5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTransExtAxes_5.Name = "txtTransExtAxes_5";
            this.txtTransExtAxes_5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTransExtAxes_5_KeyPress);
            this.txtTransExtAxes_5.Leave += new System.EventHandler(this.txtTransExtAxes_5_Leave);
            // 
            // txtTransExtAxes_4
            // 
            this.txtTransExtAxes_4.AcceptsReturn = true;
            this.txtTransExtAxes_4.BackColor = System.Drawing.SystemColors.Window;
            this.txtTransExtAxes_4.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtTransExtAxes_4, "txtTransExtAxes_4");
            this.txtTransExtAxes_4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTransExtAxes_4.Name = "txtTransExtAxes_4";
            this.txtTransExtAxes_4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTransExtAxes_4_KeyPress);
            this.txtTransExtAxes_4.Leave += new System.EventHandler(this.txtTransExtAxes_4_Leave);
            // 
            // txtTransExtAxes_3
            // 
            this.txtTransExtAxes_3.AcceptsReturn = true;
            this.txtTransExtAxes_3.BackColor = System.Drawing.SystemColors.Window;
            this.txtTransExtAxes_3.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtTransExtAxes_3, "txtTransExtAxes_3");
            this.txtTransExtAxes_3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTransExtAxes_3.Name = "txtTransExtAxes_3";
            this.txtTransExtAxes_3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTransExtAxes_3_KeyPress);
            this.txtTransExtAxes_3.Leave += new System.EventHandler(this.txtTransExtAxes_3_Leave);
            // 
            // txtTransExtAxes_2
            // 
            this.txtTransExtAxes_2.AcceptsReturn = true;
            this.txtTransExtAxes_2.BackColor = System.Drawing.SystemColors.Window;
            this.txtTransExtAxes_2.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtTransExtAxes_2, "txtTransExtAxes_2");
            this.txtTransExtAxes_2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTransExtAxes_2.Name = "txtTransExtAxes_2";
            this.txtTransExtAxes_2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTransExtAxes_2_KeyPress);
            this.txtTransExtAxes_2.Leave += new System.EventHandler(this.txtTransExtAxes_2_Leave);
            // 
            // txtTransExtAxes_1
            // 
            this.txtTransExtAxes_1.AcceptsReturn = true;
            this.txtTransExtAxes_1.BackColor = System.Drawing.SystemColors.Window;
            this.txtTransExtAxes_1.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtTransExtAxes_1, "txtTransExtAxes_1");
            this.txtTransExtAxes_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTransExtAxes_1.Name = "txtTransExtAxes_1";
            this.txtTransExtAxes_1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTransExtAxes_1_KeyPress);
            this.txtTransExtAxes_1.Leave += new System.EventHandler(this.txtTransExtAxes_1_Leave);
            // 
            // txtTransExtAxes_0
            // 
            this.txtTransExtAxes_0.AcceptsReturn = true;
            this.txtTransExtAxes_0.BackColor = System.Drawing.SystemColors.Window;
            this.txtTransExtAxes_0.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtTransExtAxes_0, "txtTransExtAxes_0");
            this.txtTransExtAxes_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTransExtAxes_0.Name = "txtTransExtAxes_0";
            this.txtTransExtAxes_0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTransExtAxes_0_KeyPress);
            this.txtTransExtAxes_0.Leave += new System.EventHandler(this.txtTransExtAxes_0_Leave);
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.SystemColors.Control;
            this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.Label3, "Label3");
            this.Label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label3.Name = "Label3";
            // 
            // XyzWprTab
            // 
            this.XyzWprTab.Controls.Add(this._lblStatic_6);
            this.XyzWprTab.Controls.Add(this._lblStatic_7);
            this.XyzWprTab.Controls.Add(this._lblStatic_8);
            this.XyzWprTab.Controls.Add(this._lblStatic_9);
            this.XyzWprTab.Controls.Add(this._lblStatic_10);
            this.XyzWprTab.Controls.Add(this._lblStatic_11);
            this.XyzWprTab.Controls.Add(this._lblStatic_25);
            this.XyzWprTab.Controls.Add(this.txtXyzWprConfig);
            this.XyzWprTab.Controls.Add(this.txtXyzWpr_0);
            this.XyzWprTab.Controls.Add(this.txtXyzWpr_1);
            this.XyzWprTab.Controls.Add(this.txtXyzWpr_2);
            this.XyzWprTab.Controls.Add(this.txtXyzWpr_3);
            this.XyzWprTab.Controls.Add(this.txtXyzWpr_4);
            this.XyzWprTab.Controls.Add(this.txtXyzWpr_5);
            this.XyzWprTab.Controls.Add(this.frmExtAxis);
            resources.ApplyResources(this.XyzWprTab, "XyzWprTab");
            this.XyzWprTab.Name = "XyzWprTab";
            // 
            // _lblStatic_6
            // 
            this._lblStatic_6.BackColor = System.Drawing.SystemColors.Control;
            this._lblStatic_6.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this._lblStatic_6, "_lblStatic_6");
            this._lblStatic_6.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblStatic_6.Name = "_lblStatic_6";
            // 
            // _lblStatic_7
            // 
            this._lblStatic_7.BackColor = System.Drawing.SystemColors.Control;
            this._lblStatic_7.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this._lblStatic_7, "_lblStatic_7");
            this._lblStatic_7.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblStatic_7.Name = "_lblStatic_7";
            // 
            // _lblStatic_8
            // 
            this._lblStatic_8.BackColor = System.Drawing.SystemColors.Control;
            this._lblStatic_8.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this._lblStatic_8, "_lblStatic_8");
            this._lblStatic_8.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblStatic_8.Name = "_lblStatic_8";
            // 
            // _lblStatic_9
            // 
            this._lblStatic_9.BackColor = System.Drawing.SystemColors.Control;
            this._lblStatic_9.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this._lblStatic_9, "_lblStatic_9");
            this._lblStatic_9.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblStatic_9.Name = "_lblStatic_9";
            // 
            // _lblStatic_10
            // 
            this._lblStatic_10.BackColor = System.Drawing.SystemColors.Control;
            this._lblStatic_10.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this._lblStatic_10, "_lblStatic_10");
            this._lblStatic_10.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblStatic_10.Name = "_lblStatic_10";
            // 
            // _lblStatic_11
            // 
            this._lblStatic_11.BackColor = System.Drawing.SystemColors.Control;
            this._lblStatic_11.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this._lblStatic_11, "_lblStatic_11");
            this._lblStatic_11.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblStatic_11.Name = "_lblStatic_11";
            // 
            // _lblStatic_25
            // 
            this._lblStatic_25.BackColor = System.Drawing.SystemColors.Control;
            this._lblStatic_25.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this._lblStatic_25, "_lblStatic_25");
            this._lblStatic_25.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblStatic_25.Name = "_lblStatic_25";
            // 
            // txtXyzWprConfig
            // 
            this.txtXyzWprConfig.AcceptsReturn = true;
            this.txtXyzWprConfig.BackColor = System.Drawing.SystemColors.Window;
            this.txtXyzWprConfig.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtXyzWprConfig, "txtXyzWprConfig");
            this.txtXyzWprConfig.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtXyzWprConfig.Name = "txtXyzWprConfig";
            this.txtXyzWprConfig.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXyzWprConfig_KeyPress);
            this.txtXyzWprConfig.Leave += new System.EventHandler(this.txtXyzWprConfig_Leave);
            // 
            // txtXyzWpr_0
            // 
            this.txtXyzWpr_0.AcceptsReturn = true;
            this.txtXyzWpr_0.BackColor = System.Drawing.SystemColors.Window;
            this.txtXyzWpr_0.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtXyzWpr_0, "txtXyzWpr_0");
            this.txtXyzWpr_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtXyzWpr_0.Name = "txtXyzWpr_0";
            this.txtXyzWpr_0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXyzWpr_0_KeyPress);
            this.txtXyzWpr_0.Leave += new System.EventHandler(this.txtXyzWpr_0_Leave);
            // 
            // txtXyzWpr_1
            // 
            this.txtXyzWpr_1.AcceptsReturn = true;
            this.txtXyzWpr_1.BackColor = System.Drawing.SystemColors.Window;
            this.txtXyzWpr_1.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtXyzWpr_1, "txtXyzWpr_1");
            this.txtXyzWpr_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtXyzWpr_1.Name = "txtXyzWpr_1";
            this.txtXyzWpr_1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXyzWpr_1_KeyPress);
            this.txtXyzWpr_1.Leave += new System.EventHandler(this.txtXyzWpr_1_Leave);
            // 
            // txtXyzWpr_2
            // 
            this.txtXyzWpr_2.AcceptsReturn = true;
            this.txtXyzWpr_2.BackColor = System.Drawing.SystemColors.Window;
            this.txtXyzWpr_2.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtXyzWpr_2, "txtXyzWpr_2");
            this.txtXyzWpr_2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtXyzWpr_2.Name = "txtXyzWpr_2";
            this.txtXyzWpr_2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXyzWpr_2_KeyPress);
            this.txtXyzWpr_2.Leave += new System.EventHandler(this.txtXyzWpr_2_Leave);
            // 
            // txtXyzWpr_3
            // 
            this.txtXyzWpr_3.AcceptsReturn = true;
            this.txtXyzWpr_3.BackColor = System.Drawing.SystemColors.Window;
            this.txtXyzWpr_3.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtXyzWpr_3, "txtXyzWpr_3");
            this.txtXyzWpr_3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtXyzWpr_3.Name = "txtXyzWpr_3";
            this.txtXyzWpr_3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXyzWpr_3_KeyPress);
            this.txtXyzWpr_3.Leave += new System.EventHandler(this.txtXyzWpr_3_Leave);
            // 
            // txtXyzWpr_4
            // 
            this.txtXyzWpr_4.AcceptsReturn = true;
            this.txtXyzWpr_4.BackColor = System.Drawing.SystemColors.Window;
            this.txtXyzWpr_4.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtXyzWpr_4, "txtXyzWpr_4");
            this.txtXyzWpr_4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtXyzWpr_4.Name = "txtXyzWpr_4";
            this.txtXyzWpr_4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXyzWpr_4_KeyPress);
            this.txtXyzWpr_4.Leave += new System.EventHandler(this.txtXyzWpr_4_Leave);
            // 
            // txtXyzWpr_5
            // 
            this.txtXyzWpr_5.AcceptsReturn = true;
            this.txtXyzWpr_5.BackColor = System.Drawing.SystemColors.Window;
            this.txtXyzWpr_5.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtXyzWpr_5, "txtXyzWpr_5");
            this.txtXyzWpr_5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtXyzWpr_5.Name = "txtXyzWpr_5";
            this.txtXyzWpr_5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXyzExtAxes_0_KeyPress);
            this.txtXyzWpr_5.Leave += new System.EventHandler(this.txtXyzWpr_5_Leave);
            // 
            // frmExtAxis
            // 
            this.frmExtAxis.BackColor = System.Drawing.SystemColors.Control;
            this.frmExtAxis.Controls.Add(this.txtXyzExtAxes_8);
            this.frmExtAxis.Controls.Add(this.txtXyzExtAxes_7);
            this.frmExtAxis.Controls.Add(this.txtXyzExtAxes_6);
            this.frmExtAxis.Controls.Add(this.txtXyzExtAxes_0);
            this.frmExtAxis.Controls.Add(this.txtXyzExtAxes_1);
            this.frmExtAxis.Controls.Add(this.txtXyzExtAxes_2);
            this.frmExtAxis.Controls.Add(this.txtXyzExtAxes_3);
            this.frmExtAxis.Controls.Add(this.txtXyzExtAxes_4);
            this.frmExtAxis.Controls.Add(this.txtXyzExtAxes_5);
            this.frmExtAxis.Controls.Add(this.lblnone);
            resources.ApplyResources(this.frmExtAxis, "frmExtAxis");
            this.frmExtAxis.ForeColor = System.Drawing.SystemColors.ControlText;
            this.frmExtAxis.Name = "frmExtAxis";
            this.frmExtAxis.TabStop = false;
            // 
            // txtXyzExtAxes_8
            // 
            this.txtXyzExtAxes_8.AcceptsReturn = true;
            this.txtXyzExtAxes_8.BackColor = System.Drawing.SystemColors.Window;
            this.txtXyzExtAxes_8.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtXyzExtAxes_8, "txtXyzExtAxes_8");
            this.txtXyzExtAxes_8.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtXyzExtAxes_8.Name = "txtXyzExtAxes_8";
            this.txtXyzExtAxes_8.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXyzExtAxes_8_KeyPress);
            this.txtXyzExtAxes_8.Leave += new System.EventHandler(this.txtXyzExtAxes_8_Leave);
            // 
            // txtXyzExtAxes_7
            // 
            this.txtXyzExtAxes_7.AcceptsReturn = true;
            this.txtXyzExtAxes_7.BackColor = System.Drawing.SystemColors.Window;
            this.txtXyzExtAxes_7.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtXyzExtAxes_7, "txtXyzExtAxes_7");
            this.txtXyzExtAxes_7.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtXyzExtAxes_7.Name = "txtXyzExtAxes_7";
            this.txtXyzExtAxes_7.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXyzExtAxes_7_KeyPress);
            this.txtXyzExtAxes_7.Leave += new System.EventHandler(this.txtXyzExtAxes_7_Leave);
            // 
            // txtXyzExtAxes_6
            // 
            this.txtXyzExtAxes_6.AcceptsReturn = true;
            this.txtXyzExtAxes_6.BackColor = System.Drawing.SystemColors.Window;
            this.txtXyzExtAxes_6.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtXyzExtAxes_6, "txtXyzExtAxes_6");
            this.txtXyzExtAxes_6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtXyzExtAxes_6.Name = "txtXyzExtAxes_6";
            this.txtXyzExtAxes_6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXyzExtAxes_6_KeyPress);
            this.txtXyzExtAxes_6.Leave += new System.EventHandler(this.txtXyzExtAxes_6_Leave);
            // 
            // txtXyzExtAxes_0
            // 
            this.txtXyzExtAxes_0.AcceptsReturn = true;
            this.txtXyzExtAxes_0.BackColor = System.Drawing.SystemColors.Window;
            this.txtXyzExtAxes_0.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtXyzExtAxes_0, "txtXyzExtAxes_0");
            this.txtXyzExtAxes_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtXyzExtAxes_0.Name = "txtXyzExtAxes_0";
            this.txtXyzExtAxes_0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXyzExtAxes_0_KeyPress);
            this.txtXyzExtAxes_0.Leave += new System.EventHandler(this.txtXyzExtAxes_0_Leave);
            // 
            // txtXyzExtAxes_1
            // 
            this.txtXyzExtAxes_1.AcceptsReturn = true;
            this.txtXyzExtAxes_1.BackColor = System.Drawing.SystemColors.Window;
            this.txtXyzExtAxes_1.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtXyzExtAxes_1, "txtXyzExtAxes_1");
            this.txtXyzExtAxes_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtXyzExtAxes_1.Name = "txtXyzExtAxes_1";
            this.txtXyzExtAxes_1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXyzExtAxes_1_KeyPress);
            this.txtXyzExtAxes_1.Leave += new System.EventHandler(this.txtXyzExtAxes_1_Leave);
            // 
            // txtXyzExtAxes_2
            // 
            this.txtXyzExtAxes_2.AcceptsReturn = true;
            this.txtXyzExtAxes_2.BackColor = System.Drawing.SystemColors.Window;
            this.txtXyzExtAxes_2.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtXyzExtAxes_2, "txtXyzExtAxes_2");
            this.txtXyzExtAxes_2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtXyzExtAxes_2.Name = "txtXyzExtAxes_2";
            this.txtXyzExtAxes_2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXyzExtAxes_2_KeyPress);
            this.txtXyzExtAxes_2.Leave += new System.EventHandler(this.txtXyzExtAxes_2_Leave);
            // 
            // txtXyzExtAxes_3
            // 
            this.txtXyzExtAxes_3.AcceptsReturn = true;
            this.txtXyzExtAxes_3.BackColor = System.Drawing.SystemColors.Window;
            this.txtXyzExtAxes_3.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtXyzExtAxes_3, "txtXyzExtAxes_3");
            this.txtXyzExtAxes_3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtXyzExtAxes_3.Name = "txtXyzExtAxes_3";
            this.txtXyzExtAxes_3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXyzExtAxes_3_KeyPress);
            this.txtXyzExtAxes_3.Leave += new System.EventHandler(this.txtXyzExtAxes_3_Leave);
            // 
            // txtXyzExtAxes_4
            // 
            this.txtXyzExtAxes_4.AcceptsReturn = true;
            this.txtXyzExtAxes_4.BackColor = System.Drawing.SystemColors.Window;
            this.txtXyzExtAxes_4.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtXyzExtAxes_4, "txtXyzExtAxes_4");
            this.txtXyzExtAxes_4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtXyzExtAxes_4.Name = "txtXyzExtAxes_4";
            this.txtXyzExtAxes_4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXyzExtAxes_4_KeyPress);
            this.txtXyzExtAxes_4.Leave += new System.EventHandler(this.txtXyzExtAxes_4_Leave);
            // 
            // txtXyzExtAxes_5
            // 
            this.txtXyzExtAxes_5.AcceptsReturn = true;
            this.txtXyzExtAxes_5.BackColor = System.Drawing.SystemColors.Window;
            this.txtXyzExtAxes_5.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtXyzExtAxes_5, "txtXyzExtAxes_5");
            this.txtXyzExtAxes_5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtXyzExtAxes_5.Name = "txtXyzExtAxes_5";
            this.txtXyzExtAxes_5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXyzExtAxes_5_KeyPress);
            this.txtXyzExtAxes_5.Leave += new System.EventHandler(this.txtXyzExtAxes_5_Leave);
            // 
            // lblnone
            // 
            this.lblnone.BackColor = System.Drawing.SystemColors.Control;
            this.lblnone.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblnone, "lblnone");
            this.lblnone.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblnone.Name = "lblnone";
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
            this.JointTab.Controls.Add(this.lblJointNotValid);
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
            this.txtJoint_0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJoint_0_KeyPress);
            this.txtJoint_0.Leave += new System.EventHandler(this.txtJoint_0_Leave);
            // 
            // txtJoint_1
            // 
            this.txtJoint_1.AcceptsReturn = true;
            this.txtJoint_1.BackColor = System.Drawing.SystemColors.Window;
            this.txtJoint_1.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtJoint_1, "txtJoint_1");
            this.txtJoint_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtJoint_1.Name = "txtJoint_1";
            this.txtJoint_1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJoint_1_KeyPress);
            this.txtJoint_1.Leave += new System.EventHandler(this.txtJoint_1_Leave);
            // 
            // txtJoint_2
            // 
            this.txtJoint_2.AcceptsReturn = true;
            this.txtJoint_2.BackColor = System.Drawing.SystemColors.Window;
            this.txtJoint_2.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtJoint_2, "txtJoint_2");
            this.txtJoint_2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtJoint_2.Name = "txtJoint_2";
            this.txtJoint_2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJoint_2_KeyPress);
            this.txtJoint_2.Leave += new System.EventHandler(this.txtJoint_2_Leave);
            // 
            // txtJoint_3
            // 
            this.txtJoint_3.AcceptsReturn = true;
            this.txtJoint_3.BackColor = System.Drawing.SystemColors.Window;
            this.txtJoint_3.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtJoint_3, "txtJoint_3");
            this.txtJoint_3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtJoint_3.Name = "txtJoint_3";
            this.txtJoint_3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJoint_3_KeyPress);
            this.txtJoint_3.Leave += new System.EventHandler(this.txtJoint_3_Leave);
            // 
            // txtJoint_4
            // 
            this.txtJoint_4.AcceptsReturn = true;
            this.txtJoint_4.BackColor = System.Drawing.SystemColors.Window;
            this.txtJoint_4.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtJoint_4, "txtJoint_4");
            this.txtJoint_4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtJoint_4.Name = "txtJoint_4";
            this.txtJoint_4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJoint_4_KeyPress);
            this.txtJoint_4.Leave += new System.EventHandler(this.txtJoint_4_Leave);
            // 
            // txtJoint_5
            // 
            this.txtJoint_5.AcceptsReturn = true;
            this.txtJoint_5.BackColor = System.Drawing.SystemColors.Window;
            this.txtJoint_5.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtJoint_5, "txtJoint_5");
            this.txtJoint_5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtJoint_5.Name = "txtJoint_5";
            this.txtJoint_5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJoint_5_KeyPress);
            this.txtJoint_5.Leave += new System.EventHandler(this.txtJoint_5_Leave);
            // 
            // txtJoint_6
            // 
            this.txtJoint_6.AcceptsReturn = true;
            this.txtJoint_6.BackColor = System.Drawing.SystemColors.Window;
            this.txtJoint_6.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtJoint_6, "txtJoint_6");
            this.txtJoint_6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtJoint_6.Name = "txtJoint_6";
            this.txtJoint_6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJoint_6_KeyPress);
            this.txtJoint_6.Leave += new System.EventHandler(this.txtJoint_6_Leave);
            // 
            // txtJoint_7
            // 
            this.txtJoint_7.AcceptsReturn = true;
            this.txtJoint_7.BackColor = System.Drawing.SystemColors.Window;
            this.txtJoint_7.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtJoint_7, "txtJoint_7");
            this.txtJoint_7.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtJoint_7.Name = "txtJoint_7";
            this.txtJoint_7.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJoint_7_KeyPress);
            this.txtJoint_7.Leave += new System.EventHandler(this.txtJoint_7_Leave);
            // 
            // txtJoint_8
            // 
            this.txtJoint_8.AcceptsReturn = true;
            this.txtJoint_8.BackColor = System.Drawing.SystemColors.Window;
            this.txtJoint_8.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtJoint_8, "txtJoint_8");
            this.txtJoint_8.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtJoint_8.Name = "txtJoint_8";
            this.txtJoint_8.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJoint_8_KeyPress);
            this.txtJoint_8.Leave += new System.EventHandler(this.txtJoint_8_Leave);
            // 
            // lblJointNotValid
            // 
            this.lblJointNotValid.BackColor = System.Drawing.SystemColors.Control;
            this.lblJointNotValid.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblJointNotValid, "lblJointNotValid");
            this.lblJointNotValid.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblJointNotValid.Name = "lblJointNotValid";
            // 
            // cmdOk
            // 
            this.cmdOk.BackColor = System.Drawing.SystemColors.Control;
            this.cmdOk.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.cmdOk, "cmdOk");
            this.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.UseVisualStyleBackColor = false;
            this.cmdOk.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // frmEditPosition
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdOk);
            this.Controls.Add(this.tabPos);
            this.Controls.Add(this.cmdSetAsCopySource);
            this.Controls.Add(this.cmdCopyFromSource);
            this.Controls.Add(this.cmdIsReachable);
            this.Controls.Add(this.cmdUpdate);
            this.Controls.Add(this.cmdRefresh);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.cmdUninit);
            this.Controls.Add(this.cmdRecord);
            this.Controls.Add(this.cmdMoveto);
            this.Controls.Add(this.cmdInv);
            this.Controls.Add(this.txtToolNum);
            this.Controls.Add(this.txtFrameNum);
            this.Controls.Add(this.Frame1);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.lblFrameNum);
            this.Controls.Add(this.lblToolNum);
            this.Controls.Add(this.lblComment);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmEditPosition";
            this.ShowIcon = false;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmEditPosition_KeyPress);
            this.Frame1.ResumeLayout(false);
            this.tabPos.ResumeLayout(false);
            this.TransformTab.ResumeLayout(false);
            this.TransformTab.PerformLayout();
            this.frmTransExtAxes.ResumeLayout(false);
            this.frmTransExtAxes.PerformLayout();
            this.XyzWprTab.ResumeLayout(false);
            this.XyzWprTab.PerformLayout();
            this.frmExtAxis.ResumeLayout(false);
            this.frmExtAxis.PerformLayout();
            this.JointTab.ResumeLayout(false);
            this.JointTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        public System.Windows.Forms.Button cmdSetAsCopySource;
        public System.Windows.Forms.Button cmdCopyFromSource;
        public System.Windows.Forms.Button cmdIsReachable;
        public System.Windows.Forms.Button cmdUpdate;
        public System.Windows.Forms.Button cmdRefresh;
        public System.Windows.Forms.TextBox txtId;
        public System.Windows.Forms.Button cmdUninit;
        public System.Windows.Forms.Button cmdRecord;
        public System.Windows.Forms.Button cmdMoveto;
        public System.Windows.Forms.Button cmdInv;
        public System.Windows.Forms.TextBox txtToolNum;
        public System.Windows.Forms.TextBox txtFrameNum;
        public System.Windows.Forms.GroupBox Frame1;
        public System.Windows.Forms.RadioButton optJoint;
        public System.Windows.Forms.RadioButton optXyzWpr;
        public System.Windows.Forms.RadioButton optTransform;
        public System.Windows.Forms.Label lblWithExtAxes;
        public System.Windows.Forms.TextBox txtComment;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.Label lblFrameNum;
        public System.Windows.Forms.Label lblToolNum;
        public System.Windows.Forms.Label lblComment;
        public System.Windows.Forms.TabControl tabPos;
        public System.Windows.Forms.TabPage TransformTab;
        public System.Windows.Forms.Label _lblStatic_0;
        public System.Windows.Forms.Label _lblStatic_1;
        public System.Windows.Forms.Label _lblStatic_2;
        public System.Windows.Forms.Label _lblStatic_3;
        public System.Windows.Forms.Label _lblStatic_5;
        public System.Windows.Forms.TextBox txtN_0;
        public System.Windows.Forms.TextBox txtN_1;
        public System.Windows.Forms.TextBox txtN_2;
        public System.Windows.Forms.TextBox txtO_0;
        public System.Windows.Forms.TextBox txtO_1;
        public System.Windows.Forms.TextBox txtO_2;
        public System.Windows.Forms.TextBox txtA_0;
        public System.Windows.Forms.TextBox txtA_1;
        public System.Windows.Forms.TextBox txtA_2;
        public System.Windows.Forms.TextBox txtL_0;
        public System.Windows.Forms.TextBox txtL_1;
        public System.Windows.Forms.TextBox txtL_2;
        public System.Windows.Forms.TextBox txtTransConfig;
        public System.Windows.Forms.GroupBox frmTransExtAxes;
        public System.Windows.Forms.TextBox txtTransExtAxes_8;
        public System.Windows.Forms.TextBox txtTransExtAxes_7;
        public System.Windows.Forms.TextBox txtTransExtAxes_6;
        public System.Windows.Forms.TextBox txtTransExtAxes_5;
        public System.Windows.Forms.TextBox txtTransExtAxes_4;
        public System.Windows.Forms.TextBox txtTransExtAxes_3;
        public System.Windows.Forms.TextBox txtTransExtAxes_2;
        public System.Windows.Forms.TextBox txtTransExtAxes_1;
        public System.Windows.Forms.TextBox txtTransExtAxes_0;
        public System.Windows.Forms.Label Label3;
        public System.Windows.Forms.TabPage XyzWprTab;
        public System.Windows.Forms.Label _lblStatic_6;
        public System.Windows.Forms.Label _lblStatic_7;
        public System.Windows.Forms.Label _lblStatic_8;
        public System.Windows.Forms.Label _lblStatic_9;
        public System.Windows.Forms.Label _lblStatic_10;
        public System.Windows.Forms.Label _lblStatic_11;
        public System.Windows.Forms.Label _lblStatic_25;
        public System.Windows.Forms.TextBox txtXyzWprConfig;
        public System.Windows.Forms.TextBox txtXyzWpr_0;
        public System.Windows.Forms.TextBox txtXyzWpr_1;
        public System.Windows.Forms.TextBox txtXyzWpr_2;
        public System.Windows.Forms.TextBox txtXyzWpr_3;
        public System.Windows.Forms.TextBox txtXyzWpr_4;
        public System.Windows.Forms.TextBox txtXyzWpr_5;
        public System.Windows.Forms.GroupBox frmExtAxis;
        public System.Windows.Forms.TextBox txtXyzExtAxes_8;
        public System.Windows.Forms.TextBox txtXyzExtAxes_7;
        public System.Windows.Forms.TextBox txtXyzExtAxes_6;
        public System.Windows.Forms.TextBox txtXyzExtAxes_1;
        public System.Windows.Forms.TextBox txtXyzExtAxes_2;
        public System.Windows.Forms.TextBox txtXyzExtAxes_4;
        public System.Windows.Forms.TextBox txtXyzExtAxes_5;
        public System.Windows.Forms.Label lblnone;
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
        public System.Windows.Forms.Label lblJointNotValid;
        public System.Windows.Forms.TextBox txtJoint_0;
        public System.Windows.Forms.TextBox txtJoint_1;
        public System.Windows.Forms.TextBox txtJoint_2;
        public System.Windows.Forms.TextBox txtJoint_3;
        public System.Windows.Forms.TextBox txtJoint_4;
        public System.Windows.Forms.TextBox txtJoint_5;
        public System.Windows.Forms.TextBox txtJoint_6;
        public System.Windows.Forms.TextBox txtJoint_7;
        public System.Windows.Forms.TextBox txtJoint_8;
        public System.Windows.Forms.Button cmdOk;
        public System.Windows.Forms.TextBox txtXyzExtAxes_0;
        public System.Windows.Forms.TextBox txtXyzExtAxes_3;
    }
}