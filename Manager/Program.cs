using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Manager
{
    static class Program
    {
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        
//      [System.Runtime.InteropServices.DllImport("user32.dll")]
//      private static extern bool SetProcessDPIAware();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool isNew;
            Mutex mutex = new Mutex(true, "{6E4A69F1-663E-4e44-8CA8-7439AD95EB52}", out isNew);
            if (isNew)
            {
//              if (Environment.OSVersion.Version.Major >= 6)  // DPI awarenes can be enabled by this API call or by manifest file.see
//                  SetProcessDPIAware();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormMain());
            }
            else
            {
                Process current = Process.GetCurrentProcess();
                foreach (Process process in Process.GetProcessesByName(current.ProcessName))
                    if (process.Id != current.Id)
                    {
                        SetForegroundWindow(process.MainWindowHandle);
                        break;
                    }
            }
            GC.KeepAlive(mutex);
        }
    }
}
