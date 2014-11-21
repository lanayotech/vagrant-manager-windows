namespace Lanayo.Vagrant_Manager.Windows {
    partial class ManageBookmarksWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageBookmarksWindow));
            this.BookmarksDataGridView = new System.Windows.Forms.DataGridView();
            this.Path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DisplayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProviderIdentifier = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.AddBookmarksButton = new System.Windows.Forms.Button();
            this.RemoveBookmarksButton = new System.Windows.Forms.Button();
            this.SaveBookmarksButton = new System.Windows.Forms.Button();
            this.CancelBookmarksButton = new System.Windows.Forms.Button();
            this.RecursiveScanCheckbox = new System.Windows.Forms.CheckBox();
            this.DisplayNameNoteLabel = new System.Windows.Forms.Label();
            this.DirectoryLabelTextField = new System.Windows.Forms.TextBox();
            this.CancelScanButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BookmarksDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // BookmarksDataGridView
            // 
            this.BookmarksDataGridView.AllowDrop = true;
            this.BookmarksDataGridView.AllowUserToAddRows = false;
            this.BookmarksDataGridView.AllowUserToDeleteRows = false;
            this.BookmarksDataGridView.AllowUserToResizeRows = false;
            this.BookmarksDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BookmarksDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.BookmarksDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BookmarksDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Path,
            this.DisplayName,
            this.ProviderIdentifier});
            this.BookmarksDataGridView.Location = new System.Drawing.Point(12, 61);
            this.BookmarksDataGridView.Name = "BookmarksDataGridView";
            this.BookmarksDataGridView.Size = new System.Drawing.Size(455, 277);
            this.BookmarksDataGridView.TabIndex = 0;
            this.BookmarksDataGridView.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.BookmarksDataGridView_CellMouseDown);
            this.BookmarksDataGridView.DragDrop += new System.Windows.Forms.DragEventHandler(this.BookmarksDataGridView_DragDrop);
            this.BookmarksDataGridView.DragOver += new System.Windows.Forms.DragEventHandler(this.BookmarksDataGridView_DragOver);
            this.BookmarksDataGridView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BookmarksDataGridView_MouseMove);
            // 
            // Path
            // 
            this.Path.DataPropertyName = "Path";
            this.Path.HeaderText = "Path";
            this.Path.Name = "Path";
            this.Path.ReadOnly = true;
            this.Path.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // DisplayName
            // 
            this.DisplayName.DataPropertyName = "DisplayName";
            this.DisplayName.HeaderText = "Display Name";
            this.DisplayName.Name = "DisplayName";
            this.DisplayName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // ProviderIdentifier
            // 
            this.ProviderIdentifier.DataPropertyName = "ProviderIdentifier";
            this.ProviderIdentifier.HeaderText = "Provider";
            this.ProviderIdentifier.Name = "ProviderIdentifier";
            this.ProviderIdentifier.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // AddBookmarksButton
            // 
            this.AddBookmarksButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddBookmarksButton.Location = new System.Drawing.Point(12, 344);
            this.AddBookmarksButton.Name = "AddBookmarksButton";
            this.AddBookmarksButton.Size = new System.Drawing.Size(30, 23);
            this.AddBookmarksButton.TabIndex = 1;
            this.AddBookmarksButton.Text = "+";
            this.AddBookmarksButton.UseVisualStyleBackColor = true;
            this.AddBookmarksButton.Click += new System.EventHandler(this.AddBookmarksButton_Click);
            // 
            // RemoveBookmarksButton
            // 
            this.RemoveBookmarksButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RemoveBookmarksButton.Location = new System.Drawing.Point(48, 344);
            this.RemoveBookmarksButton.Name = "RemoveBookmarksButton";
            this.RemoveBookmarksButton.Size = new System.Drawing.Size(30, 23);
            this.RemoveBookmarksButton.TabIndex = 2;
            this.RemoveBookmarksButton.Text = "-";
            this.RemoveBookmarksButton.UseVisualStyleBackColor = true;
            this.RemoveBookmarksButton.Click += new System.EventHandler(this.RemoveBookmarksButton_Click);
            // 
            // SaveBookmarksButton
            // 
            this.SaveBookmarksButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveBookmarksButton.Location = new System.Drawing.Point(391, 361);
            this.SaveBookmarksButton.Name = "SaveBookmarksButton";
            this.SaveBookmarksButton.Size = new System.Drawing.Size(75, 23);
            this.SaveBookmarksButton.TabIndex = 3;
            this.SaveBookmarksButton.Text = "Save";
            this.SaveBookmarksButton.UseVisualStyleBackColor = true;
            this.SaveBookmarksButton.Click += new System.EventHandler(this.SaveBookmarksButton_Click);
            // 
            // CancelBookmarksButton
            // 
            this.CancelBookmarksButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBookmarksButton.Location = new System.Drawing.Point(310, 361);
            this.CancelBookmarksButton.Name = "CancelBookmarksButton";
            this.CancelBookmarksButton.Size = new System.Drawing.Size(75, 23);
            this.CancelBookmarksButton.TabIndex = 4;
            this.CancelBookmarksButton.Text = "Cancel";
            this.CancelBookmarksButton.UseVisualStyleBackColor = true;
            this.CancelBookmarksButton.Click += new System.EventHandler(this.CancelBookmarksButton_Click);
            // 
            // RecursiveScanCheckbox
            // 
            this.RecursiveScanCheckbox.AutoSize = true;
            this.RecursiveScanCheckbox.Location = new System.Drawing.Point(13, 13);
            this.RecursiveScanCheckbox.Name = "RecursiveScanCheckbox";
            this.RecursiveScanCheckbox.Size = new System.Drawing.Size(220, 17);
            this.RecursiveScanCheckbox.TabIndex = 5;
            this.RecursiveScanCheckbox.Text = "Recursively scan directories when added";
            this.RecursiveScanCheckbox.UseVisualStyleBackColor = true;
            this.RecursiveScanCheckbox.CheckedChanged += new System.EventHandler(this.RecursiveScanCheckbox_CheckedChanged);
            // 
            // DisplayNameNoteLabel
            // 
            this.DisplayNameNoteLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DisplayNameNoteLabel.AutoSize = true;
            this.DisplayNameNoteLabel.Location = new System.Drawing.Point(13, 371);
            this.DisplayNameNoteLabel.Name = "DisplayNameNoteLabel";
            this.DisplayNameNoteLabel.Size = new System.Drawing.Size(151, 13);
            this.DisplayNameNoteLabel.TabIndex = 7;
            this.DisplayNameNoteLabel.Text = "Note: Display Name is editable";
            // 
            // DirectoryLabelTextField
            // 
            this.DirectoryLabelTextField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DirectoryLabelTextField.BackColor = System.Drawing.Color.Black;
            this.DirectoryLabelTextField.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DirectoryLabelTextField.ForeColor = System.Drawing.Color.Lime;
            this.DirectoryLabelTextField.Location = new System.Drawing.Point(13, 35);
            this.DirectoryLabelTextField.Name = "DirectoryLabelTextField";
            this.DirectoryLabelTextField.ReadOnly = true;
            this.DirectoryLabelTextField.Size = new System.Drawing.Size(454, 20);
            this.DirectoryLabelTextField.TabIndex = 8;
            // 
            // CancelScanButton
            // 
            this.CancelScanButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelScanButton.Location = new System.Drawing.Point(216, 361);
            this.CancelScanButton.Name = "CancelScanButton";
            this.CancelScanButton.Size = new System.Drawing.Size(88, 23);
            this.CancelScanButton.TabIndex = 9;
            this.CancelScanButton.Text = "Cancel Scan";
            this.CancelScanButton.UseVisualStyleBackColor = true;
            this.CancelScanButton.Visible = false;
            this.CancelScanButton.Click += new System.EventHandler(this.CancelScanButton_Click);
            // 
            // ManageBookmarksWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 396);
            this.Controls.Add(this.CancelScanButton);
            this.Controls.Add(this.DirectoryLabelTextField);
            this.Controls.Add(this.DisplayNameNoteLabel);
            this.Controls.Add(this.RecursiveScanCheckbox);
            this.Controls.Add(this.CancelBookmarksButton);
            this.Controls.Add(this.SaveBookmarksButton);
            this.Controls.Add(this.RemoveBookmarksButton);
            this.Controls.Add(this.AddBookmarksButton);
            this.Controls.Add(this.BookmarksDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(495, 435);
            this.Name = "ManageBookmarksWindow";
            this.Text = "Manage Bookmarks";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageBookmarksWindow_FormClosing);
            this.Load += new System.EventHandler(this.ManageBookmarksWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BookmarksDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView BookmarksDataGridView;
        private System.Windows.Forms.Button AddBookmarksButton;
        private System.Windows.Forms.Button RemoveBookmarksButton;
        private System.Windows.Forms.Button SaveBookmarksButton;
        private System.Windows.Forms.Button CancelBookmarksButton;
        private System.Windows.Forms.CheckBox RecursiveScanCheckbox;
        private System.Windows.Forms.Label DisplayNameNoteLabel;
        private System.Windows.Forms.TextBox DirectoryLabelTextField;
        private System.Windows.Forms.DataGridViewTextBoxColumn Path;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisplayName;
        private System.Windows.Forms.DataGridViewComboBoxColumn ProviderIdentifier;
        private System.Windows.Forms.Button CancelScanButton;
    }
}