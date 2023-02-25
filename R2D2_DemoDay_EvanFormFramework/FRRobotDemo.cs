// Module: FRRobotDemo
//
// Description:
//   Data and routines available to all forms in this project
//
// Author: Tri Quach
//         FANUC America Corporation 
//         29700 Kohoutek Way
//         Union City, CA 94587
//
// Modification history:
// 05-Oct-2015 Quach    Adapted from the VB.Net version

using FRRobot;
using FRRobotNeighborhood;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Forms;

namespace FRRobotDemoCSharp
{
    public class FRRobotDemo
    {

        #region "Declarations"

        //*************************************************************************
        //                           Declarations
        //*************************************************************************
        public FRCRobotNeighborhood gobjRobotNeighborhood;
        public static FRCRobot gobjRobot;
        public static frmFRRobotDemo gobjMDIParent;
        public object gobjPositionCopySource;
        public static OrderedDictionary gobjIndPositions;

        //frmEvents frmEvents;

        #endregion

        #region "Class Maintenance"

        //*************************************************************************
        //                         Class Maintenance
        //*************************************************************************
        public FRRobotDemo()
        {

        }

        #endregion

        #region "Utility Routines"

        //*************************************************************************
        //                        Utility Routines
        //*************************************************************************

        //===============================================================
        //
        // Common Delegate routines to handle Form work that needs to 
        // be done on the main thread when a Robot Server event is handled.
        //
        //===============================================================
        private delegate void SetTextDelegate(Form theForm, Control theFormElement, string newText);
        public void SetText(Form theForm, Control theFormElement, string newText)
        {
            if (theForm.InvokeRequired)
            {
                // Called from the Robot Server thread
                SetTextDelegate HandleSetText = new SetTextDelegate(SetText);
                theForm.BeginInvoke(HandleSetText, theForm, theFormElement, newText);
            }
            else
            {
                // Now we are on the Form’s thread
                theFormElement.Text = newText;
            }
        }

        private delegate void LogEventDelegate(Form theForm, string EventText);
        public void LogEvent(Form theForm, string EventText)
        {
            if (theForm.InvokeRequired)
            {
                // Called from the Robot Server thread
                LogEventDelegate HandleLogEvent = new LogEventDelegate(LogEvent);
                theForm.BeginInvoke(HandleLogEvent, theForm, EventText);
            }
            else
            {
                // Now we are on the Form’s thread
                //if (frmEvents == null || frmEvents.IsDisposed)
                //    frmEvents = new frmEvents();
                //frmEvents.AddEvent(EventText);
            }
        }

        private delegate void SetCheckedDelegate(Form theForm, CheckBox theCheckBox);
        public void SetChecked(Form theForm, CheckBox theCheckBox)
        {
            if (theForm.InvokeRequired)
            {
                // Called from the Robot Server thread
                SetCheckedDelegate HandleSetChecked = new SetCheckedDelegate(SetChecked);
                theForm.BeginInvoke(HandleSetChecked, theForm, theCheckBox);
            }
            else
            {
                // Now we are on the Form’s thread
                theCheckBox.Checked = true;
            }
        }

        private delegate void SetUncheckedDelegate(Form theForm, CheckBox theCheckBox);
        public void SetUnchecked(Form theForm, CheckBox theCheckBox)
        {
            if (theForm.InvokeRequired)
            {
                // Called from the Robot Server thread
                SetUncheckedDelegate HandleSetUnchecked = new SetUncheckedDelegate(SetUnchecked);
                theForm.BeginInvoke(HandleSetUnchecked, theForm, theCheckBox);
            }
            else
            {
                // Now we are on the Form’s thread
                theCheckBox.Checked = false;
            }
        }

        #endregion

    }
}