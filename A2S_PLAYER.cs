using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;

namespace steamquery {
    public class A2S_PLAYER {
        public struct Player {
            public Player(ref BinaryReader br) {
                Index = br.ReadByte();
                Name = utils.ReadNullTerminatedString(ref br);
                Score = br.ReadInt32();
                Duration = br.ReadSingle();
            }
            public byte Index { get; set; }
            public string Name { get; set; }
            public int Score { get; set; }
            public float Duration { get; set; }

            public override string ToString() {
                return Name;
            }
        }

        // \xFF\xFF\xFF\xFFU\xFF\xFF\xFF\xFF
        public static readonly byte[] REQUEST = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0x55, 0xFF, 0xFF, 0xFF, 0xFF };

        public byte Header { get; set; } // D
        public Player[] Players { get; set; }

        public A2S_PLAYER(IPEndPoint ep) {
            UdpClient udp = new UdpClient();
            udp.Client.ReceiveTimeout = 10000;
            udp.Client.SendTimeout = 10000;
            udp.Send(REQUEST, REQUEST.Length, ep);
            byte[] challenge_response = udp.Receive(ref ep);
            if (challenge_response.Length == 9 && challenge_response[4] == 0x41) // B
            {
                challenge_response[4] = 0x55; // U
                // \xFF\xFF\xFF\xFFU[CHALLENGE]
                udp.Send(challenge_response, challenge_response.Length, ep);
                MemoryStream ms = new MemoryStream(udp.Receive(ref ep));
                BinaryReader br = new BinaryReader(ms, Encoding.UTF8);
                ms.Seek(4, SeekOrigin.Begin);
                Header = br.ReadByte(); // D
                Players = new Player[br.ReadByte()];
                for (int i = 0; i < Players.Length; i++)
                    Players[i] = new Player(ref br);
                br.Close();
                ms.Close();
                udp.Close();
            }
            else
                throw new Exception("Response invalid.");

        }
    }
}