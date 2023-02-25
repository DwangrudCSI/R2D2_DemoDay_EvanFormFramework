// Module: frmConnect
//
// Description:
//    Ask the user which robot to connect to
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
using FRRNSelect;
using System;
using System.Net;
using System.Windows.Forms;

namespace FRRobotDemoCSharp
{
    public partial class frmConnect : Form
    {

        #region "Declarations"

        //*************************************************************************
        //                                  Declarations
        //*************************************************************************
        private string mstrHostName;
        private string mstrRNPath;

        public string HostName
        {
            get { return mstrHostName; }
        }

        public string RNPath
        {
            get { return mstrRNPath; }
        }

        FRRobotDemo FRRobotDemo;
        frmFRRobotDemo frmFRRobotDemo;

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

        #region "Form Maintenance"

        //*************************************************************************
        //                         Form Maintenance
        //*************************************************************************

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // Constuctor
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        public frmConnect()
        {
            InitializeComponent();
            //set min/max size
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: Form_Load
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void frmConnect_Load(object sender, EventArgs e)
        {
            try
            {
                // Recover the last selections
                txtRNPath.Text = Registry.GetSetting("FRRobotDemo", "MRU", "LastRNSelection", "\\");
                txtHostName.Text = Registry.GetSetting("FRRobotDemo", "MRU", "LastHostNameSelection", txtHostName.Text);
                if (Registry.GetSetting("FRRobotDemo", "MRU", "LastSelectionMethod", "0").Contains("0"))
                {
                    rbByHostName.Checked = true;
                }
                else
                {
                    rbFromRN.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "frmConnect_Load");
            }
        }

        #endregion

        #region "User Input Events"

        //*************************************************************************
        //                        User Input Events
        //*************************************************************************

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdRNBrowse_click
        //
        // Browse the Robot Neighborhood
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdRNBrowse_Click(object sender, EventArgs e)
        {
            object objBrowseStart = null;
            FRCRNRobot objRNRobot;
            FRURNSelect FRURNSelect;

            try
            {
                rbFromRN.Checked = true;

                if(FRRobotDemo == null)
                {
                    FRRobotDemo = new FRRobotDemo();
                }

                // Get access to the neighborhood
                if (FRRobotDemo.gobjRobotNeighborhood == null)
                {
                    FRRobotDemo.gobjRobotNeighborhood = new FRCRobotNeighborhood();
                }

                // Use the entry in txtRNPath as the starting point
                // in the Robot Neighborhood.
                // If none yet, pick the root of the Neighborhood
                try
                {
                    objBrowseStart = FRRobotDemo.gobjRobotNeighborhood.Robots.Item[txtRNPath.Text, -1];
                }
                catch (Exception ex)
                {
                    objBrowseStart = FRRobotDemo.gobjRobotNeighborhood.Robots;
                    MessageBox.Show(ex.Message, "cmdRNBrowse_Click1");
                }
                finally
                {
                    objBrowseStart = FRRobotDemo.gobjRobotNeighborhood.Robots.Item[txtRNPath.Text, -1];
                }

                FRURNSelect = new FRURNSelect();

                // Allow only robot selections in the browser
                FRURNSelect.AllowFRCRNRobots = false;
                FRURNSelect.AllowFRCRNRealRobot = true;
                FRURNSelect.AllowFRCRNVirtualRobot = true;

                // Set the caption for this
                FRURNSelect.Caption = "Select a Real or Virtual robot to connect";

                // Show the browser and let it do its thing
                objRNRobot = FRURNSelect.ShowSelect(ref objBrowseStart);
                if (objRNRobot != null)
                {
                    txtRNPath.Text = objRNRobot.PathName;
                    SetConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cmdRNBrowse_Click");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdCancel_Click
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            mstrHostName = string.Empty;
            mstrRNPath = string.Empty;
            this.Hide();
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdConnect_Click
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdConnect_Click(object sender, EventArgs e)
        {
            string IP;
            //connection by IP address
            if(rbByHostName.Checked)
            {
                IPAddress valid;
                IP = Registry.GetSetting("FRRobotDemo", "MRU", "LastHostNameSelection", string.Empty);

                if(!IPAddress.TryParse(txtHostName.Text, out valid))
                {
                    MessageBox.Show("Invalid IP address");
                    return;
                }
                else if (frmFRRobotDemo.mobjRobot != null)
                {
                    if (frmFRRobotDemo.mobjRobot.IsConnected && txtHostName.Text.Equals(IP))
                    {
                        MessageBox.Show("Already connected to: " + IP, "Existing Connection");
                        return;
                    }
                }
            }
            
            //connection by Robot neighborhood
            else
            {
                IP = Registry.GetSetting("FRRobotDemo", "MRU", "LastRNSelection", string.Empty);
                if (txtRNPath.Text.Length < 20)
                {
                    MessageBox.Show("Please choose correct path");
                    return;
                }
                else if (txtRNPath.Text.Equals(IP) && frmFRRobotDemo.mobjRobot != null)
                {
                    MessageBox.Show("Already connected to: " + IP, "Existing Connection");
                    return;
                }
            }
            SetConnection();
        }
        
        private void txtHostName_Enter(object sender, EventArgs e)
        {
            rbByHostName.Checked = true;
        }

        private void txtHostName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                SetConnection();
            }
        }

        private void txtRNPath_Enter(object sender, EventArgs e)
        {
            rbFromRN.Checked = true;
        }

        private void txtRNPath_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                SetConnection();
            }
        }

        private void frmConnect_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Escape))
                cmdCancel_Click(this, new EventArgs());
            else if (e.KeyChar.Equals((char)Keys.Enter))
                cmdConnect_Click(this, new EventArgs());
        }

        #endregion

        #region "Utility Routines"

        //*************************************************************************
        //                        Utility Routines
        //*************************************************************************
        private void SetConnection()
        {
            try
            {
                if (rbByHostName.Checked)
                {
                    // Host Name specified
                    mstrRNPath = string.Empty;
                    mstrHostName = txtHostName.Text;
                    Registry.SaveSetting("FRRobotDemo", "MRU", "LastHostNameSelection", mstrHostName);
                    Registry.SaveSetting("FRRobotDemo", "MRU", "LastSelectionMethod", "0");
                }
                else
                {
                    mstrHostName = string.Empty;
                    mstrRNPath = txtRNPath.Text;
                    Registry.SaveSetting("FRRobotDemo", "MRU", "LastRNSelection", mstrRNPath);
                    Registry.SaveSetting("FRRobotDemo", "MRU", "LastSelectionMethod", "1");
                }
                if (frmFRRobotDemo == null || frmFRRobotDemo.IsDisposed)
                {
                    frmFRRobotDemo = new frmFRRobotDemo();
                }

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SetConnection");
            }
        }

        #endregion

    }
}