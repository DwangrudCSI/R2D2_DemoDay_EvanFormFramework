namespace FRRobotDemoCSharp
{
    partial class frmFeatures
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFeatures));
            this.fraFeatureList = new System.Windows.Forms.GroupBox();
            this.lstFeatures = new System.Windows.Forms.ListBox();
            this._lblListColumns_0 = new System.Windows.Forms.Label();
            this._lblListColumns_1 = new System.Windows.Forms.Label();
            this._lblListColumns_2 = new System.Windows.Forms.Label();
            this.lblFeatureCount = new System.Windows.Forms.Label();
            this.fraFeatureQuery = new System.Windows.Forms.GroupBox();
            this.txtFeatureOrderNum = new System.Windows.Forms.TextBox();
            this.cmdFeatureIsValid = new System.Windows.Forms.Button();
            this.cmdGetItem = new System.Windows.Forms.Button();
            this.lblFeatureQuery = new System.Windows.Forms.Label();
            this.lblFeatureYesNo = new System.Windows.Forms.Label();
            this.lblFeatureData = new System.Windows.Forms.Label();
            this._lblListColumns_3 = new System.Windows.Forms.Label();
            this._lblListColumns_4 = new System.Windows.Forms.Label();
            this._lblListColumns_5 = new System.Windows.Forms.Label();
            this.fraFeatureList.SuspendLayout();
            this.fraFeatureQuery.SuspendLayout();
            this.SuspendLayout();
            // 
            // fraFeatureList
            // 
            resources.ApplyResources(this.fraFeatureList, "fraFeatureList");
            this.fraFeatureList.BackColor = System.Drawing.SystemColors.Control;
            this.fraFeatureList.Controls.Add(this.lstFeatures);
            this.fraFeatureList.Controls.Add(this._lblListColumns_0);
            this.fraFeatureList.Controls.Add(this._lblListColumns_1);
            this.fraFeatureList.Controls.Add(this._lblListColumns_2);
            this.fraFeatureList.Controls.Add(this.lblFeatureCount);
            this.fraFeatureList.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fraFeatureList.Name = "fraFeatureList";
            this.fraFeatureList.TabStop = false;
            // 
            // lstFeatures
            // 
            resources.ApplyResources(this.lstFeatures, "lstFeatures");
            this.lstFeatures.BackColor = System.Drawing.SystemColors.Window;
            this.lstFeatures.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstFeatures.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lstFeatures.Name = "lstFeatures";
            // 
            // _lblListColumns_0
            // 
            this._lblListColumns_0.BackColor = System.Drawing.SystemColors.Control;
            this._lblListColumns_0.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this._lblListColumns_0, "_lblListColumns_0");
            this._lblListColumns_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblListColumns_0.Name = "_lblListColumns_0";
            // 
            // _lblListColumns_1
            // 
            this._lblListColumns_1.BackColor = System.Drawing.SystemColors.Control;
            this._lblListColumns_1.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this._lblListColumns_1, "_lblListColumns_1");
            this._lblListColumns_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblListColumns_1.Name = "_lblListColumns_1";
            // 
            // _lblListColumns_2
            // 
            this._lblListColumns_2.BackColor = System.Drawing.SystemColors.Control;
            this._lblListColumns_2.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this._lblListColumns_2, "_lblListColumns_2");
            this._lblListColumns_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblListColumns_2.Name = "_lblListColumns_2";
            // 
            // lblFeatureCount
            // 
            resources.ApplyResources(this.lblFeatureCount, "lblFeatureCount");
            this.lblFeatureCount.BackColor = System.Drawing.SystemColors.Control;
            this.lblFeatureCount.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblFeatureCount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFeatureCount.Name = "lblFeatureCount";
            // 
            // fraFeatureQuery
            // 
            this.fraFeatureQuery.BackColor = System.Drawing.SystemColors.Control;
            this.fraFeatureQuery.Controls.Add(this.txtFeatureOrderNum);
            this.fraFeatureQuery.Controls.Add(this.cmdFeatureIsValid);
            this.fraFeatureQuery.Controls.Add(this.cmdGetItem);
            this.fraFeatureQuery.Controls.Add(this.lblFeatureQuery);
            this.fraFeatureQuery.Controls.Add(this.lblFeatureYesNo);
            this.fraFeatureQuery.Controls.Add(this.lblFeatureData);
            this.fraFeatureQuery.Controls.Add(this._lblListColumns_3);
            this.fraFeatureQuery.Controls.Add(this._lblListColumns_4);
            this.fraFeatureQuery.Controls.Add(this._lblListColumns_5);
            resources.ApplyResources(this.fraFeatureQuery, "fraFeatureQuery");
            this.fraFeatureQuery.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fraFeatureQuery.Name = "fraFeatureQuery";
            this.fraFeatureQuery.TabStop = false;
            // 
            // txtFeatureOrderNum
            // 
            this.txtFeatureOrderNum.AcceptsReturn = true;
            this.txtFeatureOrderNum.BackColor = System.Drawing.SystemColors.Window;
            this.txtFeatureOrderNum.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtFeatureOrderNum, "txtFeatureOrderNum");
            this.txtFeatureOrderNum.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFeatureOrderNum.Name = "txtFeatureOrderNum";
            this.txtFeatureOrderNum.TextChanged += new System.EventHandler(this.txtFeatureOrderNum_TextChanged);
            // 
            // cmdFeatureIsValid
            // 
            this.cmdFeatureIsValid.BackColor = System.Drawing.SystemColors.Control;
            this.cmdFeatureIsValid.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.cmdFeatureIsValid, "cmdFeatureIsValid");
            this.cmdFeatureIsValid.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdFeatureIsValid.Name = "cmdFeatureIsValid";
            this.cmdFeatureIsValid.UseVisualStyleBackColor = false;
            this.cmdFeatureIsValid.Click += new System.EventHandler(this.cmdFeatureIsValid_Click);
            // 
            // cmdGetItem
            // 
            this.cmdGetItem.BackColor = System.Drawing.SystemColors.Control;
            this.cmdGetItem.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.cmdGetItem, "cmdGetItem");
            this.cmdGetItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdGetItem.Name = "cmdGetItem";
            this.cmdGetItem.UseVisualStyleBackColor = false;
            this.cmdGetItem.Click += new System.EventHandler(this.cmdGetItem_Click);
            // 
            // lblFeatureQuery
            // 
            this.lblFeatureQuery.BackColor = System.Drawing.SystemColors.Control;
            this.lblFeatureQuery.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblFeatureQuery, "lblFeatureQuery");
            this.lblFeatureQuery.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFeatureQuery.Name = "lblFeatureQuery";
            // 
            // lblFeatureYesNo
            // 
            this.lblFeatureYesNo.BackColor = System.Drawing.SystemColors.Control;
            this.lblFeatureYesNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFeatureYesNo.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblFeatureYesNo, "lblFeatureYesNo");
            this.lblFeatureYesNo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFeatureYesNo.Name = "lblFeatureYesNo";
            // 
            // lblFeatureData
            // 
            this.lblFeatureData.BackColor = System.Drawing.SystemColors.Control;
            this.lblFeatureData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFeatureData.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lblFeatureData, "lblFeatureData");
            this.lblFeatureData.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFeatureData.Name = "lblFeatureData";
            // 
            // _lblListColumns_3
            // 
            this._lblListColumns_3.BackColor = System.Drawing.SystemColors.Control;
            this._lblListColumns_3.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this._lblListColumns_3, "_lblListColumns_3");
            this._lblListColumns_3.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblListColumns_3.Name = "_lblListColumns_3";
            // 
            // _lblListColumns_4
            // 
            this._lblListColumns_4.BackColor = System.Drawing.SystemColors.Control;
            this._lblListColumns_4.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this._lblListColumns_4, "_lblListColumns_4");
            this._lblListColumns_4.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblListColumns_4.Name = "_lblListColumns_4";
            // 
            // _lblListColumns_5
            // 
            this._lblListColumns_5.BackColor = System.Drawing.SystemColors.Control;
            this._lblListColumns_5.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this._lblListColumns_5, "_lblListColumns_5");
            this._lblListColumns_5.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblListColumns_5.Name = "_lblListColumns_5";
            // 
            // frmFeatures
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fraFeatureList);
            this.Controls.Add(this.fraFeatureQuery);
            this.Name = "frmFeatures";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.frmFeatures_Load);
            this.fraFeatureList.ResumeLayout(false);
            this.fraFeatureQuery.ResumeLayout(false);
            this.fraFeatureQuery.PerformLayout();
            this.ResumeLayout(false);

        }
        public System.Windows.Forms.GroupBox fraFeatureList;
        public System.Windows.Forms.ListBox lstFeatures;
        public System.Windows.Forms.Label _lblListColumns_0;
        public System.Windows.Forms.Label _lblListColumns_1;
        public System.Windows.Forms.Label _lblListColumns_2;
        public System.Windows.Forms.Label lblFeatureCount;
        public System.Windows.Forms.GroupBox fraFeatureQuery;
        public System.Windows.Forms.TextBox txtFeatureOrderNum;
        public System.Windows.Forms.Button cmdFeatureIsValid;
        public System.Windows.Forms.Button cmdGetItem;
        public System.Windows.Forms.Label lblFeatureQuery;
        public System.Windows.Forms.Label lblFeatureYesNo;
        public System.Windows.Forms.Label lblFeatureData;
        public System.Windows.Forms.Label _lblListColumns_3;
        public System.Windows.Forms.Label _lblListColumns_4;
        public System.Windows.Forms.Label _lblListColumns_5;
    }
}