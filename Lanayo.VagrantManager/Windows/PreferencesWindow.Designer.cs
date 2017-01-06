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
            this.TerminalStartCommandTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.UseDefaultTerminalCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TerminalStartArgumentsTextbox = new System.Windows.Forms.TextBox();
            this.PreferencesTabControl = new System.Windows.Forms.TabControl();
            this.GeneralPreferencesTabPage = new System.Windows.Forms.TabPage();
            this.VirtualBoxPathStatusTextBox = new System.Windows.Forms.Label();
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
            this.AdvancedPreferencesTabPage = new System.Windows.Forms.TabPage();
            this.SshToMachineGroupBox = new System.Windows.Forms.GroupBox();
            this.SshToMachineCommandTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.UseDefaultSshToMachineCheckBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SshToMachineArgumentsTextBox = new System.Windows.Forms.TextBox();
            this.TerminalCommandGroupBox = new System.Windows.Forms.GroupBox();
            this.SshToInstanceGroupBox = new System.Windows.Forms.GroupBox();
            this.SshToInstanceCommandTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.UseDefaultSshToInstanceCheckBox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SshToInstanceArgumentsTextBox = new System.Windows.Forms.TextBox();
            this.PreferencesTabControl.SuspendLayout();
            this.GeneralPreferencesTabPage.SuspendLayout();
            this.AdvancedPreferencesTabPage.SuspendLayout();
            this.SshToMachineGroupBox.SuspendLayout();
            this.TerminalCommandGroupBox.SuspendLayout();
            this.SshToInstanceGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // DoneButton
            // 
            this.DoneButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DoneButton.Location = new System.Drawing.Point(187, 504);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(75, 23);
            this.DoneButton.TabIndex = 1;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = true;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // TerminalStartCommandTextbox
            // 
            this.TerminalStartCommandTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TerminalStartCommandTextbox.Enabled = false;
            this.TerminalStartCommandTextbox.Location = new System.Drawing.Point(12, 55);
            this.TerminalStartCommandTextbox.Name = "TerminalStartCommandTextbox";
            this.TerminalStartCommandTextbox.Size = new System.Drawing.Size(212, 20);
            this.TerminalStartCommandTextbox.TabIndex = 17;
            this.TerminalStartCommandTextbox.TextChanged += new System.EventHandler(this.TerminalStartCommandTextbox_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Command";
            // 
            // UseDefaultTerminalCheckBox
            // 
            this.UseDefaultTerminalCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UseDefaultTerminalCheckBox.AutoSize = true;
            this.UseDefaultTerminalCheckBox.Location = new System.Drawing.Point(9, 19);
            this.UseDefaultTerminalCheckBox.Name = "UseDefaultTerminalCheckBox";
            this.UseDefaultTerminalCheckBox.Size = new System.Drawing.Size(60, 17);
            this.UseDefaultTerminalCheckBox.TabIndex = 19;
            this.UseDefaultTerminalCheckBox.Text = "Default";
            this.UseDefaultTerminalCheckBox.UseVisualStyleBackColor = true;
            this.UseDefaultTerminalCheckBox.CheckedChanged += new System.EventHandler(this.DefaultTerminalCheckBox_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Arguments";
            // 
            // TerminalStartArgumentsTextbox
            // 
            this.TerminalStartArgumentsTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TerminalStartArgumentsTextbox.Enabled = false;
            this.TerminalStartArgumentsTextbox.Location = new System.Drawing.Point(12, 94);
            this.TerminalStartArgumentsTextbox.Name = "TerminalStartArgumentsTextbox";
            this.TerminalStartArgumentsTextbox.Size = new System.Drawing.Size(212, 20);
            this.TerminalStartArgumentsTextbox.TabIndex = 20;
            this.TerminalStartArgumentsTextbox.TextChanged += new System.EventHandler(this.TerminalStartArgumentsTextbox_TextChanged);
            // 
            // PreferencesTabControl
            // 
            this.PreferencesTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PreferencesTabControl.Controls.Add(this.GeneralPreferencesTabPage);
            this.PreferencesTabControl.Controls.Add(this.AdvancedPreferencesTabPage);
            this.PreferencesTabControl.Location = new System.Drawing.Point(12, 12);
            this.PreferencesTabControl.Multiline = true;
            this.PreferencesTabControl.Name = "PreferencesTabControl";
            this.PreferencesTabControl.SelectedIndex = 0;
            this.PreferencesTabControl.Size = new System.Drawing.Size(250, 480);
            this.PreferencesTabControl.TabIndex = 2;
            // 
            // GeneralPreferencesTabPage
            // 
            this.GeneralPreferencesTabPage.Controls.Add(this.VirtualBoxPathStatusTextBox);
            this.GeneralPreferencesTabPage.Controls.Add(this.label1);
            this.GeneralPreferencesTabPage.Controls.Add(this.VirtualBoxBrowseButton);
            this.GeneralPreferencesTabPage.Controls.Add(this.VirtualBoxPathTextBox);
            this.GeneralPreferencesTabPage.Controls.Add(this.AutoCloseTaskWindowLabel);
            this.GeneralPreferencesTabPage.Controls.Add(this.IncludeMachineNamesLabel);
            this.GeneralPreferencesTabPage.Controls.Add(this.InstancePathAsDisplayLabel);
            this.GeneralPreferencesTabPage.Controls.Add(this.RefreshEveryComboBox);
            this.GeneralPreferencesTabPage.Controls.Add(this.RefreshEveryCheckBox);
            this.GeneralPreferencesTabPage.Controls.Add(this.AutoCloseTaskWindowCheckBox);
            this.GeneralPreferencesTabPage.Controls.Add(this.IncludeMachineNamesCheckBox);
            this.GeneralPreferencesTabPage.Controls.Add(this.InstancePathAsDisplayCheckBox);
            this.GeneralPreferencesTabPage.Controls.Add(this.UpdateNotificationCheckBox);
            this.GeneralPreferencesTabPage.Controls.Add(this.LaunchAtLoginCheckBox);
            this.GeneralPreferencesTabPage.Location = new System.Drawing.Point(4, 22);
            this.GeneralPreferencesTabPage.Name = "GeneralPreferencesTabPage";
            this.GeneralPreferencesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.GeneralPreferencesTabPage.Size = new System.Drawing.Size(242, 454);
            this.GeneralPreferencesTabPage.TabIndex = 0;
            this.GeneralPreferencesTabPage.Text = "General";
            this.GeneralPreferencesTabPage.UseVisualStyleBackColor = true;
            // 
            // VirtualBoxPathStatusTextBox
            // 
            this.VirtualBoxPathStatusTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.VirtualBoxPathStatusTextBox.AutoSize = true;
            this.VirtualBoxPathStatusTextBox.ForeColor = System.Drawing.Color.DarkGreen;
            this.VirtualBoxPathStatusTextBox.Location = new System.Drawing.Point(147, 266);
            this.VirtualBoxPathStatusTextBox.Name = "VirtualBoxPathStatusTextBox";
            this.VirtualBoxPathStatusTextBox.Size = new System.Drawing.Size(39, 13);
            this.VirtualBoxPathStatusTextBox.TabIndex = 30;
            this.VirtualBoxPathStatusTextBox.Text = "Linked";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 266);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "VBoxManage.exe | Status:";
            // 
            // VirtualBoxBrowseButton
            // 
            this.VirtualBoxBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.VirtualBoxBrowseButton.Location = new System.Drawing.Point(148, 282);
            this.VirtualBoxBrowseButton.Name = "VirtualBoxBrowseButton";
            this.VirtualBoxBrowseButton.Size = new System.Drawing.Size(60, 23);
            this.VirtualBoxBrowseButton.TabIndex = 28;
            this.VirtualBoxBrowseButton.Text = "Browse";
            this.VirtualBoxBrowseButton.UseVisualStyleBackColor = true;
            this.VirtualBoxBrowseButton.Click += new System.EventHandler(this.VirtualBoxBrowseButton_Click);
            // 
            // VirtualBoxPathTextBox
            // 
            this.VirtualBoxPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.VirtualBoxPathTextBox.Location = new System.Drawing.Point(21, 284);
            this.VirtualBoxPathTextBox.Name = "VirtualBoxPathTextBox";
            this.VirtualBoxPathTextBox.Size = new System.Drawing.Size(121, 20);
            this.VirtualBoxPathTextBox.TabIndex = 27;
            // 
            // AutoCloseTaskWindowLabel
            // 
            this.AutoCloseTaskWindowLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AutoCloseTaskWindowLabel.AutoSize = true;
            this.AutoCloseTaskWindowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoCloseTaskWindowLabel.Location = new System.Drawing.Point(37, 185);
            this.AutoCloseTaskWindowLabel.Name = "AutoCloseTaskWindowLabel";
            this.AutoCloseTaskWindowLabel.Size = new System.Drawing.Size(149, 24);
            this.AutoCloseTaskWindowLabel.TabIndex = 26;
            this.AutoCloseTaskWindowLabel.Text = "Automatically close the task output\r\nwindow if the task was successful";
            // 
            // IncludeMachineNamesLabel
            // 
            this.IncludeMachineNamesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IncludeMachineNamesLabel.AutoSize = true;
            this.IncludeMachineNamesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IncludeMachineNamesLabel.Location = new System.Drawing.Point(37, 135);
            this.IncludeMachineNamesLabel.Name = "IncludeMachineNamesLabel";
            this.IncludeMachineNamesLabel.Size = new System.Drawing.Size(129, 24);
            this.IncludeMachineNamesLabel.TabIndex = 25;
            this.IncludeMachineNamesLabel.Text = "Include machine names in top-\r\nlevel menu item labels";
            // 
            // InstancePathAsDisplayLabel
            // 
            this.InstancePathAsDisplayLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.InstancePathAsDisplayLabel.AutoSize = true;
            this.InstancePathAsDisplayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstancePathAsDisplayLabel.Location = new System.Drawing.Point(37, 82);
            this.InstancePathAsDisplayLabel.Name = "InstancePathAsDisplayLabel";
            this.InstancePathAsDisplayLabel.Size = new System.Drawing.Size(153, 24);
            this.InstancePathAsDisplayLabel.TabIndex = 24;
            this.InstancePathAsDisplayLabel.Text = "Use the path to the vagrant instance\r\nfor the menu item label";
            // 
            // RefreshEveryComboBox
            // 
            this.RefreshEveryComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RefreshEveryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RefreshEveryComboBox.FormattingEnabled = true;
            this.RefreshEveryComboBox.Location = new System.Drawing.Point(113, 220);
            this.RefreshEveryComboBox.Name = "RefreshEveryComboBox";
            this.RefreshEveryComboBox.Size = new System.Drawing.Size(96, 21);
            this.RefreshEveryComboBox.TabIndex = 23;
            // 
            // RefreshEveryCheckBox
            // 
            this.RefreshEveryCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RefreshEveryCheckBox.AutoSize = true;
            this.RefreshEveryCheckBox.Location = new System.Drawing.Point(21, 222);
            this.RefreshEveryCheckBox.Name = "RefreshEveryCheckBox";
            this.RefreshEveryCheckBox.Size = new System.Drawing.Size(93, 17);
            this.RefreshEveryCheckBox.TabIndex = 22;
            this.RefreshEveryCheckBox.Text = "Refresh Every";
            this.RefreshEveryCheckBox.UseVisualStyleBackColor = true;
            // 
            // AutoCloseTaskWindowCheckBox
            // 
            this.AutoCloseTaskWindowCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AutoCloseTaskWindowCheckBox.AutoSize = true;
            this.AutoCloseTaskWindowCheckBox.Location = new System.Drawing.Point(21, 165);
            this.AutoCloseTaskWindowCheckBox.Name = "AutoCloseTaskWindowCheckBox";
            this.AutoCloseTaskWindowCheckBox.Size = new System.Drawing.Size(138, 17);
            this.AutoCloseTaskWindowCheckBox.TabIndex = 21;
            this.AutoCloseTaskWindowCheckBox.Text = "Auto-close task window";
            this.AutoCloseTaskWindowCheckBox.UseVisualStyleBackColor = true;
            // 
            // IncludeMachineNamesCheckBox
            // 
            this.IncludeMachineNamesCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IncludeMachineNamesCheckBox.AutoSize = true;
            this.IncludeMachineNamesCheckBox.Location = new System.Drawing.Point(21, 115);
            this.IncludeMachineNamesCheckBox.Name = "IncludeMachineNamesCheckBox";
            this.IncludeMachineNamesCheckBox.Size = new System.Drawing.Size(138, 17);
            this.IncludeMachineNamesCheckBox.TabIndex = 20;
            this.IncludeMachineNamesCheckBox.Text = "Include machine names";
            this.IncludeMachineNamesCheckBox.UseVisualStyleBackColor = true;
            // 
            // InstancePathAsDisplayCheckBox
            // 
            this.InstancePathAsDisplayCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.InstancePathAsDisplayCheckBox.AutoSize = true;
            this.InstancePathAsDisplayCheckBox.Location = new System.Drawing.Point(21, 59);
            this.InstancePathAsDisplayCheckBox.Name = "InstancePathAsDisplayCheckBox";
            this.InstancePathAsDisplayCheckBox.Size = new System.Drawing.Size(190, 17);
            this.InstancePathAsDisplayCheckBox.TabIndex = 19;
            this.InstancePathAsDisplayCheckBox.Text = "Use instance path as display name";
            this.InstancePathAsDisplayCheckBox.UseVisualStyleBackColor = true;
            // 
            // UpdateNotificationCheckBox
            // 
            this.UpdateNotificationCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateNotificationCheckBox.AutoSize = true;
            this.UpdateNotificationCheckBox.Location = new System.Drawing.Point(21, 35);
            this.UpdateNotificationCheckBox.Name = "UpdateNotificationCheckBox";
            this.UpdateNotificationCheckBox.Size = new System.Drawing.Size(169, 17);
            this.UpdateNotificationCheckBox.TabIndex = 18;
            this.UpdateNotificationCheckBox.Text = "Don\'t show update notification";
            this.UpdateNotificationCheckBox.UseVisualStyleBackColor = true;
            // 
            // LaunchAtLoginCheckBox
            // 
            this.LaunchAtLoginCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LaunchAtLoginCheckBox.AutoSize = true;
            this.LaunchAtLoginCheckBox.Location = new System.Drawing.Point(21, 12);
            this.LaunchAtLoginCheckBox.Name = "LaunchAtLoginCheckBox";
            this.LaunchAtLoginCheckBox.Size = new System.Drawing.Size(99, 17);
            this.LaunchAtLoginCheckBox.TabIndex = 17;
            this.LaunchAtLoginCheckBox.Text = "Launch at login";
            this.LaunchAtLoginCheckBox.UseVisualStyleBackColor = true;
            // 
            // AdvancedPreferencesTabPage
            // 
            this.AdvancedPreferencesTabPage.Controls.Add(this.SshToInstanceGroupBox);
            this.AdvancedPreferencesTabPage.Controls.Add(this.SshToMachineGroupBox);
            this.AdvancedPreferencesTabPage.Controls.Add(this.TerminalCommandGroupBox);
            this.AdvancedPreferencesTabPage.Location = new System.Drawing.Point(4, 22);
            this.AdvancedPreferencesTabPage.Name = "AdvancedPreferencesTabPage";
            this.AdvancedPreferencesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.AdvancedPreferencesTabPage.Size = new System.Drawing.Size(242, 454);
            this.AdvancedPreferencesTabPage.TabIndex = 1;
            this.AdvancedPreferencesTabPage.Text = "Advanced";
            this.AdvancedPreferencesTabPage.UseVisualStyleBackColor = true;
            // 
            // SshToMachineGroupBox
            // 
            this.SshToMachineGroupBox.Controls.Add(this.SshToMachineCommandTextBox);
            this.SshToMachineGroupBox.Controls.Add(this.label4);
            this.SshToMachineGroupBox.Controls.Add(this.UseDefaultSshToMachineCheckBox);
            this.SshToMachineGroupBox.Controls.Add(this.label5);
            this.SshToMachineGroupBox.Controls.Add(this.SshToMachineArgumentsTextBox);
            this.SshToMachineGroupBox.Location = new System.Drawing.Point(9, 134);
            this.SshToMachineGroupBox.Name = "SshToMachineGroupBox";
            this.SshToMachineGroupBox.Size = new System.Drawing.Size(227, 130);
            this.SshToMachineGroupBox.TabIndex = 23;
            this.SshToMachineGroupBox.TabStop = false;
            this.SshToMachineGroupBox.Text = "SSH Start Command (Machine Instance)";
            // 
            // SshToMachineCommandTextBox
            // 
            this.SshToMachineCommandTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SshToMachineCommandTextBox.Enabled = false;
            this.SshToMachineCommandTextBox.Location = new System.Drawing.Point(9, 55);
            this.SshToMachineCommandTextBox.Name = "SshToMachineCommandTextBox";
            this.SshToMachineCommandTextBox.Size = new System.Drawing.Size(212, 20);
            this.SshToMachineCommandTextBox.TabIndex = 17;
            this.SshToMachineCommandTextBox.TextChanged += new System.EventHandler(this.SshToMachineCommandTextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Arguments";
            // 
            // UseDefaultSshToMachineCheckBox
            // 
            this.UseDefaultSshToMachineCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UseDefaultSshToMachineCheckBox.AutoSize = true;
            this.UseDefaultSshToMachineCheckBox.Location = new System.Drawing.Point(6, 19);
            this.UseDefaultSshToMachineCheckBox.Name = "UseDefaultSshToMachineCheckBox";
            this.UseDefaultSshToMachineCheckBox.Size = new System.Drawing.Size(60, 17);
            this.UseDefaultSshToMachineCheckBox.TabIndex = 19;
            this.UseDefaultSshToMachineCheckBox.Text = "Default";
            this.UseDefaultSshToMachineCheckBox.UseVisualStyleBackColor = true;
            this.UseDefaultSshToMachineCheckBox.CheckedChanged += new System.EventHandler(this.UseDefaultSshToMachineCheckBox_CheckedChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Command";
            // 
            // SshToMachineArgumentsTextBox
            // 
            this.SshToMachineArgumentsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SshToMachineArgumentsTextBox.Enabled = false;
            this.SshToMachineArgumentsTextBox.Location = new System.Drawing.Point(9, 94);
            this.SshToMachineArgumentsTextBox.Name = "SshToMachineArgumentsTextBox";
            this.SshToMachineArgumentsTextBox.Size = new System.Drawing.Size(212, 20);
            this.SshToMachineArgumentsTextBox.TabIndex = 20;
            this.SshToMachineArgumentsTextBox.TextChanged += new System.EventHandler(this.SshToMachineArgumentsTextBox_TextChanged);
            // 
            // TerminalCommandGroupBox
            // 
            this.TerminalCommandGroupBox.Controls.Add(this.TerminalStartCommandTextbox);
            this.TerminalCommandGroupBox.Controls.Add(this.label3);
            this.TerminalCommandGroupBox.Controls.Add(this.UseDefaultTerminalCheckBox);
            this.TerminalCommandGroupBox.Controls.Add(this.label2);
            this.TerminalCommandGroupBox.Controls.Add(this.TerminalStartArgumentsTextbox);
            this.TerminalCommandGroupBox.Location = new System.Drawing.Point(6, 6);
            this.TerminalCommandGroupBox.Name = "TerminalCommandGroupBox";
            this.TerminalCommandGroupBox.Size = new System.Drawing.Size(230, 122);
            this.TerminalCommandGroupBox.TabIndex = 22;
            this.TerminalCommandGroupBox.TabStop = false;
            this.TerminalCommandGroupBox.Text = "Instance Terminal Start Command";
            // 
            // SshToInstanceGroupBox
            // 
            this.SshToInstanceGroupBox.Controls.Add(this.SshToInstanceCommandTextBox);
            this.SshToInstanceGroupBox.Controls.Add(this.label6);
            this.SshToInstanceGroupBox.Controls.Add(this.UseDefaultSshToInstanceCheckBox);
            this.SshToInstanceGroupBox.Controls.Add(this.label7);
            this.SshToInstanceGroupBox.Controls.Add(this.SshToInstanceArgumentsTextBox);
            this.SshToInstanceGroupBox.Location = new System.Drawing.Point(9, 276);
            this.SshToInstanceGroupBox.Name = "SshToInstanceGroupBox";
            this.SshToInstanceGroupBox.Size = new System.Drawing.Size(227, 130);
            this.SshToInstanceGroupBox.TabIndex = 24;
            this.SshToInstanceGroupBox.TabStop = false;
            this.SshToInstanceGroupBox.Text = "SSH Start Command (Instance)";
            // 
            // SshToInstanceCommandTextBox
            // 
            this.SshToInstanceCommandTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SshToInstanceCommandTextBox.Enabled = false;
            this.SshToInstanceCommandTextBox.Location = new System.Drawing.Point(9, 55);
            this.SshToInstanceCommandTextBox.Name = "SshToInstanceCommandTextBox";
            this.SshToInstanceCommandTextBox.Size = new System.Drawing.Size(212, 20);
            this.SshToInstanceCommandTextBox.TabIndex = 17;
            this.SshToInstanceCommandTextBox.TextChanged += new System.EventHandler(this.SshToInstanceCommandTextBox_TextChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Arguments";
            // 
            // UseDefaultSshToInstanceCheckBox
            // 
            this.UseDefaultSshToInstanceCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UseDefaultSshToInstanceCheckBox.AutoSize = true;
            this.UseDefaultSshToInstanceCheckBox.Location = new System.Drawing.Point(6, 19);
            this.UseDefaultSshToInstanceCheckBox.Name = "UseDefaultSshToInstanceCheckBox";
            this.UseDefaultSshToInstanceCheckBox.Size = new System.Drawing.Size(60, 17);
            this.UseDefaultSshToInstanceCheckBox.TabIndex = 19;
            this.UseDefaultSshToInstanceCheckBox.Text = "Default";
            this.UseDefaultSshToInstanceCheckBox.UseVisualStyleBackColor = true;
            this.UseDefaultSshToInstanceCheckBox.CheckedChanged += new System.EventHandler(this.UseDefaultSshToInstanceCheckBox_CheckedChanged);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Command";
            // 
            // SshToInstanceArgumentsTextBox
            // 
            this.SshToInstanceArgumentsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SshToInstanceArgumentsTextBox.Enabled = false;
            this.SshToInstanceArgumentsTextBox.Location = new System.Drawing.Point(9, 94);
            this.SshToInstanceArgumentsTextBox.Name = "SshToInstanceArgumentsTextBox";
            this.SshToInstanceArgumentsTextBox.Size = new System.Drawing.Size(212, 20);
            this.SshToInstanceArgumentsTextBox.TabIndex = 20;
            this.SshToInstanceArgumentsTextBox.TextChanged += new System.EventHandler(this.SshToInstanceArgumentsTextBox_TextChanged);
            // 
            // PreferencesWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 539);
            this.Controls.Add(this.PreferencesTabControl);
            this.Controls.Add(this.DoneButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PreferencesWindow";
            this.Text = "Preferences";
            this.Load += new System.EventHandler(this.PreferencesWindow_Load);
            this.PreferencesTabControl.ResumeLayout(false);
            this.GeneralPreferencesTabPage.ResumeLayout(false);
            this.GeneralPreferencesTabPage.PerformLayout();
            this.AdvancedPreferencesTabPage.ResumeLayout(false);
            this.SshToMachineGroupBox.ResumeLayout(false);
            this.SshToMachineGroupBox.PerformLayout();
            this.TerminalCommandGroupBox.ResumeLayout(false);
            this.TerminalCommandGroupBox.PerformLayout();
            this.SshToInstanceGroupBox.ResumeLayout(false);
            this.SshToInstanceGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.CheckBox UseDefaultTerminalCheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TerminalStartCommandTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TerminalStartArgumentsTextbox;
        private System.Windows.Forms.TabControl PreferencesTabControl;
        private System.Windows.Forms.TabPage GeneralPreferencesTabPage;
        private System.Windows.Forms.Label VirtualBoxPathStatusTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button VirtualBoxBrowseButton;
        private System.Windows.Forms.TextBox VirtualBoxPathTextBox;
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
        private System.Windows.Forms.TabPage AdvancedPreferencesTabPage;
        private System.Windows.Forms.GroupBox TerminalCommandGroupBox;
        private System.Windows.Forms.GroupBox SshToMachineGroupBox;
        private System.Windows.Forms.TextBox SshToMachineCommandTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox UseDefaultSshToMachineCheckBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox SshToMachineArgumentsTextBox;
        private System.Windows.Forms.GroupBox SshToInstanceGroupBox;
        private System.Windows.Forms.TextBox SshToInstanceCommandTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox UseDefaultSshToInstanceCheckBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox SshToInstanceArgumentsTextBox;
    }
}