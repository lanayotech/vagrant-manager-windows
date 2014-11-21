using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanayo.Vagrant_Manager.Core.Vagrant {

    class VagrantMachine {
        public VagrantInstance Instance { get; set; }
        public string Name { get; set; }
        public VagrantMachineState State { get; set; }
        public string StateString {
            set {
                State = VagrantMachine.GetStateForString(value);
            }
            get { return VagrantMachine.GetStringForState(State); }
        }

        public VagrantMachine() {}

        public VagrantMachine(VagrantInstance instance, string name, VagrantMachineState state) {
            Instance = instance;
            Name = name;
            State = state;
            StateString = VagrantMachine.GetStringForState(state);
        }

        public static string GetStringForState(VagrantMachineState state) {
            if (state == VagrantMachineState.NotCreatedState) {
                return "not created";
            } else if (state == VagrantMachineState.PowerOffState) {
                return "poweroff";
            } else if (state == VagrantMachineState.SavedState) {
                return "saved";
            } else if (state == VagrantMachineState.RunningState) {
                return "running";
            } else if (state == VagrantMachineState.RestoringState) {
                return "restoring";
            } else {
                return "unknown";
            }
        }

        public static VagrantMachineState GetStateForString(string stateString) {
            if(stateString == "not created") {
                return VagrantMachineState.NotCreatedState;
            } else if(stateString == "poweroff") {
                return VagrantMachineState.PowerOffState;
            } else if(stateString == "saved") {
                return VagrantMachineState.SavedState;
            } else if(stateString == "running") {
                return VagrantMachineState.RunningState;
            } else if(stateString == "restoring") {
                return VagrantMachineState.RestoringState;
            } else {
                return VagrantMachineState.UnknownState;
            }
        }
    }
}
