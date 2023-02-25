namespace FRRobotDemoCSharp
{
    partial class frmEditAssoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditAssoc));
            this.FrameGroup = new System.Windows.Forms.GroupBox();
            this.chkSegBreak = new System.Windows.Forms.CheckBox();
            this.Frame1 = new System.Windows.Forms.GroupBox();
            this.optNone_go = new System.Windows.Forms.RadioButton();
            this.optRSWorld = new System.Windows.Forms.RadioButton();
            this.optAESWorld = new System.Windows.Forms.RadioButton();
            this.optWristJoint = new System.Windows.Forms.RadioButton();
            this.Frame3 = new System.Windows.Forms.GroupBox();
            this.optNone_gt = new System.Windows.Forms.RadioButton();
            this.optCircular = new System.Windows.Forms.RadioButton();
            this.optLinear = new System.Windows.Forms.RadioButton();
            this.optJoint = new System.Windows.Forms.RadioButton();
            this.txtSegRelSpeed = new System.Windows.Forms.TextBox();
            this._lblStatic_5 = new System.Windows.Forms.Label();
            this.cmdOk = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.FrameCommon = new System.Windows.Forms.GroupBox();
            this.txtSegTimeShift = new System.Windows.Forms.TextBox();
            this.txtSegRelAccel = new System.Windows.Forms.TextBox();
            this.txtSegDecelTol = new System.Windows.Forms.TextBox();
            this.Frame2 = new System.Windows.Forms.GroupBox();
            this.optNone = new System.Windows.Forms.RadioButton();
            this.optVarDecel = new System.Windows.Forms.RadioButton();
            this.optFine = new System.Windows.Forms.RadioButton();
            this.optCoarse = new System.Windows.Forms.RadioButton();
            this.optNosettle = new System.Windows.Forms.RadioButton();
            this.optNoDecel = new System.Windows.Forms.RadioButton();
            this._lblStatic_2 = new System.Windows.Forms.Label();
            this._lblStatic_1 = new System.Windows.Forms.Label();
            this._lblStatic_0 = new System.Windows.Forms.Label();
            this.FrameGroup.SuspendLayout();
            this.Frame1.SuspendLayout();
            this.Frame3.SuspendLayout();
            this.FrameCommon.SuspendLayout();
            this.Frame2.SuspendLayout();
            this.SuspendLayout();
            // 
            // FrameGroup
            // 
            this.FrameGroup.BackColor = System.Drawing.SystemColors.Control;
            this.FrameGroup.Controls.Add(this.chkSegBreak);
            this.FrameGroup.Controls.Add(this.Frame1);
            this.FrameGroup.Controls.Add(this.Frame3);
            this.FrameGroup.Controls.Add(this.txtSegRelSpeed);
            this.FrameGroup.Controls.Add(this._lblStatic_5);
            resources.ApplyResources(this.FrameGroup, "FrameGroup");
            this.FrameGroup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FrameGroup.Name = "FrameGroup";
            this.FrameGroup.TabStop = false;
            // 
            // chkSegBreak
            // 
            this.chkSegBreak.BackColor = System.Drawing.SystemColors.Control;
            this.chkSegBreak.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.chkSegBreak, "chkSegBreak");
            this.chkSegBreak.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkSegBreak.Name = "chkSegBreak";
            this.chkSegBreak.UseVisualStyleBackColor = false;
            // 
            // Frame1
            // 
            this.Frame1.BackColor = System.Drawing.SystemColors.Control;
            this.Frame1.Controls.Add(this.optNone_go);
            this.Frame1.Controls.Add(this.optRSWorld);
            this.Frame1.Controls.Add(this.optAESWorld);
            this.Frame1.Controls.Add(this.optWristJoint);
            resources.ApplyResources(this.Frame1, "Frame1");
            this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Frame1.Name = "Frame1";
            this.Frame1.TabStop = false;
            // 
            // optNone_go
            // 
            this.optNone_go.BackColor = System.Drawing.SystemColors.Control;
            this.optNone_go.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.optNone_go, "optNone_go");
            this.optNone_go.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optNone_go.Name = "optNone_go";
            this.optNone_go.TabStop = true;
            this.optNone_go.UseVisualStyleBackColor = false;
            // 
            // optRSWorld
            // 
            this.optRSWorld.BackColor = System.Drawing.SystemColors.Control;
            this.optRSWorld.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.optRSWorld, "optRSWorld");
            this.optRSWorld.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optRSWorld.Name = "optRSWorld";
            this.optRSWorld.TabStop = true;
            this.optRSWorld.UseVisualStyleBackColor = false;
            // 
            // optAESWorld
            // 
            this.optAESWorld.BackColor = System.Drawing.SystemColors.Control;
            this.optAESWorld.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.optAESWorld, "optAESWorld");
            this.optAESWorld.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optAESWorld.Name = "optAESWorld";
            this.optAESWorld.TabStop = true;
            this.optAESWorld.UseVisualStyleBackColor = false;
            // 
            // optWristJoint
            // 
            this.optWristJoint.BackColor = System.Drawing.SystemColors.Control;
            this.optWristJoint.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.optWristJoint, "optWristJoint");
            this.optWristJoint.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optWristJoint.Name = "optWristJoint";
            this.optWristJoint.TabStop = true;
            this.optWristJoint.UseVisualStyleBackColor = false;
            // 
            // Frame3
            // 
            this.Frame3.BackColor = System.Drawing.SystemColors.Control;
            this.Frame3.Controls.Add(this.optNone_gt);
            this.Frame3.Controls.Add(this.optCircular);
            this.Frame3.Controls.Add(this.optLinear);
            this.Frame3.Controls.Add(this.optJoint);
            resources.ApplyResources(this.Frame3, "Frame3");
            this.Frame3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Frame3.Name = "Frame3";
            this.Frame3.TabStop = false;
            // 
            // optNone_gt
            // 
            this.optNone_gt.BackColor = System.Drawing.SystemColors.Control;
            this.optNone_gt.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.optNone_gt, "optNone_gt");
            this.optNone_gt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optNone_gt.Name = "optNone_gt";
            this.optNone_gt.TabStop = true;
            this.optNone_gt.UseVisualStyleBackColor = false;
            // 
            // optCircular
            // 
            this.optCircular.BackColor = System.Drawing.SystemColors.Control;
            this.optCircular.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.optCircular, "optCircular");
            this.optCircular.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optCircular.Name = "optCircular";
            this.optCircular.TabStop = true;
            this.optCircular.UseVisualStyleBackColor = false;
            // 
            // optLinear
            // 
            this.optLinear.BackColor = System.Drawing.SystemColors.Control;
            this.optLinear.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.optLinear, "optLinear");
            this.optLinear.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optLinear.Name = "optLinear";
            this.optLinear.TabStop = true;
            this.optLinear.UseVisualStyleBackColor = false;
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
            // 
            // txtSegRelSpeed
            // 
            this.txtSegRelSpeed.AcceptsReturn = true;
            this.txtSegRelSpeed.BackColor = System.Drawing.SystemColors.Window;
            this.txtSegRelSpeed.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtSegRelSpeed, "txtSegRelSpeed");
            this.txtSegRelSpeed.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSegRelSpeed.Name = "txtSegRelSpeed";
            // 
            // _lblStatic_5
            // 
            this._lblStatic_5.BackColor = System.Drawing.SystemColors.Control;
            this._lblStatic_5.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this._lblStatic_5, "_lblStatic_5");
            this._lblStatic_5.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblStatic_5.Name = "_lblStatic_5";
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
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
            this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.cmdCancel, "cmdCancel");
            this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.UseVisualStyleBackColor = false;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // FrameCommon
            // 
            this.FrameCommon.BackColor = System.Drawing.SystemColors.Control;
            this.FrameCommon.Controls.Add(this.txtSegTimeShift);
            this.FrameCommon.Controls.Add(this.txtSegRelAccel);
            this.FrameCommon.Controls.Add(this.txtSegDecelTol);
            this.FrameCommon.Controls.Add(this.Frame2);
            this.FrameCommon.Controls.Add(this._lblStatic_2);
            this.FrameCommon.Controls.Add(this._lblStatic_1);
            this.FrameCommon.Controls.Add(this._lblStatic_0);
            resources.ApplyResources(this.FrameCommon, "FrameCommon");
            this.FrameCommon.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FrameCommon.Name = "FrameCommon";
            this.FrameCommon.TabStop = false;
            // 
            // txtSegTimeShift
            // 
            this.txtSegTimeShift.AcceptsReturn = true;
            this.txtSegTimeShift.BackColor = System.Drawing.SystemColors.Window;
            this.txtSegTimeShift.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtSegTimeShift, "txtSegTimeShift");
            this.txtSegTimeShift.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSegTimeShift.Name = "txtSegTimeShift";
            // 
            // txtSegRelAccel
            // 
            this.txtSegRelAccel.AcceptsReturn = true;
            this.txtSegRelAccel.BackColor = System.Drawing.SystemColors.Window;
            this.txtSegRelAccel.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtSegRelAccel, "txtSegRelAccel");
            this.txtSegRelAccel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSegRelAccel.Name = "txtSegRelAccel";
            // 
            // txtSegDecelTol
            // 
            this.txtSegDecelTol.AcceptsReturn = true;
            this.txtSegDecelTol.BackColor = System.Drawing.SystemColors.Window;
            this.txtSegDecelTol.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtSegDecelTol, "txtSegDecelTol");
            this.txtSegDecelTol.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSegDecelTol.Name = "txtSegDecelTol";
            // 
            // Frame2
            // 
            this.Frame2.BackColor = System.Drawing.SystemColors.Control;
            this.Frame2.Controls.Add(this.optNone);
            this.Frame2.Controls.Add(this.optVarDecel);
            this.Frame2.Controls.Add(this.optFine);
            this.Frame2.Controls.Add(this.optCoarse);
            this.Frame2.Controls.Add(this.optNosettle);
            this.Frame2.Controls.Add(this.optNoDecel);
            resources.ApplyResources(this.Frame2, "Frame2");
            this.Frame2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Frame2.Name = "Frame2";
            this.Frame2.TabStop = false;
            // 
            // optNone
            // 
            this.optNone.BackColor = System.Drawing.SystemColors.Control;
            this.optNone.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.optNone, "optNone");
            this.optNone.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optNone.Name = "optNone";
            this.optNone.TabStop = true;
            this.optNone.UseVisualStyleBackColor = false;
            // 
            // optVarDecel
            // 
            this.optVarDecel.BackColor = System.Drawing.SystemColors.Control;
            this.optVarDecel.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.optVarDecel, "optVarDecel");
            this.optVarDecel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optVarDecel.Name = "optVarDecel";
            this.optVarDecel.TabStop = true;
            this.optVarDecel.UseVisualStyleBackColor = false;
            // 
            // optFine
            // 
            this.optFine.BackColor = System.Drawing.SystemColors.Control;
            this.optFine.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.optFine, "optFine");
            this.optFine.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optFine.Name = "optFine";
            this.optFine.TabStop = true;
            this.optFine.UseVisualStyleBackColor = false;
            // 
            // optCoarse
            // 
            this.optCoarse.BackColor = System.Drawing.SystemColors.Control;
            this.optCoarse.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.optCoarse, "optCoarse");
            this.optCoarse.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optCoarse.Name = "optCoarse";
            this.optCoarse.TabStop = true;
            this.optCoarse.UseVisualStyleBackColor = false;
            // 
            // optNosettle
            // 
            this.optNosettle.BackColor = System.Drawing.SystemColors.Control;
            this.optNosettle.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.optNosettle, "optNosettle");
            this.optNosettle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optNosettle.Name = "optNosettle";
            this.optNosettle.TabStop = true;
            this.optNosettle.UseVisualStyleBackColor = false;
            // 
            // optNoDecel
            // 
            this.optNoDecel.BackColor = System.Drawing.SystemColors.Control;
            this.optNoDecel.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.optNoDecel, "optNoDecel");
            this.optNoDecel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optNoDecel.Name = "optNoDecel";
            this.optNoDecel.TabStop = true;
            this.optNoDecel.UseVisualStyleBackColor = false;
            // 
            // _lblStatic_2
            // 
            this._lblStatic_2.BackColor = System.Drawing.SystemColors.Control;
            this._lblStatic_2.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this._lblStatic_2, "_lblStatic_2");
            this._lblStatic_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblStatic_2.Name = "_lblStatic_2";
            // 
            // _lblStatic_1
            // 
            this._lblStatic_1.BackColor = System.Drawing.SystemColors.Control;
            this._lblStatic_1.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this._lblStatic_1, "_lblStatic_1");
            this._lblStatic_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblStatic_1.Name = "_lblStatic_1";
            // 
            // _lblStatic_0
            // 
            this._lblStatic_0.BackColor = System.Drawing.SystemColors.Control;
            this._lblStatic_0.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this._lblStatic_0, "_lblStatic_0");
            this._lblStatic_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblStatic_0.Name = "_lblStatic_0";
            // 
            // frmEditAssoc
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.FrameCommon);
            this.Controls.Add(this.FrameGroup);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOk);
            this.MaximizeBox = false;
            this.Name = "frmEditAssoc";
            this.ShowIcon = false;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmEditAssoc_KeyPress);
            this.FrameGroup.ResumeLayout(false);
            this.FrameGroup.PerformLayout();
            this.Frame1.ResumeLayout(false);
            this.Frame3.ResumeLayout(false);
            this.FrameCommon.ResumeLayout(false);
            this.FrameCommon.PerformLayout();
            this.Frame2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        public System.Windows.Forms.GroupBox FrameGroup;
        public System.Windows.Forms.CheckBox chkSegBreak;
        public System.Windows.Forms.GroupBox Frame1;
        public System.Windows.Forms.RadioButton optNone_go;
        public System.Windows.Forms.RadioButton optRSWorld;
        public System.Windows.Forms.RadioButton optAESWorld;
        public System.Windows.Forms.RadioButton optWristJoint;
        public System.Windows.Forms.GroupBox Frame3;
        public System.Windows.Forms.RadioButton optNone_gt;
        public System.Windows.Forms.RadioButton optCircular;
        public System.Windows.Forms.RadioButton optLinear;
        public System.Windows.Forms.RadioButton optJoint;
        public System.Windows.Forms.TextBox txtSegRelSpeed;
        public System.Windows.Forms.Label _lblStatic_5;
        public System.Windows.Forms.Button cmdOk;
        public System.Windows.Forms.Button cmdCancel;
        public System.Windows.Forms.GroupBox FrameCommon;
        public System.Windows.Forms.TextBox txtSegTimeShift;
        public System.Windows.Forms.TextBox txtSegRelAccel;
        public System.Windows.Forms.TextBox txtSegDecelTol;
        public System.Windows.Forms.GroupBox Frame2;
        public System.Windows.Forms.RadioButton optNone;
        public System.Windows.Forms.RadioButton optVarDecel;
        public System.Windows.Forms.RadioButton optFine;
        public System.Windows.Forms.RadioButton optCoarse;
        public System.Windows.Forms.RadioButton optNosettle;
        public System.Windows.Forms.RadioButton optNoDecel;
        public System.Windows.Forms.Label _lblStatic_2;
        public System.Windows.Forms.Label _lblStatic_1;
        public System.Windows.Forms.Label _lblStatic_0;
    }
}