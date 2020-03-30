using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace steamquery {
    public struct steamuser {
        public steamuser(string xml) {
            this.steamName = utils.getSteamName(xml);
            this.steamID64 = utils.getSteamID64(xml);
            this.privacy = utils.getPrivacy(xml);
            this.status = utils.getStatus(xml);
            this.gameName = utils.getGameName(xml);
            this.gameServerIP = utils.getGameServerIP(xml);
        }

        public steamuser(string steamName, string steamID64, string privacy, string status, string gameName, string gameServerIP) {
            this.steamName = steamName;
            this.steamID64 = steamID64;
            this.privacy = privacy;
            this.status = status;
            this.gameName = gameName;
            this.gameServerIP = gameServerIP;
        }

        public static steamuser empty => new steamuser("empty", "0", "", "", "", "");

        public override string ToString() {
            return this.steamName;
        }

        public static bool operator ==(steamuser a, steamuser b) {
            return a.steamID64 == b.steamID64;
        }

        public static bool operator !=(steamuser a, steamuser b) {
            return a.steamID64 != b.steamID64;
        }

        public string steamName;
        public string steamID64;
        public string privacy;
        public string status;
        public string gameName;
        public string gameServerIP;
    }
}
