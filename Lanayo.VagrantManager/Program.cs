using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lanayo.Vagrant_Manager {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            bool OK;
            string appGuid = ((GuidAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), false).GetValue(0)).Value.ToString();
            Mutex mutex = new System.Threading.Mutex(true, appGuid, out OK);

            if (!OK) {
                MessageBox.Show("Another instance of Vagrant Manager is already running");
                return;
            }
            
            App app = App.Instance;
            app.Run();

            GC.KeepAlive(mutex);
        }
    }
}
