using Lanayo.Vagrant_Manager.Core.Bookmarks;
using Lanayo.Vagrant_Manager.Core.Providers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanayo.Vagrant_Manager.Core.Vagrant {
    class VagrantManager {
        private static VagrantManager _Instance;
        private List<VagrantInstance> _Instances;
        private Dictionary<string, VirtualMachineServiceProvider> _Providers;
        public VagrantManagerDelegate Delegate { get; set; }
        public VagrantInstance[] Instances { get { return _Instances.ToArray(); } }

        private VagrantManager() {
            _Instances = new List<VagrantInstance>();
            _Providers = new Dictionary<string, VirtualMachineServiceProvider>();
        }

        public static VagrantManager Instance {
            get {
                if (_Instance == null) {
                    _Instance = new VagrantManager();
                }
                return _Instance;
            }
        }

        public int GetRunningVmCount() {
            lock(_Instances) {
                return _Instances.Select(instance => instance.GetMachineCountWithState(VagrantMachineState.RunningState)).Sum();
            }
        }

        public List<VagrantMachine> GetMachinesWithState(VagrantMachineState state) {
            lock (_Instances) {
                return _Instances.SelectMany(instance => instance.Machines.Where(machine => machine.State == state)).ToList();
            }
        }

        public void RegisterServiceProvider(VirtualMachineServiceProvider provider) {
            _Providers[provider.GetProviderIdentifier()] = provider;
        }

        public VagrantInstance GetInstanceForPath(string path) {
            return _Instances.Find(instance => instance.Path == path);
        }

        public void RefreshInstances(){
            List<VagrantInstance> instances = new List<VagrantInstance>();

            // create instance for each bookmark
            List<Bookmark> bookmarks = BookmarkManager.Instance.GetBookmarks();
            bookmarks.ForEach(bookmark => instances.Add(new VagrantInstance(bookmark.Path, bookmark.ProviderIdentifier, bookmark.DisplayName)));

            List<string> allPaths = new List<string>();

            // scan vagrant global-status output
            VagrantGlobalStatusScanner globalStatusScanner = new VagrantGlobalStatusScanner();
            Array.ForEach(globalStatusScanner.GetInstancePaths(), (path) => {
                if (BookmarkManager.Instance.GetBookmarkWithPath(path) == null && !allPaths.Contains(path)) {
                    allPaths.Add(path);
                    instances.Add(new VagrantInstance(path, null));
                }
            });

            // create instance for each detected path
            Dictionary<string, string[]> detectedPaths = this.DetectInstancePaths();

            detectedPaths.Keys.ToList().ForEach(providerIdentifier => {
                string[] paths = detectedPaths[providerIdentifier];
                paths.ToList().ForEach(path => {
                    if (BookmarkManager.Instance.GetBookmarkWithPath(path) == null && !allPaths.Contains(path)) {
                        allPaths.Add(path);
                        instances.Add(new VagrantInstance(path, providerIdentifier));
                    }
                });
            });

            List<string> validPaths = new List<string>();

            List<Task> tasks = new List<Task>();

            instances.ForEach(instance => {
                Task task = Task.Run(() => {
                    instance.QueryMachines();

                    lock (_Instances) {
                        VagrantInstance existingInstance = this.GetInstanceForPath(instance.Path);

                        if (existingInstance != null) {
                            // instance already exists, check for changes
                            int idx = _Instances.IndexOf(existingInstance);
                            if (instance.Machines.Length != existingInstance.Machines.Length || existingInstance.DisplayName != instance.DisplayName || existingInstance.ProviderIdentifier != instance.ProviderIdentifier) {
                                _Instances[idx] = instance;
                                Delegate.InstanceUpdated(this, existingInstance, instance);
                            } else {
                                Array.ForEach(instance.Machines, machine => {
                                    VagrantMachine existingMachine = existingInstance.GetMachineWithName(machine.Name);

                                    if (existingMachine == null || existingMachine.StateString != machine.StateString) {
                                        _Instances[idx] = instance;
                                        Delegate.InstanceUpdated(this, existingInstance, instance);
                                    }
                                });
                            }
                        } else {
                            //new instance
                            _Instances.Add(instance);
                            Delegate.InstanceAdded(this, instance);
                        }

                        validPaths.Add(instance.Path);
                    }
                });

                tasks.Add(task);
            });

            Task.WaitAll(tasks.ToArray());

            for (int i = _Instances.Count - 1; i >= 0; --i) {
                VagrantInstance instance = _Instances.ElementAt(i);

                if (!validPaths.Contains(instance.Path)) {
                    _Instances.RemoveAt(i);
                    Delegate.InstanceRemoved(this, instance);
                }
            }
        }

        public Dictionary<string, string[]> DetectInstancePaths() {
            List<string> allPaths = new List<string>();
            Dictionary<string, string[]> keyedPaths = new Dictionary<string, string[]>();

            _Providers.Values.ToList().ForEach(provider => {
                string[] paths = provider.GetVagrantInstancePaths();
                List<string> uniquePaths = new List<string>();

                paths.ToList().ForEach(path => {
                    if (!allPaths.Contains(path)) {
                        allPaths.Add(path);
                        uniquePaths.Add(path);
                    }
                });

                keyedPaths[provider.GetProviderIdentifier()] = uniquePaths.ToArray();
            });

            return keyedPaths;
        }

        public string DetectVagrantProvider(string path) {
            try {
                string[] machinePaths = Directory.GetDirectories(new DirectoryInfo(path + "/.vagrant/machines/").FullName);

                foreach(string machinePath in machinePaths) {
                    foreach(string provider in this.GetProviderIdentifiers()) {
                        if (Directory.Exists(new DirectoryInfo(machinePath+"/"+provider).FullName)) {
                            return provider;
                        }
                    }
                }

            } catch (Exception) {
                return "virtualbox";
            }

            return "virtualbox";
        }

        public string[] GetProviderIdentifiers() {
            return _Providers.Keys.ToArray().Concat(new List<string> { "vmware_workstation", "vmware_fusion", "docker" }).ToArray();
        }

    }
}
