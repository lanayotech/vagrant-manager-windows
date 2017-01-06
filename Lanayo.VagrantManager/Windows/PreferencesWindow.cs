using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            InitializeAdvancedTabGroup();

            RefreshEveryComboBox.Text = Properties.Settings.Default.RefreshEveryInterval > 0 ? RefreshItems.First(item => item.Value == Properties.Settings.Default.RefreshEveryInterval).Text : RefreshItems[4].Text;
            RefreshEveryCheckBox.Checked = Properties.Settings.Default.RefreshEvery;
            VirtualBoxPathTextBox.Text = Properties.Settings.Default.VBoxManagePath;
            VirtualBoxPathTextBox.TextChanged += VirtualBoxPathTextBox_TextChanged;
            VirtualBoxPathTextBox_TextChanged(VirtualBoxPathTextBox, EventArgs.Empty);
            
        }

        private void InitializeAdvancedTabGroup()
        {
            LaunchAtLoginCheckBox.Checked = Properties.Settings.Default.LaunchAtLogin;
            UpdateNotificationCheckBox.Checked = Properties.Settings.Default.ShowUpdateNotification;
            InstancePathAsDisplayCheckBox.Checked = Properties.Settings.Default.UsePathAsInstanceDisplayName;
            IncludeMachineNamesCheckBox.Checked = Properties.Settings.Default.IncludeMachineNamesInMenu;
            AutoCloseTaskWindowCheckBox.Checked = Properties.Settings.Default.AutoCloseTaskWindows;

            UseDefaultTerminalCheckBox.Checked = (Properties.Settings.Default.DefaultTerminalCommand == Properties.Settings.Default.CurrentTerminalCommand && Properties.Settings.Default.DefaultTerminalArguments == Properties.Settings.Default.CurrentTerminalArguments);
            TerminalStartCommandTextbox.Enabled = !UseDefaultTerminalCheckBox.Checked;
            TerminalStartCommandTextbox.Text = Properties.Settings.Default.CurrentTerminalCommand;
            TerminalStartArgumentsTextbox.Enabled = !UseDefaultTerminalCheckBox.Checked;
            TerminalStartArgumentsTextbox.Text = Properties.Settings.Default.CurrentTerminalArguments;


            UseDefaultSshToMachineCheckBox.Checked = (Properties.Settings.Default.DefaultSshToMachineCommand == Properties.Settings.Default.CurrentSshToMachineCommand && Properties.Settings.Default.DefaultSshToMachineArguments == Properties.Settings.Default.CurrentSshToMachineArguments);
            SshToMachineCommandTextBox.Enabled = !UseDefaultSshToMachineCheckBox.Checked;
            SshToMachineCommandTextBox.Text = Properties.Settings.Default.CurrentSshToMachineCommand;
            SshToMachineArgumentsTextBox.Enabled = !UseDefaultSshToMachineCheckBox.Checked;
            SshToMachineArgumentsTextBox.Text = Properties.Settings.Default.CurrentSshToMachineArguments;

            UseDefaultSshToInstanceCheckBox.Checked = (Properties.Settings.Default.DefaultSshToInstanceCommand == Properties.Settings.Default.CurrentSshToInstanceCommand && Properties.Settings.Default.DefaultSshToInstanceArguments == Properties.Settings.Default.CurrentSshToInstanceArguments);
            SshToInstanceCommandTextBox.Enabled = !UseDefaultSshToInstanceCheckBox.Checked;
            SshToInstanceCommandTextBox.Text = Properties.Settings.Default.CurrentSshToInstanceCommand;
            SshToInstanceArgumentsTextBox.Enabled = !UseDefaultSshToInstanceCheckBox.Checked;
            SshToInstanceArgumentsTextBox.Text = Properties.Settings.Default.CurrentSshToInstanceArguments;
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

        private void DefaultTerminalCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TerminalStartCommandTextbox.Enabled = !UseDefaultTerminalCheckBox.Checked;
            TerminalStartArgumentsTextbox.Enabled = !UseDefaultTerminalCheckBox.Checked;
            Properties.Settings.Default.CurrentTerminalCommand = ((UseDefaultTerminalCheckBox.Checked) ? Properties.Settings.Default.DefaultTerminalCommand : Properties.Settings.Default.UserTerminalCommand);
            Properties.Settings.Default.CurrentTerminalArguments = ((UseDefaultTerminalCheckBox.Checked) ? Properties.Settings.Default.DefaultTerminalArguments : Properties.Settings.Default.UserTerminalArguments);
            Properties.Settings.Default.Save();
            TerminalStartCommandTextbox.Text = Properties.Settings.Default.CurrentTerminalCommand;
            TerminalStartArgumentsTextbox.Text = Properties.Settings.Default.CurrentTerminalArguments;
        }

        private void UseDefaultSshToMachineCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SshToMachineCommandTextBox.Enabled = !UseDefaultSshToMachineCheckBox.Checked;
            SshToMachineArgumentsTextBox.Enabled = !UseDefaultSshToMachineCheckBox.Checked;
            Properties.Settings.Default.CurrentSshToMachineCommand = ((UseDefaultSshToMachineCheckBox.Checked) ? Properties.Settings.Default.DefaultSshToMachineCommand : Properties.Settings.Default.UserSshToMachineCommand);
            Properties.Settings.Default.CurrentSshToMachineArguments = ((UseDefaultSshToMachineCheckBox.Checked) ? Properties.Settings.Default.DefaultSshToMachineArguments : Properties.Settings.Default.UserSshToMachineArguments);
            Properties.Settings.Default.Save();
            SshToMachineCommandTextBox.Text = Properties.Settings.Default.CurrentSshToMachineCommand;
            SshToMachineArgumentsTextBox.Text = Properties.Settings.Default.CurrentSshToMachineArguments;
        }

        private void UseDefaultSshToInstanceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SshToInstanceCommandTextBox.Enabled = !UseDefaultSshToInstanceCheckBox.Checked;
            SshToInstanceArgumentsTextBox.Enabled = !UseDefaultSshToInstanceCheckBox.Checked;
            Properties.Settings.Default.CurrentSshToInstanceCommand = ((UseDefaultSshToInstanceCheckBox.Checked) ? Properties.Settings.Default.DefaultSshToInstanceCommand : Properties.Settings.Default.UserSshToInstanceCommand);
            Properties.Settings.Default.CurrentSshToInstanceArguments = ((UseDefaultSshToInstanceCheckBox.Checked) ? Properties.Settings.Default.DefaultSshToInstanceArguments : Properties.Settings.Default.UserSshToInstanceArguments);
            Properties.Settings.Default.Save();
            SshToInstanceCommandTextBox.Text = Properties.Settings.Default.CurrentSshToInstanceCommand;
            SshToInstanceArgumentsTextBox.Text = Properties.Settings.Default.CurrentSshToInstanceArguments;
        }

        private void TerminalStartCommandTextbox_TextChanged(object sender, EventArgs e)
        {
            if (UseDefaultTerminalCheckBox.Checked)
                return;

            Properties.Settings.Default.UserTerminalCommand = TerminalStartCommandTextbox.Text;
            Properties.Settings.Default.CurrentTerminalCommand = TerminalStartCommandTextbox.Text;

        }

        private void TerminalStartArgumentsTextbox_TextChanged(object sender, EventArgs e)
        {
            if (UseDefaultTerminalCheckBox.Checked)
                return;

            Properties.Settings.Default.UserTerminalArguments = TerminalStartArgumentsTextbox.Text;
            Properties.Settings.Default.CurrentTerminalArguments = TerminalStartArgumentsTextbox.Text;
        }

        private void SshToMachineCommandTextBox_TextChanged(object sender, EventArgs e)
        {
            if (UseDefaultSshToMachineCheckBox.Checked)
                return;

            Properties.Settings.Default.UserSshToMachineCommand = SshToMachineCommandTextBox.Text;
            Properties.Settings.Default.CurrentSshToMachineCommand = SshToMachineCommandTextBox.Text;
        }

        private void SshToMachineArgumentsTextBox_TextChanged(object sender, EventArgs e)
        {
            if (UseDefaultSshToMachineCheckBox.Checked)
                return;

            Properties.Settings.Default.UserSshToMachineArguments = SshToMachineArgumentsTextBox.Text;
            Properties.Settings.Default.CurrentSshToMachineArguments = SshToMachineArgumentsTextBox.Text;
        }

        private void SshToInstanceCommandTextBox_TextChanged(object sender, EventArgs e)
        {
            if (UseDefaultSshToInstanceCheckBox.Checked)
                return;

            Properties.Settings.Default.UserSshToInstanceCommand = SshToInstanceCommandTextBox.Text;
            Properties.Settings.Default.CurrentSshToInstanceCommand = SshToInstanceCommandTextBox.Text;
        }

        private void SshToInstanceArgumentsTextBox_TextChanged(object sender, EventArgs e)
        {
            if (UseDefaultSshToInstanceCheckBox.Checked)
                return;

            Properties.Settings.Default.UserSshToInstanceArguments = SshToInstanceArgumentsTextBox.Text;
            Properties.Settings.Default.CurrentSshToInstanceArguments = SshToInstanceArgumentsTextBox.Text;
        }

        
    }
}
