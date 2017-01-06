using System;
using System.Diagnostics;

namespace Lanayo.Vagrant_Manager.Core.CommandPromptApps.Apps
{
    /// <summary>
    /// Standart windows console support
    /// </summary>
    class CMD : CommandPromptApp
    {

        public override string[] SupportedFiles
        {
            get
            {
                return new string[]
                {
                    "cmd.exe"
                };
            }
        }        

        public override void launch(string path, string command = "")
        {
            Process p = new Process();
            p.StartInfo.FileName = Properties.Settings.Default.CommandPromptPath;
            if (command == "") {
                p.StartInfo.Arguments = String.Format("/d /K cd /D {0}", Util.EscapeShellArg(path));
            } else {
                p.StartInfo.Arguments = String.Format("/d /K cd /D {0} && {1}", Util.EscapeShellArg(path), command);
            }
            p.Start();
        }
    }
}
