using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanayo.Vagrant_Manager.Core.Vagrant {
    interface VirtualMachineServiceProvider {
        string[] GetVagrantInstancePaths();
        string GetProviderIdentifier();
    }
}
