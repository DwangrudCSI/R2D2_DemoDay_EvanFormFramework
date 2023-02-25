namespace FRRobotDemoCSharp
{
    partial class frmEvents
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEvents));
            this.cmdClear = new System.Windows.Forms.Button();
            this.lstViewEvents = new System.Windows.Forms.ListView();
            this.Events = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // cmdClear
            // 
            resources.ApplyResources(this.cmdClear, "cmdClear");
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.UseVisualStyleBackColor = true;
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // lstViewEvents
            // 
            resources.ApplyResources(this.lstViewEvents, "lstViewEvents");
            this.lstViewEvents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Events});
            this.lstViewEvents.FullRowSelect = true;
            this.lstViewEvents.Name = "lstViewEvents";
            this.lstViewEvents.UseCompatibleStateImageBehavior = false;
            this.lstViewEvents.View = System.Windows.Forms.View.Details;
            // 
            // Events
            // 
            resources.ApplyResources(this.Events, "Events");
            // 
            // frmEvents
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstViewEvents);
            this.Controls.Add(this.cmdClear);
            this.Name = "frmEvents";
            this.ShowIcon = false;
            this.Resize += new System.EventHandler(this.frmEvents_Resize);
            this.ResumeLayout(false);

        }
        internal System.Windows.Forms.Button cmdClear;
        private System.Windows.Forms.ListView lstViewEvents;
        private System.Windows.Forms.ColumnHeader Events;
    }
}