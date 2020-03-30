using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;

namespace steamquery {
    public class A2S_INFO {
        // \xFF\xFF\xFF\xFFTSource Engine Query\x00 
        public static readonly byte[] REQUEST = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0x54, 0x53, 0x6F, 0x75, 0x72, 0x63, 0x65, 0x20, 0x45, 0x6E, 0x67, 0x69, 0x6E, 0x65, 0x20, 0x51, 0x75, 0x65, 0x72, 0x79, 0x00 };
        [Flags]
        public enum ExtraDataFlags : byte {
            GameID = 0x01,
            SteamID = 0x10,
            Keywords = 0x20,
            Spectator = 0x40,
            Port = 0x80
        }
        public enum VACFlags : byte {
            Unsecured = 0,
            Secured = 1
        }
        public enum VisibilityFlags : byte {
            Public = 0,
            Private = 1
        }
        public enum EnvironmentFlags : byte {
            Linux = 0x6C, // l
            Windows = 0x77, // w
            Mac = 0x6D, // m
            MacOsX = 0x6F // o
        }
        public enum ServerTypeFlags : byte {
            Dedicated = 0x64, // d
            Nondedicated = 0x6C, // l
            SourceTV = 0x70 // p
        }
        public byte Header { get; set; } // I
        public byte Protocol { get; set; }
        public string Name { get; set; }
        public string Map { get; set; }
        public string Folder { get; set; }
        public string Game { get; set; }
        public short ID { get; set; }
        public byte Players { get; set; }
        public byte MaxPlayers { get; set; }
        public byte Bots { get; set; }
        public ServerTypeFlags ServerType { get; set; }
        public EnvironmentFlags Environment { get; set; }
        public VisibilityFlags Visibility { get; set; }
        public VACFlags VAC { get; set; }
        public string Version { get; set; }
        public ExtraDataFlags ExtraDataFlag { get; set; }
        public ulong GameID { get; set; } // 0x01
        public ulong SteamID { get; set; } // 0x10
        public string Keywords { get; set; } // 0x20
        public string Spectator { get; set; } // 0x40
        public short SpectatorPort { get; set; } // 0x40
        public short Port { get; set; } // 0x80
        public A2S_INFO(IPEndPoint ep) {
            UdpClient udp = new UdpClient();
            udp.Client.ReceiveTimeout = 10000;
            udp.Client.SendTimeout = 10000;
            udp.Send(REQUEST, REQUEST.Length, ep);
            MemoryStream ms = new MemoryStream(udp.Receive(ref ep));
            BinaryReader br = new BinaryReader(ms, Encoding.UTF8);
            ms.Seek(4, SeekOrigin.Begin);
            Header = br.ReadByte();
            Protocol = br.ReadByte();
            Name = utils.ReadNullTerminatedString(ref br);
            Map = utils.ReadNullTerminatedString(ref br);
            Folder = utils.ReadNullTerminatedString(ref br);
            Game = utils.ReadNullTerminatedString(ref br);
            ID = br.ReadInt16();
            Players = br.ReadByte();
            MaxPlayers = br.ReadByte();
            Bots = br.ReadByte();
            ServerType = (ServerTypeFlags)br.ReadByte();
            Environment = (EnvironmentFlags)br.ReadByte();
            Visibility = (VisibilityFlags)br.ReadByte();
            VAC = (VACFlags)br.ReadByte();
            Version = utils.ReadNullTerminatedString(ref br);
            ExtraDataFlag = (ExtraDataFlags)br.ReadByte();
            if (ExtraDataFlag.HasFlag(ExtraDataFlags.Port))
                Port = br.ReadInt16();
            if (ExtraDataFlag.HasFlag(ExtraDataFlags.SteamID))
                SteamID = br.ReadUInt64();
            if (ExtraDataFlag.HasFlag(ExtraDataFlags.Spectator)) {
                SpectatorPort = br.ReadInt16();
                Spectator = utils.ReadNullTerminatedString(ref br);
            }
            if (ExtraDataFlag.HasFlag(ExtraDataFlags.Keywords))
                Keywords = utils.ReadNullTerminatedString(ref br);
            if (ExtraDataFlag.HasFlag(ExtraDataFlags.GameID))
                GameID = br.ReadUInt64();
            br.Close();
            ms.Close();
            udp.Close();
        }
    }
}