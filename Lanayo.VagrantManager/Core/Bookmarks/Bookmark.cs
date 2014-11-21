using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanayo.Vagrant_Manager.Core.Bookmarks {
    [Serializable]
    class Bookmark : ICloneable {
        public string Path { get; set; }
        public string DisplayName { get; set; }
        public string ProviderIdentifier { get; set; }

        public Bookmark() {}

        public Bookmark(string path, string displayName, string providerIdentifier) {
            Path = path;
            DisplayName = displayName;
            ProviderIdentifier = providerIdentifier;
        }

        public object Clone() {
            Bookmark bookmark = new Bookmark();
            bookmark.Path = this.Path;
            bookmark.DisplayName = this.DisplayName;
            bookmark.ProviderIdentifier = this.ProviderIdentifier;

            return bookmark;
        }
    }
}