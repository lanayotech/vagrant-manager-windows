using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanayo.Vagrant_Manager.Core.Vagrant {
    interface VagrantManagerDelegate {
        void InstanceAdded(VagrantManager vagrantManager, VagrantInstance instance);
        void InstanceRemoved(VagrantManager vagrantManager, VagrantInstance instance);
        void InstanceUpdated(VagrantManager vagrantManager, VagrantInstance oldInstance, VagrantInstance newInstance);
    }
}
