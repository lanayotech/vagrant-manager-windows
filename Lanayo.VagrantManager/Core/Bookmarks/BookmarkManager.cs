using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Lanayo.Vagrant_Manager.Core.Vagrant;

namespace Lanayo.Vagrant_Manager.Core.Bookmarks {
    class BookmarkManager {

        private static BookmarkManager _Instance;
        private List<Bookmark> _Bookmarks;

        public static BookmarkManager Instance {
            get {
                if (_Instance == null) {
                    _Instance = new BookmarkManager();
                }
                return _Instance;
            }
        }

        private BookmarkManager() {
            _Bookmarks = new List<Bookmark>();
        }

        public void LoadBookmarks() {
            lock (_Bookmarks) {
                if (Properties.Settings.Default.Bookmarks != null) {
                    try {
                        BinaryFormatter binaryFormatter = new BinaryFormatter();
                        _Bookmarks = (List<Bookmark>)binaryFormatter.Deserialize(new MemoryStream(Convert.FromBase64String(Properties.Settings.Default.Bookmarks)));
                    } catch (Exception) {
                        _Bookmarks = new List<Bookmark>();
                    }
                } else {
                    _Bookmarks = new List<Bookmark>();
                }               
            }
        }

        public void SaveBookmarks() {
            lock (_Bookmarks) {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                MemoryStream ms = new MemoryStream();
                binaryFormatter.Serialize(ms, _Bookmarks);

                Properties.Settings.Default.Bookmarks = Convert.ToBase64String(ms.ToArray());
                Properties.Settings.Default.Save();
            }
        }

        public Bookmark AddBookmark(Bookmark bookmark) {
            Bookmark existing = this.GetBookmarkWithPath(bookmark.Path);

            if (existing != null) {
                return existing;
            }

            lock (_Bookmarks) {
                _Bookmarks.Add(bookmark);
            }

            return bookmark;
        }

        public List<Bookmark> GetBookmarks() {
            lock(_Bookmarks) {
                return _Bookmarks.ToList();
            };
        }

        public void ClearBookmarks() {
            lock(_Bookmarks) {
                _Bookmarks.Clear();
            }
        }

        public Bookmark AddBookmarkWithPath(string path, string displayName, string providerIdentifier) {
            Bookmark bookmark = this.GetBookmarkWithPath(path);

            if (bookmark != null) {
                return bookmark;
            }
                
            bookmark = new Bookmark(path, displayName, providerIdentifier);
            if (providerIdentifier.Length == 0) {
                bookmark.ProviderIdentifier = VagrantManager.Instance.DetectVagrantProvider(path);
            }

            lock(_Bookmarks) {
                _Bookmarks.Add(bookmark);
            }
                
            return bookmark;
        }

        public void RemoveBookmarkWithPath(string path) {
            Bookmark bookmark = this.GetBookmarkWithPath(path);

            if (bookmark != null) {
                lock (_Bookmarks) {
                    _Bookmarks.Remove(bookmark);
                }
            }
        }

        public Bookmark GetBookmarkWithPath(string path) {
            lock (_Bookmarks) {
                return _Bookmarks.Find(bookmark => bookmark.Path == path);
            }
        }

        public int GetIndexOfBookmarkWithPath(string path) {
            return _Bookmarks.IndexOf(this.GetBookmarkWithPath(path));
        }

    }
}
