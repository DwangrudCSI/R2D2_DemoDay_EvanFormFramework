// Module: frmIOConfigAdd
//
// Description:
//   Dialog box to input I/O config data
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
    public partial class frmIOConfigAdd : Form
    {

        #region "Declarations"

        //*************************************************************************
        //                           Declarations
        //*************************************************************************
        private DialogResult mblnReturnStatus;

        #endregion

        #region "Public Properties and Methods"

        //*************************************************************************
        //                      Public Properties and Methods
        //*************************************************************************
        public int FirstLogicalNum
        {
            get { return int.Parse(txtFirstLogicalNum.Text); }
            set { txtFirstLogicalNum.Text = value.ToString(); }
        }

        public int NumSignals
        {
            get { return int.Parse(txtNumSignals.Text); }
            set { txtNumSignals.Text = value.ToString(); }
        }

        public short Rack
        {
            get { return short.Parse(txtRack.Text); }
            set { txtRack.Text = value.ToString(); }
        }

        public short Slot
        {
            get { return short.Parse(txtSlot.Text); }
            set { txtSlot.Text = value.ToString(); }
        }

        public int FirstPhysicalNum
        {
            get { return int.Parse(txtFirstPhysicalNum.Text); }
            set { txtFirstPhysicalNum.Text = value.ToString(); }
        }

        public DialogResult ReturnStatus
        {
            get { return mblnReturnStatus; }
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
        public frmIOConfigAdd()
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
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            mblnReturnStatus = DialogResult.Cancel;
            this.Hide();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            mblnReturnStatus = DialogResult.OK;
            this.Hide();
        }

        private void frmIOConfigAdd_Load(object sender, EventArgs e)
        {
            mblnReturnStatus = DialogResult.Cancel;
        }

        private void frmIOConfigAdd_FormClosed(object sender, FormClosedEventArgs e)
        {
            mblnReturnStatus = DialogResult.Cancel;
        }

        private void frmIOConfigAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Escape))
                this.Close();
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