namespace FRRobotDemoCSharp
{
    partial class frmIOConfigAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIOConfigAdd));
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.txtFirstLogicalNum = new System.Windows.Forms.TextBox();
            this.txtNumSignals = new System.Windows.Forms.TextBox();
            this.txtRack = new System.Windows.Forms.TextBox();
            this.txtSlot = new System.Windows.Forms.TextBox();
            this.txtFirstPhysicalNum = new System.Windows.Forms.TextBox();
            this.lblFirstLogicalNum = new System.Windows.Forms.Label();
            this.lblNumSignals = new System.Windows.Forms.Label();
            this.lblRack = new System.Windows.Forms.Label();
            this.lblSlot = new System.Windows.Forms.Label();
            this.lblFirstPhysicalNum = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            // cmdOK
            // 
            this.cmdOK.BackColor = System.Drawing.SystemColors.Control;
            this.cmdOK.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.cmdOK, "cmdOK");
            this.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.UseVisualStyleBackColor = false;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // txtFirstLogicalNum
            // 
            this.txtFirstLogicalNum.AcceptsReturn = true;
            this.txtFirstLogicalNum.BackColor = System.Drawing.SystemColors.Window;
            this.txtFirstLogicalNum.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtFirstLogicalNum, "txtFirstLogicalNum");
            this.txtFirstLogicalNum.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFirstLogicalNum.Name = "txtFirstLogicalNum";
            // 
            // txtNumSignals
            // 
            this.txtNumSignals.AcceptsReturn = true;
            this.txtNumSignals.BackColor = System.Drawing.SystemColors.Window;
            this.txtNumSignals.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtNumSignals, "txtNumSignals");
            this.txtNumSignals.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNumSignals.Name = "txtNumSignals";
            // 
            // txtRack
            // 
            this.txtRack.AcceptsReturn = true;
            this.txtRack.BackColor = System.Drawing.SystemColors.Window;
            this.txtRack.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtRack, "txtRack");
            this.txtRack.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtRack.Name = "txtRack";
            // 
            // txtSlot
            // 
            this.txtSlot.AcceptsReturn = true;
            this.txtSlot.BackColor = System.Drawing.SystemColors.Window;
            this.txtSlot.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtSlot, "txtSlot");
            this.txtSlot.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSlot.Name = "txtSlot";
            // 
            // txtFirstPhysicalNum
            // 
            this.txtFirstPhysicalNum.AcceptsReturn = true;
            this.txtFirstPhysicalNum.BackColor = System.Drawing.SystemColors.Window;
            this.txtFirstPhysicalNum.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtFirstPhysicalNum, "txtFirstPhysicalNum");
            this.txtFirstPhysicalNum.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFirstPhysicalNum.Name = "txtFirstPhysicalNum";
            // 
            // lblFirstLogicalNum
            // 
            this.lblFirstLogicalNum.BackColor = System.Drawing.SystemColors.Control;
            this.lblFirstLogicalNum.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblFirstLogicalNum, "lblFirstLogicalNum");
            this.lblFirstLogicalNum.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFirstLogicalNum.Name = "lblFirstLogicalNum";
            // 
            // lblNumSignals
            // 
            this.lblNumSignals.BackColor = System.Drawing.SystemColors.Control;
            this.lblNumSignals.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblNumSignals, "lblNumSignals");
            this.lblNumSignals.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNumSignals.Name = "lblNumSignals";
            // 
            // lblRack
            // 
            this.lblRack.BackColor = System.Drawing.SystemColors.Control;
            this.lblRack.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblRack, "lblRack");
            this.lblRack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRack.Name = "lblRack";
            // 
            // lblSlot
            // 
            this.lblSlot.BackColor = System.Drawing.SystemColors.Control;
            this.lblSlot.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblSlot, "lblSlot");
            this.lblSlot.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSlot.Name = "lblSlot";
            // 
            // lblFirstPhysicalNum
            // 
            this.lblFirstPhysicalNum.BackColor = System.Drawing.SystemColors.Control;
            this.lblFirstPhysicalNum.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblFirstPhysicalNum, "lblFirstPhysicalNum");
            this.lblFirstPhysicalNum.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFirstPhysicalNum.Name = "lblFirstPhysicalNum";
            // 
            // frmIOConfigAdd
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.txtFirstLogicalNum);
            this.Controls.Add(this.txtNumSignals);
            this.Controls.Add(this.txtRack);
            this.Controls.Add(this.txtSlot);
            this.Controls.Add(this.txtFirstPhysicalNum);
            this.Controls.Add(this.lblFirstLogicalNum);
            this.Controls.Add(this.lblNumSignals);
            this.Controls.Add(this.lblRack);
            this.Controls.Add(this.lblSlot);
            this.Controls.Add(this.lblFirstPhysicalNum);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmIOConfigAdd";
            this.ShowIcon = false;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmIOConfigAdd_FormClosed);
            this.Load += new System.EventHandler(this.frmIOConfigAdd_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmIOConfigAdd_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        public System.Windows.Forms.Button cmdCancel;
        public System.Windows.Forms.Button cmdOK;
        public System.Windows.Forms.TextBox txtFirstLogicalNum;
        public System.Windows.Forms.TextBox txtNumSignals;
        public System.Windows.Forms.TextBox txtRack;
        public System.Windows.Forms.TextBox txtSlot;
        public System.Windows.Forms.TextBox txtFirstPhysicalNum;
        public System.Windows.Forms.Label lblFirstLogicalNum;
        public System.Windows.Forms.Label lblNumSignals;
        public System.Windows.Forms.Label lblRack;
        public System.Windows.Forms.Label lblSlot;
        public System.Windows.Forms.Label lblFirstPhysicalNum;
    }
}