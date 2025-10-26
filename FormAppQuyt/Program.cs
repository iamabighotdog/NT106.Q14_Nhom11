using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormAppQuyt
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Thread serverThread = new Thread(() =>
            {
                try
                {
                    TcpServer server = new TcpServer();
                    server.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Server failed to start: " + ex.Message);
                }
            });

            serverThread.IsBackground = true;
            serverThread.Start();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LogInForm());
        }
    }
}
