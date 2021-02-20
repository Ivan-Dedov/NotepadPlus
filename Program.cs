using System;
using System.Windows.Forms;

namespace NotepadPlus
{

    /// <summary>
    /// The main body of the application.
    /// </summary>
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            UserSettingsReader.DeleteAllAutosaves();
            UserSettingsReader.DeleteAllBackups();
            try
            {
                Application.Run(new NotepadMainWindow());
            }
            catch
            {
                UserSettingsReader.RefreshSettings(Constants.DefaultColourTheme,
                    (SystemInformation.PrimaryMonitorSize / 2).Width, (SystemInformation.PrimaryMonitorSize / 2).Height,
                    Constants.DefaultAutosaveFrequencyValue, Constants.DefaultBackupFrequencyValue, null, true);

                MessageBox.Show("Something went wrong!", "Unknown Error Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}