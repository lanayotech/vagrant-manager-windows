using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lanayo.Vagrant_Manager {
    class SingleGlobalInstance : IDisposable {
        public bool HasHandle = false;
        Mutex mutex;

        private void InitMutex() {
            string appGuid = ((GuidAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), false).GetValue(0)).Value.ToString();
            string mutexId = string.Format("Global\\{{{0}}}", appGuid);
            mutex = new Mutex(false, mutexId);

            var allowEveryoneRule = new MutexAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), MutexRights.FullControl, AccessControlType.Allow);
            var securitySettings = new MutexSecurity();
            securitySettings.AddAccessRule(allowEveryoneRule);
            mutex.SetAccessControl(securitySettings);
        }

        public SingleGlobalInstance(int timeOut) {
            InitMutex();
            try {
                if (timeOut < 0)
                    HasHandle = mutex.WaitOne(Timeout.Infinite, false);
                else
                    HasHandle = mutex.WaitOne(timeOut, false);

                if (HasHandle == false)
                    throw new TimeoutException("Timeout waiting for exclusive access on SingleInstance");
            } catch (AbandonedMutexException) {
                HasHandle = true;
            }
        }

        public void Dispose() {
            if (mutex != null) {
                if (HasHandle) {
                    mutex.ReleaseMutex();
                }

                mutex.Close();
            }
        }
    }
}
