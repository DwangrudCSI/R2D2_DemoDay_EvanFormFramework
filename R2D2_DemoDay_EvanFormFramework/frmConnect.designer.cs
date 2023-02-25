namespace FRRobotDemoCSharp
{
    partial class frmConnect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConnect));
            this.rbByHostName = new System.Windows.Forms.RadioButton();
            this.rbFromRN = new System.Windows.Forms.RadioButton();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtHostName = new System.Windows.Forms.TextBox();
            this.txtRNPath = new System.Windows.Forms.TextBox();
            this.cmdRNBrowse = new System.Windows.Forms.Button();
            this.cmdConnect = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rbByHostName
            // 
            resources.ApplyResources(this.rbByHostName, "rbByHostName");
            this.rbByHostName.Name = "rbByHostName";
            this.rbByHostName.TabStop = true;
            this.rbByHostName.UseVisualStyleBackColor = true;
            // 
            // rbFromRN
            // 
            resources.ApplyResources(this.rbFromRN, "rbFromRN");
            this.rbFromRN.Name = "rbFromRN";
            this.rbFromRN.TabStop = true;
            this.rbFromRN.UseVisualStyleBackColor = true;
            // 
            // Label1
            // 
            resources.ApplyResources(this.Label1, "Label1");
            this.Label1.Name = "Label1";
            // 
            // txtHostName
            // 
            resources.ApplyResources(this.txtHostName, "txtHostName");
            this.txtHostName.Name = "txtHostName";
            this.txtHostName.Enter += new System.EventHandler(this.txtHostName_Enter);
            this.txtHostName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHostName_KeyPress);
            // 
            // txtRNPath
            // 
            resources.ApplyResources(this.txtRNPath, "txtRNPath");
            this.txtRNPath.Name = "txtRNPath";
            this.txtRNPath.Enter += new System.EventHandler(this.txtRNPath_Enter);
            this.txtRNPath.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRNPath_KeyPress);
            // 
            // cmdRNBrowse
            // 
            resources.ApplyResources(this.cmdRNBrowse, "cmdRNBrowse");
            this.cmdRNBrowse.Name = "cmdRNBrowse";
            this.cmdRNBrowse.UseVisualStyleBackColor = true;
            this.cmdRNBrowse.Click += new System.EventHandler(this.cmdRNBrowse_Click);
            // 
            // cmdConnect
            // 
            resources.ApplyResources(this.cmdConnect, "cmdConnect");
            this.cmdConnect.Name = "cmdConnect";
            this.cmdConnect.UseVisualStyleBackColor = true;
            this.cmdConnect.Click += new System.EventHandler(this.cmdConnect_Click);
            // 
            // cmdCancel
            // 
            resources.ApplyResources(this.cmdCancel, "cmdCancel");
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmConnect
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdConnect);
            this.Controls.Add(this.cmdRNBrowse);
            this.Controls.Add(this.txtRNPath);
            this.Controls.Add(this.txtHostName);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.rbFromRN);
            this.Controls.Add(this.rbByHostName);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmConnect";
            this.Load += new System.EventHandler(this.frmConnect_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmConnect_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        internal System.Windows.Forms.RadioButton rbByHostName;
        internal System.Windows.Forms.RadioButton rbFromRN;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtHostName;
        internal System.Windows.Forms.TextBox txtRNPath;
        internal System.Windows.Forms.Button cmdRNBrowse;
        internal System.Windows.Forms.Button cmdConnect;
        internal System.Windows.Forms.Button cmdCancel;
        //internal AxFRRNSelect.AxFRURNSelect FRURNSelect;
    }
}