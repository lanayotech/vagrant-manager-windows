using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lanayo.Vagrant_Manager.Core.Bookmarks;
using Lanayo.Vagrant_Manager.Core.Vagrant;
using Lanayo.Vagrant_Manager.Windows;
using Lanayo.Vagrant_Manager.Menu;
using Lanayo.Vagrant_Manager.Core.Providers;
using System.IO;

namespace Lanayo.Vagrant_Manager {
    public enum VagrantMachineState { UnknownState, NotCreatedState, PowerOffState, SavedState, RunningState, RestoringState }
    public enum PossibleVmStates { running, suspended, off };

    class App : VagrantManagerDelegate, MenuDelegate {
        private NativeMenu _NativeMenu;
        private List<TaskOutputWindow> _TaskOutputWindows;
        private bool IsRefreshingVagrantMachines;
        private int QueuedRefreshes;
        private static App _Instance;
        public Timer RefreshTimer { get; set; }

        public static App Instance {
            get {
                if (_Instance == null) {
                    _Instance = new App();
                }
                return _Instance;
            }
        }

        public void Run() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            NotificationCenter.Instance.AddObserver(TaskCompleted, "vagrant-manager.task-completed");
            NotificationCenter.Instance.AddObserver(ThemeChanged, "vagrant-manager.theme-changed");
            NotificationCenter.Instance.AddObserver(ShowRunningVmCountPreferenceChanged, "vagrant-manager.show-running-vm-count-preference-changed");
            NotificationCenter.Instance.AddObserver(UsePathAsInstanceDisplayNamePreferenceChanged, "vagrant-manager.use-path-as-instance-display-name-preference-changed");
            NotificationCenter.Instance.AddObserver(IncludeMachineNamesInMenuPreferenceChanged, "vagrant-manager.include-machine-names-in-menu-preference-changed");
            NotificationCenter.Instance.AddObserver(ShowUpdateNotificationPreferenceChanged, "vagrant-manager.show-update-notification-preference-changed");
            NotificationCenter.Instance.AddObserver(BookmarksUpdated, "vagrant-manager.bookmarks-updated");

            _TaskOutputWindows = new List<TaskOutputWindow>();

            _NativeMenu = new NativeMenu();
            _NativeMenu.Delegate = this;

            VagrantManager.Instance.Delegate = this;
            VagrantManager.Instance.RegisterServiceProvider(new VirtualBoxServiceProvider());

            BookmarkManager.Instance.LoadBookmarks();

            if (Properties.Settings.Default.Guid.Length == 0) {
                Properties.Settings.Default.Guid = System.Guid.NewGuid().ToString();
                Properties.Settings.Default.Save();
            }

            Uri appcastUrl = Util.AddQuery(new Uri(Properties.Settings.Default.AppcastUrl), "machineid", Properties.Settings.Default.Guid);
            appcastUrl = Util.AddQuery(appcastUrl, "appversion", Application.ProductVersion);
            SharpSparkle.SharpSparkle.SetAppcastUrl(appcastUrl.AbsoluteUri);
            SharpSparkle.SharpSparkle.SetAppDetails(Application.CompanyName, Application.ProductName, Application.ProductVersion);
            SharpSparkle.SharpSparkle.Init();
            Application.ApplicationExit += Application_ApplicationExit;

            var dummy = _NativeMenu.Menu.Handle; // forces handle creation so _NativeMenu.Menu.BeginInvoke can work before the menu was ever clicked

            this.VerifyVBoxManagePath();

            this.RefreshVagrantMachines();

            this.RefreshTimerState();

            Application.Run();
        }

        void Application_ApplicationExit(object sender, EventArgs e) {
            SharpSparkle.SharpSparkle.Cleanup();
        }

        #region Notification handlers

        private void TaskCompleted(Notification notification) {
            this.RefreshVagrantMachines();
        }

        private void BookmarksUpdated(Notification notification) {
            this.RefreshVagrantMachines();
        }

        private void ThemeChanged(Notification notification) {
            this.UpdateRunningCount();
        }

        private void ShowRunningVmCountPreferenceChanged(Notification notification) {
            this.UpdateRunningCount();
        }

        private void UsePathAsInstanceDisplayNamePreferenceChanged(Notification notification) {
            _NativeMenu.RebuildMenu();
        }

        private void IncludeMachineNamesInMenuPreferenceChanged(Notification notification) {
            _NativeMenu.RebuildMenu();
        }

        private void ShowUpdateNotificationPreferenceChanged(Notification notification) {
            NotificationCenter.Instance.PostNotification("vagrant-manager.notification-preference-changed", new Notification(null));
        }

        #endregion

        #region Menu item handlers

        public void PerformVagrantAction(string action, VagrantInstance instance) {
            if (action == "ssh") {
                action = String.Format("cd /d {0} && vagrant ssh", Util.EscapeShellArg(instance.Path));
                this.RunTerminalCommand(action);
            } else {
                this.RunVagrantAction(action, instance);
            }
        }
        public void PerformVagrantAction(string action, VagrantMachine machine) {
            if (action == "ssh") {
                action = String.Format("cd /d {0} && vagrant ssh {1}", Util.EscapeShellArg(machine.Instance.Path), machine.Name);
                this.RunTerminalCommand(action);
            } else {
                this.RunVagrantAction(action, machine);
            }
        }
        public void OpenInstanceInExplorer(VagrantInstance instance) {
            if (Directory.Exists(instance.Path)) {
                Process.Start(@instance.Path);
            } else {
                MessageBox.Show("Path not found: " + instance.Path);
            }
        }
        public void OpenInstanceInTerminal(VagrantInstance instance) {
            if (Directory.Exists(instance.Path)) {
                Process p = new Process();
                p.StartInfo.FileName = "cmd";
                p.StartInfo.Arguments = String.Format("/K cd /d {0}", instance.Path);
                p.Start();
            } else {
                MessageBox.Show("Path not found: " + instance.Path);
            }
        }
        public void AddBookmarkWithInstance(VagrantInstance instance) {
            BookmarkManager.Instance.AddBookmarkWithPath(instance.Path, instance.DisplayName, instance.ProviderIdentifier);
            BookmarkManager.Instance.SaveBookmarks();
            NotificationCenter.Instance.PostNotification("vagrant-manager.bookmarks-updated");
        }
        public void RemoveBookmarkWithInstance(VagrantInstance instance) {
            BookmarkManager.Instance.RemoveBookmarkWithPath(instance.Path);
            BookmarkManager.Instance.SaveBookmarks();
            NotificationCenter.Instance.PostNotification("vagrant-manager.bookmarks-updated");
        }

        #endregion

        #region Vagrant Manager delegates

        public void InstanceAdded(VagrantManager vagrantManager, VagrantInstance instance) {
            _NativeMenu.Menu.BeginInvoke((MethodInvoker) delegate {
                Dictionary<string, object> userInfo = new Dictionary<string, object>();
                userInfo["instance"] = instance;
                NotificationCenter.Instance.PostNotification("vagrant-manager.instance-added", new Notification(null, userInfo));
            });
        }
        public void InstanceRemoved(VagrantManager vagrantManager, VagrantInstance instance) {
            _NativeMenu.Menu.BeginInvoke((MethodInvoker)delegate {
                Dictionary<string, object> userInfo = new Dictionary<string, object>();
                userInfo["instance"] = instance;
                NotificationCenter.Instance.PostNotification("vagrant-manager.instance-removed", new Notification(null, userInfo));
            });
        }
        public void InstanceUpdated(VagrantManager vagrantManager, VagrantInstance oldInstance, VagrantInstance newInstance) {
            _NativeMenu.Menu.BeginInvoke((MethodInvoker)delegate {
                Dictionary<string, object> userInfo = new Dictionary<string, object>();
                userInfo["old_instance"] = oldInstance;
                userInfo["new_instance"] = newInstance;
                NotificationCenter.Instance.PostNotification("vagrant-manager.instance-updated", new Notification(null, userInfo));
            });
        }

        #endregion

        #region Vagrant Machine control

        public void RefreshVagrantMachines() {
            if (!IsRefreshingVagrantMachines) {
                IsRefreshingVagrantMachines = true;
                NotificationCenter.Instance.PostNotification("vagrant-manager.refreshing-started");
                Task.Run(() => {
                    VagrantManager.Instance.RefreshInstances();

                    _NativeMenu.Menu.BeginInvoke((MethodInvoker)delegate {
                        IsRefreshingVagrantMachines = false;
                        NotificationCenter.Instance.PostNotification("vagrant-manager.refreshing-ended");
                        this.UpdateRunningCount();

                        if (QueuedRefreshes > 0) {
                            --QueuedRefreshes;
                            this.RefreshVagrantMachines();
                        }
                    });
                });
            } else {
                ++QueuedRefreshes;
            }
        }

        private void RunVagrantAction(string action, VagrantMachine machine) {
            string command;

            if (action == "up") {
                command = String.Format("vagrant up{0}", !String.IsNullOrEmpty(machine.Instance.ProviderIdentifier) ? String.Format(" --provider={0}", machine.Instance.ProviderIdentifier) : "virtualbox");
            } else if (action == "reload") {
                command = "vagrant reload";
            } else if (action == "suspend") {
                command = "vagrant suspend";
            } else if (action == "halt") {
                command = "vagrant halt";
            } else if (action == "provision") {
                command = "vagrant provision";
            } else if (action == "destroy") {
                command = "vagrant destroy -f";
            } else {
                return;
            }

            Process process = new Process();
            process.StartInfo.FileName = "cmd";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.Arguments = String.Format("/C cd /d {0} && {1} {2}", Util.EscapeShellArg(machine.Instance.Path), command, Util.EscapeShellArg(machine.Name));

            TaskOutputWindow outputWindow = new TaskOutputWindow();
            outputWindow.Task = process;
            outputWindow.TaskCommand = process.StartInfo.Arguments;
            outputWindow.TaskAction = command;
            outputWindow.Target = machine;
            outputWindow.Show();

            _TaskOutputWindows.Add(outputWindow);
        }

        private void RunVagrantAction(string action, VagrantInstance instance) {
            string command;

            if (action == "up") {
                command = String.Format("vagrant up{0}", !String.IsNullOrEmpty(instance.ProviderIdentifier) ? String.Format(" --provider={0}", instance.ProviderIdentifier) : "virtualbox");
            } else if (action == "reload") {
                command = "vagrant reload";
            } else if (action == "suspend") {
                command = "vagrant suspend";
            } else if (action == "halt") {
                command = "vagrant halt";
            } else if (action == "provision") {
                command = "vagrant provision";
            } else if (action == "destroy") {
                command = "vagrant destroy -f";
            } else {
                return;
            }

            Process process = new Process();
            process.StartInfo.FileName = "cmd";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.Arguments = String.Format("/C cd /d {0} && {1}", Util.EscapeShellArg(instance.Path), command);

            TaskOutputWindow outputWindow = new TaskOutputWindow();
            outputWindow.Task = process;
            outputWindow.TaskCommand = process.StartInfo.Arguments;
            outputWindow.TaskAction = command;
            outputWindow.Target = instance;
            outputWindow.Show();

            _TaskOutputWindows.Add(outputWindow);
        }

        private void RunTerminalCommand(string command) {
            Process p = new Process();
            p.StartInfo.FileName = "cmd";
            p.StartInfo.Arguments = String.Format("/C {0}", command);
            p.Start();
        }

        #endregion

        #region Window management

        private void RemoveTaskOutputWindow(TaskOutputWindow taskOutputWindow) {
            _TaskOutputWindows.Remove(taskOutputWindow);
        }

        public void UpdateRunningCount() {
            Dictionary<string, object> userInfo = new Dictionary<string, object>();
            userInfo["count"] = VagrantManager.Instance.GetRunningVmCount();
            NotificationCenter.Instance.PostNotification("vagrant-manager.update-running-vm-count", new Notification(null, userInfo));
        }

        public void RefreshTimerState() {
            if (RefreshTimer != null) {
                RefreshTimer.Stop();
                RefreshTimer = null;
            }

            if (Properties.Settings.Default.RefreshEvery) {
                RefreshTimer = new Timer();
                RefreshTimer.Interval = Properties.Settings.Default.RefreshEveryInterval * 1000;
                RefreshTimer.Tick += (s, args) => { this.RefreshVagrantMachines(); };
                RefreshTimer.Start();
            }
        }

        public void VerifyVBoxManagePath() {
            if (!File.Exists(Properties.Settings.Default.VBoxManagePath) && !Properties.Settings.Default.VBoxManagePathPrompted) {

                MessageBox.Show("VBoxManage.exe not found at default location", "Vagrant Manager - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Title = "Select VBoxManage.exe";
                dialog.Filter = "VBoxManage|VBoxManage.exe";
                if (dialog.ShowDialog() == DialogResult.OK) {
                    DirectoryInfo info = new DirectoryInfo(dialog.FileName);
                    Properties.Settings.Default.VBoxManagePath = info.FullName;
                    Properties.Settings.Default.Save();
                }

            }

            Properties.Settings.Default.VBoxManagePathPrompted = true;
            Properties.Settings.Default.Save();
        }

        #endregion
    }
}
