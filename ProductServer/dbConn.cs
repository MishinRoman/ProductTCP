using Microsoft.Data.Sqlite;
using ProductClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Configuration;

namespace ProductServer
{
    public class dbConn
    {
        public static void ProdSendDb(List<Product> products)
        {
            string exception = "INSERT INTO Products( Name, Price, Count) VALUES( @name, @price, @count)" ;


            using (SqliteConnection sqliteConnection = new SqliteConnection("Data Source = ProductData.db"))
            {
                try
                {
                    sqliteConnection.Open();
               
                    SqliteCommand command = new SqliteCommand(exception);
                    command.Connection = sqliteConnection;
                
                    //command.CommandText = 
                    //   "CREATE TABLE Products(_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, Name TEXT NOT NULL, Price INTAGER, Count INTAGER) ";
                    //command.ExecuteNonQuery();


                    foreach(var item in products)
                    {
                   
                        command.Parameters.Add(new SqliteParameter ("@name", item.Name));
                        command.Parameters.Add(new SqliteParameter ("@price", item.Price));
                        command.Parameters.Add(new SqliteParameter ("@count", item.Count));

                        command.ExecuteNonQuery();

                    }

                }
                catch (SqliteException ex)
                {
                    Console.WriteLine(ex.Message);
                  
                }
                
            }

        }


    }
}
