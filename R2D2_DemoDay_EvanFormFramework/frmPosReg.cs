// Module: frmPosReg
//
// Description:
//   Manipulate Position Registers
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
using System.Drawing;
using System.Windows.Forms;

namespace FRRobotDemoCSharp
{
    public partial class frmPosReg : Form
    {

        #region "Declarations"

        //*************************************************************************
        //                           Declarations
        //*************************************************************************

        private int mintPRNum;
        private int mintNumGroups;
        private bool mblnEditingPos;
        private FRCSysPositions mobjPosRegs;
        private FRCSysPosition mobjPosReg;
        private FRCSysGroupPosition mobjGrpPos;
        private TreeNode mobjSelectedNode;

        FRRobotDemo FRRobotDemo;
        frmEditPosition frmEditPosition;
        //frmScattAccess frmScattAccess;

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
        public frmPosReg()
        {
            InitializeComponent();

            if (FRRobotDemo == null)
                FRRobotDemo = new FRRobotDemo();
            //set min/max size
            this.MinimumSize = this.Size;
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: tmrRunOnce_Tick
        // Run this after the form is visible so that the user can watch the tree
        // get populated.
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void tmrRunOnce_Tick(object sender, EventArgs e)
        {
            TreeNode objNode;
            int intRegNum;
            string strRegName;
            string strRegDetails;

            try
            {
                tmrRunOnce.Enabled = false;

                mobjPosRegs = FRRobotDemo.gobjRobot.RegPositions;
                //unsubscribe event if already subscribed
                mobjPosRegs.Change -= mobjPosRegs_Change;
                mobjPosRegs.CommentChange -= mobjPosRegs_CommentChange;
                //subscribe event handlers
                mobjPosRegs.Change += mobjPosRegs_Change;
                mobjPosRegs.CommentChange += mobjPosRegs_CommentChange;

                mintNumGroups = FRRobotDemo.gobjRobot.CurPosition.NumGroups;
                lblNumGroups.Text = string.Format("{0}{1} ", R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_THIS_HAS_NUMGROUPS, mintNumGroups);
                lblNumGroups.Text = lblNumGroups.Text;
                if (mintNumGroups == 1)
                {
                    lblNumGroups.Text += R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_GROUP;
                }
                else
                {
                    lblNumGroups.Text += R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_GROUPS;
                }

                // Fill in the tree
                treePosReg.Nodes.Clear();
                short index = 1;
                int count = 0;
                count = mobjPosRegs.Count;
                if (count >= 100)
                    count = 3;
                else if (count >= 10)
                    count = 2;
                else
                    count = 0;

                // Add an entry for each Position Register
                // Loop thru for each PR[] of the robot
                intRegNum = 0;

                foreach (FRCSysPosition objRegPosn in mobjPosRegs)
                {
                    intRegNum += 1;
                    strRegName = string.Format("PR[{0}] = ", intRegNum);
                    strRegDetails = string.Format("PR[{0," + count.ToString() + "}:{1," + (-22+mintNumGroups*2).ToString() + "}] = ", intRegNum, objRegPosn.Group[1].Comment);

                    //insert @ symbol if at position
                    string atPos = " ";
                    if (objRegPosn.IsAtCurPosition)
                    {
                        atPos = "@";
                    }
                    strRegName = strRegName.Insert(0, atPos);
                    strRegDetails = strRegDetails.Insert(0, atPos);

                    for (index = 1; index <= mintNumGroups; index++)
                    {
                        if (objRegPosn.Group[index].IsInitialized)
                        {
                            strRegDetails = strRegDetails + "[R]";
                        }
                        else
                        {
                            strRegDetails = strRegDetails + "[*]";
                        }
                    }

                    // Add the node to the list
                    objNode = treePosReg.Nodes.Add(strRegName, strRegDetails);
                    objNode.Nodes.Add(strRegName, "ExpandMe");

                    objNode.BackColor = System.Drawing.Color.White;
                    if (objRegPosn.IsAtCurPosition)
                    {
                        objNode.BackColor = System.Drawing.Color.Yellow;
                    }
                }

                treePosReg.SelectedNode = treePosReg.Nodes[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "tmrRunOnce_Tick");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void frmPosReg_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (mobjPosReg != null)
            {
                mobjPosReg.Change -= mobjPosReg_Change;
                mobjPosReg.CommentChange -= mobjPosReg_CommentChange;
            }

            if (mobjPosRegs != null)
            {
                mobjPosRegs.Change -= mobjPosRegs_Change;
                mobjPosRegs.CommentChange -= mobjPosRegs_CommentChange;
            }

            if (mobjGrpPos != null)
            {
                mobjGrpPos.Change -= mobjGrpPos_Change;
                mobjGrpPos.CommentChange -= mobjGrpPos_CommentChange;
            }
        }

        #endregion

        #region "User Input Events"

        //*************************************************************************
        //                        User Input Events
        //*************************************************************************

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: trePosReg_Expand
        //
        // Expand the tree.
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void treePosReg_AfterExpand(object sender, TreeViewEventArgs e)
        {
            TreeNode objNodeToExpland = e.Node;
            TreeNode objNode;
            int intRegNumber;
            FRCSysPosition objRegPosn;
            int intGrpNum;
            FRCSysGroupPosition objSysGrpPosn;
            string strGrpName;
            string strGrpDetails;

            // Get the first sub node
            if (objNodeToExpland.FirstNode.Text.Equals("ExpandMe"))
            {
                // We need to expand the list since it isn't currently done
                objNodeToExpland.Nodes.Clear();

                intRegNumber = objNodeToExpland.Index + 0;
                objRegPosn = mobjPosRegs[Type.Missing, intRegNumber];

                for (intGrpNum = 1; intGrpNum <= mintNumGroups; intGrpNum++)
                {
                    objSysGrpPosn = objRegPosn.Group[(short)intGrpNum];
                    strGrpName = "G" + intGrpNum.ToString();

                    if (objSysGrpPosn.IsInitialized)
                    {
                        // Display the type of position
                        switch (objSysGrpPosn.Type)
                        {
                            case FRETypeCodeConstants.frExtTransform:
                            case FRETypeCodeConstants.frTransform:
                                strGrpName = strGrpName + " [Transformed]";
                                break;
                            case FRETypeCodeConstants.frExtXyzWpr:
                            case FRETypeCodeConstants.frXyzWpr:
                                strGrpName = strGrpName + " [XyzWpr]";
                                break;
                            case FRETypeCodeConstants.frJoint:
                                strGrpName = strGrpName + " [Joint]";
                                break;
                            default:
                                strGrpName = strGrpName + " [Other]";
                                break;
                        }
                        strGrpDetails = strGrpName + " = R";
                    }
                    else
                    {
                        strGrpDetails = strGrpName + " = *";
                    }
                    objNode = objNodeToExpland.Nodes.Add(strGrpName, strGrpDetails);
                    objNode.EnsureVisible();
                }
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: trePosReg_AfterSelect
        //
        // When a new node is selected, decide which buttons are active.
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void treePosReg_AfterSelect(object sender, TreeViewEventArgs e)
        {
            mobjSelectedNode = e.Node;

            if (mobjSelectedNode.Parent == null)
            {
                // This is a SysPosition
                mintPRNum = mobjSelectedNode.Index + 1;
                mobjPosReg = mobjPosRegs[mintPRNum];
                mobjGrpPos = null;
                cmdEdit.Enabled = false;
                cmdMoveto.Enabled = mobjPosReg.IsInitialized;
                cmdStartMon.Enabled = false;
                cmdStopMon.Enabled = false;
                picMonitor.BackColor = Color.FromArgb(128, 0, 0);
            }
            else
            {
                // This node is a SysGroupPosition
                mintPRNum = mobjSelectedNode.Parent.Index + 1;
                mobjPosReg = mobjPosRegs[mintPRNum];
                mobjGrpPos = mobjPosReg.Group[(short)(mobjSelectedNode.Index + 1)];
                //unsubscribe event if already subscribed
                mobjGrpPos.Change -= mobjGrpPos_Change;
                mobjGrpPos.CommentChange -= mobjGrpPos_CommentChange;
                //subscribe event handlers
                mobjGrpPos.Change += mobjGrpPos_Change;
                mobjGrpPos.CommentChange += mobjGrpPos_CommentChange;

                cmdEdit.Enabled = true;
                cmdMoveto.Enabled = mobjGrpPos.IsInitialized;
                cmdStartMon.Enabled = true;
                cmdStopMon.Enabled = true;
                if (mobjGrpPos.IsMonitoring)
                {
                    picMonitor.BackColor = Color.FromArgb(255, 0, 0);
                }
                else
                {
                    picMonitor.BackColor = Color.FromArgb(128, 0, 0);
                }
            }
            //unsubscribe event if already subscribed
            mobjPosReg.Change -= mobjPosReg_Change;
            mobjPosReg.CommentChange -= mobjPosReg_CommentChange;
            //subscribe event handlers
            mobjPosReg.Change += mobjPosReg_Change;
            mobjPosReg.CommentChange += mobjPosReg_CommentChange;
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdEdit_Click
        //
        // Select a new Group Position and allow edit
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (frmEditPosition == null || frmEditPosition.IsDisposed)
                frmEditPosition = new frmEditPosition();

            mblnEditingPos = true;
            frmEditPosition.EditReg(mobjGrpPos);
            mblnEditingPos = false;

            //The Record/Uninit status may have changed so
            // we need to update the trview of it.
            subUpdatePR(mintPRNum);
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdMoveto_Click
        //
        // Move to the recorded position
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdMoveto_Click(object sender, EventArgs e)
        {
            try
            {
                if (mobjGrpPos == null)
                {
                    mobjPosReg.Moveto();
                }
                else
                {
                    mobjGrpPos.Moveto();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cmdMoveto_Click");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdRecord_Click
        //
        // Recorded the position
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdRecord_Click(object sender, EventArgs e)
        {
            try
            {
                if (mobjGrpPos == null)
                {
                    mobjPosReg.Record();
                }
                else
                {
                    mobjGrpPos.Record();
                }

                subUpdatePR(mintPRNum);
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
        // Uninit the position
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdUninit_Click(object sender, EventArgs e)
        {
            try
            {
                if (mobjGrpPos == null)
                {
                    mobjPosReg.Uninitialize();
                }
                else
                {
                    mobjGrpPos.Uninitialize();
                }
                subUpdatePR(mintPRNum);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cmdUninit_Click");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdRefresh_Click
        //
        // Refresh the position
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                if (mobjGrpPos == null)
                {
                    mobjPosReg.Refresh();
                }
                else
                {
                    mobjGrpPos.Refresh();
                }

                subUpdatePR(mintPRNum);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cmdRefresh_Click");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdUpdate_Click
        //
        // Update the position
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (mobjGrpPos == null)
                {
                    mobjPosReg.Update();
                }
                else
                {
                    mobjGrpPos.Update();
                }

                subUpdatePR(mintPRNum);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cmdUpdate_Click");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdCopy_Click
        //
        // Copy this position into the global PositionCopySource
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdCopy_Click(object sender, EventArgs e)
        {
            try
            {
                if (FRRobotDemo == null)
                    FRRobotDemo = new FRRobotDemo();

                if (mobjGrpPos == null)
                {
                    FRRobotDemo.gobjPositionCopySource = mobjPosReg;
                }
                else
                {
                    FRRobotDemo.gobjPositionCopySource = mobjGrpPos;
                }

                subUpdatePR(mintPRNum);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cmdCopy_Click");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdPaste_Click
        //
        // Copy the global PositionCopySource into this position
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdPaste_Click(object sender, EventArgs e)
        {
            try
            {
                if (FRRobotDemo == null)
                    FRRobotDemo = new FRRobotDemo();

                if (mobjGrpPos == null)
                {
                    mobjPosReg.Copy(FRRobotDemo.gobjPositionCopySource);
                }
                else
                {
                    mobjGrpPos.Copy(FRRobotDemo.gobjPositionCopySource);
                }

                subUpdatePR(mintPRNum);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cmdPaste_Click");
            }
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
                mobjGrpPos.StartMonitor(int.Parse(txtLatency.Text));
                picMonitor.BackColor = Color.FromArgb(255, 0, 0);
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
                mobjGrpPos.StopMonitor();
                picMonitor.BackColor = Color.FromArgb(128, 0, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cmdStopMon_Click");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdAddSysGrpPosToScattAccess_Click
        //
        // Add position register to scatter list
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //private void cmdAddSysGrpPosToScattAccess_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (frmScattAccess == null || frmScattAccess.IsDisposed)
        //            frmScattAccess = new frmScattAccess();

        //        frmScattAccess.AddItem(mobjPosReg);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "cmdAddToScattAccess_Click");
        //    }
        //}

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

        #region "Robot Server Events"

        //*************************************************************************
        //                        Robot Server Events
        //*************************************************************************

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: mobjPosRegs_Change
        //
        // Posts an entry to the event form
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private delegate void PosRegsChangeDelegate(int Id, short GroupNum);
        private void mobjPosRegs_Change(int Id, short GroupNum)
        {
            if (this.InvokeRequired)
            {
                // Called from the Robot Server thread
                PosRegsChangeDelegate HandleChangeEvent = new PosRegsChangeDelegate(mobjPosRegs_Change);
                this.BeginInvoke(HandleChangeEvent, Id, GroupNum);
            }
            else
            {
                // Now we are on the Form’s thread
                FRRobotDemo.LogEvent(this, "Change Event on SysPosCol[" + Id + "," + GroupNum + "]");

                // When the PR is not the one we are working on, then refresh the values 
                // so the tree reflects the change just made on the controller.
                FRCSysPosition objPosReg;
                objPosReg = mobjPosRegs[Type.Missing, Id];
                if (mintPRNum != Id || !mblnEditingPos)
                {
                    objPosReg.Refresh();
                }
                subUpdatePR(Id);
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: mobjPosRegs_CommentChange
        //
        // Posts an entry to the event form
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private delegate void PosRegsCommentChangeDelegate(int Id, short GroupNum);
        private void mobjPosRegs_CommentChange(int Id, short GroupNum)
        {
            if (this.InvokeRequired)
            {
                // Called from the Robot Server thread
                PosRegsChangeDelegate HandleCommentChangeEvent = new PosRegsChangeDelegate(mobjPosRegs_CommentChange);
                this.BeginInvoke(HandleCommentChangeEvent, Id, GroupNum);
            }
            else
            {
                // Now we are on the Form’s thread
                FRRobotDemo.LogEvent(this, "CommentChange Event on SysPosCol[" + Id + "," + GroupNum + "]");

                // When the PR is not the one we are working on, then refresh the values 
                // so the tree reflects the change just made on the controller.
                FRCSysPosition objPosReg;
                objPosReg = mobjPosRegs[Type.Missing, Id];
                if (mintPRNum != Id || !mblnEditingPos)
                {
                    objPosReg.Refresh();
                }
                subUpdatePR(Id);
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: mobjPosReg_Change
        //
        // Posts an entry to the event form
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void mobjPosReg_Change(short GroupNum)
        {
            FRRobotDemo.LogEvent(this, "Change Event on SysPos[" + mobjPosReg.Id + "," + GroupNum + "]");
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: mobjPosReg_CommentChange
        // Posts an entry to the event form
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void mobjPosReg_CommentChange(short GroupNum)
        {
            FRRobotDemo.LogEvent(this, "Comment Change Event on SysPos[" + mobjPosReg.Id + "," + GroupNum + "]");
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: mobjGrpPos_Change
        //
        // Posts an entry to the event form
        // Updates information
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void mobjGrpPos_Change()
        {
            FRRobotDemo.LogEvent(this, "CommentChange Event on SysGrpPos[" + mobjGrpPos.Id + "," + mobjGrpPos.GroupNum + "]");
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: mobjGrpPos_CommentChange
        //
        // Posts an entry to the event form
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void mobjGrpPos_CommentChange()
        {
            FRRobotDemo.LogEvent(this, "CommentChange Event on SysGrpPos[" + mobjGrpPos.Id + "," + mobjGrpPos.GroupNum + "]");
        }

        #endregion

        #region "Utility Routines"

        //*************************************************************************
        //                        Utility Routines
        //*************************************************************************

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // Routine: subUpdatePR
        // Update the treee node for the position register.
        // Switch to the main thread if required.
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private delegate void UpdatePRDelegate(int intPRNum);
        private void subUpdatePR(int intPRNum)
        {
            if (this.InvokeRequired)
            {
                // Need to switch to the main thread
                UpdatePRDelegate HandleUpdatePR = new UpdatePRDelegate(subUpdatePR);
                this.BeginInvoke(HandleUpdatePR, intPRNum);
            }
            else
            {
                // On the main thread now
                FRCSysPosition objPosReg;
                TreeNode objPRNode;
                int intGrpNum;
                TreeNode objGrpNode;

                try
                {
                    objPosReg = mobjPosRegs[Type.Missing, intPRNum - 1];

                    objPRNode = treePosReg.Nodes[intPRNum - 1];
                    if (objPosReg.IsInitialized)
                    {
                        objPRNode.Text = string.Format("PR[{0,4}:{1,-16}] = R", intPRNum, objPosReg.Group[1].Comment);
                    }
                    else
                    {
                        objPRNode.Text = string.Format("PR[{0,4}:{1,-16}] = *", intPRNum, objPosReg.Group[1].Comment);
                    }

                    if (!objPRNode.Nodes[0].Text.Equals("ExpandMe"))
                    {
                        // The group nodes have been expanded. Update them too
                        for (intGrpNum = 1; intGrpNum <= mintNumGroups; intGrpNum++)
                        {
                            objGrpNode = objPRNode.Nodes[intGrpNum - 1];
                            if (objPosReg.Group[(short)intGrpNum].IsInitialized)
                            {
                                objGrpNode.Text = string.Format("G{0} = R", intGrpNum);
                            }
                            else
                            {
                                objGrpNode.Text = string.Format("G{0} = *", intGrpNum);
                            }
                        }
                    }

                    //Indicate a change happened
                    picUpdate.BackColor = Color.FromArgb(255, 255, 0);
                    tmrBlinkUpdate.Enabled = true;

                    treePosReg.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "subUpdatePR");
                }
            }
        }

        #endregion

    }
}