// Module: Registry
//
// Description:
//   Writes to system registry like that of VBNet
//
// Author: Tri Quach
//         FANUC America Corporation 
//         29700 Kohoutek Way
//         Union City, CA 94587
//
// Modification history:
// 05-Oct-2015 Quach    Initial Creation

using System;
using Microsoft.Win32;
using System.Windows.Forms;

namespace FRRobotDemoCSharp
{
    public class Registry
    {

        #region "Utility Routines"

        //*************************************************************************
        //                        Utility Routines
        //*************************************************************************
        public static void SaveSetting(string AppName, string Section, string Key, string Setting)
        {
            //might change path later on
            string path = string.Empty;
            path = Section;

            RegistryKey key = Application.UserAppDataRegistry.CreateSubKey(path);

            if (key != null)
            {
                try
                {
                    key.SetValue(Key, Setting);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "SaveSetting");
                    return;
                }
                finally
                {
                    key.Close();
                }
            }
        }

        public static string GetSetting(string AppName, string Section, string Key, string Default)
        {
            try
            {
                //might change path later on
                string path = string.Empty;
                path = Section;

                RegistryKey key = Application.UserAppDataRegistry.OpenSubKey(path);

                if (key != null)
                {
                    Default = key.GetValue(Key, Default).ToString();
                    key.Close();
                    if (string.IsNullOrEmpty(Default))
                        return null;
                }
            }
            catch( Exception ex)
            {
                MessageBox.Show(ex.Message, "GetSetting");
            }
            return Default;
        }

        #endregion

    }
}
