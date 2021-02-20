namespace NotepadPlus
{

    partial class Settings
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.Autosave_Label = new System.Windows.Forms.Label();
            this.Autosave_ComboBox = new System.Windows.Forms.ComboBox();
            this.ApplyChanges_Button = new System.Windows.Forms.Button();
            this.Backup_Label = new System.Windows.Forms.Label();
            this.Backup_ComboBox = new System.Windows.Forms.ComboBox();
            this.CommentColour_Label = new System.Windows.Forms.Label();
            this.AttributeColour_Label = new System.Windows.Forms.Label();
            this.ClassColour_Label = new System.Windows.Forms.Label();
            this.CommentTagColour_Label = new System.Windows.Forms.Label();
            this.KeywordColour_Label = new System.Windows.Forms.Label();
            this.NumberColour_Label = new System.Windows.Forms.Label();
            this.StringColour_Label = new System.Windows.Forms.Label();
            this.VariableColour_Label = new System.Windows.Forms.Label();
            this.AttributeColour_Button = new System.Windows.Forms.Button();
            this.ClassColour_Button = new System.Windows.Forms.Button();
            this.CommentColour_Button = new System.Windows.Forms.Button();
            this.CommentTagColour_Button = new System.Windows.Forms.Button();
            this.KeywordColour_Button = new System.Windows.Forms.Button();
            this.NumberColour_Button = new System.Windows.Forms.Button();
            this.StringColour_Button = new System.Windows.Forms.Button();
            this.VariableColour_Button = new System.Windows.Forms.Button();
            this.Instruction_Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Autosave_Label
            // 
            this.Autosave_Label.AutoSize = true;
            this.Autosave_Label.Location = new System.Drawing.Point(199, 28);
            this.Autosave_Label.Name = "Autosave_Label";
            this.Autosave_Label.Size = new System.Drawing.Size(144, 20);
            this.Autosave_Label.TabIndex = 0;
            this.Autosave_Label.Text = "Autosave Frequency:";
            // 
            // Autosave_ComboBox
            // 
            this.Autosave_ComboBox.DropDownHeight = 110;
            this.Autosave_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Autosave_ComboBox.DropDownWidth = 50;
            this.Autosave_ComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Autosave_ComboBox.FormattingEnabled = true;
            this.Autosave_ComboBox.IntegralHeight = false;
            this.Autosave_ComboBox.Location = new System.Drawing.Point(379, 25);
            this.Autosave_ComboBox.Name = "Autosave_ComboBox";
            this.Autosave_ComboBox.Size = new System.Drawing.Size(220, 28);
            this.Autosave_ComboBox.TabIndex = 1;
            // 
            // ApplyChanges_Button
            // 
            this.ApplyChanges_Button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ApplyChanges_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ApplyChanges_Button.Location = new System.Drawing.Point(321, 391);
            this.ApplyChanges_Button.Name = "ApplyChanges_Button";
            this.ApplyChanges_Button.Size = new System.Drawing.Size(150, 50);
            this.ApplyChanges_Button.TabIndex = 2;
            this.ApplyChanges_Button.Text = "Apply Changes";
            this.ApplyChanges_Button.UseVisualStyleBackColor = true;
            this.ApplyChanges_Button.Click += new System.EventHandler(this.ApplyChanges_Button_Click);
            // 
            // Backup_Label
            // 
            this.Backup_Label.Location = new System.Drawing.Point(199, 89);
            this.Backup_Label.Name = "Backup_Label";
            this.Backup_Label.Size = new System.Drawing.Size(144, 20);
            this.Backup_Label.TabIndex = 3;
            this.Backup_Label.Text = "Backup Frequency:";
            // 
            // Backup_ComboBox
            // 
            this.Backup_ComboBox.DropDownHeight = 110;
            this.Backup_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Backup_ComboBox.DropDownWidth = 50;
            this.Backup_ComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Backup_ComboBox.FormattingEnabled = true;
            this.Backup_ComboBox.IntegralHeight = false;
            this.Backup_ComboBox.Location = new System.Drawing.Point(379, 86);
            this.Backup_ComboBox.Name = "Backup_ComboBox";
            this.Backup_ComboBox.Size = new System.Drawing.Size(220, 28);
            this.Backup_ComboBox.TabIndex = 4;
            // 
            // CommentColour_Label
            // 
            this.CommentColour_Label.Location = new System.Drawing.Point(40, 234);
            this.CommentColour_Label.Name = "CommentColour_Label";
            this.CommentColour_Label.Size = new System.Drawing.Size(200, 25);
            this.CommentColour_Label.TabIndex = 5;
            this.CommentColour_Label.Text = "C# Comment Colour:";
            // 
            // AttributeColour_Label
            // 
            this.AttributeColour_Label.Location = new System.Drawing.Point(40, 154);
            this.AttributeColour_Label.Name = "AttributeColour_Label";
            this.AttributeColour_Label.Size = new System.Drawing.Size(200, 25);
            this.AttributeColour_Label.TabIndex = 6;
            this.AttributeColour_Label.Text = "C# Attribute Colour:";
            // 
            // ClassColour_Label
            // 
            this.ClassColour_Label.Location = new System.Drawing.Point(40, 194);
            this.ClassColour_Label.Name = "ClassColour_Label";
            this.ClassColour_Label.Size = new System.Drawing.Size(200, 25);
            this.ClassColour_Label.TabIndex = 7;
            this.ClassColour_Label.Text = "C# Class Colour:";
            // 
            // CommentTagColour_Label
            // 
            this.CommentTagColour_Label.Location = new System.Drawing.Point(40, 276);
            this.CommentTagColour_Label.Name = "CommentTagColour_Label";
            this.CommentTagColour_Label.Size = new System.Drawing.Size(200, 25);
            this.CommentTagColour_Label.TabIndex = 8;
            this.CommentTagColour_Label.Text = "C# Comment Tag Colour:";
            // 
            // KeywordColour_Label
            // 
            this.KeywordColour_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.KeywordColour_Label.Location = new System.Drawing.Point(426, 152);
            this.KeywordColour_Label.Name = "KeywordColour_Label";
            this.KeywordColour_Label.Size = new System.Drawing.Size(200, 25);
            this.KeywordColour_Label.TabIndex = 9;
            this.KeywordColour_Label.Text = "C# Keyword Colour:";
            // 
            // NumberColour_Label
            // 
            this.NumberColour_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NumberColour_Label.Location = new System.Drawing.Point(426, 192);
            this.NumberColour_Label.Name = "NumberColour_Label";
            this.NumberColour_Label.Size = new System.Drawing.Size(200, 25);
            this.NumberColour_Label.TabIndex = 10;
            this.NumberColour_Label.Text = "C# Number Colour:";
            // 
            // StringColour_Label
            // 
            this.StringColour_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StringColour_Label.Location = new System.Drawing.Point(426, 233);
            this.StringColour_Label.Name = "StringColour_Label";
            this.StringColour_Label.Size = new System.Drawing.Size(200, 25);
            this.StringColour_Label.TabIndex = 11;
            this.StringColour_Label.Text = "C# String Colour:";
            // 
            // VariableColour_Label
            // 
            this.VariableColour_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.VariableColour_Label.Location = new System.Drawing.Point(426, 274);
            this.VariableColour_Label.Name = "VariableColour_Label";
            this.VariableColour_Label.Size = new System.Drawing.Size(200, 25);
            this.VariableColour_Label.TabIndex = 12;
            this.VariableColour_Label.Text = "C# Variable Colour:";
            // 
            // AttributeColour_Button
            // 
            this.AttributeColour_Button.Location = new System.Drawing.Point(234, 154);
            this.AttributeColour_Button.Name = "AttributeColour_Button";
            this.AttributeColour_Button.Size = new System.Drawing.Size(100, 25);
            this.AttributeColour_Button.TabIndex = 13;
            this.AttributeColour_Button.UseVisualStyleBackColor = true;
            this.AttributeColour_Button.Click += new System.EventHandler(this.AttributeColour_Button_Click);
            // 
            // ClassColour_Button
            // 
            this.ClassColour_Button.Location = new System.Drawing.Point(234, 194);
            this.ClassColour_Button.Name = "ClassColour_Button";
            this.ClassColour_Button.Size = new System.Drawing.Size(100, 25);
            this.ClassColour_Button.TabIndex = 14;
            this.ClassColour_Button.UseVisualStyleBackColor = true;
            this.ClassColour_Button.Click += new System.EventHandler(this.ClassColour_Button_Click);
            // 
            // CommentColour_Button
            // 
            this.CommentColour_Button.Location = new System.Drawing.Point(234, 234);
            this.CommentColour_Button.Name = "CommentColour_Button";
            this.CommentColour_Button.Size = new System.Drawing.Size(100, 25);
            this.CommentColour_Button.TabIndex = 15;
            this.CommentColour_Button.UseVisualStyleBackColor = true;
            this.CommentColour_Button.Click += new System.EventHandler(this.CommentColour_Button_Click);
            // 
            // CommentTagColour_Button
            // 
            this.CommentTagColour_Button.Location = new System.Drawing.Point(234, 276);
            this.CommentTagColour_Button.Name = "CommentTagColour_Button";
            this.CommentTagColour_Button.Size = new System.Drawing.Size(100, 25);
            this.CommentTagColour_Button.TabIndex = 16;
            this.CommentTagColour_Button.UseVisualStyleBackColor = true;
            this.CommentTagColour_Button.Click += new System.EventHandler(this.CommentTagColour_Button_Click);
            // 
            // KeywordColour_Button
            // 
            this.KeywordColour_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.KeywordColour_Button.Location = new System.Drawing.Point(613, 152);
            this.KeywordColour_Button.Name = "KeywordColour_Button";
            this.KeywordColour_Button.Size = new System.Drawing.Size(100, 25);
            this.KeywordColour_Button.TabIndex = 17;
            this.KeywordColour_Button.UseVisualStyleBackColor = true;
            this.KeywordColour_Button.Click += new System.EventHandler(this.KeywordColour_Button_Click);
            // 
            // NumberColour_Button
            // 
            this.NumberColour_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NumberColour_Button.Location = new System.Drawing.Point(613, 192);
            this.NumberColour_Button.Name = "NumberColour_Button";
            this.NumberColour_Button.Size = new System.Drawing.Size(100, 25);
            this.NumberColour_Button.TabIndex = 18;
            this.NumberColour_Button.UseVisualStyleBackColor = true;
            this.NumberColour_Button.Click += new System.EventHandler(this.NumberColour_Button_Click);
            // 
            // StringColour_Button
            // 
            this.StringColour_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StringColour_Button.Location = new System.Drawing.Point(613, 233);
            this.StringColour_Button.Name = "StringColour_Button";
            this.StringColour_Button.Size = new System.Drawing.Size(100, 25);
            this.StringColour_Button.TabIndex = 19;
            this.StringColour_Button.UseVisualStyleBackColor = true;
            this.StringColour_Button.Click += new System.EventHandler(this.StringColour_Button_Click);
            // 
            // VariableColour_Button
            // 
            this.VariableColour_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.VariableColour_Button.Location = new System.Drawing.Point(613, 274);
            this.VariableColour_Button.Name = "VariableColour_Button";
            this.VariableColour_Button.Size = new System.Drawing.Size(100, 25);
            this.VariableColour_Button.TabIndex = 20;
            this.VariableColour_Button.UseVisualStyleBackColor = true;
            this.VariableColour_Button.Click += new System.EventHandler(this.VariableColour_Button_Click);
            // 
            // Instruction_Label
            // 
            this.Instruction_Label.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Instruction_Label.Location = new System.Drawing.Point(199, 338);
            this.Instruction_Label.Name = "Instruction_Label";
            this.Instruction_Label.Size = new System.Drawing.Size(400, 50);
            this.Instruction_Label.TabIndex = 21;
            this.Instruction_Label.Text = "Press the buttons above to change the colour of the corresponding lexemes in C# c" +
    "ode";
            this.Instruction_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 453);
            this.Controls.Add(this.Instruction_Label);
            this.Controls.Add(this.VariableColour_Button);
            this.Controls.Add(this.StringColour_Button);
            this.Controls.Add(this.NumberColour_Button);
            this.Controls.Add(this.KeywordColour_Button);
            this.Controls.Add(this.CommentTagColour_Button);
            this.Controls.Add(this.CommentColour_Button);
            this.Controls.Add(this.ClassColour_Button);
            this.Controls.Add(this.AttributeColour_Button);
            this.Controls.Add(this.VariableColour_Label);
            this.Controls.Add(this.StringColour_Label);
            this.Controls.Add(this.NumberColour_Label);
            this.Controls.Add(this.KeywordColour_Label);
            this.Controls.Add(this.CommentTagColour_Label);
            this.Controls.Add(this.ClassColour_Label);
            this.Controls.Add(this.AttributeColour_Label);
            this.Controls.Add(this.CommentColour_Label);
            this.Controls.Add(this.Backup_ComboBox);
            this.Controls.Add(this.Backup_Label);
            this.Controls.Add(this.ApplyChanges_Button);
            this.Controls.Add(this.Autosave_ComboBox);
            this.Controls.Add(this.Autosave_Label);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Autosave_Label;
        private System.Windows.Forms.ComboBox Autosave_ComboBox;
        private System.Windows.Forms.Button ApplyChanges_Button;
        private System.Windows.Forms.Label Backup_Label;
        private System.Windows.Forms.ComboBox Backup_ComboBox;
        private System.Windows.Forms.Label CommentColour_Label;
        private System.Windows.Forms.Label AttributeColour_Label;
        private System.Windows.Forms.Label ClassColour_Label;
        private System.Windows.Forms.Label CommentTagColour_Label;
        private System.Windows.Forms.Label KeywordColour_Label;
        private System.Windows.Forms.Label NumberColour_Label;
        private System.Windows.Forms.Label StringColour_Label;
        private System.Windows.Forms.Label VariableColour_Label;
        private System.Windows.Forms.Button AttributeColour_Button;
        private System.Windows.Forms.Button ClassColour_Button;
        private System.Windows.Forms.Button CommentColour_Button;
        private System.Windows.Forms.Button CommentTagColour_Button;
        private System.Windows.Forms.Button KeywordColour_Button;
        private System.Windows.Forms.Button NumberColour_Button;
        private System.Windows.Forms.Button StringColour_Button;
        private System.Windows.Forms.Button VariableColour_Button;
        private System.Windows.Forms.Label Instruction_Label;

    }

}