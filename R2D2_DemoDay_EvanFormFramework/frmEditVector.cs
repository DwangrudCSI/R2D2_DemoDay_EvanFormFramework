// Module: frmEditVector
//
// Description:
//   Present X,Y,Z for editing
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
    public partial class frmEditVector : Form
    {

        #region "Declarations"

        //*************************************************************************
        //                           Declarations
        //*************************************************************************
        const string strUninit = "*****";
        private bool mblnCancel;

        private FRCVector mobjVec;

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
        // ROUTINE: EditVar
        //
        // Routine called by other forms, displays current information and
        // writes changes if ok is clicked
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        public void EditVar(FRCVector objVar)
        {
            try
            {
                // Set the vector object
                mobjVec = objVar;

                // Display the vector data
                RefreshVec();

                this.ShowDialog();

                if (!mblnCancel)
                {
                    UpdateVec();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "EditVar");
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
        public frmEditVector()
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
        // Reject the changes
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
        // Accept the changes
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdOK_Click(object sender, EventArgs e)
        {
            mblnCancel = false;
            this.Hide();
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: frmEditVector_KeyPress
        //
        // Press ESC to simulate cancel button press
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void frmEditVector_KeyPress(object sender, KeyPressEventArgs e)
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

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: RefreshVec
        //
        // Refresh the data on the screen
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void RefreshVec()
        {
            try
            {
                if (mobjVec.Parent.IsInitialized)
                {
                    // Update the xyz values
                    txtX.Text = mobjVec.X.ToString();
                    txtY.Text = mobjVec.Y.ToString();
                    txtZ.Text = mobjVec.Z.ToString();
                }
                else
                {
                    // Show uninit values
                    txtX.Text = strUninit;
                    txtY.Text = strUninit;
                    txtZ.Text = strUninit;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "RefreshVec");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: UpdateVec
        //
        // Update the data on the controller
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void UpdateVec()
        {
            double output;
            try
            {
                if (!txtX.Text.Equals(strUninit))
                {
                    if (double.TryParse(txtX.Text, out output))
                        mobjVec.X = output;
                }
                if (!txtY.Text.Equals(strUninit))
                {
                    if (double.TryParse(txtY.Text, out output))
                        mobjVec.Y = output;
                }
                if (!txtZ.Text.Equals(strUninit))
                {
                    if (double.TryParse(txtZ.Text, out output))
                        mobjVec.Z = output;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "UpdateVec");
            }
        }

        #endregion

    }
}