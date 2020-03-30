using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace steamquery {
    public partial class query : Form {
        private IPEndPoint ip;
        private string id;
        private string name;

        public static List<string> instances = new List<string>();

        public query() {
            InitializeComponent();
        }

        private void onLoad(object sender, EventArgs e) {
            name = main.name;
            this.Text = "Steam Query - Server Query - " + name;
            label_duration.Visible = false;
            label_duration_out.Visible = false;
            label_score.Visible = false;
            label_score_out.Visible = false;
            ip = new IPEndPoint(IPAddress.Parse(main.ip.Split(':')[0]), Convert.ToInt32(main.ip.Split(':')[1]));
            id = main.id;
            instances.Add(id);
            DoA2S(ip);
        }

        private void onRefreshButtonClick(object sender, EventArgs e) {
            textbox_serverinfo.Text = string.Empty;
            listbox_players.SelectedIndex = -1;
            listbox_players.Items.Clear();
            DoA2S(ip);
        }

        private void onPlayersListBoxSelectedIndexChanged(object sender, EventArgs e) {
            if (listbox_players.SelectedIndex == -1 || listbox_players.SelectedIndex > listbox_players.Items.Count - 1) {
                label_duration.Visible = false;
                label_duration_out.Visible = false;
                label_score.Visible = false;
                label_score_out.Visible = false;
                return;
            }

            label_duration.Visible = true;
            label_duration_out.Visible = true;
            label_duration_out.Text = ((A2S_PLAYER.Player)listbox_players.SelectedItem).Duration.ToString();
            label_score.Visible = true;
            label_score_out.Visible = true;
            label_score_out.Text = ((A2S_PLAYER.Player)listbox_players.SelectedItem).Score.ToString();
        }

        private void DoA2S(IPEndPoint ip) {
            try {
                A2S_INFO info = new A2S_INFO(ip);
                textbox_serverinfo.Text = $"Header: {info.Header} \r\n" +
                    $"Protocol: {info.Protocol} \r\n" +
                    $"Name: {info.Name} \r\n" +
                    $"Map: {info.Map} \r\n" +
                    $"Folder: {info.Folder} \r\n" +
                    $"Game: {info.Game} \r\n" +
                    $"ID: {info.ID} \r\n" +
                    $"Players: {info.Players} \r\n" +
                    $"Max Players: {info.MaxPlayers} \r\n" +
                    $"Bots: {info.Bots} \r\n" +
                    $"Server Type: {info.ServerType.ToString()} \r\n" +
                    $"Environment Flags: {info.Environment.ToString()} \r\n" +
                    $"VAC Flags: {info.VAC.ToString()} \r\n" +
                    $"Version: {info.Version} \r\n" +
                    $"Extra Data Flags: {info.ExtraDataFlag.ToString()} \r\n" +
                    $"Game ID: {info.GameID} \r\n" +
                    $"Steam ID: {info.SteamID} \r\n" +
                    $"Keywords: {info.Keywords} \r\n" +
                    $"Spectator: {info.Spectator} \r\n" +
                    $"Spectator Port: {info.SpectatorPort} \r\n" +
                    $"Port: {info.Port} \r\n";
            }
            catch (SocketException ex) {
                MessageBox.Show("Unable to get server query: A2S_INFO, Timeout", this.Text + " - Error", MessageBoxButtons.OK);
                this.Close();
                return;
            }

            try {
                A2S_PLAYER player = new A2S_PLAYER(ip);
                for (int i = 0; i < player.Players.Length; i++) {
                    listbox_players.Items.Add(player.Players[i]);
                }
            }
            catch (SocketException ex) {
                MessageBox.Show("Unable to get server query: A2S_PLAYER, Timeout", this.Text + " - Error", MessageBoxButtons.OK);
                this.Close();
                return;
            }
        }

        private void onClose(object sender, FormClosedEventArgs e) {
            instances.Remove(id);
        }
    }
}
