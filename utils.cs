using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace steamquery {
    public class utils {
        public static string parseLink(string link) {
            if (link[link.Length - 1] == '/') link = link.Remove(link.Length - 1, 1);
            if (link[0] == '[' || link[0] == '7') return "https://steamcommunity.com/profiles/" + link + "?xml=1";
            else if (link.StartsWith("http"))
                if (link[4] != 's') return link.Insert(4, "s") + "?xml=1";
                else return link + "?xml=1";
            else if (link.StartsWith("steamcommunity.")) return "https://" + link + "?xml=1";
            else return "https://steamcommunity.com/id/" + link + "?xml=1";
        }

        public static bool isInvalidUser(string xml) {
            return xml.Contains("The specified profile could not be found.") || xml.Contains("<error>");
        }
        
        public static string getStatus(string xml) {
            var splitted = xml.Split('\n');
            int i = 0;
            while (!splitted[i].Contains("<onlineState>")) {
                if (i >= splitted.Length) return string.Empty;
                i++;
            }
            if (splitted[i].Contains(">in-game<")) return "in-game";
            else if (splitted[i].Contains(">online<")) return "online";
            else return "offline";
        }

        public static bool isInGame(string xml) {
            return getStatus(xml) == "in-game";
        }

        public static bool isOnline(string xml) {
            return getStatus(xml) == "online";
        }

        public static bool isInGame(steamuser user) {
            return user.status == "in-game";
        }

        public static bool isOnline(steamuser user) {
            return user.status == "online";
        }

        public static string getPrivacy(string xml) {
            var splitted = xml.Split('\n');
            int i = 0;
            while (!splitted[i].Contains("<privacyState>")) {
                if (i >= splitted.Length) return string.Empty;
                i++;
            }
            if (splitted[i].Contains(">public<")) return "public";
            else return "private";
        }

        public static bool isPrivate(string xml) {
            return getPrivacy(xml) == "private";
        }

        public static bool isPrivate(steamuser user) {
            return user.privacy == "private";
        }

        public static string getSteamID64(string xml) {
            var splitted = xml.Split('\n');
            int i = 0;
            while (!splitted[i].Contains("<steamID64>")) {
                if (i >= splitted.Length) return string.Empty;
                i++;
            }
            return new string(splitted[i].ToCharArray().Where(c => !Char.IsWhiteSpace(c)).ToArray()).Replace("<steamID64>", string.Empty).Replace("</steamID64>", string.Empty);
        }

        public static string getSteamName(string xml) {
            var splitted = xml.Split('\n');
            int i = 0;
            while (!splitted[i].Contains("<steamID>")) {
                if (i >= splitted.Length) return string.Empty;
                i++;
            }
            return new string(splitted[i].ToCharArray().Where(c => !Char.IsWhiteSpace(c)).ToArray()).Replace("<steamID><![CDATA[", string.Empty).Replace("]]></steamID>", string.Empty);
        }

        public static string getGameName(string xml) {
            if (isPrivate(xml) || !isInGame(xml)) return string.Empty;
            var splitted = xml.Split('\n');
            int i = 0;
            while (!splitted[i].Contains("<gameName>")) {
                if (i >= splitted.Length) return string.Empty;
                i++;
            }
            return new string(splitted[i].ToCharArray().Where(c => !Char.IsWhiteSpace(c)).ToArray()).Replace("<gameName><![CDATA[", string.Empty).Replace("]]></gameName>", string.Empty);
        }

        public static string getGameServerIP(string xml) {
            if (isPrivate(xml) || !isInGame(xml)) return string.Empty;
            var splitted = xml.Split('\n');
            int i = 0;
            while (!splitted[i].Contains("<inGameServerIP>")) {
                if (i >= splitted.Length) return string.Empty;
                i++;
            }
            return new string(splitted[i].ToCharArray().Where(c => !Char.IsWhiteSpace(c)).ToArray()).Replace("<inGameServerIP>", string.Empty).Replace("</inGameServerIP>", string.Empty);
        }

        public static string ReadNullTerminatedString(ref BinaryReader input) {
            StringBuilder sb = new StringBuilder();
            char read;
            try {
                read = input.ReadChar();
            }
            catch {
                read = '\x20';
            }
            while (read != '\x00') {
                try {
                    sb.Append(read);
                    read = input.ReadChar();
                }
                catch {
                    sb.Append(read);
                    read = '\x20';
                }
            }
            return sb.ToString();
        }
    }
}
