using Lanayo.Vagrant_Manager.Core.Vagrant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanayo.Vagrant_Manager.Menu {
    interface MenuDelegate {
        void PerformVagrantAction(string action, VagrantInstance instance);
        void PerformVagrantAction(string action, VagrantMachine machine);
        void OpenInstanceInExplorer(VagrantInstance instance);
        void OpenInstanceInTerminal(VagrantInstance instance);
        void AddBookmarkWithInstance(VagrantInstance instance);
        void RemoveBookmarkWithInstance(VagrantInstance instance);
    }
}
