// Module: frmNumReg
//
// Description:
//   Display and manipulate Numeric Registers
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
    public partial class frmNumReg : Form
    {

        #region "Declarations"

        //*************************************************************************
        //                           Declarations
        //*************************************************************************
        private FRCVRProgram mobjNumRegPgm;
        private FRCVars mobjVars;
        private FRCVar mobjVar;

        private bool mblnIgnoreNoRefreshClick;

        FRRobotDemo FRRobotDemo;
        frmEditNumReg frmEditNumReg;
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
        public frmNumReg()
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
        // Initialize the form
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void frmNumReg_Load(object sender, EventArgs e)
        {
            // Get a reference to the *NUMREG* so we can detect if vars get
            // reloaded
            try
            {
                mobjNumRegPgm = (FRCVRProgram)FRRobotDemo.gobjRobot.Programs["*NUMREG*", Type.Missing, Type.Missing, Type.Missing];
                //unsubscribe event if already subscribed
                mobjNumRegPgm.RefreshVars -= mobjNumRegPgm_RefreshVars;
                //subscribe event handlers
                mobjNumRegPgm.RefreshVars += mobjNumRegPgm_RefreshVars;

                // let this do the dirty work
                UpdateNumReglist(0);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "frmNumReg_Load");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: Form_Unload
        //
        // The robot is probably disconnected - so free up any references.
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void frmNumReg_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (mobjNumRegPgm != null)
                mobjNumRegPgm.RefreshVars -= mobjNumRegPgm_RefreshVars;

            if (mobjVars != null)
            {
                mobjVars.Change -= mobjVars_Change;
                mobjVars.CommentChange -= mobjVars_CommentChange;
                mobjVar.Change -= mobjVar_Change;
                mobjVar.CommentChange -= mobjVar_CommentChange;
            }

            mobjNumRegPgm = null;
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
        private void tmrUpdateLED_Tick(object sender, EventArgs e)
        {
            tmrUpdateLED.Enabled = false;
            picEvent.BackColor = Color.FromArgb(128, 128, 0);
        }

        #endregion

        #region "User Input Events"

        //*************************************************************************
        //                        User Input Events
        //*************************************************************************

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: lstNumRegs_Click
        //
        // Select the new numeric register
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void lstNumRegs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstNumRegs.SelectedIndex >= 0)
            {
                // Get the numeric register object
                mobjVar = mobjVars[Type.Missing, lstNumRegs.SelectedIndex];
                UpdateDetails();
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: lstNumRegs_DblClick
        //
        // Select the new numeric register and allow editing
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void lstNumRegs_DoubleClick(object sender, EventArgs e)
        {

            // get the numeric register object
            mobjVar = mobjVars[Type.Missing, lstNumRegs.SelectedIndex];

            if (frmEditNumReg == null || frmEditNumReg.IsDisposed)
                frmEditNumReg = new frmEditNumReg();
            // Now edit the register
            frmEditNumReg.Edit(mobjVar);
            UpdatelistLine(int.Parse(mobjVar.FieldName) - 1);
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
        // EVENT: cmdAddToScattAccess_Click
        //
        // Add this item to the ScatteredAccess collection
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //private void cmdAddToScattAccess_Click(object sender, EventArgs e)
        //{
        //    if (mobjVar != null)
        //    {
        //        if (frmScattAccess == null || frmScattAccess.IsDisposed)
        //            frmScattAccess = new frmScattAccess();

        //        frmScattAccess.AddItem(mobjVar.Value);
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
        // Start monitoring the current numeric register
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
        // EVENT: cmdStopMon_Click
        //
        // Stop monitoring the current numeric register
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

        #endregion

        #region "Robot Server Events"

        //*************************************************************************
        //                        Robot Server Events
        //*************************************************************************

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: mobjNumRegPgm_RefreshVars
        //
        // When Numeric registers are reloaded, this event will fire.
        // Re-establish good references to Robot.RegNumerics and the
        // currently selected numeric register.
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private delegate void RefreshVarsDelegate();
        private void mobjNumRegPgm_RefreshVars()
        {
            if (this.InvokeRequired)
            {
                // Called from the Robot Server thread
                RefreshVarsDelegate HandleRefreshVars = new RefreshVarsDelegate(mobjNumRegPgm_RefreshVars);
                this.BeginInvoke(HandleRefreshVars);
            }
            else
            {
                // On the Form's thread now
                // Release the old references to the Strreg objects
                mobjVars = null;
                mobjVar = null;

                // let this do the dirty work
                UpdateNumReglist((short)lstNumRegs.SelectedIndex);
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
                FRRobotDemo.LogEvent(this, "Change Event on NumRegs: " + Var.FieldName);
                picEvent.BackColor = Color.FromArgb(255, 255, 0);
                tmrUpdateLED.Enabled = true;
                UpdatelistLine(int.Parse(Var.FieldName) - 1);
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
                FRRobotDemo.LogEvent(this, "CommentChange Event on NumRegs: " + Var.FieldName);
                picEvent.BackColor = Color.FromArgb(255, 255, 0);
                tmrUpdateLED.Enabled = true;
                UpdatelistLine(int.Parse(Var.FieldName) - 1);
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
            FRRobotDemo.LogEvent(this, "Change Event on NumReg: " + mobjVar.FieldName);
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
            FRRobotDemo.LogEvent(this, "CommentChange Event on NumReg: " + mobjVar.FieldName);
        }

        #endregion

        #region "Utility Routines"

        //*************************************************************************
        //                        Utility Routines
        //*************************************************************************

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: UpdateNumReglist
        //
        // Clear and refill the list of available numeric registers
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        public void UpdateNumReglist(short vintSelected)
        {
            int intIndex = 0;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                mobjVar = null;
                mobjVars = FRRobotDemo.gobjRobot.RegNumerics;
                mobjVars.Change += mobjVars_Change;
                mobjVars.CommentChange += mobjVars_CommentChange;

                lstNumRegs.Items.Clear();
                lstNumRegs.SelectedIndex = -1;

                // Build the list box

                for (intIndex = 0; intIndex <= mobjVars.Count - 1; intIndex++)
                {
                    // Create the list lineentry
                    lstNumRegs.Items.Add(" ");

                    // Fill in the data
                    UpdatelistLine(intIndex);
                }

                // This will cause the SelectedIndexChanged event to fire and the details to be updated
                if ((vintSelected < 0) | (vintSelected > (mobjVars.Count - 1)))
                {
                    lstNumRegs.SelectedIndex = 0;
                }
                else
                {
                    lstNumRegs.SelectedIndex = vintSelected;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error - " + ex.Message, "frmNumReg", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            FRCRegNumeric objNumReg;
            string strListLine;

            // Get a reference to the numeric register object
            objVar = mobjVars[Type.Missing, intIndex];
            objNumReg = objVar.Value;

            // Set the index column
            strListLine = objVar.FieldName + new string(' ', 4 - objVar.FieldName.Length);
            // Set the comment column
            strListLine = strListLine + objNumReg.Comment + new string(' ', 20 - objNumReg.Comment.Length);
            if (objNumReg.Type == FRETypeCodeConstants.frIntegerType)
            {
                // Set the type column
                strListLine = strListLine + "Int    ";
                // Set the value column
                strListLine = strListLine += objNumReg.RegLong.ToString();
            }
            else
            {
                // Set the type column
                strListLine = strListLine + "Real    ";
                // Set the value column
                float sngValue = objNumReg.RegFloat;
                if ((-100f < sngValue) & (100f > sngValue))
                {
                    strListLine = strListLine + string.Format("{0:N4}", sngValue);
                }
                else
                {
                    strListLine = strListLine + string.Format("{0:N1}", sngValue);
                }
            }

            lstNumRegs.Items[intIndex] = strListLine;

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
        // Update the boxes to the right of the list
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        public void UpdateDetails()
        {
            FRCRegNumeric objNumReg;

            if (mobjVar == null)
            {
                MessageBox.Show("mobjVar is nothing - Find out why");
                return;
            }

            // Get a reference to the numeric register object
            objNumReg = mobjVar.Value;

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

        #endregion

    }
}