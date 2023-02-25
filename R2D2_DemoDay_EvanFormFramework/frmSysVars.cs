// Module: frmSysVars
//
// Description:
//   Display and modify system variables
//
// Author: Tri Quach
//         FANUC America Corporation 
//         29700 Kohoutek Way
//         Union City, CA 94587
//
// Modification history:
// 05-Oct-2015 Quach    Adapted from the VB.Net version

using FRRobot;
using System.Collections.Generic;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace FRRobotDemoCSharp
{
    public partial class frmSysVars : Form
    {

        #region "Declarations"

        //*************************************************************************
        //                           Declarations
        //*************************************************************************
        // Variable objects
        private FRCVar mobjVar;
        private FRCVars mobjSelVars;
        private FRCVars mobjSysVars;
        private bool mblnIgnoreNoRefreshClick;
        private frmFindVar mobjFindVar;
        private TreeNode mobjTopNode;
        private string mstrInitialVarName;

        FRRobotDemo FRRobotDemo;
        frmEditPosition frmEditPosition;
        frmEditVector frmEditVector;
        frmEditAssoc frmEditAssoc;
        //frmScattAccess frmScattAccess;
        frmFindVar frmFindVar;

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
        public frmSysVars()
        {
            InitializeComponent();
            //set min/max size
            this.MinimumSize = this.Size;
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: frmSysVars_Activated
        //
        // Set up the form display and set up the SysVars Tree
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void frmSysVars_Activated(object sender, EventArgs e)
        {
            if (treSysVars.Nodes.Count == 0)
            {
                UpdateSysVarsTab();
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: frmSysVars_Load
        //
        // Set up the form display and set up the SysVars Tree
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void frmSysVars_Load(object sender, EventArgs e)
        {
            // Set Initial Form size
            this.Height = int.Parse(Registry.GetSetting("FRRobotDemo", "Settings", "frmSysVarsHeight", "530"));
            if (this.Height < 200)
                this.Height = 200;
            this.Width = int.Parse(Registry.GetSetting("FRRobotDemo", "Settings", "frmSysVarsWidth", "600"));
            if (this.Width < 200)
                this.Width = 200;
            mstrInitialVarName = Registry.GetSetting("FRRobotDemo", "Settings", "InitialVarName", "");

            treSysVars.Nodes.Clear();

            mobjSysVars = FRRobotDemo.gobjRobot.SysVariables;
            mobjFindVar = null;
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: frmSysVars_FormClosing
        //
        // Save last window size settings.
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void frmSysVars_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mobjVar != null)
                mobjVar.Change -= mobjVar_Change;

            if (frmFindVar != null)
            {
                frmFindVar.FoundVar -= mobjFindVar_FoundVar;
                frmFindVar.Hidden -= mobjFindVar_Hidden;
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: tmrUpdateLight_Tick
        //
        // Timer event when updating variables
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void tmrUpdateLight_Tick(object sender, EventArgs e)
        {
            tmrUpdateLight.Enabled = false;
            picEvent.BackColor = Color.FromArgb(128, 128, 0);
        }

        #endregion

        #region "User Input Events"

        //*************************************************************************
        //                        User Input Events
        //*************************************************************************

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: treSysVars_AfterExpand
        //
        // Expand the node to list the sub vars
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void treSysVars_AfterExpand(object sender, TreeViewEventArgs e)
        {
            TreeNode vobjNode = e.Node;

            // This may take a while
            Cursor.Current = Cursors.WaitCursor;

            subEnsurePopulated(vobjNode);

            Cursor.Current = Cursors.Default;
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: treSysVars_AfterSelect
        //
        // Follow the highlighted item changes
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void treSysVars_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode vobjNode = e.Node;
            dynamic objVar;

            // Set first to objVar to avoid type mismatch error
            objVar = FindNodeVar(vobjNode);
            if (objVar is FRCVar)
            {
                mobjVar = objVar;
                mobjSelVars = null;
            }
            else
            {
                mobjVar = null;
                mobjSelVars = objVar;
            }
            UpdateVarData();
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdMonitor_Click
        //
        // Start monitoring the selected variable
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdMonitor_Click(object sender, EventArgs e)
        {
            try
            {
                mobjVar.StartMonitor(int.Parse(txtLatency.Text));
                picMonitor.BackColor = Color.FromArgb(255, 0, 0);
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
        // Stop monitoring the selected variable
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdStopMon_Click(object sender, EventArgs e)
        {
            try
            {
                mobjVar.StopMonitor();
                picMonitor.BackColor = Color.FromArgb(128, 0, 0);
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
        // Refreshes the data for the selected var/vars
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                if (mobjVar != null)
                {
                    mobjVar.Refresh();
                }
                else if (mobjSelVars != null)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    mobjSelVars.Refresh();
                    Cursor.Current = Cursors.Default;
                }

                // Redisplay the variable data
                UpdateVarData();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message, "cmdRefresh_Click");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdUpdate_Click
        //
        // Updates the data for the selected var/vars
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
                else if (mobjSelVars != null)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    mobjSelVars.Update();
                    Cursor.Current = Cursors.Default;
                }

                // Redisplay the variable data
                UpdateVarData();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message, "cmdUpdate_Click");
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
        //    if (frmScattAccess == null || frmScattAccess.IsDisposed)
        //        frmScattAccess = new frmScattAccess();

        //    if (mobjVar != null)
        //    {
        //        frmScattAccess.AddItem(mobjVar);
        //    }
        //    else if (mobjSelVars != null)
        //    {
        //        frmScattAccess.AddItem(mobjSelVars);
        //    }
        //    else
        //    {
        //        MessageBox.Show(Properties.Resources.IDS_NOTHING_SELECTED);
        //    }
        //}

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: txtVarValue_KeyPress
        //
        // Update var value only when enter key is pressed
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void txtVarValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            FRCVar objVar;

            if (e.KeyChar.Equals((char)(Keys.Enter)))
            {
                try
                {
                    // Make sure that we have a selected node in the tree view
                    // and that it has no children (is an actual variable).

                    if (treSysVars.SelectedNode != null && (treSysVars.SelectedNode.GetNodeCount(false) == 0))
                    {
                        // Get the var object based on the node
                        objVar = (FRCVar)FindNodeVar(treSysVars.SelectedNode);
                        mobjVar.Value = txtVarValue.Text;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "txtVarValue_KeyPress");
                    UpdateVarData();
                }
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdFind_Click
        //
        // Brings up the find dialog box
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdFind_Click(object sender, EventArgs e)
        {
            // Show the Find form.
            if (frmFindVar == null || frmFindVar.IsDisposed)
            {
                frmFindVar = new frmFindVar();
                //unsubscribe event if already subscribed
                frmFindVar.FoundVar -= mobjFindVar_FoundVar;
                frmFindVar.Hidden -= mobjFindVar_Hidden;
                //subscribe event handlers
                frmFindVar.FoundVar += mobjFindVar_FoundVar;   
                frmFindVar.Hidden += mobjFindVar_Hidden;
            }
            mobjFindVar = frmFindVar;
            mobjFindVar.Show();

            // Then give it the scope of search
            if (FRRobotDemo == null)
                FRRobotDemo = new FRRobotDemo();
            mobjFindVar.Scope = FRRobotDemo.gobjRobot.SysVariables;
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: mobjFindVar_FoundVar
        //
        // The var finder found something
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void mobjFindVar_FoundVar(dynamic objVarFound)
        {
            TreeNode objNode;

            // Recursively find the parent node then expand as required to self
            objNode = fobjExposeItem(objVarFound.VarName);

            treSysVars.SelectedNode = objNode;

            Cursor.Current = Cursors.Default;
            treSysVars.Focus();
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: mobjFindVar_Hidden
        //
        // The find dialog box is going away. Stop monitoring its events
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        void mobjFindVar_Hidden()
        {
            mobjFindVar = null;
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdEditValue_Click
        //
        // Bring up special dialog to edit complex variables
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdEditValue_Click(object sender, EventArgs e)
        {
            try
            {
                if (mobjVar != null)
                {
                    if(frmEditPosition == null || frmEditPosition.IsDisposed)
                        frmEditPosition = new frmEditPosition();
                    if (frmEditVector == null || frmEditVector.IsDisposed)
                        frmEditVector = new frmEditVector();
                    if (frmEditAssoc == null || frmEditAssoc.IsDisposed)
                        frmEditAssoc = new frmEditAssoc();
                    // Edit value based on its type
                    switch (mobjVar.TypeCode)
                    {
                        case FRETypeCodeConstants.frExtTransform:
                        case FRETypeCodeConstants.frTransform:
                        case FRETypeCodeConstants.frExtXyzWpr:
                        case FRETypeCodeConstants.frXyzWpr:
                        case FRETypeCodeConstants.frJoint:
                            // Edit the position
                            frmEditPosition.EditVar(mobjVar.Value);
                            break;
                        case FRETypeCodeConstants.frVectorType:
                            // Edit the vector
                            frmEditVector.EditVar(mobjVar.Value);
                            break;
                        case FRETypeCodeConstants.frCommonAssocType:
                            // Edit the common associated data
                            frmEditAssoc.EditCommonAssoc(mobjVar.Value);
                            break;
                        case FRETypeCodeConstants.frGroupAssocType:
                            // Edit the group associated data
                            frmEditAssoc.EditGroupAssoc(mobjVar.Value);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cmdEditValue_Click");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: chkNoRefresh_CheckedChanged
        //
        // Set the value of the NoRefresh Property for a var or collection of vars
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void chkNoRefresh_CheckedChanged(object sender, EventArgs e)
        {
            if (!mblnIgnoreNoRefreshClick)
            {
                try
                {
                    if (mobjVar != null)
                    {
                        // Set the value of its no-refresh state
                        mobjVar.NoRefresh = chkNoRefresh.Checked;
                    }

                    if (mobjSelVars != null)
                    {
                        // Set the value of its no-refresh state
                        // This may take a while on large structures
                        mobjSelVars.NoRefresh = chkNoRefresh.Checked;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "chkNoRefresh_CheckedChanged");
                    if (ex.HResult == (int)FRERobotErrors.frInvForSysvars)
                    {
                        mblnIgnoreNoRefreshClick = true;
                        chkNoRefresh.Checked = false;
                        mblnIgnoreNoRefreshClick = false;
                    }
                }
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: chkNoUpdate_CheckedChanged
        //
        // Set the value of the NoUpdate Property for a var or collection of vars
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void chkNoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if (!mblnIgnoreNoRefreshClick)
            {
                try
                {
                    if (mobjVar != null)
                    {
                        // Set the value of its no-Update state
                        mobjVar.NoUpdate = chkNoUpdate.Checked;
                    }

                    if (mobjSelVars != null)
                    {
                        // Set the value of its no-Update state
                        // This may take a while on large structures
                        mobjSelVars.NoUpdate = chkNoUpdate.Checked;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "chkNoUpdate_CheckedChanged");
                    if (ex.HResult == (int)FRERobotErrors.frInvForSysvars)
                    {
                        mblnIgnoreNoRefreshClick = true;
                        chkNoUpdate.Checked = false;
                        mblnIgnoreNoRefreshClick = false;
                    }
                }
            }
        }

        #endregion

        #region "Robot Server Events"

        //*************************************************************************
        //                        Robot Server Events
        //*************************************************************************

        #endregion

        #region "RobotServer Events"

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: mobjVar_Change
        //
        // Update the variable data when information changes
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private delegate void VarChangeDelegate();
        private void mobjVar_Change()
        {
            if (this.InvokeRequired)
            {
                VarChangeDelegate HandleVarChange = new VarChangeDelegate(mobjVar_Change);
                this.BeginInvoke(HandleVarChange);
            }
            else
            {
                UpdateVarData();
                tmrUpdateLight.Enabled = true;
                picEvent.BackColor = Color.FromArgb(255, 255, 0);
            }
        }

        #endregion

        #region "Utility Routines"

        //*************************************************************************
        //                        Utility Routines
        //*************************************************************************

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: UpdateSysVarsTab
        //
        // Clear the tree and fill it in again
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void UpdateSysVarsTab()
        {
            TreeNode objNode;

            Cursor.Current = Cursors.WaitCursor;

            mobjVar = null;
            mobjSelVars = null;
            treSysVars.Nodes.Clear();

            // Add the top level node
            mobjTopNode = treSysVars.Nodes.Add("System Variables", "System Variables");

            // Recursively add all the subvars
            InsertSubVars(mobjTopNode, mobjSysVars);

            // Now set the top visible again
            mobjTopNode.EnsureVisible();

            // Automatically expand the top level
            mobjTopNode.Expand();

            // Select the first item
            objNode = fobjExposeItem(mstrInitialVarName);
            treSysVars.SelectedNode = objNode;

            Cursor.Current = Cursors.Default;
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: InsertSubVars
        //
        // Fills the list of Sub Variables
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        public void InsertSubVars(TreeNode robjParent, FRCVars robjVars)
        {
            TreeNode objNode;

            try
            {
                // Loop thru for each group of the robot
                foreach (dynamic objSub in robjVars)
                {
                    // Add the node to the list
                    objNode = robjParent.Nodes.Add(objSub.VarName, objSub.FieldName.ToUpper());

                    if (objSub is FRCVars)
                    {
                        // Only add structure type variables to the list.
                        objNode.Tag = "FRCVars";
                        objNode.Nodes.Add(objSub.VarName, "ExpandMe");
                    }
                    else
                    {
                        // The rest of the variables (the ones with values) we
                        // will display in the right pane detail view.
                        objNode.Tag = "FRCVar";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "InsertSubVars");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // FUNCTION: fobjExposeItem
        //
        // Makes sure the treeview is populated enough to show the item identified
        // by the variable name.
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private TreeNode fobjExposeItem(string vstrVarName)
        {
            TreeNode objExposedItem;
            List<string> lstFieldNames = new List<string>();
            int intIndex;
            TreeNode objParent;
            bool blnFound;

            // If all else fails, return the top node
            objExposedItem = treSysVars.Nodes[0];

            try
            {
                if (!string.IsNullOrEmpty(vstrVarName))
                {
                    // The branches of the trees are defined by the field names of 
                    // the variable name.  For example the field names of
                    // A[1,2].B[1].C are A,1,2,B,1,C
                    // These are the nodes of the tree.
                    int intStart = 1;
                    string strNextChar;
                    for (intIndex = 1; intIndex <= vstrVarName.Length; intIndex++)
                    {
                        strNextChar = vstrVarName.Substring(intIndex - 1, 1);

                        if (strNextChar.Equals(".") || 
                            strNextChar.Equals("[") || 
                            strNextChar.Equals("]") || 
                            strNextChar.Equals(","))
                        {
                            // Field separator found
                            if (intStart != intIndex)
                            {
                                // Field name since the last field separator.
                                lstFieldNames.Add((vstrVarName.Substring(intStart - 1, intIndex - intStart)).ToUpper());
                            }
                            intStart = intIndex + 1;
                        }
                    }

                    // Add final field name if it exists.
                    if (intStart < vstrVarName.Length)
                    {
                        lstFieldNames.Add((vstrVarName.Substring(intStart - 1)).ToUpper());
                    }

                    objParent = mobjTopNode;

                    // Indexing through the PathName in this manner will only bring up
                    // the var structure stops.
                    foreach (string strFieldName in lstFieldNames)
                    {
                        // Another Field name stop. Make sure the parent has been expanded
                        // and its children, if any, are visible
                        subEnsurePopulated(objParent);
                        blnFound = false;
                        foreach (TreeNode objNode in objParent.Nodes)
                        {
                            if (objNode.Text.Equals(strFieldName))
                            {
                                // Var name stop found, keep walking the tree
                                objExposedItem = objNode;
                                objParent = objNode;
                                objParent.EnsureVisible();
                                blnFound = true;
                                break;
                            }
                        }

                        if (!blnFound)
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("unexpected error exposing ' " + vstrVarName + "'" + "\r\n" + ex.Message, "fobjExposeItem");
            }

            return objExposedItem;

            // subEnsurePopulated may have switched to the wait cursor
            // mblnIgnoreClickEvents = False

            //subEnableDisableButtons()
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: subEnsurePopulated
        //
        // Makes sure that the children of node that represents and FRCRNRobots
        // item are created.
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void subEnsurePopulated(TreeNode robjParent)
        {
            // Get the first sub node
            if (robjParent.FirstNode.Text.Equals("ExpandMe"))
            {
                // We need to expand the list since it isn't currently done
                robjParent.Nodes.Clear();

                // Find the Fields object that matches the node
                // Now add all of the sysvars
                InsertSubVars(robjParent, (FRCVars)FindNodeVar(robjParent));
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // FUNCTION: FindNodeVar
        //
        // Used to find the FRCVars 
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        public object FindNodeVar(TreeNode vobjNode)
        {
            FRCVars objVars;

            // Recurse until we find the root
            if (vobjNode.Parent == null)
            {
                return FRRobotDemo.gobjRobot.SysVariables;
            }
            else
            {
                // Find the node for our parent
                objVars = (FRCVars)FindNodeVar(vobjNode.Parent);
                return objVars[vobjNode.Text, Type.Missing];
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: UpdateVarData
        //
        // Update the information displayed based upon the selected variable
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        public void UpdateVarData()
        {
            dynamic objVar;

            // Set up for "typical" display
            txtVarValue.Visible = true;
            txtVarValue.Enabled = true;
            cmdEditValue.Visible = false;

            if (mobjVar == null & mobjSelVars == null)
            {
                txtVarName.Text = string.Empty;
                txtFieldName.Text = string.Empty;
                txtTypeName.Text = string.Empty;
                txtVarValue.Text = string.Empty;
                txtMin.Text = string.Empty;
                txtMax.Text = string.Empty;
            }
            else
            {
                // Handle properties specific to Var .vs. Vars
                if (mobjVar != null)
                {
                    // Handle stuff only on Var objects
                    objVar = mobjVar;

                    // Display the Value text box based on the ability to show/edit its value
                    switch (mobjVar.TypeCode)
                    {
                        // Position data gets a edit command button
                        case FRETypeCodeConstants.frExtTransform:
                        case FRETypeCodeConstants.frTransform:
                        case FRETypeCodeConstants.frExtXyzWpr:
                        case FRETypeCodeConstants.frXyzWpr:
                        case FRETypeCodeConstants.frJoint:
                        case FRETypeCodeConstants.frVectorType:
                        case FRETypeCodeConstants.frCommonAssocType:
                        case FRETypeCodeConstants.frGroupAssocType:
                            txtVarValue.Visible = false;
                            cmdEditValue.Visible = true;
                            break;
                        default:
                            // Else display values that can be
                            try
                            {
                                txtVarValue.Text = Convert.ToString(mobjVar.Value);
                            }
                            catch (Exception ex)
                            {
                                int errResult = ex.HResult;
                                if (errResult == (int)FRERobotErrors.frUninit)
                                {
                                    txtVarValue.Text = "**** Uninitialized *****";
                                }
                                else if (errResult != 0)
                                {
                                    txtVarValue.Text = ex.Message;
                                    txtVarValue.Enabled = false;
                                }
                                MessageBox.Show(ex.Message, "UpdateVarData1");
                            }
                            break;
                    }
                    try
                    {
                        txtTypeName.Text = mobjVar.TypeName;

                        // Update type code property
                        switch (mobjVar.TypeCode)
                        {
                            case FRETypeCodeConstants.frArrayType:
                                txtTypeCode.Text = "frArrayType - " + FRETypeCodeConstants.frArrayType.ToString();
                                break;
                            case FRETypeCodeConstants.frBooleanType:
                                txtTypeCode.Text = "frBooleanType - " + FRETypeCodeConstants.frBooleanType.ToString();
                                break;
                            case FRETypeCodeConstants.frByteType:
                                txtTypeCode.Text = "frByteType - " + FRETypeCodeConstants.frByteType.ToString();
                                break;
                            case FRETypeCodeConstants.frCommonAssocType:
                                txtTypeCode.Text = "frCommonAssocType - " + FRETypeCodeConstants.frCommonAssocType.ToString();
                                break;
                            case FRETypeCodeConstants.frConfigType:
                                txtTypeCode.Text = "frConfigType - " + FRETypeCodeConstants.frConfigType.ToString();
                                break;
                            case FRETypeCodeConstants.frExtTransform:
                                txtTypeCode.Text = "frExtTransform - " + FRETypeCodeConstants.frExtTransform.ToString();
                                break;
                            case FRETypeCodeConstants.frExtXyz456:
                                txtTypeCode.Text = "frExtXyz456 - " + FRETypeCodeConstants.frExtXyz456.ToString();
                                break;
                            case FRETypeCodeConstants.frExtXyzAes:
                                txtTypeCode.Text = "frExtXyzAes - " + FRETypeCodeConstants.frExtXyzAes.ToString();
                                break;
                            case FRETypeCodeConstants.frExtXyzWpr:
                                txtTypeCode.Text = "frExtXyzWpr - " + FRETypeCodeConstants.frExtXyzWpr.ToString();
                                break;
                            case FRETypeCodeConstants.frFileType:
                                txtTypeCode.Text = "frFileType - " + FRETypeCodeConstants.frFileType.ToString();
                                break;
                            case FRETypeCodeConstants.frGroupAssocType:
                                txtTypeCode.Text = "frGroupAssocType - " + FRETypeCodeConstants.frGroupAssocType.ToString();
                                break;
                            case FRETypeCodeConstants.frIntegerType:
                                txtTypeCode.Text = "frIntegerType - " + FRETypeCodeConstants.frIntegerType.ToString();
                                break;
                            case FRETypeCodeConstants.frJoint:
                                txtTypeCode.Text = "frJoint - " + FRETypeCodeConstants.frJoint.ToString();
                                break;
                            case FRETypeCodeConstants.frPathType:
                                txtTypeCode.Text = "frPathType - " + FRETypeCodeConstants.frPathType.ToString();
                                break;
                            case FRETypeCodeConstants.frRealType:
                                txtTypeCode.Text = "frRealType - " + FRETypeCodeConstants.frRealType.ToString();
                                break;
                            case FRETypeCodeConstants.frRegNumericType:
                                txtTypeCode.Text = "frRegNumericType - " + FRETypeCodeConstants.frRegNumericType.ToString();
                                break;
                            case FRETypeCodeConstants.frRegPositionType:
                                txtTypeCode.Text = "frRegPositionType - " + FRETypeCodeConstants.frRegPositionType.ToString();
                                break;
                            case FRETypeCodeConstants.frShortType:
                                txtTypeCode.Text = "frShortType - " + FRETypeCodeConstants.frShortType.ToString();
                                break;
                            case FRETypeCodeConstants.frStringType:
                                txtTypeCode.Text = "frStringType - " + FRETypeCodeConstants.frStringType.ToString();
                                break;
                            case FRETypeCodeConstants.frStructureType:
                                txtTypeCode.Text = "frStructureType - " + FRETypeCodeConstants.frStructureType.ToString();
                                break;
                            case FRETypeCodeConstants.frTransform:
                                txtTypeCode.Text = "frTransform - " + FRETypeCodeConstants.frTransform.ToString();
                                break;
                            case FRETypeCodeConstants.frVectorType:
                                txtTypeCode.Text = "frVectorType - " + FRETypeCodeConstants.frVectorType.ToString();
                                break;
                            case FRETypeCodeConstants.frXyz456:
                                txtTypeCode.Text = "txtTypeCode - " + txtTypeCode.Text;
                                break;
                            case FRETypeCodeConstants.frXyzAes:
                                txtTypeCode.Text = "txtTypeCode - " + txtTypeCode.Text;
                                break;
                            case FRETypeCodeConstants.frXyzWpr:
                                txtTypeCode.Text = "frXyzWpr - " + FRETypeCodeConstants.frXyzWpr.ToString();
                                break;
                        }

                        txtMin.Text = string.Empty;
                        txtMax.Text = string.Empty;
                        // Min and Max values are not supported for all types
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "UpdateVarData2");
                    }

                    try
                    {
                        txtMin.Text = Convert.ToString(mobjVar.MinValue);
                        txtMax.Text = Convert.ToString(mobjVar.MaxValue);
                    }
                    catch
                    {
                        txtMin.Text = string.Empty;
                        txtMax.Text = string.Empty;
                    }
                    txtVarName.Text = objVar.VarName;
                    mstrInitialVarName = txtVarName.Text;
                    txtFieldName.Text = objVar.FieldName;

                    // Handle properties common to Var and Vars
                }
                else
                {
                    try
                    {
                        // Handle stuff only on Vars objects
                        objVar = mobjSelVars;

                        // Init Var form controls to empty
                        txtVarValue.Text = string.Empty;
                        txtTypeName.Text = string.Empty;
                        txtTypeCode.Text = string.Empty;
                        txtMin.Text = string.Empty;
                        txtMax.Text = string.Empty;

                        mblnIgnoreNoRefreshClick = true;

                        chkNoRefresh.Checked = mobjSelVars.NoRefresh;
                        chkNoUpdate.Checked = mobjSelVars.NoUpdate;

                        mblnIgnoreNoRefreshClick = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "UpdateVarData");
                    }
                }
            }
            // not valid Var or Vars
        }

        #endregion

    }
}