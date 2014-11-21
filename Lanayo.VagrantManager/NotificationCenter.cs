using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanayo.Vagrant_Manager {
    class NotificationCenter {
        private static NotificationCenter _Instance;
        private Dictionary<string, List<NotificationDelegate>> _Notifications;

        public delegate void NotificationDelegate(Notification notification);

        private NotificationCenter() {
            _Notifications = new Dictionary<string, List<NotificationDelegate>>();
        }
 
        public static NotificationCenter Instance {
            get { return _Instance ?? (_Instance = new NotificationCenter()); }
        }

        public void AddObserver(NotificationDelegate notificationDelegate, string notificationName) {
            if (string.IsNullOrEmpty(notificationName)) {
                throw new ArgumentNullException(@"notificationDelegate");
            }
            if (notificationDelegate == null) {
                throw new ArgumentNullException("notificationDelegate");
            }
            if(!_Notifications.ContainsKey(notificationName)) {
                _Notifications[notificationName] = new List<NotificationDelegate>();
            }
            _Notifications[notificationName].Add(notificationDelegate);
        }

        public void RemoveObserver(NotificationDelegate notificationDelegate, string notificationName) {
            if (string.IsNullOrEmpty(notificationName)) {
                throw new ArgumentNullException(@"notificationName");
            }
            if (notificationDelegate == null) {
                throw new ArgumentNullException("notificationDelegate");
            }
            if (_Notifications.ContainsKey(notificationName)) {
                _Notifications[notificationName].Remove(notificationDelegate);
            }
        }

        public void PostNotification(string notificationName, Notification notification) {
            if (notification == null) {
                throw new ArgumentNullException("notification");
            }

            if (_Notifications.ContainsKey(notificationName)) {
                _Notifications[notificationName].ForEach(notificationDelegate => {
                    notificationDelegate(notification);
                });
            }
        }

        public void PostNotification(string notificationName) {
            if (string.IsNullOrEmpty(notificationName)) {
                throw new ArgumentNullException(@"notificationName");
            }

            if (_Notifications.ContainsKey(notificationName)) {
                _Notifications[notificationName].ForEach(notificationDelegate => {
                    try {
                        notificationDelegate(Notification.Empty);
                    } catch (Exception) {
                        //Error firing Notification
                    }
                });                    
            }
        }

    }
}
