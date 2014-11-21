using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lanayo.Vagrant_Manager.Windows {
    public partial class TaskOutputWindow : Form {

        public string TaskCommand;
        public string TaskAction;
        public Process Task;
        public object Target;

        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams {
            get {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        public TaskOutputWindow() {
            InitializeComponent();
        }

        private void TaskOutputWindow_Load(object sender, EventArgs e) {
            TaskCommandTextBox.Text = TaskCommand;
            Text = TaskAction;
            ActiveControl = OutputTextBox;

            Task.EnableRaisingEvents = true;

            Task.OutputDataReceived += Task_OutputDataRecieved;
            Task.ErrorDataReceived += Task_ErrorDataReceived;
            Task.Exited += Task_Exited;

            Task.Start();
            Task.BeginOutputReadLine();
            Task.BeginErrorReadLine();
        }

        void Task_ErrorDataReceived(object sender, DataReceivedEventArgs args) {
            if (!this.IsDisposed) {
                this.Invoke(new MethodInvoker(delegate {
                    if (!String.IsNullOrEmpty(args.Data)) {
                        OutputTextBox.AppendText(args.Data + Environment.NewLine);
                        OutputTextBox.ScrollToCaret();
                    }
                }));
            }
        }

        public void Task_OutputDataRecieved(object sender, DataReceivedEventArgs args) {
            if (!this.IsDisposed) {
                this.Invoke(new MethodInvoker(delegate {
                    if (!String.IsNullOrEmpty(args.Data)) {
                        OutputTextBox.AppendText(args.Data + Environment.NewLine);
                        OutputTextBox.ScrollToCaret();
                    }
                }));
            }
        }

        public void Task_Exited(object sender, EventArgs args) {
            this.Invoke(new MethodInvoker(delegate {
                if (Task.ExitCode != 0) {
                    TaskStatusLabel.Text = "Completed with errors";
                } else {
                    TaskStatusLabel.Text = "Completed Successfully";
                }

                Dictionary<string, object> userInfo = new Dictionary<string, object>();
                userInfo["target"] = Target;
                NotificationCenter.Instance.PostNotification("vagrant-manager.task-completed", new Notification(null, userInfo));

                CancelTaskButton.Enabled = false;
                TaskProgressBar.Style = ProgressBarStyle.Continuous;
                CloseWindowButton.Enabled = true;

                if (Properties.Settings.Default.AutoCloseTaskWindows) {
                    this.Close();
                }
            }));
        }

        private void CloseWindowButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void CancelTaskButton_Click(object sender, EventArgs e) {
            //TODO: implement this
        }
    }
}
