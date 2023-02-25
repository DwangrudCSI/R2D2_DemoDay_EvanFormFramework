namespace FRRobotDemoCSharp
{
    partial class frmFRRobotDemo
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFRRobotDemo));
            this.topMenuStrip = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSelectNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuComponents = new System.Windows.Forms.ToolStripMenuItem();
            this.AlarmsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CurrentPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EventsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FeaturesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fTPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IndependentPosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.IOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.numericRegistersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PacketEventsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PipesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PositionRegistersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProgramVariablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProgramsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScatteredAccess = new System.Windows.Forms.ToolStripMenuItem();
            this.SetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StringRegistersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SystemFramesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SystemInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSysVars = new System.Windows.Forms.ToolStripMenuItem();
            this.TasksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VariablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrPing = new System.Windows.Forms.Timer(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.tabPage12 = new System.Windows.Forms.TabPage();
            this.tabPage13 = new System.Windows.Forms.TabPage();
            this.topMenuStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // topMenuStrip
            // 
            this.topMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.topMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem1,
            this.mnuComponents});
            resources.ApplyResources(this.topMenuStrip, "topMenuStrip");
            this.topMenuStrip.Name = "topMenuStrip";
            // 
            // ToolStripMenuItem1
            // 
            this.ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSelectNew,
            this.mnuExit});
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            resources.ApplyResources(this.ToolStripMenuItem1, "ToolStripMenuItem1");
            // 
            // mnuSelectNew
            // 
            this.mnuSelectNew.Name = "mnuSelectNew";
            resources.ApplyResources(this.mnuSelectNew, "mnuSelectNew");
            this.mnuSelectNew.Click += new System.EventHandler(this.mnuSelectNew_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            resources.ApplyResources(this.mnuExit, "mnuExit");
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuComponents
            // 
            this.mnuComponents.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AlarmsToolStripMenuItem,
            this.CurrentPositionToolStripMenuItem,
            this.EventsToolStripMenuItem,
            this.FeaturesToolStripMenuItem,
            this.fTPToolStripMenuItem,
            this.IndependentPosToolStripMenuItem1,
            this.IOToolStripMenuItem,
            this.numericRegistersToolStripMenuItem,
            this.PacketEventsToolStripMenuItem,
            this.PipesToolStripMenuItem,
            this.PositionRegistersToolStripMenuItem,
            this.ProgramVariablesToolStripMenuItem,
            this.ProgramsToolStripMenuItem,
            this.mnuScatteredAccess,
            this.SetupToolStripMenuItem,
            this.StringRegistersToolStripMenuItem,
            this.SystemFramesToolStripMenuItem,
            this.SystemInformationToolStripMenuItem,
            this.mnuSysVars,
            this.TasksToolStripMenuItem,
            this.VariablesToolStripMenuItem});
            this.mnuComponents.Name = "mnuComponents";
            resources.ApplyResources(this.mnuComponents, "mnuComponents");
            this.mnuComponents.Click += new System.EventHandler(this.mnuComponents_Click);
            // 
            // AlarmsToolStripMenuItem
            // 
            this.AlarmsToolStripMenuItem.Name = "AlarmsToolStripMenuItem";
            resources.ApplyResources(this.AlarmsToolStripMenuItem, "AlarmsToolStripMenuItem");
            // 
            // CurrentPositionToolStripMenuItem
            // 
            this.CurrentPositionToolStripMenuItem.Name = "CurrentPositionToolStripMenuItem";
            resources.ApplyResources(this.CurrentPositionToolStripMenuItem, "CurrentPositionToolStripMenuItem");
            // 
            // EventsToolStripMenuItem
            // 
            this.EventsToolStripMenuItem.Name = "EventsToolStripMenuItem";
            resources.ApplyResources(this.EventsToolStripMenuItem, "EventsToolStripMenuItem");
            // 
            // FeaturesToolStripMenuItem
            // 
            this.FeaturesToolStripMenuItem.Name = "FeaturesToolStripMenuItem";
            resources.ApplyResources(this.FeaturesToolStripMenuItem, "FeaturesToolStripMenuItem");
            // 
            // fTPToolStripMenuItem
            // 
            this.fTPToolStripMenuItem.Name = "fTPToolStripMenuItem";
            resources.ApplyResources(this.fTPToolStripMenuItem, "fTPToolStripMenuItem");
            // 
            // IndependentPosToolStripMenuItem1
            // 
            this.IndependentPosToolStripMenuItem1.Name = "IndependentPosToolStripMenuItem1";
            resources.ApplyResources(this.IndependentPosToolStripMenuItem1, "IndependentPosToolStripMenuItem1");
            // 
            // IOToolStripMenuItem
            // 
            this.IOToolStripMenuItem.Name = "IOToolStripMenuItem";
            resources.ApplyResources(this.IOToolStripMenuItem, "IOToolStripMenuItem");
            // 
            // numericRegistersToolStripMenuItem
            // 
            this.numericRegistersToolStripMenuItem.Name = "numericRegistersToolStripMenuItem";
            resources.ApplyResources(this.numericRegistersToolStripMenuItem, "numericRegistersToolStripMenuItem");
            // 
            // PacketEventsToolStripMenuItem
            // 
            this.PacketEventsToolStripMenuItem.Name = "PacketEventsToolStripMenuItem";
            resources.ApplyResources(this.PacketEventsToolStripMenuItem, "PacketEventsToolStripMenuItem");
            // 
            // PipesToolStripMenuItem
            // 
            this.PipesToolStripMenuItem.Name = "PipesToolStripMenuItem";
            resources.ApplyResources(this.PipesToolStripMenuItem, "PipesToolStripMenuItem");
            // 
            // PositionRegistersToolStripMenuItem
            // 
            this.PositionRegistersToolStripMenuItem.Name = "PositionRegistersToolStripMenuItem";
            resources.ApplyResources(this.PositionRegistersToolStripMenuItem, "PositionRegistersToolStripMenuItem");
            // 
            // ProgramVariablesToolStripMenuItem
            // 
            this.ProgramVariablesToolStripMenuItem.Name = "ProgramVariablesToolStripMenuItem";
            resources.ApplyResources(this.ProgramVariablesToolStripMenuItem, "ProgramVariablesToolStripMenuItem");
            // 
            // ProgramsToolStripMenuItem
            // 
            this.ProgramsToolStripMenuItem.Name = "ProgramsToolStripMenuItem";
            resources.ApplyResources(this.ProgramsToolStripMenuItem, "ProgramsToolStripMenuItem");
            // 
            // mnuScatteredAccess
            // 
            this.mnuScatteredAccess.Name = "mnuScatteredAccess";
            resources.ApplyResources(this.mnuScatteredAccess, "mnuScatteredAccess");
            // 
            // SetupToolStripMenuItem
            // 
            this.SetupToolStripMenuItem.Name = "SetupToolStripMenuItem";
            resources.ApplyResources(this.SetupToolStripMenuItem, "SetupToolStripMenuItem");
            // 
            // StringRegistersToolStripMenuItem
            // 
            this.StringRegistersToolStripMenuItem.Name = "StringRegistersToolStripMenuItem";
            resources.ApplyResources(this.StringRegistersToolStripMenuItem, "StringRegistersToolStripMenuItem");
            // 
            // SystemFramesToolStripMenuItem
            // 
            this.SystemFramesToolStripMenuItem.Name = "SystemFramesToolStripMenuItem";
            resources.ApplyResources(this.SystemFramesToolStripMenuItem, "SystemFramesToolStripMenuItem");
            // 
            // SystemInformationToolStripMenuItem
            // 
            this.SystemInformationToolStripMenuItem.Name = "SystemInformationToolStripMenuItem";
            resources.ApplyResources(this.SystemInformationToolStripMenuItem, "SystemInformationToolStripMenuItem");
            // 
            // mnuSysVars
            // 
            this.mnuSysVars.Name = "mnuSysVars";
            resources.ApplyResources(this.mnuSysVars, "mnuSysVars");
            // 
            // TasksToolStripMenuItem
            // 
            this.TasksToolStripMenuItem.Name = "TasksToolStripMenuItem";
            resources.ApplyResources(this.TasksToolStripMenuItem, "TasksToolStripMenuItem");
            // 
            // VariablesToolStripMenuItem
            // 
            this.VariablesToolStripMenuItem.Name = "VariablesToolStripMenuItem";
            resources.ApplyResources(this.VariablesToolStripMenuItem, "VariablesToolStripMenuItem");
            // 
            // tmrPing
            // 
            this.tmrPing.Interval = 200;
            this.tmrPing.Tick += new System.EventHandler(this.tmrPing_Tick);
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            // 
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage8);
            this.tabControl1.Controls.Add(this.tabPage9);
            this.tabControl1.Controls.Add(this.tabPage10);
            this.tabControl1.Controls.Add(this.tabPage11);
            this.tabControl1.Controls.Add(this.tabPage12);
            this.tabControl1.Controls.Add(this.tabPage13);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseClick);
            // 
            // tabPage3
            // 
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            resources.ApplyResources(this.tabPage4, "tabPage4");
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            resources.ApplyResources(this.tabPage5, "tabPage5");
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            resources.ApplyResources(this.tabPage6, "tabPage6");
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            resources.ApplyResources(this.tabPage7, "tabPage7");
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            resources.ApplyResources(this.tabPage8, "tabPage8");
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // tabPage9
            // 
            resources.ApplyResources(this.tabPage9, "tabPage9");
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // tabPage10
            // 
            resources.ApplyResources(this.tabPage10, "tabPage10");
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // tabPage11
            // 
            resources.ApplyResources(this.tabPage11, "tabPage11");
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // tabPage12
            // 
            resources.ApplyResources(this.tabPage12, "tabPage12");
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.UseVisualStyleBackColor = true;
            // 
            // tabPage13
            // 
            resources.ApplyResources(this.tabPage13, "tabPage13");
            this.tabPage13.Name = "tabPage13";
            this.tabPage13.UseVisualStyleBackColor = true;
            // 
            // frmFRRobotDemo
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.topMenuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.topMenuStrip;
            this.Name = "frmFRRobotDemo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFRRobotDemo_FormClosing);
            this.Load += new System.EventHandler(this.frmFRRobotDemo_Load);
            this.topMenuStrip.ResumeLayout(false);
            this.topMenuStrip.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        internal System.Windows.Forms.MenuStrip topMenuStrip;
        internal System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem1;
        internal System.Windows.Forms.ToolStripMenuItem mnuSelectNew;
        internal System.Windows.Forms.ToolStripMenuItem mnuExit;
        internal System.Windows.Forms.ToolStripMenuItem mnuComponents;
        internal System.Windows.Forms.Timer tmrPing;
        internal System.Windows.Forms.ToolStripMenuItem mnuSysVars;
        internal System.Windows.Forms.ToolStripMenuItem mnuScatteredAccess;
        internal System.Windows.Forms.ToolStripMenuItem ProgramsToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem EventsToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem AlarmsToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem StringRegistersToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem PacketEventsToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem IndependentPosToolStripMenuItem1;
        internal System.Windows.Forms.ToolStripMenuItem ProgramVariablesToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem TasksToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem SetupToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem SystemInformationToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem PositionRegistersToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem SystemFramesToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem CurrentPositionToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem PipesToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem IOToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem FeaturesToolStripMenuItem;

        internal System.Windows.Forms.ToolStripMenuItem VariablesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem numericRegistersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fTPToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.TabPage tabPage11;
        private System.Windows.Forms.TabPage tabPage12;
        private System.Windows.Forms.TabPage tabPage13;
    }
}