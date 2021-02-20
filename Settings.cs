using FastColoredTextBoxNS;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NotepadPlus
{

    /// <summary>
    /// The settings form.
    /// </summary>
    public partial class Settings : Form
    {

        /// <summary>
        /// The parent form of this form.
        /// </summary>
        private readonly Form parentForm;


        /// <summary>
        /// The colour of C# attributes.
        /// </summary>
        public static Color AttributeColour { get; set; } = Constants.DefaultAttributeColour;
        /// <summary>
        /// The colour of C# classes.
        /// </summary>
        public static Color ClassColour { get; set; } = Constants.DefaultClassColour;
        /// <summary>
        /// The colour of C# comments.
        /// </summary>
        public static Color CommentColour { get; set; } = Constants.DefaultCommentColour;
        /// <summary>
        /// The colour of C# comment tags.
        /// </summary>
        public static Color CommentTagColour { get; set; } = Constants.DefaultCommentTagColour;
        /// <summary>
        /// The colour of C# keywords.
        /// </summary>
        public static Color KeywordColour { get; set; } = Constants.DefaultKeywordColour;
        /// <summary>
        /// The colour of C# number literals.
        /// </summary>
        public static Color NumberColour { get; set; } = Constants.DefaultNumberColour;
        /// <summary>
        /// The colour of C# string literals.
        /// </summary>
        public static Color StringColour { get; set; } = Constants.DefaultStringColour;
        /// <summary>
        /// The colour of C# variables.
        /// </summary>
        public static Color VariableColour { get; set; } = Constants.DefaultVariableColour;


        /// <summary>
        /// Creates a new Settings form.
        /// </summary>
        /// <param name="form">The parent form.</param>
        public Settings(Form form)
        {
            parentForm = form;
            InitializeComponent();

            MaximumSize = Constants.SettingsWindowSize;
            MinimumSize = Constants.SettingsWindowSize;
            Size = Constants.SettingsWindowSize;

            int colourTheme = UserSettingsReader.GetColourTheme();
            UpdateColours(colourTheme);

            Autosave_ComboBox.Items.AddRange(Constants.AutosaveFrequencies);
            Autosave_ComboBox.SelectedItem =
                Constants.AutosaveFrequencies[
                    Array.FindIndex(Constants.AutosaveFrequenciesInSeconds,
                    x => x == NotepadMainWindow.AutosaveFrequency)
                    ];

            Backup_ComboBox.Items.AddRange(Constants.BackupFrequencies);
            Backup_ComboBox.SelectedItem =
                Constants.BackupFrequencies[
                    Array.FindIndex(Constants.BackupFrequenciesInSeconds,
                    x => x == NotepadMainWindow.BackupFrequency)
                    ];

            UpdateButtonColours();
        }


        /// <summary>
        /// Applies the changes made in the Autosave ComboBox.
        /// </summary>
        private void ApplyChanges_Button_Click(object sender, EventArgs e)
        {
            try
            {
                NotepadMainWindow.AutosaveFrequency =
                    Constants.AutosaveFrequenciesInSeconds[Autosave_ComboBox.SelectedIndex];
                NotepadMainWindow.BackupFrequency =
                    Constants.BackupFrequenciesInSeconds[Backup_ComboBox.SelectedIndex];

                // If "None" was not selected, create and start a new timer.
                if (NotepadMainWindow.AutosaveFrequency != 0)
                {
                    NotepadMainWindow.AutosaveTimer = new Timer
                    {
                        Interval = NotepadMainWindow.AutosaveFrequency * 1000
                    };
                    NotepadMainWindow.AutosaveTimer.Start();
                    NotepadMainWindow.AutosaveTimer.Tick +=
                        (parentForm as NotepadMainWindow).AutosaveTimerEventProcessor;
                }
                else
                {
                    if (NotepadMainWindow.AutosaveTimer != null)
                    {
                        NotepadMainWindow.AutosaveTimer.Stop();
                        NotepadMainWindow.AutosaveTimer = null;
                    }
                }

                if (NotepadMainWindow.BackupFrequency != 0)
                {
                    NotepadMainWindow.BackupTimer = new Timer
                    {
                        Interval = NotepadMainWindow.BackupFrequency * 1000
                    };
                    NotepadMainWindow.BackupTimer.Start();
                    NotepadMainWindow.BackupTimer.Tick +=
                        (parentForm as NotepadMainWindow).BackupTimerEventProcessor;
                }
                else
                {
                    if (NotepadMainWindow.BackupTimer != null)
                    {
                        NotepadMainWindow.BackupTimer?.Stop();
                        NotepadMainWindow.BackupTimer = null;
                    }
                }

                (parentForm as NotepadMainWindow).GetNewSyntaxHighlighter();

                Close();
            }
            catch { };
        }
        /// <summary>
        /// Handles clicking the Attribute Colour Button.
        /// </summary>
        private void AttributeColour_Button_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog colorDialog = new ColorDialog();
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    SolidBrush brush = new SolidBrush(colorDialog.Color);
                    AttributeColour = colorDialog.Color;
                    NotepadMainWindow.AttributeStyle = new TextStyle(brush, null, FontStyle.Regular);
                    UpdateButtonColours();
                }
            }
            catch { };
        }
        /// <summary>
        /// Handles clicking the Class Colour Button.
        /// </summary>
        private void ClassColour_Button_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog colorDialog = new ColorDialog();
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    SolidBrush brush = new SolidBrush(colorDialog.Color);
                    ClassColour = colorDialog.Color;
                    NotepadMainWindow.ClassStyle = new TextStyle(brush, null, FontStyle.Regular);
                    UpdateButtonColours();
                }
            }
            catch { };
        }
        /// <summary>
        /// Handles clicking the Comment Colour Button.
        /// </summary>
        private void CommentColour_Button_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog colorDialog = new ColorDialog();
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    SolidBrush brush = new SolidBrush(colorDialog.Color);
                    CommentColour = colorDialog.Color;
                    NotepadMainWindow.CommentStyle = new TextStyle(brush, null, FontStyle.Regular);
                    UpdateButtonColours();
                }
            }
            catch { };
        }
        /// <summary>
        /// Handles clicking the Comment Tag Colour Button.
        /// </summary>
        private void CommentTagColour_Button_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog colorDialog = new ColorDialog();
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    SolidBrush brush = new SolidBrush(colorDialog.Color);
                    CommentTagColour = colorDialog.Color;
                    NotepadMainWindow.CommentTagStyle = new TextStyle(brush, null, FontStyle.Regular);
                    UpdateButtonColours();
                }
            }
            catch { };
        }
        /// <summary>
        /// Handles clicking the Keyword Colour Button.
        /// </summary>
        private void KeywordColour_Button_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog colorDialog = new ColorDialog();
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    SolidBrush brush = new SolidBrush(colorDialog.Color);
                    KeywordColour = colorDialog.Color;
                    NotepadMainWindow.KeywordStyle = new TextStyle(brush, null, FontStyle.Regular);
                    UpdateButtonColours();
                }
            }
            catch { };
        }
        /// <summary>
        /// Handles clicking the Number Colour Button.
        /// </summary>
        private void NumberColour_Button_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog colorDialog = new ColorDialog();
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    SolidBrush brush = new SolidBrush(colorDialog.Color);
                    NumberColour = colorDialog.Color;
                    NotepadMainWindow.NumberStyle = new TextStyle(brush, null, FontStyle.Regular);
                    UpdateButtonColours();
                }
            }
            catch { };
        }
        /// <summary>
        /// Handles clicking the String Colour Button.
        /// </summary>
        private void StringColour_Button_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog colorDialog = new ColorDialog();
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    SolidBrush brush = new SolidBrush(colorDialog.Color);
                    StringColour = colorDialog.Color;
                    NotepadMainWindow.StringStyle = new TextStyle(brush, null, FontStyle.Regular);
                    UpdateButtonColours();
                }
            }
            catch { };
        }
        /// <summary>
        /// Handles clicking the Variable Colour Button.
        /// </summary>
        private void VariableColour_Button_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog colorDialog = new ColorDialog();
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    SolidBrush brush = new SolidBrush(colorDialog.Color);
                    VariableColour = colorDialog.Color;
                    NotepadMainWindow.VariableStyle = new TextStyle(brush, null, FontStyle.Regular);
                    UpdateButtonColours();
                }
            }
            catch { };
        }

        /// <summary>
        /// Accordingly updates the colours of the buttons used for selecting colours of 
        /// highlighting different parts of the text.
        /// </summary>
        private void UpdateButtonColours()
        {
            try
            {
                AttributeColour_Button.BackColor = AttributeColour;
                ClassColour_Button.BackColor = ClassColour;
                CommentColour_Button.BackColor = CommentColour;
                CommentTagColour_Button.BackColor = CommentTagColour;
                KeywordColour_Button.BackColor = KeywordColour;
                NumberColour_Button.BackColor = NumberColour;
                StringColour_Button.BackColor = StringColour;
                VariableColour_Button.BackColor = VariableColour;
            }
            catch { };
        }
        /// <summary>
        /// Updates the colour theme of the form.
        /// </summary>
        /// <param name="colourTheme">The colour theme to be used for the items on the form.</param>
        private void UpdateColours(int colourTheme)
        {
            BackColor = Constants.BackgroundPrimaryColour[colourTheme];
            ForeColor = Constants.ForeColour[colourTheme];

            foreach (var item in this.Controls)
            {
                if (item is Label)
                {
                    (item as Label).BackColor = Color.Transparent;
                    (item as Label).ForeColor = Constants.ForeColour[colourTheme];
                }
                else if (item is ComboBox)
                {
                    (item as ComboBox).BackColor = Constants.BackgroundPrimaryColour[colourTheme];
                    (item as ComboBox).ForeColor = Constants.ForeColour[colourTheme];
                }
            }

            ApplyChanges_Button.BackColor = Constants.BackgroundPrimaryColour[colourTheme];
            ApplyChanges_Button.ForeColor = Constants.ForeColour[colourTheme];
        }

    }
}