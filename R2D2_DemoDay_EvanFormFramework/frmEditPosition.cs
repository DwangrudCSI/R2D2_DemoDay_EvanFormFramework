// Module: frmEditPosition
//
// Description:
//     Edit position data
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
using System.Windows;

namespace FRRobotDemoCSharp
{
    public partial class frmEditPosition : Form
    {

        #region "Declarations"

        //*************************************************************************
        //                           Declarations
        //*************************************************************************
        const string strEXT = "Ext";
        const string strJOINT = "Joint";

        const string strUninit = "*****";
        const short ssTRANSFORM = 0;
        const short ssXYZWPR = 1;

        const short ssJOINT = 2;
        private FRCTransform mobjTrans;
        private FRCXyzWpr mobjXyzWpr;

        private FRCJoint mobjJoint;
        private FRCPosition mobjPos;
        private FRCSysGroupPosition mobjSysGrpPos;
        private FRCTPPosition mobjTPPos;

        private FRCIndPosition mobjIndPos;

        private bool mblnRefreshingDisplay;
        private TextBox[] txtN = new TextBox[3];
        private TextBox[] txtO = new TextBox[3];
        private TextBox[] txtA = new TextBox[3];
        private TextBox[] txtL = new TextBox[3];

        private TextBox[] txtTransExtAxes = new TextBox[9];
        private TextBox[] txtXyzWpr = new TextBox[6];

        private TextBox[] txtXyzExtAxes = new TextBox[9];
        private TextBox[] txtJoint = new TextBox[9];

        private Label[] lblJointNum = new Label[9];

        FRRobotDemo FRRobotDemo;

        //remove the form buttons
        private const int WS_SYSMENU = 0x80000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style &= ~WS_SYSMENU;
                return cp;
            }
        }

        #endregion

        #region "Public Properties and Methods"

        //*************************************************************************
        //                      Public Properties and Methods
        //*************************************************************************

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: EditReg
        //
        // Called to edit Position Register data
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        public void EditReg(FRCSysGroupPosition objRegPos)
        {
            try
            {
                // Set up module wide access to the position
                mobjSysGrpPos = objRegPos;
                mobjPos = (FRCPosition)objRegPos;
                mobjTPPos = null;
                mobjIndPos = null;

                // Allow the comment to be changed
                txtComment.Visible = true;
                lblComment.Visible = true;

                // Display the position data
                InitDisplay();

                this.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "EditReg");
            }
            finally
            {
                mobjPos = null;
                mobjSysGrpPos = null;
                this.Close();
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: EditTP
        //
        // Called to edit TP Position data
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        public void EditTP(FRCTPPosition objTPPos, short intGrpNum)
        {
            try
            {
                // Set up module wide access to the position
                mobjTPPos = objTPPos;
                mobjPos = (FRCPosition)objTPPos.Group[intGrpNum];
                mobjSysGrpPos = null;
                mobjIndPos = null;

                // Allow the comment to be changed
                txtComment.Visible = true;
                lblComment.Visible = true;

                // Display the position data
                InitDisplay();

                this.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "EditTP");
            }
            finally
            {
                mobjPos = null;
                mobjTPPos = null;
                this.Close();
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: EditVar
        //
        // Called to edit position variable data
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        public void EditVar(FRCVarPosition objVarPos)
        {
            try
            {
                // Set up module wide access to the position
                mobjPos = (FRCPosition)objVarPos;
                mobjSysGrpPos = null;
                mobjTPPos = null;
                mobjIndPos = null;

                // Don't allow the comment to be changed
                txtComment.Text = string.Empty;
                txtComment.Visible = false;
                lblComment.Visible = false;

                // Display the position data
                InitDisplay();

                this.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "EditVar");
            }
            finally
            {
                mobjPos = null;
                this.Close();
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: EditInd
        //
        // Called to edit Independent position data
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        public void EditInd(FRCIndGroupPosition objPos)
        {
            try
            {
                // Set up module wide access to the position
                mobjPos = (FRCPosition)objPos;
                mobjIndPos = objPos.Parent;
                mobjSysGrpPos = null;
                mobjTPPos = null;

                // Allow the comment to be changed
                txtComment.Visible = true;
                lblComment.Visible = true;

                // Display the position data
                InitDisplay();

                this.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "EditInd");
            }
            finally
            {
                mobjPos = null;
                this.Close();
            }
        }

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
        public frmEditPosition()
        {
            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            CreateXyzWprControlArrays();
            CreateTransformControlArrays();
            CreateJointControlArrays();

            if (FRRobotDemo == null)
                FRRobotDemo = new FRRobotDemo();

            //set min/max size
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }

        #endregion

        #region "User Input Events"

        //*************************************************************************
        //                        User Input Events
        //*************************************************************************

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdIsReachable_Click
        //
        // Checks if the position is reachable
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdIsReachable_Click(object sender, EventArgs e)
        {
            FRCMotionErrorInfo MotionErrorInfo;
            try
            {
                if (mobjPos.get_IsReachable(Type.Missing, FREMotionTypeConstants.frJointMotionType, FREOrientTypeConstants.frAESWorldOrientType, Type.Missing, out MotionErrorInfo))
                {
                    cmdIsReachable.Text = R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_YES;
                }
                else
                {
                    cmdIsReachable.Text = R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_NO;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_Q_REACHABLE);
            }
        }

        private void cmdIsReachable_Leave(object sender, EventArgs e)
        {
            cmdIsReachable.Text = R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_Q_REACH;
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdRefresh_Click
        //
        // Gets new data from the controller and redisplays
        // everything on the screen.
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            mobjPos.Refresh();
            InitDisplay();
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdCopyFromSource_Click
        //
        // Copy the PositionCopySource into this position
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdCopyFromSource_Click(object sender, EventArgs e)
        {
            try
            {
                mobjPos.Copy(FRRobotDemo.gobjPositionCopySource);
                RefreshTab();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cmdCopyFromSource_Click");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdSetAsCopySource_Click
        //
        // Sets this as the PositionCopySource
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdSetAsCopySource_Click(object sender, EventArgs e)
        {
            FRRobotDemo.gobjPositionCopySource = mobjPos;
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdUpdate_Click
        //
        // Sends the data to the controller
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                mobjPos.Update();
                InitDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cmdUpdate_Click");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdOK_Click
        //
        // Accept changes made to the data
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdOK_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdMoveto_Click
        //
        // Move to the current position
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdmoveto_Click(object sender, EventArgs e)
        {
            try
            {
                mobjPos.Moveto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cmdmoveto_Click");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdRecord_Click
        //
        // Record the current position
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdRecord_Click(object sender, EventArgs e)
        {
            try
            {
                mobjPos.Record();
                InitDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cmdRecord_Click");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdUninit_Click
        //
        // Uninitialize the current position
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdUninit_Click(object sender, EventArgs e)
        {
            try
            {
                mobjPos.Uninitialize();
                InitDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cmdUninit_Click");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdInv_Click
        //
        // Invert the transformation matrix of the position
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdInv_Click(object sender, EventArgs e)
        {
            try
            {
                // invert the transformation matrix
                MessageBox.Show("Inverting the position itself");
                mobjPos.MatInv(mobjPos);
                // refresh the display : the results should be A^(-1)
                InitDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cmdInv_Click");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: tabPos_Click
        //
        // When changing display tabs, incorporate changes made on the previous
        // tab and update all.
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void tabPos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int PreviousTab = tabPos.SelectedIndex;

            if (!mblnRefreshingDisplay)
            {
                RefreshTab();
            }

            PreviousTab = tabPos.SelectedIndex;
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENTs: txtComment_Keypress, LostFocus
        //
        // Change the Comment.  This event will never happen on VarPositions
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void txtComment_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar.Equals((char)Keys.Enter))
                {
                    if (mobjSysGrpPos != null)
                    {
                        mobjSysGrpPos.Comment = txtComment.Text;
                    }
                    else if (mobjTPPos != null)
                    {
                        mobjTPPos.Comment = txtComment.Text;
                    }
                    else if (mobjIndPos != null)
                    {
                        mobjIndPos.Comment = txtComment.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "txtComment_KeyPress");
            }
            finally
            {
                if (e.KeyChar == 0)
                {
                    e.Handled = true;
                }
            }
        }

        private void txtComment_Leave(object sender, EventArgs e)
        {
            try
            {
                if (mobjSysGrpPos != null)
                {
                    mobjSysGrpPos.Comment = txtComment.Text;
                }
                else if (mobjTPPos != null)
                {
                    mobjTPPos.Comment = txtComment.Text;
                }
                else if (mobjIndPos != null)
                {
                    mobjIndPos.Comment = txtComment.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "txtComment_Leave");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: optXXXType_Click
        //
        // Adjust the display each time the PosType is changed
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void optJoint_CheckedChanged(object sender, EventArgs e)
        {
            if (optJoint.Checked)
            {
                if (!mblnRefreshingDisplay)
                {
                    UpdateType();
                }
            }
        }

        private void optTransform_CheckedChanged(object sender, EventArgs e)
        {
            if (optTransform.Checked)
            {
                if (!mblnRefreshingDisplay)
                {
                    UpdateType();
                }
            }
        }

        private void optXyzWpr_CheckedChanged(object sender, EventArgs e)
        {
            if (optXyzWpr.Checked)
            {
                if (!mblnRefreshingDisplay)
                {
                    UpdateType();
                }
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENTS: txtFrameNum_KeyPress & txtFrameNum_LostFocus
        //
        // Handle changes to the UserFrame Number box
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void txtFrameNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Respond to carriage returns only
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                ApplyFrameNumChange();
            }
            if (e.KeyChar == 0)
            {
                e.Handled = true;
            }
        }

        private void txtFrameNum_Leave(object sender, EventArgs e)
        {
            ApplyFrameNumChange();
        }

        private void ApplyFrameNumChange()
        {
            short output;
            if (!short.TryParse(txtFrameNum.Text, out output))
            {
                MessageBox.Show("Please enter valid number");
                return;
            }
            mobjPos.UserFrame = short.Parse(txtFrameNum.Text);
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENTS: txtToolNum_KeyPress & txtToolNum_LostFocus
        //
        // Handle changes to the UserTool Number box
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void txtToolNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Respond to carriage returns only
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                ApplyToolNumChange();
            }
            if (e.KeyChar == 0)
            {
                e.Handled = true;
            }
        }

        private void txtToolNum_Leave(object Sender, EventArgs e)
        {
            ApplyToolNumChange();
        }

        private void ApplyToolNumChange()
        {
            short output;
            if (!short.TryParse(txtToolNum.Text, out output))
            {
                MessageBox.Show("Please enter valid number");
                return;
            }
            mobjPos.UserTool = short.Parse(txtToolNum.Text);
        }

        #endregion

        #region "Robot Server Events"

        //*************************************************************************
        //                        Robot Server Events
        //*************************************************************************

        #endregion

        #region "Utility Routines"

        //*************************************************************************
        //                        Utility Routines
        //*************************************************************************

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: RefreshTab
        //
        // Fill in the current tab information
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void RefreshTab()
        {
            switch (tabPos.SelectedIndex)
            {
                case 0:
                    RefreshTransformTab();
                    break;
                case 1:
                    RefreshXyzwprTab();
                    break;
                case 2:
                    RefreshJointTab();
                    break;
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: InitDisplay
        //
        // Set up the display
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void InitDisplay()
        {
            short lLcv = 0;

            try
            {
                // Ignore click events during this
                mblnRefreshingDisplay = true;

                // Display the Comment
                if (mobjSysGrpPos != null)
                {
                    txtComment.Text = mobjSysGrpPos.Comment;
                }
                else if (mobjTPPos != null)
                {
                    txtComment.Text = mobjTPPos.Comment;
                }
                else if (mobjIndPos != null)
                {
                    txtComment.Text = mobjIndPos.Comment;
                }

                // Allow changing Type on SysPositions, IndPositions and TPPositions only
                if (mobjTPPos == null && mobjSysGrpPos == null && mobjIndPos == null)
                {
                    optJoint.Enabled = false;
                    optTransform.Enabled = false;
                    optXyzWpr.Enabled = false;
                }
                else
                {
                    optJoint.Enabled = true;
                    optTransform.Enabled = true;
                    optXyzWpr.Enabled = true;
                }

                // Allow changing Frame numbers on IndPositions and TPPositions only
                if (mobjTPPos == null && mobjIndPos == null)
                {
                    txtFrameNum.Enabled = false;
                    txtToolNum.Enabled = false;
                }
                else
                {
                    txtFrameNum.Enabled = true;
                    txtToolNum.Enabled = true;
                }

                // Display how the position is stored
                if (mobjPos.Type == FRETypeCodeConstants.frExtTransform || 
                    mobjPos.Type == FRETypeCodeConstants.frExtXyzWpr)
                {
                    lblWithExtAxes.Visible = true;
                }
                else
                {
                    lblWithExtAxes.Visible = false;
                }

                txtId.Text = mobjPos.Id.ToString();
                txtToolNum.Text = mobjPos.UserTool.ToString();
                txtFrameNum.Text = mobjPos.UserFrame.ToString();

                // Get formats for all tabs
                mobjTrans = mobjPos.Formats[FRETypeCodeConstants.frTransform];
                mobjXyzWpr = mobjPos.Formats[FRETypeCodeConstants.frXyzWpr];
                mobjJoint = null;
                try
                {
                    mobjJoint = mobjPos.Formats[FRETypeCodeConstants.frJoint];
                }
                catch { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "InitDisplay1");
            }

            try
            {
                // Setup the Joint tab so the first time it is
                // displayed, only the valid joints will be shown.
                for (lLcv = 0; lLcv <= 8; lLcv++)
                {
                    txtJoint[lLcv].Visible = false;
                    lblJointNum[lLcv].Visible = false;
                }

                // Set the tab, which will cause itself to populate
                switch ((short)mobjPos.Type)
                {
                    case (short)FRETypeCodeConstants.frExtTransform:
                    case (short)FRETypeCodeConstants.frTransform:
                        optTransform.Checked = true;
                        tabPos.SelectedIndex = 0;
                        break;
                    case (short)FRETypeCodeConstants.frExtXyzWpr:
                    case (short)FRETypeCodeConstants.frXyzWpr:
                        optXyzWpr.Checked = true;
                        tabPos.SelectedIndex = 1;
                        break;
                    case (short)FRETypeCodeConstants.frJoint:
                        optJoint.Checked = true;
                        tabPos.SelectedIndex = 2;
                        break;
                }

                // Enable updates and fake out a tab pos click
                mblnRefreshingDisplay = false;
                tabPos_SelectedIndexChanged(tabPos, new System.EventArgs());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "InitDisplay");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: UpdateType
        //
        // User has changed the position storage type.
        // Set the typoe based on extended axis info.
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void UpdateType()
        {
            try
            {
                // Set the position type which changes how the
                // position data is actually stored
                if (lblWithExtAxes.Visible)
                {
                    if (optTransform.Checked)
                    {
                        mobjPos.Type = FRETypeCodeConstants.frExtTransform;
                    }
                    if (optXyzWpr.Checked)
                    {
                        mobjPos.Type = FRETypeCodeConstants.frExtXyzWpr;
                    }
                }
                else
                {
                    if (optTransform.Checked)
                    {
                         mobjPos.Type = FRETypeCodeConstants.frTransform;
                    }
                    if (optXyzWpr.Checked)
                    {
                         mobjPos.Type = FRETypeCodeConstants.frXyzWpr;
                    }
                    if (optJoint.Checked)
                    {
                        mobjPos.Type = FRETypeCodeConstants.frJoint;
                    }
                }

                // Update the display
                InitDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Type Change");
            }
        }

        #endregion

        #region "Everything to do with the XYZWPR Tab"

        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //                       Everything to do with the XYZWPR Tab
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: CreateXyzWprControlArrays
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void CreateXyzWprControlArrays()
        {
            txtXyzWpr[0] = txtXyzWpr_0;
            txtXyzWpr[1] = txtXyzWpr_1;
            txtXyzWpr[2] = txtXyzWpr_2;
            txtXyzWpr[3] = txtXyzWpr_3;
            txtXyzWpr[4] = txtXyzWpr_4;
            txtXyzWpr[5] = txtXyzWpr_5;

            txtXyzExtAxes[0] = txtXyzExtAxes_0;
            txtXyzExtAxes[1] = txtXyzExtAxes_1;
            txtXyzExtAxes[2] = txtXyzExtAxes_2;
            txtXyzExtAxes[3] = txtXyzExtAxes_3;
            txtXyzExtAxes[4] = txtXyzExtAxes_4;
            txtXyzExtAxes[5] = txtXyzExtAxes_5;
            txtXyzExtAxes[6] = txtXyzExtAxes_6;
            txtXyzExtAxes[7] = txtXyzExtAxes_7;
            txtXyzExtAxes[8] = txtXyzExtAxes_8;
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: RefreshXyzwprTab
        //
        // (Re)Populate the display boxes in the Xyzwpr tab
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void RefreshXyzwprTab()
        {
            int lLcv;

            try
            {
                // Setup to show ext axes or not
                for (lLcv = 0; lLcv <= 8; lLcv++)
                {
                    txtXyzExtAxes[lLcv].Visible = false;
                }

                if (mobjPos.IsInitialized)
                {
                    // Update the xyzwpr values
                    txtXyzWpr[0].Text = string.Format("{0:N2}", mobjXyzWpr.X);
                    txtXyzWpr[1].Text = string.Format("{0:N2}", mobjXyzWpr.Y);
                    txtXyzWpr[2].Text = string.Format("{0:N2}", mobjXyzWpr.Z);
                    txtXyzWpr[3].Text = string.Format("{0:N2}", mobjXyzWpr.W);
                    txtXyzWpr[4].Text = string.Format("{0:N2}", mobjXyzWpr.P);
                    txtXyzWpr[5].Text = string.Format("{0:N2}", mobjXyzWpr.R);

                    // Update the configuration
                    txtXyzWprConfig.Text = mobjXyzWpr.Config.Text;

                    // Update the extended axes
                    lLcv = 0;
                    foreach (object vExt in mobjXyzWpr.Ext)
                    {
                        txtXyzExtAxes[lLcv].Text = string.Format("{0:N2}", vExt);
                        txtXyzExtAxes[lLcv].Visible = true;
                        lLcv = lLcv + 1;
                    }
                    //uninit position
                }
                else
                {
                    // Update the xyzwpr values
                    for (lLcv = 0; lLcv <= 5; lLcv++)
                    {
                        txtXyzWpr[lLcv].Text = strUninit;
                    }

                    // Update the configuration
                    txtXyzWprConfig.Text = strUninit;

                    // Update the extended axes
                    for (lLcv = 0; lLcv <= mobjXyzWpr.Ext.Count - 1; lLcv++)
                    {
                        txtXyzExtAxes[lLcv].Text = strUninit;
                        txtXyzExtAxes[lLcv].Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Refreshing XyzWpr boxes");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENTS: txtXyzWpr_KeyPress & txtXyzWpr_LostFocus
        //
        // Call ApplyXyzwprChange to handle changes to the X Y Z W P R text boxes
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void txtXyzWpr_0_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtXyzWpr_KeyPress(0, e);
        }

        private void txtXyzWpr_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtXyzWpr_KeyPress(1, e);
        }

        private void txtXyzWpr_2_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtXyzWpr_KeyPress(2, e);
        }

        private void txtXyzWpr_3_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtXyzWpr_KeyPress(3, e);
        }

        private void txtXyzWpr_4_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtXyzWpr_KeyPress(4, e);
        }

        private void txtXyzWpr_5_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtXyzWpr_KeyPress(5, e);
        }

        private void txtXyzWpr_KeyPress(short Index, KeyPressEventArgs e)
        {
            //Respond to carriage returns only
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                ApplyXyzwprChange(Index);
            }
            if (e.KeyChar == 0)
            {
                e.Handled = true;
            }
        }

        private void txtXyzWpr_0_Leave(object sender, EventArgs e)
        {
            ApplyXyzwprChange(0);
        }

        private void txtXyzWpr_1_Leave(object sender, EventArgs e)
        {
            ApplyXyzwprChange(1);
        }

        private void txtXyzWpr_2_Leave(object sender, EventArgs e)
        {
            ApplyXyzwprChange(2);
        }

        private void txtXyzWpr_3_Leave(object sender, EventArgs e)
        {
            ApplyXyzwprChange(3);
        }

        private void txtXyzWpr_4_Leave(object sender, EventArgs e)
        {
            ApplyXyzwprChange(4);
        }

        private void txtXyzWpr_5_Leave(object sender, EventArgs e)
        {
            ApplyXyzwprChange(5);
        }

        private void ApplyXyzwprChange(short Index)
        {
            // Don't try to convert the "*****" string
            if (txtXyzWpr[Index].Text.Equals(strUninit))
                return;

            try
            {
                switch (Index)
                {
                    case 0:
                        // X
                        mobjXyzWpr.X = double.Parse(txtXyzWpr[Index].Text);
                        break;
                    case 1:
                        // Y
                        mobjXyzWpr.Y = double.Parse(txtXyzWpr[Index].Text);
                        break;
                    case 2:
                        // Z
                        mobjXyzWpr.Z = double.Parse(txtXyzWpr[Index].Text);
                        break;
                    case 3:
                        // W
                        mobjXyzWpr.W = double.Parse(txtXyzWpr[Index].Text);
                        break;
                    case 4:
                        // P
                        mobjXyzWpr.P = double.Parse(txtXyzWpr[Index].Text);
                        break;
                    case 5:
                        // R
                        mobjXyzWpr.R = double.Parse(txtXyzWpr[Index].Text);
                        break;
                }

                RefreshTab();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Setting XyzWpr");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENTS: txtXyzExtAxes_KeyPress & txtXyzExtAxes_LostFocus
        //
        // Handle changes to the Extended axes text boxes
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void txtXyzExtAxes_0_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtXyzExtAxes_KeyPress(0, e);
        }

        private void txtXyzExtAxes_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtXyzExtAxes_KeyPress(1, e);
        }

        private void txtXyzExtAxes_2_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtXyzExtAxes_KeyPress(2, e);
        }

        private void txtXyzExtAxes_3_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtXyzExtAxes_KeyPress(3, e);
        }

        private void txtXyzExtAxes_4_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtXyzExtAxes_KeyPress(4, e);
        }

        private void txtXyzExtAxes_5_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtXyzExtAxes_KeyPress(5, e);
        }

        private void txtXyzExtAxes_6_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtXyzExtAxes_KeyPress(6, e);
        }

        private void txtXyzExtAxes_7_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtXyzExtAxes_KeyPress(7, e);
        }

        private void txtXyzExtAxes_8_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtXyzExtAxes_KeyPress(8, e);
        }

        private void txtXyzExtAxes_KeyPress(short Index, KeyPressEventArgs e)
        {
            //Respond to carriage returns only
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                ApplyXyzExtAxesChange(Index);
            }
            if (e.KeyChar == 0)
            {
                e.Handled = true;
            }
        }

        private void txtXyzExtAxes_0_Leave(object sender, EventArgs e)
        {
            ApplyXyzwprChange(0);
        }

        private void txtXyzExtAxes_1_Leave(object sender, EventArgs e)
        {
            ApplyXyzwprChange(1);
        }

        private void txtXyzExtAxes_2_Leave(object sender, EventArgs e)
        {
            ApplyXyzwprChange(2);
        }

        private void txtXyzExtAxes_3_Leave(object sender, EventArgs e)
        {
            ApplyXyzwprChange(3);
        }

        private void txtXyzExtAxes_4_Leave(object sender, EventArgs e)
        {
            ApplyXyzwprChange(4);
        }

        private void txtXyzExtAxes_5_Leave(object sender, EventArgs e)
        {
            ApplyXyzwprChange(5);
        }

        private void txtXyzExtAxes_6_Leave(object sender, EventArgs e)
        {
            ApplyXyzwprChange(6);
        }

        private void txtXyzExtAxes_7_Leave(object sender, EventArgs e)
        {
            ApplyXyzwprChange(7);
        }

        private void txtXyzExtAxes_8_Leave(object sender, EventArgs e)
        {
            ApplyXyzwprChange(8);
        }

        private void ApplyXyzExtAxesChange(short Index)
        {
            try
            {
                // Don't try to convert the "*****" string
                if (!txtXyzExtAxes[Index].Text.Equals(strUninit))
                {
                    mobjXyzWpr.Ext[(short)(Index + 1)] = double.Parse(txtXyzExtAxes[Index].Text);
                    RefreshTab();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Setting XyzWpr Extended axes");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENTS: txtXyzWprConfig_KeyPress & txtXyzWprConfig_LostFocus
        //
        // Handle changes to the Extended axes text boxes
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void txtXyzWprConfig_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Respond to carriage returns only
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                ApplyXyzWprConfigChange();
            }
            if (e.KeyChar == 0)
            {
                e.Handled = true;
            }
        }

        private void txtXyzWprConfig_Leave(object sender, EventArgs e)
        {
            ApplyXyzWprConfigChange();
        }

        private void ApplyXyzWprConfigChange()
        {
            // Don't try to convert the "*****" string
            try
            {
                if (!txtXyzWprConfig.Text.Equals(strUninit))
                {
                    mobjXyzWpr.Config.Text = txtXyzWprConfig.Text;
                    RefreshTab();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Config Change");
            }
        }

        #endregion

        #region "Everything to do with the Transform Tab"

        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //                       Everything to do with the Transform Tab
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: CreateTransformControlArrays
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void CreateTransformControlArrays()
        {
            txtN[0] = txtN_0;
            txtN[1] = txtN_1;
            txtN[2] = txtN_2;
            txtO[0] = txtO_0;
            txtO[1] = txtO_1;
            txtO[2] = txtO_2;
            txtA[0] = txtA_0;
            txtA[1] = txtA_1;
            txtA[2] = txtA_2;
            txtL[0] = txtL_0;
            txtL[1] = txtL_1;
            txtL[2] = txtL_2;

            txtTransExtAxes[0] = txtTransExtAxes_0;
            txtTransExtAxes[1] = txtTransExtAxes_1;
            txtTransExtAxes[2] = txtTransExtAxes_2;
            txtTransExtAxes[3] = txtTransExtAxes_3;
            txtTransExtAxes[4] = txtTransExtAxes_4;
            txtTransExtAxes[5] = txtTransExtAxes_5;
            txtTransExtAxes[6] = txtTransExtAxes_6;
            txtTransExtAxes[7] = txtTransExtAxes_7;
            txtTransExtAxes[8] = txtTransExtAxes_8;
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: RefreshTransformTab
        //
        // (Re)Populate the display boxes in the Xyzwpr tab
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void RefreshTransformTab()
        {
            short lLcv = 0;
            object vExt = null;

            try
            {
                // Setup to show ext axes or not
                for (lLcv = 0; lLcv <= 8; lLcv++)
                {
                    txtTransExtAxes[lLcv].Visible = false;
                }

                if (mobjPos.IsInitialized)
                {
                    // Set the transform values
                    for (lLcv = 0; lLcv <= 2; lLcv++)
                    {
                        // N, O, A are changed to read only
                        txtN[lLcv].Text = string.Format("{0:N4}", mobjTrans.Normal[(short)(lLcv + 1)]);
                        txtO[lLcv].Text = string.Format("{0:N4}", mobjTrans.Orient[(short)(lLcv + 1)]);
                        txtA[lLcv].Text = string.Format("{0:N4}", mobjTrans.Approach[(short)(lLcv + 1)]);
                        txtL[lLcv].Text = string.Format("{0:N2}", mobjTrans.Location[(short)(lLcv + 1)]);
                    }

                    // Set the config
                    txtTransConfig.Text = mobjTrans.Config.Text;

                    // Update the extended axes
                    lLcv = 0;
                    foreach (object tempLoopVar_vExt in mobjTrans.Ext)
                    {
                        vExt = tempLoopVar_vExt;
                        txtTransExtAxes[lLcv].Text = string.Format("{0:N2}", vExt);
                        txtTransExtAxes[lLcv].Visible = true;
                        lLcv++;
                    }
                }
                else
                {
                    // Set the transform values
                    for (lLcv = 0; lLcv <= 2; lLcv++)
                    {
                        // N, O, A are changed to read only
                        txtN[lLcv].Text = strUninit;
                        txtO[lLcv].Text = strUninit;
                        txtA[lLcv].Text = strUninit;
                        txtL[lLcv].Text = strUninit;
                    }

                    // Update the configuration
                    txtTransConfig.Text = strUninit;

                    // Update the extended axes
                    for (lLcv = 0; lLcv <= mobjTrans.Ext.Count - 1; lLcv++)
                    {
                        txtTransExtAxes[lLcv].Text = strUninit;
                        txtTransExtAxes[lLcv].Visible = true;
                    }
                } // Uninit
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "RefreshTransformTab");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENTS: txtL_KeyPress & txtL_LostFocus
        //
        // Handle changes to the Location text boxes
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void txtL_0_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtL_KeyPress(0, e);
        }

        private void txtL_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtL_KeyPress(1, e);
        }

        private void txtL_2_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtL_KeyPress(2, e);
        }

        private void txtL_KeyPress(short Index, KeyPressEventArgs e)
        {
            //Respond to carriage returns only
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                ApplyLocationChange(Index);
            }
            if (e.KeyChar == 0)
            {
                e.Handled = true;
            }
        }

        private void txtL_0_Leave(object sender, EventArgs e)
        {
            ApplyLocationChange(0);
        }

        private void txtL_1_Leave(object sender, EventArgs e)
        {
            ApplyLocationChange(1);
        }

        private void txtL_2_Leave(object sender, EventArgs e)
        {
            ApplyLocationChange(2);
        }

        private void ApplyLocationChange(short Index)
        {
            try
            {
                // Don't try to convert the "*****" string
                if (!txtL[Index].Text.Equals(strUninit))
                {
                    mobjTrans.Location[(short)(Index + 1)] = double.Parse(txtL[Index].Text);
                    RefreshTab();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ApplyLocationChange");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENTS: txtTransExtAxes_KeyPress & txtTransExtAxes_LostFocus
        //
        // Handle changes to the Extended axes text boxes
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void txtTransExtAxes_0_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtTransExtAxes_KeyPress(0, e);
        }

        private void txtTransExtAxes_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtTransExtAxes_KeyPress(1, e);
        }

        private void txtTransExtAxes_2_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtTransExtAxes_KeyPress(2, e);
        }

        private void txtTransExtAxes_3_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtTransExtAxes_KeyPress(3, e);
        }

        private void txtTransExtAxes_4_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtTransExtAxes_KeyPress(4, e);
        }

        private void txtTransExtAxes_5_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtTransExtAxes_KeyPress(5, e);
        }

        private void txtTransExtAxes_6_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtTransExtAxes_KeyPress(6, e);
        }

        private void txtTransExtAxes_7_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtTransExtAxes_KeyPress(7, e);
        }

        private void txtTransExtAxes_8_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtTransExtAxes_KeyPress(8, e);
        }

        private void txtTransExtAxes_KeyPress(short Index, KeyPressEventArgs e)
        {
            //Respond to carriage returns only
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                ApplyTransExtAxesChange(Index);
            }
            if (e.KeyChar == 0)
            {
                e.Handled = true;
            }
        }

        private void txtTransExtAxes_0_Leave(object sender, EventArgs e)
        {
            ApplyTransExtAxesChange(0);
        }

        private void txtTransExtAxes_1_Leave(object sender, EventArgs e)
        {
            ApplyTransExtAxesChange(1);
        }

        private void txtTransExtAxes_2_Leave(object sender, EventArgs e)
        {
            ApplyTransExtAxesChange(2);
        }

        private void txtTransExtAxes_3_Leave(object sender, EventArgs e)
        {
            ApplyTransExtAxesChange(3);
        }

        private void txtTransExtAxes_4_Leave(object sender, EventArgs e)
        {
            ApplyTransExtAxesChange(4);
        }

        private void txtTransExtAxes_5_Leave(object sender, EventArgs e)
        {
            ApplyTransExtAxesChange(5);
        }

        private void txtTransExtAxes_6_Leave(object sender, EventArgs e)
        {
            ApplyTransExtAxesChange(6);
        }

        private void txtTransExtAxes_7_Leave(object sender, EventArgs e)
        {
            ApplyTransExtAxesChange(7);
        }

        private void txtTransExtAxes_8_Leave(object sender, EventArgs e)
        {
            ApplyTransExtAxesChange(8);
        }

        private void ApplyTransExtAxesChange(short Index)
        {
            try
            {
                // Don't try to convert the "*****" string
                if (!txtTransExtAxes[Index].Text.Equals(strUninit))
                {
                    mobjTrans.Ext[(short)(Index + 1)] = double.Parse(txtTransExtAxes[Index].Text);
                    RefreshTab();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ApplyTransExtAxesChange");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENTS: txtTransConfig_KeyPress & txtTransConfig_LostFocus
        //
        // Handle changes to the Extended axes text boxes
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void txtTransConfig_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Respond to carriage returns only
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                ApplyTransConfigChange();
            }
            if (e.KeyChar == 0)
            {
                e.Handled = true;
            }
        }

        private void txtTransConfig_Leave(object sender, EventArgs e)
        {
            ApplyTransConfigChange();
        }

        private void ApplyTransConfigChange()
        {
            try
            {
                // Don't try to convert the "*****" string
                if (!txtTransConfig.Text.Equals(strUninit))
                {
                    mobjTrans.Config.Text = txtTransConfig.Text;
                    RefreshTab();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ApplyTransConfigChange");
            }
        }

        #endregion

        #region "Everything to do with the Joint Tab"

        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //                       Everything to do with the Joint Tab
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

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
            short lLcv;

            try
            {
                if (mobjJoint == null)
                {
                    lblJointNotValid.Visible = true;
                }
                else
                {
                    lblJointNotValid.Visible = false;

                    if (mobjPos.IsInitialized)
                    {
                        // Set the Joint values
                        lLcv = 0;
                        foreach (object vAngle in mobjJoint)
                        {
                            txtJoint[lLcv].Text = string.Format("{0:N2}", vAngle);
                            txtJoint[lLcv].Visible = true;
                            lblJointNum[lLcv].Visible = true;
                            lLcv = (short)(lLcv + 1);
                        }
                    }
                    else
                    {
                        // Update the extended axes
                        for (lLcv = 0; lLcv <= mobjJoint.Count - 1; lLcv++)
                        {
                            txtJoint[lLcv].Text = strUninit;
                            txtJoint[lLcv].Visible = true;
                            lblJointNum[lLcv].Visible = true;
                        }
                    }
                    // Uninit
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "RefreshJointTab");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENTS: txtJoint_KeyPress & txtJoint_LostFocus
        //
        // Handle changes to the Joint text boxes
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void txtJoint_0_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtJoint_KeyPress(0, e);
        }

        private void txtJoint_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtJoint_KeyPress(1, e);
        }

        private void txtJoint_2_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtJoint_KeyPress(2, e);
        }

        private void txtJoint_3_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtJoint_KeyPress(3, e);
        }

        private void txtJoint_4_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtJoint_KeyPress(4, e);
        }

        private void txtJoint_5_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtJoint_KeyPress(5, e);
        }

        private void txtJoint_6_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtJoint_KeyPress(6, e);
        }

        private void txtJoint_7_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtJoint_KeyPress(7, e);
        }

        private void txtJoint_8_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtJoint_KeyPress(8, e);
        }

        private void txtJoint_KeyPress(short Index, KeyPressEventArgs e)
        {
            //Respond to carriage returns only
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                ApplyJointChange(Index);
            }
            if (e.KeyChar == 0)
            {
                e.Handled = true;
            }
        }

        private void txtJoint_0_Leave(object sender, EventArgs e)
        {
            ApplyJointChange(0);
        }

        private void txtJoint_1_Leave(object sender, EventArgs e)
        {
            ApplyJointChange(1);
        }

        private void txtJoint_2_Leave(object sender, EventArgs e)
        {
            ApplyJointChange(2);
        }

        private void txtJoint_3_Leave(object sender, EventArgs e)
        {
            ApplyJointChange(3);
        }

        private void txtJoint_4_Leave(object sender, EventArgs e)
        {
            ApplyJointChange(4);
        }

        private void txtJoint_5_Leave(object sender, EventArgs e)
        {
            ApplyJointChange(5);
        }

        private void txtJoint_6_Leave(object sender, EventArgs e)
        {
            ApplyJointChange(6);
        }

        private void txtJoint_7_Leave(object sender, EventArgs e)
        {
            ApplyJointChange(7);
        }

        private void txtJoint_8_Leave(object sender, EventArgs e)
        {
            ApplyJointChange(8);
        }

        private void ApplyJointChange(short Index)
        {
            try
            {
                // Don't try to convert the "*****" string
                if (!txtJoint[Index].Text.Equals(strUninit))
                {
                    mobjJoint[(short)(Index + 1)] = double.Parse(txtJoint[Index].Text);
                    RefreshTab();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ApplyJointChange");
            }
        }

        private void frmEditPosition_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Escape))
                cmdOK_Click(this, new EventArgs());
        }

        #endregion

    }
}