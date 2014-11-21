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
            this.PreferencesPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.VirtualBoxBrowseButton = new System.Windows.Forms.Button();
            this.VirtualBoxPathTextBox = new System.Windows.Forms.TextBox();
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
            this.DoneButton = new System.Windows.Forms.Button();
            this.VirtualBoxPathStatusTextBox = new System.Windows.Forms.Label();
            this.PreferencesPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PreferencesPanel
            // 
            this.PreferencesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PreferencesPanel.BackColor = System.Drawing.Color.LightGray;
            this.PreferencesPanel.Controls.Add(this.VirtualBoxPathStatusTextBox);
            this.PreferencesPanel.Controls.Add(this.label1);
            this.PreferencesPanel.Controls.Add(this.VirtualBoxBrowseButton);
            this.PreferencesPanel.Controls.Add(this.VirtualBoxPathTextBox);
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
            this.PreferencesPanel.Location = new System.Drawing.Point(12, 12);
            this.PreferencesPanel.Name = "PreferencesPanel";
            this.PreferencesPanel.Size = new System.Drawing.Size(250, 356);
            this.PreferencesPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 276);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "VBoxManage.exe | Status:";
            // 
            // VirtualBoxBrowseButton
            // 
            this.VirtualBoxBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.VirtualBoxBrowseButton.Location = new System.Drawing.Point(161, 292);
            this.VirtualBoxBrowseButton.Name = "VirtualBoxBrowseButton";
            this.VirtualBoxBrowseButton.Size = new System.Drawing.Size(60, 23);
            this.VirtualBoxBrowseButton.TabIndex = 14;
            this.VirtualBoxBrowseButton.Text = "Browse";
            this.VirtualBoxBrowseButton.UseVisualStyleBackColor = true;
            this.VirtualBoxBrowseButton.Click += new System.EventHandler(this.VirtualBoxBrowseButton_Click);
            // 
            // VirtualBoxPathTextBox
            // 
            this.VirtualBoxPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.VirtualBoxPathTextBox.Location = new System.Drawing.Point(34, 294);
            this.VirtualBoxPathTextBox.Name = "VirtualBoxPathTextBox";
            this.VirtualBoxPathTextBox.Size = new System.Drawing.Size(121, 20);
            this.VirtualBoxPathTextBox.TabIndex = 13;
            // 
            // AutoCloseTaskWindowLabel
            // 
            this.AutoCloseTaskWindowLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AutoCloseTaskWindowLabel.AutoSize = true;
            this.AutoCloseTaskWindowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoCloseTaskWindowLabel.Location = new System.Drawing.Point(50, 195);
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
            this.IncludeMachineNamesLabel.Location = new System.Drawing.Point(50, 145);
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
            this.InstancePathAsDisplayLabel.Location = new System.Drawing.Point(50, 92);
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
            this.RefreshEveryComboBox.Location = new System.Drawing.Point(126, 230);
            this.RefreshEveryComboBox.Name = "RefreshEveryComboBox";
            this.RefreshEveryComboBox.Size = new System.Drawing.Size(96, 21);
            this.RefreshEveryComboBox.TabIndex = 9;
            this.RefreshEveryComboBox.SelectedIndexChanged += new System.EventHandler(this.RefreshEveryComboBox_SelectedIndexChanged);
            // 
            // RefreshEveryCheckBox
            // 
            this.RefreshEveryCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RefreshEveryCheckBox.AutoSize = true;
            this.RefreshEveryCheckBox.Location = new System.Drawing.Point(34, 232);
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
            this.AutoCloseTaskWindowCheckBox.Location = new System.Drawing.Point(34, 175);
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
            this.IncludeMachineNamesCheckBox.Location = new System.Drawing.Point(34, 125);
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
            this.InstancePathAsDisplayCheckBox.Location = new System.Drawing.Point(34, 69);
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
            this.UpdateNotificationCheckBox.Location = new System.Drawing.Point(34, 45);
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
            this.LaunchAtLoginCheckBox.Location = new System.Drawing.Point(34, 22);
            this.LaunchAtLoginCheckBox.Name = "LaunchAtLoginCheckBox";
            this.LaunchAtLoginCheckBox.Size = new System.Drawing.Size(99, 17);
            this.LaunchAtLoginCheckBox.TabIndex = 2;
            this.LaunchAtLoginCheckBox.Text = "Launch at login";
            this.LaunchAtLoginCheckBox.UseVisualStyleBackColor = true;
            this.LaunchAtLoginCheckBox.CheckedChanged += new System.EventHandler(this.LaunchAtLoginCheckBox_CheckedChanged);
            // 
            // DoneButton
            // 
            this.DoneButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DoneButton.Location = new System.Drawing.Point(187, 390);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(75, 23);
            this.DoneButton.TabIndex = 1;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = true;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // VirtualBoxPathStatusTextBox
            // 
            this.VirtualBoxPathStatusTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.VirtualBoxPathStatusTextBox.AutoSize = true;
            this.VirtualBoxPathStatusTextBox.ForeColor = System.Drawing.Color.DarkGreen;
            this.VirtualBoxPathStatusTextBox.Location = new System.Drawing.Point(160, 276);
            this.VirtualBoxPathStatusTextBox.Name = "VirtualBoxPathStatusTextBox";
            this.VirtualBoxPathStatusTextBox.Size = new System.Drawing.Size(39, 13);
            this.VirtualBoxPathStatusTextBox.TabIndex = 16;
            this.VirtualBoxPathStatusTextBox.Text = "Linked";
            // 
            // PreferencesWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 425);
            this.Controls.Add(this.DoneButton);
            this.Controls.Add(this.PreferencesPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PreferencesWindow";
            this.Text = "Preferences";
            this.Load += new System.EventHandler(this.PreferencesWindow_Load);
            this.PreferencesPanel.ResumeLayout(false);
            this.PreferencesPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PreferencesPanel;
        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.CheckBox InstancePathAsDisplayCheckBox;
        private System.Windows.Forms.CheckBox UpdateNotificationCheckBox;
        private System.Windows.Forms.CheckBox LaunchAtLoginCheckBox;
        private System.Windows.Forms.CheckBox AutoCloseTaskWindowCheckBox;
        private System.Windows.Forms.CheckBox IncludeMachineNamesCheckBox;
        private System.Windows.Forms.CheckBox RefreshEveryCheckBox;
        private System.Windows.Forms.ComboBox RefreshEveryComboBox;
        private System.Windows.Forms.Label InstancePathAsDisplayLabel;
        private System.Windows.Forms.Label IncludeMachineNamesLabel;
        private System.Windows.Forms.Label AutoCloseTaskWindowLabel;
        private System.Windows.Forms.Button VirtualBoxBrowseButton;
        private System.Windows.Forms.TextBox VirtualBoxPathTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label VirtualBoxPathStatusTextBox;
    }
}