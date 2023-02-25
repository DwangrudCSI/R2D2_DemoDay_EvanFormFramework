// Module: frmFindVar
//
// Description:
//    Find a variable by name or content
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
using System.Collections;
using System.Windows.Forms;

namespace FRRobotDemoCSharp
{
    public partial class frmFindVar : Form
    {

        #region "Declarations"

        //*************************************************************************
        //                           Declarations
        //*************************************************************************
        private FRCVars mobjScope;
        private ArrayList mobjFoundAlready;
        private int mintSearchIndex;
        private bool mblnSearchInProgress;
        private bool mblnCancel;

        #endregion

        #region "Public Properties and Methods"

        //*************************************************************************
        //                      Public Properties and Methods
        //*************************************************************************
        public event FoundVarEvent FoundVar;
        public delegate void FoundVarEvent(dynamic objVarFound);

        public event HiddenEvent Hidden;
        public delegate void HiddenEvent();

        ///''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        //  FindWhat - the string to be found
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        public string FindWhat
        {
            get 
            { 
                return txtFindWhat.Text; 
            }
            set
            {
                txtFindWhat.Text = value;
                mobjFoundAlready.Clear();
                mintSearchIndex = 0;
            }
        }

        ///''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        //  Scope - the Vars object underwhich to look
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        public FRCVars Scope
        {
            get 
            { 
                return mobjScope; 
            }
            set
            {
                mobjScope = value;
                mobjFoundAlready.Clear();
                mintSearchIndex = 0;
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
        public frmFindVar()
        {
            InitializeComponent();

            if (mobjFoundAlready == null)
                mobjFoundAlready = new ArrayList();

            //set min/max size
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }
        ///''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        //  Form_load
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void frmFindVar_Load(object sender, EventArgs e)
        {
            txtFindWhat.Text = string.Empty;
            cmdFindNext.Enabled = false;
            mobjScope = null;
            mintSearchIndex = 0;
        }

        #endregion

        #region "User Input Events"

        //*************************************************************************
        //                        User Input Events
        //*************************************************************************

        ///''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        //  cmdCancel Events
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            if (mblnSearchInProgress)
            {
                mblnCancel = true;
            }
            else
            {
                Hidden();
                this.Hide();
            }
        }

        ///''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        //  txtFindWhat Events
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void txtFindWhat_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFindWhat.Text))
            {
                cmdFindNext.Enabled = false;
            }
            else
            {
                cmdFindNext.Enabled = true;
            }
        }

        private void txtFindWhat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (!string.IsNullOrEmpty(txtFindWhat.Text))
                {
                    cmdFindNext_Click(cmdFindNext, new System.EventArgs());
                }
                // Changing what we're looking for resets what we've already found
            }
            else
            {
                mobjFoundAlready.Clear();
            }

            if (e.KeyChar == 0)
            {
                e.Handled = true;
            }
        }

        ///''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        //  cmdFindNext Events
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdFindNext_Click(object sender, EventArgs e)
        {
            object objFound;

            // This may take a while
            Cursor.Current = Cursors.WaitCursor;
            cmdFindNext.Enabled = false;
            mblnSearchInProgress = true;
            mblnCancel = false;

            while (mintSearchIndex <= (mobjScope.Count - 1))
            {
                // Update progress meter and
                // check if action has been canceled
                lblProgress.Text = mobjScope[Type.Missing, mintSearchIndex].VarName + "...";
                Application.DoEvents();
                if (mblnCancel)
                {
                    mblnSearchInProgress = false;
                    Cursor.Current = Cursors.Default;
                    lblProgress.Text = string.Empty;
                    cmdFindNext.Enabled = true;
                    return;
                }

                // Check the next top level Var/Vars
                objFound = fobjFindNext(mobjScope[Type.Missing, mintSearchIndex]);

                if (objFound != null)
                {
                    // String found, raise it
                    Cursor.Current = Cursors.Default;
                    lblProgress.Text = string.Empty;
                    mblnSearchInProgress = false;
                    cmdFindNext.Enabled = true;
                    FoundVar(objFound);
                    return;
                }
                else
                {
                    // String not found in this item go to next
                    mintSearchIndex = mintSearchIndex + 1;
                }
            }

            // If got here, Finished searching the whole scope
            Cursor.Current = Cursors.Default;
            lblProgress.Text = string.Empty;
            mintSearchIndex = 0;
            mblnSearchInProgress = false;
            cmdFindNext.Enabled = true;

            // If we didn't find any items within the scope,
            // then tell user and exit.
            //short intStartOver;
            if (mobjFoundAlready.Count == 0)
            {
                MessageBox.Show("\"" + txtFindWhat.Text + "\"" + R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_NOT_FOUND, "Find Variable");
                return;
            }
            else
            {
                // We found at least one item within the scope,
                // then it is worth asking if user wants to start over from the top.
                mobjFoundAlready.Clear();
                DialogResult intStartOver = MessageBox.Show(R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_REGION_SEARCHED, "Find Variable", MessageBoxButtons.YesNo, MessageBoxIcon.None);
                if (intStartOver == DialogResult.Yes)
                {
                    cmdFindNext_Click(cmdFindNext, new System.EventArgs());
                }
            }
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

        ///''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // Function: fobjFindNext
        //
        // Main loop to find the next occurrence
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private object fobjFindNext(dynamic vobjVarOrVars)
        {
            // Check the passed in item itself first
            if (fblnNewMatch(vobjVarOrVars))
            {
                return vobjVarOrVars;
            }

            // The item itself didn't match.
            // If It is an FRCVars type, check its children
            object objObject;
            if (vobjVarOrVars is FRCVars)
            {
                foreach (object objVarOrVars in vobjVarOrVars)
                {
                    if (fblnNewMatch(objVarOrVars))
                    {
                        return objVarOrVars;
                    }
                    else
                    {
                        if (objVarOrVars is FRCVars)
                        {
                            objObject = fobjFindNext(objVarOrVars);
                            if (objObject != null)
                            {
                                return objObject;
                            }
                        }
                    }
                }
            }
            // item passed in is an FRCVars
            return null;
        }

        ///''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // Function: fblnNewMatch
        //
        // Verifies if this Var or Vars Name has the string in it and
        // makes sure it isn't one we've already seen.
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private bool fblnNewMatch(dynamic vobjVarObject)
        {
            bool blnMatch;
            string strValue;

            blnMatch = false;

            // Check of name matches
            if (chkFindInName.Checked)
            {
                blnMatch = vobjVarObject.VarName.ToUpper().Contains(txtFindWhat.Text.ToUpper());
            }

            if (!blnMatch && chkFindInValue.Checked && vobjVarObject.VarName.Equals("IVar"))
            {
                // We have a var object, so just try to get the value as a string.
                // If theres no magic to do the conversion, then just ignore the error
                try
                {
                    strValue = Convert.ToString(vobjVarObject.Value);
                    blnMatch = strValue.ToUpper().Contains(txtFindWhat.Text.ToUpper());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "fblnNewMatch");
                }
            }

            // If this is a match, Make sure it is not a repreat
            if (blnMatch)
            {
                foreach (object objObject in mobjFoundAlready)
                {
                    if (object.Equals(objObject, vobjVarObject))
                    {
                        blnMatch = false;
                        break;
                    }
                }
            }

            if (blnMatch)
            {
                mobjFoundAlready.Add(vobjVarObject);
            }

            return blnMatch;
        }

        #endregion

    }
}