// Module: frmFrames
//
// Description:
//   Display and minipulate User, Tool and Jog Frames
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
    public partial class frmFrames: Form
    {

        #region "Declarations"

        //*************************************************************************
        //                           Declarations
        //*************************************************************************
        private int mintNumGroups;
        private FRCSysPositions mobjToolFrames;
        private FRCSysPosition mobjToolFrame;
        private FRCSysGroupPosition mobjToolGroup;

        private TreeNode mobjTopToolNode;
        private FRCSysPositions mobjUserFrames;
        private FRCSysPosition mobjUserFrame;
        private FRCSysGroupPosition mobjUserGroup;

        private TreeNode mobjTopUserNode;
        private FRCSysPositions mobjJogFrames;
        private FRCSysPosition mobjJogFrame;
        private FRCSysGroupPosition mobjJogGroup;

        private TreeNode mobjTopJogNode;
        private FRCSysGroupPosition mobjSysGrpPosn;

        private FRCSysPosition mobjSysPosn;

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
        public frmFrames()
        {
            InitializeComponent();

            if (FRRobotDemo == null)
                FRRobotDemo = new FRRobotDemo();

            //set min/max size
            this.MinimumSize = this.Size;
        }

        private void frmFrames_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (mobjToolFrame != null)
            {
                mobjToolFrame.Change -= mobjToolFrame_Change;
                mobjToolFrame.CommentChange -= mobjToolFrame_CommentChange;
            }

            if (mobjToolFrames != null)
            {
                mobjToolFrames.Change -= mobjToolFrames_Change;
                mobjToolFrames.CommentChange -= mobjToolFrames_CommentChange;
            }

            if (mobjToolGroup != null)
            {
                mobjToolGroup.Change -= mobjToolGroup_Change;
                mobjToolGroup.CommentChange -= mobjToolGroup_CommentChange;
            }

            if (mobjUserFrame != null)
            {
                mobjUserFrame.Change -= mobjUserFrame_Change;
                mobjUserFrame.CommentChange -= mobjUserFrame_CommentChange;
            }

            if (mobjUserFrames != null)
            {
                mobjUserFrames.Change -= mobjUserFrames_Change;
                mobjUserFrames.CommentChange -= mobjUserFrames_CommentChange;
            }

            if (mobjUserGroup != null)
            {
                mobjUserGroup.Change -= mobjUserGroup_Change;
                mobjUserGroup.CommentChange -= mobjUserGroup_CommentChange;
            }

            if (mobjJogFrame != null)
            {
                mobjJogFrame.Change -= mobjJogFrame_Change;
                mobjJogFrame.CommentChange -= mobjJogFrame_CommentChange;
            }

            if (mobjJogFrames != null)
            {
                mobjJogFrames.Change -= mobjJogFrames_Change;
                mobjJogFrames.CommentChange -= mobjJogFrames_CommentChange;
            }

            if (mobjJogGroup != null)
            {
                mobjJogGroup.Change -= mobjJogGroup_Change;
                mobjJogGroup.CommentChange -= mobjJogGroup_CommentChange;
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: tmrRunOnce_Tick
        //
        // Run this after the form is visible so that the user can watch the tree
        // get populated.
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void tmrRunOnce_Tick(object sender, EventArgs e)
        {
            TreeNode objNode;
            int intFrameNum;
            string strNodeKey;
            string strNodeText;

            try
            {
                tmrRunOnce.Enabled = false;

                mintNumGroups = FRRobotDemo.gobjRobot.CurPosition.NumGroups;
                lblNumGroups.Text = string.Format("{0}{1} ", R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_THIS_HAS_NUMGROUPS, mintNumGroups);
                if (mintNumGroups == 1)
                {
                    lblNumGroups.Text = lblNumGroups.Text + R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_GROUP;
                }
                else
                {
                    lblNumGroups.Text = lblNumGroups.Text + R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_GROUPS;
                }

                // Fill in the tree
                treFrames.Nodes.Clear();

                //  Populate the top level of the Tool Frame
                mobjToolFrames = FRRobotDemo.gobjRobot.ToolFrames;
                //unsubscribe event if already subscribed
                mobjToolFrames.Change -= mobjToolFrames_Change;
                mobjToolFrames.CommentChange -= mobjToolFrames_CommentChange;
                //subscribe event handlers
                mobjToolFrames.Change += mobjToolFrames_Change;
                mobjToolFrames.CommentChange += mobjToolFrames_CommentChange;

                mobjTopToolNode = treFrames.Nodes.Add(R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_TOOL_FRAMES, R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_TOOL_FRAMES);

                // Add an entry for each Tool Frame
                // Loop thru for each PR[] of the robot
                intFrameNum = 0;

                foreach (FRCSysPosition objFrame in mobjToolFrames)
                {
                    intFrameNum += 1;
                    strNodeKey = string.Format("TF[{0}] = ", intFrameNum);
                    strNodeText = string.Format("TF[{0}]", intFrameNum);
                    // Add the node to the list
                    objNode = mobjTopToolNode.Nodes.Add(strNodeKey, strNodeText);
                    objNode.Nodes.Add(strNodeKey, "ExpandMe");
                }

                //  Populate the top level of the User Frame
                mobjUserFrames = FRRobotDemo.gobjRobot.UserFrames;
                //unsubscribe event if already subscribed
                mobjUserFrames.Change -= mobjUserFrames_Change;
                mobjUserFrames.CommentChange -= mobjUserFrames_CommentChange;
                //subscribe event handlers
                mobjUserFrames.Change += mobjUserFrames_Change;
                mobjUserFrames.CommentChange += mobjUserFrames_CommentChange;

                mobjTopUserNode = treFrames.Nodes.Add(R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_USER_FRAMES, R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_USER_FRAMES);

                // Add an entry for each User Frame
                // Loop thru for each PR[] of the robot
                intFrameNum = 0;

                foreach (FRCSysPosition objFrame in mobjUserFrames)
                {
                    intFrameNum += 1;
                    strNodeKey = string.Format("UF[{0}] = ", intFrameNum);
                    strNodeText = string.Format("UF[{0}]", intFrameNum);
                    // Add the node to the list
                    objNode = mobjTopUserNode.Nodes.Add(strNodeKey, strNodeText);
                    objNode.Nodes.Add(strNodeKey, "ExpandMe");
                }

                //  Populate the top level of the Jog Frame
                mobjJogFrames = FRRobotDemo.gobjRobot.JogFrames;
                //unsubscribe event if already subscribed
                mobjJogFrames.Change -= mobjJogFrames_Change;
                mobjJogFrames.CommentChange -= mobjJogFrames_CommentChange;
                //subscribe event handlers
                mobjJogFrames.Change += mobjJogFrames_Change;
                mobjJogFrames.CommentChange += mobjJogFrames_CommentChange;

                mobjTopJogNode = treFrames.Nodes.Add(R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_JOG_FRAMES, R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_JOG_FRAMES);

                // Add an entry for each Jog Frame
                // Loop thru for each PR[] of the robot
                intFrameNum = 0;

                foreach (FRCSysPosition objFrame in mobjJogFrames)
                {
                    intFrameNum += 1;
                    strNodeKey = string.Format("JF[{0}] = ", intFrameNum);
                    strNodeText = string.Format("JF[{0}]", intFrameNum);
                    // Add the node to the list
                    objNode = mobjTopJogNode.Nodes.Add(strNodeKey, strNodeText);
                    objNode.Nodes.Add(strNodeKey, "ExpandMe");
                }

                treFrames.SelectedNode = treFrames.Nodes[0];
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
        // EVENT: treFrames_Expand
        //
        // Expand the tree.
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void treFrames_AfterExpand(object sender, TreeViewEventArgs e)
        {
            TreeNode objNodeToExpland = e.Node;
            TreeNode objNode;
            int intFrameNum;
            FRCSysPosition objFrame;
            int intGrpNum;
            FRCSysGroupPosition objSysGrpPosn;
            string strNodeKey;
            string strNodeText;

            try
            {
                // Get the first sub node
                if (objNodeToExpland.FirstNode.Text.Equals("ExpandMe"))
                {
                    // We need to expand the list since it isn't currently done
                    objNodeToExpland.Nodes.Clear();

                    intFrameNum = objNodeToExpland.Index + 1;
                    if (object.ReferenceEquals(objNodeToExpland.Parent, mobjTopToolNode))
                    {
                        objFrame = mobjToolFrames[intFrameNum];
                    }
                    else if (object.ReferenceEquals(objNodeToExpland.Parent, mobjTopUserNode))
                    {
                        objFrame = mobjUserFrames[intFrameNum];
                    }
                    else
                    {
                        objFrame = mobjJogFrames[intFrameNum];
                    }

                    for (intGrpNum = 1; intGrpNum <= mintNumGroups; intGrpNum++)
                    {
                        objSysGrpPosn = objFrame.Group[(short)intGrpNum];
                        strNodeKey = "G" + intGrpNum.ToString();
                        strNodeText = string.Format("{0}: {1,-16}", strNodeKey, objSysGrpPosn.Comment);
                        objNode = objNodeToExpland.Nodes.Add(strNodeKey, strNodeText);
                        objNode.EnsureVisible();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "treFrames_AfterExpand");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: treFrames_AfterSelect
        //
        // When a new node is selected, decide which buttons are active.
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void treFrames_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                mobjSelectedNode = e.Node;

                // We will be making all new selections
                mobjToolFrame = null;
                mobjToolGroup = null;
                mobjUserFrame = null;
                mobjUserGroup = null;
                mobjJogFrame = null;
                mobjJogGroup = null;
                mobjSysGrpPosn = null;
                mobjSysPosn = null;

                picMonitor.BackColor = Color.FromArgb(128, 0, 0);
                cmdEdit.Enabled = false;
                cmdCopy.Enabled = false;
                cmdPaste.Enabled = false;
                cmdStartMon.Enabled = false;
                cmdStopMon.Enabled = false;

                if (mobjSelectedNode.Parent == null)
                {
                    // This is one of the main catagories. Nothing specific selected
                   
                }
                else
                {
                    // Either a SysPosition or SysGrpPosition.  These buttons are enabled.
                    cmdCopy.Enabled = true;
                    cmdPaste.Enabled = true;
                    

                    if (object.ReferenceEquals(mobjSelectedNode.Parent, mobjTopToolNode))
                    {
                        // This is a Tool Frame SysPosition node
                        mobjToolFrame = mobjToolFrames[Type.Missing, mobjSelectedNode.Index + 0];
                        //unsubscribe event if already subscribed
                        mobjToolFrame.Change -= mobjToolFrame_Change;
                        mobjToolFrame.CommentChange -= mobjToolFrame_CommentChange;
                        //subscribe event handlers
                        mobjToolFrame.Change += mobjToolFrame_Change;
                        mobjToolFrame.CommentChange += mobjToolFrame_CommentChange;

                        mobjSysPosn = mobjToolFrame;
                    }
                    else if (object.ReferenceEquals(mobjSelectedNode.Parent, mobjTopUserNode))
                    {
                        // This is a User Frame SysPosition node
                        mobjUserFrame = mobjUserFrames[Type.Missing, mobjSelectedNode.Index + 1];
                        //unsubscribe event if already subscribed
                        mobjUserFrame.Change -= mobjUserFrame_Change;
                        mobjUserFrame.CommentChange -= mobjUserFrame_CommentChange;
                        //subscribe event handlers
                        mobjUserFrame.Change += mobjUserFrame_Change;
                        mobjUserFrame.CommentChange += mobjUserFrame_CommentChange;

                        mobjSysPosn = mobjUserFrame;
                    }
                    else if (object.ReferenceEquals(mobjSelectedNode.Parent, mobjTopJogNode))
                    {
                        // This is a Jog Frame SysPosition node
                        mobjJogFrame = mobjJogFrames[Type.Missing, mobjSelectedNode.Index + 1];
                        //unsubscribe event if already subscribed
                        mobjJogFrame.Change -= mobjJogFrame_Change;
                        mobjJogFrame.CommentChange -= mobjJogFrame_CommentChange;
                        //subscribe event handlers
                        mobjJogFrame.Change += mobjJogFrame_Change;
                        mobjJogFrame.CommentChange += mobjJogFrame_CommentChange;

                        mobjSysPosn = mobjJogFrame;
                    }
                    else
                    {
                        // Must be a SysGrpPosition.  These buttons are enabled.
                        cmdEdit.Enabled = true;
                        cmdStartMon.Enabled = true;
                        cmdStopMon.Enabled = true;

                        if (object.ReferenceEquals(mobjSelectedNode.Parent.Parent, mobjTopToolNode))
                        {
                            // This is a Tool Frame SysGroupPosition node
                            mobjToolFrame = mobjToolFrames[Type.Missing, mobjSelectedNode.Parent.Index + 0];
                            //unsubscribe event if already subscribed
                            mobjToolFrame.Change -= mobjToolFrame_Change;
                            mobjToolFrame.CommentChange -= mobjToolFrame_CommentChange;
                            //subscribe event handlers
                            mobjToolFrame.Change += mobjToolFrame_Change;
                            mobjToolFrame.CommentChange += mobjToolFrame_CommentChange;

                            mobjToolGroup = mobjToolFrame.Group[(short)(mobjSelectedNode.Index + 1)];
                            //unsubscribe event if already subscribed
                            mobjToolGroup.Change -= mobjToolGroup_Change;
                            mobjToolGroup.CommentChange -= mobjToolGroup_CommentChange;
                            //subscribe event handlers
                            mobjToolGroup.Change += mobjToolGroup_Change;
                            mobjToolGroup.CommentChange += mobjToolGroup_CommentChange;

                            mobjSysGrpPosn = mobjToolGroup;
                            cmdEdit.Enabled = true;
                            cmdStartMon.Enabled = true;
                            cmdStopMon.Enabled = true;
                            if (mobjToolGroup.IsMonitoring)
                            {
                                picMonitor.BackColor = Color.FromArgb(255, 0, 0);
                            }
                            else
                            {
                                picMonitor.BackColor = Color.FromArgb(128, 0, 0);
                            }
                        }
                        else if (object.ReferenceEquals(mobjSelectedNode.Parent.Parent, mobjTopUserNode))
                        {
                            // This is a User Frame SysGroupPosition node
                            mobjUserFrame = mobjUserFrames[Type.Missing, mobjSelectedNode.Parent.Index + 0];
                            //unsubscribe event if already subscribed
                            mobjUserFrame.Change -= mobjUserFrame_Change;
                            mobjUserFrame.CommentChange -= mobjUserFrame_CommentChange;
                            //subscribe event handlers
                            mobjUserFrame.Change += mobjUserFrame_Change;
                            mobjUserFrame.CommentChange += mobjUserFrame_CommentChange;

                            mobjUserGroup = mobjUserFrame.Group[(short)(mobjSelectedNode.Index + 1)];
                            //unsubscribe event if already subscribed
                            mobjUserGroup.Change -= mobjUserGroup_Change;
                            mobjUserGroup.CommentChange -= mobjUserGroup_CommentChange;
                            //subscribe event handlers
                            mobjUserGroup.Change += mobjUserGroup_Change;
                            mobjUserGroup.CommentChange += mobjUserGroup_CommentChange;

                            mobjSysGrpPosn = mobjUserGroup;
                            cmdEdit.Enabled = true;
                            cmdStartMon.Enabled = true;
                            cmdStopMon.Enabled = true;
                            if (mobjUserGroup.IsMonitoring)
                            {
                                picMonitor.BackColor = Color.FromArgb(255, 0, 0);
                            }
                            else
                            {
                                picMonitor.BackColor = Color.FromArgb(128, 0, 0);
                            }
                        }
                        else if (object.ReferenceEquals(mobjSelectedNode.Parent.Parent, mobjTopJogNode))
                        {
                            // This is a Jog Frame SysGroupPosition node
                            mobjJogFrame = mobjJogFrames[Type.Missing, mobjSelectedNode.Parent.Index + 0];
                            //unsubscribe event if already subscribed
                            mobjJogFrame.Change -= mobjJogFrame_Change;
                            mobjJogFrame.CommentChange -= mobjJogFrame_CommentChange;
                            //subscribe event handlers
                            mobjJogFrame.Change += mobjJogFrame_Change;
                            mobjJogFrame.CommentChange += mobjJogFrame_CommentChange;

                            mobjJogGroup = mobjJogFrame.Group[(short)(mobjSelectedNode.Index + 1)];
                            //unsubscribe event if already subscribed
                            mobjJogGroup.Change -= mobjJogGroup_Change;
                            mobjJogGroup.CommentChange -= mobjJogGroup_CommentChange;
                            //subscribe event handlers
                            mobjJogGroup.Change += mobjJogGroup_Change;
                            mobjJogGroup.CommentChange += mobjJogGroup_CommentChange;

                            mobjSysGrpPosn = mobjJogGroup;
                            cmdEdit.Enabled = true;
                            cmdStartMon.Enabled = true;
                            cmdStopMon.Enabled = true;
                            if (mobjJogGroup.IsMonitoring)
                            {
                                picMonitor.BackColor = Color.FromArgb(255, 0, 0);
                            }
                            else
                            {
                                picMonitor.BackColor = Color.FromArgb(128, 0, 0);
                            }
                        }
                        else
                        {
                            MessageBox.Show("This should never happen");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "treFrames_AfterSelect");
            }
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
            try
            {
                if (frmEditPosition == null || frmEditPosition.IsDisposed)
                    frmEditPosition = new frmEditPosition();

                frmEditPosition.EditReg(mobjSysGrpPosn);

                //The Record/Uninit status may have changed so
                // we need to update the treview node of it.
                mobjSelectedNode.Text = string.Format("G{0}: {1,-16}", mobjSelectedNode.Index + 1, mobjSysGrpPosn.Comment);
                treFrames.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cmdEdit_Click");
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
                if (mobjSysGrpPosn == null)
                {
                    mobjSysPosn.Refresh();
                    subUpdateSysPosn(mobjSysPosn);
                }
                else
                {
                    mobjSysGrpPosn.Refresh();
                    mobjSelectedNode.Text = string.Format("G{0}: {1,-16}", mobjSelectedNode.Index + 1, mobjSysGrpPosn.Comment);
                    treFrames.Focus();
                }
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
                if (mobjSysGrpPosn == null)
                {
                    mobjSysPosn.Update();
                }
                else
                {
                    mobjSysGrpPosn.Update();
                }
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
                if (mobjSysGrpPosn == null)
                {
                    FRRobotDemo.gobjPositionCopySource = mobjSysPosn;
                }
                else
                {
                    FRRobotDemo.gobjPositionCopySource = mobjSysGrpPosn;
                }
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
                if (mobjSysGrpPosn == null)
                {
                    mobjSysPosn.Copy(FRRobotDemo.gobjPositionCopySource);
                    subUpdateSysPosn(mobjSysPosn);
                }
                else
                {
                    mobjSysGrpPosn.Copy(FRRobotDemo.gobjPositionCopySource);
                    mobjSelectedNode.Text = string.Format("G{0}: {1,-16}", mobjSelectedNode.Index + 1, mobjSysGrpPosn.Comment);
                    treFrames.Focus();
                }
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
                mobjSysGrpPosn.StartMonitor(int.Parse(txtLatency.Text));
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
                mobjSysGrpPosn.StopMonitor();
                picMonitor.BackColor = Color.FromArgb(128, 0, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cmdStopMon_Click");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdAddToScattAccess_Click
        //
        // Add this item to the Scattered Access list
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //private void cmdAddToScattAccess_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (frmScattAccess == null || frmScattAccess.IsDisposed)
        //            frmScattAccess = new frmScattAccess();

        //        if (mobjSysGrpPosn == null)
        //        {
        //            frmScattAccess.AddItem(mobjSysPosn);
        //        }
        //        else
        //        {
        //            frmScattAccess.AddItem(mobjSysGrpPosn);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "cmdAddToScattAccess_Click");
        //    }
        //}

        #endregion

        #region "Robot Server Events"

        //*************************************************************************
        //                        Robot Server Events
        //*************************************************************************

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: mobjToolFrames_Change
        //
        // Posts an entry to the event form and updates the entry in the treeview
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private delegate void ToolFramesChangeDelegate(int Id, short GroupNum);
        private void mobjToolFrames_Change(int Id, short GroupNum)
        {
            if (this.InvokeRequired)
            {
                // Need to switch to the main thread
                ToolFramesChangeDelegate HandleToolFramesChange = new ToolFramesChangeDelegate(mobjToolFrames_Change);
                this.BeginInvoke(HandleToolFramesChange, Id, GroupNum);
            }
            else
            {
                // On the main thread now
                FRRobotDemo.LogEvent(this, string.Format("mobjToolFrames_Change Id={0}, GroupNum={1}", Id, GroupNum));
                subUpdateSysPosn(mobjToolFrames[Type.Missing, Id]);
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: mobjToolFrames_CommentChange
        //
        // Posts an entry to the event form and updates the entry in the treeview
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private delegate void ToolFramesCommentChangeDelegate(int Id, short GroupNum);
        private void mobjToolFrames_CommentChange(int Id, short GroupNum)
        {
            if (this.InvokeRequired)
            {
                // Need to switch to the main thread
                ToolFramesCommentChangeDelegate HandleToolFramesCommentChange = new ToolFramesCommentChangeDelegate(mobjToolFrames_Change);
                this.BeginInvoke(HandleToolFramesCommentChange, Id, GroupNum);
            }
            else
            {
                // On the main thread now
                FRRobotDemo.LogEvent(this, string.Format("mobjToolFrames_CommentChange Id={0}, GroupNum={1}", Id, GroupNum));
                subUpdateSysPosn(mobjToolFrames[Type.Missing, (short)Id]);
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: mobjUserFrames_Change
        //
        // Posts an entry to the event form and updates the entry in the treeview
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private delegate void UserFramesChangeDelegate(int Id, short GroupNum);
        private void mobjUserFrames_Change(int Id, short GroupNum)
        {
            if (this.InvokeRequired)
            {
                // Need to switch to the main thread
                UserFramesChangeDelegate HandleUserFramesChange = new UserFramesChangeDelegate(mobjUserFrames_Change);
                this.BeginInvoke(HandleUserFramesChange, Id, GroupNum);
            }
            else
            {
                // On the main thread now
                FRRobotDemo.LogEvent(this, string.Format("mobjUserFrames_Change Id={0}, GroupNum={1}", Id, GroupNum));
                subUpdateSysPosn(mobjUserFrames[GroupNum, Id]);
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: mobjUserFrames_CommentChange
        //
        // Posts an entry to the event form and updates the entry in the treeview
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private delegate void UserFramesCommentChangeDelegate(int Id, short GroupNum);
        private void mobjUserFrames_CommentChange(int Id, short GroupNum)
        {
            if (this.InvokeRequired)
            {
                // Need to switch to the main thread
                UserFramesCommentChangeDelegate HandleUserFramesCommentChange = new UserFramesCommentChangeDelegate(mobjUserFrames_Change);
                this.BeginInvoke(HandleUserFramesCommentChange, Id, GroupNum);
            }
            else
            {
                // On the main thread now
                FRRobotDemo.LogEvent(this, string.Format("mobjUserFrames_CommentChange Id={0}, GroupNum={1}", Id, GroupNum));
                subUpdateSysPosn(mobjUserFrames[Type.Missing, Id]);
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: mobjJogFrames_Change
        //
        // Posts an entry to the event form and updates the entry in the treeview
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private delegate void JogFramesChangeDelegate(int Id, short GroupNum);
        private void mobjJogFrames_Change(int Id, short GroupNum)
        {
            if (this.InvokeRequired)
            {
                // Need to switch to the main thread
                JogFramesChangeDelegate HandleJogFramesChange = new JogFramesChangeDelegate(mobjJogFrames_Change);
                this.BeginInvoke(HandleJogFramesChange, Id, GroupNum);
            }
            else
            {
                // On the main thread now
                FRRobotDemo.LogEvent(this, string.Format("mobjJogFrames_Change Id={0}, GroupNum={1}", Id, GroupNum));
                subUpdateSysPosn(mobjJogFrames[Type.Missing, Id]);
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: mobjJogFrames_CommentChange
        //
        // Posts an entry to the event form and updates the entry in the treeview
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private delegate void JogFramesCommentChangeDelegate(int Id, short GroupNum);
        private void mobjJogFrames_CommentChange(int Id, short GroupNum)
        {
            if (this.InvokeRequired)
            {
                // Need to switch to the main thread
                JogFramesCommentChangeDelegate HandleJogFramesCommentChange = new JogFramesCommentChangeDelegate(mobjJogFrames_Change);
                this.BeginInvoke(HandleJogFramesCommentChange, Id, GroupNum);
            }
            else
            {
                // On the main thread now
                FRRobotDemo.LogEvent(this, string.Format("mobjJogFrames_CommentChange Id={0}, GroupNum={1}", Id, GroupNum));
                subUpdateSysPosn(mobjJogFrames[GroupNum, Id]);
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: All the specific syspositon and sysgroupposition Events.
        // Just log them
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void mobjToolFrame_Change(short GroupNum)
        {
            FRRobotDemo.LogEvent(this, string.Format("mobjToolFrame_Change Event GroupNum={0}", GroupNum));
        }

        private void mobjToolFrame_CommentChange(short GroupNum)
        {
            FRRobotDemo.LogEvent(this, string.Format("mobjToolFrame_CommentChange Event GroupNum={0}", GroupNum));
        }

        private void mobjToolGroup_Change()
        {
            FRRobotDemo.LogEvent(this, "mobjToolGroup_Change Event");
        }

        private void mobjToolGroup_CommentChange()
        {
            FRRobotDemo.LogEvent(this, "mobjToolGroup_CommentChange Event");
        }

        private void mobjUserFrame_Change(short GroupNum)
        {
            FRRobotDemo.LogEvent(this, string.Format("mobjUserFrame_Change Event GroupNum={0}", GroupNum));
        }

        private void mobjUserFrame_CommentChange(short GroupNum)
        {
            FRRobotDemo.LogEvent(this, string.Format("mobjUserFrame_CommentChange Event GroupNum={0}", GroupNum));
        }

        private void mobjUserGroup_Change()
        {
            FRRobotDemo.LogEvent(this, "mobjUserGroup_Change Event");
        }

        private void mobjUserGroup_CommentChange()
        {
            FRRobotDemo.LogEvent(this, "mobjUserGroup_CommentChange Event");
        }

        private void mobjJogFrame_Change(short GroupNum)
        {
            FRRobotDemo.LogEvent(this, string.Format("mobjJogFrame_Change Event GroupNum={0}", GroupNum));
        }

        private void mobjJogFrame_CommentChange(short GroupNum)
        {
            FRRobotDemo.LogEvent(this, string.Format("mobjJogFrame_CommentChange Event GroupNum={0}", GroupNum));
        }

        private void mobjJogGroup_Change()
        {
            FRRobotDemo.LogEvent(this, "mobjJogGroup_Change Event");
        }

        private void mobjJogGroup_CommentChange()
        {
            FRRobotDemo.LogEvent(this, "mobjJogGroup_CommentChange Event");
        }

        #endregion

        #region "Utility Routines"

        //*************************************************************************
        //                        Utility Routines
        //*************************************************************************

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // Routine: subUpdateSysPosn
        //
        // Update the tree node for the position register.
        // Switch to the main thread if required.
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private delegate void UpdateSysPosnDelegate(FRCSysPosition objSysPosn);
        private void subUpdateSysPosn(FRCSysPosition objSysPosn)
        {
            if (this.InvokeRequired)
            {
                // Need to switch to the main thread
                UpdateSysPosnDelegate HandleUpdateSysPosn = new UpdateSysPosnDelegate(subUpdateSysPosn);
                this.BeginInvoke(HandleUpdateSysPosn, objSysPosn);
            }
            else
            {
                // On the main thread now
                int Id;
                TreeNode objNode;
                int intGrpNum = 0;
                TreeNode objGrpNode;

                try
                {
                    Id = objSysPosn.Id;
                    if (object.ReferenceEquals(objSysPosn, mobjToolFrames[Id, Type.Missing]))
                    {
                        objNode = mobjTopToolNode.Nodes[Id - 1];
                    }
                    else if (object.ReferenceEquals(objSysPosn, mobjUserFrames))
                    {
                        objNode = mobjTopUserNode.Nodes[Id - 1];
                    }
                    else
                    {
                        objNode = mobjTopJogNode.Nodes[Id - 1];
                    }

                    if (!objNode.Nodes[0].Text.Equals("ExpandMe"))
                    {
                        // The group nodes have been expanded. Update them
                        for (intGrpNum = 1; intGrpNum <= mintNumGroups; intGrpNum++)
                        {
                            objGrpNode = objNode.Nodes[intGrpNum - 1];
                            objGrpNode.Text = string.Format("G{0}: {1,-16}", intGrpNum, objSysPosn.Group[(short)intGrpNum].Comment);
                        }
                    }

                    //Indicate a change happened
                    picUpdate.BackColor = Color.FromArgb(255, 255, 0);
                    tmrBlinkUpdate.Enabled = true;

                    treFrames.Focus();
                }
                catch (Exception ex)
                {
                    // ignore errors
                    MessageBox.Show(ex.Message, "subUpdateSysPosn");
                }
            }
        }

        #endregion

    }
}