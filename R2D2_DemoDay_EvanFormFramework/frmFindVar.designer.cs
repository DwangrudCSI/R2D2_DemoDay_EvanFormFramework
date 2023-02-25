namespace FRRobotDemoCSharp
{
    partial class frmFindVar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFindVar));
            this.txtFindWhat = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.cmdFindNext = new System.Windows.Forms.Button();
            this.chkMatchWholeWord = new System.Windows.Forms.CheckBox();
            this.chkFindInName = new System.Windows.Forms.CheckBox();
            this.chkFindInValue = new System.Windows.Forms.CheckBox();
            this.lblProgress = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtFindWhat
            // 
            this.txtFindWhat.AcceptsReturn = true;
            this.txtFindWhat.BackColor = System.Drawing.SystemColors.Window;
            this.txtFindWhat.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtFindWhat, "txtFindWhat");
            this.txtFindWhat.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFindWhat.Name = "txtFindWhat";
            this.txtFindWhat.TextChanged += new System.EventHandler(this.txtFindWhat_TextChanged);
            this.txtFindWhat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFindWhat_KeyPress);
            // 
            // Label1
            // 
            resources.ApplyResources(this.Label1, "Label1");
            this.Label1.Name = "Label1";
            // 
            // cmdFindNext
            // 
            this.cmdFindNext.BackColor = System.Drawing.SystemColors.Control;
            this.cmdFindNext.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.cmdFindNext, "cmdFindNext");
            this.cmdFindNext.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdFindNext.Name = "cmdFindNext";
            this.cmdFindNext.UseVisualStyleBackColor = false;
            this.cmdFindNext.Click += new System.EventHandler(this.cmdFindNext_Click);
            // 
            // chkMatchWholeWord
            // 
            this.chkMatchWholeWord.BackColor = System.Drawing.SystemColors.Control;
            this.chkMatchWholeWord.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.chkMatchWholeWord, "chkMatchWholeWord");
            this.chkMatchWholeWord.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkMatchWholeWord.Name = "chkMatchWholeWord";
            this.chkMatchWholeWord.UseVisualStyleBackColor = false;
            // 
            // chkFindInName
            // 
            this.chkFindInName.BackColor = System.Drawing.SystemColors.Control;
            this.chkFindInName.Checked = true;
            this.chkFindInName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFindInName.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.chkFindInName, "chkFindInName");
            this.chkFindInName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkFindInName.Name = "chkFindInName";
            this.chkFindInName.UseVisualStyleBackColor = false;
            // 
            // chkFindInValue
            // 
            this.chkFindInValue.BackColor = System.Drawing.SystemColors.Control;
            this.chkFindInValue.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.chkFindInValue, "chkFindInValue");
            this.chkFindInValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkFindInValue.Name = "chkFindInValue";
            this.chkFindInValue.UseVisualStyleBackColor = false;
            // 
            // lblProgress
            // 
            this.lblProgress.BackColor = System.Drawing.SystemColors.Control;
            this.lblProgress.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblProgress, "lblProgress");
            this.lblProgress.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblProgress.Name = "lblProgress";
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
            // frmFindVar
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.chkFindInValue);
            this.Controls.Add(this.chkFindInName);
            this.Controls.Add(this.chkMatchWholeWord);
            this.Controls.Add(this.cmdFindNext);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.txtFindWhat);
            this.MaximizeBox = false;
            this.Name = "frmFindVar";
            this.Load += new System.EventHandler(this.frmFindVar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        public System.Windows.Forms.TextBox txtFindWhat;
        internal System.Windows.Forms.Label Label1;
        public System.Windows.Forms.Button cmdFindNext;
        public System.Windows.Forms.CheckBox chkMatchWholeWord;
        public System.Windows.Forms.CheckBox chkFindInName;
        public System.Windows.Forms.CheckBox chkFindInValue;
        public System.Windows.Forms.Label lblProgress;
        public System.Windows.Forms.Button cmdCancel;
    }
}