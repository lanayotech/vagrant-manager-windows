using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanayo.Vagrant_Manager.Windows {
    public class ComboBoxItem {
        public string Text { get; set; }
        public int Value { get; set; }

        public override string ToString() {
            return Text;
        }
    }
}
