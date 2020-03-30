using steamquery.web;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace steamquery {
    public partial class main : Form {
        public static Form form;
        public static ListBox users;
        public static string ip = string.Empty;
        public static string id = string.Empty;
        public static string name = string.Empty;
        private Point label_steamid64_storedLocation;
        private Point label_steamid64_out_storedLocation;
        private Point label_privacy_storedLocation;
        private Point label_privacy_out_storedLocation;
        private Point label_status_storedLocation;
        private Point label_status_out_storedLocation;
        private Point label_gamename_storedLocation;
        private Point label_gamename_out_storedLocation;
        private Point label_gameserverip_storedLocation;
        private Point label_gameserverip_out_storedLocation;
        private Point button_queryinfo_storedLocation;
        private Color label_gameserverip_out_storedColor;

        public main() {
            InitializeComponent();
            form = this;
            users = this.listbox_users;
        }

        private void onLoad(object sender, EventArgs e) {
            label_steamname.Visible = false;
            label_steamname_out.Visible = false;
            label_steamid64.Visible = false;
            label_steamid64_out.Visible = false;
            label_privacy.Visible = false;
            label_privacy_out.Visible = false;
            label_status.Visible = false;
            label_status_out.Visible = false;
            label_gamename.Visible = false;
            label_gamename_out.Visible = false;
            label_gameserverip.Visible = false;
            label_gameserverip_out.Visible = false;
            button_refresh.Visible = false;
            button_queryinfo.Visible = false;
            label_steamid64_storedLocation = this.label_steamid64.Location;
            label_steamid64_out_storedLocation = label_steamid64_out.Location;
            label_privacy_storedLocation = label_privacy.Location;
            label_privacy_out_storedLocation = label_privacy_out.Location;
            label_status_storedLocation = label_status.Location;
            label_status_out_storedLocation = label_status_out.Location;
            label_gamename_storedLocation = label_gamename.Location;
            label_gamename_out_storedLocation = label_gamename_out.Location;
            label_gameserverip_storedLocation = label_gameserverip.Location;
            label_gameserverip_out_storedLocation = label_gameserverip_out.Location;
            button_queryinfo_storedLocation = button_queryinfo.Location;
            label_gameserverip_out_storedColor = label_gameserverip_out.ForeColor;
        }

        private void onAddButtonClick(object sender, EventArgs e) {
            if (adduser.isOpened) return;
            var adduserform = new adduser();
            adduserform.Show();
        }

        private void onRemoveButtonClick(object sender, EventArgs e) {
            if (listbox_users.SelectedIndex == -1) return;
            listbox_users.Items.RemoveAt(listbox_users.SelectedIndex);
            if (listbox_users.Items.Count > 0) listbox_users.SelectedIndex = listbox_users.Items.Count - 1;
            else listbox_users.SelectedIndex = -1;
        }

        private void onSaveButtonClick(object sender, EventArgs e) {
            if (listbox_users.Items.Count <= 0) return;
            string content = string.Empty;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "owo?(*.owo)|*.owo";
            if (sfd.ShowDialog() == DialogResult.Cancel) return;
            foreach (steamuser user in listbox_users.Items)
                content += user.steamID64 + "\n";
            File.WriteAllText(sfd.FileName, content);
        }

        private void onLoadButtonClick(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "uwu?(*.owo)|*.owo";
            if (ofd.ShowDialog() == DialogResult.Cancel) return;
            string[] content = File.ReadAllText(ofd.FileName).Split('\n');
            foreach (string steamid in content) {
                if (String.IsNullOrEmpty(steamid) || String.IsNullOrWhiteSpace(steamid)) continue;
                string s = steamid.Replace("\n", string.Empty);
                bool skip = false;
                foreach (steamuser user in listbox_users.Items) 
                    if (s == user.steamID64) skip = true;
                if (!skip) {
                    using (GET get = new GET(utils.parseLink(s), Encoding.Default)) {
                        if (utils.isInvalidUser(get.response)) {
                            MessageBox.Show("User is invalid", "Steam Query - Add User - Error", MessageBoxButtons.OK);
                            return;
                        }
                        listbox_users.Items.Add(new steamuser(get.response));
                    }
                }
                s = null;
            }
        }

        private void onRefreshButtonClick(object sender, EventArgs e) {
            var index = listbox_users.SelectedIndex;
            string steamid = ((steamuser)listbox_users.SelectedItem).steamID64;
            listbox_users.Items.RemoveAt(listbox_users.SelectedIndex);
            listbox_users.SelectedIndex = -1;
            using (GET get = new GET(utils.parseLink(steamid), Encoding.Default)) {
                if (utils.isInvalidUser(get.response)) {
                    MessageBox.Show("User is invalid", "Steam Query - Add User - Error", MessageBoxButtons.OK);
                    return;
                }
                listbox_users.Items.Insert(index, new steamuser(get.response));
            }
            listbox_users.SelectedIndex = index;
            steamid = null;
        }

        private void onQueryInfoButtonClick(object sender, EventArgs e) {
            if (listbox_users.SelectedIndex == -1) return;
            if (query.instances.Contains(id)) return;
            query q = new query();
            q.Show();
        }

        private void onUsersListBoxSelectedIndexChanged(object sender, EventArgs e) {
            Console.WriteLine("updated");
            if (listbox_users.SelectedIndex == -1 || listbox_users.SelectedIndex > listbox_users.Items.Count - 1) {
                label_steamname.Visible = false;
                label_steamname_out.Visible = false;
                label_steamname_out2.Visible = false;
                label_steamid64.Visible = false;
                label_steamid64_out.Visible = false;
                label_privacy.Visible = false;
                label_privacy_out.Visible = false;
                label_status.Visible = false;
                label_status_out.Visible = false;
                label_gamename.Visible = false;
                label_gamename_out.Visible = false;
                label_gamename_out2.Visible = false;
                label_gameserverip.Visible = false;
                label_gameserverip_out.Visible = false;
                button_refresh.Visible = false;
                ip = string.Empty;
                id = string.Empty;
                name = string.Empty;
                return;
            }
            if (((steamuser)listbox_users.SelectedItem).steamID64 == "0") {
                label_steamname.Visible = false;
                label_steamname_out.Visible = false;
                label_steamid64.Visible = false;
                label_steamid64_out.Visible = false;
                label_privacy.Visible = false;
                label_privacy_out.Visible = false;
                label_status.Visible = false;
                label_status_out.Visible = false;
                label_gamename.Visible = false;
                label_gamename_out.Visible = false;
                label_gameserverip.Visible = false;
                label_gameserverip_out.Visible = false;
                button_refresh.Visible = false;
                ip = string.Empty;
                id = string.Empty;
                name = string.Empty;
                return;
            }
            button_refresh.Visible = true;
            label_steamname.Visible = true;
            label_steamname_out.Visible = true;
            label_steamname_out.Text = ((steamuser)listbox_users.SelectedItem).steamName;
            name = ((steamuser)listbox_users.SelectedItem).steamName;
            label_steamname_out2.Visible = false;
            if (label_steamname_out.Location.X + label_steamname_out.Width > this.Width) {
                char[] str1 = new char[16];
                for (int i = 0; i < 16; i++)
                    str1[i] = label_steamname_out.Text[i];
                label_steamname_out2.Visible = true;
                label_steamname_out2.Text = label_steamname_out.Text.Substring(16, 16);
                label_steamname_out.Text = new string(str1);
                str1 = null;
                label_steamid64.Location = new Point(label_steamid64.Location.X, label_steamid64_storedLocation.Y + 16);
                label_steamid64_out.Location = new Point(label_steamid64_out.Location.X, label_steamid64_out_storedLocation.Y + 16);
                label_privacy.Location = new Point(label_privacy.Location.X, label_privacy_storedLocation.Y + 16);
                label_privacy_out.Location = new Point(label_privacy_out.Location.X, label_privacy_out_storedLocation.Y + 16);
                label_status.Location = new Point(label_status.Location.X, label_status_storedLocation.Y + 16);
                label_status_out.Location = new Point(label_status_out.Location.X, label_status_out_storedLocation.Y + 16);
                label_gamename.Location = new Point(label_gamename.Location.X, label_gamename_storedLocation.Y + 16);
                label_gamename_out.Location = new Point(label_gamename_out.Location.X, label_gamename_out_storedLocation.Y + 16);
                label_gameserverip.Location = new Point(label_gameserverip.Location.X, label_gameserverip_storedLocation.Y + 16);
                label_gameserverip_out.Location = new Point(label_gameserverip_out.Location.X, label_gameserverip_out_storedLocation.Y + 16);
                button_queryinfo.Location = new Point(button_queryinfo.Location.X, button_queryinfo_storedLocation.Y + 38);
            }
            else {
                label_steamname_out2.Visible = false;
                label_steamid64.Location = label_steamid64_storedLocation;
                label_steamid64_out.Location = label_steamid64_out_storedLocation;
                label_privacy.Location = label_privacy_storedLocation;
                label_privacy_out.Location = label_privacy_out_storedLocation;
                label_status.Location = label_status_storedLocation;
                label_status_out.Location = label_status_out_storedLocation;
                label_gamename.Location = label_gamename_storedLocation;
                label_gamename_out.Location = label_gamename_out_storedLocation;
                label_gameserverip.Location = label_gameserverip_storedLocation;
                label_gameserverip_out.Location = label_gameserverip_out_storedLocation;
                button_queryinfo.Location = button_queryinfo_storedLocation;
            }
            label_steamid64.Visible = true;
            label_steamid64_out.Visible = true;
            label_steamid64_out.Text = ((steamuser)listbox_users.SelectedItem).steamID64;
            id = ((steamuser)listbox_users.SelectedItem).steamID64;
            label_privacy.Visible = true;
            label_privacy_out.Visible = true;
            label_privacy_out.Text = ((steamuser)listbox_users.SelectedItem).privacy;
            if (utils.isPrivate((steamuser)listbox_users.SelectedItem)) { 
                label_privacy_out.ForeColor = Color.FromArgb(200, 10, 10);
                label_status.Visible = false;
                label_status_out.Visible = false;
                label_gamename.Visible = false;
                label_gamename_out.Visible = false;
                label_gameserverip.Visible = false;
                label_gameserverip_out.Visible = false;
                return;
            }
            else label_privacy_out.ForeColor = Color.FromArgb(10, 200, 10);
            label_status.Visible = true;
            label_status_out.Visible = true;
            label_status_out.Text = ((steamuser)listbox_users.SelectedItem).status;
            if (utils.isInGame((steamuser)listbox_users.SelectedItem)) label_status_out.ForeColor = Color.FromArgb(10, 200, 10);
            else if (((steamuser)listbox_users.SelectedItem).status == "online") {
                label_status_out.ForeColor = Color.FromArgb(50, 50, 200);
                label_gamename.Visible = false;
                label_gamename_out.Visible = false;
                label_gameserverip.Visible = false;
                label_gameserverip_out.Visible = false;
                return;
            }
            else {
                label_status_out.ForeColor = Color.FromArgb(200, 10, 10);
                label_gamename.Visible = false;
                label_gamename_out.Visible = false;
                label_gameserverip.Visible = false;
                label_gameserverip_out.Visible = false;
                return;
            }
            label_gamename.Visible = true;
            label_gamename_out.Visible = true;
            label_gamename_out.Text = ((steamuser)listbox_users.SelectedItem).gameName;
            label_gamename_out2.Visible = false;
            // yeah, i know, i know, if steam name will be >16 chars and game name will be >16 chars, than ui will be bugged.
            // i mean, LOOK AT ALL OF THIS SHITIY CODE, AND ONLY THING THAT U LOOKING AT IS THAT LITTLE BUG???
            if (label_gamename_out.Location.X + label_gamename_out.Width > this.Width) {
                char[] str1 = new char[16];
                for (int i = 0; i < 16; i++)
                    str1[i] = label_gamename_out.Text[i];
                label_gamename_out2.Visible = true;
                label_gamename_out2.Text = label_gamename_out.Text.Substring(16, 16);
                label_gamename_out.Text = new string(str1);
                str1 = null;
                label_gameserverip.Location = new Point(label_gameserverip.Location.X, label_gameserverip_storedLocation.Y + 16);
                label_gameserverip_out.Location = new Point(label_gameserverip_out.Location.X, label_gameserverip_out_storedLocation.Y + 16);
                button_queryinfo.Location = new Point(button_queryinfo.Location.X, button_queryinfo_storedLocation.Y + 38);
            }
            else {
                label_gamename_out2.Visible = false;
                label_gameserverip.Location = label_gameserverip_storedLocation;
                label_gameserverip_out.Location = label_gameserverip_out_storedLocation;
                button_queryinfo.Location = button_queryinfo_storedLocation;
            }
            label_gameserverip.Visible = true;
            label_gameserverip_out.Visible = true;
            if (((steamuser)listbox_users.SelectedItem).gameServerIP == string.Empty) {
                label_gameserverip_out.Text = "Unable to get IP";
                label_gameserverip_out.ForeColor = Color.FromArgb(200, 10, 10);
                ip = string.Empty;
                button_queryinfo.Visible = false;
            }
            else {
                label_gameserverip_out.Text = ((steamuser)listbox_users.SelectedItem).gameServerIP;
                label_gameserverip_out.ForeColor = label_gameserverip_out_storedColor;
                ip = ((steamuser)listbox_users.SelectedItem).gameServerIP;
                button_queryinfo.Visible = true;
            }
        }

        private void onLabelSteamID64Click(object sender, EventArgs e) {
            Clipboard.SetText(label_steamid64_out.Text);
        }

        private void onLabelGameServerIPClick(object sender, EventArgs e) {
            if (label_gameserverip_out.Text[2] == 'a') return;
            Clipboard.SetText(label_gameserverip_out.Text);
        }
    }
}
