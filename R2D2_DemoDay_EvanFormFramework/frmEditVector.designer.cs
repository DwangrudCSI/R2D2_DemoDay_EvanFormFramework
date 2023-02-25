namespace FRRobotDemoCSharp
{
    partial class frmEditVector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditVector));
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOk = new System.Windows.Forms.Button();
            this.txtZ = new System.Windows.Forms.TextBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.txtX = new System.Windows.Forms.TextBox();
            this._lblStatic_8 = new System.Windows.Forms.Label();
            this._lblStatic_7 = new System.Windows.Forms.Label();
            this._lblStatic_6 = new System.Windows.Forms.Label();
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
            // txtZ
            // 
            this.txtZ.AcceptsReturn = true;
            this.txtZ.BackColor = System.Drawing.SystemColors.Window;
            this.txtZ.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtZ, "txtZ");
            this.txtZ.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtZ.Name = "txtZ";
            // 
            // txtY
            // 
            this.txtY.AcceptsReturn = true;
            this.txtY.BackColor = System.Drawing.SystemColors.Window;
            this.txtY.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtY, "txtY");
            this.txtY.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtY.Name = "txtY";
            // 
            // txtX
            // 
            this.txtX.AcceptsReturn = true;
            this.txtX.BackColor = System.Drawing.SystemColors.Window;
            this.txtX.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtX, "txtX");
            this.txtX.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtX.Name = "txtX";
            // 
            // _lblStatic_8
            // 
            this._lblStatic_8.BackColor = System.Drawing.SystemColors.Control;
            this._lblStatic_8.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this._lblStatic_8, "_lblStatic_8");
            this._lblStatic_8.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblStatic_8.Name = "_lblStatic_8";
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
            // frmEditVector
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOk);
            this.Controls.Add(this.txtZ);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this._lblStatic_8);
            this.Controls.Add(this._lblStatic_7);
            this.Controls.Add(this._lblStatic_6);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmEditVector";
            this.ShowIcon = false;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmEditVector_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        public System.Windows.Forms.Button cmdCancel;
        public System.Windows.Forms.Button cmdOk;
        public System.Windows.Forms.TextBox txtZ;
        public System.Windows.Forms.TextBox txtY;
        public System.Windows.Forms.TextBox txtX;
        public System.Windows.Forms.Label _lblStatic_8;
        public System.Windows.Forms.Label _lblStatic_7;
        public System.Windows.Forms.Label _lblStatic_6;
    }
}