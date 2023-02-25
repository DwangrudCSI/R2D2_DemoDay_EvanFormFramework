// Module: frmEditNumReg
//
// Description:
//    Edit a Numeric Register
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
    public partial class frmEditNumReg : Form
    {

        #region "Declarations"

        //*************************************************************************
        //                           Declarations
        //*************************************************************************
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
        // ROUTINE: Edit
        //
        // Displays current value, type, and comment.  Changes values if
        // OK is pressed
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        public void Edit(FRCVar objVar)
        {
            FRCRegNumeric objNumReg;

            objNumReg = objVar.Value;
            mblnCancel = true;

            // Set the edit box caption
            this.Text = R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_EDITING + objVar.VarName;

            // Copy the comment string
            txtComment.Text = objNumReg.Comment;

            if (objNumReg.Type == FRETypeCodeConstants.frIntegerType)
            {
                optInteger.Checked = true;
                txtValue.Text = objNumReg.RegLong.ToString();
            }
            else
            {
                optReal.Checked = true;
                txtValue.Text = objNumReg.RegFloat.ToString();
            }

            // Show the form modally
            ShowDialog();

            try
            {
                // Check to see if we cancelled
                if (!mblnCancel)
                {
                    // Update the comment string back
                    objNumReg.Comment = txtComment.Text;
                    if (optInteger.Checked)
                    {
                        objNumReg.RegLong = int.Parse(txtValue.Text);
                    }
                    else
                    {
                        objNumReg.RegFloat = float.Parse(txtValue.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Edit");
            }
            finally
            {
                this.Close();
            }

            return;
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
        public frmEditNumReg()
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
        // Reject changes to the String register
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
        // Accept changes to the String register
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdOK_Click(object sender, EventArgs e)
        {
            mblnCancel = false;
            this.Hide();
        }

        private void frmEditNumReg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Escape))
                cmdCancel_Click(this, new EventArgs());
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

        #endregion

    }
}