namespace FRRobotDemoCSharp
{
    partial class frmEditNumReg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditNumReg));
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOk = new System.Windows.Forms.Button();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.Frame1 = new System.Windows.Forms.GroupBox();
            this.optReal = new System.Windows.Forms.RadioButton();
            this.optInteger = new System.Windows.Forms.RadioButton();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Frame1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
            this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
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
            // txtComment
            // 
            this.txtComment.AcceptsReturn = true;
            this.txtComment.BackColor = System.Drawing.SystemColors.Window;
            this.txtComment.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtComment, "txtComment");
            this.txtComment.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtComment.Name = "txtComment";
            // 
            // txtValue
            // 
            this.txtValue.AcceptsReturn = true;
            this.txtValue.BackColor = System.Drawing.SystemColors.Window;
            this.txtValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtValue, "txtValue");
            this.txtValue.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtValue.Name = "txtValue";
            // 
            // Frame1
            // 
            this.Frame1.BackColor = System.Drawing.SystemColors.Control;
            this.Frame1.Controls.Add(this.optReal);
            this.Frame1.Controls.Add(this.optInteger);
            resources.ApplyResources(this.Frame1, "Frame1");
            this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Frame1.Name = "Frame1";
            this.Frame1.TabStop = false;
            // 
            // optReal
            // 
            this.optReal.BackColor = System.Drawing.SystemColors.Control;
            this.optReal.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.optReal, "optReal");
            this.optReal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optReal.Name = "optReal";
            this.optReal.TabStop = true;
            this.optReal.UseVisualStyleBackColor = false;
            // 
            // optInteger
            // 
            this.optInteger.BackColor = System.Drawing.SystemColors.Control;
            this.optInteger.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.optInteger, "optInteger");
            this.optInteger.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optInteger.Name = "optInteger";
            this.optInteger.TabStop = true;
            this.optInteger.UseVisualStyleBackColor = false;
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.SystemColors.Control;
            this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.Label2, "Label2");
            this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label2.Name = "Label2";
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.SystemColors.Control;
            this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.Label1, "Label1");
            this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label1.Name = "Label1";
            // 
            // frmEditNumReg
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOk);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.Frame1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmEditNumReg";
            this.ShowIcon = false;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmEditNumReg_KeyPress);
            this.Frame1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        public System.Windows.Forms.Button cmdCancel;
        public System.Windows.Forms.Button cmdOk;
        public System.Windows.Forms.TextBox txtComment;
        public System.Windows.Forms.TextBox txtValue;
        public System.Windows.Forms.GroupBox Frame1;
        public System.Windows.Forms.RadioButton optReal;
        public System.Windows.Forms.RadioButton optInteger;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.Label Label1;
    }
}