using Lanayo.Vagrant_Manager.Core.Bookmarks;
using Lanayo.Vagrant_Manager.Core.Vagrant;
using Lanayo.Vagrant_Manager.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lanayo.Vagrant_Manager.Menu {
    class NativeMenuItem {
        public NativeMenuItemDelegate Delegate { get; set; }
        public VagrantInstance Instance { get; set; }
        public ToolStripMenuItem MenuItem { get; set; }

        private ToolStripMenuItem _InstanceUpMenuItem;
        private ToolStripMenuItem _SSHMenuItem;
        private ToolStripMenuItem _InstanceReloadMenuItem;
        private ToolStripMenuItem _InstanceSuspendMenuItem;
        private ToolStripMenuItem _InstanceHaltMenuItem;
        private ToolStripMenuItem _InstanceDestroyMenuItem;
        private ToolStripMenuItem _InstanceProvisionMenuItem;

        private ToolStripMenuItem _OpenInExplorerMenuItem;
        private ToolStripMenuItem _OpenInTerminalMenuItem;
        private ToolStripMenuItem _AddBookmarkMenuItem;
        private ToolStripMenuItem _RemoveBookmarkMenuItem;
        private ToolStripMenuItem _ChooseProviderMenuItem;

        private ToolStripSeparator _MachineSeparator;
        private ToolStripSeparator _ActionSeparator;

        private List<ToolStripMenuItem> _MachineMenuItems;

        public NativeMenuItem() {
            _MachineMenuItems = new List<ToolStripMenuItem>();
        }

        public void Refresh() {

            if (Instance != null) {

                if (_InstanceUpMenuItem == null) {
                    _InstanceUpMenuItem = new ToolStripMenuItem(Instance.Machines.Length > 1 ? "Up All" : "Up", Resources.up, UpAllMachines_Click);
                    MenuItem.DropDownItems.Add(_InstanceUpMenuItem);
                }

                if (_SSHMenuItem == null) {
                    _SSHMenuItem = new ToolStripMenuItem("SSH", Resources.ssh, SSHInstance_Click);
                    MenuItem.DropDownItems.Add(_SSHMenuItem);
                }

                if (_InstanceReloadMenuItem == null) {
                    _InstanceReloadMenuItem = new ToolStripMenuItem(Instance.Machines.Length > 1 ? "Reload All" : "Reload", Resources.reload, ReloadAllMachines_Click);
                    MenuItem.DropDownItems.Add(_InstanceReloadMenuItem);
                }

                if (_InstanceSuspendMenuItem == null) {
                    _InstanceSuspendMenuItem = new ToolStripMenuItem(Instance.Machines.Length > 1 ? "Suspend All" : "Suspend", Resources.suspend, SuspendAllMachines_Click);
                    MenuItem.DropDownItems.Add(_InstanceSuspendMenuItem);
                }

                if (_InstanceHaltMenuItem == null) {
                    _InstanceHaltMenuItem = new ToolStripMenuItem(Instance.Machines.Length > 1 ? "Halt All" : "Halt", Resources.halt, HaltAllMachines_Click);
                    MenuItem.DropDownItems.Add(_InstanceHaltMenuItem);
                }

                if (_InstanceDestroyMenuItem == null) {
                    _InstanceDestroyMenuItem = new ToolStripMenuItem(Instance.Machines.Length > 1 ? "Destroy All" : "Destroy", Resources.destroy, DestroyAllMachines_Click);
                    MenuItem.DropDownItems.Add(_InstanceDestroyMenuItem);
                }

                if (_InstanceProvisionMenuItem == null) {
                    _InstanceProvisionMenuItem = new ToolStripMenuItem(Instance.Machines.Length > 1 ? "Provision All" : "Provision", Resources.provision, ProvisionAllMachines_Click);
                    MenuItem.DropDownItems.Add(_InstanceProvisionMenuItem);
                }

                if (_ActionSeparator == null) {
                    _ActionSeparator = new ToolStripSeparator();
                    MenuItem.DropDownItems.Add(_ActionSeparator);
                }

                if (_OpenInExplorerMenuItem == null) {
                    _OpenInExplorerMenuItem = Util.MakeBlankToolstripMenuItem("Open In Explorer", OpenInExplorerMenuItem_Click);
                    MenuItem.DropDownItems.Add(_OpenInExplorerMenuItem);
                }

                if (_OpenInTerminalMenuItem == null) {
                    _OpenInTerminalMenuItem = Util.MakeBlankToolstripMenuItem("Open In Terminal", OpenInTerminalMenuItem_Click);
                    MenuItem.DropDownItems.Add(_OpenInTerminalMenuItem);
                }

                if (_ChooseProviderMenuItem == null) {
                    _ChooseProviderMenuItem = new ToolStripMenuItem(String.Format("Provider: {0}", Instance.ProviderIdentifier ?? "Unknown"));
                    VagrantManager.Instance.GetProviderIdentifiers().ToList().ForEach(identifier => {
                        ToolStripMenuItem menuItem = Util.MakeBlankToolstripMenuItem(identifier, UpdateProviderIdentifier_Click);
                        menuItem.Tag = identifier;
                        _ChooseProviderMenuItem.DropDownItems.Add(menuItem);
                    });
                    MenuItem.DropDownItems.Add(_ChooseProviderMenuItem);
                } else {
                    _ChooseProviderMenuItem.Text = String.Format("Provider: {0}", Instance.ProviderIdentifier ?? "Unknown");
                }

                if (_RemoveBookmarkMenuItem == null) {
                    _RemoveBookmarkMenuItem = Util.MakeBlankToolstripMenuItem("Remove from bookmarks", RemoveBookmarkMenuItem_Click);
                    MenuItem.DropDownItems.Add(_RemoveBookmarkMenuItem);
                }

                if (_AddBookmarkMenuItem == null) {
                    _AddBookmarkMenuItem = Util.MakeBlankToolstripMenuItem("Add to bookmarks", AddBookmarkMenuItem_Click);
                    MenuItem.DropDownItems.Add(_AddBookmarkMenuItem);
                }

                if (Instance.HasVagrantFile()) {
                    int runningCount = Instance.GetRunningMachineCount();
                    int SuspendedCount = Instance.GetMachineCountWithState(VagrantMachineState.SavedState);

                    if (runningCount == 0 && SuspendedCount == 0) {
                        MenuItem.Image = Resources.status_icon_off;
                    } else if (runningCount == this.Instance.Machines.Length) {
                        MenuItem.Image = Resources.status_icon_on;
                    } else {
                        MenuItem.Image = Resources.status_icon_suspended;
                    }

                    if (runningCount < Instance.Machines.Count()) {
                        _InstanceUpMenuItem.Visible = true;
                        _SSHMenuItem.Visible = false;
                        _InstanceReloadMenuItem.Visible = false;
                        _InstanceSuspendMenuItem.Visible = false;
                        _InstanceHaltMenuItem.Visible = false;
                        _InstanceProvisionMenuItem.Visible = false;
                    }

                    if (runningCount > 0) {
                        _InstanceUpMenuItem.Visible = false;
                        _SSHMenuItem.Visible = true;
                        _InstanceReloadMenuItem.Visible = true;
                        _InstanceSuspendMenuItem.Visible = true;
                        _InstanceHaltMenuItem.Visible = true;
                        _InstanceProvisionMenuItem.Visible = true;
                    }

                    if (Instance.Machines.Count() > 1) {
                        _SSHMenuItem.Visible = false;
                    }

                    if (BookmarkManager.Instance.GetBookmarkWithPath(Instance.Path) != null) {
                        _RemoveBookmarkMenuItem.Visible = true;
                        _AddBookmarkMenuItem.Visible = false;
                    } else {
                        _AddBookmarkMenuItem.Visible = true;
                        _RemoveBookmarkMenuItem.Visible = false;
                    }

                } else {
                    MenuItem.DropDownItems.Clear();
                }

                Bookmark bookmark = BookmarkManager.Instance.GetBookmarkWithPath(Instance.Path);
                if (bookmark != null) {
                    MenuItem.Text = "[B] " + bookmark.DisplayName;
                } else {
                    string title;
                    if (Properties.Settings.Default.UsePathAsInstanceDisplayName) {
                        title = Instance.Path;
                    } else {
                        title = Instance.DisplayName;
                    }

                    if (Instance.Machines.Count() > 0 && Properties.Settings.Default.IncludeMachineNamesInMenu) {
                        title = String.Format("{0} ({1})", title, String.Join(", ", Instance.Machines.Select(machine => machine.Name).ToArray()));
                    }

                    MenuItem.Text = title;
                }

                if (_MachineSeparator == null) {
                    _MachineSeparator = new ToolStripSeparator();
                    MenuItem.DropDownItems.Add(_MachineSeparator);
                }

                _MachineMenuItems.ForEach(machineItem => {
                    MenuItem.DropDownItems.Remove(machineItem);
                });

                _MachineMenuItems.Clear();

                if (Instance.Machines.Count() > 1) {
                    _MachineSeparator.Visible = true;

                    Array.ForEach(Instance.Machines, machine => {
                        ToolStripMenuItem machineItem = new ToolStripMenuItem(machine.Name);

                        ToolStripMenuItem machineUpMenuItem = new ToolStripMenuItem("Up", Resources.up, UpMachine_Click) { Tag = machine };
                        ToolStripMenuItem machineSSHMenuItem = new ToolStripMenuItem("SSH", Resources.ssh, SSHMachine_Click) { Tag = machine };
                        ToolStripMenuItem machineReloadMenuItem = new ToolStripMenuItem("Reload", Resources.reload, ReloadMachine_Click) { Tag = machine };
                        ToolStripMenuItem machineSuspendMenuItem = new ToolStripMenuItem("Suspend", Resources.suspend, SuspendMachine_Click) { Tag = machine };
                        ToolStripMenuItem machineHaltMenuItem = new ToolStripMenuItem("Halt", Resources.halt, HaltMachine_Click) { Tag = machine };
                        ToolStripMenuItem machineDestroyMenuItem = new ToolStripMenuItem("Destroy", Resources.destroy, DestroyMachine_Click) { Tag = machine };
                        ToolStripMenuItem machineProvisionMenuItem = new ToolStripMenuItem("Provision", Resources.provision, ProvisionMachine_Click) { Tag = machine };

                        machineItem.DropDownItems.AddRange(new ToolStripMenuItem[] {
                            machineUpMenuItem,
                            machineSSHMenuItem,
                            machineReloadMenuItem,
                            machineSuspendMenuItem,
                            machineHaltMenuItem,
                            machineDestroyMenuItem,
                            machineProvisionMenuItem
                        });

                        _MachineMenuItems.Add(machineItem);
                        MenuItem.DropDownItems.Insert(MenuItem.DropDownItems.IndexOf(_MachineSeparator) + _MachineMenuItems.Count, machineItem);

                        machineItem.Image = machine.State == VagrantMachineState.RunningState ? Resources.status_icon_on : machine.State == VagrantMachineState.SavedState ? Resources.status_icon_suspended : Resources.status_icon_off;

                        if (machine.State == VagrantMachineState.RunningState) {
                            machineUpMenuItem.Visible = false;
                            machineSSHMenuItem.Visible = true;
                            machineReloadMenuItem.Visible = true;
                            machineSuspendMenuItem.Visible = true;
                            machineHaltMenuItem.Visible = true;
                            machineProvisionMenuItem.Visible = true;
                        } else {
                            machineUpMenuItem.Visible = true;
                            machineSSHMenuItem.Visible = false;
                            machineReloadMenuItem.Visible = false;
                            machineSuspendMenuItem.Visible = false;
                            machineHaltMenuItem.Visible = false;
                            machineProvisionMenuItem.Visible = false;
                        }
                    });
                } else {
                    _MachineSeparator.Visible = false;
                }
            } else {
                MenuItem.DropDownItems.Clear();
            }
        }

        public void UpAllMachines_Click(object sender, EventArgs e) {
            Delegate.NativeMenuItemUpAllMachines(this);
        }

        public void SSHInstance_Click(object sender, EventArgs e) {
            Delegate.NativeMenuItemSSHInstance(this);
        }

        public void ReloadAllMachines_Click(object sender, EventArgs e) {
            Delegate.NativeMenuItemReloadAllMachines(this);
        }

        public void SuspendAllMachines_Click(object sender, EventArgs e) {
            Delegate.NativeMenuItemSuspendAllMachines(this);
        }

        public void HaltAllMachines_Click(object sender, EventArgs e) {
            Delegate.NativeMenuItemHaltAllMachines(this);
        }

        public void DestroyAllMachines_Click(object sender, EventArgs e) {
            Delegate.NativeMenuItemDestroyAllMachines(this);
        }

        public void ProvisionAllMachines_Click(object sender, EventArgs e) {
            Delegate.NativeMenuItemProvisionAllMachines(this);
        }

        public void OpenInExplorerMenuItem_Click(object sender, EventArgs e) {
            Delegate.NativeMenuItemOpenExplorer(this);
        }

        public void OpenInTerminalMenuItem_Click(object sender, EventArgs e) {
            Delegate.NativeMenuItemOpenTerminal(this);
        }

        public void TerminalMenuItem_Click(object sender, EventArgs e) {
            Delegate.NativeMenuItemOpenTerminal(this);
        }

        public void UpdateProviderIdentifier_Click(object sender, EventArgs e) {
            Delegate.NativeMenuItemUpdateProviderIdentifier(this, (string)((ToolStripMenuItem)sender).Tag);
        }

        public void RemoveBookmarkMenuItem_Click(object sender, EventArgs e) {
            Delegate.NativeMenuItemRemoveBookmark(this);
        }

        public void AddBookmarkMenuItem_Click(object sender, EventArgs e) {
            Delegate.NativeMenuItemAddBookmark(this);
        }

        public void UpMachine_Click(object sender, EventArgs e) {
            Delegate.NativeMenuItemUpMachine((VagrantMachine)((ToolStripMenuItem)sender).Tag);
        }

        public void SSHMachine_Click(object sender, EventArgs e) {
            Delegate.NativeMenuItemSSHMachine((VagrantMachine)((ToolStripMenuItem)sender).Tag);
        }
        
        public void ReloadMachine_Click(object sender, EventArgs e) {
            Delegate.NativeMenuItemReloadMachine((VagrantMachine)((ToolStripMenuItem)sender).Tag);
        }

        public void SuspendMachine_Click(object sender, EventArgs e) {
            Delegate.NativeMenuItemSuspendMachine((VagrantMachine)((ToolStripMenuItem)sender).Tag);
        }

        public void HaltMachine_Click(object sender, EventArgs e) {
            Delegate.NativeMenuItemHaltMachine((VagrantMachine)((ToolStripMenuItem)sender).Tag);
        }

        public void DestroyMachine_Click(object sender, EventArgs e) {
            Delegate.NativeMenuItemDestroyMachine((VagrantMachine)((ToolStripMenuItem)sender).Tag);
        }

        public void ProvisionMachine_Click(object sender, EventArgs e) {
            Delegate.NativeMenuItemProvisionMachine((VagrantMachine)((ToolStripMenuItem)sender).Tag);
        }
    }
}
