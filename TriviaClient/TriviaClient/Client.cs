using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace TriviaClient
{
    internal class Client
    {
        private TcpClient tcp;
        private Queue<string> msgQ;
        private Thread messageSenderThread;
        private Socket Sock { get => tcp.Client; }

        public Client(string ip, int port)
        {
            this.tcp = new TcpClient();
            this.msgQ = new Queue<string>();
            Connect(ip, port);

            this.messageSenderThread = new Thread(new ThreadStart(MessageSender));
            this.messageSenderThread.Start();
        }

        ~Client()
        {
            this.messageSenderThread?.Abort();
            Disconnect();
        }

        public void Send(string msg)
        {
            Console.WriteLine("[Client::Send] Sending to server: " + msg);
            Sock.Send(Encoding.ASCII.GetBytes(msg));
        }

        public string Recv()
        {
            byte[] buf = new byte[8192];
            Sock.Receive(buf);
            string msg = Encoding.ASCII.GetString(buf);
            Console.WriteLine("[Client::Recv] Received from server: " + msg);
            return msg;
        }

        private void Connect(string ip, int port)
        {
            this.tcp.Connect(ip, port);
            Console.WriteLine($"[Client::Connect] Connected to {ip}:{port}");
        }

        private void Disconnect()
        {
            Console.WriteLine($"[Client::Disconnect] Disconnecting");
            this.tcp.Close();
        }

        //////////////
        
        // Thread Func
        private void MessageSender()
        {
            while (true)
            {
                while (this.msgQ.Count == 0) ;

                string nextMsg = this.msgQ.Dequeue();
                Send(nextMsg);
            }
        }

        public TriviaProtocolMessage EnqueueMessage(TriviaProtocolMessage message)
        {
            this.msgQ.Enqueue(message.RawDecrypted());
            return TriviaProtocolMessage.FromDecrypted(Recv());
        }

        public static bool ValidUsername(string username)
            => new Regex(@"^[\w]{4,16}$").IsMatch(username);

        public static bool ValidPassword(string password)
            => new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,16}$").IsMatch(password);

        public static bool ValidEmail(string email)
            => new Regex(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$").IsMatch(email);
    }
}
