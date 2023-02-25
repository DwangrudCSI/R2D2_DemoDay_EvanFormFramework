// Module: frmAlarms
//
// Description:
//   Show robot alarm log
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
using System.Resources;

namespace FRRobotDemoCSharp
{
    public partial class frmAlarms : Form
    {

        #region "Declarations"

        //*************************************************************************
        //                           Declarations
        //*************************************************************************
        public FRCAlarms mobjAlarms;

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
        public frmAlarms()
        {
            InitializeComponent();
            //set min/max size
            this.MinimumSize = this.Size;
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: Form_Load
        //
        // Set up the Alarm display form
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void frmAlarms_Load(object sender, EventArgs e)
        {
            try
            {
                mobjAlarms = FRRobotDemo.gobjRobot.Alarms;
                foreach (FRCAlarm objAlarm in mobjAlarms)
                {
                    msubAddAlarm(objAlarm, true);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "frmAlarms_Load");
            }
            
            // check for existing alarm and select the first one
            if (lsvAlarms.Items.Count > 0)
            {
                lsvAlarms.FocusedItem = lsvAlarms.Items[0];
                msubUpdateAlarm(mobjAlarms[0]);
            }
            //unsubscribe event if already subscribed
            mobjAlarms.AlarmNotify -= mobjAlarms_AlarmNotify;
            //subscribe event handlers
            mobjAlarms.AlarmNotify += mobjAlarms_AlarmNotify;
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: Form_Unload
        //
        // The robot is probably disconnected - so free up any references.
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void frmAlarms_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (mobjAlarms != null)
                mobjAlarms.AlarmNotify -= mobjAlarms_AlarmNotify;
            mobjAlarms = null;
        }

        #endregion

        #region "User Input Events"

        //*************************************************************************
        //                        User Input Events
        //*************************************************************************

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: lsvAlarms_SelectedIndexChanged
        //
        // Update the alarm information text when a new alarm is selected
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void lsvAlarms_SelectedIndexChanged(object sender, EventArgs e)
        {
            FRCAlarm objAlarm;
            int intIndex;

            if (lsvAlarms.SelectedIndices.Count > 0)
            {
                intIndex = lsvAlarms.SelectedIndices[0];
                objAlarm = mobjAlarms[intIndex];
                msubUpdateAlarm(objAlarm);
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdReset_Click
        //
        // Issue the Alarms.Reset
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdReset_Click(object sender, EventArgs e)
        {
            try
            {
                mobjAlarms.Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cmdReset_Click");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdClearAll_Click
        //
        // Clear All Allarms
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdClearAll_Click(object sender, EventArgs e)
        {
            try
            {
                object[] ArgumentsForError = { 2 };
                FRRobotDemo.gobjRobot.PostAlarm(FREAlarmSeverityConstants.frSevNone, 5, 0, 0, 0, ArgumentsForError);
                lsvAlarms.Items.Clear();
                lblCount.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cmdClearAll_Click");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdSetMax_Click
        //
        // Set the Maximum Number of Alarms stored and displayed
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdSetMax_Click(object sender, EventArgs e)
        {
            //Set the maximum number of alarms
            if (InputBox.UserInput(R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_SET_MAX_PROMPT, R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_SET_MAX_TITLE, mobjAlarms.Max.ToString()) == DialogResult.OK)
            {
                string strNewMax;
                strNewMax = InputBox.txtOutput;

                int output;

                if (!int.TryParse(strNewMax, out output))
                {
                    MessageBox.Show("Enter a valid number", "cmdSetMax_Click");
                    return;
                }
                mobjAlarms.Max = int.Parse(strNewMax);

                // Regenerate list
                lsvAlarms.Items.Clear();
                foreach (FRCAlarm objAlarm in mobjAlarms)
                {
                    msubAddAlarm(objAlarm, true);
                }

                // check for existing alarm and select the first one
                if (lsvAlarms.Items.Count > 0)
                {
                    lsvAlarms.FocusedItem = lsvAlarms.Items[0];
                    msubUpdateAlarm(mobjAlarms[0]);
                }
            }
        }

        #endregion

        #region "Robot Server Events"

        //*************************************************************************
        //                        Robot Server Events
        //*************************************************************************
        private delegate void AlarmNotifyDelegate(dynamic Alarm);
        private void mobjAlarms_AlarmNotify(dynamic Alarm)
        {
            if (this.InvokeRequired) 
            {
                // Called from the Robot Server thread
                AlarmNotifyDelegate HandleAlarmNotify = new AlarmNotifyDelegate(mobjAlarms_AlarmNotify);
                this.BeginInvoke(HandleAlarmNotify, new object[] { Alarm });
            } 
            else 
            {
                //Now we are on the Form’s thread
                FRCAlarm objAlarm;
                objAlarm = Alarm;
                msubAddAlarm(objAlarm, false);
                //Add new alarm at top of list
            }
        }

        #endregion

        #region "Utility Routines"

        //*************************************************************************
        //                        Utility Routines
        //*************************************************************************

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: msubAddAlarm
        //
        // Add a new alarm to list of alarm
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        public void msubAddAlarm(FRCAlarm robjAlarm, bool rblnAtEnd)
        {
            ListViewItem objListItem;

            if (robjAlarm.ErrorClass == (int)FREAlarmSeverityConstants.frErrorClear)
            {
                lsvAlarms.Items.Clear();
            }
            else if (robjAlarm.ErrorClass == (int)FREAlarmSeverityConstants.frErrorClearAll)
            {

            }

            if (rblnAtEnd)
            {
                //Add alarm to end of list
                if (robjAlarm.ErrorClass == (int)FREAlarmSeverityConstants.frErrorReset)
                    objListItem = lsvAlarms.Items.Add(R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_R_E_S_E_T);
                else
                    objListItem = lsvAlarms.Items.Add(robjAlarm.ErrorMnemonic);
            }
            else
            {
                //Add alarm at beginning of list
                if (robjAlarm.ErrorClass == (int)FREAlarmSeverityConstants.frErrorReset)
                    objListItem = lsvAlarms.Items.Insert(0, R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_R_E_S_E_T);
                else
                    objListItem = lsvAlarms.Items.Insert(0, robjAlarm.ErrorMnemonic);
            }

            //color coding
            objListItem.UseItemStyleForSubItems = false;
            switch(robjAlarm.ErrorClass)
            {
                case (int)FREAlarmSeverityConstants.frErrorReset:
                    objListItem.SubItems[0].BackColor = Color.Blue;
                    objListItem.SubItems[0].ForeColor = Color.White;
                    break;
                case (int)FREAlarmSeverityConstants.frSevStopL:
                    objListItem.SubItems[0].BackColor = Color.Red;
                    objListItem.SubItems[0].ForeColor = Color.White;
                    break;
                case (int)FREAlarmSeverityConstants.frErrorNormal:
                    int len = robjAlarm.ErrorMnemonic.Length;
                    if (robjAlarm.ErrorMnemonic.Contains("INTP"))
                    {
                        if (int.Parse(robjAlarm.ErrorMnemonic.Substring(len - 3, 3)) > 105)
                        {
                            objListItem.SubItems[0].BackColor = Color.Yellow;
                        }
                    }
                    else if (robjAlarm.ErrorMnemonic.Contains("SYS"))
                    {
                        if (int.Parse(robjAlarm.ErrorMnemonic.Substring(len - 3, 3)) < 43)
                        {
                            objListItem.SubItems[0].BackColor = Color.Red;
                            objListItem.SubItems[0].ForeColor = Color.White;
                        }
                        else if (int.Parse(robjAlarm.ErrorMnemonic.Substring(len - 3, 3)) > 177)
                        { 
                        
                        }
                        else
                            objListItem.SubItems[0].BackColor = Color.Yellow;
                    }
                    else if(robjAlarm.ErrorMnemonic.Contains("MOT"))
                    {
                        objListItem.SubItems[0].BackColor = Color.Yellow;
                    }
                    break;
            }

            switch (robjAlarm.ErrorClass)
            {
                case (int)FREAlarmSeverityConstants.frErrorNormal:
                    if (objListItem.SubItems.Count > 1)
                    {
                        objListItem.SubItems[1].Text = robjAlarm.ErrorMessage;
                    }
                    else
                    {
                        objListItem.SubItems.Insert(1, new ListViewItem.ListViewSubItem(null, robjAlarm.ErrorMessage));
                    }
                    break;
                case (int)FREAlarmSeverityConstants.frErrorClear:
                case (int)FREAlarmSeverityConstants.frErrorClearAll:
                    if (objListItem.SubItems.Count > 1)
                    {
                        objListItem.SubItems[1].Text = "Clear";
                    }
                    else
                    {
                        objListItem.SubItems.Insert(1, new ListViewItem.ListViewSubItem(null, R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_CLEAR));
                    }
                    break;
                case (int)FREAlarmSeverityConstants.frErrorReset:
                    if (objListItem.SubItems.Count > 1)
                    {
                        objListItem.SubItems[1].Text = string.Empty;
                    }
                    else
                    {
                        objListItem.SubItems.Insert(1, new ListViewItem.ListViewSubItem(null, string.Empty));
                    }
                    break;
            }

            if (objListItem.SubItems.Count > 2)
            {
                objListItem.SubItems[2].Text = robjAlarm.CauseMnemonic;
            }
            else
            {
                objListItem.SubItems.Insert(2, new ListViewItem.ListViewSubItem(null, robjAlarm.CauseMnemonic));
            }
            if (objListItem.SubItems.Count > 3)
            {
                objListItem.SubItems[3].Text = robjAlarm.CauseMessage;
            }
            else
            {
                objListItem.SubItems.Insert(3, new ListViewItem.ListViewSubItem(null, robjAlarm.CauseMessage));
            }

            while (lsvAlarms.Items.Count > mobjAlarms.Max)
            {
                //If adding item makes count > maximum, remove the bottommost alarm
                lsvAlarms.Items.RemoveAt(lsvAlarms.Items.Count-1);
            }

            if (mobjAlarms.ActiveAlarms)
            {
                lblActiveAlarms.BackColor = Color.Red;
                lblActiveAlarms.ForeColor = Color.White;
                lblActiveAlarms.Text = R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_ACTIVE_ALARMS;
            }
            else 
            {
                lblActiveAlarms.BackColor = default(Color);
                lblActiveAlarms.ForeColor = default(Color);
                lblActiveAlarms.Text = R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_NO_ACITVE_ALARMS;
            }
            lblCount.Text = mobjAlarms.Count.ToString();
            lblMax.Text = mobjAlarms.Max.ToString();
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: msubUpdateAlarm
        //
        // Update the alarm information display for the passed in alarm
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        public void msubUpdateAlarm(FRCAlarm robjAlarm)
        {
            try
            {
                txtErrMnemonic.Text = robjAlarm.ErrorMnemonic;

                switch (robjAlarm.ErrorClass)
                {
                    case (int)FREAlarmSeverityConstants.frErrorNormal:
                        txtErrText.Text = robjAlarm.ErrorMessage;
                        break;
                    case (int)FREAlarmSeverityConstants.frErrorClear:
                    case (int)FREAlarmSeverityConstants.frErrorClearAll:
                        txtErrText.Text = R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_CLEAR;
                        break;
                    case (int)FREAlarmSeverityConstants.frErrorReset:
                        txtErrText.Text = R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_R_E_S_E_T;
                        break;
                }

                txtSeverity.Text = robjAlarm.SeverityMessage;
                txtCseMnemonic.Text = robjAlarm.CauseMnemonic;
                txtCseText.Text = robjAlarm.CauseMessage;
                txtTimeStamp.Text = robjAlarm.TimeStamp.ToString();

                if (mobjAlarms.ActiveAlarms)
                {
                    lblActiveAlarms.BackColor = Color.Red;
                    lblActiveAlarms.ForeColor = Color.White;
                    lblActiveAlarms.Text = R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_ACTIVE_ALARMS;
                }
                else 
                {
                    lblActiveAlarms.BackColor = default(Color);
                    lblActiveAlarms.ForeColor = default(Color);
                    lblActiveAlarms.Text = R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_NO_ACITVE_ALARMS;
                }
                lblCount.Text = mobjAlarms.Count.ToString();
                lblMax.Text = mobjAlarms.Max.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "msubUpdateAlarm");
            }
        }

        #endregion

    }
}