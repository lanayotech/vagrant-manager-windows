using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lanayo.Vagrant_Manager.Core.Providers {
    class VagrantGlobalStatusScanner {

        public string[] GetInstancePaths() {
            List<string> paths = new List<string>();

            Process p = new Process {
                StartInfo = new ProcessStartInfo {
                    FileName = "cmd",
                    Arguments = "/C vagrant global-status",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true
                }
            };

            p.Start();
            p.WaitForExit();
            string outputString = p.StandardOutput.ReadToEnd();

            if (p.ExitCode == 0) {
                Regex regex = new Regex("(\\S+)\\s+(\\S+)\\s+(\\S+)\\s+(\\S+)\\s+([A-Z]:/.*)(\\n|$)");
                MatchCollection matchCollection = regex.Matches(outputString);
                foreach (Match match in matchCollection) {
                    if (match.Success) {
                        DirectoryInfo pathInfo = new DirectoryInfo(Util.TrimWhitespaceAndNewlines(match.Groups[5].Value));
                        string filePath = new DirectoryInfo(pathInfo + "/Vagrantfile").FullName;
                        if (File.Exists(filePath)) {
                            paths.Add(pathInfo.FullName);
                        }
                    }
                }
            }

            return paths.ToArray();
        }
    }
}
