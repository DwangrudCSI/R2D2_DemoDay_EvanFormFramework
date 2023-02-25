// Module: frmFeatures
//
// Description:
//   Display and search for features installed on the robot
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
    public partial class frmFeatures : Form
    {

        #region "Declarations"

        //*************************************************************************
        //                           Declarations
        //*************************************************************************

        private FRRobot.FRCSynchData mobjSynchData;
        private FRRobot.FRCFeatures mobjFeatures;

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
        public frmFeatures()
        {
            InitializeComponent();
            //set min/max size
            this.MinimumSize = this.Size;
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: Form_Load
        //
        // Sets up the form and populates the feature list
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void frmFeatures_Load(object sender, EventArgs e)
        {
            //FRCFeature objFeature;

            // Set module global references
            mobjSynchData = FRRobotDemo.gobjRobot.SynchData;
            // Create the synch data object
            mobjFeatures = FRRobotDemo.gobjRobot.SynchData.Features;


            lstFeatures.Items.Clear();
            // Zap the list

            foreach (FRCFeature objFeature in mobjFeatures)
            {
                lstFeatures.Items.Add(objFeature.OrderNumber + (char)(Keys.Tab) + objFeature.Version + "   " + objFeature.Name);
            }

            // Display the count andZget out
            lblFeatureCount.Text = R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_NUMBER_OF_FEATURES + mobjFeatures.Count.ToString();
        }

        #endregion

        #region "User Input Events"

        //*************************************************************************
        //                        User Input Events
        //*************************************************************************

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdFeatureIsValid_Click
        //
        // Checks to see if selected feature is valid.
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdFeatureIsValid_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFeatureOrderNum.Text))
            {
                MessageBox.Show(R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_NO_FEATURE_NUMBER_DEFINED);
            }
            else
            {
                try
                {
                    lblFeatureYesNo.Text = (mobjFeatures.IsValid[txtFeatureOrderNum.Text]).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "cmdFeatureIsValid_Click");
                }
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: cmdGetItem_Click
        //
        // Gets version data about the selected feature
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void cmdGetItem_Click(object sender, EventArgs e)
        {
            FRRobot.FRCFeature objFeature;

            if (string.IsNullOrEmpty(txtFeatureOrderNum.Text))
            {
                MessageBox.Show(R2D2_DemoDay_EvanFormFramework.Properties.Resources.IDS_NO_FEATURE_NUMBER_DEFINED);
            }
            else
            {
                try
                {
                    objFeature = mobjFeatures[txtFeatureOrderNum.Text];
                    lblFeatureData.Text = objFeature.OrderNumber + "        " + objFeature.Version + "        " + objFeature.Name;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "cmdGetItem_Click");
                }
            }
        }

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //
        // EVENT: txtFeatureOrderNum_TextChanged
        //
        // New number being entered.  Data and Valid are no longer valie
        //
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        private void txtFeatureOrderNum_TextChanged(object sender, EventArgs e)
        {
            lblFeatureData.Text = string.Empty;
            lblFeatureYesNo.Text = string.Empty;
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