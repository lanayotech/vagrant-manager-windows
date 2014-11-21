using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;

namespace Lanayo.Vagrant_Manager {
    public static class Util {
        public static string EscapeShellArg(string arg) {
            return "\"" + Regex.Replace(arg, @"(\\+)$", @"$1$1") + "\"";
        }

        public static string TrimWhitespaceAndNewlines(string str) {
            return str.Trim(Environment.NewLine.ToCharArray().Concat(new char[] { ' ' }).ToArray());
        }

        public static ToolStripMenuItem MakeBlankToolstripMenuItem(string Name, EventHandler onClick) {
            ToolStripMenuItem menuItem = new ToolStripMenuItem(Name);
            menuItem.Click += onClick;
            return menuItem;
        }

        public static Uri AddQuery(this Uri uri, string name, string value) {
            var ub = new UriBuilder(uri);

            // decodes urlencoded pairs from uri.Query to HttpValueCollection
            var httpValueCollection = HttpUtility.ParseQueryString(uri.Query);
            httpValueCollection.Add(name, value);

            // this code block is taken from httpValueCollection.ToString() method
            // and modified so it encodes strings with HttpUtility.UrlEncode
            if (httpValueCollection.Count == 0)
                ub.Query = String.Empty;
            else {
                var sb = new StringBuilder();

                for (int i = 0; i < httpValueCollection.Count; i++) {
                    string text = httpValueCollection.GetKey(i);
                    {
                        text = HttpUtility.UrlEncode(text);

                        string val = (text != null) ? (text + "=") : string.Empty;
                        string[] vals = httpValueCollection.GetValues(i);

                        if (sb.Length > 0)
                            sb.Append('&');

                        if (vals == null || vals.Length == 0)
                            sb.Append(val);
                        else {
                            if (vals.Length == 1) {
                                sb.Append(val);
                                sb.Append(HttpUtility.UrlEncode(vals[0]));
                            } else {
                                for (int j = 0; j < vals.Length; j++) {
                                    if (j > 0)
                                        sb.Append('&');

                                    sb.Append(val);
                                    sb.Append(HttpUtility.UrlEncode(vals[j]));
                                }
                            }
                        }
                    }
                }

                ub.Query = sb.ToString();
            }

            return ub.Uri;
        }
    }
}
