using System.Linq;
using System.IO;
using System.Reflection;
using System;

namespace Lanayo.Vagrant_Manager.Core.CommandPromptApps
{
    /// <summary>
    /// This class is used as base class for Command Prompt Apps 
    /// </summary>
    public abstract class CommandPromptApp
    {

        /// <summary>
        /// Get current command prompts app provider.
        /// </summary>
        /// <returns></returns>
        public static CommandPromptApp GetCurrent()
        {
            foreach (CommandPromptApp instance in GetAll())
            {
                if (instance.canLaunch()) {
                    return instance;
                }
            }
            return null;
        }

        /// <summary>
        /// Get all types of CommandPromptApp
        /// </summary>
        /// <returns></returns>
        public static CommandPromptApp[] GetAll()
        {
            return Assembly.GetAssembly(typeof(Lanayo.Vagrant_Manager.Core.CommandPromptApps.CommandPromptApp)).GetTypes().Where(
                t => String.Equals(t.Namespace, "Lanayo.Vagrant_Manager.Core.CommandPromptApps.Apps", StringComparison.Ordinal)
            ).Select(
                t => (CommandPromptApp)Activator.CreateInstance(t)
            ).ToArray();
        }

        /// <summary>
        /// List of filenames that are supported for thie method
        /// </summary>
        public abstract string[] SupportedFiles { get; }

        /// <summary>
        /// Opens console
        /// </summary>
        /// <param name="path">Working path</param>
        /// <param name="command">Command to execute</param>
        public abstract void launch(string path, string command = "");

        /// <summary>
        /// Checks if this CommandPromptAppProvider can be used for selected  CommandPromptPath
        /// </summary>
        /// <returns></returns>
        public bool canLaunch()
        {
            return this.SupportedFiles.Contains(Path.GetFileName(Properties.Settings.Default.CommandPromptPath));
        }

    }
}
