using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lanayo.Vagrant_Manager.Core.Vagrant {
    class VagrantInstance {
        private string _Path;
        private string _DisplayName;
        private List<VagrantMachine> _Machines;

        public string ProviderIdentifier { get; set; }
        public string Path { get { return _Path; } }
        public string DisplayName { get { return _DisplayName; } }
        public VagrantMachine[] Machines { get { return _Machines.ToArray(); } }
        public VagrantInstance() {
            _Machines = new List<VagrantMachine>();
        }

        public VagrantInstance(string path, string providerIdentifier) {
            if (String.IsNullOrEmpty(providerIdentifier)) {
                providerIdentifier = VagrantManager.Instance.DetectVagrantProvider(path);
            }
            
            _Path = path;
            ProviderIdentifier = providerIdentifier;

            _DisplayName = new DirectoryInfo(path).Name;

            if (_DisplayName.Length < 1) {
                _DisplayName = "Unknown";
            }

            _Machines = new List<VagrantMachine>();
        }

        public VagrantInstance(string path, string providerIdentifier, string displayName) : this(path, providerIdentifier) {
            _DisplayName = DisplayName;
        }

        public int GetRunningMachineCount() {
            return _Machines.Where(machine => machine.State == VagrantMachineState.RunningState).Count();
        }

        public bool HasVagrantFile() {
            return this.GetVagrantFilePath() != null;
        }

        public string GetVagrantFilePath() {
            string filePath = new DirectoryInfo(this._Path + "/Vagrantfile").FullName;
            return File.Exists(filePath) ? filePath : null;
        }

        public VagrantMachine GetMachineWithName(string name) {
            return _Machines.Find(machine => machine.Name == name);
        }

        public void QueryMachines() {
            List<VagrantMachine> machines = new List<VagrantMachine>();

            if (this.HasVagrantFile()) {
                Process p = new Process {
                    StartInfo = new ProcessStartInfo {
                        FileName = "cmd",
                        WindowStyle = ProcessWindowStyle.Hidden,
                        CreateNoWindow = true,
                        Arguments = String.Format("/C cd /d {0} && vagrant status", Util.EscapeShellArg(_Path)),
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                    }
                };

                p.Start();
                p.WaitForExit();
                string outputString = p.StandardOutput.ReadToEnd();

                Regex regex = new Regex("([\\w-_\\.]+)\\s+([\\w\\s]+) \\(\\w+\\)");
                MatchCollection matchCollection = regex.Matches(outputString);
                foreach (Match match in matchCollection) {
                    VagrantMachine machine = new VagrantMachine(this, Util.TrimWhitespaceAndNewlines(match.Groups[1].Value), VagrantMachineState.UnknownState);
                    machine.StateString = Util.TrimWhitespaceAndNewlines(match.Groups[2].Value);
                    machines.Add(machine);
                }
            }

            _Machines = machines;
        }

        public int GetMachineCountWithState(VagrantMachineState state) {
            return _Machines.Where(machine => machine.State == state).Count();
        }
    }
}
