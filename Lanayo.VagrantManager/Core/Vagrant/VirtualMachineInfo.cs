using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanayo.Vagrant_Manager.Core.Vagrant {
    abstract class VirtualMachineInfo {
        public string UUID { get; set; }
        public PossibleVmStates State { get; set; }
        public string StateString { get; set; }
        public string Name { get; set; }
        public string OS { get; set; }
        public Dictionary<string, string> SharedFolders { get; set; }
        public Dictionary<string, string> Properties { get; set; }
        public VirtualMachineServiceProvider Provider { get; set; }

        public string GetSharedFolderPathWithName(string name) {
            return SharedFolders.ContainsKey(name) ? SharedFolders[name]: "";
        }

        public bool isState(PossibleVmStates state) {
            return State == state;
        }

        public bool isRunning() {
            return State == PossibleVmStates.running;
        }

        public bool isSuspended() {
            return State == PossibleVmStates.suspended;
        }

        public bool isOff() {
            return State == PossibleVmStates.off;
        }

        public VirtualMachineServiceProvider GetProvider() {
            return Provider;
        }
    }
}
