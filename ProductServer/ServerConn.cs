using ProductClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace ProductServer
{
    public class ServerConn
    {
        BinaryFormatter formatter = new BinaryFormatter();
        public TcpClient client;
        public ServerConn(TcpClient _client)
        {
            client = _client;
        }
        public void Process()
        {
            List<Product> desProduct;
            NetworkStream ns = null;
            try
            {
                
                ns = client.GetStream();

                desProduct = (List<Product>)formatter.Deserialize(ns);
                while (true)
                {
                    foreach (var product in desProduct)
                    {
                        if (product.Count > 5)
                            product.Price += (product.Price * 10) / 100;

                    }

                    using (MemoryStream ms = new MemoryStream())
                    {
                        formatter.Serialize(ms, desProduct);
                        byte[] data = ms.GetBuffer();
                        ns.Write(data, 0, data.Length);
                    }
                    dbConn.ProdSendDb(desProduct);

                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            finally
            {
                if (ns != null)
                {
                    ns.Close();
                }
                if (client != null)
                {
                    client.Close();
                }

            }
        }
    }
}

