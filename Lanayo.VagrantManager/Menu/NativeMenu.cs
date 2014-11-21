using Lanayo.Vagrant_Manager.Core.Bookmarks;
using Lanayo.Vagrant_Manager.Core.Vagrant;
using Lanayo.Vagrant_Manager.Properties;
using Lanayo.Vagrant_Manager.Windows;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Lanayo.Vagrant_Manager.Menu {
    class NativeMenu : NativeMenuItemDelegate {
        private AboutWindow AboutWindow;
        private PreferencesWindow PreferencesWindow;
        private ManageBookmarksWindow ManageBookmarksWindow;

        public MenuDelegate Delegate { get; set; }

        private ContextMenuStrip _Menu;
        private NotifyIcon _NotifyIcon;
        private ToolStripMenuItem _RefreshMenuItem;
        private List<NativeMenuItem> _MenuItems;

        private ToolStripSeparator _TopMachineSeparator;
        private ToolStripSeparator _BottomMachineSeparator;

        private ToolStripMenuItem _CheckForUpdatesMenuItem;

        private int _RefreshIconFrame;
        private Timer _RefreshTimer;

        public ContextMenuStrip Menu { get { return _Menu; } }

        public NativeMenu() {

            NotificationCenter.Instance.AddObserver(BookmarksUpdated, "vagrant-manager.bookmarks-updated");
            NotificationCenter.Instance.AddObserver(NotificationPreferenceChanged, "vagrant-manager.notification-preference-changed");
            NotificationCenter.Instance.AddObserver(InstanceAdded, "vagrant-manager.instance-added");
            NotificationCenter.Instance.AddObserver(InstanceRemoved, "vagrant-manager.instance-removed");
            NotificationCenter.Instance.AddObserver(InstanceUpdated, "vagrant-manager.instance-updated");
            NotificationCenter.Instance.AddObserver(SetUpdateAvailable, "vagrant-manager.update-available");
            NotificationCenter.Instance.AddObserver(RefreshingStarted, "vagrant-manager.refreshing-started");
            NotificationCenter.Instance.AddObserver(RefreshingEnded, "vagrant-manager.refreshing-ended");
            NotificationCenter.Instance.AddObserver(UpdateRunningVmCount, "vagrant-manager.update-running-vm-count");

            _Menu = new ContextMenuStrip();

            _NotifyIcon = new NotifyIcon() {
                Icon = Icon.FromHandle(Resources.vagrant_logo_off.GetHicon()),
                Text = "Vagrant Manager",
                ContextMenuStrip = _Menu,
                Visible = true,
            };

            _NotifyIcon.MouseUp += NotifyIcon_MouseUp;

            _MenuItems = new List<NativeMenuItem>();

            _RefreshMenuItem = Util.MakeBlankToolstripMenuItem("Refresh", RefreshMenuItem_Click);
            _Menu.Items.Add(_RefreshMenuItem);

            _TopMachineSeparator = new ToolStripSeparator();

            // instances here

            _BottomMachineSeparator = new ToolStripSeparator();
            _Menu.Items.Add(_BottomMachineSeparator);

            ToolStripMenuItem allMachinesMenuItem = new ToolStripMenuItem("All Machines");
            allMachinesMenuItem.DropDownItems.AddRange(new ToolStripMenuItem[] {
                new ToolStripMenuItem("Up", Resources.up, AllUpMenuItem_Click),
                new ToolStripMenuItem("Reload", Resources.reload, AllReloadMenuItem_Click),
                new ToolStripMenuItem("Suspend", Resources.suspend, AllSuspendMenuItem_Click ),
                new ToolStripMenuItem("Halt", Resources.halt, AllHaltMenuItem_Click),
                new ToolStripMenuItem("Provision", Resources.provision, AllProvisionMenuItem_Click),
                new ToolStripMenuItem("Destroy", Resources.destroy, AllDestroyMenuitem_Click)
            });
            _Menu.Items.Add(allMachinesMenuItem);
            _Menu.Items.Add(Util.MakeBlankToolstripMenuItem("Manage Bookmarks", ManageBookmarksMenuItem_Click));
            _Menu.Items.Add(Util.MakeBlankToolstripMenuItem("Preferences", PreferencesMenuItem_Click));
            _Menu.Items.Add(Util.MakeBlankToolstripMenuItem("About", AboutMenuItem_Click));

            _CheckForUpdatesMenuItem = Util.MakeBlankToolstripMenuItem("Check For Updates", CheckForUpdatesMenuItem_Click);
            _Menu.Items.Add(_CheckForUpdatesMenuItem);

            _Menu.Items.Add(Util.MakeBlankToolstripMenuItem("Exit", ExitMenuItem_Click));
        }

        #region Notification event handlers


        private void BookmarksUpdated(Notification notification) {
            this.RebuildMenu();
        }

        private void NotificationPreferenceChanged(Notification notification) {

        }

        private void InstanceAdded(Notification notification) {
            NativeMenuItem item = new NativeMenuItem();
            item.Delegate = this;
            _MenuItems.Add(item);
            item.Instance = (VagrantInstance)notification.UserInfo["instance"];
            item.MenuItem = new ToolStripMenuItem(item.Instance.DisplayName);
            item.Refresh();
            this.RebuildMenu();
        }

        private void InstanceRemoved(Notification notification) {
            NativeMenuItem item = this.MenuItemForInstance((VagrantInstance)notification.UserInfo["instance"]);
            _MenuItems.Remove(item);
            _Menu.Items.Remove(item.MenuItem);
            this.RebuildMenu();
        }

        private void InstanceUpdated(Notification notification) {
            NativeMenuItem item = this.MenuItemForInstance((VagrantInstance)notification.UserInfo["old_instance"]);
            item.Instance = (VagrantInstance)notification.UserInfo["new_instance"];
            item.Refresh();
            this.RebuildMenu();
        }

        private void SetUpdateAvailable(Notification notification) {
            this.SetUpdatesAvailable((bool)notification.UserInfo["is_update_available"]);
        }

        private void RefreshingStarted(Notification notification) {
            this.SetIsRefreshing(true);
        }

        private void RefreshingEnded(Notification notification) {
            this.SetIsRefreshing(false);
        }
        private void UpdateRunningVmCount(Notification notification) {
            int count = (int)notification.UserInfo["count"];

            if (count > 0) {
                //TODO: show running vm count?
                _NotifyIcon.Icon = Icon.FromHandle(Resources.vagrant_logo_on.GetHicon());
            } else {
                _NotifyIcon.Icon = Icon.FromHandle(Resources.vagrant_logo_off.GetHicon());
            }
        }

        #endregion

        #region Control

        public void RebuildMenu() {
            _MenuItems.ForEach(item => item.Refresh());

            BookmarkManager bookmarkManager = BookmarkManager.Instance;

            List<NativeMenuItem> sortedList = _MenuItems.ToList();

            sortedList.Sort((a, b) => {
                VagrantInstance firstInstance = a.Instance;
                VagrantInstance secondInstance = b.Instance;

                bool firstBookmarked = bookmarkManager.GetBookmarkWithPath(firstInstance.Path) != null;
                bool secondBookmarked = bookmarkManager.GetBookmarkWithPath(secondInstance.Path) != null;

                int firstRunningCount = firstInstance.GetRunningMachineCount();
                int secondRunningCount = secondInstance.GetRunningMachineCount();

                if (firstBookmarked && !secondBookmarked) {
                    return -1;
                } else if (secondBookmarked && !firstBookmarked) {
                    return 1;
                } else {
                    if (firstRunningCount > 0 && secondRunningCount == 0) {
                        return -1;
                    } else if (secondRunningCount > 0 && firstRunningCount == 0) {
                        return 1;
                    } else {
                        int firstIdx = bookmarkManager.GetIndexOfBookmarkWithPath(firstInstance.Path);
                        int secondIdx = bookmarkManager.GetIndexOfBookmarkWithPath(secondInstance.Path);

                        if (firstIdx < secondIdx) {
                            return -1;
                        } else if (secondIdx < firstIdx) {
                            return 1;
                        } else {
                            return firstInstance.DisplayName.CompareTo(secondInstance.DisplayName);
                        }
                    }
                }
            });

            sortedList.ForEach(item => {
                if (_Menu.Items.Contains(item.MenuItem)) {
                    _Menu.Items.Remove(item.MenuItem);
                }

                _Menu.Items.Insert(_Menu.Items.IndexOf(_BottomMachineSeparator), item.MenuItem);
            });

            _MenuItems = sortedList;

            if (_Menu.Items.Contains(_TopMachineSeparator)) {
                _Menu.Items.Remove(_TopMachineSeparator);
            }

            if (_MenuItems.Count > 0) {
                _Menu.Items.Insert(_Menu.Items.IndexOf(_RefreshMenuItem) + 1, _TopMachineSeparator);
            }
            
        }

        private void SetUpdatesAvailable(bool updatesAvailable) {
            //_CheckForUpdatesMenuItem.Image = updatesAvailable ? Resources.status_icon_problem : null;
        }

        private void SetIsRefreshing(bool isRefreshing) {
            _RefreshMenuItem.Enabled = !isRefreshing;
            _RefreshMenuItem.Text = isRefreshing ? "Refreshing..." : "Refresh";

            if (isRefreshing) {
                _RefreshIconFrame = 1;
                _RefreshTimer = new Timer();
                _RefreshTimer.Interval = 200;
                _RefreshTimer.Tick += UpdateRefreshIcon;
                _RefreshTimer.Start();
            } else {
                _RefreshTimer.Stop();
                _RefreshTimer = null;
            }
        }

        private void UpdateRefreshIcon(object s, EventArgs args) {
            _NotifyIcon.Icon = Icon.FromHandle((Resources.ResourceManager.GetObject(String.Format("vagrant_logo_refresh{0}", _RefreshIconFrame)) as Bitmap).GetHicon());

            if(++_RefreshIconFrame > 6) {
                _RefreshIconFrame = 1;
            }
        }

        #endregion

        #region Native menu item delegate

        public void NativeMenuItemUpAllMachines(NativeMenuItem menuItem) {
            this.PerformAction("up", menuItem.Instance);
        }
        public void NativeMenuItemSSHInstance(NativeMenuItem menuItem) {
            this.PerformAction("ssh", menuItem.Instance);
        }
        public void NativeMenuItemSuspendAllMachines(NativeMenuItem menuItem) {
            this.PerformAction("suspend", menuItem.Instance);
        }
        public void NativeMenuItemReloadAllMachines(NativeMenuItem menuItem) {
            this.PerformAction("reload", menuItem.Instance);
        }
        public void NativeMenuItemHaltAllMachines(NativeMenuItem menuItem) {
            this.PerformAction("halt", menuItem.Instance);
        }
        public void NativeMenuItemDestroyAllMachines(NativeMenuItem menuItem) {
            DialogResult dialogResult = MessageBox.Show(String.Format("Are you sure you want to destroy {0}?", menuItem.Instance.Machines.Length > 1 ? "all machines in the group" : "this machine"), "Confirm Destructive Action", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes) {
                this.PerformAction("destroy", menuItem.Instance);
            }
        }
        public void NativeMenuItemProvisionAllMachines(NativeMenuItem menuItem) {
            this.PerformAction("provision", menuItem.Instance);
        }
        public void NativeMenuItemOpenExplorer(NativeMenuItem menuItem) {
            Delegate.OpenInstanceInExplorer(menuItem.Instance);
        }
        public void NativeMenuItemOpenTerminal(NativeMenuItem menuItem) {
            Delegate.OpenInstanceInTerminal(menuItem.Instance);
        }
        public void NativeMenuItemUpdateProviderIdentifier(NativeMenuItem menuItem, string providerIdentifier) {
            Bookmark bookmark = BookmarkManager.Instance.GetBookmarkWithPath(menuItem.Instance.Path);

            if (bookmark != null) {
                bookmark.ProviderIdentifier = providerIdentifier;
                BookmarkManager.Instance.SaveBookmarks();
            }

            menuItem.Instance.ProviderIdentifier = providerIdentifier;
            menuItem.Refresh();
        }
        public void NativeMenuItemRemoveBookmark(NativeMenuItem menuItem) {
            Delegate.RemoveBookmarkWithInstance(menuItem.Instance);
        }
        public void NativeMenuItemAddBookmark(NativeMenuItem menuItem) {
            Delegate.AddBookmarkWithInstance(menuItem.Instance);
        }

        public void NativeMenuItemUpMachine(VagrantMachine machine) {
            this.PerformAction("up", machine);
        }
        public void NativeMenuItemSSHMachine(VagrantMachine machine) {
            this.PerformAction("ssh", machine);
        }
        public void NativeMenuItemSuspendMachine(VagrantMachine machine) {
            this.PerformAction("suspend", machine);
        }
        public void NativeMenuItemReloadMachine(VagrantMachine machine) {
            this.PerformAction("reload", machine);
        }
        public void NativeMenuItemHaltMachine(VagrantMachine machine) {
            this.PerformAction("halt", machine);
        }
        public void NativeMenuItemDestroyMachine(VagrantMachine machine) {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to destroy this machine?", "Confirm Destructive Action", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes) {
                this.PerformAction("destroy", machine);
            }
        }
        public void NativeMenuItemProvisionMachine(VagrantMachine machine) {
            this.PerformAction("provision", machine);
        }

        #endregion

        #region All machines actions

        private void AllUpMenuItem_Click(object sender, EventArgs e) {
            VagrantManager.Instance.Instances.ToList().ForEach(instance => {
                instance.Machines.ToList().ForEach(machine => {
                    if (machine.State != VagrantMachineState.RunningState) {
                        this.PerformAction("up", machine);
                    }
                });
            });
        }

        private void AllReloadMenuItem_Click(object sender, EventArgs e) {
            VagrantManager.Instance.Instances.ToList().ForEach(instance => {
                instance.Machines.ToList().ForEach(machine => {
                    if (machine.State == VagrantMachineState.RunningState) {
                        this.PerformAction("reload", machine);
                    }
                });
            });
        }

        private void AllSuspendMenuItem_Click(object sender, EventArgs e) {
            VagrantManager.Instance.Instances.ToList().ForEach(instance => {
                instance.Machines.ToList().ForEach(machine => {
                    if (machine.State == VagrantMachineState.RunningState) {
                        this.PerformAction("suspend", machine);
                    }
                });
            });
        }

        private void AllHaltMenuItem_Click(object sender, EventArgs e) {
            VagrantManager.Instance.Instances.ToList().ForEach(instance => {
                instance.Machines.ToList().ForEach(machine => {
                    if (machine.State == VagrantMachineState.RunningState) {
                        this.PerformAction("halt", machine);
                    }
                });
            });
        }

        private void AllProvisionMenuItem_Click(object sender, EventArgs e) {
            VagrantManager.Instance.Instances.ToList().ForEach(instance => {
                instance.Machines.ToList().ForEach(machine => {
                    this.PerformAction("provision", machine);
                });
            });
        }

        private void AllDestroyMenuitem_Click(object sender, EventArgs e) {
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Delete Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes) {
                VagrantManager.Instance.Instances.ToList().ForEach(instance => {
                    instance.Machines.ToList().ForEach(machine => {
                        this.PerformAction("destroy", machine);
                    });
                });
            }
        }

        #endregion

        #region Menu Item Click Handlers

        private void RefreshMenuItem_Click(object sender, EventArgs e) {
            App.Instance.RefreshVagrantMachines();
        }
        private void ManageBookmarksMenuItem_Click(object sender, EventArgs e) {
            ManageBookmarksWindow = new ManageBookmarksWindow();
            ManageBookmarksWindow.StartPosition = FormStartPosition.CenterScreen;
            ManageBookmarksWindow.Show();
        }
        private void PreferencesMenuItem_Click(object sender, EventArgs e) {
            PreferencesWindow = new PreferencesWindow();
            PreferencesWindow.StartPosition = FormStartPosition.CenterScreen;
            PreferencesWindow.Show();
        }

        private void AboutMenuItem_Click(object sender, EventArgs e) {
            AboutWindow = new AboutWindow();
            AboutWindow.StartPosition = FormStartPosition.CenterScreen;
            AboutWindow.Show();
        }

        private void CheckForUpdatesMenuItem_Click(object sender, EventArgs e) {
            SharpSparkle.SharpSparkle.CheckUpdateWithUi();
        }

        private void ExitMenuItem_Click(object Sender, EventArgs e) {
            Application.Exit();
        }

        private void NotifyIcon_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
                mi.Invoke(_NotifyIcon, null);
            }
        }

        #endregion

        #region Misc

        private void PerformAction(string action, VagrantInstance instance) {
            Delegate.PerformVagrantAction(action, instance);
        }

        private void PerformAction(string action, VagrantMachine machine) {
            Delegate.PerformVagrantAction(action, machine);
        }

        private NativeMenuItem MenuItemForInstance(VagrantInstance instance) {
            return _MenuItems.Find(nativeMenuItem => nativeMenuItem.Instance.Path == instance.Path);
        }

        #endregion
    }
}
