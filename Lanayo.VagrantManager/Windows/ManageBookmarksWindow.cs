using Lanayo.Vagrant_Manager.Core.Bookmarks;
using Lanayo.Vagrant_Manager.Core.Vagrant;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO;
using System.Threading;

namespace Lanayo.Vagrant_Manager.Windows {
    public partial class ManageBookmarksWindow : Form {
        private List<Bookmark> Bookmarks;
        private BindingSource BookmarksBindingSource;
        private CancellationTokenSource CancelScan;
        private bool NeedsClosing = false;
        private bool IsScanning = false;

        private Rectangle DragBoxFromMouseDown;
        private int RowIndexFromMouseDown;
        private int RowIndexOfItemUnderMouseToDrop;

        public ManageBookmarksWindow() {
            InitializeComponent();
        }

        private void ManageBookmarksWindow_Load(object sender, EventArgs e) {
            CancelScan = new CancellationTokenSource();
            Bookmarks = new List<Bookmark>(BookmarkManager.Instance.GetBookmarks().Select(bookmark => (Bookmark)bookmark.Clone()));

            ((DataGridViewComboBoxColumn)BookmarksDataGridView.Columns["ProviderIdentifier"]).Items.AddRange(VagrantManager.Instance.GetProviderIdentifiers());
            BookmarksBindingSource = new BindingSource() { DataSource = Bookmarks };
            BookmarksDataGridView.DataSource = BookmarksBindingSource;

            BookmarksDataGridView.ColumnHeaderMouseClick += (s, args) => {
                BookmarksDataGridView.EndEdit();

                foreach (DataGridViewColumn column in BookmarksDataGridView.Columns) {
                    if (column == BookmarksDataGridView.Columns[args.ColumnIndex]) {
                        column.Tag = column.Tag != null && ((SortOrder)column.Tag) == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
                        column.HeaderCell.SortGlyphDirection = (SortOrder)column.Tag;

                        Bookmarks.Sort((a, b) => {
                            PropertyInfo bookmarkProperty = typeof(Bookmark).GetProperty(column.DataPropertyName);
                            return String.Compare(bookmarkProperty.GetValue(a).ToString(), bookmarkProperty.GetValue(b).ToString());
                        });

                        if (column.HeaderCell.SortGlyphDirection == SortOrder.Descending) {
                            Bookmarks.Reverse();
                        }
                    } else {
                        column.HeaderCell.SortGlyphDirection = SortOrder.None;
                        column.Tag = null;
                    }
                }

                BookmarksDataGridView.Refresh();
            };
            BookmarksDataGridView.CellValueChanged += (s, args) => {
                if (BookmarksDataGridView.Columns["ProviderIdentifier"].Index == args.ColumnIndex) {
                    Bookmarks.ElementAt(args.RowIndex).ProviderIdentifier = (string) BookmarksDataGridView.Rows[args.RowIndex].Cells[args.ColumnIndex].Value;
                    BookmarksDataGridView.Refresh();
                }
            };

            RecursiveScanCheckbox.Checked = Properties.Settings.Default.RecursiveBookmarkScan;
        }

        private void SaveBookmarksButton_Click(object sender, EventArgs e) {
            BookmarksDataGridView.EndEdit();

            BookmarkManager.Instance.ClearBookmarks();
            Bookmarks.ForEach(bookmark => {
                BookmarkManager.Instance.AddBookmark(bookmark);
            });
            BookmarkManager.Instance.SaveBookmarks();

            NotificationCenter.Instance.PostNotification("vagrant-manager.bookmarks-updated");
            this.Close();
        }

        private void CancelBookmarksButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void AddBookmarksButton_Click(object sender, EventArgs e) {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            dialog.Multiselect = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok) {
                List<Bookmark> bookmarksSnapshot = Bookmarks.Select(bookmark => (Bookmark)bookmark.Clone()).ToList();

                CancelScanButton.Show();
                CancelBookmarksButton.Enabled = false;
                SaveBookmarksButton.Enabled = false;
                AddBookmarksButton.Enabled = false;
                RemoveBookmarksButton.Enabled = false;
                BookmarksDataGridView.Enabled = false;

                IsScanning = true;
                CancelScan = new CancellationTokenSource();

                Task.Run(() => {
                    try {

                        List<string> bookmarkPaths = Bookmarks.Select(bookmark => bookmark.Path).ToList();

                        foreach (string path in dialog.FileNames) {

                            if (Properties.Settings.Default.RecursiveBookmarkScan) {

                                IEnumerable<string> filePaths = EnumerateFiles(path, "*.*", SearchOption.AllDirectories)
                                    .Where(p => {
                                        try {
                                            return p.Split(System.IO.Path.DirectorySeparatorChar).Where(s => s[0] == '.').Count() == 0 && !((File.GetAttributes(p) & FileAttributes.Hidden) == FileAttributes.Hidden);
                                        } catch (Exception) { return false; }
                                    });

                                foreach (string filePath in filePaths) {
                                    CancelScan.Token.ThrowIfCancellationRequested();

                                    DirectoryInfo info = new DirectoryInfo(filePath);

                                    this.Invoke((MethodInvoker)delegate {
                                        DirectoryLabelTextField.Text = info.FullName;
                                    });

                                    if (info.Name == "Vagrantfile" && !bookmarkPaths.Contains(info.Parent.FullName)) {
                                        Bookmarks.Add(new Bookmark(info.Parent.FullName, info.Parent.Name, VagrantManager.Instance.DetectVagrantProvider(info.Parent.FullName)));
                                    }
                                }

                            } else {
                                if (File.Exists(new DirectoryInfo(path + "/Vagrantfile").FullName) && !bookmarkPaths.Contains(path)) {
                                    Bookmarks.Add(new Bookmark(path, new DirectoryInfo(path).Name, VagrantManager.Instance.DetectVagrantProvider(path)));
                                }
                            }
                        }

                        this.Invoke((MethodInvoker)delegate {
                            this.ScanComplete();
                        }); 

                    } catch (OperationCanceledException) {
                        this.Invoke((MethodInvoker)delegate {
                            Bookmarks = bookmarksSnapshot;
                            BookmarksBindingSource.DataSource = Bookmarks;
                            this.ScanComplete();
                        });
                    }

                }, CancelScan.Token);
            }
        }

        private void ScanComplete() {
            IsScanning = false;

            if (NeedsClosing) {
                this.Close();
            }

            CancelScanButton.Hide();
            CancelBookmarksButton.Enabled = true;
            SaveBookmarksButton.Enabled = true;
            AddBookmarksButton.Enabled = true;
            RemoveBookmarksButton.Enabled = true;
            BookmarksDataGridView.Enabled = true;
            DirectoryLabelTextField.Text = "";

            BookmarksBindingSource.ResetBindings(false);
        }

        private void RemoveBookmarksButton_Click(object sender, EventArgs e) {
            foreach(DataGridViewRow row in BookmarksDataGridView.SelectedRows) {
                Bookmarks.RemoveAt(row.Index);
            }

            BookmarksBindingSource.ResetBindings(false);
        }

        private void RecursiveScanCheckbox_CheckedChanged(object sender, EventArgs e) {
            Properties.Settings.Default.RecursiveBookmarkScan = RecursiveScanCheckbox.Checked;
            Properties.Settings.Default.Save();
        }

        private void BookmarksDataGridView_DragOver(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Move;
        }

        private void BookmarksDataGridView_DragDrop(object sender, DragEventArgs e) {
            // The mouse locations are relative to the screen, so they must be
            // converted to client coordinates.
            Point clientPoint = BookmarksDataGridView.PointToClient(new Point(e.X, e.Y));

            // Get the row index of the item the mouse is below.
            RowIndexOfItemUnderMouseToDrop = BookmarksDataGridView.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            // If the drag operation was a move then remove and insert the row.
            if (e.Effect == DragDropEffects.Move) {
                DataGridViewRow rowToMove = e.Data.GetData(typeof(DataGridViewRow)) as DataGridViewRow;
                
                Bookmark bookmark = (Bookmark)Bookmarks.ElementAt(rowToMove.Index).Clone();
                Bookmarks.RemoveAt(rowToMove.Index);
                if (RowIndexOfItemUnderMouseToDrop >= 0) {
                    Bookmarks.Insert(RowIndexOfItemUnderMouseToDrop, bookmark);
                } else {
                    Bookmarks.Add(bookmark);
                }
            }

            BookmarksBindingSource.ResetBindings(false);
        }

        private void BookmarksDataGridView_MouseMove(object sender, MouseEventArgs e) {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left) {
                // If the mouse moves outside the rectangle, start the drag.
                if (DragBoxFromMouseDown != Rectangle.Empty && !DragBoxFromMouseDown.Contains(e.X, e.Y)) {
                    // Proceed with the drag and drop, passing in the list item.                   
                    DragDropEffects dropEffect = BookmarksDataGridView.DoDragDrop(BookmarksDataGridView.Rows[RowIndexFromMouseDown], DragDropEffects.Move);
                }
            }
        }

        private static IEnumerable<string> EnumerateFiles(string path, string searchPattern, SearchOption searchOpt) {
            try {
                var dirFiles = Enumerable.Empty<string>();

                if (searchOpt == SearchOption.AllDirectories) {
                    dirFiles = Directory.EnumerateDirectories(path)
                                        .SelectMany(x => EnumerateFiles(x, searchPattern, searchOpt));
                }
                return dirFiles.Concat(Directory.EnumerateFiles(path, searchPattern));
            } catch (Exception) {
                return Enumerable.Empty<string>();
            }
        }

        private void BookmarksDataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e) {
            RowIndexFromMouseDown = e.RowIndex;

            if (RowIndexFromMouseDown != -1) {
                // Remember the point where the mouse down occurred. 
                // The DragSize indicates the size that the mouse can move 
                // before a drag event should be started.               
                Size dragSize = SystemInformation.DragSize;

                // Create a rectangle using the DragSize, with the mouse position being
                // at the center of the rectangle.
                DragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
            } else {
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                DragBoxFromMouseDown = Rectangle.Empty;
            }
        }

        private void CancelScanButton_Click(object sender, EventArgs e) {
            CancelScan.Cancel();
        }

        private void ManageBookmarksWindow_FormClosing(object sender, FormClosingEventArgs e) {
            if (IsScanning && !CancelScan.IsCancellationRequested) {
                CancelScan.Cancel();
                e.Cancel = true;
                NeedsClosing = true;
            }
        }
    }
}
