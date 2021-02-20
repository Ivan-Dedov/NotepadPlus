using System.Drawing;
using System.Text;

namespace NotepadPlus
{

    /// <summary>
    /// Contains the constants used in the project.
    /// </summary>
    public static class Constants
    {

        /// <summary>
        /// String values for autosave frequencies.
        /// </summary>
        public static readonly string[] AutosaveFrequencies =
        {
            "None", "30s", "1m", "2m", "5m", "10m", "20m", "30m", "1h"
        };
        /// <summary>
        /// Integer values for autosave frequencies (in seconds).
        /// </summary>
        public static readonly int[] AutosaveFrequenciesInSeconds =
        {
            0, 30, 60, 120, 300, 600, 1200, 1800, 3600
        };
        /// <summary>
        /// The default value for autosave frequency (in seconds).
        /// </summary>
        public static readonly int DefaultAutosaveFrequencyValue = AutosaveFrequenciesInSeconds[0];

        /// <summary>
        /// String values for backup frequencies.
        /// </summary>
        public static readonly string[] BackupFrequencies =
        {
            "None", "45s", "10m", "20m", "30m", "1h", "2h"
        };
        /// <summary>
        /// Integer values for backup frequencies (in seconds).
        /// </summary>
        public static readonly int[] BackupFrequenciesInSeconds =
        {
            0, 45, 600, 1200, 1800, 3600, 7200
        };
        /// <summary>
        /// The default valye for backup frequency (in seconds).
        /// </summary>
        public static readonly int DefaultBackupFrequencyValue = BackupFrequenciesInSeconds[0];

        /// <summary>
        /// The string prefix for the autosave frequency line in the User Settings file.
        /// </summary>
        public static readonly string AutosaveString = "Autosave";
        /// <summary>
        /// The string prefix for the backup frequency line in the User Settings file.
        /// </summary>
        public static readonly string BackupString = "Backup";
        /// <summary>
        /// The string prefix for the colour theme line in the User Settings file.
        /// </summary>
        public static readonly string ColourThemeString = "ColourTheme";
        /// <summary>
        /// The string prefix for the window size line in the User Settings file.
        /// </summary>
        public static readonly string WindowSizeString = "WindowSize";
        /// <summary>
        /// The separator string used in the User Settings file.
        /// </summary>
        public static readonly string UserSettingsSeparator = " ";

        /// <summary>
        /// The colour values for the primary background colour.
        /// 0 - Light Theme, 1 - Dark Theme.
        /// </summary>
        public static readonly Color[] BackgroundPrimaryColour =
        {
            Color.White,
            Color.FromArgb(32, 32, 32)
        };
        /// <summary>
        /// The colour values for the secondary background colour.
        /// 0 - Light Theme, 1 - Dark Theme.
        /// </summary>
        public static readonly Color[] BackgroundSecondaryColour =
        {
            Color.FromArgb(220, 220, 220),
            Color.FromArgb(64, 64, 64)
        };
        /// <summary>
        /// The colour values for the foreground colour.
        /// 0 - Light Theme, 1 - Dark Theme.
        /// </summary>
        public static readonly Color[] ForeColour =
        {
            Color.Black,
            Color.White
        };
        /// <summary>
        /// The quantity of colour themes.
        /// </summary>
        public static readonly int ColourThemeQuantity = 2;
        /// <summary>
        /// The default value for the colour theme.
        /// </summary>
        public static readonly int DefaultColourTheme = 0;

        /// <summary>
        /// The directory of autosave files.
        /// </summary>
        public static readonly string AutosaveDirectory = @"saves\";
        /// <summary>
        /// The directory of backup files.
        /// </summary>
        public static readonly string BackupDirectory = @"backups\";
        /// <summary>
        /// The name of the file containing the highlight colours.
        /// </summary>
        public static readonly string HighlightSettingsFile = @"highlightSettings.svd";
        /// <summary>
        /// The directory of all the custom program files.
        /// </summary>
        public static readonly string MainFolder = @"notepadFiles\";
        /// <summary>
        /// The name of the file containing the directories of the files opened in the previous session.
        /// </summary>
        public static readonly string PreviouslyOpenFilesFile = @"previouslyOpenFiles.svd";
        /// <summary>
        /// The name of the User Settings file.
        /// </summary>
        public static readonly string SettingsFile = @"userSettings.svd";

        /// <summary>
        /// The height of the Close Tab Button (in pixels).
        /// </summary>
        public static readonly int CloseAreaHeight = 15;
        /// <summary>
        /// The width of the Close Tab Button (in pixels).
        /// </summary>
        public static readonly int CloseAreaWidth = 20;
        /// <summary>
        /// The size of the symbol for the TabPage Close Button (in points).
        /// </summary>
        public static readonly int CloseSymbolSize = 9;
        /// <summary>
        /// The symbol for the TabPage Close Button.
        /// </summary>
        public static readonly string CloseSymbol = "\u2715";

        /// <summary>
        /// Available font sizes (in points).
        /// </summary>
        public static readonly int[] FontSizes =
        {
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 16, 18, 20,
            22, 24, 26, 28, 30, 32, 36, 40, 44, 48, 52, 56, 60, 72,
            80, 90, 100, 120, 144
        };

        /// <summary>
        /// The duration that the save message in the status strip is visible for (in seconds).
        /// </summary>
        public static readonly float SaveMessageVisibilityDuraion = 7.5f;

        /// <summary>
        /// The size of the Settings Window.
        /// </summary>
        public static readonly Size SettingsWindowSize = new Size(800, 500);

        /// <summary>
        /// The width of the closing area of a TabPage.
        /// </summary>
        public static readonly int CloseArea = 15;
        /// <summary>
        /// The width of the closing spacing area of a TabPage.
        /// </summary>
        public static readonly int CloseSpace = 15;
        /// <summary>
        /// The width of the leading area of a TabPage.
        /// </summary>
        public static readonly int LeadingSpace = 12;

        /// <summary>
        /// The left offset of a TabPage.
        /// </summary>
        public static readonly int LeftBoundDelta = 5;
        /// <summary>
        /// The right offset of a TabPage.
        /// </summary>
        public static readonly int RightBoundDelta = -20;
        /// <summary>
        /// The top offset of a TabPage.
        /// </summary>
        public static readonly int TopBoundDelta = 3;
        /// <summary>
        /// The top offset of a TabPage name.
        /// </summary>
        public static readonly int TopBoundDeltaName = 2;

        /// <summary>
        /// The text of the message displayed when all files are autosaved.
        /// </summary>
        public static readonly string AllFilesSavedMessage = "All open files were saved.";
        /// <summary>
        /// The separator used in the backed up file names.
        /// </summary>
        public static readonly string BackupNameSeparator = "_";
        /// <summary>
        /// The default name of a TabPage.
        /// </summary>
        public static readonly string DefaultTabPageName = "TabPage";
        /// <summary>
        /// The default text of a TabPage.
        /// </summary>
        public static readonly string DefaultTabPageText = "New Document";

        /// <summary>
        /// The .cs extension string.
        /// </summary>
        public static readonly string ExtensionCS = ".cs";
        /// <summary>
        /// The .rtf extension string.
        /// </summary>
        public static readonly string ExtensionRTF = ".rtf";
        /// <summary>
        /// The .txt extension string.
        /// </summary>
        public static readonly string ExtensionTXT = ".txt";

        /// <summary>
        /// The default Encoding.
        /// </summary>
        public static readonly Encoding DefaultEncoding = Encoding.Unicode;

        /// <summary>
        /// The default Attribute colour.
        /// </summary>
        public static readonly Color DefaultAttributeColour = Color.DarkCyan;
        /// <summary>
        /// The default Class name colour.
        /// </summary>
        public static readonly Color DefaultClassColour = Color.DarkCyan;
        /// <summary>
        /// The default Comment text colour.
        /// </summary>
        public static readonly Color DefaultCommentColour = Color.Green;
        /// <summary>
        /// The default Comment tag colour.
        /// </summary>
        public static readonly Color DefaultCommentTagColour = Color.Green;
        /// <summary>
        /// The default Keyword colour.
        /// </summary>
        public static readonly Color DefaultKeywordColour = Color.Blue;
        /// <summary>
        /// The default Number literal colour.
        /// </summary>
        public static readonly Color DefaultNumberColour = Color.YellowGreen;
        /// <summary>
        /// The default String literal colour.
        /// </summary>
        public static readonly Color DefaultStringColour = Color.Orange;
        /// <summary>
        /// The default Variable colour.
        /// </summary>
        public static readonly Color DefaultVariableColour = Color.DarkCyan;

    }

}