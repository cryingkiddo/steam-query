using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using steamquery.web;

namespace steamquery {
    public partial class adduser : Form {
        public static Form form;
        public static bool isOpened;

        public adduser() {
            InitializeComponent();
            form = this;
        }

        private void onOkButtonClick(object sender, EventArgs e) {
            using (GET get = new GET(utils.parseLink(this.textbox_accountlink.Text), Encoding.Default)) {
                if (utils.isInvalidUser(get.response)) {
                    MessageBox.Show("User is invalid", "Steam Query - Add User - Error", MessageBoxButtons.OK);
                    closeform();
                    return;
                }
                var user = new steamuser(get.response);
                if (!main.users.Items.Contains(user)) {
                    main.users.Items.Add(user);
                    closeform();
                }
                else {
                    MessageBox.Show("User already added", "Steam Query - Add User - Error", MessageBoxButtons.OK);
                    return;
                }
            }
        }

        private void closeform() {
            textbox_accountlink.Text = string.Empty;
            this.Close();
        }

        private void onLoad(object sender, EventArgs e) {
            isOpened = true;
        }

        private void onClose(object sender, FormClosedEventArgs e) {
            isOpened = false;
        }
    }
}
