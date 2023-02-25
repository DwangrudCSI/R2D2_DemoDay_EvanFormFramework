namespace FRRobotDemoCSharp
{
    partial class frmEditStrReg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditStrReg));
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOk = new System.Windows.Forms.Button();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
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
            // frmEditStrReg
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOk);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmEditStrReg";
            this.ShowIcon = false;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmEditStrReg_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        public System.Windows.Forms.Button cmdCancel;
        public System.Windows.Forms.Button cmdOk;
        public System.Windows.Forms.TextBox txtComment;
        public System.Windows.Forms.TextBox txtValue;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.Label Label1;
    }
}