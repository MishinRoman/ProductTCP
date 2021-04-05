using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace ProductClient
{
    static class TCPConnecntion
    {
        const int port = 3333;
        const string ip = "127.0.0.1";
        static TcpClient client;

        public static void SendData(List<Product> products)
        {
            BinaryFormatter formatter = new BinaryFormatter();


            try
            {
                client = new TcpClient(ip, port);
                using (NetworkStream stream = client.GetStream())
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        formatter.Serialize(ms, products);
                        byte[] data = ms.GetBuffer();
                        stream.Write(data, 0, data.Length);
                    }               


                    products = (List<Product>)formatter.Deserialize(stream);
                    foreach (var item in products)
                    {
                        Console.WriteLine($"Новая цена с сревера {item.Price}");
                    }

                }               
              
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Для выхода нажмите любую клавишу");
                client.Close();
            }
           


        }
       
    }
}


