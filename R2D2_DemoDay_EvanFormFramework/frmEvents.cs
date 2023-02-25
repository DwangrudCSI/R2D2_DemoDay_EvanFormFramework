// Module: frmEvents
//
// Description:
//    Display the event log
//
// Author: Tri Quach
//         FANUC America Corporation 
//         29700 Kohoutek Way
//         Union City, CA 94587
//
// Modification history:
// 05-Oct-2015 Quach    Adapted from the VB.Net version
// 09-Feb-2016 Quach    Changed from listBox to listView

using System;
using System.Windows.Forms;

namespace FRRobotDemoCSharp
{
    public partial class frmEvents : Form
    {

        #region "Declarations"

        //*************************************************************************
        //                           Declarations
        //*************************************************************************
        int line;
        object item;

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
        public frmEvents()
        {
            InitializeComponent();
            //set min/max size
            this.MinimumSize = this.Size;
            Events.Width = lstViewEvents.Size.Width - 10;
        }

        #endregion

        #region "User Input Events"

        //*************************************************************************
        //                        User Input Events
        //*************************************************************************
        private void cmdClear_Click(object sender, EventArgs e)
        {
            line = 0;
            Events.ListView.Items.Clear();
        }


        private void frmEvents_Resize(object sender, EventArgs e)
        {
            Events.Width = lstViewEvents.Size.Width - 10;
            if (line > 15)
                Events.Width = lstViewEvents.Size.Width - 27;
        }

        #endregion

        #region "Utility Routines"

        //*************************************************************************
        //                        Utility Routines
        //*************************************************************************
        private void LocalAddEvent(string vstrItem)
        {

        }

        public void AddEvent(string vstrItem)
        {
            try
            {
                this.MdiParent = FRRobotDemo.gobjMDIParent;
                this.Show();
                vstrItem = vstrItem.Replace("\r\n", "");
                item = new ListViewItem(vstrItem);

                lstViewEvents.Items.Add(vstrItem + "\n");
                //alternate between each line
                if ((line & 1) == 0)
                    lstViewEvents.Items[line].BackColor = System.Drawing.Color.Yellow;
                if(vstrItem.ToUpper().Contains("ERROR"))
                {
                    lstViewEvents.Items[line].BackColor = System.Drawing.Color.Red;
                    lstViewEvents.Items[line].ForeColor = System.Drawing.Color.White;
                }
                // scroll to line
                lstViewEvents.Items[line].EnsureVisible();
                line++;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "AddEvent");
            }
        }

        public void Clear()
        {
            line = 0;
            Events.ListView.Items.Clear();
        }

        #endregion

    }
}