// Module: frmFTP
//
// Description:
//   Upload files to robot and make all files backup
//
// Author: Tri Quach
//         FANUC America Corporation 
//         29700 Kohoutek Way
//         Union City, CA 94587
//
// Modification history:
// 26-Jan-2016 Quach        Initial Creation
// 31-Jan-2016 Wunderlich   Changed from COM to .NET
// 07-Feb-2016 Quach        Added multiple items selection for FTP

using FRRobot;
using FANUC.Net.Ftp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using System.IO;
using System.Diagnostics;

namespace FRRobotDemoCSharp
{
    public partial class frmFTP : Form
    {

        #region "Declarations"

        //*************************************************************************
        //                           Declarations
        //*************************************************************************
        private FSFtp FTP;
        private FRCPrograms mobjPrograms;
        private List<string> mobjSelectedNodes = new List<string>();
        //master filter list
        private List<string> mobjFilterList = new List<string>()
        {
            "All Files (*.*)|*.*|",
            "KAREL Source (*.KL)|*.KL|",
            "Command Files (*.CF)|*.CF|",
            "Text Files (*.TX)|*.TX|",
            "KAREL listings (*.LS)|*.LS|",
            "KAREL data files (*.DT)|*.DT|",
            "KAREL p-code (*.PC)|*.PC|",
            "TP Programs (*.TP)|*.TP|",
            "MN Programs (*.MN)|*.MN|",
            "Variable Files (*.VR)|*.VR|",
            "System Files (*.SV)|*.SV|",
            "I/O Config Data (*.IO)|*.IO|",
            "DEFAULT Files (*.DF)|*.DF|",
            "Part Model Files (*.ML)|*.ML|",
            "Bit-map images (*.BMP)|*.BMP|",
            "PMC Files (*.PMC)|*.PMC|",
            "Variable Listings (*.VA)|*.VA|",
            "Diagnostic Files (*.DG)|*.DG|",
            "Vision VD Files (*.VD)|*.VD|",
            "IBG Files (*.IBG)|*.IBG|",
            "IBA Files (*.IBA)|*.IBA|",
            "IMG Files (*.IMG)|*.IMG|",
            "HTM Files (*.HTM)|*.HTM|",
            "STM Files (*.STM)|*.STM|",
            "GIF Files (*.GIF)|*.GIF|",
            "JPG Files (*.JPG)|*.JPG|",
            "XML Files (*.XML)|*.XML"
        };
        private TreeNode mobjFirstNode,
            mobjLastNode;
        private string mstrProgramName;
        private bool mblnFoundFile,
            mblnGotCreateEvent,
            mblnGotRefreshVarsEvent,
            mblnGotFinalRefreshVarsEvent,
            mblnRefresh,
            mblnUpdateFTP,
            mblnBusy,
            mblnCtrl,
            mblnShft,
            mblnFilterSelected;
        //choose your highlighting color here
        Color Highlight = Color.LightBlue;
        int intNodeIdxStrt,
            intNodeIdxEnd;
        // Delay constants
        const int LOAD_DELAY = 35000; // Allow for network hangups

        const string CURRENT_DIRECTORY = ".",
            PARENT_DIRECTORY = ".";
        const char DELIMITER = ';';
        private static readonly string LIST_DELIMITER = DELIMITER.ToString();

        /// <summary>
        /// Item to exclude on all FTP operations
        /// </summary>
        private static readonly List<string> ExcludedItems = new List<string>() 
        {
            CURRENT_DIRECTORY,
            CURRENT_DIRECTORY,
            //"RD:",
        };

        FRRobotDemo FRRobotDemo;

        #endregion

        #region "Public Properties and Methods"

        //*************************************************************************
        //                      Public Properties and Methods
        //*************************************************************************

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
        public frmFTP()
        {
            InitializeComponent();
            if (FRRobotDemo == null)
                FRRobotDemo = new FRRobotDemo();
            //set min/max size
            this.MinimumSize = this.Size;
        }


        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: frmFTP_Load
        //
        // show hostname
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void frmFTP_Load(object sender, EventArgs e)
        {
            // initially get robot's hostname;
            // user can change later if needed;
            txtHostName.Text = HostName(FRRobotDemo.gobjRobot.SysInfo.Robot.HostName);
            
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: frmFTP_FormClosed
        //
        // Null all objects
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void frmFTP_FormClosed(object sender, FormClosedEventArgs e)
        {
            FTP = null;
            treeFTP = null;
            if (mobjPrograms != null)
            {
                mobjPrograms.Create -= mobjPrograms_Create;
                mobjPrograms.Refresh -= mobjPrograms_Refresh;
                mobjPrograms.RefreshVars -= mobjPrograms_RefreshVars;
            }
            mobjPrograms = null;
        }

        #endregion

        #region "User Input Events"

        //*************************************************************************
        //                        User Input Events
        //*************************************************************************

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: txtHostName_XXX
        //
        // handles hostname textbox input
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void txtHostName_Click(object sender, EventArgs e)
        {
            if (txtHostName.Text.Contains("127.0.0.1") || txtHostName.Text.Contains("localhost"))
                txtHostName.Text = string.Empty;
        }

        private void txtHostName_KeyUp(object sender, KeyEventArgs e)
        {
            txtHostName.ForeColor = Color.Black;
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                if (string.IsNullOrEmpty(txtHostName.Text))
                {
                    txtHostName.Text = "127.0.0.1";
                    txtHostName.ForeColor = Color.Gray;
                }
                else if (txtHostName.SelectionLength == 0)
                {
                    txtHostName.Text = "127.0.0.1";
                    txtHostName.ForeColor = Color.Gray;
                }
            }
        }

        private void txtHostName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtHostName.Text))
            {
                txtHostName.ForeColor = Color.Gray;
                txtHostName.Text = "127.0.0.1";
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: txtUserName_XXX
        //
        // handles username textbox input
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void txtUserName_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Contains("anonymous"))
                txtUserName.Text = string.Empty;
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            txtUserName.ForeColor = Color.Black;
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                if (string.IsNullOrEmpty(txtHostName.Text))
                {
                    txtUserName.Text = "anonymous";
                    txtUserName.ForeColor = Color.Gray;
                }
                else if (txtUserName.SelectionLength == 0)
                {
                    txtUserName.Text = "anonymous";
                    txtUserName.ForeColor = Color.Gray;
                }
            }
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                txtUserName.ForeColor = Color.Gray;
                txtUserName.Text = "anonymous";
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdConnect_Click
        //
        // Start FTP session with authentication
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdConnect_Click(object sender, EventArgs e)
        {
            try
            {
                treeFTP.Nodes.Clear();
                lstFilter.Items.Clear();

                if (FTP == null)
                    FTP = new FSFtp();
                if(cmdConnect.Text.Equals("Cancel"))
                {
                    mblnUpdateFTP = false;
                    cmdConnect.Text = "Login";
                    return;
                }
                bool disconnect = false;
                if (FTP.IsFtpConnected())
                {
                    disconnect = true;
                    FTP.Disconnect();
                    _lblStatic_9.Text = string.Format("Version: {0,10} {1,10}", "Mode:", "Type:");
                    this.Text = "FANUC FTP";
                    cmdConnect.Text = "Login";
                    cmdRefresh.Enabled = false;
                    cmdUpload.Enabled = false;
                    cmdBackup.Enabled = false;
                    cmdDelete.Enabled = false;
                    cmdCreateDir.Enabled = false;
                    cmdRemoveDir.Enabled = false;
                    cmdFind.Enabled = false;
                    cmdUpload.Enabled = false;
                    cmdLoad.Enabled = false;
                    chkWaitForLoad.Enabled = false;
                    transferFTP.Visible = false;
                    lblTransferFTP.Visible = false;
                    cmbRbtDir.Enabled = false;
                    lstFilter.Enabled = false;
                    txtHostName.Enabled = true;
                    txtUserName.Enabled = true;
                    txtPassword.Enabled = true;
                    txtPort.Enabled = true;
                }
                if(disconnect)
                {
                    FTP = null;
                    return;
                }
                cmdConnect.Text = "Cancel";
                this.Text = string.Format("FANUC FTP: Connecting...{0}", txtHostName.Text);
                FRRobotDemo.LogEvent(this, "Waiting for connection");
                if (string.IsNullOrEmpty(txtUserName.Text))
                {
                    txtUserName.ForeColor = Color.Gray;
                    txtUserName.Text = "anonymous";
                }
                string strHostName;
                int port;
                if(string.IsNullOrEmpty(txtHostName.Text))
                    txtHostName.Text = "localhost";
                strHostName = HostName(txtHostName.Text);
                port = short.Parse(txtPort.Text);
                FTP.Connect(strHostName, txtUserName.Text, txtPassword.Text, (ushort)port, chkPassive.Checked);
                mblnUpdateFTP = true;
                new System.Threading.Thread(() =>
                {
                    //wait until FTP is connected
                    while (!FTP.IsFtpConnected()) 
                    {
                        //cancel is pressed
                        if (!mblnUpdateFTP)
                            break;
                    }
                    UpdateFTP();
                }).Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cmdLogin_Click");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: treeFTP_AfterExpand
        //
        // Expand the tree.
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void treeFTP_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (!FTP.IsFtpConnected())
            {
                FRRobotDemo.LogEvent(this, "Disconnected from FTP server.");
                return;
            }

            try
            {
                TreeNode objNode,
                    objNodeToExpand;
                objNodeToExpand = e.Node;
                //get filered list
                string[] extension = strArrFilteredExt();
                // Get the first sub node
                if (objNodeToExpand.FirstNode.Text.Equals("ExpandMe"))
                {
                    // We need to expand the list since it isn't currently done
                    objNodeToExpand.Nodes.Clear();

                    FTP.SetDir("/" + objNodeToExpand.FullPath);

                    Cursor.Current = Cursors.WaitCursor;

                    foreach (var subitem in FTP.GetFileList(".", LIST_DELIMITER).Split(new char[] { DELIMITER }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        //loop through each extension
                        foreach (string ext in extension)
                        {
                            //has extension
                            if (subitem.ToUpper().Contains(ext))
                            {
                                objNode = objNodeToExpand.Nodes.Add(subitem, subitem);
                                //folder
                                if (!subitem.Contains("."))
                                    objNode.Nodes.Add(subitem, "ExpandMe");
                                objNode.EnsureVisible();
                            }
                        }
                    }
                    //free up resources
                    extension = null;
                    objNode = null;
                }
                objNodeToExpand = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "treeFTP_AfterExpand");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: treeFTP_NodeMouseClick
        //
        // On mouse click, are we selecting multiple items?
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void treeFTP_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //get what keys are pressed during selection
            mblnCtrl = false;
            mblnShft = false;
            mblnCtrl = (ModifierKeys == Keys.Control);
            mblnShft = (ModifierKeys == Keys.Shift);

            if (mblnCtrl || mblnShft)
            {
                //top level node, or folder so incorrect selection
                if (e.Node.Parent == null || !e.Node.Text.Contains("."))
                {
                    mblnCtrl = false;
                    mblnShft = false;
                    return;
                } 
            }

            if (mblnCtrl)
            {
                if (e.Node.IsSelected)
                {
                    if (e.Node.BackColor == Highlight)
                    {
                        e.Node.BackColor = Color.White;
                        if (mobjSelectedNodes.Contains(e.Node.FullPath))
                            mobjSelectedNodes.Remove(e.Node.FullPath);
                        mblnCtrl = false;
                    }
                    else
                    {
                        e.Node.BackColor = Highlight;
                        if (!mobjSelectedNodes.Contains(e.Node.FullPath))
                            mobjSelectedNodes.Add(e.Node.FullPath);
                        mblnCtrl = false;
                    }
                }
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: treeFTP_AfterSelect
        //
        // Follow the highlighted item changes
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void treeFTP_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if(mblnBusy)
                    return;
                if (!FTP.IsFtpConnected())
                {
                    FRRobotDemo.LogEvent(this, "Disconnected from FTP server.");
                    return;
                }

                TreeNode objNode = e.Node;

                cmdUpload.Enabled = false;
                cmdCreateDir.Enabled = false;
                cmdRemoveDir.Enabled = false;
                cmdLoad.Enabled = false;
                chkWaitForLoad.Enabled = false;
                cmdDelete.Enabled = false;
                cmdBackup.Enabled = true;
                transferFTP.Visible = false;
                lblTransferFTP.Visible = false;

                if (Path.HasExtension(objNode.Text))
                    cmdBackup.Text = "File Backup";
                else
                    cmdBackup.Text = "Directory Backup";

                // grab the first 2 characters in directory to handle buttons 
                string topDir = objNode.FullPath.Substring(0, 2);
                switch(topDir)
                {
                    case "FR":
                    case "MD":
                    case "UD":
                    case "UT":
                        // if not root node
                        if (objNode.Parent != null)
                        {
                            if (!Path.HasExtension(objNode.Text))
                                cmdRemoveDir.Enabled = true;
                            else
                                cmdDelete.Enabled = true;
                        }
                        break;
                }
                switch (topDir)
                {
                    case "FR": // can modify from FR only
                        if (objNode.Parent != null && objNode.Text.Contains("."))
                            cmdLoad.Enabled = true;
                        chkWaitForLoad.Enabled = true;
                        cmdUpload.Enabled = true;
                        cmdCreateDir.Enabled = true;
                        // if not root node
                        break;
                    case "MD":
                        cmdUpload.Enabled = true;
                        break;
                    case "RD": //RD is still not available
                        break;
                    case "UD":
                    case "UT":
                        cmdBackup.Text = "Invalid Directory";
                        cmdBackup.Enabled = false;
                        cmdCreateDir.Enabled = true;
                        break;
                }

                if (mblnCtrl || mblnShft)
                {
                    TreeNode mobjParentNode = objNode.Parent;
                    //selecting multiple files
                    if (mblnShft)
                    {
                        intNodeIdxEnd = objNode.Index;
                        //in case selection was reversed
                        if (intNodeIdxEnd < intNodeIdxStrt)
                        {
                            int intTempEnd = intNodeIdxEnd;
                            intNodeIdxEnd = intNodeIdxStrt;
                            intNodeIdxStrt = intTempEnd;
                        }
                        mobjLastNode = e.Node;
                        for (int index = intNodeIdxStrt; index <= intNodeIdxEnd; index++)
                        {
                            if (!mobjSelectedNodes.Contains(mobjParentNode.Nodes[index].FullPath))
                            {
                                mobjParentNode.Nodes[index].BackColor = Highlight;
                                mobjSelectedNodes.Add(mobjParentNode.Nodes[index].FullPath);
                            }
                            else
                            {
                                mobjParentNode.Nodes[index].BackColor = Color.White;
                                mobjSelectedNodes.Remove(mobjParentNode.Nodes[index].FullPath);
                            }
                        }
                        mblnShft = false;
                    }
                    //selecting multiple files, but one at a time
                    else if (mblnCtrl)
                    {
                        if (!mobjSelectedNodes.Contains(objNode.FullPath))
                        {
                            objNode.BackColor = Highlight;
                            mobjSelectedNodes.Add(objNode.FullPath);
                        }
                        else
                        {
                            objNode.BackColor = Color.White;
                            mobjSelectedNodes.Remove(objNode.FullPath);
                        }
                        mblnCtrl = false;
                    }
                    mobjParentNode = null;
                }
                else
                {
                    if (objNode.Parent != null)
                    {
                        intNodeIdxStrt = objNode.Index;
                        mobjFirstNode = objNode;
                        //empty list if clicking on new item
                        if (mobjFirstNode.BackColor != Highlight)
                        {
                            TreeNode node;
                            foreach (string strPath in mobjSelectedNodes)
                            {
                                node = NodeFromPath(strPath);
                                node.BackColor = Color.White;
                            }
                            node = null;
                            mobjSelectedNodes.Clear();
                        }
                    }
                }
                //OCD
                cmdDelete.Text = "Delete File";
                if (mobjSelectedNodes.Count > 1)
                {
                    cmdBackup.Text = "Files Backup";
                    cmdDelete.Text += "s";
                }
                objNode = null;
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message, "treeFTP_AfterSelect");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdRefresh_Click
        //
        // Refresh treeview
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            msubUpdateFTP(cmbRbtDir.Text);
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdUpload_Click
        //
        // Upload file(s)
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdUpload_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog path = new OpenFileDialog();
                path.Title = "Upload File(s) to Robot";
                path.Multiselect = true;
                path.Filter = string.Join("", mobjFilterList);

                if (path.ShowDialog() == DialogResult.OK)
                {
                    //verify before big file transfer
                    int files = path.FileNames.Length;
                    if (files> 50)
                    {
                        DialogResult confirm = MessageBox.Show(string.Format("Upload {0} files to robot?", files), "Warning!", MessageBoxButtons.OKCancel);
                        if (confirm == DialogResult.Cancel)
                            return;
                    }
                    TreeNode nodeDir;
                    string strRbtDir,
                        strPath;
                    int filesCount;
                    strRbtDir = treeFTP.SelectedNode.FullPath;
                    strPath = strRbtDir;
                    //did user choose directory or file?
                    if (strRbtDir.Contains("."))
                    {
                        strRbtDir = treeFTP.SelectedNode.Parent.FullPath;
                        strPath = Path.GetDirectoryName(strPath);
                    }
                    //get node so we can focus again
                    nodeDir = NodeFromPath(strPath);
                    //set directory for upload
                    FTP.SetDir(strRbtDir);
                    filesCount = path.FileNames.Length;
                    transferFTP.Maximum = filesCount;
                    transferFTP.Visible = true;
                    lblTransferFTP.Visible = true;

                    string strSafeFileName;

                    for (int index = 0; index < filesCount; index++)
                    {
                        strSafeFileName = path.SafeFileNames[index];
                        //successful transaction
                        if (FTP.PutFile(path.FileNames[index], strSafeFileName, TransferFlag.BinaryMode))
                        {
                            transferFTP.Value = index + 1;
                            //don't add if already exists 
                            if (!nodeDir.Nodes.ContainsKey(strSafeFileName))
                                nodeDir.Nodes.Add(strSafeFileName);
                            lblTransferFTP.Text = string.Format("{0:0.0}%", (double)transferFTP.Value * 100 / (double)filesCount);
                            lblTransferFTP.Refresh();
                            FRRobotDemo.LogEvent(this, string.Format("Uploaded {0} to {1}", strSafeFileName, strRbtDir));
                        }
                        else
                        {
                            FRRobotDemo.LogEvent(this, "Failed on file " + strSafeFileName);
                            break;
                        }
                    }
                    treeFTP.Update();
                    treeFTP.Focus();
                    //free up resources
                    path = null;
                    strRbtDir = null;
                    strSafeFileName = null;
                    files = 0;
                    filesCount = 0;
                }
                path = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "cmdUpload_Click");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdCreateDir_Click
        //
        // Create directory
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdCreateDir_Click(object sender, EventArgs e)
        {
            //Prompt user for Directory name
            try
            {
                if (InputBox.UserInput("Create Directory Name", "Create Directory Name", string.Empty) == DialogResult.OK)
                {
                    string strNewDir;
                    strNewDir = InputBox.txtOutput;
                    TreeNode RbtDir;
                    RbtDir = treeFTP.SelectedNode;
                    if (RbtDir.FullPath.Contains("."))
                        RbtDir = treeFTP.SelectedNode.Parent;
                    if (FTP.CreateDirectory(RbtDir.FullPath + "/" + strNewDir))
                    {
                        //must add key or else node is null
                        RbtDir.Nodes.Add(strNewDir, strNewDir);
                        treeFTP.Update();
                        FRRobotDemo.LogEvent(this, string.Format("Created Folder \"{0}\" in \"{1}\"", strNewDir, RbtDir.FullPath));
                    }
                    else
                    {
                        FRRobotDemo.LogEvent(this, string.Format("Create Direcyory Error: {0}", FTP.GetLastResponse()));
                    }
                    //free up resources
                    strNewDir = null;
                    RbtDir = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "cmdCreateDir_Click");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdBackup_Click
        //
        // Make back up of single file or directory
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdBackup_Click(object sender, EventArgs e)
        {
            if(mobjSelectedNodes.Count > 1)
            {
                DialogResult result = MessageBox.Show(string.Format("Backing Up {0} Files", mobjSelectedNodes.Count), "Files Backup", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    return;
            }
            FolderBrowserDialog path = new FolderBrowserDialog();
            //Check to see if the user clicked the cancel button
            if (path.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string strSavePath,
                        strFile = string.Empty;
                    int nodesCount = 0;
                    bool skip = false,
                        cancel = false,
                        success = false,
                        filesTransfer = false;
                    strSavePath = path.SelectedPath;
                    FTP.SetDir(treeFTP.SelectedNode.FullPath);
                    //expand tree to get count
                    treeFTP.SelectedNode.Expand();
                    nodesCount = treeFTP.SelectedNode.Nodes.Count;
                    //for single file transfer
                    if (nodesCount < 1)
                        nodesCount = 1;
                    //multiple files transfer
                    if (mobjSelectedNodes.Count > 0)
                    {
                        filesTransfer = true;
                        nodesCount = mobjSelectedNodes.Count;
                    }
                    transferFTP.Value = 0;
                    transferFTP.Maximum = nodesCount;
                    transferFTP.Visible = true;
                    lblTransferFTP.Visible = true;
                    for (int index = 0; index < nodesCount; index++)
                    {
                        //directory/single selection
                        if (!filesTransfer)
                        {
                            if (nodesCount > 1)
                                strFile = treeFTP.SelectedNode.Nodes[index].Text;
                            else
                                strFile = treeFTP.SelectedNode.Text;
                        }
                        else
                        {
                            //in case of selections from MD, FR, UD, etc
                            FTP.SetDir(Path.GetDirectoryName(mobjSelectedNodes[index]));
                            strFile = Path.GetFileName(mobjSelectedNodes[index]);
                        }
                        // if file already exists at destination
                        if (File.Exists(strSavePath + "/" + strFile))
                        {
                            skip = false;
                            cancel = false;
                            success = false;
                            DialogResult file = MessageBox.Show(string.Format("Overwrite File \"{0}\"", strFile), "Existing File Detected", MessageBoxButtons.YesNoCancel);
                            switch(file)
                            {
                                case DialogResult.Yes: //overwrite file
                                    success = FTP.GetFile(strFile, strSavePath + "/" + strFile, true, TransferFlag.BinaryMode);
                                    break;
                                case DialogResult.No: //don't overwrite
                                    skip = true;
                                    break;
                                case DialogResult.Cancel: //cancel operation
                                    cancel = true;
                                    break;
                            }
                        }
                        else
                            success = FTP.GetFile(strFile, strSavePath + "/" + strFile, true, TransferFlag.BinaryMode);                        
                        // exit loop
                        if (cancel)
                            break;
                        //successful transaction
                        if (success && !skip)
                        {
                            transferFTP.Value++;
                            lblTransferFTP.Text = string.Format("{0:0.0}%", (double)transferFTP.Value * 100 / (double)(nodesCount));
                            lblTransferFTP.Refresh();
                            FRRobotDemo.LogEvent(this, string.Format("Downloaded {0}", strFile));
                        }
                    }
                    FRRobotDemo.LogEvent(this, string.Format("Downloaded {0} to {1}", strFile, strSavePath));
                    treeFTP.SelectedNode.Collapse();

                    //free up resources
                    strSavePath = null;
                    strFile = null;
                    nodesCount = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "cmdSaveto_Click");
                }
            }
            path = null;
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdRemoveDir_Click
        //
        // Remove directory
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdRemoveDir_Click(object sender, EventArgs e)
        {
            try
            {
                string strFullPath;
                strFullPath = treeFTP.SelectedNode.FullPath;
                //Prompt user
                DialogResult result = MessageBox.Show(string.Format("OK To Delete {0}?", strFullPath), "Warning!", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    if (FTP.RemoveDirectoryW(strFullPath))
                    {
                        FRRobotDemo.LogEvent(this, string.Format("Removed Folder \"{0}\"", strFullPath));
                        treeFTP.SelectedNode.Remove();
                        treeFTP.Update();
                    }
                    else
                    {
                        FRRobotDemo.LogEvent(this, string.Format("Remove Directory Error: {0}", FTP.GetLastResponse()));
                    }
                    strFullPath = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "cmdCreateDir_Click");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdFind_Click
        //
        // Search treeview for specified file
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdFind_Click(object sender, EventArgs e)
        {
            string searchText = string.Empty;

            if (InputBox.UserInput("Find File", "Enter file name", string.Empty) == DialogResult.OK)
            {
                searchText = InputBox.txtOutput;
                if (string.IsNullOrEmpty(searchText))
                    return;
                searchText = searchText.ToUpper();
                Recursive(treeFTP, searchText);
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdDelete_Click
        //
        // Delete single file or empty directory
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string prompt = (mobjSelectedNodes.Count > 1) 
                    ? string.Format("Delete {0} Files From Robot?", mobjSelectedNodes.Count)
                    : string.Format("Delete {0} From Robot?", treeFTP.SelectedNode.FullPath);
                DialogResult result = MessageBox.Show(prompt, "Warning!", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    string strFileNameNoExt,
                        strFileName,
                        strPath,
                        strFullPath,
                        strParentNode,
                        strNodePath = string.Empty;
                    int intCount;
                    intCount = mobjSelectedNodes.Count;
                    TreeNodeCollection nodes;
                    TreeNode nodeDir = null; //just declaring a temporary node;

                    transferFTP.Value = 0;
                    transferFTP.Visible = true;
                    lblTransferFTP.Visible = true;
                    //multiple files delete
                    if (intCount > 1)
                    {
                        transferFTP.Maximum = intCount;
                        for (int index = 0; index < intCount; index++)
                        {
                            strFullPath = mobjSelectedNodes[0];
                            //only do if file exists
                            if (FTP.DeleteFile(strFullPath))
                            {
                                strFileNameNoExt = Path.GetFileNameWithoutExtension(strFullPath);
                                strFileName = Path.GetFileName(strFullPath);
                                strPath = Path.GetDirectoryName(strFullPath);     
                                //rebuild parent node
                                if (!strNodePath.Equals(strPath))
                                {
                                    nodeDir = NodeFromPath(strPath);
                                    //get directory path
                                    strNodePath = nodeDir.FullPath;
                                }

                                // Loop through each sub node to eliminate 
                                // double items like "TEST.LS" and "TEST.TP"
                                nodes = nodeDir.Nodes;

                                // search how many duplicate files we have
                                // and record first position
                                // typically .LS and .TP inside MD:
                                foreach (TreeNode node in nodes)
                                {
                                    if (node != null)
                                    {
                                        strParentNode = Path.GetFileNameWithoutExtension(node.Text);
                                        if (strFileNameNoExt.Contains(strParentNode))
                                        {
                                            node.BackColor = Color.White;
                                            //directory, skip
                                            if (node.Text.Contains("."))
                                            {
                                                transferFTP.Value++;
                                                FRRobotDemo.LogEvent(this, "Removed File " + node.FullPath);
                                                nodes.Remove(node);
                                                lblTransferFTP.Text = string.Format("{0:0.0}%", (double)(transferFTP.Value) * 100 / (double)intCount);
                                                lblTransferFTP.Refresh();
                                                mobjSelectedNodes.Remove(strFullPath);
                                            }
                                        }
                                    }
                                }
                                mblnBusy = true;
                            }
                        }
                    }
                    //single file delete
                    else
                    {
                        strFullPath = treeFTP.SelectedNode.FullPath;
                        strParentNode = treeFTP.SelectedNode.Parent.FullPath;
                        if (FTP.DeleteFile(strFullPath))
                        {
                            strFileNameNoExt = Path.GetFileNameWithoutExtension(strFullPath);
                            nodes = treeFTP.SelectedNode.Parent.Nodes;

                            transferFTP.Maximum = 0;
                            mblnBusy = true;
                            // search how many duplicate files we have
                            // and record first position
                            // typically .LS and .TP inside MD:
                            foreach (TreeNode node in nodes)
                            {
                                if (node != null)
                                {
                                    strPath = Path.GetFileNameWithoutExtension(node.Text);
                                    if (strFileNameNoExt.Contains(strPath))
                                    {
                                        node.BackColor = Color.White;
                                        //directory, skip
                                        if (node.Text.Contains("."))
                                        {
                                            transferFTP.Maximum++;
                                            transferFTP.Value++;
                                            lblTransferFTP.Text = string.Format("{0:0.0}%", (double)transferFTP.Value * 100 / (double)transferFTP.Maximum);
                                            lblTransferFTP.Refresh();
                                            FRRobotDemo.LogEvent(this, "Removed File" + strFullPath);
                                            nodes.Remove(node);
                                        }
                                    }
                                }
                            }
                            //free up resources
                            prompt = null;
                            strFileNameNoExt = null;
                            strFileName = null;
                            strPath = null;
                            strFullPath = null;
                            strParentNode = null;
                            strNodePath = null;
                            intCount = 0;
                            nodes = null;
                            nodeDir = null;
                        }
                        else
                        {
                            FRRobotDemo.LogEvent(this, string.Format("Failed To Delete {0} From {1}", strFullPath, strParentNode));
                        }
                    }
                    treeFTP.Update();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "cmdDelete_Click");
            }
            finally
            {
                mblnBusy = false;
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdLoad_Click
        //
        // Load file from FR (MD/MDB?)
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdLoad_Click(object sender, EventArgs e)
        {
            try
            {
                LoadFile(treeFTP.SelectedNode.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cmdLoad_Click");
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmbRbtDir_SelectedIndexChanged
        //
        // Filter directory via combobox
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmbRbtDir_SelectedIndexChanged(object sender, EventArgs e)
        {
            //prevent endless loop of death
            if (mblnRefresh)
            {
                mblnRefresh = false;
                return;
            }
            msubUpdateFTP(cmbRbtDir.Text);
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: lstFilter_Click
        //
        // Update filter list
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void lstFilter_Click(object sender, EventArgs e)
        {
            if (lstFilter.SelectedItems.Count > 0)
            {
                bool AllFilesSelected = lstFilter.SelectedItems[0].ToString().Contains("*.*") ? true : false;
                if (mblnFilterSelected && AllFilesSelected)
                {
                    lstFilter.SelectedItems.Remove(lstFilter.SelectedItems[0]);
                    mblnFilterSelected = false;
                }
                else if (!mblnFilterSelected && AllFilesSelected)
                {
                    mblnFilterSelected = true;
                    lstFilter.ClearSelected();
                    lstFilter.SetSelected(0, true);
                }
            }
            else
            {
                mblnFilterSelected = false;
            }
            msubUpdateFTP(cmbRbtDir.Text);
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: frmFTP_KeyPress
        //
        // Quick keys to make life a bit easier...AKA I'm lazy
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void frmFTP_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (cmdConnect.Text)
            {
                case "Login":
                    if (e.KeyChar.Equals((char)Keys.Enter))
                        cmdConnect_Click(this, new EventArgs());
                    break;
                case "Disconnect":
                    if (e.KeyChar.Equals((char)Keys.Escape))
                        cmdConnect_Click(this, new EventArgs());
                    else if (e.KeyChar.Equals((char)Keys.F5))
                        cmdRefresh_Click(this, new EventArgs());
                    break;
            }
        }

        #endregion

        #region "Robot Server Events"

        //*************************************************************************
        //                        Robot Server Events
        //*************************************************************************

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: mobjPrograms_Create
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void mobjPrograms_Create(IProgram Program)
        {
            FRRobotDemo.LogEvent(this, String.Format("Got mobjPrograms_Create Event for program {0}", Program.Name));

            if (mstrProgramName.Equals(Program.Name))
            {
                mblnGotCreateEvent = true;
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT:  mobjPrograms_Refresh
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void mobjPrograms_Refresh(IProgram Program)
        {
            FRRobotDemo.LogEvent(this, String.Format("Got mobjPrograms_Refresh Event for program {0}", Program.Name));
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: mobjPrograms_RefreshVars
        //
        // It gets tricky when you load a file without an extension.
        // In such cases, the variables collection is only valid on the "final"
        // RefreshVars event.  See the combinations under Case "" of the Load method
        // above.
        // This routine flags the final refresh var event only if it was preceded
        // by a Create or RefreshVars event.
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void mobjPrograms_RefreshVars(IProgram Program)
        {
            FRRobotDemo.LogEvent(this, String.Format("Got mobjPrograms_RefreshVars Event for program {0}", Program.Name));

            if (mstrProgramName.Equals(Program.Name))
            {
                if (mblnGotCreateEvent | mblnGotRefreshVarsEvent)
                {
                    mblnGotFinalRefreshVarsEvent = true;
                }
                mblnGotRefreshVarsEvent = true;
            }
        }

        #endregion

        #region "Utility Routines"

        //*************************************************************************
        //                        Utility Routines
        //*************************************************************************

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: msubUpdateFTP
        //
        // Update the FTP treeview.
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void msubUpdateFTP(string path)
        {
            try
            {
                treeFTP.Nodes.Clear();
                cmbRbtDir.Items.Clear();
                cmbRbtDir.Items.Add("/");
                FTP.SetDir(path);
                TreeNode objNode;
                string FileList;
                FileList = FTP.GetFileList(".", LIST_DELIMITER);
                //update the entire FTP
                if (path.Equals("/"))
                {
                    //gets top level
                    foreach (var item in FileList.Split(new char[] { DELIMITER }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        string drive = item.ToUpper();
                        if (!ExcludedItems.Contains(drive))
                        {
                            cmbRbtDir.Items.Add(drive);
                            //add top level to tree
                            objNode = treeFTP.Nodes.Add(drive, drive);
                            FTP.SetDir(path + drive);
                            //just go ahead and expand to lower cycle time from FTP.GetFileList();
                            //copy foreach from below if needed
                            objNode.Nodes.Add(drive, "ExpandMe");
                        }
                    }
                }
                //update single directory
                else
                {
                    cmbRbtDir.Items.Add(path);
                    objNode = treeFTP.Nodes.Add(path, path);
                    foreach (var subitem in FileList.Split(new char[] { DELIMITER }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        if (!ExcludedItems.Contains(subitem))
                            objNode.Nodes.Add(subitem, "ExpandMe");
                    }
                }
                mblnRefresh = true;
                cmbRbtDir.Text = path;
                //free up resources
                objNode = null;
                FileList = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "msubUpdateFTP");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                treeFTP.Update();
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: Recursive
        //
        // Recursive procedure
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void Recursive(TreeView treeView, string txtInput)
        {
            // Loop through each node recursively
            TreeNodeCollection nodes = treeView.Nodes;
            foreach (TreeNode node in nodes)
            {
                node.Expand();
                mblnFoundFile = false;
                SelfRecursive(node, txtInput);
                // only show the nodes containing file(s)
                if (!mblnFoundFile)
                    node.Collapse();
            }
            nodes = null;
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: SelfRecursive
        //
        // Loop through nodes of nodes to match text
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void SelfRecursive(TreeNode treeNode, string txtInput)
        {
            // highlight found items
            if (treeNode.Text.Contains(txtInput))
            {
                treeNode.BackColor = Color.Yellow;
                treeNode.EnsureVisible();
                mblnFoundFile = true;
            }
            else
            {
                treeNode.BackColor = Color.Empty;         
            }
            // loop each node recursively.
            foreach (TreeNode objNode in treeNode.Nodes)
            {
                SelfRecursive(objNode, txtInput);
            }
        }

        private void LoadFile(string strFileName)
        {
            try
            {
                string strFileExt;
                int intDotLoc;
                Stopwatch timStopWatch = new Stopwatch();

                // Get the file name to load
                strFileName.ToUpper();

                // Reference the Programs object so we can catch the load events
                mobjPrograms = FRRobotDemo.gobjRobot.Programs;
                //unsubscribe event if already subscribed
                mobjPrograms.Create -= mobjPrograms_Create;
                mobjPrograms.Refresh -= mobjPrograms_Refresh;
                mobjPrograms.RefreshVars -= mobjPrograms_RefreshVars;
                //subscribe event handlers
                mobjPrograms.Create += mobjPrograms_Create;
                mobjPrograms.Refresh += mobjPrograms_Refresh;
                mobjPrograms.RefreshVars += mobjPrograms_RefreshVars;

                mblnGotCreateEvent = false;
                mblnGotRefreshVarsEvent = false;
                mblnGotFinalRefreshVarsEvent = false;

                // Extract the base program name
                intDotLoc = strFileName.IndexOf('.');
                if (intDotLoc > 1)
                {
                    mstrProgramName = strFileName.Substring(1 - 1, intDotLoc - 1);
                    strFileExt = strFileName.Substring((intDotLoc + 1) - 1);
                }
                else
                {
                    mstrProgramName = strFileName;
                    strFileExt = string.Empty;
                }

                // Load it
                FRRobotDemo.gobjRobot.Load(treeFTP.SelectedNode.FullPath, FRELoadOptionConstants.frStandardLoad);

                // Checkbox to wait is checked
                if (chkWaitForLoad.Checked)
                {
                    // Set the timeout for the event to occur
                    timStopWatch.Start();
                    Cursor = Cursors.WaitCursor;

                    // Wait for the appropriate event based on file extension
                    switch (strFileExt)
                    {
                        // Loading a .pc file.
                        //    if nothing exists, get Create event
                        //    if only the variables exists, get Delete followed by Create event
                        //    if the pc exists, get RefreshVars event
                        //    if both exist, get RefreshVars event
                        case "PC":
                            while (((timStopWatch.ElapsedMilliseconds < LOAD_DELAY) & !(mblnGotCreateEvent | mblnGotRefreshVarsEvent)))
                            {
                                Application.DoEvents();
                            }
                            Cursor.Current = Cursors.Default;

                            if (!(mblnGotCreateEvent | mblnGotRefreshVarsEvent))
                            {
                                MessageBox.Show("Load timed out for " + strFileName, "cmdLoad_Click1");
                            }
                            break;
                        // Loading a .vr file.
                        //    if nothing exists get Create
                        //    if pc exists, get RefreshVars
                        //    if variables exist, get RefreshVars
                        //    if both exist, get RefreshVars
                        case "VR":
                            while (((timStopWatch.ElapsedMilliseconds < LOAD_DELAY) & !(mblnGotRefreshVarsEvent | mblnGotCreateEvent)))
                            {
                                Application.DoEvents();
                            }
                            Cursor.Current = Cursors.Default;

                            if (!(mblnGotRefreshVarsEvent | mblnGotCreateEvent))
                            {
                                MessageBox.Show("Load timed out for " + strFileName, "");
                            }
                            break;
                        // If no file extension given, PC and VR are loaded (if they exist)
                        //    if nothing exists, get Create and RefreshVars event
                        //    if both exist, then get two RefreshVars events
                        //    if only variables exist, get Delete, Create then RefreshVars events
                        //    if there is only a .pc file on the MC: device then get only a Create event
                        case "":
                            while (((timStopWatch.ElapsedMilliseconds < LOAD_DELAY) & !mblnGotFinalRefreshVarsEvent))
                            {
                                Application.DoEvents();
                            }
                            Cursor.Current = Cursors.Default;

                            if (!(mblnGotFinalRefreshVarsEvent | mblnGotCreateEvent))
                            {
                                MessageBox.Show("Load timed out for " + strFileName, "cmdLoad_Click2");
                            }
                            break;
                        default:
                            // Don't know how to wait for other file type - like .io
                            // so just let the load take place
                            Cursor.Current = Cursors.Default;
                            break;
                    }

                    timStopWatch.Stop();
                    timStopWatch = null;
                }
                //free up resources;
                strFileExt = null;
                intDotLoc = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LoadFile");
            }
            finally
            {
                Cursor = Cursors.Default;
                mobjPrograms = null;
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: updateFTP
        //
        // Update FTP after succesful login
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        public delegate void DelegateUpdateFTP();
        private void UpdateFTP()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new DelegateUpdateFTP(UpdateFTP));
                return;
            }
            if (!mblnUpdateFTP)
            {
                this.Text = "FANUC FTP";
                FTP = null;
                return;
            }
            string response;
            response = FTP.GetLastResponse();
            FRRobotDemo.LogEvent(this, response);
            _lblStatic_9.Text = string.Format("Version:{0,0} {1,10}{2} {3,10}{4}", Version(response), "Mode:", FTP.GetControllerMode(), "Type:", FTP.GetControllerType());
            this.Text = string.Format("FANUC FTP: Connected To {0}", txtHostName.Text);
            cmdConnect.Text = "Disconnect";
            //get the sublist for the listBox
            lstFilter.Items.AddRange(FilterList(FTP.GetControllerMode().ToString()));
            lstFilter.Enabled = true;
            //select All Files
            lstFilter.ClearSelected();
            lstFilter.SetSelected(0, true);
            mblnFilterSelected = true;
            msubUpdateFTP("/");
            cmdRefresh.Enabled = true;
            cmbRbtDir.Enabled = true;
            cmdFind.Enabled = true;
            txtHostName.Enabled = false;
            txtUserName.Enabled = false;
            txtPassword.Enabled = false;
            txtPort.Enabled = false;
            //free up resources
            response = null;
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: FilterList
        //
        // Filter out allowed extension based on controller mode
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private string[] FilterList(string ControllerMode)
        {
            string[] output = new string[mobjFilterList.Count];
            mobjFilterList.CopyTo(output, 0);
            // depends on controller mode, do something
            switch (ControllerMode)
            {
                case "Normal":
                    //no need to do anything
                    break;
                default:
                    output = null;
                    break;
            }
            int lenght,
                start,
                count;
            count = output.Length;
            //loop though master list and get the friendly text
            for (int index = 0; index < count; index++)
            {
                lenght = output[index].Length;
                start = output[index].IndexOf("|");
                output[index] = output[index].Substring(0, start);
            }
            //free up resources
            lenght = 0;
            start = 0;
            count = 0; 
            return output;
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: strFilteredList
        //
        // Compile filter list
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private string[] strArrFilteredExt()
        {
            string[] FilteredList;
            string extension;
            int index,
                count,
                start,
                end;
            count = lstFilter.SelectedItems.Count;
            //create array with specified size and copy from list
            FilteredList = new string[count];
            lstFilter.SelectedItems.CopyTo(FilteredList, 0);
            for (index = 0; index < count; index++)
            {
                extension = FilteredList[index];
                //all files
                if (extension.Contains("*.*"))
                {
                    //need to null previous array?
                    FilteredList = null;
                    FilteredList = new string[1]{""};
                    break;
                }
                else
                {
                    start = extension.IndexOf("(");
                    end = extension.IndexOf(")");
                    // inside bracket
                    extension = extension.Substring(start + 1, end - start - 1);
                    extension = extension.Replace("*", "");
                    FilteredList[index] = extension;
                }
            }
            //free up resources
            extension = null;
            index = 0;
            count = 0;
            start = 0;
            end = 0;
            return FilteredList;
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: Version
        //
        // Parse robot server response to get version
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private string Version(string input)
        {
            int start,
                end;
            string output;
            start = input.IndexOf("[");
            end = input.IndexOf("]");
            output = input.Substring(start, end - start);
            input = output;
            start = input.IndexOf("V");
            output = input.Substring(start + 1);
            //free up resources
            start = 0;
            end = 0;
            return output;
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: NodeFromPath
        //
        // Rebuild Node from path
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private TreeNode NodeFromPath(string Path)
        {
            TreeNode nodeDir = null;
            int count = 0;
            foreach (var subitem in Path.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries))
            {
                //parse directory to get parent node
                count++;
                nodeDir = (count == 1) ? treeFTP.Nodes[subitem] : nodeDir = nodeDir.Nodes[subitem];
            }
            count = 0;
            return nodeDir;
        }
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // ROUTINE: HostName
        //
        // Remove port if hostname contains port (e.g. 127.0.0.1:3003)
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private string HostName(string strHostName)
        {
            int port;
            //remove port if existing
            port = strHostName.IndexOf(":");
            if (port > 0)
            {
                strHostName = strHostName.Substring(0, port);
            }
            return strHostName;
        }

        #endregion

    }
}