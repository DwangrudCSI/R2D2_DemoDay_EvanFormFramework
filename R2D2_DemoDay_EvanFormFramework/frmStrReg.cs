// Module: frmStrReg
//
// Description:
//   
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
    public partial class frmStrReg : Form
    {

        #region "Declarations"

        //*************************************************************************
        //                           Declarations
        //*************************************************************************
        private FRCVRProgram mobjStrRegPgm;
        private FRCVars mobjVars;
        private FRCVar mobjVar;

        private bool mblnIgnoreNoRefreshClick;

        FRRobotDemo FRRobotDemo;
        frmEditStrReg frmEditStrReg;
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
        public frmStrReg()
        {
            InitializeComponent();
            //set min/max size
            this.MinimumSize = this.Size;
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: Form_Load
        //
        // Initialize the form
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void frmStrReg_Load(object sender, EventArgs e)
        {
            // Get a reference to the *STRREG* so we can detect if vars get
            // reloaded
            mobjStrRegPgm = (FRCVRProgram)FRRobotDemo.gobjRobot.Programs["*STRREG*", Type.Missing, Type.Missing, Type.Missing];
            //unsubscribe event if already subscribed
            mobjStrRegPgm.RefreshVars -= mobjStrRegPgm_RefreshVars;
            //subscribe event handlers
            mobjStrRegPgm.RefreshVars += mobjStrRegPgm_RefreshVars;

            // let this do the dirty work
            UpdateStrRegList(0);
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: Form_Unload
        //
        // The robot is probably disconnected - so free up any references.
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void frmStrReg_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (mobjStrRegPgm != null)
                mobjStrRegPgm.RefreshVars -= mobjStrRegPgm_RefreshVars;

            if (mobjVars != null)
            {
                mobjVars.Change -= mobjVars_Change;
                mobjVars.CommentChange -= mobjVars_CommentChange;
            }

            if (mobjVar != null)
            {
                mobjVar.Change -= mobjVar_Change;
                mobjVar.CommentChange -= mobjVar_CommentChange;
            }

            mobjStrRegPgm = null;
            mobjVar = null;
            mobjVars = null;
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: tmrUpdate_Timer
        //
        // Turn light off after a while
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            tmrUpdate.Enabled = false;
            picEvent.BackColor = Color.FromArgb(128, 128, 0);
        }

        #endregion

        #region "User Input Events"

        //*************************************************************************
        //                        User Input Events
        //*************************************************************************

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: lstStrRegs_SelectedIndexChanged
        //
        // Select the new String register
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void lstStrRegs_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get the String register object
            if (lstStrRegs.SelectedIndex >= 0)
            {
                mobjVar = mobjVars[Type.Missing, lstStrRegs.SelectedIndex];
                //unsubscribe event if already subscribed
                mobjVar.Change -= mobjVar_Change;
                mobjVar.CommentChange -= mobjVar_CommentChange;
                //subscribe event handlers
                mobjVar.Change += mobjVar_Change;
                mobjVar.CommentChange += mobjVar_CommentChange;

                UpdateDetails();
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: lstStrRegs_DblClick
        //
        // Select the new String register and allow editing
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void lstStrRegs_DoubleClick(object sender, EventArgs e)
        {
            // get the String register object
            try
            {
                mobjVar = mobjVars[Type.Missing, lstStrRegs.SelectedIndex];
                //unsubscribe event if already subscribed
                mobjVar.Change -= mobjVar_Change;
                mobjVar.CommentChange -= mobjVar_CommentChange;
                //subscribe event handlers
                mobjVar.Change += mobjVar_Change;
                mobjVar.CommentChange += mobjVar_CommentChange;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "lstStrRegs_DoubleClick");
            }
            // Now edit the register
            if (frmEditStrReg == null || frmEditStrReg.IsDisposed)
                frmEditStrReg = new frmEditStrReg();
            frmEditStrReg.Edit(mobjVar);
            UpdateDetails();
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
        //    if (mobjVar != null)
        //    {
        //        //  frmScattAccess.Add_Renamed((mobjVar.Value))
        //        if (frmScattAccess == null || frmScattAccess.IsDisposed)
        //            frmScattAccess = new frmScattAccess();
        //        frmScattAccess.AddItem(mobjVar);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Nothing selected");
        //    }
        //}

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdMonitor_Click
        //
        // Start monitoring the current String register
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdMonitor_Click(object sender, EventArgs e)
        {
            try
            {
                mobjVar.StartMonitor(int.Parse(txtLatency.Text));
                UpdateDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cmdMonitor_Click");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdRefresh_Click
        //
        // Refreshes the data for the selected Register
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                if (mobjVar != null)
                {
                    mobjVar.Refresh();
                    // Redisplay the variable data
                    UpdatelistLine(int.Parse(mobjVar.FieldName) - 1);
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
        // Updates the data for the selected register
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (mobjVar != null)
                {
                    mobjVar.Update();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cmdUpdate_Click");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: chkNoRefresh_Click
        //
        // Set the value of the NoRefresh Property for a Register
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void chkNoRefresh_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (!mblnIgnoreNoRefreshClick)
                {
                    if (mobjVar != null)
                    {
                        // Set the value of its no-refresh state
                        mobjVar.NoRefresh = chkNoRefresh.Checked;
                        UpdatelistLine(int.Parse(mobjVar.FieldName) - 1);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "chkNoRefresh_CheckStateChanged");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: chkNoUpdate_Click
        //
        // Set the value of the NoUpdate Property for a Register
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void chkNoUpdate_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (!mblnIgnoreNoRefreshClick)
                {
                    if (mobjVar != null)
                    {
                        // Set the value of its no-Update state
                        mobjVar.NoUpdate = chkNoUpdate.Checked;
                        UpdatelistLine(int.Parse(mobjVar.FieldName) - 1);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "chkNoUpdate_CheckStateChanged");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdSaveStrReg_Click
        //
        // Save the String registers to the default directory
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdSaveStrReg_Click(object sender, EventArgs e)
        {
            try
            {
                // Save variables associated with program
                FRRobotDemo.gobjRobot.Programs["*STRREG*", Type.Missing, Type.Missing, Type.Missing].Save(("STRREG.VR"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cmdSaveStrReg_Click");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdStopMon_Click
        //
        // Stop monitoring the current String register
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdStopMon_Click(object sender, EventArgs e)
        {
            try
            {
                mobjVar.StopMonitor();
                UpdateDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cmdStopMon_Click");
            }
        }

        #endregion

        #region "Robot Server Events"

        //*************************************************************************
        //                        Robot Server Events
        //*************************************************************************

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: mobjStrRegPgm_RefreshVars
        //
        // When String registers are reloaded, this event will fire.
        // Re-establish good references to Robot.RegStrings and the
        // currently selected String register.
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private delegate void RefreshVarsDelegate();
        private void mobjStrRegPgm_RefreshVars()
        {
            if (this.InvokeRequired)
            {
                // Called from the Robot Server thread
                RefreshVarsDelegate HandleRefreshVars = new RefreshVarsDelegate(mobjStrRegPgm_RefreshVars);
                this.BeginInvoke(HandleRefreshVars);
            }
            else
            {
                // On the Form's thread now
                // Release the old references to the Strreg objects
                mobjVars = null;
                mobjVar = null;

                // let this do the dirty work
                UpdateStrRegList(lstStrRegs.SelectedIndex);
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: mobjVars_Change
        //
        // Post an event to the event log and update the list
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private delegate void VarChangDelegate(ref dynamic Var);
        private void mobjVars_Change(ref dynamic Var)
        {
            if (this.InvokeRequired)
            {
                // Called from the Robot Server thread
                VarChangDelegate HandleVarChange = new VarChangDelegate(mobjVars_Change);
                this.BeginInvoke(HandleVarChange, new object[] { Var });
            }
            else
            {
                try
                {
                    if (FRRobotDemo == null)
                        FRRobotDemo = new FRRobotDemo();
                    FRRobotDemo.LogEvent(this, "Change Event on StrRegs: " + Var.FieldName);
                    picEvent.BackColor = Color.FromArgb(255, 255, 0);
                    tmrUpdate.Enabled = true;
                    UpdatelistLine(int.Parse(Var.FieldName) - 1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "mobjVars_Change");
                }
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: mobjVars_CommentChange
        //
        // Post an event to the event log and update the list
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private delegate void CommentChangDelegate(ref dynamic Var);
        private void mobjVars_CommentChange(ref dynamic Var)
        {
            if (this.InvokeRequired)
            {
                // Called from the Robot Server thread
                CommentChangDelegate HandleCommentChange = new CommentChangDelegate(mobjVars_CommentChange);
                this.BeginInvoke(HandleCommentChange, new object[] { Var });
            }
            else
            {
                try
                {
                    if (FRRobotDemo == null)
                        FRRobotDemo = new FRRobotDemo();
                    FRRobotDemo.LogEvent(this, "CommentChange Event on StrRegs: " + Var.FieldName);
                    picEvent.BackColor = Color.FromArgb(255, 255, 0);
                    tmrUpdate.Enabled = true;
                    UpdatelistLine(int.Parse(Var.FieldName) - 1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "mobjVars_CommentChange");
                }
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: mobjVar_Change
        //
        // Post an event to the event log
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void mobjVar_Change()
        {
            if (FRRobotDemo == null)
                FRRobotDemo = new FRRobotDemo();
            FRRobotDemo.LogEvent(this, "Change Event on StrReg: " + mobjVar.FieldName);
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: mobjVar_CommentChange
        //
        // Post an event to the event log
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void mobjVar_CommentChange()
        {
            if (FRRobotDemo == null)
                FRRobotDemo = new FRRobotDemo();
            FRRobotDemo.LogEvent(this, "CommentChange Event on StrReg: " + mobjVar.FieldName);
        }

        #endregion

        #region "Utility Routines"

        //*************************************************************************
        //                        Utility Routines
        //*************************************************************************

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: UpdateStrRegList
        //
        // Clear and refill the list of available String registers
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        public void UpdateStrRegList(int vintSelected)
        {
            int intIndex;

            try
            {
                // This may take a while
                Cursor.Current = Cursors.WaitCursor;

                mobjVar = null;
                mobjVars = FRRobotDemo.gobjRobot.RegStrings;
                //unsubscribe event if already subscribed
                mobjVars.Change -= mobjVars_Change;
                mobjVars.CommentChange -= mobjVars_CommentChange;
                //subscribe event handlers
                mobjVars.Change += mobjVars_Change;
                mobjVars.CommentChange += mobjVars_CommentChange;

                lstStrRegs.Items.Clear();
                lstStrRegs.SelectedIndex = -1;

                // Build the list box

                for (intIndex = 0; intIndex <= mobjVars.Count - 1; intIndex++)
                {
                    // Create the list lineentry
                    lstStrRegs.Items.Add(" ");

                    // Fill in the data
                    UpdatelistLine(intIndex);
                }

                // This will cause the SelectedIndexChanged event to fire and the details to be updated
                if ((vintSelected < 0) | (vintSelected > (mobjVars.Count - 1)))
                {
                    lstStrRegs.SelectedIndex = 0;
                }
                else
                {
                    lstStrRegs.SelectedIndex = vintSelected;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error - " + ex.Message, "frmStrReg", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: UpdatelistLine
        //
        // Add a String register to the listbox
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        public void UpdatelistLine(int intIndex)
        {
            FRCVar objVar;
            FRCRegString objStrReg;
            string strListLine;

            objVar = mobjVars[Type.Missing, intIndex];
            objStrReg = objVar.Value;

            // Set the index column
            strListLine = objVar.FieldName + new string(' ', 4 - objVar.FieldName.Length);
            // Set the comment column
            strListLine = strListLine + objStrReg.Comment + new string(' ', 20 - objStrReg.Comment.Length);
            // Set the value column
            strListLine = strListLine + objStrReg.Value.ToString();

            lstStrRegs.Items[intIndex] = strListLine;

            if (object.ReferenceEquals(objVar, mobjVar))
            {
                // This is the selected item
                UpdateDetails();
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: UpdateDetails
        //
        // Add a String register to the listbox
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        public void UpdateDetails()
        {
            FRCRegString objStrReg;

            try
            {
                if (mobjVar == null)
                {
                    MessageBox.Show("mobjVar is nothing - Find out why");
                    return;
                }

                // Get a reference to the String register object
                objStrReg = mobjVar.Value;

                if (mobjVar.IsMonitoring)
                {
                    picMonitor.BackColor = Color.FromArgb(255, 0, 0);
                }
                else
                {
                    picMonitor.BackColor = Color.FromArgb(128, 0, 0);
                }

                mblnIgnoreNoRefreshClick = true;
                chkNoRefresh.Checked = mobjVar.NoRefresh;
                chkNoUpdate.Checked = mobjVar.NoUpdate;
                mblnIgnoreNoRefreshClick = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "UpdateDetails");
            }
        }

        #endregion

    }
}