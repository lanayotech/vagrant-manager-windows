using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanayo.Vagrant_Manager {
    class Notification {
        public object Object { get; set; }
        public Dictionary<string, object> UserInfo { get; set; }

        public Notification(object obj) {
            Object = obj ?? null;
        }

        public Notification(object obj, Dictionary<string, object> userInfo) : this(obj) {
            UserInfo = userInfo ?? null;
        }

        public static Notification Empty {
            get {
                return new Notification(null, null);
            }
        }
    }
}
