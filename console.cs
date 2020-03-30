#if DEBUG
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace steamquery {
    public class console {
        private const int MY_CODE_PAGE = 437;
        private const uint GENERIC_WRITE = 0x40000000;
        private const uint FILE_SHARE_WRITE = 0x2;
        private const uint OPEN_EXISTING = 0x3;
        private const UInt32 StdOutputHandle = 0xFFFFFFF5;

        [DllImport("kernel32.dll")]
        private static extern bool SetConsoleCtrlHandler(EventHandler handler, bool add);

        [DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetStdHandle(UInt32 nStdHandle);

        [DllImport("kernel32.dll")]
        private static extern void SetStdHandle(UInt32 nStdHandle, IntPtr handle);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr CreateFile(string lpFileName, uint
            dwDesiredAccess, uint dwShareMode, uint lpSecurityAttributes, uint
            dwCreationDisposition, uint dwFlagsAndAttributes, uint hTemplateFile);

        public static void init() {
            AllocConsole();
            IntPtr stdHandle = CreateFile("CONOUT$", GENERIC_WRITE, FILE_SHARE_WRITE, 0, OPEN_EXISTING, 0, 0);
            SetStdHandle(StdOutputHandle, stdHandle);
            TextWriter writer = new StreamWriter(Console.OpenStandardOutput()) {
                AutoFlush = true
            };
            Console.SetOut(writer);
            _handler += new EventHandler(Handler);
            SetConsoleCtrlHandler(_handler, true);
        }

        private static bool Handler(CtrlType sig) {
            switch (sig) {
                case CtrlType.CTRL_C_EVENT:
                case CtrlType.CTRL_LOGOFF_EVENT:
                case CtrlType.CTRL_SHUTDOWN_EVENT:
                case CtrlType.CTRL_CLOSE_EVENT:
                default:
                    return false;
            }
        }

        private enum CtrlType {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT = 1,
            CTRL_CLOSE_EVENT = 2,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT = 6
        }

        private delegate bool EventHandler(CtrlType sig);
        static EventHandler _handler;
    }
}
#endif

