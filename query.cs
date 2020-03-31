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

        public void Open(IPEndPoint ip, string id, string name) {
            this.ip = ip;
            this.id = id;
            this.name = name;
            this.Show();
        }
        
        private void onLoad(object sender, EventArgs e) {
            this.Text = "Steam Query - Server Query - " + name;
            label_duration.Visible = false;
            label_duration_out.Visible = false;
            label_score.Visible = false;
            label_score_out.Visible = false;
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
            bool isInfoFailed = false, isPlayerFailed = false;
            
            if (!DoA2S_INFO(ip)) isInfoFailed = true;
            else isInfoFailed = false;

            if (!DoA2S_PLAYER(ip)) isPlayerFailed = true;
            else isPlayerFailed = false;

            if (isInfoFailed && isPlayerFailed) ip.Port = ip.Port + 1;
            else return;

            if (!DoA2S_INFO(ip)) isInfoFailed = true;
            else isInfoFailed = false;

            if (!DoA2S_PLAYER(ip)) isPlayerFailed = true;
            else isPlayerFailed = false;

            if (isInfoFailed && isPlayerFailed) ip.Port = 27016;
            else return;

            if (!DoA2S_INFO(ip)) {
                MessageBox.Show("Unable to get server query: A2S_INFO, Timeout", this.Text + " - Error", MessageBoxButtons.OK);
                isInfoFailed = true;
            }
            else isInfoFailed = false;

            if (!DoA2S_PLAYER(ip)) {
                MessageBox.Show("Unable to get server query: A2S_PLAYER, Timeout", this.Text + " - Error", MessageBoxButtons.OK);
                isPlayerFailed = true;
            }
            else isPlayerFailed = false;

            if (isInfoFailed && isPlayerFailed) {
                MessageBox.Show("Unable to get server query for this server", this.Text + " - Error", MessageBoxButtons.OK);
                this.Close();
            }
            else return;
        }

        private bool DoA2S_INFO(IPEndPoint ip) {
            Console.WriteLine($"sending A2S_INFO request to {ip.Address}:{ip.Port}");
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
                return true;
            }
            catch (SocketException ex) {
                return false;
            }
        }

        private bool DoA2S_PLAYER(IPEndPoint ip) {
            Console.WriteLine($"sending A2S_PLAYER request to {ip.Address}:{ip.Port}");
            try {
                A2S_PLAYER player = new A2S_PLAYER(ip);
                for (int i = 0; i < player.Players.Length; i++) {
                    listbox_players.Items.Add(player.Players[i]);
                }
                return true;
            }
            catch (SocketException ex) {
                return false;
            }
        }

        private void onClose(object sender, FormClosedEventArgs e) {
            instances.Remove(id);
        }
    }
}
