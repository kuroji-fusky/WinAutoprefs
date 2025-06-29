using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace WinAutoprefs
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }

        // Admin stuff
        
        const int BCM_SHIELDICON = 0x160C;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        internal static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        ///  Just adds the UAC shield from a control, it doesn't do much by itself
        ///  other than to literally just show a badge lmao
        /// </summary>
        internal static void AppendUACShield(Button btn)
        {
            btn.FlatStyle = FlatStyle.System;
            SendMessage(btn.Handle, BCM_SHIELDICON, IntPtr.Zero, (IntPtr)1);
        }

        /// <summary>
        ///  Hey girlie, you an admin?
        /// </summary>
        internal static bool GurlYouAdminDoe()
        {
            WindowsIdentity currentIdentities = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new(currentIdentities);

            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        internal static void RelaunchThatAppAsAdmin()
        {
            if (GurlYouAdminDoe()) return;

            try
            {
                ProcessStartInfo proc = new()
                {
                    FileName = Application.ExecutablePath,
                    WorkingDirectory = Environment.CurrentDirectory,
                    UseShellExecute = true,
                    Verb = "runas",
                };

                Process? elevateMeUpBaby = Process.Start(proc);

                if (elevateMeUpBaby != null)
                {
                    Application.Exit();
                }
            }
            catch
            { }
        }
    }
}