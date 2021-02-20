using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace NotepadPlus
{

    /// <summary>
    /// Handles reading from and writing to User Settings files.
    /// </summary>
    public static class UserSettingsReader
    {

        /// <summary>
        /// Deletes all autosaves from the autosave directory.
        /// </summary>
        public static void DeleteAllAutosaves()
        {
            if (Directory.Exists(Constants.MainFolder + Constants.AutosaveDirectory))
            {
                foreach (string item in Directory.GetFiles(Constants.MainFolder + Constants.AutosaveDirectory))
                {
                    File.Delete(item);
                }
            }
        }
        /// <summary>
        /// Deletes all backups from the backup directory.
        /// </summary>
        public static void DeleteAllBackups()
        {
            if (Directory.Exists(Constants.MainFolder + Constants.BackupDirectory))
            {
                foreach (string item in Directory.GetFiles(Constants.MainFolder + Constants.BackupDirectory))
                {
                    File.Delete(item);
                }
            }
        }

        /// <summary>
        /// Retrieves the previously selected value for autosave frequency (in seconds).
        /// </summary>
        /// <returns>The previously selected number of seconds between each autosave.</returns>
        public static int GetAutosaveFrequency()
        {
            int autosaveDuration = 0;

            try
            {
                using (StreamReader streamReader =
                    new StreamReader(Constants.MainFolder + Constants.SettingsFile))
                {
                    while (!streamReader.EndOfStream)
                    {
                        string[] line = streamReader.ReadLine().Split(Constants.UserSettingsSeparator);
                        if (line[0] == Constants.AutosaveString &&
                            line.Length == 2 &&
                            int.TryParse(line[1], out autosaveDuration) &&
                            Array.IndexOf(Constants.AutosaveFrequenciesInSeconds, autosaveDuration) != -1)
                        {
                            break;
                        }
                    }
                }
            }
            catch
            {
                return Constants.DefaultAutosaveFrequencyValue;
            }

            return autosaveDuration;
        }
        /// <summary>
        /// Retrieves the previously selected value for backup frequency (in seconds).
        /// </summary>
        /// <returns>The previously selected number of seconds between each autosave.</returns>
        public static int GetBackupFrequency()
        {
            int backupFrequency = 0;

            try
            {
                using (StreamReader streamReader =
                    new StreamReader(Constants.MainFolder + Constants.SettingsFile))
                {
                    while (!streamReader.EndOfStream)
                    {
                        string[] line = streamReader.ReadLine().Split(Constants.UserSettingsSeparator);
                        if (line[0] == Constants.BackupString &&
                            line.Length == 2 &&
                            int.TryParse(line[1], out backupFrequency) &&
                            Array.IndexOf(Constants.BackupFrequenciesInSeconds, backupFrequency) != -1)
                        {
                            break;
                        }
                    }
                }
            }
            catch
            {
                return Constants.DefaultBackupFrequencyValue;
            }

            return backupFrequency;
        }
        /// <summary>
        /// Retrieves the previously selected colour theme.
        /// </summary>
        /// <returns>0, for Light Theme; 1, for Dark Theme.</returns>
        public static int GetColourTheme()
        {
            int colourTheme = Constants.DefaultColourTheme;

            try
            {
                using (StreamReader streamReader =
                    new StreamReader(Constants.MainFolder + Constants.SettingsFile))
                {
                    while (!streamReader.EndOfStream)
                    {
                        string[] line = streamReader.ReadLine().Split(Constants.UserSettingsSeparator);
                        if (line[0] == Constants.ColourThemeString &&
                            line.Length == 2 &&
                            int.TryParse(line[1], out colourTheme) &&
                            colourTheme >= 0 &&
                            colourTheme < Constants.ColourThemeQuantity)
                        {
                            break;
                        }
                    }
                }
            }
            catch
            {
                return Constants.DefaultColourTheme;
            }

            return colourTheme;
        }
        /// <summary>
        /// Retrieves the previously selected Window size.
        /// </summary>
        /// <returns>The size of the Window used in the previous session.</returns>
        public static Size GetWindowSize()
        {
            int[] maxSize =
                { SystemInformation.PrimaryMonitorSize.Width,
                SystemInformation.PrimaryMonitorSize.Height };
            int[] size = new int[2] { -1, -1 };

            try
            {
                using (StreamReader streamReader =
                    new StreamReader(Constants.MainFolder + Constants.SettingsFile))
                {
                    while (!streamReader.EndOfStream)
                    {
                        string[] line = streamReader.ReadLine().Split(Constants.UserSettingsSeparator);
                        if (line[0] == Constants.WindowSizeString &&
                            line.Length == 3)
                        {
                            bool isCorrect = true;
                            for (int i = 1; (i < line.Length) && isCorrect; i++)
                            {
                                if (!int.TryParse(line[i], out size[i - 1]) ||
                                    size[i - 1] < maxSize[i - 1] / 2 ||
                                    size[i - 1] > maxSize[i - 1])
                                {
                                    isCorrect = false;
                                }
                            }
                            if (isCorrect)
                            {
                                break;
                            }
                        }
                    }
                }
            }
            catch
            {
                return SystemInformation.PrimaryMonitorSize / 2;
            }

            if (size[0] != -1 && size[1] != -1)
            {
                return new Size(size[0], size[1]);
            }
            return SystemInformation.PrimaryMonitorSize / 2;
        }
        /// <summary>
        /// Changes the properties of NotepadMainWindow according to the previously
        /// selected highlight colours.
        /// </summary>
        public static void GetHighlightColours()
        {
            try
            {
                List<Color> colours = new List<Color>();
                using (StreamReader streamReader =
                    new StreamReader(Constants.MainFolder + Constants.HighlightSettingsFile))
                {
                    while (!streamReader.EndOfStream)
                    {
                        string colour = streamReader.ReadLine();
                        colours.Add(Color.FromArgb(int.Parse(colour)));
                    }
                }
                Settings.AttributeColour = colours[0];
                Settings.ClassColour = colours[1];
                Settings.CommentColour = colours[2];
                Settings.CommentTagColour = colours[3];
                Settings.KeywordColour = colours[4];
                Settings.NumberColour = colours[5];
                Settings.StringColour = colours[6];
                Settings.VariableColour = colours[7];
                NotepadMainWindow.AttributeStyle =
                    new TextStyle(new SolidBrush(Settings.AttributeColour), null, FontStyle.Regular);
                NotepadMainWindow.ClassStyle =
                    new TextStyle(new SolidBrush(Settings.ClassColour), null, FontStyle.Regular);
                NotepadMainWindow.CommentStyle =
                    new TextStyle(new SolidBrush(Settings.CommentColour), null, FontStyle.Regular);
                NotepadMainWindow.CommentTagStyle =
                    new TextStyle(new SolidBrush(Settings.CommentTagColour), null, FontStyle.Regular);
                NotepadMainWindow.KeywordStyle =
                    new TextStyle(new SolidBrush(Settings.KeywordColour), null, FontStyle.Regular);
                NotepadMainWindow.NumberStyle =
                    new TextStyle(new SolidBrush(Settings.NumberColour), null, FontStyle.Regular);
                NotepadMainWindow.StringStyle =
                    new TextStyle(new SolidBrush(Settings.StringColour), null, FontStyle.Regular);
                NotepadMainWindow.VariableStyle =
                    new TextStyle(new SolidBrush(Settings.VariableColour), null, FontStyle.Regular);
            }
            catch { };
        }

        /// <summary>
        /// Rewrites the User Settings file.
        /// </summary>
        /// <param name="colourTheme">The colour theme value.</param>
        /// <param name="windowWidth">The width of the window (in pixels).</param>
        /// <param name="windowHeight">The height of the window (in pixels).</param>
        /// <param name="autosaveFrequency">The time between each autosave (in seconds).</param>
        /// <param name="backupFrequency">The time between each backup (in seconds).</param>
        /// <param name="tabControl">The tab control.</param>
        public static void RefreshSettings(int colourTheme, int windowWidth, int windowHeight,
            int autosaveFrequency, int backupFrequency, TabControl tabControl, bool hasError = false)
        {
            if (!Directory.Exists(Constants.MainFolder))
            {
                Directory.CreateDirectory(Constants.MainFolder);
            }

            using (StreamWriter sw = new StreamWriter(Constants.MainFolder + Constants.SettingsFile))
            {
                sw.WriteLine(Constants.ColourThemeString + Constants.UserSettingsSeparator
                    + colourTheme.ToString());
                sw.WriteLine(Constants.WindowSizeString + Constants.UserSettingsSeparator
                    + windowWidth.ToString() + Constants.UserSettingsSeparator
                    + windowHeight.ToString());
                sw.WriteLine(Constants.AutosaveString + Constants.UserSettingsSeparator
                    + autosaveFrequency.ToString());
                sw.WriteLine(Constants.BackupString + Constants.UserSettingsSeparator
                    + backupFrequency.ToString());
            }
            if (!hasError)
            {
                using (StreamWriter sw = new StreamWriter(Constants.MainFolder + Constants.PreviouslyOpenFilesFile))
                {
                    foreach (TabPage item in tabControl.TabPages)
                    {
                        sw.WriteLine(item.Name);
                    }
                }
            }
            if (!hasError)
            {
                using (StreamWriter sw = new StreamWriter(Constants.MainFolder + Constants.HighlightSettingsFile))
                {
                    sw.WriteLine(Settings.AttributeColour.ToArgb().ToString());
                    sw.WriteLine(Settings.ClassColour.ToArgb().ToString());
                    sw.WriteLine(Settings.CommentColour.ToArgb().ToString());
                    sw.WriteLine(Settings.CommentTagColour.ToArgb().ToString());
                    sw.WriteLine(Settings.KeywordColour.ToArgb().ToString());
                    sw.WriteLine(Settings.NumberColour.ToArgb().ToString());
                    sw.WriteLine(Settings.StringColour.ToArgb().ToString());
                    sw.WriteLine(Settings.VariableColour.ToArgb().ToString());
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(Constants.MainFolder + Constants.HighlightSettingsFile))
                {
                    sw.WriteLine(Constants.DefaultAttributeColour.ToArgb().ToString());
                    sw.WriteLine(Constants.DefaultClassColour.ToArgb().ToString());
                    sw.WriteLine(Constants.DefaultCommentColour.ToArgb().ToString());
                    sw.WriteLine(Constants.DefaultCommentTagColour.ToArgb().ToString());
                    sw.WriteLine(Constants.DefaultKeywordColour.ToArgb().ToString());
                    sw.WriteLine(Constants.DefaultNumberColour.ToArgb().ToString());
                    sw.WriteLine(Constants.DefaultStringColour.ToArgb().ToString());
                    sw.WriteLine(Constants.DefaultVariableColour.ToArgb().ToString());
                }
            }
        }

    }

}