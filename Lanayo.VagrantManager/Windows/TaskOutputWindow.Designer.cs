namespace Lanayo.Vagrant_Manager.Windows {
    partial class TaskOutputWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskOutputWindow));
            this.TaskStatusLabel = new System.Windows.Forms.Label();
            this.TaskProgressBar = new System.Windows.Forms.ProgressBar();
            this.TaskCommandTextBox = new System.Windows.Forms.TextBox();
            this.CloseWindowButton = new System.Windows.Forms.Button();
            this.CancelTaskButton = new System.Windows.Forms.Button();
            this.OutputTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TaskStatusLabel
            // 
            this.TaskStatusLabel.AutoSize = true;
            this.TaskStatusLabel.Location = new System.Drawing.Point(13, 13);
            this.TaskStatusLabel.Name = "TaskStatusLabel";
            this.TaskStatusLabel.Size = new System.Drawing.Size(83, 13);
            this.TaskStatusLabel.TabIndex = 0;
            this.TaskStatusLabel.Text = "Running Task...";
            // 
            // TaskProgressBar
            // 
            this.TaskProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TaskProgressBar.Location = new System.Drawing.Point(16, 30);
            this.TaskProgressBar.MarqueeAnimationSpeed = 10;
            this.TaskProgressBar.Name = "TaskProgressBar";
            this.TaskProgressBar.Size = new System.Drawing.Size(365, 23);
            this.TaskProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.TaskProgressBar.TabIndex = 1;
            // 
            // TaskCommandTextBox
            // 
            this.TaskCommandTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TaskCommandTextBox.BackColor = System.Drawing.Color.Black;
            this.TaskCommandTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaskCommandTextBox.ForeColor = System.Drawing.Color.Lime;
            this.TaskCommandTextBox.Location = new System.Drawing.Point(16, 60);
            this.TaskCommandTextBox.Name = "TaskCommandTextBox";
            this.TaskCommandTextBox.ReadOnly = true;
            this.TaskCommandTextBox.Size = new System.Drawing.Size(365, 20);
            this.TaskCommandTextBox.TabIndex = 2;
            this.TaskCommandTextBox.Text = "Task Command";
            // 
            // CloseWindowButton
            // 
            this.CloseWindowButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseWindowButton.Enabled = false;
            this.CloseWindowButton.Location = new System.Drawing.Point(260, 288);
            this.CloseWindowButton.Name = "CloseWindowButton";
            this.CloseWindowButton.Size = new System.Drawing.Size(120, 23);
            this.CloseWindowButton.TabIndex = 4;
            this.CloseWindowButton.Text = "Close Window";
            this.CloseWindowButton.UseVisualStyleBackColor = true;
            this.CloseWindowButton.Click += new System.EventHandler(this.CloseWindowButton_Click);
            // 
            // CancelTaskButton
            // 
            this.CancelTaskButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelTaskButton.Location = new System.Drawing.Point(179, 288);
            this.CancelTaskButton.Name = "CancelTaskButton";
            this.CancelTaskButton.Size = new System.Drawing.Size(75, 23);
            this.CancelTaskButton.TabIndex = 5;
            this.CancelTaskButton.Text = "Cancel";
            this.CancelTaskButton.UseVisualStyleBackColor = true;
            this.CancelTaskButton.Visible = false;
            this.CancelTaskButton.Click += new System.EventHandler(this.CancelTaskButton_Click);
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputTextBox.BackColor = System.Drawing.Color.White;
            this.OutputTextBox.Location = new System.Drawing.Point(16, 87);
            this.OutputTextBox.Multiline = true;
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.ReadOnly = true;
            this.OutputTextBox.Size = new System.Drawing.Size(364, 195);
            this.OutputTextBox.TabIndex = 6;
            // 
            // TaskOutputWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 323);
            this.Controls.Add(this.OutputTextBox);
            this.Controls.Add(this.CancelTaskButton);
            this.Controls.Add(this.CloseWindowButton);
            this.Controls.Add(this.TaskCommandTextBox);
            this.Controls.Add(this.TaskProgressBar);
            this.Controls.Add(this.TaskStatusLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(409, 362);
            this.Name = "TaskOutputWindow";
            this.Text = "Task";
            this.Load += new System.EventHandler(this.TaskOutputWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TaskStatusLabel;
        private System.Windows.Forms.ProgressBar TaskProgressBar;
        private System.Windows.Forms.TextBox TaskCommandTextBox;
        private System.Windows.Forms.Button CloseWindowButton;
        private System.Windows.Forms.Button CancelTaskButton;
        private System.Windows.Forms.TextBox OutputTextBox;
    }
}