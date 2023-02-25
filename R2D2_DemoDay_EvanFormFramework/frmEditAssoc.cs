// Module: frmEditAssoc
//
// Description:
//   Edit both Common and Group Associated data
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

namespace FRRobotDemoCSharp
{
    public partial class frmEditAssoc: Form
    {

        #region "Declarations"

        //*************************************************************************
        //                           Declarations
        //*************************************************************************
        const string strUninit = "*****";
        private bool mblnCancel;

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
        // ROUTINE: EditCommonAssoc
        //
        // Main routine called by other forms to edit common assoc. data
        // Sets up the form
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        public void EditCommonAssoc(FRCCommonAssoc robjVar)
        {
            try
            {
                // Set the proper frame
                FrameGroup.Visible = false;
                FrameCommon.Visible = true;
                mblnCancel = true;

                // Display the data
                RefreshCommonAssoc(robjVar);

                this.ShowDialog();

                if (!mblnCancel)
                {
                    UpdateCommonAssoc(robjVar);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "EditCommonAssoc");
            }
            finally
            {
                this.Close();
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: EditGroupAssoc
        //
        // Main routine called by other forms to edit group assoc. data
        // Sets up the form
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        public void EditGroupAssoc(FRCGroupAssoc robjVar)
        {
            try
            {
                // Set the proper frame
                FrameCommon.Visible = false;
                FrameGroup.Visible = true;
                mblnCancel = true;

                // Display the data
                RefreshGroupAssoc(robjVar);

                this.ShowDialog();

                if (!mblnCancel)
                {
                    UpdateGroupAssoc(robjVar);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "EditGroupAssoc");
            }
            finally
            {
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
        public frmEditAssoc()
        {
            InitializeComponent();
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
        // EVENT: cmdCancel_Click
        //
        // Cancel any changes made to the data
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            mblnCancel = true;
            this.Hide();
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
            mblnCancel = false;
            this.Hide();
        }

        private void frmEditAssoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Escape))
                this.Hide();
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
        // ROUTINE: RefreshCommonAssoc
        //
        // Refresh all the data on the form
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void RefreshCommonAssoc(FRCCommonAssoc robjVar)
        {
            try
            {
                if (robjVar.Parent.IsInitialized)
                {
                    // Update the values
                    switch (robjVar.SegTermType)
                    {
                        case FRETermTypeConstants.frFineTermType:
                            optFine.Checked = true;
                            break;
                        case FRETermTypeConstants.frCoarseTermType:
                            optCoarse.Checked = true;
                            break;
                        case FRETermTypeConstants.frNoSettleTermType:
                            optNosettle.Checked = true;
                            break;
                        case FRETermTypeConstants.frNoDecelTermType:
                            optNoDecel.Checked = true;
                            break;
                        case FRETermTypeConstants.frVarDecelTermType:
                            optVarDecel.Checked = true;
                            break;
                        default:
                            optNone.Checked = true;
                            break;
                    }
                    txtSegDecelTol.Text = robjVar.SegDecelTol.ToString();
                    txtSegRelAccel.Text = robjVar.SegRelAccel.ToString();
                    txtSegTimeShift.Text = robjVar.SegTimeShift.ToString();
                }
                else
                {
                    // Show uninit values
                    optNone.Checked = true;
                    txtSegDecelTol.Text = strUninit;
                    txtSegRelAccel.Text = strUninit;
                    txtSegTimeShift.Text = strUninit;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "RefreshCommonAssoc");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: UpdateCommonAssoc
        //
        // Change common assoc. data based upon options selected
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void UpdateCommonAssoc(FRCCommonAssoc robjVar)
        {
            try
            {
                if (optFine.Checked)
                {
                    robjVar.SegTermType = FRETermTypeConstants.frFineTermType;
                }
                else if (optCoarse.Checked)
                {
                    robjVar.SegTermType = FRETermTypeConstants.frCoarseTermType;
                }
                else if (optNosettle.Checked)
                {
                    robjVar.SegTermType = FRETermTypeConstants.frNoSettleTermType;
                }
                else if (optNoDecel.Checked)
                {
                    robjVar.SegTermType = FRETermTypeConstants.frNoDecelTermType;
                }
                else if (optVarDecel.Checked)
                {
                    robjVar.SegTermType = FRETermTypeConstants.frVarDecelTermType;
                }

                if (!txtSegDecelTol.Text.Equals(strUninit))
                {
                    short output;
                    if (!short.TryParse(txtSegDecelTol.Text, out output))
                    {
                        MessageBox.Show("Please enter valid number");
                        return;
                    }
                    robjVar.SegDecelTol = short.Parse(txtSegDecelTol.Text);
                }
                if (!txtSegRelAccel.Text.Equals(strUninit))
                {
                    short output;
                    if (!short.TryParse(txtSegRelAccel.Text, out output))
                    {
                        MessageBox.Show("Please enter valid number");
                        return;
                    }
                    robjVar.SegRelAccel = short.Parse(txtSegRelAccel.Text);
                }
                if (!txtSegTimeShift.Text.Equals(strUninit))
                {
                    short output;
                    if (!short.TryParse(txtSegTimeShift.Text, out output))
                    {
                        MessageBox.Show("Please enter valid number");
                        return;
                    }
                    robjVar.SegTimeShift = short.Parse(txtSegTimeShift.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "UpdateCommonAssoc");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: RefreshGroupAssoc
        //
        // Refresh all data on the form
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void RefreshGroupAssoc(FRCGroupAssoc robjVar)
        {
            try
            {
                if (robjVar.Parent.IsInitialized)
                {
                    // Update the values
                    switch (robjVar.SegMoType)
                    {
                        case FREMotionTypeConstants.frJointMotionType:
                            optJoint.Checked = true;
                            break;
                        case FREMotionTypeConstants.frLinearMotionType:
                            optLinear.Checked = true;
                            break;
                        case FREMotionTypeConstants.frCircularMotionType:
                            optCircular.Checked = true;
                            break;
                        default:
                            optNone_gt.Checked = true;
                            break;
                    }

                    switch (robjVar.SegOrientType)
                    {
                        case FREOrientTypeConstants.frRSWorldOrientType:
                            optRSWorld.Checked = true;
                            break;
                        case FREOrientTypeConstants.frAESWorldOrientType:
                            optAESWorld.Checked = true;
                            break;
                        case FREOrientTypeConstants.frWristJointOrientType:
                            optWristJoint.Checked = true;
                            break;
                        default:
                            optNone_go.Checked = true;
                            break;
                    }

                    txtSegRelSpeed.Text = robjVar.SegRelSpeed.ToString();
                    chkSegBreak.Checked = robjVar.SegBreak;
                }
                else
                {
                    // Show uninit values
                    optNone_gt.Checked = true;
                    optNone_go.Checked = true;
                    txtSegRelSpeed.Text = strUninit;
                    chkSegBreak.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "RefreshGroupAssoc");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: UpdateGroupAssoc
        //
        // Change group assoc. values based on options selected
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void UpdateGroupAssoc(FRCGroupAssoc robjVar)
        {
            try
            {
                if (optJoint.Checked)
                {
                    robjVar.SegMoType = FREMotionTypeConstants.frJointMotionType;
                }
                else if (optLinear.Checked)
                {
                    robjVar.SegMoType = FREMotionTypeConstants.frLinearMotionType;
                }
                else if (optCircular.Checked)
                {
                    robjVar.SegMoType = FREMotionTypeConstants.frCircularMotionType;
                }
                if (optRSWorld.Checked)
                {
                    robjVar.SegOrientType = FREOrientTypeConstants.frRSWorldOrientType;
                }
                else if (optAESWorld.Checked)
                {
                    robjVar.SegOrientType = FREOrientTypeConstants.frAESWorldOrientType;
                }
                else if (optWristJoint.Checked)
                {
                    robjVar.SegOrientType = FREOrientTypeConstants.frWristJointOrientType;
                }
                if (!txtSegRelSpeed.Text.Equals(strUninit))
                {
                    robjVar.SegRelSpeed = short.Parse(txtSegRelSpeed.Text);
                }

                robjVar.SegBreak = chkSegBreak.Checked;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "UpdateGroupAssoc");
            }
        }

        #endregion

    }
}