using Microsoft.Data.Sqlite;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ProductServer
{
    class Program
    {

        static TcpListener listener;
        const int port = 3333;
        const string ip = "127.0.0.1";

        static void Main(string[] args)
        {
           

            try
            {
                listener = new TcpListener(IPAddress.Parse(ip), port);

                listener.Start();
                Console.WriteLine("Ожидание подключений...");

                while (true)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    ServerConn serverConnection = new ServerConn(client);
                    Thread serverThread = new Thread(new ThreadStart(serverConnection.Process));
                    serverThread.Start();

                }
               
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            finally
            {
                if (listener != null)
                {
                    listener.Stop();
                }

            }

        }
    }
}
