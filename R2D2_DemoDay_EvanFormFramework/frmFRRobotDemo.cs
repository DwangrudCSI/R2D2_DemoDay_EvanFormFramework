// Module: frmFRRobotDemo
//
// Description:
//    MDI form to encapsulate the child forms to demonstarate Robot Server features
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
using System.Collections.Specialized;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using FRRobotDemoCSharp;

namespace FRRobotDemoCSharp
{
    public partial class frmFRRobotDemo : Form
    {

        #region "Declarations"

        //*************************************************************************
        //                           Declarations
        //*************************************************************************
        private FRCRNRobot mobjRNRobot;
        public static FRCRobot mobjRobot;
        private string mstrRNPath = string.Empty,
            mstrHostName = string.Empty;
        private bool mblnUpdateConnect;


        FRRobotDemo FRRobotDemo;
        frmConnect frmConnect;
        frmSysVars frmSysVars;
        frmEvents frmEvents;
        frmAlarms frmAlarms;
        frmStrReg frmStrReg;
        frmPickPlace frmPickPlace;
        frmPosReg frmPosReg;
        frmFrames frmFrames;
        frmCurPos frmCurPos;
        
        frmIO frmIO;
        frmFeatures frmFeatures;
        frmNumReg frmNumReg;
        frmFTP frmFTP;

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
        public frmFRRobotDemo()
        {
            InitializeComponent();

            if (FRRobotDemo == null)
            {
                FRRobotDemo = new FRRobotDemo();
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: frmFRRobotDemo_Load
        //
        // Use a simple input box to get the host name from the user.
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void frmFRRobotDemo_Load(object sender, EventArgs e)
        {
            FRRobotDemo.gobjMDIParent = this;
            FRRobotDemo.gobjRobot = null;
            FRRobotDemo.gobjIndPositions = null;
            mobjRobot = null;

            // Set the Window size
            //this.Height = int.Parse(Registry.GetSetting("FRRobotDemo", "Settings", "frmFRRobotDemoHeight", "600"));
            //if (this.Height <= 200)
            //    this.Height = 200;
            //this.Width = int.Parse(Registry.GetSetting("FRRobotDemo", "Settings", "frmFRRobotDemoWidth", "700"));
            //if (this.Width <= 200)
            //    this.Width = 200;

            this.WindowState = FormWindowState.Maximized;
            
            mstrRNPath = string.Empty;
            mstrHostName = string.Empty;

            if (Environment.GetCommandLineArgs().Length > 0)
            {
                // Accept two forms of kinds of arguments on the command line
                // /N 'RNPath'
                // /H 'HostName'
                if (Environment.GetCommandLineArgs().GetValue(0).ToString().ToUpper().Equals("/N"))
                {
                    mstrRNPath = Environment.GetCommandLineArgs().GetValue(1).ToString();
                }
                else if (Environment.GetCommandLineArgs().GetValue(0).ToString().ToUpper().Equals("/H"))
                {
                    mstrHostName = Environment.GetCommandLineArgs().GetValue(1).ToString();
                }
            }

            if (string.IsNullOrEmpty(mstrHostName) && string.IsNullOrEmpty(mstrRNPath))
            {
                // Nothing selected on the command line
                // Let the operator select.
                this.Text = R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_APP_NAME;
                //this.Show();
                if (frmConnect == null || frmConnect.IsDisposed)
                {
                    frmConnect = new frmConnect();
                    frmConnect.ShowDialog();
                    mstrRNPath = frmConnect.RNPath;
                    mstrHostName = frmConnect.HostName;
                    frmConnect.Close();
                }
            }

            // Start the connection process
            InitiateConnection();
        }

        private void frmFRRobotDemo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mobjRNRobot != null)
                mobjRNRobot.OnConnectionStatusChange -= mobjRNRobot_OnConnectionStatusChange;

            if (mobjRobot != null)
            {
                mobjRobot.Disconnect -= mobjRobot_Disconnect;
                mobjRobot.Error -= mobjRobot_Error;
            }

            if (this.Top > 0)
            {
                // Not minimized, save settings
                Registry.SaveSetting("FRRobotDemo", "Settings", "MDIFormHeight", this.Height.ToString());
                Registry.SaveSetting("FRRobotDemo", "Settings", "MDIFormWidth", this.Width.ToString());
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: tmrPing_Timer
        //
        // Do all the pinging in this timer routine so that the user can wait
        // forever if he wishes or cancel out later
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void tmrPing_Tick(object sender, EventArgs e)
        {
            tmrPing.Enabled = false;

            if (mstrHostName.Length == 0)
            {
                this.Text = "FRRobotDemo - Nothing Connected";
                return;
            }

            try
            {
                Ping ping = new Ping();
                PingReply reply;
                reply = ping.Send(mstrHostName);

                if (reply.Status == IPStatus.Success)
                {
                    try
                    {
                        // The Robot Object will do all the error checking for us
                        this.Text = R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_APP_NAME + mstrHostName + "  [" + R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_CONNECTING + "]";
                        if (FRRobotDemo.gobjRobot != null)
                            if (FRRobotDemo.gobjRobot.IsConnected)
                                mobjRobot_Disconnect();
                        if (FRRobotDemo.gobjRobot == null)
                        {
                            FRRobotDemo.gobjRobot = new FRCRobot();
                            mobjRobot = FRRobotDemo.gobjRobot;
                            //unsubscribe event if already subscribed
                            mobjRobot.Disconnect -= mobjRobot_Disconnect;
                            mobjRobot.Error -= mobjRobot_Error;
                            //subscribe event handlers
                            mobjRobot.Disconnect += mobjRobot_Disconnect;
                            mobjRobot.Error += mobjRobot_Error;
                            FRRobotDemo.gobjIndPositions = new OrderedDictionary();
                            mobjRobot_Connect();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "tmrPing_Tick1");
                        mobjRobot = null;
                        FRRobotDemo.gobjRobot = null;
                        FRRobotDemo.gobjIndPositions = null;
                    }
                }
            }
            catch (Exception ex)
            {
                tmrPing.Enabled = true;
                tmrPing.Interval = 1000;
                MessageBox.Show(ex.Message, "tmrPing_Tick");
            }
        }

        #endregion

        #region "User Input Events"

        //*************************************************************************
        //                        User Input Events
        //*************************************************************************

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: Menu selection routines
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void mnuSelectNew_Click(object sender, EventArgs e)
        {
            mblnUpdateConnect = false;
            tmrPing.Enabled = false;

            if (frmConnect == null || frmConnect.IsDisposed)
                frmConnect = new frmConnect();

            frmConnect.ShowDialog();

            if (string.IsNullOrEmpty(frmConnect.RNPath) & string.IsNullOrEmpty(frmConnect.HostName))
            {
                // The user canceled
                frmConnect.Close();
                return;
            }

            // Something was selected
            mstrRNPath = frmConnect.RNPath;
            mstrHostName = frmConnect.HostName;
            frmConnect.Close();

            // Terminate any remnants of a previous connection
            mnuComponents.Enabled = false;
            while (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }

            mobjRobot = null;
            FRRobotDemo.gobjRobot = null;
            mobjRNRobot = null;
            FRRobotDemo.gobjIndPositions = null;
            for (int i = 1; i <= 3; i++)
            {
                //GC.Collect();
                Application.DoEvents();
            }

            // Start the connections
            InitiateConnection();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        //private void AlarmsToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (frmAlarms == null || frmAlarms.IsDisposed)
        //    {
        //        frmAlarms = new frmAlarms();
        //        frmAlarms.MdiParent = this;
        //        frmAlarms.Show();
        //        frmAlarms.Activate();
        //    }
        //}

        //private void CurrentPositionToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (frmCurPos == null || frmCurPos.IsDisposed)
        //    {
        //        frmCurPos = new frmCurPos();
        //        frmCurPos.MdiParent = this;
        //        frmCurPos.Show();
        //        frmCurPos.Activate();
        //    }
        //}

        //private void EventsToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (frmEvents == null || frmEvents.IsDisposed)
        //    {
        //        frmEvents = new frmEvents();
        //        frmEvents.MdiParent = this;
        //        frmEvents.Show();
        //        frmEvents.Activate();
        //    }
        //}

        //private void FeaturesToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (frmFeatures == null || frmFeatures.IsDisposed)
        //    {
        //        frmFeatures = new frmFeatures();
        //        frmFeatures.MdiParent = this;
        //        frmFeatures.Show();
        //        frmFeatures.Activate();
        //    }
        //}

        //private void IndependentPosToolStripMenuItem1_Click(object sender, EventArgs e)
        //{
        //    if (frmIndependentPos == null || frmIndependentPos.IsDisposed)
        //    {
        //        frmIndependentPos = new frmIndependentPos();
        //        frmIndependentPos.MdiParent = this;
        //        frmIndependentPos.Show();
        //        frmIndependentPos.Activate();
        //    }
        //}

        //private void IOToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (frmIO == null || frmIO.IsDisposed)
        //    {
        //        frmIO = new frmIO();
        //        frmIO.MdiParent = this;
        //        frmIO.Show();
        //        frmIO.Activate();
        //    }
        //}

        //private void numericRegistersToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (frmNumReg == null || frmNumReg.IsDisposed)
        //    {
        //        frmNumReg = new frmNumReg();
        //        frmNumReg.MdiParent = this;
        //        frmNumReg.Show();
        //        frmNumReg.Activate();
        //    }
        //}

        //private void PacketEventsToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (frmPacketEvents == null || frmPacketEvents.IsDisposed)
        //    {
        //        frmPacketEvents = new frmPacketEvents();
        //        frmPacketEvents.MdiParent = this;
        //        frmPacketEvents.Show();
        //        frmPacketEvents.Activate();
        //    }
        //}

        //private void PipesToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (frmPipes == null || frmPipes.IsDisposed)
        //    {
        //        frmPipes = new frmPipes();
        //        frmPipes.MdiParent = this;
        //        frmPipes.Show();
        //        frmPipes.Activate();
        //    }
        //}

        //private void PositionRegistersToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (frmPosReg == null || frmPosReg.IsDisposed)
        //    {
        //        frmPosReg = new frmPosReg();
        //        frmPosReg.MdiParent = this;
        //        frmPosReg.Show();
        //        frmPosReg.Activate();
        //    }
        //}

        //private void ProgramVariablesToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (frmVars == null || frmVars.IsDisposed)
        //    {
        //        frmVars = new frmVars();
        //        frmVars.MdiParent = this;
        //        frmVars.Show();
        //        frmVars.Activate();
        //    }
        //}

        //private void ProgramsToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (frmPrograms == null || frmPrograms.IsDisposed)
        //    {
        //        frmPrograms = new frmPrograms();
        //        frmPrograms.MdiParent = this;
        //        frmPrograms.Show();
        //        frmPrograms.Activate();
        //    }
        //}

        //private void mnuScatteredAccess_Click(object sender, EventArgs e)
        //{
        //    if (frmScattAccess == null || frmScattAccess.IsDisposed)
        //    {
        //        frmScattAccess = new frmScattAccess();
        //        frmScattAccess.MdiParent = this;
        //        frmScattAccess.Show();
        //        frmScattAccess.Activate();
        //    }
        //}

        //private void SetupToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (frmSetup == null || frmSetup.IsDisposed)
        //    {
        //        frmSetup = new frmSetup();
        //        frmSetup.MdiParent = this;
        //        frmSetup.Show();
        //        frmSetup.Activate();
        //    }
        //}

        //private void StringRegistersToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (frmStrReg == null || frmStrReg.IsDisposed)
        //    {
        //        frmStrReg = new frmStrReg();
        //        frmStrReg.MdiParent = this;
        //        frmStrReg.Show();
        //        frmStrReg.Activate();
        //    }
        //}

        //private void SystemFramesToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (frmFrames == null || frmFrames.IsDisposed)
        //    {
        //        frmFrames = new frmFrames();
        //        frmFrames.MdiParent = this;
        //        frmFrames.Show();
        //        frmFrames.Activate();
        //    }
        //}

        //private void SystemInformationToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (frmSysInfo == null || frmSysInfo.IsDisposed)
        //    {
        //        frmSysInfo = new frmSysInfo();
        //        frmSysInfo.MdiParent = this;
        //        frmSysInfo.Show();
        //        frmSysInfo.Activate();
        //    }
        //}

        //private void mnuSysVars_Click(object sender, EventArgs e)
        //{
        //    if (frmSysVars == null || frmSysVars.IsDisposed)
        //    {
        //        frmSysVars = new frmSysVars();
        //        frmSysVars.MdiParent = this;
        //        frmSysVars.Show();
        //        frmSysVars.Activate();
        //    }
        //}

        //private void TasksToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (frmTasks == null || frmTasks.IsDisposed)
        //    {
        //        frmTasks = new frmTasks();
        //        frmTasks.MdiParent = this;
        //        frmTasks.Show();
        //        frmTasks.Activate();
        //    }
        //}

        //private void VariablesToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (frmVars == null || frmVars.IsDisposed)
        //    {
        //        frmVars = new frmVars();
        //        frmVars.MdiParent = this;
        //        frmVars.Show();
        //        frmVars.Activate();
        //    }
        //}

        //private void fTPToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (frmFTP == null || frmFTP.IsDisposed)
        //    {
        //        frmFTP = new frmFTP();
        //        frmFTP.MdiParent = this;
        //        frmFTP.Show();
        //        frmFTP.Activate();
        //    }
        //}

        #endregion

        #region "Robot Server Events"

        //*************************************************************************
        //                        Robot Server Events
        //*************************************************************************

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: mobjRNRobot_OnConnectionStatusChange
        //
        // Handle all connection changes here
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private delegate void OnConnectionStatusChangeDelegate(FRRobotNeighborhood.FRERNConnectionStatusConstants NewStatus);
        private void mobjRNRobot_OnConnectionStatusChange(FRERNConnectionStatusConstants NewStatus)
        {
            // Surprisingly, the mobjRNRobot_OnConnectionStatusChange event can be
            // called before the Set mobjRNRobot statement is completed. Go figure.
            // Nothing to do but exit
            if (mobjRNRobot == null)
                return;

            if (this.InvokeRequired)
            {
                OnConnectionStatusChangeDelegate HandleOnConnectionStatusChange = new OnConnectionStatusChangeDelegate(mobjRNRobot_OnConnectionStatusChange);
                this.BeginInvoke(HandleOnConnectionStatusChange, NewStatus);
            }
            else
            {
                this.Text = R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_APP_NAME + mobjRNRobot.PathName;

                switch (NewStatus)
                {
                    case FRRobotNeighborhood.FRERNConnectionStatusConstants.frRNConnected:
                        this.Text = this.Text + "  [" + R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_CONNECTED + "]";
                        break;
                    case FRRobotNeighborhood.FRERNConnectionStatusConstants.frRNConnecting:
                        this.Text = this.Text + "  [" + R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_CONNECTING + "]";
                        break;
                    case FRRobotNeighborhood.FRERNConnectionStatusConstants.frRNAvailable:
                        if (mobjRNRobot.Services.Item[FRRobotNeighborhood.FRERNServiceIDConstants.frRNRPCMainServiceID].State == FRRobotNeighborhood.FRERNServiceStateConstants.frRNServiceStateStopped)
                        {
                            this.Text = this.Text + "  [" + R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_PCIF_NOT_INSTALLED + "]";
                        }
                        else
                        {
                            this.Text = this.Text + "  [" + R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_AVAILABLE + "]";
                        }
                        break;
                    case FRRobotNeighborhood.FRERNConnectionStatusConstants.frRNUnavailable:
                        this.Text = this.Text + "  [" + R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_UNAVAILABLE + "]";
                        break;
                    case FRRobotNeighborhood.FRERNConnectionStatusConstants.frRNHeartbeatLost:
                        this.Text = this.Text + "  [" + R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_HEARTBEAT_LOST + "]";
                        break;
                    case FRRobotNeighborhood.FRERNConnectionStatusConstants.frRNDisconnecting:
                        this.Text = this.Text + "  [" + R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_DISCONNECTING + "]";
                        break;
                    case FRRobotNeighborhood.FRERNConnectionStatusConstants.frRNUnknown:
                        this.Text = this.Text + "  [" + R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_UNKNOWN + "]";
                        break;
                }

                switch (NewStatus)
                {
                    case FRRobotNeighborhood.FRERNConnectionStatusConstants.frRNConnected:
                        // Do initialization work
                        mnuComponents.Enabled = true;
                        break;
                    default:
                        if (mnuComponents.Enabled)
                        {
                            // We were connected but now we're not.
                            // Disable the menus and close open windows
                            mnuComponents.Enabled = false;
                            while (this.ActiveMdiChild != null)
                            {
                                this.ActiveMdiChild.Close();
                            }
                        }
                        break;
                }
            }
            // Invoke or not
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: mobjRobot Events.
        //
        // mobjRobot will be set when the RobotNeighborhood is not involved
        // Use these events to detect the robot connection status
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        public delegate void RobotConnectDelegate();
        public void mobjRobot_Connect()
        {
            if (this.InvokeRequired)
            {
                RobotConnectDelegate HandleOnMainThread = new RobotConnectDelegate(mobjRobot_Connect);
                this.BeginInvoke(HandleOnMainThread);
            }
            else
            {
                mobjRobot = null;
                mobjRobot = FRRobotDemo.gobjRobot; //work off one reference object

                if (mobjRobot == null)
                    mobjRobot = new FRCRobot();
                try
                {
                    mobjRobot.ConnectEx(mstrHostName, true, 0, 2);
                }
                catch
                {
                    return;
                }
                new System.Threading.Thread(() =>
                {
                    mblnUpdateConnect = true;
                    //wait until connected
                    while (!mobjRobot.IsConnected)
                    {
                        if (!mblnUpdateConnect)
                            break;
                    }
                    if(!mblnUpdateConnect)
                        FRRobotDemo.gobjRobot = null;
                    else
                        UpdateConnect();
                }).Start();
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: UpdateConnect
        //
        // Update robot connection status
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        public delegate void DelegateUpdateConnect();
        private void UpdateConnect()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new DelegateUpdateConnect(UpdateConnect));
                return;
            }
            this.Text = R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_APP_NAME + mstrHostName + "  [" + R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_CONNECTED + "]";
            mnuComponents.Enabled = true;
        } 


        private delegate void RobotDisconnectDelegate();
        private void mobjRobot_Disconnect()
        {
            if (this.InvokeRequired)
            {
                RobotDisconnectDelegate HandleOnMainThread = new RobotDisconnectDelegate(mobjRobot_Disconnect);
                this.BeginInvoke(HandleOnMainThread);
            }
            else
            {
                this.Text = R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_APP_NAME + mstrHostName + "  [" + R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_DISCONNECTED + "]";
                mnuComponents.Enabled = false;
                while (this.ActiveMdiChild != null)
                {
                    this.ActiveMdiChild.Hide();
                }
                mobjRobot = null;
            }
        }

        private delegate void RobotErrorDelegate(FRCRobotErrorInfo RobotError);
        private void mobjRobot_Error(FRCRobotErrorInfo RobotError)
        {
            if (this.InvokeRequired)
            {
                RobotErrorDelegate HandleOnMainThread = new RobotErrorDelegate(mobjRobot_Error);
                this.BeginInvoke(HandleOnMainThread, RobotError);
            }
            else
            {
                // (frPCIFNotLoaded And &HFFFF)
                if (RobotError.Number == 15)
                {
                    this.Text = R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_APP_NAME + mstrHostName + "  [" + R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_PCIF_NOT_INSTALLED + "]";
                    mnuComponents.Enabled = false;
                    while (this.ActiveMdiChild != null)
                    {
                        this.ActiveMdiChild.Hide();
                    }
                    mobjRobot = null;
                    // (frRobotConnectionFailed And &HFFFF)
                }
                else if (RobotError.Number == 24)
                {
                    this.Text = R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_APP_NAME + mstrHostName + "  [" + R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_CONNECTION_FAILED + "]";
                    mnuComponents.Enabled = false;
                    while (this.ActiveMdiChild != null)
                    {
                        this.ActiveMdiChild.Hide();
                    }
                    mobjRobot = null;
                }
                else
                {
                    MessageBox.Show("Unknown Robot Error: " + RobotError.Number + "\r\n" + RobotError.Description);
                }
            }
        }

        #endregion

        #region "Utility Routines"

        //*************************************************************************
        //                        Utility Routines
        //*************************************************************************

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: InitiateConnection
        //
        // Start the connection process
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void InitiateConnection()
        {
            try
            {
                if (!string.IsNullOrEmpty(mstrRNPath))
                {
                    // Use the Robot Neighborhood to connect
                    FRRobotDemo.gobjRobotNeighborhood = null;
                    if (FRRobotDemo.gobjRobotNeighborhood == null)
                    {
                        FRRobotDemo.gobjRobotNeighborhood = new FRCRobotNeighborhood();
                    }
                    mobjRNRobot = FRRobotDemo.gobjRobotNeighborhood.Robots.Item[mstrRNPath, -1];
                    mobjRNRobot.OnConnectionStatusChange += mobjRNRobot_OnConnectionStatusChange;
                    FRRobotDemo.gobjRobot = mobjRNRobot.RobotServer;
                    FRRobotDemo.gobjIndPositions = new OrderedDictionary();
                    mobjRNRobot_OnConnectionStatusChange(mobjRNRobot.ConnectionStatus);
                }
                else if (!string.IsNullOrEmpty(mstrHostName))
                {
                    // Use the Robot Server directly to connect
                    mnuComponents.Enabled = false;
                    this.Text = R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_APP_NAME + mstrHostName + "  [" + R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_PINGING + "]";
                    tmrPing.Interval = 20;
                    tmrPing.Enabled = true;
                }
                else
                {
                    // Nothings selected. Just hang
                    this.Text = R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_APP_NAME + R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_NOTHING_CONNECTED;
                    mnuComponents.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                this.Text = R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_APP_NAME + R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_NOTHING_CONNECTED;
                mnuComponents.Enabled = false;
                mobjRobot = null;
                FRRobotDemo.gobjRobot = null;
                mobjRNRobot = null;
                FRRobotDemo.gobjIndPositions = null;

                //GC.Collect();
                MessageBox.Show(ex.Message, "InitiateConnection");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: SetText
        //
        // Use this to set the Text property of any component 
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private delegate void SetTextDelegate(Form theFormComponent, string newText);

        private void mnuComponents_Click(object sender, EventArgs e)
        {
            
        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
             //Main Tab
            if (tabControl1.SelectedIndex == 0)
            {
                if (frmPickPlace == null || frmPickPlace.IsDisposed)
                {
                    frmPickPlace = new frmPickPlace();
                    frmPickPlace.MdiParent = this;
                    frmPickPlace.Show();
                    frmPickPlace.Activate();
                }
                else
                {
                    frmPickPlace.Show();
                }
                frmPickPlace.Dock = DockStyle.Fill;
                frmPickPlace.Location = new System.Drawing.Point(0, 0);
                frmPickPlace.WindowState = FormWindowState.Normal;
                frmPickPlace.BringToFront();
                frmPickPlace.TopMost = true;
                frmPickPlace.Focus();
            }
        
        //IO Tab
         if (tabControl1.SelectedIndex == 1)
            {
                if (frmIO == null || frmIO.IsDisposed)
                {
                    frmIO = new frmIO();
                    frmIO.MdiParent = this;
                    frmIO.Show();
                    frmIO.Activate();
                }
                else
                {
                    frmIO.Show();
                }
                frmIO.Dock = DockStyle.Fill; 
                frmIO.Location = new System.Drawing.Point(0, 0);
                frmIO.WindowState = FormWindowState.Normal;
                frmIO.BringToFront();
                frmIO.TopMost = true;
                frmIO.Focus();
            }
        
        // FTP Tab
            if (tabControl1.SelectedIndex == 2)
            {
                if (frmFTP == null || frmFTP.IsDisposed)
                {
                    frmFTP = new frmFTP();
                    frmFTP.MdiParent = this;
                    frmFTP.Show();
                    frmFTP.Activate();
                }
                else
                {
                    frmFTP.Show();
                }
                frmFTP.Dock = DockStyle.Fill;
                frmFTP.Location = new System.Drawing.Point(0,0);
                frmFTP.WindowState = FormWindowState.Normal;
                frmFTP.BringToFront();
                frmFTP.TopMost = true;
                frmFTP.Focus();
            }
            //Cur Position Tab
            if (tabControl1.SelectedIndex == 3)
            {
                if (frmCurPos == null || frmCurPos.IsDisposed)
                {
                    frmCurPos = new frmCurPos();
                    frmCurPos.MdiParent = this;
                    frmCurPos.Show();
                    frmCurPos.Activate();
                }
                else
                {
                    frmCurPos.Show();
                }
                frmCurPos.Dock = DockStyle.Fill;
                frmCurPos.Location = new System.Drawing.Point(0, 0);
                frmCurPos.WindowState = FormWindowState.Normal;
                frmCurPos.BringToFront();
                frmCurPos.TopMost = true;
                frmCurPos.Focus();
            }

            //Features Tab
            if (tabControl1.SelectedIndex == 4)
            {
                if (frmFeatures == null || frmFeatures.IsDisposed)
                {
                    frmFeatures = new frmFeatures();
                    frmFeatures.MdiParent = this;
                    frmFeatures.Show();
                    frmFeatures.Activate();
                }
                else
                {
                    frmFeatures.Show();
                }
                frmFeatures.Dock = DockStyle.Fill;
                frmFeatures.Location = new System.Drawing.Point(0, 0);
                frmFeatures.WindowState = FormWindowState.Normal;
                frmFeatures.BringToFront();
                frmFeatures.TopMost = true;
                frmFeatures.Focus();
            }
            //Num Regs Tab
            if (tabControl1.SelectedIndex == 5)
            {
                if (frmNumReg == null || frmNumReg.IsDisposed)
                {
                    frmNumReg = new frmNumReg();
                    frmNumReg.MdiParent = this;
                    frmNumReg.Show();
                    frmNumReg.Activate();
                }
                else
                {
                    frmNumReg.Show();
                }
                frmNumReg.Dock = DockStyle.Fill;
                frmNumReg.Location = new System.Drawing.Point(0, 0);
                frmNumReg.WindowState = FormWindowState.Normal;
                frmNumReg.BringToFront();
                frmNumReg.TopMost = true;
                frmNumReg.Focus();
            }
            //String Regs Tab
            if (tabControl1.SelectedIndex == 6)
            {
                if (frmStrReg == null || frmStrReg.IsDisposed)
                {
                    frmStrReg = new frmStrReg();
                    frmStrReg.MdiParent = this;
                    frmStrReg.Show();
                    frmStrReg.Activate();
                }
                else
                {
                    frmStrReg.Show();
                }
                frmStrReg.Dock = DockStyle.Fill;
                frmStrReg.Location = new System.Drawing.Point(0, 0);
                frmStrReg.WindowState = FormWindowState.Normal;
                frmStrReg.BringToFront();
                frmStrReg.TopMost = true;
                frmStrReg.Focus();
            }
            //Position Regs Tab
            if (tabControl1.SelectedIndex == 7)
            {
                if (frmPosReg == null || frmPosReg.IsDisposed)
                {
                    frmPosReg = new frmPosReg();
                    frmPosReg.MdiParent = this;
                    frmPosReg.Show();
                    frmPosReg.Activate();
                }
                else
                {
                    frmPosReg.Show();
                }
                frmPosReg.Dock = DockStyle.Fill;
                frmPosReg.Location = new System.Drawing.Point(0, 0);
                frmPosReg.WindowState = FormWindowState.Normal;
                frmPosReg.BringToFront();
                frmPosReg.TopMost = true;
                frmPosReg.Focus();
            }
            //System Frames Tab
            if (tabControl1.SelectedIndex == 8)
            {
                if (frmFrames == null || frmFrames.IsDisposed)
                {
                    frmFrames = new frmFrames();
                    frmFrames.MdiParent = this;
                    frmFrames.Show();
                    frmFrames.Activate();
                }
                else
                {
                    frmFrames.Show();
                }
                frmFrames.Dock = DockStyle.Fill;
                frmFrames.Location = new System.Drawing.Point(0, 0);
                frmFrames.WindowState = FormWindowState.Normal;
                frmFrames.BringToFront();
                frmFrames.TopMost = true;
                frmFrames.Focus();
            }
            //System Variables Tab
            if (tabControl1.SelectedIndex == 9)
            {
                if (frmSysVars == null || frmSysVars.IsDisposed)
                {
                    frmSysVars = new frmSysVars();
                    frmSysVars.MdiParent = this;
                    frmSysVars.Show();
                    frmSysVars.Activate();
                }
                else
                {
                    frmSysVars.Show();
                }
                frmSysVars.Dock = DockStyle.Fill;
                frmSysVars.Location = new System.Drawing.Point(0, 0);
                frmSysVars.WindowState = FormWindowState.Normal;
                frmSysVars.BringToFront();
                frmSysVars.TopMost = true;
                frmSysVars.Focus();
            }
            //Alarm Tab
            if (tabControl1.SelectedIndex == 10)
            {
                if (frmAlarms == null || frmAlarms.IsDisposed)
                {
                    frmAlarms = new frmAlarms();
                    frmAlarms.MdiParent = this;

                    frmAlarms.Show();
                    frmAlarms.Activate();
                }
                else
                {
                    frmAlarms.Show();
                }
                frmAlarms.Dock = DockStyle.Fill;
                frmAlarms.Location = new System.Drawing.Point(0, 0);
                frmAlarms.WindowState = FormWindowState.Normal;
                frmAlarms.BringToFront();
                frmAlarms.TopMost = true;
                frmAlarms.Focus();
            }
        }
        
        private void SetText(Form theFormComponent, string newText)
        {
            if (this.InvokeRequired)
            {
                SetTextDelegate HandleSetText = new SetTextDelegate(SetText);
                this.BeginInvoke(HandleSetText, theFormComponent, newText);
            }
            else
            {
                theFormComponent.Text = newText;
            }
        }

        #endregion

    }
}