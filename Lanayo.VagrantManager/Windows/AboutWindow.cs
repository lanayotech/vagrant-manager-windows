using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lanayo.Vagrant_Manager.Windows {
    public partial class AboutWindow : Form {
        public AboutWindow() {
            InitializeComponent();
        }

        private void AboutWindow_Load(object sender, EventArgs e) {
            string str = "<div style=\"text-align:center;font-family:Arial;font-size:13px;\">Copyright &copy;{YEAR} Lanayo Tech<br><br>Vagrant Manager {VERSION}<br><br>For more information visit:<br><a href=\"{URL}\">{URL}</a><br><br>or check us out on GitHub:<br><a href=\"{GITHUB_URL}\">{GITHUB_URL}</a></div>"
                .Replace("{YEAR}", DateTime.Now.Year.ToString())
                .Replace("{VERSION}", Application.ProductVersion)
                .Replace("{URL}", Properties.Settings.Default.AboutUrl)
                .Replace("{GITHUB_URL}", Properties.Settings.Default.GithubUrl)
                .Replace("\n", "<br>");

            WebBrowser.DocumentText = str;
            WebBrowser.Navigating += WebBrowser_Navigating;
        }

        void WebBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e) {
            Process.Start(e.Url.AbsoluteUri);
            e.Cancel = true;
        }
    }
}
