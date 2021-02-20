namespace NotepadPlus
{

    partial class NotepadMainWindow
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">truf managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotepadMainWindow));
            this.MainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.MainToolbar = new System.Windows.Forms.MenuStrip();
            this.File_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.New_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewCSFile_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewInNewWindow_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Open_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator_1 = new System.Windows.Forms.ToolStripSeparator();
            this.Save_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAs_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAll_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator_2 = new System.Windows.Forms.ToolStripSeparator();
            this.Exit_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Edit_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.Undo_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Redo_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator_3 = new System.Windows.Forms.ToolStripSeparator();
            this.Cut_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Copy_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Paste_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator_4 = new System.Windows.Forms.ToolStripSeparator();
            this.SelectAll_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Format_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.FontSelector_ComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.FontSize_ComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.ToolStripSeparator_5 = new System.Windows.Forms.ToolStripSeparator();
            this.Bold_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Italics_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Underlined_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Strikethrough_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator_6 = new System.Windows.Forms.ToolStripSeparator();
            this.FontColour_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Settings_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.Autosave_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator_7 = new System.Windows.Forms.ToolStripSeparator();
            this.ColourTheme_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LightTheme_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DarkTheme_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Documents_TabControl = new System.Windows.Forms.TabControl();
            this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.SaveLabel_StatusStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.ContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SelectAll_ContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Cut_ContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Copy_ContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Paste_ContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator_Context_1 = new System.Windows.Forms.ToolStripSeparator();
            this.FontSelector_ContextComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.FontSize_ContextComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.ToolStripSeparator_Context_2 = new System.Windows.Forms.ToolStripSeparator();
            this.Bold_ContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Italics_ContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Underlined_ContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Strikethrough_ContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator_Context_3 = new System.Windows.Forms.ToolStripSeparator();
            this.FontColour_ContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FormatCode_ContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainTableLayoutPanel.SuspendLayout();
            this.MainToolbar.SuspendLayout();
            this.MainStatusStrip.SuspendLayout();
            this.ContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTableLayoutPanel
            // 
            this.MainTableLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.MainTableLayoutPanel.ColumnCount = 1;
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.Controls.Add(this.MainToolbar, 0, 0);
            this.MainTableLayoutPanel.Controls.Add(this.Documents_TabControl, 0, 1);
            this.MainTableLayoutPanel.Controls.Add(this.MainStatusStrip, 0, 2);
            this.MainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            this.MainTableLayoutPanel.RowCount = 3;
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.MainTableLayoutPanel.Size = new System.Drawing.Size(1068, 464);
            this.MainTableLayoutPanel.TabIndex = 0;
            // 
            // MainToolbar
            // 
            this.MainToolbar.BackColor = System.Drawing.Color.White;
            this.MainToolbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainToolbar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File_Menu,
            this.Edit_Menu,
            this.Format_Menu,
            this.Settings_Menu});
            this.MainToolbar.Location = new System.Drawing.Point(0, 0);
            this.MainToolbar.Name = "MainToolbar";
            this.MainToolbar.Size = new System.Drawing.Size(1068, 40);
            this.MainToolbar.TabIndex = 0;
            // 
            // File_Menu
            // 
            this.File_Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.New_MenuItem,
            this.NewCSFile_MenuItem,
            this.NewInNewWindow_MenuItem,
            this.Open_MenuItem,
            this.ToolStripSeparator_1,
            this.Save_MenuItem,
            this.SaveAs_MenuItem,
            this.SaveAll_MenuItem,
            this.ToolStripSeparator_2,
            this.Exit_MenuItem});
            this.File_Menu.Name = "File_Menu";
            this.File_Menu.Size = new System.Drawing.Size(46, 36);
            this.File_Menu.Text = "&File";
            // 
            // New_MenuItem
            // 
            this.New_MenuItem.Image = ((System.Drawing.Image)(resources.GetObject("New_MenuItem.Image")));
            this.New_MenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.New_MenuItem.Name = "New_MenuItem";
            this.New_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.New_MenuItem.Size = new System.Drawing.Size(282, 26);
            this.New_MenuItem.Text = "&New";
            this.New_MenuItem.Click += new System.EventHandler(this.New_MenuItem_Click);
            // 
            // NewCSFile_MenuItem
            // 
            this.NewCSFile_MenuItem.Name = "NewCSFile_MenuItem";
            this.NewCSFile_MenuItem.Size = new System.Drawing.Size(282, 26);
            this.NewCSFile_MenuItem.Text = "New .cs File";
            this.NewCSFile_MenuItem.Click += new System.EventHandler(this.NewCSFile_MenuItem_Click);
            // 
            // NewInNewWindow_MenuItem
            // 
            this.NewInNewWindow_MenuItem.Name = "NewInNewWindow_MenuItem";
            this.NewInNewWindow_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
            this.NewInNewWindow_MenuItem.Size = new System.Drawing.Size(282, 26);
            this.NewInNewWindow_MenuItem.Text = "New Window";
            this.NewInNewWindow_MenuItem.Click += new System.EventHandler(this.NewInNewWindow_MenuItem_Click);
            // 
            // Open_MenuItem
            // 
            this.Open_MenuItem.Image = ((System.Drawing.Image)(resources.GetObject("Open_MenuItem.Image")));
            this.Open_MenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Open_MenuItem.Name = "Open_MenuItem";
            this.Open_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.Open_MenuItem.Size = new System.Drawing.Size(282, 26);
            this.Open_MenuItem.Text = "&Open";
            this.Open_MenuItem.Click += new System.EventHandler(this.Open_MenuItem_Click);
            // 
            // ToolStripSeparator_1
            // 
            this.ToolStripSeparator_1.Name = "ToolStripSeparator_1";
            this.ToolStripSeparator_1.Size = new System.Drawing.Size(279, 6);
            // 
            // Save_MenuItem
            // 
            this.Save_MenuItem.Image = ((System.Drawing.Image)(resources.GetObject("Save_MenuItem.Image")));
            this.Save_MenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Save_MenuItem.Name = "Save_MenuItem";
            this.Save_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.Save_MenuItem.Size = new System.Drawing.Size(282, 26);
            this.Save_MenuItem.Text = "&Save";
            this.Save_MenuItem.Click += new System.EventHandler(this.Save_MenuItem_Click);
            // 
            // SaveAs_MenuItem
            // 
            this.SaveAs_MenuItem.Name = "SaveAs_MenuItem";
            this.SaveAs_MenuItem.Size = new System.Drawing.Size(282, 26);
            this.SaveAs_MenuItem.Text = "Save As";
            this.SaveAs_MenuItem.Click += new System.EventHandler(this.SaveAs_MenuItem_Click);
            // 
            // SaveAll_MenuItem
            // 
            this.SaveAll_MenuItem.Name = "SaveAll_MenuItem";
            this.SaveAll_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.SaveAll_MenuItem.Size = new System.Drawing.Size(282, 26);
            this.SaveAll_MenuItem.Text = "Save All";
            this.SaveAll_MenuItem.Click += new System.EventHandler(this.SaveAll_MenuItem_Click);
            // 
            // ToolStripSeparator_2
            // 
            this.ToolStripSeparator_2.Name = "ToolStripSeparator_2";
            this.ToolStripSeparator_2.Size = new System.Drawing.Size(279, 6);
            // 
            // Exit_MenuItem
            // 
            this.Exit_MenuItem.Name = "Exit_MenuItem";
            this.Exit_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.Exit_MenuItem.Size = new System.Drawing.Size(282, 26);
            this.Exit_MenuItem.Text = "Exit";
            this.Exit_MenuItem.Click += new System.EventHandler(this.Exit_MenuItem_Click);
            // 
            // Edit_Menu
            // 
            this.Edit_Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Undo_MenuItem,
            this.Redo_MenuItem,
            this.ToolStripSeparator_3,
            this.Cut_MenuItem,
            this.Copy_MenuItem,
            this.Paste_MenuItem,
            this.ToolStripSeparator_4,
            this.SelectAll_MenuItem});
            this.Edit_Menu.Name = "Edit_Menu";
            this.Edit_Menu.Size = new System.Drawing.Size(49, 36);
            this.Edit_Menu.Text = "&Edit";
            // 
            // Undo_MenuItem
            // 
            this.Undo_MenuItem.Name = "Undo_MenuItem";
            this.Undo_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.Undo_MenuItem.Size = new System.Drawing.Size(226, 26);
            this.Undo_MenuItem.Text = "&Undo";
            this.Undo_MenuItem.Click += new System.EventHandler(this.Undo_MenuItem_Click);
            // 
            // Redo_MenuItem
            // 
            this.Redo_MenuItem.Name = "Redo_MenuItem";
            this.Redo_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Z)));
            this.Redo_MenuItem.Size = new System.Drawing.Size(226, 26);
            this.Redo_MenuItem.Text = "&Redo";
            this.Redo_MenuItem.Click += new System.EventHandler(this.Redo_MenuItem_Click);
            // 
            // ToolStripSeparator_3
            // 
            this.ToolStripSeparator_3.Name = "ToolStripSeparator_3";
            this.ToolStripSeparator_3.Size = new System.Drawing.Size(223, 6);
            // 
            // Cut_MenuItem
            // 
            this.Cut_MenuItem.Image = ((System.Drawing.Image)(resources.GetObject("Cut_MenuItem.Image")));
            this.Cut_MenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Cut_MenuItem.Name = "Cut_MenuItem";
            this.Cut_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.Cut_MenuItem.Size = new System.Drawing.Size(226, 26);
            this.Cut_MenuItem.Text = "Cu&t";
            this.Cut_MenuItem.Click += new System.EventHandler(this.Cut_MenuItem_Click);
            // 
            // Copy_MenuItem
            // 
            this.Copy_MenuItem.Image = ((System.Drawing.Image)(resources.GetObject("Copy_MenuItem.Image")));
            this.Copy_MenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Copy_MenuItem.Name = "Copy_MenuItem";
            this.Copy_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.Copy_MenuItem.Size = new System.Drawing.Size(226, 26);
            this.Copy_MenuItem.Text = "&Copy";
            this.Copy_MenuItem.Click += new System.EventHandler(this.Copy_MenuItem_Click);
            // 
            // Paste_MenuItem
            // 
            this.Paste_MenuItem.Image = ((System.Drawing.Image)(resources.GetObject("Paste_MenuItem.Image")));
            this.Paste_MenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Paste_MenuItem.Name = "Paste_MenuItem";
            this.Paste_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.Paste_MenuItem.Size = new System.Drawing.Size(226, 26);
            this.Paste_MenuItem.Text = "&Paste";
            this.Paste_MenuItem.Click += new System.EventHandler(this.Paste_MenuItem_Click);
            // 
            // ToolStripSeparator_4
            // 
            this.ToolStripSeparator_4.Name = "ToolStripSeparator_4";
            this.ToolStripSeparator_4.Size = new System.Drawing.Size(223, 6);
            // 
            // SelectAll_MenuItem
            // 
            this.SelectAll_MenuItem.Name = "SelectAll_MenuItem";
            this.SelectAll_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.SelectAll_MenuItem.Size = new System.Drawing.Size(226, 26);
            this.SelectAll_MenuItem.Text = "Select &All";
            this.SelectAll_MenuItem.Click += new System.EventHandler(this.SelectAll_MenuItem_Click);
            // 
            // Format_Menu
            // 
            this.Format_Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FontSelector_ComboBox,
            this.FontSize_ComboBox,
            this.ToolStripSeparator_5,
            this.Bold_MenuItem,
            this.Italics_MenuItem,
            this.Underlined_MenuItem,
            this.Strikethrough_MenuItem,
            this.ToolStripSeparator_6,
            this.FontColour_MenuItem});
            this.Format_Menu.Name = "Format_Menu";
            this.Format_Menu.Size = new System.Drawing.Size(70, 36);
            this.Format_Menu.Text = "Fo&rmat";
            this.Format_Menu.Click += new System.EventHandler(this.Format_Menu_Click);
            // 
            // FontSelector_ComboBox
            // 
            this.FontSelector_ComboBox.AutoSize = false;
            this.FontSelector_ComboBox.DropDownHeight = 110;
            this.FontSelector_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FontSelector_ComboBox.IntegralHeight = false;
            this.FontSelector_ComboBox.Name = "FontSelector_ComboBox";
            this.FontSelector_ComboBox.Size = new System.Drawing.Size(250, 28);
            this.FontSelector_ComboBox.SelectedIndexChanged += new System.EventHandler(this.FontSelector_ComboBox_SelectedIndexChanged);
            // 
            // FontSize_ComboBox
            // 
            this.FontSize_ComboBox.AutoSize = false;
            this.FontSize_ComboBox.DropDownHeight = 110;
            this.FontSize_ComboBox.IntegralHeight = false;
            this.FontSize_ComboBox.MaxLength = 3;
            this.FontSize_ComboBox.Name = "FontSize_ComboBox";
            this.FontSize_ComboBox.Size = new System.Drawing.Size(50, 28);
            this.FontSize_ComboBox.SelectedIndexChanged += new System.EventHandler(this.FontSize_ComboBox_SelectedIndexChanged);
            // 
            // ToolStripSeparator_5
            // 
            this.ToolStripSeparator_5.Name = "ToolStripSeparator_5";
            this.ToolStripSeparator_5.Size = new System.Drawing.Size(321, 6);
            // 
            // Bold_MenuItem
            // 
            this.Bold_MenuItem.Name = "Bold_MenuItem";
            this.Bold_MenuItem.Size = new System.Drawing.Size(324, 26);
            this.Bold_MenuItem.Text = "&Bold";
            this.Bold_MenuItem.Click += new System.EventHandler(this.Bold_MenuItem_Click);
            // 
            // Italics_MenuItem
            // 
            this.Italics_MenuItem.Name = "Italics_MenuItem";
            this.Italics_MenuItem.Size = new System.Drawing.Size(324, 26);
            this.Italics_MenuItem.Text = "&Italics";
            this.Italics_MenuItem.Click += new System.EventHandler(this.Italics_MenuItem_Click);
            // 
            // Underlined_MenuItem
            // 
            this.Underlined_MenuItem.Name = "Underlined_MenuItem";
            this.Underlined_MenuItem.Size = new System.Drawing.Size(324, 26);
            this.Underlined_MenuItem.Text = "&Underlined";
            this.Underlined_MenuItem.Click += new System.EventHandler(this.Underlined_MenuItem_Click);
            // 
            // Strikethrough_MenuItem
            // 
            this.Strikethrough_MenuItem.Name = "Strikethrough_MenuItem";
            this.Strikethrough_MenuItem.Size = new System.Drawing.Size(324, 26);
            this.Strikethrough_MenuItem.Text = "&Strikethrough";
            this.Strikethrough_MenuItem.Click += new System.EventHandler(this.Strikethrough_MenuItem_Click);
            // 
            // ToolStripSeparator_6
            // 
            this.ToolStripSeparator_6.Name = "ToolStripSeparator_6";
            this.ToolStripSeparator_6.Size = new System.Drawing.Size(321, 6);
            // 
            // FontColour_MenuItem
            // 
            this.FontColour_MenuItem.Name = "FontColour_MenuItem";
            this.FontColour_MenuItem.Size = new System.Drawing.Size(324, 26);
            this.FontColour_MenuItem.Text = "Font Colour";
            this.FontColour_MenuItem.Click += new System.EventHandler(this.FontColour_MenuItem_Click);
            // 
            // Settings_Menu
            // 
            this.Settings_Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Autosave_MenuItem,
            this.ToolStripSeparator_7,
            this.ColourTheme_MenuItem});
            this.Settings_Menu.Name = "Settings_Menu";
            this.Settings_Menu.Size = new System.Drawing.Size(76, 36);
            this.Settings_Menu.Text = "&Settings";
            // 
            // Autosave_MenuItem
            // 
            this.Autosave_MenuItem.Name = "Autosave_MenuItem";
            this.Autosave_MenuItem.Size = new System.Drawing.Size(185, 26);
            this.Autosave_MenuItem.Text = "Settings";
            this.Autosave_MenuItem.Click += new System.EventHandler(this.Settings_MenuItem_Click);
            // 
            // ToolStripSeparator_7
            // 
            this.ToolStripSeparator_7.Name = "ToolStripSeparator_7";
            this.ToolStripSeparator_7.Size = new System.Drawing.Size(182, 6);
            // 
            // ColourTheme_MenuItem
            // 
            this.ColourTheme_MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LightTheme_MenuItem,
            this.DarkTheme_MenuItem});
            this.ColourTheme_MenuItem.Name = "ColourTheme_MenuItem";
            this.ColourTheme_MenuItem.Size = new System.Drawing.Size(185, 26);
            this.ColourTheme_MenuItem.Text = "Colour Theme";
            // 
            // LightTheme_MenuItem
            // 
            this.LightTheme_MenuItem.Name = "LightTheme_MenuItem";
            this.LightTheme_MenuItem.Size = new System.Drawing.Size(125, 26);
            this.LightTheme_MenuItem.Text = "Light";
            this.LightTheme_MenuItem.Click += new System.EventHandler(this.LightTheme_MenuItem_Click);
            // 
            // DarkTheme_MenuItem
            // 
            this.DarkTheme_MenuItem.Name = "DarkTheme_MenuItem";
            this.DarkTheme_MenuItem.Size = new System.Drawing.Size(125, 26);
            this.DarkTheme_MenuItem.Text = "Dark";
            this.DarkTheme_MenuItem.Click += new System.EventHandler(this.DarkTheme_MenuItem_Click);
            // 
            // Documents_TabControl
            // 
            this.Documents_TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Documents_TabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.Documents_TabControl.Location = new System.Drawing.Point(3, 43);
            this.Documents_TabControl.Name = "Documents_TabControl";
            this.Documents_TabControl.SelectedIndex = 0;
            this.Documents_TabControl.Size = new System.Drawing.Size(1062, 388);
            this.Documents_TabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.Documents_TabControl.TabIndex = 1;
            this.Documents_TabControl.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Documents_TabControl_DrawItem);
            this.Documents_TabControl.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.Documents_TabControl_ControlAdded);
            this.Documents_TabControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Documents_TabControl_MouseDown);
            // 
            // MainStatusStrip
            // 
            this.MainStatusStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainStatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveLabel_StatusStrip});
            this.MainStatusStrip.Location = new System.Drawing.Point(0, 434);
            this.MainStatusStrip.Name = "MainStatusStrip";
            this.MainStatusStrip.Size = new System.Drawing.Size(1068, 30);
            this.MainStatusStrip.TabIndex = 2;
            // 
            // SaveLabel_StatusStrip
            // 
            this.SaveLabel_StatusStrip.Name = "SaveLabel_StatusStrip";
            this.SaveLabel_StatusStrip.Size = new System.Drawing.Size(0, 24);
            // 
            // ContextMenu
            // 
            this.ContextMenu.BackColor = System.Drawing.Color.White;
            this.ContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectAll_ContextMenuItem,
            this.Cut_ContextMenuItem,
            this.Copy_ContextMenuItem,
            this.Paste_ContextMenuItem,
            this.ToolStripSeparator_Context_1,
            this.FontSelector_ContextComboBox,
            this.FontSize_ContextComboBox,
            this.ToolStripSeparator_Context_2,
            this.Bold_ContextMenuItem,
            this.Italics_ContextMenuItem,
            this.Underlined_ContextMenuItem,
            this.Strikethrough_ContextMenuItem,
            this.ToolStripSeparator_Context_3,
            this.FontColour_ContextMenuItem,
            this.FormatCode_ContextMenuItem});
            this.ContextMenu.Name = "ContextMenuStrip";
            this.ContextMenu.Size = new System.Drawing.Size(311, 326);
            this.ContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenu_Opening);
            // 
            // SelectAll_ContextMenuItem
            // 
            this.SelectAll_ContextMenuItem.Name = "SelectAll_ContextMenuItem";
            this.SelectAll_ContextMenuItem.Size = new System.Drawing.Size(310, 24);
            this.SelectAll_ContextMenuItem.Text = "Select All";
            this.SelectAll_ContextMenuItem.Click += new System.EventHandler(this.SelectAll_ContextMenuItem_Click);
            // 
            // Cut_ContextMenuItem
            // 
            this.Cut_ContextMenuItem.Name = "Cut_ContextMenuItem";
            this.Cut_ContextMenuItem.Size = new System.Drawing.Size(310, 24);
            this.Cut_ContextMenuItem.Text = "Cut";
            this.Cut_ContextMenuItem.Click += new System.EventHandler(this.Cut_ContextMenuItem_Click);
            // 
            // Copy_ContextMenuItem
            // 
            this.Copy_ContextMenuItem.Name = "Copy_ContextMenuItem";
            this.Copy_ContextMenuItem.Size = new System.Drawing.Size(310, 24);
            this.Copy_ContextMenuItem.Text = "Copy";
            this.Copy_ContextMenuItem.Click += new System.EventHandler(this.Copy_ContextMenuItem_Click);
            // 
            // Paste_ContextMenuItem
            // 
            this.Paste_ContextMenuItem.Name = "Paste_ContextMenuItem";
            this.Paste_ContextMenuItem.Size = new System.Drawing.Size(310, 24);
            this.Paste_ContextMenuItem.Text = "Paste";
            this.Paste_ContextMenuItem.Click += new System.EventHandler(this.Paste_ContextMenuItem_Click);
            // 
            // ToolStripSeparator_Context_1
            // 
            this.ToolStripSeparator_Context_1.Name = "ToolStripSeparator_Context_1";
            this.ToolStripSeparator_Context_1.Size = new System.Drawing.Size(307, 6);
            // 
            // FontSelector_ContextComboBox
            // 
            this.FontSelector_ContextComboBox.AutoSize = false;
            this.FontSelector_ContextComboBox.DropDownHeight = 110;
            this.FontSelector_ContextComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FontSelector_ContextComboBox.IntegralHeight = false;
            this.FontSelector_ContextComboBox.Name = "FontSelector_ContextComboBox";
            this.FontSelector_ContextComboBox.Size = new System.Drawing.Size(250, 28);
            this.FontSelector_ContextComboBox.SelectedIndexChanged += new System.EventHandler(this.FontSelector_ContextComboBox_SelectedIndexChanged);
            // 
            // FontSize_ContextComboBox
            // 
            this.FontSize_ContextComboBox.AutoSize = false;
            this.FontSize_ContextComboBox.DropDownHeight = 110;
            this.FontSize_ContextComboBox.IntegralHeight = false;
            this.FontSize_ContextComboBox.MaxLength = 3;
            this.FontSize_ContextComboBox.Name = "FontSize_ContextComboBox";
            this.FontSize_ContextComboBox.Size = new System.Drawing.Size(50, 28);
            this.FontSize_ContextComboBox.SelectedIndexChanged += new System.EventHandler(this.FontSize_ContextComboBox_SelectedIndexChanged);
            // 
            // ToolStripSeparator_Context_2
            // 
            this.ToolStripSeparator_Context_2.Name = "ToolStripSeparator_Context_2";
            this.ToolStripSeparator_Context_2.Size = new System.Drawing.Size(307, 6);
            // 
            // Bold_ContextMenuItem
            // 
            this.Bold_ContextMenuItem.Name = "Bold_ContextMenuItem";
            this.Bold_ContextMenuItem.Size = new System.Drawing.Size(310, 24);
            this.Bold_ContextMenuItem.Text = "Bold";
            this.Bold_ContextMenuItem.Click += new System.EventHandler(this.Bold_ContextMenuItem_Click);
            // 
            // Italics_ContextMenuItem
            // 
            this.Italics_ContextMenuItem.Name = "Italics_ContextMenuItem";
            this.Italics_ContextMenuItem.Size = new System.Drawing.Size(310, 24);
            this.Italics_ContextMenuItem.Text = "Italics";
            this.Italics_ContextMenuItem.Click += new System.EventHandler(this.Italics_ContextMenuItem_Click);
            // 
            // Underlined_ContextMenuItem
            // 
            this.Underlined_ContextMenuItem.Name = "Underlined_ContextMenuItem";
            this.Underlined_ContextMenuItem.Size = new System.Drawing.Size(310, 24);
            this.Underlined_ContextMenuItem.Text = "Underlined";
            this.Underlined_ContextMenuItem.Click += new System.EventHandler(this.Underlined_ContextMenuItem_Click);
            // 
            // Strikethrough_ContextMenuItem
            // 
            this.Strikethrough_ContextMenuItem.Name = "Strikethrough_ContextMenuItem";
            this.Strikethrough_ContextMenuItem.Size = new System.Drawing.Size(310, 24);
            this.Strikethrough_ContextMenuItem.Text = "Strikethrough";
            this.Strikethrough_ContextMenuItem.Click += new System.EventHandler(this.Strikethrough_ContextMenuItem_Click);
            // 
            // ToolStripSeparator_Context_3
            // 
            this.ToolStripSeparator_Context_3.Name = "ToolStripSeparator_Context_3";
            this.ToolStripSeparator_Context_3.Size = new System.Drawing.Size(307, 6);
            // 
            // FontColour_ContextMenuItem
            // 
            this.FontColour_ContextMenuItem.Name = "FontColour_ContextMenuItem";
            this.FontColour_ContextMenuItem.Size = new System.Drawing.Size(310, 24);
            this.FontColour_ContextMenuItem.Text = "Font Colour";
            this.FontColour_ContextMenuItem.Click += new System.EventHandler(this.FontColour_ContextMenuItem_Click);
            // 
            // FormatCode_ContextMenuItem
            // 
            this.FormatCode_ContextMenuItem.Name = "FormatCode_ContextMenuItem";
            this.FormatCode_ContextMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.FormatCode_ContextMenuItem.Size = new System.Drawing.Size(310, 24);
            this.FormatCode_ContextMenuItem.Text = "Format Code";
            this.FormatCode_ContextMenuItem.Click += new System.EventHandler(this.FormatCode_ContextMenuItem_Click);
            // 
            // NotepadMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1068, 464);
            this.Controls.Add(this.MainTableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainToolbar;
            this.Name = "NotepadMainWindow";
            this.Text = "Notepad+";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NotepadMainWindow_FormClosing);
            this.MainTableLayoutPanel.ResumeLayout(false);
            this.MainTableLayoutPanel.PerformLayout();
            this.MainToolbar.ResumeLayout(false);
            this.MainToolbar.PerformLayout();
            this.MainStatusStrip.ResumeLayout(false);
            this.MainStatusStrip.PerformLayout();
            this.ContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
        private System.Windows.Forms.MenuStrip MainToolbar;
        private System.Windows.Forms.ToolStripMenuItem File_Menu;
        private System.Windows.Forms.ToolStripMenuItem New_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Open_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Save_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAs_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAll_MenuItem;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator_Context_1;
        private System.Windows.Forms.ToolStripMenuItem Exit_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Edit_Menu;
        private System.Windows.Forms.ToolStripMenuItem Undo_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Redo_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Cut_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Copy_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Paste_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem SelectAll_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Format_Menu;
        private System.Windows.Forms.ToolStripComboBox FontSelector_ComboBox;
        private System.Windows.Forms.ToolStripMenuItem Bold_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Italics_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Underlined_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Strikethrough_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem FontColour_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Settings_Menu;
        private System.Windows.Forms.ToolStripMenuItem Autosave_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem ColourTheme_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem LightTheme_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem DarkTheme_MenuItem;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator_1;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator_2;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator_3;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator_4;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator_5;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator_6;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator_7;
        private System.Windows.Forms.TabControl Documents_TabControl;
        private System.Windows.Forms.ContextMenuStrip ContextMenu;
        private System.Windows.Forms.ToolStripMenuItem SelectAll_ContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Cut_ContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Copy_ContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Paste_ContextMenuItem;
        private System.Windows.Forms.ToolStripComboBox FontSelector_ContextComboBox;
        private System.Windows.Forms.ToolStripMenuItem Bold_ContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Italics_ContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Underlined_ContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Strikethrough_ContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FontColour_ContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewInNewWindow_MenuItem;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator_Context_2;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator_Context_3;
        private System.Windows.Forms.ToolStripComboBox FontSize_ComboBox;
        private System.Windows.Forms.ToolStripComboBox FontSize_ContextComboBox;
        private System.Windows.Forms.StatusStrip MainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel SaveLabel_StatusStrip;
        private System.Windows.Forms.ToolStripMenuItem NewCSFile_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem FormatCode_ContextMenuItem;
    }

}