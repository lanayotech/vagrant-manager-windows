﻿using Microsoft.Win32;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Lanayo.Vagrant_Manager.Core.CommandPromptApps;

namespace Lanayo.Vagrant_Manager.Windows {
    public partial class PreferencesWindow : Form {

        private ComboBoxItem[] RefreshItems;

        public PreferencesWindow() {
            InitializeComponent();
        }

        private void PreferencesWindow_Load(object sender, EventArgs e) {
            RefreshItems = new ComboBoxItem[] {
                new ComboBoxItem() { Text = "5 seconds", Value = 5 },
                new ComboBoxItem() { Text = "15 seconds", Value = 15 },
                new ComboBoxItem() { Text = "30 seconds", Value = 30 },
                new ComboBoxItem() { Text = "1 minute", Value = 60 },
                new ComboBoxItem() { Text = "15 minutes", Value = 900 },
                new ComboBoxItem() { Text = "30 minutes", Value = 1800 },
                new ComboBoxItem() { Text = "1 hour", Value = 3600 }
            };

            RefreshEveryComboBox.Items.AddRange(RefreshItems);

            LaunchAtLoginCheckBox.Checked = Properties.Settings.Default.LaunchAtLogin;
            UpdateNotificationCheckBox.Checked = Properties.Settings.Default.ShowUpdateNotification;
            InstancePathAsDisplayCheckBox.Checked = Properties.Settings.Default.UsePathAsInstanceDisplayName;
            IncludeMachineNamesCheckBox.Checked = Properties.Settings.Default.IncludeMachineNamesInMenu;
            AutoCloseTaskWindowCheckBox.Checked = Properties.Settings.Default.AutoCloseTaskWindows;
            RefreshEveryComboBox.Text = Properties.Settings.Default.RefreshEveryInterval > 0 ? RefreshItems.First(item => item.Value == Properties.Settings.Default.RefreshEveryInterval).Text : RefreshItems[4].Text;
            RefreshEveryCheckBox.Checked = Properties.Settings.Default.RefreshEvery;
            VirtualBoxPathTextBox.Text = Properties.Settings.Default.VBoxManagePath;
            VirtualBoxPathTextBox.TextChanged += VirtualBoxPathTextBox_TextChanged;
            VirtualBoxPathTextBox_TextChanged(VirtualBoxPathTextBox, EventArgs.Empty);
            CommandPromptTextBox.Text = Properties.Settings.Default.CommandPromptPath;
            CommandPromptTextBox.TextChanged += CommandPromptTextBox_TextChanged;
            CommandPromptTextBox_TextChanged(CommandPromptTextBox, EventArgs.Empty);
        }

        private void CommandPromptTextBox_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.CommandPromptPath = CommandPromptTextBox.Text;
            Properties.Settings.Default.Save();

            if (File.Exists(CommandPromptTextBox.Text))
            {
                CommandPromptPathStatusTextBox.Text = "Linked";
                CommandPromptPathStatusTextBox.ForeColor = Color.DarkGreen;
            }
            else
            {
                CommandPromptPathStatusTextBox.Text = "Unlinked";
                CommandPromptPathStatusTextBox.ForeColor = Color.DarkRed;
            }
        }

        void VirtualBoxPathTextBox_TextChanged(object sender, EventArgs e) {
            Properties.Settings.Default.VBoxManagePath = VirtualBoxPathTextBox.Text;
            Properties.Settings.Default.Save();
            
            if (File.Exists(VirtualBoxPathTextBox.Text)) {
                VirtualBoxPathStatusTextBox.Text = "Linked";
                VirtualBoxPathStatusTextBox.ForeColor = Color.DarkGreen;
            } else {
                VirtualBoxPathStatusTextBox.Text = "Unlinked";
                VirtualBoxPathStatusTextBox.ForeColor = Color.DarkRed;
            }
        }

        private void DoneButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void LaunchAtLoginCheckBox_CheckedChanged(object sender, EventArgs e) {
            RegistryKey subKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            Properties.Settings.Default.LaunchAtLogin = LaunchAtLoginCheckBox.Checked;

            if (LaunchAtLoginCheckBox.Checked) {
                subKey.SetValue("Vagrant Manager", "\"" + Application.ExecutablePath.ToString() + "\"");
            } else {
                subKey.DeleteValue("Vagrant Manager");
            }

            Properties.Settings.Default.Save();
        }

        private void UpdateNotificationCheckBox_CheckedChanged(object sender, EventArgs e) {
            Properties.Settings.Default.ShowUpdateNotification = UpdateNotificationCheckBox.Checked;
            Properties.Settings.Default.Save();

            NotificationCenter.Instance.PostNotification("vagrant-manager.show-update-notification-preference-changed");
        }

        private void InstancePathAsDisplayCheckBox_CheckedChanged(object sender, EventArgs e) {
            Properties.Settings.Default.UsePathAsInstanceDisplayName = InstancePathAsDisplayCheckBox.Checked;
            Properties.Settings.Default.Save();

            NotificationCenter.Instance.PostNotification("vagrant-manager.use-path-as-instance-display-name-preference-changed");
        }

        private void IncludeMachineNamesCheckBox_CheckedChanged(object sender, EventArgs e) {
            Properties.Settings.Default.IncludeMachineNamesInMenu = IncludeMachineNamesCheckBox.Checked;
            Properties.Settings.Default.Save();

            NotificationCenter.Instance.PostNotification("vagrant-manager.include-machine-names-in-menu-preference-changed");
        }

        private void AutoCloseTaskWindowCheckBox_CheckedChanged(object sender, EventArgs e) {
            Properties.Settings.Default.AutoCloseTaskWindows = AutoCloseTaskWindowCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void RefreshEveryCheckBox_CheckedChanged(object sender, EventArgs e) {
            Properties.Settings.Default.RefreshEvery = RefreshEveryCheckBox.Checked;
            Properties.Settings.Default.RefreshEveryInterval = RefreshItems.First(item => item.Text == RefreshEveryComboBox.Text).Value;
            Properties.Settings.Default.Save();

            App.Instance.RefreshTimerState();
        }
        private void RefreshEveryComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            Properties.Settings.Default.RefreshEveryInterval = RefreshItems.First(item => item.Text == RefreshEveryComboBox.Text).Value;
            Properties.Settings.Default.Save();

            App.Instance.RefreshTimerState();
        }

        private void VirtualBoxBrowseButton_Click(object sender, EventArgs e) {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select VBoxManage.exe";
            dialog.Filter = "VBoxManage|VBoxManage.exe";
            if (dialog.ShowDialog() == DialogResult.OK) {
                DirectoryInfo info = new DirectoryInfo(dialog.FileName);
                VirtualBoxPathTextBox.Text = info.FullName;
            }
        }

        private void CommandPromptBrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select command prompt exe";
            dialog.Filter = String.Join(
                "|",
                CommandPromptApp.GetAll().Select(
                    t => t.GetType().Name + "|" + String.Join(";", t.SupportedFiles)
                ).ToArray()
            );
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                DirectoryInfo info = new DirectoryInfo(dialog.FileName);
                this.CommandPromptTextBox.Text = info.FullName;
            }
        }
    }
}
