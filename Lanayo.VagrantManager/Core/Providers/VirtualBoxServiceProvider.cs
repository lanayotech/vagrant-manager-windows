using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Lanayo.Vagrant_Manager.Core.Vagrant;
using System.Text.RegularExpressions;
using System.IO;

namespace Lanayo.Vagrant_Manager.Core.Providers {
    class VirtualBoxServiceProvider : VirtualMachineServiceProvider {
        public string[] GetVagrantInstancePaths() {
            List<string> paths = new List<string>();

            string[] uuids = this.GetAllVirtualMachineUUIDs();

            foreach(string uuid in uuids) {
                VirtualBoxMachineInfo machineInfo = this.GetVirtualMachineInfoFromUUID(uuid);

                if (machineInfo != null) {
                    string instancePath = machineInfo.GetSharedFolderPathWithName("vagrant");
                    if (instancePath.Length > 0) {
                        if (File.Exists(instancePath+"/Vagrantfile") && !paths.Contains(instancePath)) {
                            paths.Add(instancePath);
                        }
                    }
                }
            }

            return paths.ToArray();
        }
        public string GetProviderIdentifier() {
            return "virtualbox";
        }

        public string[] GetAllVirtualMachineUUIDs() {
            List<string> uuids = new List<string>();

            Process p = new Process {
                StartInfo = new ProcessStartInfo {
                    FileName = Properties.Settings.Default.VBoxManagePath,
                    Arguments = "list vms",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true
                }
            };

            try {
                p.Start();
            } catch (Exception) { 
                return uuids.ToArray(); 
            }

            p.WaitForExit();
            string outputString = p.StandardOutput.ReadToEnd();

            if (p.ExitCode == 0) {
                Regex regex = new Regex("\"[^\"]+\"\\s+\\{([^\\}]+)\\}");
                MatchCollection matchCollection = regex.Matches(outputString);
                foreach (Match match in matchCollection) {
                    if (match.Success) {
                        uuids.Add(match.Groups[1].Value);
                    }
                }
            }

            return uuids.ToArray();
        }

        public VirtualBoxMachineInfo GetVirtualMachineInfoFromUUID(string uuid) {
            Process p = new Process {
                StartInfo = new ProcessStartInfo {
                    FileName = Properties.Settings.Default.VBoxManagePath,
                    Arguments = String.Format("showvminfo {0} --machinereadable", uuid),
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true
                }
            };

            try {
                p.Start();
            } catch (Exception) {
                return null;
            }

            p.WaitForExit();
            string outputString = p.StandardOutput.ReadToEnd();

            if (p.ExitCode == 0) {
                return new VirtualBoxMachineInfo(outputString);
            } else {
                return null;
            }

        }
    }
}
