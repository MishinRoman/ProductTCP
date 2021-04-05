using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace ProductClient
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            string answer;

            do
            {
                Console.WriteLine("Ввидите имя продукта: ");
                string name = Console.ReadLine();
                Console.WriteLine("Ввидите цену продукта: ");
                double.TryParse(Console.ReadLine(), out double price);
                Console.WriteLine("Ввидете количество продукта: ");
                int.TryParse(Console.ReadLine(), out int count);

                products.Add(new Product(name, price, count));

                int allCount = products.Count;
                Console.WriteLine($"Вы ввели {allCount} продуктов");

                Console.WriteLine("Хотите дабвить еще продукт? Ведите Да(Y) или нажмите любую клавишу для выхода");
                answer = Console.ReadLine();

            } while (answer == "Да" || answer == "Y");

          
            TCPConnecntion.SendData(products);
            Console.ReadKey();
            
        }
    }
}
