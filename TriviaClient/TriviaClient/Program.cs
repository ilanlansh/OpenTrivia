using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Windows.Forms;

namespace TriviaClient
{
    internal static class Program
    {
        private const string LOCALHOST = "127.0.0.1";
        private const int STD_TRIVIA_PORT = 6565;

        public static Client client;
        public static bool tryRunAgain;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Console.WriteLine("TRIVIA CLIENT\n\n");
            Console.Title = "Trivia Client Console";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            tryRunAgain = true;
            
            while (tryRunAgain)
            {
                try
                {
                    client = new Client(LOCALHOST, STD_TRIVIA_PORT);
                    tryRunAgain = false;
                    Application.Run(new AuthWindow());
                }
                catch (SocketException)
                {
                    Application.Run(new ErrorWindow());
                }
            }
        }
    }
}
