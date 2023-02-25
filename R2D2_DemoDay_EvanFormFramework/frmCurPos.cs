// Module: frmCurPos
//
// Description:
//   Display the current position
//
// Author: Tri Quach
//         FANUC America Corporation 
//         29700 Kohoutek Way
//         Union City, CA 94587
//
// Modification history:
// 05-Oct-2015 Quach    Adapted from the VB.Net version

using FRRobot;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace FRRobotDemoCSharp
{
    public partial class frmCurPos: Form
    {

        #region "Declarations"

        //*************************************************************************
        //                           Declarations
        //*************************************************************************
        private int mintNumGroups;

        private int mintGrpNum;
        private FRCCurPosition mobjCurPos;

        private FRCCurGroupPosition mobjCurGrpPos;
        private bool mblnIgnoreEvents;

        private bool mblnUpdateDisplay = false;

        private TextBox[] txtJoint = new TextBox[9];

        private Label[] lblJointNum = new Label[9];
        private TextBox[] txtWorld = new TextBox[6];
        private TextBox[] txtWorldExtAxes = new TextBox[3];

        private Label[] lblWorldExtAxes = new Label[3];
        private TextBox[] txtUser = new TextBox[6];
        private TextBox[] txtUserExtAxes = new TextBox[3];

        private Label[] lblUserExtAxes = new Label[3];
        private const int Joint_tab = 0;
        private const int World_tab = 1;

        private const int User_tab = 2;

        FRRobotDemo FRRobotDemo;

        #endregion

        #region "Public Properties and Methods"

        //*************************************************************************
        //                      Public Properties and Methods
        //*************************************************************************

        #endregion

        #region "Form Maintenance"

        //*************************************************************************
        //                         Form Maintenance
        //*************************************************************************

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // Constuctor
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        public frmCurPos()
        {
            // This call is required by the designer.
            InitializeComponent();

            if (FRRobotDemo == null)
                FRRobotDemo = new FRRobotDemo();

            // Add any initialization after the InitializeComponent() call.
            CreateJointControlArrays();
            CreateWorldControlArrays();
            CreateUserControlArrays();

            //set min/max size
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // frmCurPos_Load
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void frmCurPos_Load(object sender, EventArgs e)
        {
            int intGrpNum;

            try
            {
                // Don't want to be responding to tabsCurPos or cboGroupSel change events
                // before everything is initialized.
                mblnIgnoreEvents = true;

                mobjCurPos = FRRobotDemo.gobjRobot.CurPosition;
                mintNumGroups = mobjCurPos.NumGroups;

                cboGroupSel.Items.Clear();
                for (intGrpNum = 1; intGrpNum <= mintNumGroups; intGrpNum++)
                {
                    cboGroupSel.Items.Add(intGrpNum.ToString());
                }

                // Set up for Joint display of group 1.
                // This will trigger events that select the appropriate group and display type
                tabsCurPos.SelectedIndex = Joint_tab;
                cboGroupSel.SelectedIndex = 0;
                mblnIgnoreEvents = false;
                cboGroupSel_SelectedIndexChanged(cboGroupSel, new EventArgs());

                tmrUpdateDisplay.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "frmCurPos_Load");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // frmCurPos_FormClosing
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void frmCurPos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mobjCurGrpPos != null)
                mobjCurGrpPos.Change -= mobjCurGrpPos_Change;
            mobjCurGrpPos = null;
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: tmrUpdateDisplay_Tick
        //
        // (Re)Populate the display on the timer tick so it is always done 
        // on the main form thread.
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void tmrUpdateDisplay_Tick(object sender, EventArgs e)
        {
            if (mblnUpdateDisplay)
            {
                if (int.Parse(txtLatency.Text) < 20)
                    txtLatency.Text = "20";
                try
                {
                    switch (tabsCurPos.SelectedIndex)
                    {
                        case Joint_tab:
                            RefreshJointTab();
                            break;
                        case World_tab:
                            RefreshWorldTab();
                            break;
                        case User_tab:
                            RefreshUserTab();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "tmrUpdateDisplay_Tick");
                }
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: tmrBlinkUpdate_Timer
        //
        // turn off the change light
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void tmrBlinkUpdate_Tick(object sender, EventArgs e)
        {
            picUpdate.BackColor = Color.FromArgb(128, 128, 0);
            tmrBlinkUpdate.Enabled = false;
        }

        #endregion

        #region "User Input Events"

        //*************************************************************************
        //                        User Input Events
        //*************************************************************************

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cboGroupSel_SelectedIndexChanged
        //
        // Changing the group selection
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cboGroupSel_SelectedIndexChanged(object sender, EventArgs e)
        {
            FRRobot.FRECurPositionConstants enuType;

            if (mblnIgnoreEvents)
                return;

            mintGrpNum = cboGroupSel.SelectedIndex + 1;

            switch (tabsCurPos.SelectedIndex)
            {
                case Joint_tab:
                    enuType = FRRobot.FRECurPositionConstants.frJointDisplayType;
                    break;
                case World_tab:
                    enuType = FRRobot.FRECurPositionConstants.frWorldDisplayType;
                    break;
                case User_tab:
                    enuType = FRRobot.FRECurPositionConstants.frUserDisplayType;
                    break;
                default:
                    enuType = FRRobot.FRECurPositionConstants.frJointDisplayType;
                    break;
            }
            //get a new CURPOS type, don't just convert old
            mobjCurGrpPos = mobjCurPos.Group[(short)mintGrpNum, enuType];
            //unsubscribe event if already subscribed
            mobjCurGrpPos.Change -= mobjCurGrpPos_Change;
            //subscribe event handlers
            mobjCurGrpPos.Change += mobjCurGrpPos_Change;

            if (mobjCurGrpPos.IsMonitoring)
            {
                picMonitor.BackColor = Color.FromArgb(255, 0, 0);
            }
            else
            {
                picMonitor.BackColor = Color.FromArgb(128, 0, 0);
            }
            mblnUpdateDisplay = true;
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: tabsCurPos_SelectedIndexChanged
        //
        // Changing the output display format selection
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void tabsCurPos_SelectedIndexChanged(object sender, EventArgs e)
        {
            mblnUpdateDisplay = true;
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdStartMon_Click
        //
        // Tell the controller to start monitoring this position
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdStartMon_Click(object sender, EventArgs e)
        {
            try
            {
                picMonitor.BackColor = Color.FromArgb(255, 0, 0);
                if (int.Parse(txtLatency.Text) < 20)
                {
                    txtLatency.Text = "20";
                    MessageBox.Show("Minimum interval is 20mS", "cmdStartMon_Click");
                }
                tmrUpdateDisplay.Interval = int.Parse(txtLatency.Text) + 50; //lag a bit behind
                mobjCurGrpPos.StartMonitor(tmrUpdateDisplay.Interval);
                mblnUpdateDisplay = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cmdStartMon_Click");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdStopMon_Click
        //
        // Tell the controller to Stop monitoring this position
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdStopMon_Click(object sender, EventArgs e)
        {
            try
            {
                mobjCurGrpPos.StopMonitor();
                picMonitor.BackColor = Color.FromArgb(128, 0, 0);
                mblnUpdateDisplay = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cmdStopMon_Click");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdSetCurPosAsCopySource_Click
        //
        // Sets this as the PositionCopySource
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdSetCurPosAsCopySource_Click(object sender, EventArgs e)
        {
            try
            {
                FRRobotDemo.gobjPositionCopySource = mobjCurPos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cmdSetCurPosAsCopySource_Click");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdSetCurGrpPosAsCopySource_Click
        //
        // Sets this as the PositionCopySource
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdSetCurGrpPosAsCopySource_Click(object sender, EventArgs e)
        {
            try
            {
                FRRobotDemo.gobjPositionCopySource = mobjCurGrpPos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cmdSetCurGrpPosAsCopySource_Click");
            }
        }

        #endregion

        #region "Robot Server Events"

        //*************************************************************************
        //                        Robot Server Events
        //*************************************************************************

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: mobjCurGrpPos_Change
        //
        // Controller is monitoring curpos and it changed.
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private delegate void CurPosChangeDelegate();
        private void mobjCurGrpPos_Change()
        {

            if (this.InvokeRequired)
            {
                CurPosChangeDelegate HandleCurPosChange = new CurPosChangeDelegate(mobjCurGrpPos_Change);
                this.BeginInvoke(HandleCurPosChange);
            }
            else
            {
                FRRobotDemo.LogEvent(this, "mobjCurGrpPos_Change");
                picUpdate.BackColor = Color.FromArgb(255, 255, 0);
                tmrBlinkUpdate.Enabled = true;
                mblnUpdateDisplay = true;
            }
        }

        #endregion

        #region "Utility Routines"

        //*************************************************************************
        //                        Utility Routines
        //*************************************************************************

        #endregion

        #region Everything to do with the Joint Tab

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: CreateJointControlArrays
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void CreateJointControlArrays()
        {
            txtJoint[0] = txtJoint_0;
            txtJoint[1] = txtJoint_1;
            txtJoint[2] = txtJoint_2;
            txtJoint[3] = txtJoint_3;
            txtJoint[4] = txtJoint_4;
            txtJoint[5] = txtJoint_5;
            txtJoint[6] = txtJoint_6;
            txtJoint[7] = txtJoint_7;
            txtJoint[8] = txtJoint_8;

            lblJointNum[0] = lblJointNum_0;
            lblJointNum[1] = lblJointNum_1;
            lblJointNum[2] = lblJointNum_2;
            lblJointNum[3] = lblJointNum_3;
            lblJointNum[4] = lblJointNum_4;
            lblJointNum[5] = lblJointNum_5;
            lblJointNum[6] = lblJointNum_6;
            lblJointNum[7] = lblJointNum_7;
            lblJointNum[8] = lblJointNum_8;
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: RefreshJointTab
        //
        // (Re)Populate the display boxes in the Joint tab
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void RefreshJointTab()
        {
            FRCJoint objJoint;
            int intJointNum;
            double dblAngle;

            try
            {
                objJoint = mobjCurGrpPos.Formats[FRETypeCodeConstants.frJoint];

                // Set the Joint values
                for (intJointNum = 1; intJointNum <= objJoint.Count; intJointNum++)
                {
                    dblAngle = objJoint[(short)intJointNum];
                    txtJoint[intJointNum - 1].Text = string.Format("{0:N2}", dblAngle);
                    txtJoint[intJointNum - 1].Visible = true;
                    lblJointNum[intJointNum - 1].Visible = true;
                }

                // Hide the unused items.
                for (intJointNum = objJoint.Count + 1; intJointNum <= 9; intJointNum++)
                {
                    txtJoint[intJointNum - 1].Visible = false;
                    lblJointNum[intJointNum - 1].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "RefreshJointTab");
            }
        }

        #endregion

        #region Everything to do with the World Tab

        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //                       Everything to do with the World Tab
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: CreateXyzWprControlArrays
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void CreateWorldControlArrays()
        {
            txtWorld[0] = txtWorld_0;
            txtWorld[1] = txtWorld_1;
            txtWorld[2] = txtWorld_2;
            txtWorld[3] = txtWorld_3;
            txtWorld[4] = txtWorld_4;
            txtWorld[5] = txtWorld_5;

            txtWorldExtAxes[0] = txtWorldExtAxes_0;
            txtWorldExtAxes[1] = txtWorldExtAxes_1;
            txtWorldExtAxes[2] = txtWorldExtAxes_2;

            lblWorldExtAxes[0] = lblWorldExtAxes_0;
            lblWorldExtAxes[1] = lblWorldExtAxes_1;
            lblWorldExtAxes[2] = lblWorldExtAxes_2;
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: RefreshXyzwprTab
        //
        // (Re)Populate the display boxes in the Xyzwpr tab
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void RefreshWorldTab()
        {
            FRCXyzWpr objXyzWpr;
            int lLcv;

            try
            {
                objXyzWpr = mobjCurGrpPos.Formats[FRETypeCodeConstants.frExtXyzWpr];

                // Setup to show ext axes or not
                for (lLcv = 0; lLcv <= 2; lLcv++)
                {
                    lblWorldExtAxes[lLcv].Visible = false;
                    txtWorldExtAxes[lLcv].Visible = false;
                }

                // Update the xyzwpr values
                txtWorld[0].Text = string.Format("{0:N2}", objXyzWpr.X);
                txtWorld[1].Text = string.Format("{0:N2}", objXyzWpr.Z);
                txtWorld[2].Text = string.Format("{0:N2}", objXyzWpr.Z);
                txtWorld[3].Text = string.Format("{0:N2}", objXyzWpr.W);
                txtWorld[4].Text = string.Format("{0:N2}", objXyzWpr.P);
                txtWorld[5].Text = string.Format("{0:N2}", objXyzWpr.R);

                // Update the extended axes
                lLcv = 0;
                foreach (double dblExtAngle in objXyzWpr.Ext)
                {
                    txtWorldExtAxes[lLcv].Text = string.Format("{0:N2}", dblExtAngle);
                    txtWorldExtAxes[lLcv].Visible = true;
                    lblWorldExtAxes[lLcv].Visible = true;
                    lLcv = lLcv + 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "RefreshWorldTab");
            }
        }

        #endregion

        #region "Everything to do with the User Tab"

        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //                       Everything to do with the User Tab
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: CreateXyzWprControlArrays
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void CreateUserControlArrays()
        {
            txtUser[0] = txtUser_0;
            txtUser[1] = txtUser_1;
            txtUser[2] = txtUser_2;
            txtUser[3] = txtUser_3;
            txtUser[4] = txtUser_4;
            txtUser[5] = txtUser_5;

            txtUserExtAxes[0] = txtUserExtAxes_0;
            txtUserExtAxes[1] = txtUserExtAxes_1;
            txtUserExtAxes[2] = txtUserExtAxes_2;

            lblUserExtAxes[0] = lblUserExtAxes_0;
            lblUserExtAxes[1] = lblUserExtAxes_1;
            lblUserExtAxes[2] = lblUserExtAxes_2;
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: RefreshXyzwprTab
        //
        // (Re)Populate the display boxes in the Xyzwpr tab
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void RefreshUserTab()
        {
            FRCXyzWpr objXyzWpr;
            int lLcv;

            try
            {
                objXyzWpr = mobjCurGrpPos.Formats[FRETypeCodeConstants.frExtXyzWpr];

                // Setup to show ext axes or not
                for (lLcv = 0; lLcv <= 2; lLcv++)
                {
                    lblUserExtAxes[lLcv].Visible = false;
                    txtUserExtAxes[lLcv].Visible = false;
                }

                // Update the xyzwpr values
                txtUser[0].Text = string.Format("{0:N2}", objXyzWpr.X);
                txtUser[1].Text = string.Format("{0:N2}", objXyzWpr.Z);
                txtUser[2].Text = string.Format("{0:N2}", objXyzWpr.Z);
                txtUser[3].Text = string.Format("{0:N2}", objXyzWpr.W);
                txtUser[4].Text = string.Format("{0:N2}", objXyzWpr.P);
                txtUser[5].Text = string.Format("{0:N2}", objXyzWpr.R);

                // Update the extended axes
                lLcv = 0;
                foreach (double dblExtAngle in objXyzWpr.Ext)
                {
                    txtUserExtAxes[lLcv].Text = string.Format("{0:N2}", dblExtAngle);
                    txtUserExtAxes[lLcv].Visible = true;
                    lblUserExtAxes[lLcv].Visible = true;
                    lLcv = lLcv + 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "RefreshUserTab");
            }
        }

        #endregion

    }
}