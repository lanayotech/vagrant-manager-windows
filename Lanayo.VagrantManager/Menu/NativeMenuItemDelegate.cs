using Lanayo.Vagrant_Manager.Core.Vagrant;
using Lanayo.Vagrant_Manager.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanayo.Vagrant_Manager.Menu {
    interface NativeMenuItemDelegate {
        void NativeMenuItemUpAllMachines(NativeMenuItem menuItem);
        void NativeMenuItemSSHInstance(NativeMenuItem menuItem);
        void NativeMenuItemSuspendAllMachines(NativeMenuItem menuItem);
        void NativeMenuItemReloadAllMachines(NativeMenuItem menuItem);
        void NativeMenuItemHaltAllMachines(NativeMenuItem menuItem);
        void NativeMenuItemDestroyAllMachines(NativeMenuItem menuItem);
        void NativeMenuItemProvisionAllMachines(NativeMenuItem menuItem);
        void NativeMenuItemOpenExplorer(NativeMenuItem menuItem);
        void NativeMenuItemOpenTerminal(NativeMenuItem menuItem);
        void NativeMenuItemUpdateProviderIdentifier(NativeMenuItem menuItem, string providerIdentifier);
        void NativeMenuItemRemoveBookmark(NativeMenuItem menuItem);
        void NativeMenuItemAddBookmark(NativeMenuItem menuItem);

        void NativeMenuItemUpMachine(VagrantMachine machine);
        void NativeMenuItemSSHMachine(VagrantMachine machine);
        void NativeMenuItemSuspendMachine(VagrantMachine machine);
        void NativeMenuItemReloadMachine(VagrantMachine machine);
        void NativeMenuItemHaltMachine(VagrantMachine machine);
        void NativeMenuItemDestroyMachine(VagrantMachine machine);
        void NativeMenuItemProvisionMachine(VagrantMachine machine);

    }
}
