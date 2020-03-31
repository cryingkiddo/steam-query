using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace steamquery {
    public partial class direct : Form {
        public static bool isOpened;

        public direct() {
            InitializeComponent();
        }

        private void onSendButtonClicked(object sender, EventArgs e) {
            if (query.instances.Contains("1337")) return;
            if (String.IsNullOrEmpty(textbox_ip.Text) || 
                String.IsNullOrWhiteSpace(textbox_ip.Text) || 
                String.IsNullOrEmpty(textbox_port.Text) || 
                String.IsNullOrWhiteSpace(textbox_port.Text)) return;
            query q = new query();
            IPAddress addr;
            if (IPAddress.TryParse(textbox_ip.Text, out addr)) {
                var ipendpoint = new IPEndPoint(addr, Convert.ToInt32(textbox_port.Text));
                q.Open(ipendpoint, "1337", "Direct");
                this.Close();
            }
            else {
                MessageBox.Show("Incorrect Address", "Steam Query - Direct Connect - Error", MessageBoxButtons.OK);
            }
        }

        private void onLoad(object sender, EventArgs e) {
            isOpened = true;
        }

        private void onClose(object sender, FormClosedEventArgs e) {
            isOpened = false;
        }
    }
}
