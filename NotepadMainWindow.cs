using FastColoredTextBoxNS;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Formatting;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.CodeAnalysis.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace NotepadPlus
{

    /// <summary>
    /// The main Notepad+ Window.
    /// </summary>
    public partial class NotepadMainWindow : Form
    {

        /// <summary>
        /// The List of user fonts.
        /// </summary>
        private readonly List<FontFamily> userFonts = new List<FontFamily>(FontFamily.Families.Length);

        /// <summary>
        /// The selected colour theme: 0, Light (default); 1, Dark.
        /// </summary>
        private static int colourTheme = UserSettingsReader.GetColourTheme();
        /// <summary>
        /// The index of the new Tab.
        /// </summary>
        private static int newTabPageIndex = 0;

        /// <summary>
        /// Attribute highlight Style.
        /// </summary>
        public static Style AttributeStyle { get; set; } =
            new TextStyle(new SolidBrush(Settings.AttributeColour), null, FontStyle.Regular);
        /// <summary>
        /// Class highlight Style.
        /// </summary>
        public static Style ClassStyle { get; set; } =
            new TextStyle(new SolidBrush(Settings.ClassColour), null, FontStyle.Regular);
        /// <summary>
        /// Comment highlight Style.
        /// </summary>
        public static Style CommentStyle { get; set; } =
            new TextStyle(new SolidBrush(Settings.CommentColour), null, FontStyle.Regular);
        /// <summary>
        /// Comment Tag highlight Style.
        /// </summary>
        public static Style CommentTagStyle { get; set; } =
            new TextStyle(new SolidBrush(Settings.CommentTagColour), null, FontStyle.Regular);
        /// <summary>
        /// Keyword highlight Style.
        /// </summary>
        public static Style KeywordStyle { get; set; } =
            new TextStyle(new SolidBrush(Settings.KeywordColour), null, FontStyle.Regular);
        /// <summary>
        /// Number highlight Style.
        /// </summary>
        public static Style NumberStyle { get; set; } =
            new TextStyle(new SolidBrush(Settings.NumberColour), null, FontStyle.Regular);
        /// <summary>
        /// String highlight Style.
        /// </summary>
        public static Style StringStyle { get; set; } =
            new TextStyle(new SolidBrush(Settings.StringColour), null, FontStyle.Regular);
        /// <summary>
        /// Variable highlight Style.
        /// </summary>
        public static Style VariableStyle { get; set; } =
            new TextStyle(new SolidBrush(Settings.VariableColour), null, FontStyle.Regular);

        /// <summary>
        /// The Timer used for showing and hiding the save file message.
        /// </summary>
        private static Timer messageTimer;


        /// <summary>
        /// The time between each autosave (in seconds).
        /// </summary>
        public static int AutosaveFrequency { get; set; } = UserSettingsReader.GetAutosaveFrequency();
        /// <summary>
        /// The time between each backup (in seconds).
        /// </summary>
        public static int BackupFrequency { get; set; } = UserSettingsReader.GetBackupFrequency();

        /// <summary>
        /// The Timer used for detecting whether autosave time has elapsed.
        /// </summary>
        public static Timer AutosaveTimer { get; set; }
        /// <summary>
        /// The Timer used for detecting whether backup time has elapsed.
        /// </summary>
        public static Timer BackupTimer { get; set; }


        /// <summary>
        /// Creates a new Notepad+ window.
        /// </summary>
        public NotepadMainWindow()
        {
            InitializeComponent();

            // Changing the Window size.
            MaximumSize = SystemInformation.PrimaryMonitorSize;
            MinimumSize = SystemInformation.PrimaryMonitorSize / 2;
            Size = UserSettingsReader.GetWindowSize();
            if (Size == SystemInformation.PrimaryMonitorSize)
            {
                WindowState = FormWindowState.Maximized;
            }

            // Changing the colour theme.
            colourTheme = UserSettingsReader.GetColourTheme();
            if (colourTheme == 0)
            {
                LightTheme_MenuItem.Checked = true;
            }
            else if (colourTheme == 1)
            {
                DarkTheme_MenuItem.Checked = true;
            }
            UpdateColours();

            // If autosave and backup is not "None", creates a timer.
            if (AutosaveFrequency != 0)
            {
                AutosaveTimer = new Timer
                {
                    Interval = AutosaveFrequency * 1000
                };
                AutosaveTimer.Start();
                AutosaveTimer.Tick += new EventHandler(AutosaveTimerEventProcessor);
            }
            if (BackupFrequency != 0)
            {
                BackupTimer = new Timer
                {
                    Interval = BackupFrequency * 1000
                };
                BackupTimer.Start();
                BackupTimer.Tick += new EventHandler(BackupTimerEventProcessor);
            }

            // Adding the fonts to the font list.
            userFonts = new List<FontFamily>(FontFamily.Families.Length);
            foreach (var item in FontFamily.Families)
            {
                userFonts.Add(item);
                FontSelector_ComboBox.Items.Add(item.Name);
            }
            FontSize_ComboBox.Items.AddRange(Array.ConvertAll(Constants.FontSizes, x => x.ToString()));
            FontSize_ContextComboBox.Items.AddRange(Array.ConvertAll(Constants.FontSizes, x => x.ToString()));
            FontSelector_ComboBox.SelectedItem = DefaultFont;
            FontSize_ComboBox.SelectedItem = (int)DefaultFont.SizeInPoints;

            UserSettingsReader.GetHighlightColours();

            // Opening files that were opened in the previous session.
            if (!OpenPreviouslyOpenedFiles())
            {
                AddNewTabPage(Constants.ExtensionRTF);
            }
        }


        /// <summary>
        /// Opens the files that were not closed in the last session (if they still exist).
        /// </summary>
        /// <returns>true, if any files have been opened; false, otherwise.</returns>
        private bool OpenPreviouslyOpenedFiles()
        {
            bool haveOpenedFiles = false;
            try
            {
                using (StreamReader streamReader =
                    new StreamReader(Constants.MainFolder + Constants.PreviouslyOpenFilesFile))
                {
                    while (!streamReader.EndOfStream)
                    {
                        string filePath = streamReader.ReadLine();
                        if (File.Exists(filePath))
                        {
                            if (Path.GetExtension(filePath) == Constants.ExtensionRTF)
                            {
                                AddNewTabPage(Constants.ExtensionRTF, filePath);
                                (Documents_TabControl.TabPages[^1].Controls[0] as RichTextBox)
                                    .LoadFile(filePath);
                                haveOpenedFiles = true;
                            }
                            else if (Path.GetExtension(filePath) == Constants.ExtensionTXT)
                            {
                                AddNewTabPage(Constants.ExtensionTXT, filePath);
                                string fileContents = string.Empty;
                                using (StreamReader reader = new StreamReader(filePath))
                                {
                                    fileContents = reader.ReadToEnd();
                                }
                                (Documents_TabControl.TabPages[^1].Controls[0] as RichTextBox).Text =
                                    fileContents;
                                haveOpenedFiles = true;
                            }
                            else if (Path.GetExtension(filePath) == Constants.ExtensionCS)
                            {
                                string fileContents = string.Empty;
                                using (StreamReader reader = new StreamReader(filePath))
                                {
                                    fileContents = reader.ReadToEnd();
                                }
                                AddNewTabPage(Constants.ExtensionCS, filePath);
                                (Documents_TabControl.TabPages[^1].Controls[0] as FastColoredTextBox).Text =
                                    fileContents;
                                haveOpenedFiles = true;
                            }
                        }
                    }
                }
            }
            catch { };
            return haveOpenedFiles;
        }

        /// <summary>
        /// Creates a new ContextMenuStrip depending on the type of TextBox.
        /// </summary>
        /// <param name="isFastColouredTextBox">true, if the TextBox is FastColoredTextBox; false, otherwise.</param>
        /// <returns>A ContextMenuStrip with the necessary functions.</returns>
        private ContextMenuStrip GetContextMenu(bool isFastColouredTextBox)
        {
            // Creating MenuItems present in both types of Context Menus.
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            ToolStripMenuItem SelectAll_ContextMenuItem = new ToolStripMenuItem()
            {
                Name = "SelectAll_ContextMenuItem",
                Text = "Select All"
            };
            ToolStripMenuItem Cut_ContextMenuItem = new ToolStripMenuItem()
            {
                Name = "Cut_ContextMenuItem",
                Text = "Cut"
            };
            ToolStripMenuItem Copy_ContextMenuItem = new ToolStripMenuItem()
            {
                Name = "Copy_ContextMenuItem",
                Text = "Copy"
            };
            ToolStripMenuItem Paste_ContextMenuItem = new ToolStripMenuItem()
            {
                Name = "Paste_ContextMenuItem",
                Text = "Paste"
            };
            SelectAll_ContextMenuItem.Click += SelectAll_ContextMenuItem_Click;
            Cut_ContextMenuItem.Click += Cut_ContextMenuItem_Click;
            Copy_ContextMenuItem.Click += Copy_ContextMenuItem_Click;
            Paste_ContextMenuItem.Click += Paste_ContextMenuItem_Click;

            // Creating items depending on the type of the TextBox.
            if (isFastColouredTextBox)
            {
                ToolStripMenuItem Format_ContextMenuItem = new ToolStripMenuItem()
                {
                    Name = "Format_ContextMenuItem",
                    Text = "Format Code"
                };
                Format_ContextMenuItem.Click += FormatCode_ContextMenuItem_Click;
                contextMenuStrip.Items.AddRange(new ToolStripItem[]
                {
                    SelectAll_ContextMenuItem,
                    Cut_ContextMenuItem,
                    Copy_ContextMenuItem,
                    Paste_ContextMenuItem,
                    Format_ContextMenuItem
                });
                contextMenuStrip.Opening += ContextMenu_Opening;
            }
            else
            {
                ToolStripSeparator Separator1_ContextMenuItem = new ToolStripSeparator()
                {
                    Name = "ToolStripSeparator_Context_1"
                };
                ToolStripComboBox FontSelector_ContextMenuItem = new ToolStripComboBox()
                {
                    Name = "FontSelector_ContextComboBox",
                    AutoSize = false,
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    FlatStyle = FlatStyle.Popup,
                    Height = 30,
                    Width = 250
                };
                ToolStripComboBox FontSize_ContextMenuItem = new ToolStripComboBox()
                {
                    Name = "FontSize_ContextComboBox",
                    AutoSize = false,
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    FlatStyle = FlatStyle.Popup,
                    Height = 30,
                    Width = 50
                };
                ToolStripSeparator Separator2_ContextMenuItem = new ToolStripSeparator()
                {
                    Name = "ToolStripSeparator_Context_2"
                };
                ToolStripMenuItem Bold_ContextMenuItem = new ToolStripMenuItem()
                {
                    Name = "Bold_ContextMenuItem",
                    Text = "Bold"
                };
                ToolStripMenuItem Italics_ContextMenuItem = new ToolStripMenuItem()
                {
                    Name = "Italics_ContextMenuItem",
                    Text = "Italics"
                };
                ToolStripMenuItem Underlined_ContextMenuItem = new ToolStripMenuItem()
                {
                    Name = "Underlined_ContextMenuItem",
                    Text = "Underlined"
                };
                ToolStripMenuItem Strikethrough_ContextMenuItem = new ToolStripMenuItem()
                {
                    Name = "Strikethrough_ContextMenuItem",
                    Text = "Strikethrough"
                };
                ToolStripSeparator Separator3_ContextMenuItem = new ToolStripSeparator()
                {
                    Name = "ToolStripSeparator_Context_3"
                };
                ToolStripMenuItem FontColour_ContextMenuItem = new ToolStripMenuItem()
                {
                    Name = "FontColour_ContextMenuItem",
                    Text = "Font Colour"
                };
                FontSelector_ContextMenuItem.SelectedIndexChanged +=
                    FontSelector_ContextComboBox_SelectedIndexChanged;
                FontSize_ContextMenuItem.SelectedIndexChanged +=
                    FontSize_ContextComboBox_SelectedIndexChanged;
                Bold_ContextMenuItem.Click += Bold_ContextMenuItem_Click;
                Italics_ContextMenuItem.Click += Italics_ContextMenuItem_Click;
                Underlined_ContextMenuItem.Click += Underlined_ContextMenuItem_Click;
                Strikethrough_ContextMenuItem.Click += Strikethrough_ContextMenuItem_Click;
                FontColour_ContextMenuItem.Click += FontColour_ContextMenuItem_Click;

                contextMenuStrip.Items.AddRange(new ToolStripItem[]
                {
                    SelectAll_ContextMenuItem,
                    Cut_ContextMenuItem,
                    Copy_ContextMenuItem,
                    Paste_ContextMenuItem,
                    Separator1_ContextMenuItem,
                    FontSelector_ContextMenuItem,
                    FontSize_ContextMenuItem,
                    Separator2_ContextMenuItem,
                    Bold_ContextMenuItem,
                    Italics_ContextMenuItem,
                    Underlined_ContextMenuItem,
                    Strikethrough_ContextMenuItem,
                    Separator3_ContextMenuItem,
                    FontColour_ContextMenuItem
                });
                foreach (var item in userFonts)
                {
                    (contextMenuStrip.Items[5] as ToolStripComboBox).Items.Add(item.Name);
                }
                foreach (var item in Constants.FontSizes)
                {
                    (contextMenuStrip.Items[6] as ToolStripComboBox).Items.Add(item.ToString());
                }
                contextMenuStrip.Opening += ContextMenu_Opening;
            }
            return contextMenuStrip;
        }

        /// <summary>
        /// Checks and returns the font size value from a string.
        /// </summary>
        /// <param name="text">The text to be checked and interpreted as a valid font size.</param>
        /// <returns>The integer value of a font size.</returns>
        private float GetFontSize(string text)
        {
            int fontSize;

            if (!int.TryParse(text, out int newFontSize) ||
                newFontSize < Constants.FontSizes[0] ||
                newFontSize > Constants.FontSizes[^1])
            {
                fontSize = (int)DefaultFont.SizeInPoints;
            }
            else
            {
                fontSize = newFontSize;
            }

            return fontSize;
        }

        /// <summary>
        /// Retrieves the current time.
        /// </summary>
        /// <returns>A string in the following format: "Year, Month, Day, Hours,
        /// Minutes, Seconds, Milliseconds", without any separations.</returns>
        private static string GetCurrentTime()
        {
            DateTime currentTime = DateTime.Now;
            return currentTime.Year.ToString() +
                   currentTime.Month.ToString() +
                   currentTime.Day.ToString() +
                   currentTime.Hour.ToString() +
                   currentTime.Minute.ToString() +
                   currentTime.Second.ToString() +
                   currentTime.Millisecond.ToString();
        }

        /// <summary>
        /// Formats the code of a .cs file.
        /// </summary>
        /// <returns>The formatted code of a .cs file represented as a string.</returns>
        private string GetFormattedCode()
        {
            if (Documents_TabControl.SelectedTab.Controls[0] is FastColoredTextBox)
            {
                var workspace = new AdhocWorkspace();

                OptionSet options = workspace.Options;
                options = options.WithChangedOption(CSharpFormattingOptions.NewLinesForBracesInMethods, true);
                options = options.WithChangedOption(CSharpFormattingOptions.NewLinesForBracesInProperties, true);

                CompilationUnitSyntax compilationUnit =
                    CSharpSyntaxTree.ParseText(
                        (Documents_TabControl.SelectedTab.Controls[0] as FastColoredTextBox).Text
                        ).GetCompilationUnitRoot();

                SyntaxNode formattedNode = Formatter.Format(compilationUnit, workspace, options);

                var sb = new StringBuilder();
                using (var writer = new StringWriter(sb))
                {
                    formattedNode.WriteTo(writer);
                }

                return sb.ToString();
            }
            return string.Empty;
        }

        /// <summary>
        /// Creates a TabPage.
        /// </summary>
        /// <param name="tabPageName">The name of the TabPage.</param>
        /// <returns>The TabPage with the desired name (default name, if none specified).</returns>
        private TabPage GetTabPage(string tabPageName)
        {
            TabPage newTabPage;

            // If no file name is specified.
            if (tabPageName == string.Empty)
            {
                // Creating a tab without an index.
                if (newTabPageIndex == 0)
                {
                    newTabPage = new TabPage()
                    {
                        Name = Constants.DefaultTabPageName + newTabPageIndex,
                        Text = Constants.DefaultTabPageText
                    };
                }
                else
                {
                    newTabPage = new TabPage()
                    {
                        Name = Constants.DefaultTabPageName + newTabPageIndex,
                        Text = Constants.DefaultTabPageText + " (" + newTabPageIndex + ")"
                    };
                }
                newTabPageIndex++;
            }
            // If file name is specified.
            else
            {
                newTabPage = new TabPage()
                {
                    Name = tabPageName,
                    Text = Path.GetFileName(tabPageName)
                };
            }

            return newTabPage;
        }

        /// <summary>
        /// Adds a new TabPage.
        /// </summary>
        /// <param name="fileExtension">The extension of the file to be opened in the TabPage.</param>
        /// <param name="tabPageName">The name of the TabPage. Leave empty for default name.</param>
        private void AddNewTabPage(string fileExtension, string tabPageName = "")
        {
            try
            {
                Documents_TabControl.TabPages.Add(GetTabPage(tabPageName));

                // Creating a RichTextBox if the file extension is .txt or .rtf.
                if (fileExtension == Constants.ExtensionTXT || fileExtension == Constants.ExtensionRTF)
                {
                    Documents_TabControl.TabPages[^1].Controls.Add(new RichTextBox()
                    {
                        Dock = DockStyle.Fill,
                        Name = Documents_TabControl.TabPages[^1].Name +
                               Path.GetExtension(Documents_TabControl.TabPages[^1].Text),
                        Font = DefaultFont
                    });
                    (Documents_TabControl.TabPages[^1].Controls[0] as RichTextBox).TextChanged += CreateNewUndo;
                }
                // Creating a FastColouredTextBox if the file extension is .cs.
                else if (fileExtension == Constants.ExtensionCS)
                {
                    Documents_TabControl.TabPages[^1].Controls.Add(new FastColoredTextBox()
                    {
                        Dock = DockStyle.Fill,
                        Name = Documents_TabControl.TabPages[^1].Name +
                               Path.GetExtension(Documents_TabControl.TabPages[^1].Text),
                        ForeColor = Color.Black,
                        Language = Language.CSharp,
                        Font = DefaultFont,
                    });
                    (Documents_TabControl.TabPages[^1].Controls[0] as FastColoredTextBox).TextChanged += CreateNewUndo;
                    GetNewSyntaxHighlighter();
                }

                Documents_TabControl.TabPages[^1].Controls[0].ContextMenuStrip =
                    GetContextMenu(fileExtension == Constants.ExtensionCS);
                FontSelector_ComboBox.SelectedItem = DefaultFont.Name;
                FontSize_ComboBox.SelectedItem = ((int)DefaultFont.SizeInPoints).ToString();
                Documents_TabControl.SelectedTab = Documents_TabControl.TabPages[^1];
                UpdateColours();
            }
            catch { };
        }
        /// <summary>
        /// Saves all files to the corresponding directories
        /// if files have already been saved before;
        /// or to the default autosave folder, otherwise.
        /// </summary>
        private void AutosaveAllFiles()
        {
            try
            {
                SuspendLayout();
                foreach (TabPage item in Documents_TabControl.TabPages)
                {
                    // Runs if file has not been saved yet.
                    if (item.Name.Length >= Constants.DefaultTabPageName.Length &&
                        item.Text.Length >= Constants.DefaultTabPageText.Length &&
                        item.Name[0..Constants.DefaultTabPageName.Length] == Constants.DefaultTabPageName &&
                        item.Text[0..Constants.DefaultTabPageText.Length] == Constants.DefaultTabPageText)
                    {
                        if (!Directory.Exists(Constants.MainFolder + Constants.AutosaveDirectory))
                        {
                            Directory.CreateDirectory(Constants.MainFolder + Constants.AutosaveDirectory);
                        }
                        if (item.Controls[0] is RichTextBox)
                        {
                            (item.Controls[0] as RichTextBox)
                                .SaveFile(Constants.MainFolder + Constants.AutosaveDirectory +
                                Path.GetFileNameWithoutExtension(item.Text) + Constants.ExtensionRTF,
                                RichTextBoxStreamType.RichText);
                        }
                        else if (item.Controls[0] is FastColoredTextBox)
                        {
                            (item.Controls[0] as FastColoredTextBox)
                                .SaveToFile(Constants.MainFolder + Constants.AutosaveDirectory +
                                Path.GetFileNameWithoutExtension(item.Text) + Constants.ExtensionCS,
                                Constants.DefaultEncoding);
                        }
                    }
                    // Runs if file was already saved somewhere.
                    else
                    {
                        if (Path.GetExtension(Documents_TabControl.SelectedTab.Name) == Constants.ExtensionTXT)
                        {
                            if (item.Controls[0] is RichTextBox)
                            {
                                (item.Controls[0] as RichTextBox)
                                    .SaveFile(item.Name, RichTextBoxStreamType.PlainText);
                            }
                        }
                        else if (Path.GetExtension(Documents_TabControl.SelectedTab.Name) == Constants.ExtensionRTF)
                        {
                            if (item.Controls[0] is RichTextBox)
                            {
                                (item.Controls[0] as RichTextBox)
                                    .SaveFile(item.Name, RichTextBoxStreamType.RichText);
                            }
                        }
                        else if (Path.GetExtension(Documents_TabControl.SelectedTab.Name) == Constants.ExtensionCS)
                        {
                            if (item.Controls[0] is FastColoredTextBox)
                            {
                                (item.Controls[0] as FastColoredTextBox)
                                    .SaveToFile(item.Name, Constants.DefaultEncoding);
                            }
                        }

                        int index = -1;
                        foreach (TabPage item2 in Documents_TabControl.TabPages)
                        {
                            if (item2.Name == Documents_TabControl.SelectedTab.Name)
                            {
                                index++;
                                break;
                            }
                            index++;
                        }
                        Documents_TabControl.TabPages[index].Name = Documents_TabControl.SelectedTab.Name;
                        Documents_TabControl.TabPages[index].Text = Path.GetFileName(Documents_TabControl.SelectedTab.Text);
                        Documents_TabControl.Invalidate();
                    }
                }
                ResumeLayout();
            }
            catch { };
        }
        /// <summary>
        /// Backs up all open and saved files.
        /// </summary>
        private void BackupAllFiles()
        {
            try
            {
                SuspendLayout();
                foreach (TabPage item in Documents_TabControl.TabPages)
                {
                    if (!Directory.Exists(Constants.MainFolder + Constants.BackupDirectory))
                    {
                        DirectoryInfo directory =
                            Directory.CreateDirectory(Constants.MainFolder + Constants.BackupDirectory);
                        directory.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                    }
                    if (Path.GetExtension(item.Name) == Constants.ExtensionTXT)
                    {
                        (item.Controls[0] as RichTextBox)
                                .SaveFile(Constants.MainFolder + Constants.BackupDirectory +
                                Path.GetFileNameWithoutExtension(item.Name) + Constants.BackupNameSeparator +
                                GetCurrentTime() + Constants.ExtensionTXT,
                                RichTextBoxStreamType.PlainText);
                    }
                    else if (Path.GetExtension(item.Name) == Constants.ExtensionRTF)
                    {
                        (item.Controls[0] as RichTextBox)
                                .SaveFile(Constants.MainFolder + Constants.BackupDirectory +
                                Path.GetFileNameWithoutExtension(item.Name) + Constants.BackupNameSeparator +
                                GetCurrentTime() + Constants.ExtensionRTF,
                                RichTextBoxStreamType.RichText);
                    }
                    else if (Path.GetExtension(item.Name) == Constants.ExtensionCS)
                    {
                        (item.Controls[0] as FastColoredTextBox)
                                .SaveToFile(Constants.MainFolder + Constants.BackupDirectory +
                                Path.GetFileNameWithoutExtension(item.Name) + Constants.BackupNameSeparator +
                                GetCurrentTime() + Constants.ExtensionCS,
                                Constants.DefaultEncoding);
                    }
                }
                ResumeLayout();
            }
            catch { };
        }
        /// <summary>
        /// Handles the events after the backup timer has elapsed.
        /// </summary>
        public void BackupTimerEventProcessor(object sender, EventArgs e)
        {
            try
            {
                if (BackupTimer != null)
                {
                    BackupTimer.Stop();
                    BackupAllFiles();
                    BackupTimer.Start();
                }
            }
            catch { };
        }
        /// <summary>
        /// Handles clicking the Bold button via the Context Menu.
        /// </summary>
        private void Bold_ContextMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bold_MenuItem_Click(sender, e);
            }
            catch { };
        }
        /// <summary>
        /// Handles clicking the Bold button via the Edit Menu.
        /// </summary>
        private void Bold_MenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Documents_TabControl.TabCount > 0)
                {
                    if (Documents_TabControl.SelectedTab.Controls[0] is RichTextBox)
                    {
                        RichTextBox richTextBox = Documents_TabControl.SelectedTab.Controls[0] as RichTextBox;
                        if (richTextBox.SelectionFont != null)
                        {
                            if (richTextBox.SelectionFont.Bold)
                            {
                                richTextBox.SelectionFont = new Font(
                                    richTextBox.SelectionFont.Name,
                                    richTextBox.SelectionFont.SizeInPoints,
                                    richTextBox.SelectionFont.Style ^ FontStyle.Bold);
                            }
                            else
                            {
                                richTextBox.SelectionFont = new Font(
                                    richTextBox.SelectionFont.Name,
                                    richTextBox.SelectionFont.SizeInPoints,
                                    richTextBox.SelectionFont.Style | FontStyle.Bold);
                            }
                            Bold_MenuItem.Checked = !richTextBox.SelectionFont.Bold;
                        }
                    }
                }
            }
            catch { };
        }
        /// <summary>
        /// Handles opening the Context Menu.
        /// </summary>
        private void ContextMenu_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                if (Documents_TabControl.SelectedTab.Controls[0] is RichTextBox)
                {
                    var textBox = Documents_TabControl.SelectedTab.Controls[0] as RichTextBox;
                    if (textBox.SelectionFont != null)
                    {
                        (textBox.ContextMenuStrip.Items[5] as ToolStripComboBox).SelectedItem =
                            textBox.SelectionFont.Name;
                        (textBox.ContextMenuStrip.Items[6] as ToolStripComboBox).SelectedItem =
                            ((int)textBox.SelectionFont.SizeInPoints).ToString();
                        (textBox.ContextMenuStrip.Items[8] as ToolStripMenuItem).Checked =
                            textBox.SelectionFont.Bold;
                        (textBox.ContextMenuStrip.Items[9] as ToolStripMenuItem).Checked =
                            textBox.SelectionFont.Italic;
                        (textBox.ContextMenuStrip.Items[10] as ToolStripMenuItem).Checked =
                            textBox.SelectionFont.Underline;
                        (textBox.ContextMenuStrip.Items[11] as ToolStripMenuItem).Checked =
                            textBox.SelectionFont.Strikeout;
                    }
                }
                FontSize_ContextComboBox_SelectedIndexChanged(sender, e);
            }
            catch { };
        }
        /// <summary>
        /// Copies the selected text to Clipboard via the Context Menu.
        /// </summary>
        private void Copy_ContextMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Copy_MenuItem_Click(sender, e);
            }
            catch { };
        }
        /// <summary>
        /// Copies the selected text to Clipboard via the Edit Menu.
        /// </summary>
        private void Copy_MenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Documents_TabControl.TabCount > 0)
                {
                    if (Documents_TabControl.SelectedTab.Controls[0] is RichTextBox)
                    {
                        Clipboard.SetData(DataFormats.Rtf,
                            (Documents_TabControl.SelectedTab.Controls[0] as RichTextBox).SelectedRtf);
                    }
                    else if (Documents_TabControl.SelectedTab.Controls[0] is FastColoredTextBox)
                    {
                        Clipboard.SetData(DataFormats.Text,
                            (Documents_TabControl.SelectedTab.Controls[0] as FastColoredTextBox).SelectedText);
                    }
                }
            }
            catch { };
        }
        /// <summary>
        /// Creates a new Undo point.
        /// </summary>
        private void CreateNewUndo(object sender, EventArgs e)
        {
            try
            {
                SuspendLayout();
                if (Documents_TabControl.SelectedTab.Controls[0] is RichTextBox)
                {
                    (Documents_TabControl.SelectedTab.Controls[0] as RichTextBox).Undo();
                    (Documents_TabControl.SelectedTab.Controls[0] as RichTextBox).Redo();
                }
                ResumeLayout();
            }
            catch { };
        }
        /// <summary>
        /// Cuts the selected text to Clipboard via the Context Menu.
        /// </summary>
        private void Cut_ContextMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cut_MenuItem_Click(sender, e);
            }
            catch { };
        }
        /// <summary>
        /// Cuts the selected text to Clipboard via the Edit Menu.
        /// </summary>
        private void Cut_MenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Documents_TabControl.TabCount > 0)
                {
                    dynamic textBox;
                    if (Documents_TabControl.SelectedTab.Controls[0] is RichTextBox)
                    {
                        textBox = Documents_TabControl.SelectedTab.Controls[0] as RichTextBox;
                        Clipboard.SetData(DataFormats.Rtf,
                            textBox.SelectedRtf);
                        (Documents_TabControl.SelectedTab.Controls[0] as RichTextBox).SelectedRtf = string.Empty;
                    }
                    else if (Documents_TabControl.SelectedTab.Controls[0] is FastColoredTextBox)
                    {
                        textBox = Documents_TabControl.SelectedTab.Controls[0] as FastColoredTextBox;
                        Clipboard.SetData(DataFormats.Text,
                            textBox.SelectedText);
                        (Documents_TabControl.SelectedTab.Controls[0] as FastColoredTextBox).SelectedText = string.Empty;
                    }
                }
            }
            catch { };
        }
        /// <summary>
        /// Handles clicking on the Dark Theme Button.
        /// </summary>
        private void DarkTheme_MenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (colourTheme == 0)
                {
                    colourTheme = ++colourTheme % Constants.ColourThemeQuantity;
                    LightTheme_MenuItem.Checked = false;
                    DarkTheme_MenuItem.Checked = true;
                    UpdateColours();
                }
            }
            catch { };
        }
        /// <summary>
        /// Handles adding a new TabPage.
        /// </summary>
        private void Documents_TabControl_ControlAdded(object sender, ControlEventArgs e)
        {
            try
            {
                int tabLength = Documents_TabControl.ItemSize.Width;

                foreach (TabPage item in Documents_TabControl.TabPages)
                {
                    int currentTabLength =
                        TextRenderer.MeasureText(item.Text, Documents_TabControl.Font).Width +
                        Constants.LeadingSpace + Constants.CloseSpace + Constants.CloseArea;
                    if (currentTabLength > tabLength)
                    {
                        tabLength = currentTabLength;
                    }
                }

                Size newTabSize = new Size(tabLength, Documents_TabControl.ItemSize.Height);
                Documents_TabControl.ItemSize = newTabSize;
            }
            catch { };
        }
        /// <summary>
        /// Handles drawing an Exit Button on a TabPage.
        /// </summary>
        private void Documents_TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                e.Graphics.DrawString(Constants.CloseSymbol,
                    new Font(DefaultFont.FontFamily, Constants.CloseSymbolSize, FontStyle.Bold),
                    Brushes.Red,
                    e.Bounds.Right + Constants.RightBoundDelta,
                    e.Bounds.Top + Constants.TopBoundDelta);
                e.Graphics.DrawString(Documents_TabControl.TabPages[e.Index].Text,
                    e.Font,
                    new SolidBrush(Constants.ForeColour[0]),
                    e.Bounds.Left + Constants.LeftBoundDelta,
                    e.Bounds.Top + Constants.TopBoundDeltaName);
                e.DrawFocusRectangle();
            }
            catch { };
        }
        /// <summary>
        /// Handles clicking on the Exit Button on a TabPage.
        /// </summary>
        private void Documents_TabControl_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                for (int i = 0; i < Documents_TabControl.TabPages.Count; i++)
                {
                    Rectangle r = Documents_TabControl.GetTabRect(i);
                    Rectangle closeButton =
                        new Rectangle(r.Right + Constants.RightBoundDelta,
                        r.Top + Constants.TopBoundDelta,
                        Constants.CloseAreaWidth,
                        Constants.CloseAreaHeight);

                    if (closeButton.Contains(e.Location))
                    {
                        DialogResult closeTab = MessageBox.Show(
                            $"Would you like to save the changes in: {Documents_TabControl.TabPages[i].Text}?",
                            "Save Changes",
                            MessageBoxButtons.YesNoCancel,
                            MessageBoxIcon.Question);
                        if (closeTab == DialogResult.Yes)
                        {
                            Save_MenuItem_Click(sender, e);
                            Documents_TabControl.TabPages.RemoveAt(i);
                            break;
                        }
                        else if (closeTab == DialogResult.No)
                        {
                            Documents_TabControl.TabPages.RemoveAt(i);
                            break;
                        }
                        else if (closeTab == DialogResult.Cancel)
                        {
                            break;
                        }
                    }
                }
            }
            catch { };
        }
        /// <summary>
        /// Handles exiting the Program.
        /// </summary>
        private void Exit_MenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                NotepadMainWindow_FormClosing(sender, new FormClosingEventArgs(CloseReason.UserClosing, false));
            }
            catch { };
        }
        /// <summary>
        /// Handles clicking on the Font Colour button via the Context Menu.
        /// </summary>
        private void FontColour_ContextMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FontColour_MenuItem_Click(sender, e);
            }
            catch { };
        }
        /// <summary>
        /// Handles clicking on the Font Colour via the Format Menu.
        /// </summary>
        private void FontColour_MenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Documents_TabControl.TabCount > 0)
                {
                    ColorDialog colorDialog = new ColorDialog();
                    if (colorDialog.ShowDialog() == DialogResult.OK)
                    {
                        if (Documents_TabControl.SelectedTab.Controls[0] is RichTextBox)
                        {
                            RichTextBox textBox = Documents_TabControl.SelectedTab.Controls[0] as RichTextBox;
                            textBox.SelectionColor = colorDialog.Color;
                        }
                    }
                }
            }
            catch { };
        }
        /// <summary>
        /// Handles the font selection via the Context Menu.
        /// </summary>
        private void FontSelector_ContextComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Documents_TabControl.SelectedTab.Controls[0] is RichTextBox)
                {
                    RichTextBox textBox = Documents_TabControl.SelectedTab.Controls[0] as RichTextBox;
                    FontSelector_ComboBox.SelectedIndex =
                        (textBox.ContextMenuStrip.Items[5] as ToolStripComboBox).SelectedIndex;
                }
            }
            catch { };
        }
        /// <summary>
        /// Handles the font selection via the Format Menu.
        /// </summary>
        private void FontSelector_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Documents_TabControl.TabCount > 0)
                {
                    if (Documents_TabControl.SelectedTab.Controls[0] is RichTextBox)
                    {
                        RichTextBox textBox = Documents_TabControl.SelectedTab.Controls[0] as RichTextBox;
                        if (textBox.Text != string.Empty)
                        {
                            textBox.SelectionFont = new Font(
                                userFonts[FontSelector_ComboBox.SelectedIndex],
                                GetFontSize(FontSize_ComboBox.SelectedItem.ToString()),
                                textBox.SelectionFont.Style);
                        }
                    }
                }
            }
            catch { };
        }
        /// <summary>
        /// Handles the font size selection via the Context Menu.
        /// </summary>
        private void FontSize_ContextComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Documents_TabControl.TabCount > 0)
                {
                    if (Documents_TabControl.SelectedTab.Controls[0] is RichTextBox)
                    {
                        RichTextBox textBox = Documents_TabControl.SelectedTab.Controls[0] as RichTextBox;
                        FontSize_ComboBox.SelectedIndex =
                             (textBox.ContextMenuStrip.Items[6] as ToolStripComboBox).SelectedIndex;
                    }
                }
            }
            catch { };
        }
        /// <summary>
        /// Handles the font size selection via the Format Menu.
        /// </summary>
        private void FontSize_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Documents_TabControl.TabCount > 0)
                {
                    if (Documents_TabControl.SelectedTab.Controls[0] is RichTextBox)
                    {
                        RichTextBox textBox = Documents_TabControl.SelectedTab.Controls[0] as RichTextBox;
                        if (textBox.SelectionFont != null)
                        {
                            textBox.SelectionFont = new Font(
                                textBox.SelectionFont.FontFamily,
                                GetFontSize(FontSize_ComboBox.Text),
                                textBox.SelectionFont.Style);
                        }
                    }
                }
            }
            catch { };
        }
        /// <summary>
        /// Changes the code in a .cs file to a formatted version.
        /// </summary>
        private void FormatCode_ContextMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Documents_TabControl.TabCount > 0)
                {
                    if (Documents_TabControl.SelectedTab.Controls[0] is FastColoredTextBox)
                    {
                        (Documents_TabControl.SelectedTab.Controls[0] as FastColoredTextBox).Text = GetFormattedCode();
                    }
                }
            }
            catch { };
        }
        /// <summary>
        /// Handles clicking on the Format button in the Toolbar.
        /// </summary>
        private void Format_Menu_Click(object sender, EventArgs e)
        {
            try
            {
                if (Documents_TabControl.TabCount > 0)
                {
                    if (Documents_TabControl.SelectedTab.Controls[0] is RichTextBox)
                    {
                        RichTextBox textBox = Documents_TabControl.SelectedTab.Controls[0] as RichTextBox;
                        if (textBox.SelectionFont != null)
                        {
                            FontSelector_ComboBox.SelectedItem = textBox.SelectionFont.Name;
                            FontSize_ComboBox.SelectedItem = ((int)textBox.SelectionFont.SizeInPoints).ToString();
                            Bold_MenuItem.Checked = textBox.SelectionFont.Bold;
                            Italics_MenuItem.Checked = textBox.SelectionFont.Italic;
                            Strikethrough_MenuItem.Checked = textBox.SelectionFont.Strikeout;
                            Underlined_MenuItem.Checked = textBox.SelectionFont.Underline;
                        }
                    }
                }
            }
            catch { };
        }
        /// <summary>
        /// Handles clicking the Italics button via the Context Menu.
        /// </summary>
        private void Italics_ContextMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Italics_MenuItem_Click(sender, e);
            }
            catch { };
        }
        /// <summary>
        /// Handles clicking the Italics button via the Format Menu.
        /// </summary>
        private void Italics_MenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Documents_TabControl.TabCount > 0)
                {
                    if (Documents_TabControl.SelectedTab.Controls[0] is RichTextBox)
                    {
                        RichTextBox textBox = Documents_TabControl.SelectedTab.Controls[0] as RichTextBox;
                        if (textBox.SelectionFont != null)
                        {
                            if (textBox.SelectionFont.Italic)
                            {
                                textBox.SelectionFont = new Font(
                                    textBox.SelectionFont.Name,
                                    textBox.SelectionFont.SizeInPoints,
                                    textBox.SelectionFont.Style ^ FontStyle.Italic);
                            }
                            else
                            {
                                textBox.SelectionFont = new Font(
                                    textBox.SelectionFont.Name,
                                    textBox.SelectionFont.SizeInPoints,
                                    textBox.SelectionFont.Style | FontStyle.Italic);
                            }
                            Italics_MenuItem.Checked = !textBox.SelectionFont.Italic;
                        }
                    }
                }
            }
            catch { };
        }
        /// <summary>
        /// Handles clicking on the Light Theme Button.
        /// </summary>
        private void LightTheme_MenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (colourTheme == 1)
                {
                    colourTheme = ++colourTheme % Constants.ColourThemeQuantity;
                    LightTheme_MenuItem.Checked = true;
                    DarkTheme_MenuItem.Checked = false;
                    UpdateColours();
                }
            }
            catch { };
        }
        /// <summary>
        /// Handles New CS File button click in the File Menu.
        /// </summary>
        private void NewCSFile_MenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AddNewTabPage(Constants.ExtensionCS);
            }
            catch { };
        }
        /// <summary>
        /// Creates a new instance of the NotepadMainWindow Form.
        /// </summary>
        private void NewInNewWindow_MenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                new NotepadMainWindow().Show();
            }
            catch { };
        }
        /// <summary>
        /// Creates a new default TabPage.
        /// </summary>
        private void New_MenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AddNewTabPage(Constants.ExtensionRTF);
            }
            catch { };
        }
        /// <summary>
        /// Handles closing the Notpad+ Form.
        /// </summary>
        private void NotepadMainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                int width, height;
                if (WindowState == FormWindowState.Maximized)
                {
                    Size size = SystemInformation.PrimaryMonitorSize;
                    width = size.Width;
                    height = size.Height;
                }
                else
                {
                    width = Size.Width;
                    height = Size.Height;
                }
                UserSettingsReader.RefreshSettings(colourTheme,
                    width, height,
                    AutosaveFrequency,
                    BackupFrequency,
                    Documents_TabControl);
                bool closeCommit = true;
                foreach (TabPage item in Documents_TabControl.TabPages)
                {
                    Documents_TabControl.SelectedTab = item;
                    DialogResult closeTab = MessageBox.Show(
                            $"Would you like to save the changes in: {item.Text}?",
                            "Save Changes",
                            MessageBoxButtons.YesNoCancel,
                            MessageBoxIcon.Question);
                    if (closeTab == DialogResult.Yes)
                    {
                        Save_MenuItem_Click(sender, e);
                    }
                    else if (closeTab == DialogResult.No)
                    {
                        continue;
                    }
                    else if (closeTab == DialogResult.Cancel)
                    {
                        closeCommit = false;
                        break;
                    }
                }
                if (closeCommit)
                {
                    Documents_TabControl.TabPages.Clear();
                    Dispose();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch { };
        }
        /// <summary>
        /// Opens a file.
        /// </summary>
        private void Open_MenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string fileContents = string.Empty, fileDirectory = string.Empty;

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Title = "Select a file";
                    openFileDialog.Filter =
                        "All text and C# code files (*.txt, *.rtf, *.cs)|*.txt;*.rtf;*.cs|" +
                        "Text files (*.txt)|*.txt|" +
                        "Rich text files (*.rtf)|*.rtf|" +
                        "C# code files (*.cs)|*.cs";
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        fileDirectory = openFileDialog.FileName;
                        int index = 0;
                        foreach (TabPage item in Documents_TabControl.TabPages)
                        {
                            if (item.Name == fileDirectory)
                            {
                                break;
                            }
                            index++;
                        }
                        if (index != Documents_TabControl.TabCount)
                        {
                            Documents_TabControl.SelectTab(index);
                            return;
                        }

                        string fileExtension = Path.GetExtension(fileDirectory);

                        if (fileExtension == Constants.ExtensionRTF)
                        {
                            AddNewTabPage(Constants.ExtensionRTF, fileDirectory);
                            (Documents_TabControl.TabPages[^1].Controls[0] as RichTextBox)
                                .LoadFile(fileDirectory);
                        }
                        else if (fileExtension == Constants.ExtensionTXT)
                        {
                            AddNewTabPage(Constants.ExtensionTXT, fileDirectory);
                            var fileStream = openFileDialog.OpenFile();
                            using (StreamReader reader = new StreamReader(fileStream))
                            {
                                fileContents = reader.ReadToEnd();
                            }
                            Documents_TabControl.TabPages[^1].Controls[0].Text = fileContents;
                        }
                        else if (fileExtension == Constants.ExtensionCS)
                        {
                            var fileStream = openFileDialog.OpenFile();
                            using (StreamReader reader = new StreamReader(fileStream))
                            {
                                fileContents = reader.ReadToEnd();
                            }
                            AddNewTabPage(Constants.ExtensionCS, fileDirectory);
                            (Documents_TabControl.TabPages[^1].Controls[0] as FastColoredTextBox).Text =
                                fileContents;
                        }
                    }
                }
            }
            catch { };
        }
        /// <summary>
        /// Pastes the text from the Clipboard via the Context Menu.
        /// </summary>
        private void Paste_ContextMenuItem_Click(object sender, EventArgs e)
        {
            Paste_MenuItem_Click(sender, e);
        }
        /// <summary>
        /// Pastes the text from the Clipboard via the Edit Menu.
        /// </summary>
        private void Paste_MenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Documents_TabControl.TabCount > 0)
                {
                    if (Documents_TabControl.SelectedTab.Controls[0] is RichTextBox)
                    {
                        if (Clipboard.ContainsText(TextDataFormat.Rtf))
                        {
                            (Documents_TabControl.SelectedTab.Controls[0] as RichTextBox).SelectedRtf =
                                Clipboard.GetData(DataFormats.Rtf).ToString();
                        }
                    }
                    else if (Documents_TabControl.SelectedTab.Controls[0] is FastColoredTextBox)
                    {
                        if (Clipboard.ContainsText(TextDataFormat.Text))
                        {
                            (Documents_TabControl.SelectedTab.Controls[0] as FastColoredTextBox).SelectedText =
                                Clipboard.GetData(DataFormats.Text).ToString();
                        }
                    }
                }
            }
            catch { };
        }
        /// <summary>
        /// Handles the redo action.
        /// </summary>
        private void Redo_MenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Documents_TabControl.TabCount > 0)
                {
                    if (Documents_TabControl.SelectedTab.Controls[0] is RichTextBox)
                    {
                        if ((Documents_TabControl.SelectedTab.Controls[0] as RichTextBox).CanRedo)
                        {
                            (Documents_TabControl.SelectedTab.Controls[0] as RichTextBox).Redo();
                        }
                    }
                    else if (Documents_TabControl.SelectedTab.Controls[0] is FastColoredTextBox)
                    {
                        (Documents_TabControl.SelectedTab.Controls[0] as FastColoredTextBox).Redo();
                    }
                }
            }
            catch { };
        }
        /// <summary>
        /// Handles saving the file without name specification.
        /// </summary>
        private void Save_MenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Documents_TabControl.SelectedTab.Name.Length >= Constants.DefaultTabPageName.Length &&
                    Documents_TabControl.SelectedTab.Text.Length >= Constants.DefaultTabPageText.Length &&
                    Documents_TabControl.SelectedTab.Name[0..Constants.DefaultTabPageName.Length] ==
                    Constants.DefaultTabPageName &&
                    Documents_TabControl.SelectedTab.Text[0..Constants.DefaultTabPageText.Length] ==
                    Constants.DefaultTabPageText)
                {
                    SaveAs_MenuItem_Click(sender, e);
                }
                else
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog()
                    {
                        FileName = Path.GetFileNameWithoutExtension(Documents_TabControl.SelectedTab.Text)
                    };

                    if (Path.GetExtension(saveFileDialog.FileName) == Constants.ExtensionTXT)
                    {
                        (Documents_TabControl.SelectedTab.Controls[0] as RichTextBox)
                            .SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
                    }
                    else if (Path.GetExtension(saveFileDialog.FileName) == Constants.ExtensionRTF)
                    {
                        (Documents_TabControl.SelectedTab.Controls[0] as RichTextBox)
                            .SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                    }
                    else if (Path.GetExtension(saveFileDialog.FileName) == Constants.ExtensionCS)
                    {
                        (Documents_TabControl.SelectedTab.Controls[0] as FastColoredTextBox)
                            .SaveToFile(saveFileDialog.FileName, Constants.DefaultEncoding);
                    }

                    int index = -1;
                    foreach (TabPage item in Documents_TabControl.TabPages)
                    {
                        if (item.Name == Documents_TabControl.SelectedTab.Name)
                        {
                            index++;
                            break;
                        }
                        index++;
                    }
                    Documents_TabControl.TabPages[index].Name = saveFileDialog.FileName;
                    Documents_TabControl.TabPages[index].Text = Path.GetFileName(saveFileDialog.FileName);
                    Documents_TabControl.Invalidate();
                }
            }
            catch { };
        }
        /// <summary>
        /// Handles saving all open files.
        /// </summary>
        private void SaveAll_MenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (TabPage item in Documents_TabControl.TabPages)
                {
                    Documents_TabControl.SelectedTab = item;
                    Save_MenuItem_Click(sender, e);
                }
            }
            catch { };
        }
        /// <summary>
        /// Saves the current file with name specification.
        /// </summary>
        private void SaveAs_MenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dynamic saveFileDialog = null;
                if (Documents_TabControl.SelectedTab.Controls[0] is RichTextBox)
                {
                    saveFileDialog = new SaveFileDialog()
                    {
                        Title = "Choose save directory",
                        Filter = "Text files (*.txt)|*.txt|" +
                                 "Rich text files (*.rtf)|*.rtf",
                        RestoreDirectory = true,
                        FileName = Path.GetFileNameWithoutExtension(Documents_TabControl.SelectedTab.Text)
                    };
                }
                else if (Documents_TabControl.SelectedTab.Controls[0] is FastColoredTextBox)
                {
                    saveFileDialog = new SaveFileDialog()
                    {
                        Title = "Choose save directory",
                        Filter = "C# code files (*.cs)|*.cs",
                        RestoreDirectory = true,
                        FileName = Path.GetFileNameWithoutExtension(Documents_TabControl.SelectedTab.Text)
                    };
                }

                if (saveFileDialog != null && saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (Path.GetFileNameWithoutExtension(saveFileDialog.FileName) != string.Empty)
                    {
                        if (Path.GetExtension(saveFileDialog.FileName) == Constants.ExtensionTXT)
                        {
                            if (Documents_TabControl.SelectedTab.Controls[0] is RichTextBox)
                            {
                                (Documents_TabControl.SelectedTab.Controls[0] as RichTextBox)
                                    .SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
                            }
                        }
                        else if (Path.GetExtension(saveFileDialog.FileName) == Constants.ExtensionRTF)
                        {
                            if (Documents_TabControl.SelectedTab.Controls[0] is RichTextBox)
                            {
                                (Documents_TabControl.SelectedTab.Controls[0] as RichTextBox)
                                    .SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                            }
                        }
                        else if (Path.GetExtension(saveFileDialog.FileName) == Constants.ExtensionCS)
                        {
                            if (Documents_TabControl.SelectedTab.Controls[0] is FastColoredTextBox)
                            {
                                (Documents_TabControl.SelectedTab.Controls[0] as FastColoredTextBox)
                                    .SaveToFile(saveFileDialog.FileName, Constants.DefaultEncoding);
                            }
                        }

                        int index = -1;
                        foreach (TabPage item in Documents_TabControl.TabPages)
                        {
                            if (item.Name == Documents_TabControl.SelectedTab.Name)
                            {
                                index++;
                                break;
                            }
                            index++;
                        }
                        Documents_TabControl.TabPages[index].Name = saveFileDialog.FileName;
                        Documents_TabControl.TabPages[index].Text = Path.GetFileName(saveFileDialog.FileName);
                        Documents_TabControl.Invalidate();
                    }
                }
            }
            catch { }; ;
        }
        /// <summary>
        /// Selects all text via the Context Menu.
        /// </summary>
        private void SelectAll_ContextMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SelectAll_MenuItem_Click(sender, e);
            }
            catch { };
        }

        /// <summary>
        /// Selects all text via the Edit Menu.
        /// </summary>
        private void SelectAll_MenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Documents_TabControl.TabCount > 0)
                {
                    if (Documents_TabControl.SelectedTab.Controls[0] is RichTextBox)
                    {
                        (Documents_TabControl.SelectedTab.Controls[0] as RichTextBox).SelectAll();
                    }
                    else if (Documents_TabControl.SelectedTab.Controls[0] is FastColoredTextBox)
                    {
                        (Documents_TabControl.SelectedTab.Controls[0] as FastColoredTextBox).SelectAll();
                    }
                }
            }
            catch { };
        }
        /// <summary>
        /// Creates a Settings menu with Autosave options.
        /// </summary>
        private void Settings_MenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int width, height;
                if (WindowState == FormWindowState.Maximized)
                {
                    Size size = SystemInformation.PrimaryMonitorSize;
                    width = size.Width;
                    height = size.Height;
                }
                else
                {
                    width = Size.Width;
                    height = Size.Height;
                }

                UserSettingsReader.RefreshSettings(colourTheme,
                    width, height,
                    AutosaveFrequency,
                    BackupFrequency,
                    Documents_TabControl);

                new Settings(this).Show();
            }
            catch { };
        }
        /// <summary>
        /// Handles clicking the Strikethough button via the Context Menu.
        /// </summary>
        private void Strikethrough_ContextMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Strikethrough_MenuItem_Click(sender, e);
            }
            catch { };
        }
        /// <summary>
        /// Handles clicking the Strikethrough button via the Format Menu.
        /// </summary>
        private void Strikethrough_MenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Documents_TabControl.TabCount > 0)
                {
                    if (Documents_TabControl.SelectedTab.Controls[0] is RichTextBox)
                    {
                        var textBox = Documents_TabControl.SelectedTab.Controls[0] as RichTextBox;
                        if (textBox.SelectionFont != null)
                        {
                            if (textBox.SelectionFont.Strikeout)
                            {
                                textBox.SelectionFont = new Font(
                                    textBox.SelectionFont.Name,
                                    textBox.SelectionFont.SizeInPoints,
                                    textBox.SelectionFont.Style ^ FontStyle.Strikeout);
                            }
                            else
                            {
                                textBox.SelectionFont = new Font(
                                    textBox.SelectionFont.Name,
                                    textBox.SelectionFont.SizeInPoints,
                                    textBox.SelectionFont.Style | FontStyle.Strikeout);
                            }
                            Strikethrough_MenuItem.Checked = !textBox.SelectionFont.Strikeout;
                        }
                    }
                }
            }
            catch { };
        }
        /// <summary>
        /// Handles clicking the Underline button via the Context Menu.
        /// </summary>
        private void Underlined_ContextMenuItem_Click(object sender, EventArgs e)
        {
            Underlined_MenuItem_Click(sender, e);
        }
        /// <summary>
        /// Handles clicking the Underline button via the Format Menu.
        /// </summary>
        private void Underlined_MenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Documents_TabControl.TabCount > 0)
                {
                    if (Documents_TabControl.SelectedTab.Controls[0] is RichTextBox)
                    {
                        RichTextBox textBox = Documents_TabControl.SelectedTab.Controls[0] as RichTextBox;
                        if (textBox.SelectionFont != null)
                        {
                            if (textBox.SelectionFont.Underline)
                            {
                                textBox.SelectionFont = new Font(
                                    textBox.SelectionFont.Name,
                                    textBox.SelectionFont.SizeInPoints,
                                    textBox.SelectionFont.Style ^ FontStyle.Underline);
                            }
                            else
                            {
                                textBox.SelectionFont = new Font(
                                    textBox.SelectionFont.Name,
                                    textBox.SelectionFont.SizeInPoints,
                                    textBox.SelectionFont.Style | FontStyle.Underline);
                            }
                            Underlined_MenuItem.Checked = !textBox.SelectionFont.Underline;
                        }
                    }
                }
            }
            catch { };
        }
        /// <summary>
        /// Handles the undo action.
        /// </summary>
        private void Undo_MenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Documents_TabControl.TabCount > 0)
                {
                    if (Documents_TabControl.SelectedTab.Controls[0] is RichTextBox)
                    {
                        if ((Documents_TabControl.SelectedTab.Controls[0] as RichTextBox).CanUndo)
                        {
                            (Documents_TabControl.SelectedTab.Controls[0] as RichTextBox).Undo();
                        }
                    }
                    else if (Documents_TabControl.SelectedTab.Controls[0] is FastColoredTextBox)
                    {
                        (Documents_TabControl.SelectedTab.Controls[0] as FastColoredTextBox).Undo();
                    }
                }
            }
            catch { };
        }
        /// <summary>
        /// Updates the colours of the controls on the Form.
        /// </summary>
        private void UpdateColours()
        {
            try
            {
                ToolStripSeparator[] toolStripSeparators =
                {
                ToolStripSeparator_1,
                ToolStripSeparator_2,
                ToolStripSeparator_3,
                ToolStripSeparator_4,
                ToolStripSeparator_5,
                ToolStripSeparator_6,
                ToolStripSeparator_7,
                ToolStripSeparator_Context_1,
                ToolStripSeparator_Context_2,
                ToolStripSeparator_Context_3
            };

                this.BackColor = Constants.BackgroundPrimaryColour[colourTheme];
                ForeColor = Constants.ForeColour[colourTheme];
                MainToolbar.BackColor = Constants.BackgroundSecondaryColour[colourTheme];
                MainToolbar.ForeColor = Constants.ForeColour[colourTheme];

                foreach (ToolStripSeparator item in toolStripSeparators)
                {
                    item.BackColor = Constants.BackgroundPrimaryColour[colourTheme];
                    item.ForeColor = Constants.ForeColour[colourTheme];
                }

                FontSelector_ComboBox.BackColor = Constants.BackgroundPrimaryColour[colourTheme];
                FontSelector_ComboBox.ForeColor = Constants.ForeColour[colourTheme];

                foreach (ToolStripMenuItem item in MainToolbar.Items)
                {
                    foreach (ToolStripItem innerItem in item.DropDownItems)
                    {
                        innerItem.BackColor = Constants.BackgroundPrimaryColour[colourTheme];
                        innerItem.ForeColor = Constants.ForeColour[colourTheme];
                    }
                }
                foreach (TabPage item in Documents_TabControl.TabPages)
                {
                    item.BackColor = Constants.BackgroundPrimaryColour[colourTheme];
                    item.ForeColor = Constants.BackgroundSecondaryColour[colourTheme];
                    if (item.Controls[0] is RichTextBox)
                    {
                        (item.Controls[0] as RichTextBox).BackColor =
                            Constants.BackgroundPrimaryColour[colourTheme];
                        foreach (ToolStripItem innerItem in (item.Controls[0] as RichTextBox).ContextMenuStrip.Items)
                        {
                            innerItem.BackColor = Constants.BackgroundPrimaryColour[colourTheme];
                            innerItem.ForeColor = Constants.ForeColour[colourTheme];
                        }
                    }
                    else if (item.Controls[0] is FastColoredTextBox)
                    {
                        (item.Controls[0] as FastColoredTextBox).BackColor =
                        Constants.BackgroundPrimaryColour[colourTheme];
                        foreach (ToolStripItem innerItem in (item.Controls[0] as FastColoredTextBox)
                            .ContextMenuStrip.Items)
                        {
                            innerItem.BackColor = Constants.BackgroundPrimaryColour[colourTheme];
                            innerItem.ForeColor = Constants.ForeColour[colourTheme];
                        }
                    }
                }

                MainStatusStrip.BackColor = Constants.BackgroundSecondaryColour[colourTheme];
                MainStatusStrip.ForeColor = Constants.ForeColour[colourTheme];
                SaveLabel_StatusStrip.BackColor = Color.Transparent;
                SaveLabel_StatusStrip.ForeColor = Constants.ForeColour[colourTheme];
            }
            catch { };
        }

        /// <summary>
        /// Handles showing and hiding text message in the Status Strip after the autosave timer has elapsed.
        /// </summary>
        public void AutosaveMessageTimerEventProcessor(object sender, EventArgs e)
        {
            try
            {
                if (messageTimer != null)
                {
                    messageTimer.Stop();
                    SaveLabel_StatusStrip.Text = string.Empty;
                    messageTimer = null;
                }
            }
            catch { };
        }
        /// <summary>
        /// Handles the events after the autosave timer has elapsed.
        /// </summary>
        public void AutosaveTimerEventProcessor(object sender, EventArgs e)
        {
            try
            {
                if (AutosaveTimer != null)
                {
                    AutosaveTimer.Stop();
                    AutosaveAllFiles();
                    SaveLabel_StatusStrip.Text = Constants.AllFilesSavedMessage;
                    AutosaveTimer.Start();
                    messageTimer = new Timer()
                    {
                        Interval = (int)(Constants.SaveMessageVisibilityDuraion * 1000)
                    };
                    messageTimer.Start();
                    messageTimer.Tick += AutosaveMessageTimerEventProcessor;
                }
            }
            catch { };
        }
        /// <summary>
        /// Changes the highlight colours of .cs files.
        /// </summary>
        public void GetNewSyntaxHighlighter()
        {
            try
            {
                SuspendLayout();
                for (int i = 0; i < Documents_TabControl.TabCount; i++)
                {
                    if (Documents_TabControl.TabPages[i].Controls[0] is FastColoredTextBox)
                    {
                        string text = (Documents_TabControl.TabPages[i].Controls[0] as FastColoredTextBox).Text;
                        (Documents_TabControl.TabPages[i].Controls[0] as FastColoredTextBox).Text = string.Empty;
                        (Documents_TabControl.TabPages[i].Controls[0] as FastColoredTextBox).
                            SyntaxHighlighter = new SyntaxHighlighter
                            (Documents_TabControl.TabPages[i].Controls[0] as FastColoredTextBox)
                            {
                                AttributeStyle = AttributeStyle,
                                ClassNameStyle = ClassStyle,
                                CommentStyle = CommentStyle,
                                CommentTagStyle = CommentTagStyle,
                                NumberStyle = NumberStyle,
                                StringStyle = StringStyle,
                                VariableStyle = VariableStyle,
                                KeywordStyle = KeywordStyle
                            };
                        (Documents_TabControl.TabPages[i].Controls[0] as FastColoredTextBox).Text = text;
                    }
                }
                ResumeLayout();
            }
            catch { };
        }

    }

}