using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lanayo.Vagrant_Manager.Core.Vagrant;
using System.IO;

namespace Lanayo.Vagrant_Manager.Core.Providers {
    class VirtualBoxMachineInfo : VirtualMachineInfo {
        public VirtualBoxMachineInfo() {}

        public VirtualBoxMachineInfo(string infoString) {
            string[] infoArray = infoString.Split(new string[] { Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, string> infoPairs = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string,string>> sharedFolders = new Dictionary<string, Dictionary<string, string>>();

            foreach (string infoLine in infoArray) {
                if (!infoLine.Contains('=')) {
                    continue;
                }

                string name = infoLine.Substring(0, infoLine.IndexOf('='));
                string value = infoLine.Substring(infoLine.IndexOf('=')+1, infoLine.Length - infoLine.IndexOf('=')-1);

                if (name.Substring(0, 1) == "\"") {
                    name = name.Substring(1, name.Length - 2);
                }

                if (value.Substring(0, 1) == "\"") {
                    value = value.Substring(1, value.Length - 2);
                }

                if (name == "name") {
                    Name = value;
                } else if (name == "ostype") {
                    OS = value;
                } else if (name == "UUID") {
                    UUID = value;
                } else if (name == "VMState") {
                    StateString = value;
                } else if (name.StartsWith("SharedFolderNameMachineMapping") || name.StartsWith("SharedFolderPathMachineMapping")) {
                    string mappingId = name.Substring(30, name.Length - 30);
                    if (!sharedFolders.ContainsKey(mappingId)) {
                        sharedFolders[mappingId] = new Dictionary<string, string>();
                    }

                    if (name.StartsWith("SharedFolderNameMachineMapping")) {
                        sharedFolders[mappingId]["name"] = value;
                    } else if(name.StartsWith("SharedFolderPathMachineMapping")) {
                        sharedFolders[mappingId]["path"] = new DirectoryInfo(value).FullName;
                    }
                } else {
                    infoPairs[name] = value;
                }
            }

            Dictionary<string, string> validSharedFolders = new Dictionary<string, string>();
            foreach (KeyValuePair<string, Dictionary<string,string>> sharedFolderKeyValue in sharedFolders) {
                Dictionary<string, string> sharedFolder = sharedFolderKeyValue.Value;
                validSharedFolders[sharedFolder["name"]] = sharedFolder["path"];
            }

            Properties = infoPairs.ToDictionary(entry => entry.Key, entry => entry.Value);
            SharedFolders = validSharedFolders.ToDictionary(entry => entry.Key, entry => entry.Value);
        }
    }
}
