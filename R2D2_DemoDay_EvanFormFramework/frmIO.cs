// Module: frmIO
//
// Description:
//   Display the I/O of a robot
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
    public partial class frmIO : Form
    {

        #region "Declarations"

        //*************************************************************************
        //                           Declarations
        //*************************************************************************
        private TreeNode mobjTopNode;
        private FRCIOTypes mobjIOTypes;
        private FRCIOType mobjIOType;
        private FRCIOSignals mobjIOSignals;
        private FRCIOSignal mobjIOSignal;
        private FRCIOConfigs mobjIOConfigs;
        private FRCIOConfig mobjIOConfig;

        private bool mblnUpdateDetail = false;

        private bool mblnLocalInit;
        private bool mblnIgnoreLeave = false;

        FRRobotDemo FRRobotDemo;
        frmIOConfigAdd frmIOConfigAdd;
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
        public frmIO()
        {
            InitializeComponent();

            if (FRRobotDemo == null)
                FRRobotDemo = new FRRobotDemo();
            //set min/max size
            this.MinimumSize = this.Size;
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: Form_Load
        //
        // Trigger the Update timer so that the form will be up while the 
        // I/O type tree is being populated.
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void frmIO_Load(object sender, EventArgs e)
        {
            // Watch for events on I/O types collection
            mobjIOTypes = FRRobotDemo.gobjRobot.IOTypes;

            picEvent.BackColor = Color.FromArgb(128, 128, 0);

            mobjTopNode = null;
            tmrRunOnce.Enabled = true;
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: frmIO_FormClosing
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void frmIO_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mobjIOSignal != null)
            {
                mobjIOSignal.Change -= mobjIOSignal_Change;
                mobjIOSignal.Simulate -= mobjIOSignal_Simulate;
                mobjIOSignal.Unsimulate -= mobjIOSignal_Unsimulate;
            }
            if (mobjIOSignals != null)
            {
                mobjIOSignals.Change -= mobjIOSignals_Change;
                mobjIOSignals.Simulate -= mobjIOSignals_Simulate;
                mobjIOSignals.Unsimulate -= mobjIOSignals_Unsimulate;
            }

            mobjIOSignals = null;
            mobjIOSignal = null;
            mobjIOConfigs = null;
            mobjIOConfig = null;
            mobjIOType = null;
            mobjIOTypes = null;
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: tmrRunOnce_Tick
        //
        // Do many of the UIF updates on the timer tick
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void tmrRunOnce_Tick(object sender, EventArgs e)
        {
            tmrRunOnce.Enabled = false;
            InitializeIOTree();
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: tmrUpdate_Tick
        //
        // Do many of the UIF updates on the timer tick
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            try
            {
                if (mblnUpdateDetail)
                {
                    UpdateDetail(treIO.SelectedNode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "tmrUpdate_tick");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: tmrEvent_Timer
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void tmrEvent_Tick(object sender, EventArgs e)
        {
            picEvent.BackColor = Color.FromArgb(128, 128, 0);
            tmrEvent.Enabled = false;
        }

        #endregion

        #region "User Input Events"

        //*************************************************************************
        //                        User Input Events
        //*************************************************************************

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: treIO_AfterSelect
        //
        // New node selected
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void treIO_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode objSelectedNode = e.Node;
            TreeNode objNewTopNode = new TreeNode();

            // Find the IOType top node
            objNewTopNode = objSelectedNode;

            while (objNewTopNode.Parent != null)
            {
                objNewTopNode = objNewTopNode.Parent;
            }

            if (!object.ReferenceEquals(objNewTopNode, mobjTopNode))
            {
                dynamic IOType = mobjIOType;
                // Just switched I/O type
                mobjTopNode = objNewTopNode;
                IOType = mobjIOTypes[Type.Missing, mobjTopNode.Index];
                mobjIOType = IOType;
                mobjIOSignals = IOType.Signals;
                if (IOType.CanConfigure)
                {
                    mobjIOConfigs = IOType.Configs;
                }
                UpdateIOTypeDetail();
            }
            UpdateDetail(objSelectedNode);
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: treSysVars_AfterExpand
        //
        // Expand the node to list the sub vars
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void treIO_AfterExpand(object sender, TreeViewEventArgs e)
        {
            TreeNode objNode = e.Node;
            TreeNode objTopNode;
            dynamic IOType;
            string strIOConfig;

            // Get the first sub node
            if (e.Node.FirstNode.Text.Equals("ExpandMe"))
            {
                // Find this node's IOType top node
                objTopNode = e.Node;

                while (objTopNode.Parent != null)
                {
                    objTopNode = objTopNode.Parent;
                }
                IOType = mobjIOTypes[Type.Missing, objTopNode.Index];

                // We need to expand the list since it isn't currently done
                e.Node.Nodes.Clear();

                if (e.Node.Text.Equals(R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_SIGNALS))
                {
                    // Since Digital, Analog and Group I/O are always enabled IOTypes
                    // its possible to have an empty signals if nothing is configured.
                    foreach (FRCIOSignal objSignal in IOType.Signals)
                    {
                        e.Node.Nodes.Add(objSignal.LogicalNum.ToString());
                    }
                }
                else if (e.Node.Text.Equals(R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_CONFIG))
                {
                    // Loop thru all the configs in the collection
                    foreach (FRCIOConfig objIOConfig in IOType.Configs)
                    {
                        // Add to the list
                        strIOConfig = "[" + objIOConfig.FirstLogicalNum.ToString() + "- " + (objIOConfig.FirstLogicalNum + objIOConfig.NumSignals - 1).ToString() + "] ";

                        e.Node.Nodes.Add(strIOConfig);
                    }
                }
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdStartMonitorSig_Click
        //
        // Start monitoring the current IOSignal
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdStartMonitorSig_Click(object sender, EventArgs e)
        {
            try
            {
                if (mobjIOSignal != null)
                {
                    mobjIOSignal.StartMonitor(short.Parse(txtLatencySig.Text));
                    if (mobjIOSignal.IsMonitoring)
                    {
                        picMonitor.BackColor = Color.FromArgb(255, 0, 0);
                    }
                    else
                    {
                        picMonitor.BackColor = Color.FromArgb(128, 0, 0);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cmdStartMonitorSig_Click");
            }
            finally
            {
                treIO.Focus();
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdStopMonitorSig_Click
        //
        // Stop monitoring the current IOSignal
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdStopMonitorSig_Click(object sender, EventArgs e)
        {
            try
            {
                if (mobjIOSignal != null)
                {
                    mobjIOSignal.StopMonitor();
                    if (mobjIOSignal.IsMonitoring)
                    {
                        picMonitor.BackColor = Color.FromArgb(255, 0, 0);
                    }
                    else
                    {
                        picMonitor.BackColor = Color.FromArgb(128, 0, 0);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cmdStopMonitorSig_Click");
            }
            finally
            {
                treIO.Focus();
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdStartMonitorSigs_Click
        //
        // Start Monitoring all the IOSignals
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdStartMonitorSigs_Click(object sender, EventArgs e)
        {
            try
            {
                if (mobjIOSignals != null)
                {
                    mobjIOSignals.StartMonitor(short.Parse(txtLatencyAll.Text));
                    if (mobjIOSignals.IsMonitoring)
                    {
                        PicMonitorSigs.BackColor = Color.FromArgb(255, 0, 0);
                    }
                    else
                    {
                        PicMonitorSigs.BackColor = Color.FromArgb(128, 0, 0);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cmdStartMonitorSigs_Click");
            }
            finally
            {
                treIO.Focus();
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdStopMonitorSigs_Click
        //
        // Stop Monitoring all the IOSignals
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdStopMonitorSigs_Click(object sender, EventArgs e)
        {
            try
            {
                if (mobjIOSignals != null)
                {
                    mobjIOSignals.StopMonitor();
                    if (mobjIOSignals.IsMonitoring)
                    {
                        PicMonitorSigs.BackColor = Color.FromArgb(255, 0, 0);
                    }
                    else
                    {
                        PicMonitorSigs.BackColor = Color.FromArgb(128, 0, 0);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cmdStopMonitorSigs_Click");
            }
            finally
            {
                treIO.Focus();
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdRefreshSigs_Click
        //
        // Refresh the Signals Collection
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdRefreshSigs_Click(object sender, EventArgs e)
        {
            try
            {
                mobjIOSignals.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cmdRefreshSigs_Click");
            }
            finally
            {
                treIO.Focus();
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: chkNoRefreshSigs_Click
        //
        // Set/reset the NoRefresh property on this Signal
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void chkNoRefreshSigs_Click(object sender, EventArgs e)
        {
            if (!mblnLocalInit)
            {
                try
                {
                    mobjIOSignals.NoRefresh = chkNoRefreshSigs.Checked;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "chkNoRefreshSigs_Click");
                }
                finally
                {
                    treIO.Focus();
                }
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdOn_Click cmdOff_Click
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdOn_Click(object sender, EventArgs e)
        {
            txtIOValue.Text = "True";
            txtIOValue_KeyPress(txtIOValue, new System.Windows.Forms.KeyPressEventArgs((char)(13)));
            treIO.Focus();
        }

        private void cmdOff_Click(object sender, EventArgs e)
        {
            txtIOValue.Text = "False";
            txtIOValue_KeyPress(txtIOValue, new System.Windows.Forms.KeyPressEventArgs((char)(13)));
            treIO.Focus();
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: txtIOValue_KeyPress
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void txtIOValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                try
                {
                    dynamic IOType = mobjIOType;
                    dynamic IOSignal = mobjIOSignal;
                    e.Handled = true;
                    if (IOType.IsBoolean) 
                    {
                        bool value = false;
                        switch (txtIOValue.Text)
                        {
                            case "1":
                            case "True":
                            case "TRUE":
                            case "true":
                            case "T":
                            case "t":
                            case "On":
                            case "ON":
                            case "on":
                                value = true;
                                break;
                            case "0":
                            case "False":
                            case "FALSE":
                            case "false":
                            case "F":
                            case "f":
                            case "Off":
                            case "OFF":
                            case "off":
                                break;
                            default:
                                MessageBox.Show("Please enter 1, 0, On, Off, True or False");
                                break;
                        }
                        IOSignal.Value = value;
                    }
                    else
                    {
                        IOSignal.Value = int.Parse(txtIOValue.Text);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "txtIOValue_KeyPress1");
                }
                finally
                {
                    try
                    {
                        dynamic IOSignal = mobjIOSignal;
                        txtIOValue.Text = IOSignal.Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "txtIOValue_KeyPress");
                    }
                    treIO.Focus();
                }
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: txtIOComment events
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void txtIOComment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                try
                {
                    e.Handled = true;
                    mblnIgnoreLeave = true; 
                    mobjIOSignal.Comment = txtIOComment.Text;
                }
                catch (Exception ex)
                {
                    // For some reason the controller throws the SCIO-030 error
                    // When the comment is set to an empty string.
                    // Don't bother the user with that.
                    if (txtIOComment.Text.Length != 0) 
                    {
                        MessageBox.Show(ex.Message, "txtIOComment_KeyPress");
                    }
                }
                finally
                {
                    treIO.Focus();
                    mblnIgnoreLeave = false; 
                }
            }
        }

        private void txtIOComment_Leave(object sender, EventArgs e)
        {
            if (mblnIgnoreLeave) 
            {
                // User hit enter and focus was returned to the tree
                // Don't apply the change twice
                mblnIgnoreLeave = false;
                return;
            }

            try
            {
                mobjIOSignal.Comment = txtIOComment.Text;
            }
            catch (Exception ex)
            {
                // For some reason the controller throws the SCIO-030 error
                // When the comment is set to an empty string.
                // Don't bother the user with that.
                if (txtIOComment.Text.Length != 0) 
                {
                    MessageBox.Show(ex.Message, "txtIOComment_Leave");
                }
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdRefreshSig_Click
        //
        // Refresh this Signal
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdRefreshSig_Click(object sender, EventArgs e)
        {
            try
            {
                mobjIOSignal.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cmdRefreshSig_Click");
            }
            finally
            {
                UpDateSignalDetail();
                treIO.Focus();
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdUdateSig_Click
        //
        // Update this Signal
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdUpdateSig_Click(object sender, EventArgs e)
        {
            try
            {
                mobjIOSignal.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cmdUpdateSig_Click");
            }
            finally
            {
                treIO.Focus();
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: chkNoRefreshSig_Click
        //
        // Set/reset the NoRefresh property on this Signal
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void chkNoRefreshSig_Click(object sender, EventArgs e)
        {
            if (!mblnLocalInit)
            {
                try
                {
                    mobjIOSignal.NoRefresh = chkNoRefreshSig.Checked;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "chkNoRefreshSig_Click");
                }
                finally
                {
                    UpDateSignalDetail();
                }
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: chkNoUpdateSig_Click
        //
        // Set/reset the NoUpdate property on this Signal
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void chkNoUpdateSig_Click(object sender, EventArgs e)
        {
            if (!mblnLocalInit)
            {
                try
                {
                    mobjIOSignal.NoUpdate = chkNoUpdateSig.Checked;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "chkNoUpdateSig_Click");
                }
                finally
                {
                    UpDateSignalDetail();
                }
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: chkSignalSimulate_CheckedChanged
        //
        // Set/reset the Simulate property on this Signal
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void chkSignalSimulate_CheckedChanged(object sender, EventArgs e)
        {
            if (!mblnLocalInit)
            {
                try
                {
                    dynamic IOSginal = mobjIOSignal;
                    IOSginal.Simulate = chkSignalSimulate.Checked;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "chkSignalSimulate_CheckedChanged");
                }
                finally
                {
                    treIO.Focus();
                }
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: chkSignalPolarity_CheckedChanged
        //
        // Set/reset the Polarity property on this Signal
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void chkSignalPolarity_CheckedChanged(object sender, EventArgs e)
        {
            if (!mblnLocalInit)
            {
                try
                {
                    dynamic IOSignal = mobjIOSignal;
                    IOSignal.Polarity = chkSignalPolarity.Checked;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "chkSignalPolarity_CheckedChanged");
                }
                finally
                {
                    treIO.Focus();
                }
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: chkSignalComplementary_CheckedChanged
        //
        // Set/reset the Complementary property on this Signal
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void chkSignalComplementary_CheckedChanged(object sender, EventArgs e)
        {
            dynamic IOsignal;
            IOsignal = mobjIOSignal;

            if (!mblnLocalInit)
            {
                try
                {
                    IOsignal.Complementary = chkSignalComplementary.Checked;
                    mobjIOSignal = IOsignal;
                    //unsubscribe event if already subscribed
                    mobjIOSignal.Change -= mobjIOSignal_Change;
                    mobjIOSignal.Simulate -= mobjIOSignal_Simulate;
                    mobjIOSignal.Unsimulate -= mobjIOSignal_Unsimulate;
                    //subscribe event handlers
                    mobjIOSignal.Change += mobjIOSignal_Change;
                    mobjIOSignal.Simulate += mobjIOSignal_Simulate;
                    mobjIOSignal.Unsimulate += mobjIOSignal_Unsimulate;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "chkSignalComplementary_CheckedChanged");
                }
                finally
                {
                    treIO.Focus();
                }
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdAddToScattAccess_Click
        //
        // Add this item to the ScatteredAccess collection
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //private void cmdAddToScattAccess_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (frmScattAccess == null || frmScattAccess.IsDisposed)
        //            frmScattAccess = new frmScattAccess();

        //        frmScattAccess.AddItem(mobjIOSignal);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "cmdAddToScattAccess_Click");
        //    }
        //    finally
        //    {
        //        treIO.Focus();
        //    }
        //}

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: txtFirstLogicalNum_TextChanged
        //
        // Add this item to the ScatteredAccess collection
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void txtFirstLogicalNum_TextChanged(object sender, EventArgs e)
        {
            if (!mblnLocalInit)
            {
                MessageBox.Show(R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_FIRST_LOGICAL_NUM_IS_READONLY);
                mblnLocalInit = true;
                txtFirstLogicalNum.Text = mobjIOConfig.FirstLogicalNum.ToString();
                mblnLocalInit = false;
                treIO.Focus();
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: txtXXX_KeyPress and Leave Events
        // These events are used to send specific config data to the controller
        // when the Enter key is pressed in their respective text boxes
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void txtNumSignals_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                try
                {
                    e.Handled = true;
                    mblnIgnoreLeave = true; 
                    mobjIOConfig.NumSignals = int.Parse(txtNumSignals.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "txtNumSignals_KeyPress");
                }
                finally
                {
                    UpDateConfigDetail();
                    mblnIgnoreLeave = false; 
                }
            }
        }

        private void txtNumSignals_Leave(object sender, EventArgs e)
        {
            if (mblnIgnoreLeave) 
            {
                // User hit enter and focus was returned to the tree
                // Don't apply the change twice
                mblnIgnoreLeave = false;
                return;
            }

            if (mobjIOConfig.NumSignals != int.Parse(txtNumSignals.Text))
            {
                // Value changed without pressing ENTER.  Appy the change
                try
                {
                    mobjIOConfig.NumSignals = int.Parse(txtNumSignals.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "txtNumSignals_Leave");
                }
                finally
                {
                    UpDateConfigDetail();
                }
            }
        }

        private void txtRack_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                try
                {
                    e.Handled = true;
                    mblnIgnoreLeave = true; 
                    mobjIOConfig.Rack = short.Parse(txtRack.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "txtRack_KeyPress");
                }
                finally
                {
                    UpDateConfigDetail();
                    mblnIgnoreLeave = false; 
                }
            }
        }

        private void txtRack_Leave(object sender, EventArgs e)
        {
            if (mblnIgnoreLeave) 
            {
                // User hit enter and focus was returned to the tree
                // Don't apply the change twice
                mblnIgnoreLeave = false;
                return;
            }

            if (mobjIOConfig.Rack != short.Parse(txtRack.Text))
            {
                // Value changed without pressing ENTER.  Appy the change
                try
                {
                    mobjIOConfig.Rack = short.Parse(txtRack.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "txtRack_Leave");
                }
                finally
                {
                    UpDateConfigDetail();
                }
            }
        }

        private void txtSlot_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                try
                {
                    e.Handled = true;
                    mblnIgnoreLeave = true; 
                    mobjIOConfig.Slot = short.Parse(txtSlot.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "txtSlot_KeyPress");
                }
                finally
                {
                    UpDateConfigDetail();
                    mblnIgnoreLeave = false; 
                }
            }
        }

        private void txtSlot_Leave(object sender, EventArgs e)
        {
            if (mblnIgnoreLeave) 
            {
                // User hit enter and focus was returned to the tree
                // Don't apply the change twice
                mblnIgnoreLeave = false;
                return;
            }

            if (mobjIOConfig.Slot != short.Parse(txtSlot.Text))
            {
                // Value changed without pressing ENTER.  Appy the change
                try
                {
                    mobjIOConfig.Slot = short.Parse(txtSlot.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "txtSlot_Leave");
                }
                finally
                {
                    UpDateConfigDetail();
                }
            }
        }

        private void txtPhysicalType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                try
                {
                    e.Handled = true;
                    mblnIgnoreLeave = true; 
                    mobjIOConfig.PhysicalType = int.Parse(txtPhysicalType.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "txtPhysicalType_KeyPress");
                }
                finally
                {
                    UpDateConfigDetail();
                    mblnIgnoreLeave = false; 
                }
            }
        }

        private void txtPhysicalType_Leave(object sender, EventArgs e)
        {
            if (mblnIgnoreLeave) 
            {
                // User hit enter and focus was returned to the tree
                // Don't apply the change twice
                mblnIgnoreLeave = false;
                return;
            }

            if (mobjIOConfig.PhysicalType != int.Parse(txtPhysicalType.Text))
            {
                // Value changed without pressing ENTER.  Appy the change
                try
                {
                    mobjIOConfig.PhysicalType = int.Parse(txtPhysicalType.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "txtPhysicalType_Leave");
                }
                finally
                {
                    UpDateConfigDetail();
                }
            }
        }

        private void txtFirstPhysicalNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                try
                {
                    e.Handled = true;
                    mblnIgnoreLeave = true; 
                    mobjIOConfig.FirstPhysicalNum = int.Parse(txtFirstPhysicalNum.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "txtFirstPhysicalNum_KeyPress");
                }
                finally
                {
                    UpDateConfigDetail();
                    mblnIgnoreLeave = false; 
                }
            }
        }

        private void txtFirstPhysicalNum_Leave(object sender, EventArgs e)
        {
            if (mblnIgnoreLeave) 
            {
                // User hit enter and focus was returned to the tree
                // Don't apply the change twice
                mblnIgnoreLeave = false;
                return;
            }

            if (mobjIOConfig.FirstPhysicalNum != int.Parse(txtFirstPhysicalNum.Text))
            {
                // Value changed without pressing ENTER.  Appy the change
                try
                {
                    mobjIOConfig.FirstPhysicalNum = int.Parse(txtFirstPhysicalNum.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "txtFirstPhysicalNum_Leave");
                }
                finally
                {
                    UpDateConfigDetail();
                }
            }
        }

        #endregion

        #region "Robot Server Events"

        //*************************************************************************
        //                        Robot Server Events
        //*************************************************************************
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: mobjIOSignal_Change
        //
        // Updates the signal value when changed and monitoring is on
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private delegate void IOSignalChangeDelegate();
        private void mobjIOSignal_Change()
        {
            if (this.InvokeRequired)
            {
                IOSignalChangeDelegate HandleSignalChanged = new IOSignalChangeDelegate(mobjIOSignal_Change);
                this.BeginInvoke(HandleSignalChanged);
            }
            else
            {
                try
                {
                    dynamic IOSignal;
                    IOSignal = mobjIOSignal;
                    txtIOValue.Text = IOSignal.Value.ToString();

                    picEvent.BackColor = Color.FromArgb(255, 255, 0);
                    tmrEvent.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "mobjIOSignal_Change");
                }
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: mobjIOSignal_Simulate and _Unsimulate
        //
        // Log it then update the signal's Sim status when changed
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void mobjIOSignal_Simulate()
        {
            dynamic IOSignal = mobjIOSignal;
            FRRobotDemo.LogEvent(this, "Simulate Event on Signal: " + "Type: " + IOSignal.Parent.Parent.Type.ToString() + ", Num: " + mobjIOSignal.LogicalNum.ToString());
            mblnUpdateDetail = true;
        }

        void mobjIOSignal_Unsimulate()
        {
            dynamic IOSignal = mobjIOSignal;
            FRRobotDemo.LogEvent(this, "UnSimulate Event on Signal: " + "Type: " + IOSignal.Parent.Parent.Type.ToString() + ", Num: " + mobjIOSignal.LogicalNum.ToString());
            mblnUpdateDetail = true;
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: mobjIOSignals_Change
        //
        // Update IOSignal collection data when changed and monitoring is on
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void mobjIOSignals_Change(dynamic IOSignal)
        {
            int intCount;
            int intIndex;

            //more?
            if (IOSignal is Object)
            {
                //a single I/O point event
            }
            else
            {
                //an array of logical numbers
                if (mobjIOSignal != null)
                {
                    //an IO signal object exists
                    intCount = IOSignal.ToString().Length;
                    for (intIndex = 0; intIndex <= intCount; intIndex++)
                    {
                        if ((IOSignal).LogicalNum == mobjIOSignal.LogicalNum)
                        {
                            //we found an event
                            mobjIOSignal_Change();
                        }
                    }
                }
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: mobjIOSignals_Simulate and _Unsimulate
        //
        // Log the events
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void mobjIOSignals_Simulate(dynamic IOSignal)
        {
            int intCount;
            int intIndex;
            FREIOTypeConstants enuTypeCode;

            enuTypeCode = (FREIOTypeConstants)mobjIOSignals.Parent.Type;

            if (IOSignal is Object)
            {
                //Single I/O signal event
                FRRobotDemo.LogEvent(this, "Simulate Event on Signals: " + "Type: " + enuTypeCode.ToString() + ", Num: " + IOSignal.LogicalNum.ToString());
            }
            else
            {
                //Array of logical numbers
                intCount = IOSignal.Length;
                for (intIndex = 0; intIndex <= intCount; intIndex++)
                {
                    FRRobotDemo.LogEvent(this, "Simulate Event on Signals: " + "Type: " + enuTypeCode.ToString() + "Num: " + IOSignal[intIndex].ToString());
                }
            }
        }

        private void mobjIOSignals_Unsimulate(dynamic IOSignal)
        {
            int intCount;
            int intIndex;
            FREIOTypeConstants enuTypeCode;

            enuTypeCode = (FREIOTypeConstants)mobjIOSignals.Parent.Type;

            if (IOSignal is Object)
            {
                //Single I/O signal event
                FRRobotDemo.LogEvent(this, "Unsimulate Event on Signals: " + "Type: " + enuTypeCode.ToString() + ", Num: " + IOSignal.LogicalNum.ToString());
            }
            else
            {
                //Array of logical numbers
                intCount = IOSignal.Length;
                for (intIndex = 0; intIndex <= intCount; intIndex++)
                {
                    FRRobotDemo.LogEvent(this, "Unsimulate Event on Signals: " + "Type: " + enuTypeCode.ToString() + ", Num: " + IOSignal.LogicalNum.ToString());
                }
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdAddNewConfig_Click
        //
        // Add a new config
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdAddNewConfig_Click(object sender, EventArgs e)
        {
            int intNextLogicalNumForAdd = 0;
            int intNextPhysicalNumForAdd = 0;
            TreeNode objConfigsNode;
            TreeNode objSignalsNode;
            TreeNode objNode;
            string strIOConfig = string.Empty;

            try
            {
                dynamic IOType = mobjIOType;
                // Loop thru all the configs in the collection
                // to discover the next available logical and physical number 
                foreach (FRCIOConfig objIOConfig in mobjIOConfigs)
                {
                    if (IOType.IsBoolean)
                    {
                        if ((intNextLogicalNumForAdd < objIOConfig.FirstLogicalNum + objIOConfig.NumSignals))
                        {
                            intNextLogicalNumForAdd = objIOConfig.FirstLogicalNum + objIOConfig.NumSignals;
                        }
                        if ((intNextPhysicalNumForAdd < objIOConfig.FirstPhysicalNum + objIOConfig.NumSignals))
                        {
                            intNextPhysicalNumForAdd = objIOConfig.FirstPhysicalNum + objIOConfig.NumSignals;
                        }
                    }
                    else
                    {
                        if (intNextLogicalNumForAdd <= objIOConfig.FirstLogicalNum)
                        {
                            intNextLogicalNumForAdd = objIOConfig.FirstLogicalNum + 1;
                        }

                        switch (mobjIOType.Type)
                        {
                            case (short)FREIOTypeConstants.frAInType:
                            case (short)FREIOTypeConstants.frAOutType:
                                if ((intNextPhysicalNumForAdd <= objIOConfig.FirstPhysicalNum))
                                {
                                    intNextPhysicalNumForAdd = objIOConfig.FirstPhysicalNum + 1;
                                }
                                break;
                            default:
                                if ((intNextPhysicalNumForAdd < objIOConfig.FirstPhysicalNum + objIOConfig.NumSignals))
                                {
                                    intNextPhysicalNumForAdd = objIOConfig.FirstPhysicalNum + objIOConfig.NumSignals;
                                }
                                break;
                        }
                    }

                    // Ask the user for the info
                    if (frmIOConfigAdd == null || frmIOConfigAdd.IsDisposed)
                        frmIOConfigAdd = new frmIOConfigAdd();
                    frmIOConfigAdd.FirstLogicalNum = intNextLogicalNumForAdd;
                    frmIOConfigAdd.FirstPhysicalNum = intNextPhysicalNumForAdd;
                    if (mobjIOType.Type == (short)FREIOTypeConstants.frAInType || 
                        mobjIOType.Type == (short)FREIOTypeConstants.frAOutType)
                        frmIOConfigAdd.NumSignals = 1;
                    frmIOConfigAdd.ShowDialog();

                    dynamic IOConfig = objIOConfig;

                    if (frmIOConfigAdd.ReturnStatus == DialogResult.OK)
                    {
                        try
                        {
                            IOConfig = IOType.Configs.Add(frmIOConfigAdd.FirstLogicalNum);
                            IOConfig.NumSignals = frmIOConfigAdd.NumSignals;
                            IOConfig.Rack = frmIOConfigAdd.Rack;
                            IOConfig.Slot = frmIOConfigAdd.Slot;
                            IOConfig.FirstPhysicalNum = frmIOConfigAdd.FirstPhysicalNum;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_FRCIOCONFIGS_ADD_ERROR + "\r\n" + ex.Message, "Adding new Config1");
                            treIO.Focus();
                            return;
                        }

                        // So far so good. 
                        // Clear a collapse the Configs and Signals nodes so they 
                        // get regenerated with the new configuration
                        objSignalsNode = mobjTopNode.Nodes[R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_SIGNALS];
                        objSignalsNode.Nodes.Clear();
                        objSignalsNode.Nodes.Add("ExpandMe");
                        objSignalsNode.Collapse();

                        // Rebuild the Configs list in the tree
                        // It is the currently selected node because that is the only time
                        // the AddNewConfig button is shown.
                        objConfigsNode = treIO.SelectedNode;

                        objConfigsNode.Nodes.Clear();

                        foreach (FRCIOConfig objIOConfig1 in IOConfig.Configs)
                        {
                            // Add to the list
                            strIOConfig = "[" + objIOConfig.FirstLogicalNum.ToString() + "- " + (objIOConfig.FirstLogicalNum + objIOConfig.NumSignals - 1).ToString() + "] ";
                            objNode = objConfigsNode.Nodes.Add(strIOConfig);
                            if (objIOConfig.FirstLogicalNum == frmIOConfigAdd.FirstLogicalNum)
                            {
                                // Make the new config the selected item
                                treIO.SelectedNode = objNode;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cmdAddNewConfig_Click");
            }
            finally
            {
                UpdateDetail(treIO.SelectedNode);
                treIO.Focus();
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdRemoveConfig_Click
        //
        // Removes the current configuration from the collection and controller
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdRemoveConfig_Click(object sender, EventArgs e)
        {
            TreeNode objConfigsNode;
            TreeNode objSignalsNode;

            try
            {
                mobjIOConfigs.Remove(Index: treIO.SelectedNode.Index);

                // Clear a collapse the Configs and Signals nodes so they 
                // get regenerated with the new configuration
                objConfigsNode = mobjTopNode.Nodes[R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_CONFIG];
                objConfigsNode.Nodes.Clear();
                objConfigsNode.Nodes.Add("ExpandMe");
                objConfigsNode.Collapse();

                objSignalsNode = mobjTopNode.Nodes[R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_SIGNALS];
                objSignalsNode.Nodes.Clear();
                objSignalsNode.Nodes.Add("ExpandMe");
                objSignalsNode.Collapse();

                // Select the Configs node
                treIO.SelectedNode = objConfigsNode;
                UpdateDetail(objConfigsNode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cmdRemoveConfig_Click");
            }
            finally
            {
                treIO.Focus();
            }
        }

        #endregion

        #region "Utility Routines"

        //*************************************************************************
        //                        Utility Routines
        //*************************************************************************

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: InitializeIOTree
        //
        // Builds the tree of the available IO types on the controller
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        public void InitializeIOTree()
        {
            TreeNode objNode;
            TreeNode objSubNode;

            try
            {
                // This can take some time
                Cursor.Current = Cursors.WaitCursor;

                // clear the Tree
                treIO.Nodes.Clear();

                // Fill the list box with all the I/O type names
                foreach (FRCIOType objIOType in mobjIOTypes)
                {
                    try
                    {
                        dynamic IOType = objIOType;
                        objNode = treIO.Nodes.Add(IOType.Name);
                        // Add a Signals branch
                        objSubNode = objNode.Nodes.Add(R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_SIGNALS, R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_SIGNALS);
                        objSubNode.Nodes.Add("ExpandMe");

                        if (IOType.CanConfigure)
                        {
                            // Add a Config branch
                            objSubNode = objNode.Nodes.Add(R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_CONFIG, R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_CONFIG);
                            objSubNode.Nodes.Add("ExpandMe");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "problem in InitializeIOTree");
                    }
                }

                // Select first in list
                mobjTopNode = null;
                treIO.SelectedNode = treIO.Nodes[0];
                treIO.Focus();

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "InitializeIOTree");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: UpdateDetail
        //
        // Update the display of detail for the selected node.
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void UpdateDetail(TreeNode objSelectedNode)
        {
            grpSignal.Visible = false;
            grpSignals.Visible = false;
            grpConfig.Visible = false;
            grpConfigs.Visible = false;
            mblnUpdateDetail = false;

            if (object.ReferenceEquals(mobjTopNode, objSelectedNode))
            {
                // This is an IOTypes node.
                // Nothing else to do.
            }
            else if (objSelectedNode.Text.Equals(R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_SIGNALS))
            {
                // This is the Signals node
                UpDateSignalsDetail();
            }
            else if (objSelectedNode.Parent.Text.Equals(R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_SIGNALS))
            {
                // This is a signal node
                UpDateSignalDetail();
            }
            else if (objSelectedNode.Text.Equals(R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_CONFIG))
            {
                // This is a Configs node
                grpConfigs.Visible = true;
            }
            else if (objSelectedNode.Parent.Text.Equals(R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_CONFIG))
            {
                // This is a signal node
                UpDateConfigDetail();
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: UpdateIOTypeDetail
        //
        // Updates the first tab on the form with information from the controller
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void UpdateIOTypeDetail()
        {
            FREIOTypeConstants enuIOTypeCode;

            try
            {
                dynamic IOType = mobjIOType;
                enuIOTypeCode = (FREIOTypeConstants)IOType.Type;
                lblTypeCode.Text = enuIOTypeCode.ToString();

                if (IOType.IsInput)
                {
                    lblIsInput.Text = R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_TRUE;
                }
                else
                {
                    lblIsInput.Text = R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_FALSE;
                }
                if (IOType.IsBoolean)
                {
                    lblIsBoolean.Text = R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_TRUE;
                }
                else
                {
                    lblIsBoolean.Text = R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_FALSE;
                }
                if (IOType.CanConfigure)
                {
                    lblCanConfigure.Text = R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_TRUE;
                }
                else
                {
                    lblCanConfigure.Text = R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_FALSE;
                }
                if (IOType.CanSimulate)
                {
                    lblCanSimulate.Text = R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_TRUE;
                }
                else
                {
                    lblCanSimulate.Text = R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_FALSE;
                }
                if (IOType.CanInvert)
                {
                    lblCanInvert.Text = R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_TRUE;
                }
                else
                {
                    lblCanInvert.Text = R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_FALSE;
                }
                if (IOType.CanComplement)
                {
                    lblCanComplement.Text = R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_TRUE;
                }
                else
                {
                    lblCanComplement.Text = R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_FALSE;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "UpdateIOTypeDetail");
            }
            finally
            {
                treIO.Focus();
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // Function: UpDateSignalsDetail
        //
        // Updates the third tab with IO signal information from the controller
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void UpDateSignalsDetail()
        {
            grpSignals.Visible = true;
            grpSignals.Top = grpIOType.Top + grpIOType.Height + 5;

            // Display the state of monitoring
            if (mobjIOSignals.IsMonitoring)
            {
                PicMonitorSigs.BackColor = Color.FromArgb(255, 0, 0);
            }
            else
            {
                PicMonitorSigs.BackColor = Color.FromArgb(128, 0, 0);
            }

            // Tell the checkbox event handlers to ignore any changes
            // while we are updating the signal tab
            mblnLocalInit = true;
            chkNoRefreshSigs.Checked = mobjIOSignals.NoRefresh;
            mblnLocalInit = false;

            treIO.Focus();
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // Function: UpDateSignalDetail
        //
        // Updates the third tab with IO signal information from the controller
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        public void UpDateSignalDetail()
        {
            // Tell the checkbox event handlers to ignore any changes
            // while we are updating the signal tab
            mblnLocalInit = true;

            try
            {
                dynamic IOSignal;
                dynamic IOType;

                // Get the signal object
                IOType = mobjIOType;
                mobjIOSignal = IOType.Signals[treIO.SelectedNode.Text, Type.Missing];
                IOSignal = mobjIOSignal;
                //unsubscribe event if already subscribed
                mobjIOSignal.Change -= mobjIOSignal_Change;
                mobjIOSignal.Simulate -= mobjIOSignal_Simulate;
                mobjIOSignal.Unsimulate -= mobjIOSignal_Unsimulate;
                //subscribe event handlers
                mobjIOSignal.Change += mobjIOSignal_Change;
                mobjIOSignal.Simulate += mobjIOSignal_Simulate;
                mobjIOSignal.Unsimulate += mobjIOSignal_Unsimulate;

                grpSignal.Visible = true;
                grpSignal.Top = grpIOType.Top + grpIOType.Height + 5;

                txtIOComment.Text = mobjIOSignal.Comment;

                try
                {
                    txtIOValue.Text = IOSignal.Value.ToString();
                }
                catch (Exception ex)
                {
                    txtIOValue.Text = "???";
                    MessageBox.Show(ex.Message, "UpDateSignalDetail");
                }

                //Display NoRefresh/Refresh/NoUpdate/Update controls
                chkNoRefreshSig.Checked = mobjIOSignal.NoRefresh;
                chkNoUpdateSig.Checked = mobjIOSignal.NoUpdate;

                // Display the state of monitoring
                if (IOSignal.IsMonitoring)
                {
                    picMonitor.BackColor = Color.FromArgb(255, 0, 0);
                }
                else
                {
                    picMonitor.BackColor = Color.FromArgb(128, 0, 0);
                }
                IOType = mobjIOType;
                // Display Simulation status if it applies
                if (IOType.CanSimulate)
                {
                    chkSignalSimulate.Visible = true;
                    chkSignalSimulate.Checked = IOSignal.Simulate;
                }
                else
                {
                    chkSignalSimulate.Visible = false;
                }
                // Display Simulation status if it applies
                if (IOType.CanInvert)
                {
                    chkSignalPolarity.Visible = true;
                    chkSignalPolarity.Checked = IOSignal.Polarity;
                }
                else
                {
                    chkSignalPolarity.Visible = false;
                }
                // Display Simulation status if it applies
                if (IOType.CanComplement)
                {
                    chkSignalComplementary.Visible = true;
                    chkSignalComplementary.Checked = IOSignal.Complementary;
                }
                else
                {
                    chkSignalComplementary.Visible = false;
                }
                // Display ON Off buttons if this is a binary signal
                if (IOType.IsBoolean & (!IOType.IsInput | IOType.IsInput & IOType.CanSimulate))
                {
                    cmdOn.Visible = true;
                    cmdOff.Visible = true;
                }
                else
                {
                    cmdOn.Visible = false;
                    cmdOff.Visible = false;
                }
                // Display if this assignment is active
                if (mobjIOSignal.IsAssigned)
                {
                    lblIsAssigned.Text = R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_TRUE;
                }
                else
                {
                    lblIsAssigned.Text = R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_FALSE;
                }
                // Display if this signal is online
                if (mobjIOSignal.IsOffline)
                {
                    lblIsOffline.Text = R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_TRUE;
                }
                else
                {
                    lblIsOffline.Text = R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_FALSE;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Updating I/O Signal Tab @ UpDateSignalDetail");
            }
            finally
            {
                // Done updating the information displays
                // reset for next time
                mblnLocalInit = false;
                treIO.Focus();
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // Function: UpDateConfigDetail
        //
        // Updates the details group box that displays the  
        // details for the selected config item
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        public void UpDateConfigDetail()
        {
            // Tell the checkbox event handlers to ignore any changes
            // while we are updating the signal tab
            mblnLocalInit = true;

            try
            {
                // Get the signal object
                mobjIOConfig = mobjIOConfigs[Type.Missing, treIO.SelectedNode.Index];

                grpConfig.Visible = true;
                grpConfig.Top = grpIOType.Top + grpIOType.Height + 5;

                txtFirstLogicalNum.Text = mobjIOConfig.FirstLogicalNum.ToString();
                txtNumSignals.Text = mobjIOConfig.NumSignals.ToString();
                txtRack.Text = mobjIOConfig.Rack.ToString();
                txtSlot.Text = mobjIOConfig.Slot.ToString();
                txtPhysicalType.Text = mobjIOConfig.PhysicalType.ToString();
                txtFirstPhysicalNum.Text = mobjIOConfig.FirstPhysicalNum.ToString();
                lblConfigIsValid.Text = mobjIOConfig.IsValid.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Updating I/O Signal Tab @ UpDateConfigDetail");
            }
            finally
            {
                mblnLocalInit = false;
                treIO.Focus();
            }
        }

        #endregion

    }
}