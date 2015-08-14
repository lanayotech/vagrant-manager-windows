using System;
using System.Diagnostics;

namespace Lanayo.Vagrant_Manager.Core.CommandPromptApps.Apps
{
    /// <summary>
    /// ConEmu support
    /// </summary>
    class ConEmu : CommandPromptApp
    {

        public override string[] SupportedFiles
        {
            get
            {
                return new string[]
                {
                     "ConEmu64.exe",
                     "ConEmu32.exe",
                     "ConEmu.exe"
                };
            }
        }

        public override void launch(string path, string command = "")
        {
            Process p = new Process();
            p.StartInfo.FileName = Properties.Settings.Default.CommandPromptPath;
            if (command == "") {
                p.StartInfo.Arguments = String.Format("/Dir {0} /cmd cmd -new_console:f", Util.EscapeShellArg(path));
            } else {
                p.StartInfo.Arguments = String.Format("/Dir {0} /cmd {1} -new_console:f", Util.EscapeShellArg(path), command);
            }            
            p.Start();
        }
    }
}
