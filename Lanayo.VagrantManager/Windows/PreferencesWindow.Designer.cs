namespace Lanayo.Vagrant_Manager.Windows {
    partial class PreferencesWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreferencesWindow));
            this.DoneButton = new System.Windows.Forms.Button();
            this.tabNavigation = new System.Windows.Forms.TabControl();
            this.tpMain = new System.Windows.Forms.TabPage();
            this.PreferencesPanel = new System.Windows.Forms.Panel();
            this.AutoCloseTaskWindowLabel = new System.Windows.Forms.Label();
            this.IncludeMachineNamesLabel = new System.Windows.Forms.Label();
            this.InstancePathAsDisplayLabel = new System.Windows.Forms.Label();
            this.RefreshEveryComboBox = new System.Windows.Forms.ComboBox();
            this.RefreshEveryCheckBox = new System.Windows.Forms.CheckBox();
            this.AutoCloseTaskWindowCheckBox = new System.Windows.Forms.CheckBox();
            this.IncludeMachineNamesCheckBox = new System.Windows.Forms.CheckBox();
            this.InstancePathAsDisplayCheckBox = new System.Windows.Forms.CheckBox();
            this.UpdateNotificationCheckBox = new System.Windows.Forms.CheckBox();
            this.LaunchAtLoginCheckBox = new System.Windows.Forms.CheckBox();
            this.tpHelpers = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CommandPromptBrowseButton = new System.Windows.Forms.Button();
            this.CommandPromptTextBox = new System.Windows.Forms.TextBox();
            this.lblCommandPrompt = new System.Windows.Forms.Label();
            this.VirtualBoxPathStatusTextBox = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.VirtualBoxBrowseButton = new System.Windows.Forms.Button();
            this.VirtualBoxPathTextBox = new System.Windows.Forms.TextBox();
            this.CommandPromptPathStatusTextBox = new System.Windows.Forms.Label();
            this.tabNavigation.SuspendLayout();
            this.tpMain.SuspendLayout();
            this.PreferencesPanel.SuspendLayout();
            this.tpHelpers.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DoneButton
            // 
            this.DoneButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DoneButton.Location = new System.Drawing.Point(183, 309);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(75, 23);
            this.DoneButton.TabIndex = 1;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = true;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // tabNavigation
            // 
            this.tabNavigation.Controls.Add(this.tpMain);
            this.tabNavigation.Controls.Add(this.tpHelpers);
            this.tabNavigation.Location = new System.Drawing.Point(11, 12);
            this.tabNavigation.Name = "tabNavigation";
            this.tabNavigation.SelectedIndex = 0;
            this.tabNavigation.Size = new System.Drawing.Size(251, 289);
            this.tabNavigation.TabIndex = 2;
            // 
            // tpMain
            // 
            this.tpMain.Controls.Add(this.PreferencesPanel);
            this.tpMain.Location = new System.Drawing.Point(4, 22);
            this.tpMain.Name = "tpMain";
            this.tpMain.Padding = new System.Windows.Forms.Padding(3);
            this.tpMain.Size = new System.Drawing.Size(243, 263);
            this.tpMain.TabIndex = 0;
            this.tpMain.Text = "Main";
            this.tpMain.UseVisualStyleBackColor = true;
            // 
            // PreferencesPanel
            // 
            this.PreferencesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PreferencesPanel.BackColor = System.Drawing.Color.LightGray;
            this.PreferencesPanel.Controls.Add(this.AutoCloseTaskWindowLabel);
            this.PreferencesPanel.Controls.Add(this.IncludeMachineNamesLabel);
            this.PreferencesPanel.Controls.Add(this.InstancePathAsDisplayLabel);
            this.PreferencesPanel.Controls.Add(this.RefreshEveryComboBox);
            this.PreferencesPanel.Controls.Add(this.RefreshEveryCheckBox);
            this.PreferencesPanel.Controls.Add(this.AutoCloseTaskWindowCheckBox);
            this.PreferencesPanel.Controls.Add(this.IncludeMachineNamesCheckBox);
            this.PreferencesPanel.Controls.Add(this.InstancePathAsDisplayCheckBox);
            this.PreferencesPanel.Controls.Add(this.UpdateNotificationCheckBox);
            this.PreferencesPanel.Controls.Add(this.LaunchAtLoginCheckBox);
            this.PreferencesPanel.Location = new System.Drawing.Point(-4, -15);
            this.PreferencesPanel.Name = "PreferencesPanel";
            this.PreferencesPanel.Size = new System.Drawing.Size(250, 292);
            this.PreferencesPanel.TabIndex = 1;
            // 
            // AutoCloseTaskWindowLabel
            // 
            this.AutoCloseTaskWindowLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AutoCloseTaskWindowLabel.AutoSize = true;
            this.AutoCloseTaskWindowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoCloseTaskWindowLabel.Location = new System.Drawing.Point(49, 204);
            this.AutoCloseTaskWindowLabel.Name = "AutoCloseTaskWindowLabel";
            this.AutoCloseTaskWindowLabel.Size = new System.Drawing.Size(149, 24);
            this.AutoCloseTaskWindowLabel.TabIndex = 12;
            this.AutoCloseTaskWindowLabel.Text = "Automatically close the task output\r\nwindow if the task was successful";
            // 
            // IncludeMachineNamesLabel
            // 
            this.IncludeMachineNamesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IncludeMachineNamesLabel.AutoSize = true;
            this.IncludeMachineNamesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IncludeMachineNamesLabel.Location = new System.Drawing.Point(49, 154);
            this.IncludeMachineNamesLabel.Name = "IncludeMachineNamesLabel";
            this.IncludeMachineNamesLabel.Size = new System.Drawing.Size(129, 24);
            this.IncludeMachineNamesLabel.TabIndex = 11;
            this.IncludeMachineNamesLabel.Text = "Include machine names in top-\r\nlevel menu item labels";
            // 
            // InstancePathAsDisplayLabel
            // 
            this.InstancePathAsDisplayLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.InstancePathAsDisplayLabel.AutoSize = true;
            this.InstancePathAsDisplayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstancePathAsDisplayLabel.Location = new System.Drawing.Point(49, 101);
            this.InstancePathAsDisplayLabel.Name = "InstancePathAsDisplayLabel";
            this.InstancePathAsDisplayLabel.Size = new System.Drawing.Size(153, 24);
            this.InstancePathAsDisplayLabel.TabIndex = 10;
            this.InstancePathAsDisplayLabel.Text = "Use the path to the vagrant instance\r\nfor the menu item label";
            // 
            // RefreshEveryComboBox
            // 
            this.RefreshEveryComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RefreshEveryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RefreshEveryComboBox.FormattingEnabled = true;
            this.RefreshEveryComboBox.Location = new System.Drawing.Point(125, 239);
            this.RefreshEveryComboBox.Name = "RefreshEveryComboBox";
            this.RefreshEveryComboBox.Size = new System.Drawing.Size(96, 21);
            this.RefreshEveryComboBox.TabIndex = 9;
            this.RefreshEveryComboBox.SelectedIndexChanged += new System.EventHandler(this.RefreshEveryComboBox_SelectedIndexChanged);
            // 
            // RefreshEveryCheckBox
            // 
            this.RefreshEveryCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RefreshEveryCheckBox.AutoSize = true;
            this.RefreshEveryCheckBox.Location = new System.Drawing.Point(33, 241);
            this.RefreshEveryCheckBox.Name = "RefreshEveryCheckBox";
            this.RefreshEveryCheckBox.Size = new System.Drawing.Size(93, 17);
            this.RefreshEveryCheckBox.TabIndex = 8;
            this.RefreshEveryCheckBox.Text = "Refresh Every";
            this.RefreshEveryCheckBox.UseVisualStyleBackColor = true;
            this.RefreshEveryCheckBox.CheckedChanged += new System.EventHandler(this.RefreshEveryCheckBox_CheckedChanged);
            // 
            // AutoCloseTaskWindowCheckBox
            // 
            this.AutoCloseTaskWindowCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AutoCloseTaskWindowCheckBox.AutoSize = true;
            this.AutoCloseTaskWindowCheckBox.Location = new System.Drawing.Point(33, 184);
            this.AutoCloseTaskWindowCheckBox.Name = "AutoCloseTaskWindowCheckBox";
            this.AutoCloseTaskWindowCheckBox.Size = new System.Drawing.Size(138, 17);
            this.AutoCloseTaskWindowCheckBox.TabIndex = 7;
            this.AutoCloseTaskWindowCheckBox.Text = "Auto-close task window";
            this.AutoCloseTaskWindowCheckBox.UseVisualStyleBackColor = true;
            this.AutoCloseTaskWindowCheckBox.CheckedChanged += new System.EventHandler(this.AutoCloseTaskWindowCheckBox_CheckedChanged);
            // 
            // IncludeMachineNamesCheckBox
            // 
            this.IncludeMachineNamesCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IncludeMachineNamesCheckBox.AutoSize = true;
            this.IncludeMachineNamesCheckBox.Location = new System.Drawing.Point(33, 134);
            this.IncludeMachineNamesCheckBox.Name = "IncludeMachineNamesCheckBox";
            this.IncludeMachineNamesCheckBox.Size = new System.Drawing.Size(138, 17);
            this.IncludeMachineNamesCheckBox.TabIndex = 6;
            this.IncludeMachineNamesCheckBox.Text = "Include machine names";
            this.IncludeMachineNamesCheckBox.UseVisualStyleBackColor = true;
            this.IncludeMachineNamesCheckBox.CheckedChanged += new System.EventHandler(this.IncludeMachineNamesCheckBox_CheckedChanged);
            // 
            // InstancePathAsDisplayCheckBox
            // 
            this.InstancePathAsDisplayCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.InstancePathAsDisplayCheckBox.AutoSize = true;
            this.InstancePathAsDisplayCheckBox.Location = new System.Drawing.Point(33, 78);
            this.InstancePathAsDisplayCheckBox.Name = "InstancePathAsDisplayCheckBox";
            this.InstancePathAsDisplayCheckBox.Size = new System.Drawing.Size(190, 17);
            this.InstancePathAsDisplayCheckBox.TabIndex = 5;
            this.InstancePathAsDisplayCheckBox.Text = "Use instance path as display name";
            this.InstancePathAsDisplayCheckBox.UseVisualStyleBackColor = true;
            this.InstancePathAsDisplayCheckBox.CheckedChanged += new System.EventHandler(this.InstancePathAsDisplayCheckBox_CheckedChanged);
            // 
            // UpdateNotificationCheckBox
            // 
            this.UpdateNotificationCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateNotificationCheckBox.AutoSize = true;
            this.UpdateNotificationCheckBox.Location = new System.Drawing.Point(33, 54);
            this.UpdateNotificationCheckBox.Name = "UpdateNotificationCheckBox";
            this.UpdateNotificationCheckBox.Size = new System.Drawing.Size(169, 17);
            this.UpdateNotificationCheckBox.TabIndex = 4;
            this.UpdateNotificationCheckBox.Text = "Don\'t show update notification";
            this.UpdateNotificationCheckBox.UseVisualStyleBackColor = true;
            this.UpdateNotificationCheckBox.CheckedChanged += new System.EventHandler(this.UpdateNotificationCheckBox_CheckedChanged);
            // 
            // LaunchAtLoginCheckBox
            // 
            this.LaunchAtLoginCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LaunchAtLoginCheckBox.AutoSize = true;
            this.LaunchAtLoginCheckBox.Location = new System.Drawing.Point(33, 31);
            this.LaunchAtLoginCheckBox.Name = "LaunchAtLoginCheckBox";
            this.LaunchAtLoginCheckBox.Size = new System.Drawing.Size(99, 17);
            this.LaunchAtLoginCheckBox.TabIndex = 2;
            this.LaunchAtLoginCheckBox.Text = "Launch at login";
            this.LaunchAtLoginCheckBox.UseVisualStyleBackColor = true;
            this.LaunchAtLoginCheckBox.CheckedChanged += new System.EventHandler(this.LaunchAtLoginCheckBox_CheckedChanged);
            // 
            // tpHelpers
            // 
            this.tpHelpers.Controls.Add(this.panel1);
            this.tpHelpers.Location = new System.Drawing.Point(4, 22);
            this.tpHelpers.Name = "tpHelpers";
            this.tpHelpers.Padding = new System.Windows.Forms.Padding(3);
            this.tpHelpers.Size = new System.Drawing.Size(243, 263);
            this.tpHelpers.TabIndex = 1;
            this.tpHelpers.Text = "Applications";
            this.tpHelpers.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.CommandPromptPathStatusTextBox);
            this.panel1.Controls.Add(this.CommandPromptBrowseButton);
            this.panel1.Controls.Add(this.CommandPromptTextBox);
            this.panel1.Controls.Add(this.lblCommandPrompt);
            this.panel1.Controls.Add(this.VirtualBoxPathStatusTextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.VirtualBoxBrowseButton);
            this.panel1.Controls.Add(this.VirtualBoxPathTextBox);
            this.panel1.Location = new System.Drawing.Point(-4, -15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 292);
            this.panel1.TabIndex = 2;
            // 
            // CommandPromptBrowseButton
            // 
            this.CommandPromptBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CommandPromptBrowseButton.Location = new System.Drawing.Point(167, 98);
            this.CommandPromptBrowseButton.Name = "CommandPromptBrowseButton";
            this.CommandPromptBrowseButton.Size = new System.Drawing.Size(60, 22);
            this.CommandPromptBrowseButton.TabIndex = 23;
            this.CommandPromptBrowseButton.Text = "Browse";
            this.CommandPromptBrowseButton.UseVisualStyleBackColor = true;
            this.CommandPromptBrowseButton.Click += new System.EventHandler(this.CommandPromptBrowseButton_Click);
            // 
            // CommandPromptTextBox
            // 
            this.CommandPromptTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CommandPromptTextBox.Location = new System.Drawing.Point(24, 100);
            this.CommandPromptTextBox.Name = "CommandPromptTextBox";
            this.CommandPromptTextBox.Size = new System.Drawing.Size(137, 20);
            this.CommandPromptTextBox.TabIndex = 22;
            // 
            // lblCommandPrompt
            // 
            this.lblCommandPrompt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCommandPrompt.AutoSize = true;
            this.lblCommandPrompt.Location = new System.Drawing.Point(21, 84);
            this.lblCommandPrompt.Name = "lblCommandPrompt";
            this.lblCommandPrompt.Size = new System.Drawing.Size(133, 13);
            this.lblCommandPrompt.TabIndex = 21;
            this.lblCommandPrompt.Text = "Command prompt | Status: ";
            // 
            // VirtualBoxPathStatusTextBox
            // 
            this.VirtualBoxPathStatusTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.VirtualBoxPathStatusTextBox.AutoSize = true;
            this.VirtualBoxPathStatusTextBox.ForeColor = System.Drawing.Color.DarkGreen;
            this.VirtualBoxPathStatusTextBox.Location = new System.Drawing.Point(150, 29);
            this.VirtualBoxPathStatusTextBox.Name = "VirtualBoxPathStatusTextBox";
            this.VirtualBoxPathStatusTextBox.Size = new System.Drawing.Size(39, 13);
            this.VirtualBoxPathStatusTextBox.TabIndex = 20;
            this.VirtualBoxPathStatusTextBox.Text = "Linked";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "VBoxManage.exe | Status:";
            // 
            // VirtualBoxBrowseButton
            // 
            this.VirtualBoxBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.VirtualBoxBrowseButton.Location = new System.Drawing.Point(167, 45);
            this.VirtualBoxBrowseButton.Name = "VirtualBoxBrowseButton";
            this.VirtualBoxBrowseButton.Size = new System.Drawing.Size(60, 22);
            this.VirtualBoxBrowseButton.TabIndex = 18;
            this.VirtualBoxBrowseButton.Text = "Browse";
            this.VirtualBoxBrowseButton.UseVisualStyleBackColor = true;
            this.VirtualBoxBrowseButton.Click += new System.EventHandler(this.VirtualBoxBrowseButton_Click);
            // 
            // VirtualBoxPathTextBox
            // 
            this.VirtualBoxPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.VirtualBoxPathTextBox.Location = new System.Drawing.Point(24, 47);
            this.VirtualBoxPathTextBox.Name = "VirtualBoxPathTextBox";
            this.VirtualBoxPathTextBox.Size = new System.Drawing.Size(137, 20);
            this.VirtualBoxPathTextBox.TabIndex = 17;
            // 
            // CommandPromptPathStatusTextBox
            // 
            this.CommandPromptPathStatusTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CommandPromptPathStatusTextBox.AutoSize = true;
            this.CommandPromptPathStatusTextBox.ForeColor = System.Drawing.Color.DarkGreen;
            this.CommandPromptPathStatusTextBox.Location = new System.Drawing.Point(150, 84);
            this.CommandPromptPathStatusTextBox.Name = "CommandPromptPathStatusTextBox";
            this.CommandPromptPathStatusTextBox.Size = new System.Drawing.Size(39, 13);
            this.CommandPromptPathStatusTextBox.TabIndex = 24;
            this.CommandPromptPathStatusTextBox.Text = "Linked";
            // 
            // PreferencesWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 344);
            this.Controls.Add(this.tabNavigation);
            this.Controls.Add(this.DoneButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PreferencesWindow";
            this.Text = "Preferences";
            this.Load += new System.EventHandler(this.PreferencesWindow_Load);
            this.tabNavigation.ResumeLayout(false);
            this.tpMain.ResumeLayout(false);
            this.PreferencesPanel.ResumeLayout(false);
            this.PreferencesPanel.PerformLayout();
            this.tpHelpers.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.TabControl tabNavigation;
        private System.Windows.Forms.TabPage tpMain;
        private System.Windows.Forms.Panel PreferencesPanel;
        private System.Windows.Forms.Label AutoCloseTaskWindowLabel;
        private System.Windows.Forms.Label IncludeMachineNamesLabel;
        private System.Windows.Forms.Label InstancePathAsDisplayLabel;
        private System.Windows.Forms.ComboBox RefreshEveryComboBox;
        private System.Windows.Forms.CheckBox RefreshEveryCheckBox;
        private System.Windows.Forms.CheckBox AutoCloseTaskWindowCheckBox;
        private System.Windows.Forms.CheckBox IncludeMachineNamesCheckBox;
        private System.Windows.Forms.CheckBox InstancePathAsDisplayCheckBox;
        private System.Windows.Forms.CheckBox UpdateNotificationCheckBox;
        private System.Windows.Forms.CheckBox LaunchAtLoginCheckBox;
        private System.Windows.Forms.TabPage tpHelpers;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCommandPrompt;
        private System.Windows.Forms.Label VirtualBoxPathStatusTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button VirtualBoxBrowseButton;
        private System.Windows.Forms.TextBox VirtualBoxPathTextBox;
        private System.Windows.Forms.Button CommandPromptBrowseButton;
        private System.Windows.Forms.TextBox CommandPromptTextBox;
        private System.Windows.Forms.Label CommandPromptPathStatusTextBox;
    }
}