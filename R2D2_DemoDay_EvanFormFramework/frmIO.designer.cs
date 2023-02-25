namespace FRRobotDemoCSharp
{
    partial class frmIO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIO));
            this.treIO = new System.Windows.Forms.TreeView();
            this.tmrRunOnce = new System.Windows.Forms.Timer(this.components);
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.grpIOType = new System.Windows.Forms.GroupBox();
            this.lblCanComplement = new System.Windows.Forms.Label();
            this.lblCanInvert = new System.Windows.Forms.Label();
            this.lblCanSimulate = new System.Windows.Forms.Label();
            this.lblCanConfigure = new System.Windows.Forms.Label();
            this.lblIsBoolean = new System.Windows.Forms.Label();
            this.lblIsInput = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTypeCode = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.grpSignal = new System.Windows.Forms.GroupBox();
            this.Label14 = new System.Windows.Forms.Label();
            this.txtLatencySig = new System.Windows.Forms.TextBox();
            this.cmdStopMonitorSig = new System.Windows.Forms.Button();
            this.cmdStartMonitorSig = new System.Windows.Forms.Button();
            this.Label10 = new System.Windows.Forms.Label();
            this.picMonitor = new System.Windows.Forms.PictureBox();
            this.cmdAddToScattAccess = new System.Windows.Forms.Button();
            this.lblIsOffline = new System.Windows.Forms.Label();
            this.lblIsAssigned = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.cmdOff = new System.Windows.Forms.Button();
            this.cmdOn = new System.Windows.Forms.Button();
            this.chkSignalComplementary = new System.Windows.Forms.CheckBox();
            this.chkSignalPolarity = new System.Windows.Forms.CheckBox();
            this.chkSignalSimulate = new System.Windows.Forms.CheckBox();
            this.cmdUpdateSig = new System.Windows.Forms.Button();
            this.cmdRefreshSig = new System.Windows.Forms.Button();
            this.chkNoRefreshSig = new System.Windows.Forms.CheckBox();
            this.chkNoUpdateSig = new System.Windows.Forms.CheckBox();
            this.txtIOValue = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.txtIOComment = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.picEvent = new System.Windows.Forms.PictureBox();
            this.grpSignals = new System.Windows.Forms.GroupBox();
            this.cmdRefreshSigs = new System.Windows.Forms.Button();
            this.chkNoRefreshSigs = new System.Windows.Forms.CheckBox();
            this.Label15 = new System.Windows.Forms.Label();
            this.txtLatencyAll = new System.Windows.Forms.TextBox();
            this.cmdStopMonitorSigs = new System.Windows.Forms.Button();
            this.cmdStartMonitorSigs = new System.Windows.Forms.Button();
            this.Label16 = new System.Windows.Forms.Label();
            this.PicMonitorSigs = new System.Windows.Forms.PictureBox();
            this.tmrEvent = new System.Windows.Forms.Timer(this.components);
            this.grpConfigs = new System.Windows.Forms.GroupBox();
            this.cmdAddNewConfig = new System.Windows.Forms.Button();
            this.grpConfig = new System.Windows.Forms.GroupBox();
            this.lblConfigIsValid = new System.Windows.Forms.Label();
            this.cmdRemoveConfig = new System.Windows.Forms.Button();
            this.Label23 = new System.Windows.Forms.Label();
            this.txtFirstPhysicalNum = new System.Windows.Forms.TextBox();
            this.Label22 = new System.Windows.Forms.Label();
            this.txtPhysicalType = new System.Windows.Forms.TextBox();
            this.Label21 = new System.Windows.Forms.Label();
            this.txtSlot = new System.Windows.Forms.TextBox();
            this.Label20 = new System.Windows.Forms.Label();
            this.txtRack = new System.Windows.Forms.TextBox();
            this.Label19 = new System.Windows.Forms.Label();
            this.txtNumSignals = new System.Windows.Forms.TextBox();
            this.Label18 = new System.Windows.Forms.Label();
            this.txtFirstLogicalNum = new System.Windows.Forms.TextBox();
            this.Label17 = new System.Windows.Forms.Label();
            this.grpIOType.SuspendLayout();
            this.grpSignal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMonitor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEvent)).BeginInit();
            this.grpSignals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicMonitorSigs)).BeginInit();
            this.grpConfigs.SuspendLayout();
            this.grpConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // treIO
            // 
            resources.ApplyResources(this.treIO, "treIO");
            this.treIO.Name = "treIO";
            this.treIO.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treIO_AfterExpand);
            this.treIO.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treIO_AfterSelect);
            // 
            // tmrRunOnce
            // 
            this.tmrRunOnce.Tick += new System.EventHandler(this.tmrRunOnce_Tick);
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Interval = 500;
            this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
            // 
            // grpIOType
            // 
            resources.ApplyResources(this.grpIOType, "grpIOType");
            this.grpIOType.Controls.Add(this.lblCanComplement);
            this.grpIOType.Controls.Add(this.lblCanInvert);
            this.grpIOType.Controls.Add(this.lblCanSimulate);
            this.grpIOType.Controls.Add(this.lblCanConfigure);
            this.grpIOType.Controls.Add(this.lblIsBoolean);
            this.grpIOType.Controls.Add(this.lblIsInput);
            this.grpIOType.Controls.Add(this.Label7);
            this.grpIOType.Controls.Add(this.Label6);
            this.grpIOType.Controls.Add(this.Label5);
            this.grpIOType.Controls.Add(this.Label4);
            this.grpIOType.Controls.Add(this.Label3);
            this.grpIOType.Controls.Add(this.label2);
            this.grpIOType.Controls.Add(this.lblTypeCode);
            this.grpIOType.Controls.Add(this.Label1);
            this.grpIOType.Name = "grpIOType";
            this.grpIOType.TabStop = false;
            // 
            // lblCanComplement
            // 
            resources.ApplyResources(this.lblCanComplement, "lblCanComplement");
            this.lblCanComplement.Name = "lblCanComplement";
            // 
            // lblCanInvert
            // 
            resources.ApplyResources(this.lblCanInvert, "lblCanInvert");
            this.lblCanInvert.Name = "lblCanInvert";
            // 
            // lblCanSimulate
            // 
            resources.ApplyResources(this.lblCanSimulate, "lblCanSimulate");
            this.lblCanSimulate.Name = "lblCanSimulate";
            // 
            // lblCanConfigure
            // 
            resources.ApplyResources(this.lblCanConfigure, "lblCanConfigure");
            this.lblCanConfigure.Name = "lblCanConfigure";
            // 
            // lblIsBoolean
            // 
            resources.ApplyResources(this.lblIsBoolean, "lblIsBoolean");
            this.lblIsBoolean.Name = "lblIsBoolean";
            // 
            // lblIsInput
            // 
            resources.ApplyResources(this.lblIsInput, "lblIsInput");
            this.lblIsInput.Name = "lblIsInput";
            // 
            // Label7
            // 
            resources.ApplyResources(this.Label7, "Label7");
            this.Label7.Name = "Label7";
            // 
            // Label6
            // 
            resources.ApplyResources(this.Label6, "Label6");
            this.Label6.Name = "Label6";
            // 
            // Label5
            // 
            resources.ApplyResources(this.Label5, "Label5");
            this.Label5.Name = "Label5";
            // 
            // Label4
            // 
            resources.ApplyResources(this.Label4, "Label4");
            this.Label4.Name = "Label4";
            // 
            // Label3
            // 
            resources.ApplyResources(this.Label3, "Label3");
            this.Label3.Name = "Label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // lblTypeCode
            // 
            resources.ApplyResources(this.lblTypeCode, "lblTypeCode");
            this.lblTypeCode.Name = "lblTypeCode";
            // 
            // Label1
            // 
            resources.ApplyResources(this.Label1, "Label1");
            this.Label1.Name = "Label1";
            // 
            // grpSignal
            // 
            resources.ApplyResources(this.grpSignal, "grpSignal");
            this.grpSignal.Controls.Add(this.Label14);
            this.grpSignal.Controls.Add(this.txtLatencySig);
            this.grpSignal.Controls.Add(this.cmdStopMonitorSig);
            this.grpSignal.Controls.Add(this.cmdStartMonitorSig);
            this.grpSignal.Controls.Add(this.Label10);
            this.grpSignal.Controls.Add(this.picMonitor);
            this.grpSignal.Controls.Add(this.cmdAddToScattAccess);
            this.grpSignal.Controls.Add(this.lblIsOffline);
            this.grpSignal.Controls.Add(this.lblIsAssigned);
            this.grpSignal.Controls.Add(this.Label13);
            this.grpSignal.Controls.Add(this.Label12);
            this.grpSignal.Controls.Add(this.cmdOff);
            this.grpSignal.Controls.Add(this.cmdOn);
            this.grpSignal.Controls.Add(this.chkSignalComplementary);
            this.grpSignal.Controls.Add(this.chkSignalPolarity);
            this.grpSignal.Controls.Add(this.chkSignalSimulate);
            this.grpSignal.Controls.Add(this.cmdUpdateSig);
            this.grpSignal.Controls.Add(this.cmdRefreshSig);
            this.grpSignal.Controls.Add(this.chkNoRefreshSig);
            this.grpSignal.Controls.Add(this.chkNoUpdateSig);
            this.grpSignal.Controls.Add(this.txtIOValue);
            this.grpSignal.Controls.Add(this.Label9);
            this.grpSignal.Controls.Add(this.txtIOComment);
            this.grpSignal.Controls.Add(this.Label8);
            this.grpSignal.Name = "grpSignal";
            this.grpSignal.TabStop = false;
            // 
            // Label14
            // 
            resources.ApplyResources(this.Label14, "Label14");
            this.Label14.Name = "Label14";
            // 
            // txtLatencySig
            // 
            resources.ApplyResources(this.txtLatencySig, "txtLatencySig");
            this.txtLatencySig.Name = "txtLatencySig";
            // 
            // cmdStopMonitorSig
            // 
            resources.ApplyResources(this.cmdStopMonitorSig, "cmdStopMonitorSig");
            this.cmdStopMonitorSig.Name = "cmdStopMonitorSig";
            this.cmdStopMonitorSig.UseVisualStyleBackColor = true;
            this.cmdStopMonitorSig.Click += new System.EventHandler(this.cmdStopMonitorSig_Click);
            // 
            // cmdStartMonitorSig
            // 
            resources.ApplyResources(this.cmdStartMonitorSig, "cmdStartMonitorSig");
            this.cmdStartMonitorSig.Name = "cmdStartMonitorSig";
            this.cmdStartMonitorSig.UseVisualStyleBackColor = true;
            this.cmdStartMonitorSig.Click += new System.EventHandler(this.cmdStartMonitorSig_Click);
            // 
            // Label10
            // 
            resources.ApplyResources(this.Label10, "Label10");
            this.Label10.Name = "Label10";
            // 
            // picMonitor
            // 
            resources.ApplyResources(this.picMonitor, "picMonitor");
            this.picMonitor.Name = "picMonitor";
            this.picMonitor.TabStop = false;
            // 
            // cmdAddToScattAccess
            // 

            // 
            // lblIsOffline
            // 
            resources.ApplyResources(this.lblIsOffline, "lblIsOffline");
            this.lblIsOffline.Name = "lblIsOffline";
            // 
            // lblIsAssigned
            // 
            resources.ApplyResources(this.lblIsAssigned, "lblIsAssigned");
            this.lblIsAssigned.Name = "lblIsAssigned";
            // 
            // Label13
            // 
            resources.ApplyResources(this.Label13, "Label13");
            this.Label13.Name = "Label13";
            // 
            // Label12
            // 
            resources.ApplyResources(this.Label12, "Label12");
            this.Label12.Name = "Label12";
            // 
            // cmdOff
            // 
            resources.ApplyResources(this.cmdOff, "cmdOff");
            this.cmdOff.Name = "cmdOff";
            this.cmdOff.UseVisualStyleBackColor = true;
            this.cmdOff.Click += new System.EventHandler(this.cmdOff_Click);
            // 
            // cmdOn
            // 
            resources.ApplyResources(this.cmdOn, "cmdOn");
            this.cmdOn.Name = "cmdOn";
            this.cmdOn.UseVisualStyleBackColor = true;
            this.cmdOn.Click += new System.EventHandler(this.cmdOn_Click);
            // 
            // chkSignalComplementary
            // 
            resources.ApplyResources(this.chkSignalComplementary, "chkSignalComplementary");
            this.chkSignalComplementary.Name = "chkSignalComplementary";
            this.chkSignalComplementary.UseVisualStyleBackColor = true;
            this.chkSignalComplementary.CheckedChanged += new System.EventHandler(this.chkSignalComplementary_CheckedChanged);
            // 
            // chkSignalPolarity
            // 
            resources.ApplyResources(this.chkSignalPolarity, "chkSignalPolarity");
            this.chkSignalPolarity.Name = "chkSignalPolarity";
            this.chkSignalPolarity.UseVisualStyleBackColor = true;
            this.chkSignalPolarity.CheckedChanged += new System.EventHandler(this.chkSignalPolarity_CheckedChanged);
            // 
            // chkSignalSimulate
            // 
            resources.ApplyResources(this.chkSignalSimulate, "chkSignalSimulate");
            this.chkSignalSimulate.Name = "chkSignalSimulate";
            this.chkSignalSimulate.UseVisualStyleBackColor = true;
            this.chkSignalSimulate.CheckedChanged += new System.EventHandler(this.chkSignalSimulate_CheckedChanged);
            // 
            // cmdUpdateSig
            // 
            resources.ApplyResources(this.cmdUpdateSig, "cmdUpdateSig");
            this.cmdUpdateSig.Name = "cmdUpdateSig";
            this.cmdUpdateSig.UseVisualStyleBackColor = true;
            this.cmdUpdateSig.Click += new System.EventHandler(this.cmdUpdateSig_Click);
            // 
            // cmdRefreshSig
            // 
            resources.ApplyResources(this.cmdRefreshSig, "cmdRefreshSig");
            this.cmdRefreshSig.Name = "cmdRefreshSig";
            this.cmdRefreshSig.UseVisualStyleBackColor = true;
            this.cmdRefreshSig.Click += new System.EventHandler(this.cmdRefreshSig_Click);
            // 
            // chkNoRefreshSig
            // 
            resources.ApplyResources(this.chkNoRefreshSig, "chkNoRefreshSig");
            this.chkNoRefreshSig.Name = "chkNoRefreshSig";
            this.chkNoRefreshSig.UseVisualStyleBackColor = true;
            this.chkNoRefreshSig.Click += new System.EventHandler(this.chkNoRefreshSig_Click);
            // 
            // chkNoUpdateSig
            // 
            resources.ApplyResources(this.chkNoUpdateSig, "chkNoUpdateSig");
            this.chkNoUpdateSig.Name = "chkNoUpdateSig";
            this.chkNoUpdateSig.UseVisualStyleBackColor = true;
            this.chkNoUpdateSig.Click += new System.EventHandler(this.chkNoUpdateSig_Click);
            // 
            // txtIOValue
            // 
            resources.ApplyResources(this.txtIOValue, "txtIOValue");
            this.txtIOValue.Name = "txtIOValue";
            this.txtIOValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIOValue_KeyPress);
            // 
            // Label9
            // 
            resources.ApplyResources(this.Label9, "Label9");
            this.Label9.Name = "Label9";
            // 
            // txtIOComment
            // 
            resources.ApplyResources(this.txtIOComment, "txtIOComment");
            this.txtIOComment.Name = "txtIOComment";
            this.txtIOComment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIOComment_KeyPress);
            this.txtIOComment.Leave += new System.EventHandler(this.txtIOComment_Leave);
            // 
            // Label8
            // 
            resources.ApplyResources(this.Label8, "Label8");
            this.Label8.Name = "Label8";
            // 
            // Label11
            // 
            resources.ApplyResources(this.Label11, "Label11");
            this.Label11.Name = "Label11";
            // 
            // picEvent
            // 
            resources.ApplyResources(this.picEvent, "picEvent");
            this.picEvent.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.picEvent.Name = "picEvent";
            this.picEvent.TabStop = false;
            // 
            // grpSignals
            // 
            resources.ApplyResources(this.grpSignals, "grpSignals");
            this.grpSignals.Controls.Add(this.cmdRefreshSigs);
            this.grpSignals.Controls.Add(this.chkNoRefreshSigs);
            this.grpSignals.Controls.Add(this.Label15);
            this.grpSignals.Controls.Add(this.txtLatencyAll);
            this.grpSignals.Controls.Add(this.cmdStopMonitorSigs);
            this.grpSignals.Controls.Add(this.cmdStartMonitorSigs);
            this.grpSignals.Controls.Add(this.Label16);
            this.grpSignals.Controls.Add(this.PicMonitorSigs);
            this.grpSignals.Name = "grpSignals";
            this.grpSignals.TabStop = false;
            // 
            // cmdRefreshSigs
            // 
            resources.ApplyResources(this.cmdRefreshSigs, "cmdRefreshSigs");
            this.cmdRefreshSigs.Name = "cmdRefreshSigs";
            this.cmdRefreshSigs.UseVisualStyleBackColor = true;
            this.cmdRefreshSigs.Click += new System.EventHandler(this.cmdRefreshSigs_Click);
            // 
            // chkNoRefreshSigs
            // 
            resources.ApplyResources(this.chkNoRefreshSigs, "chkNoRefreshSigs");
            this.chkNoRefreshSigs.Name = "chkNoRefreshSigs";
            this.chkNoRefreshSigs.UseVisualStyleBackColor = true;
            this.chkNoRefreshSigs.Click += new System.EventHandler(this.chkNoRefreshSigs_Click);
            // 
            // Label15
            // 
            resources.ApplyResources(this.Label15, "Label15");
            this.Label15.Name = "Label15";
            // 
            // txtLatencyAll
            // 
            resources.ApplyResources(this.txtLatencyAll, "txtLatencyAll");
            this.txtLatencyAll.Name = "txtLatencyAll";
            // 
            // cmdStopMonitorSigs
            // 
            resources.ApplyResources(this.cmdStopMonitorSigs, "cmdStopMonitorSigs");
            this.cmdStopMonitorSigs.Name = "cmdStopMonitorSigs";
            this.cmdStopMonitorSigs.UseVisualStyleBackColor = true;
            this.cmdStopMonitorSigs.Click += new System.EventHandler(this.cmdStopMonitorSigs_Click);
            // 
            // cmdStartMonitorSigs
            // 
            resources.ApplyResources(this.cmdStartMonitorSigs, "cmdStartMonitorSigs");
            this.cmdStartMonitorSigs.Name = "cmdStartMonitorSigs";
            this.cmdStartMonitorSigs.UseVisualStyleBackColor = true;
            this.cmdStartMonitorSigs.Click += new System.EventHandler(this.cmdStartMonitorSigs_Click);
            // 
            // Label16
            // 
            resources.ApplyResources(this.Label16, "Label16");
            this.Label16.Name = "Label16";
            // 
            // PicMonitorSigs
            // 
            resources.ApplyResources(this.PicMonitorSigs, "PicMonitorSigs");
            this.PicMonitorSigs.Name = "PicMonitorSigs";
            this.PicMonitorSigs.TabStop = false;
            // 
            // tmrEvent
            // 
            this.tmrEvent.Interval = 500;
            this.tmrEvent.Tick += new System.EventHandler(this.tmrEvent_Tick);
            // 
            // grpConfigs
            // 
            resources.ApplyResources(this.grpConfigs, "grpConfigs");
            this.grpConfigs.Controls.Add(this.cmdAddNewConfig);
            this.grpConfigs.Name = "grpConfigs";
            this.grpConfigs.TabStop = false;
            // 
            // cmdAddNewConfig
            // 
            resources.ApplyResources(this.cmdAddNewConfig, "cmdAddNewConfig");
            this.cmdAddNewConfig.Name = "cmdAddNewConfig";
            this.cmdAddNewConfig.UseVisualStyleBackColor = true;
            this.cmdAddNewConfig.Click += new System.EventHandler(this.cmdAddNewConfig_Click);
            // 
            // grpConfig
            // 
            resources.ApplyResources(this.grpConfig, "grpConfig");
            this.grpConfig.Controls.Add(this.lblConfigIsValid);
            this.grpConfig.Controls.Add(this.cmdRemoveConfig);
            this.grpConfig.Controls.Add(this.Label23);
            this.grpConfig.Controls.Add(this.txtFirstPhysicalNum);
            this.grpConfig.Controls.Add(this.Label22);
            this.grpConfig.Controls.Add(this.txtPhysicalType);
            this.grpConfig.Controls.Add(this.Label21);
            this.grpConfig.Controls.Add(this.txtSlot);
            this.grpConfig.Controls.Add(this.Label20);
            this.grpConfig.Controls.Add(this.txtRack);
            this.grpConfig.Controls.Add(this.Label19);
            this.grpConfig.Controls.Add(this.txtNumSignals);
            this.grpConfig.Controls.Add(this.Label18);
            this.grpConfig.Controls.Add(this.txtFirstLogicalNum);
            this.grpConfig.Controls.Add(this.Label17);
            this.grpConfig.Name = "grpConfig";
            this.grpConfig.TabStop = false;
            // 
            // lblConfigIsValid
            // 
            resources.ApplyResources(this.lblConfigIsValid, "lblConfigIsValid");
            this.lblConfigIsValid.Name = "lblConfigIsValid";
            // 
            // cmdRemoveConfig
            // 
            resources.ApplyResources(this.cmdRemoveConfig, "cmdRemoveConfig");
            this.cmdRemoveConfig.Name = "cmdRemoveConfig";
            this.cmdRemoveConfig.UseVisualStyleBackColor = true;
            this.cmdRemoveConfig.Click += new System.EventHandler(this.cmdRemoveConfig_Click);
            // 
            // Label23
            // 
            resources.ApplyResources(this.Label23, "Label23");
            this.Label23.Name = "Label23";
            // 
            // txtFirstPhysicalNum
            // 
            resources.ApplyResources(this.txtFirstPhysicalNum, "txtFirstPhysicalNum");
            this.txtFirstPhysicalNum.Name = "txtFirstPhysicalNum";
            this.txtFirstPhysicalNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFirstPhysicalNum_KeyPress);
            this.txtFirstPhysicalNum.Leave += new System.EventHandler(this.txtFirstPhysicalNum_Leave);
            // 
            // Label22
            // 
            resources.ApplyResources(this.Label22, "Label22");
            this.Label22.Name = "Label22";
            // 
            // txtPhysicalType
            // 
            resources.ApplyResources(this.txtPhysicalType, "txtPhysicalType");
            this.txtPhysicalType.Name = "txtPhysicalType";
            this.txtPhysicalType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhysicalType_KeyPress);
            this.txtPhysicalType.Leave += new System.EventHandler(this.txtPhysicalType_Leave);
            // 
            // Label21
            // 
            resources.ApplyResources(this.Label21, "Label21");
            this.Label21.Name = "Label21";
            // 
            // txtSlot
            // 
            resources.ApplyResources(this.txtSlot, "txtSlot");
            this.txtSlot.Name = "txtSlot";
            this.txtSlot.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSlot_KeyPress);
            this.txtSlot.Leave += new System.EventHandler(this.txtSlot_Leave);
            // 
            // Label20
            // 
            resources.ApplyResources(this.Label20, "Label20");
            this.Label20.Name = "Label20";
            // 
            // txtRack
            // 
            resources.ApplyResources(this.txtRack, "txtRack");
            this.txtRack.Name = "txtRack";
            this.txtRack.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRack_KeyPress);
            this.txtRack.Leave += new System.EventHandler(this.txtRack_Leave);
            // 
            // Label19
            // 
            resources.ApplyResources(this.Label19, "Label19");
            this.Label19.Name = "Label19";
            // 
            // txtNumSignals
            // 
            resources.ApplyResources(this.txtNumSignals, "txtNumSignals");
            this.txtNumSignals.Name = "txtNumSignals";
            this.txtNumSignals.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumSignals_KeyPress);
            this.txtNumSignals.Leave += new System.EventHandler(this.txtNumSignals_Leave);
            // 
            // Label18
            // 
            resources.ApplyResources(this.Label18, "Label18");
            this.Label18.Name = "Label18";
            // 
            // txtFirstLogicalNum
            // 
            resources.ApplyResources(this.txtFirstLogicalNum, "txtFirstLogicalNum");
            this.txtFirstLogicalNum.Name = "txtFirstLogicalNum";
            this.txtFirstLogicalNum.TextChanged += new System.EventHandler(this.txtFirstLogicalNum_TextChanged);
            // 
            // Label17
            // 
            resources.ApplyResources(this.Label17, "Label17");
            this.Label17.Name = "Label17";
            // 
            // frmIO
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpSignal);
            this.Controls.Add(this.grpSignals);
            this.Controls.Add(this.picEvent);
            this.Controls.Add(this.Label11);
            this.Controls.Add(this.treIO);
            this.Controls.Add(this.grpIOType);
            this.Controls.Add(this.grpConfig);
            this.Controls.Add(this.grpConfigs);
            this.Name = "frmIO";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmIO_FormClosing);
            this.Load += new System.EventHandler(this.frmIO_Load);
            this.grpIOType.ResumeLayout(false);
            this.grpIOType.PerformLayout();
            this.grpSignal.ResumeLayout(false);
            this.grpSignal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMonitor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEvent)).EndInit();
            this.grpSignals.ResumeLayout(false);
            this.grpSignals.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicMonitorSigs)).EndInit();
            this.grpConfigs.ResumeLayout(false);
            this.grpConfig.ResumeLayout(false);
            this.grpConfig.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        internal System.Windows.Forms.TreeView treIO;
        internal System.Windows.Forms.Timer tmrRunOnce;
        internal System.Windows.Forms.Timer tmrUpdate;
        internal System.Windows.Forms.GroupBox grpIOType;
        internal System.Windows.Forms.Label lblCanComplement;
        internal System.Windows.Forms.Label lblCanInvert;
        internal System.Windows.Forms.Label lblCanSimulate;
        internal System.Windows.Forms.Label lblCanConfigure;
        internal System.Windows.Forms.Label lblIsBoolean;
        internal System.Windows.Forms.Label lblIsInput;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label lblTypeCode;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.GroupBox grpSignal;
        internal System.Windows.Forms.TextBox txtIOComment;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.TextBox txtIOValue;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.CheckBox chkNoRefreshSig;
        internal System.Windows.Forms.CheckBox chkNoUpdateSig;
        internal System.Windows.Forms.Button cmdRefreshSig;
        internal System.Windows.Forms.Button cmdUpdateSig;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.PictureBox picEvent;
        internal System.Windows.Forms.CheckBox chkSignalSimulate;
        internal System.Windows.Forms.CheckBox chkSignalPolarity;
        internal System.Windows.Forms.CheckBox chkSignalComplementary;
        internal System.Windows.Forms.Button cmdOff;
        internal System.Windows.Forms.Button cmdOn;
        internal System.Windows.Forms.Label lblIsOffline;
        internal System.Windows.Forms.Label lblIsAssigned;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.Button cmdAddToScattAccess;
        internal System.Windows.Forms.Button cmdStopMonitorSig;
        internal System.Windows.Forms.Button cmdStartMonitorSig;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.PictureBox picMonitor;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.TextBox txtLatencySig;
        internal System.Windows.Forms.GroupBox grpSignals;
        internal System.Windows.Forms.Label Label15;
        internal System.Windows.Forms.TextBox txtLatencyAll;
        internal System.Windows.Forms.Button cmdStopMonitorSigs;
        internal System.Windows.Forms.Button cmdStartMonitorSigs;
        internal System.Windows.Forms.Label Label16;
        internal System.Windows.Forms.PictureBox PicMonitorSigs;
        internal System.Windows.Forms.Timer tmrEvent;
        internal System.Windows.Forms.GroupBox grpConfigs;
        internal System.Windows.Forms.Button cmdAddNewConfig;
        internal System.Windows.Forms.GroupBox grpConfig;
        internal System.Windows.Forms.Button cmdRemoveConfig;
        internal System.Windows.Forms.Label Label23;
        internal System.Windows.Forms.TextBox txtFirstPhysicalNum;
        internal System.Windows.Forms.Label Label22;
        internal System.Windows.Forms.TextBox txtPhysicalType;
        internal System.Windows.Forms.Label Label21;
        internal System.Windows.Forms.TextBox txtSlot;
        internal System.Windows.Forms.Label Label20;
        internal System.Windows.Forms.TextBox txtRack;
        internal System.Windows.Forms.Label Label19;
        internal System.Windows.Forms.TextBox txtNumSignals;
        internal System.Windows.Forms.Label Label18;
        internal System.Windows.Forms.TextBox txtFirstLogicalNum;
        internal System.Windows.Forms.Label Label17;
        internal System.Windows.Forms.Button cmdRefreshSigs;
        internal System.Windows.Forms.CheckBox chkNoRefreshSigs;
        internal System.Windows.Forms.Label lblConfigIsValid;
    }
}