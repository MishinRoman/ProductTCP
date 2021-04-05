using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductClient
{
    [Serializable]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }

        public Product(string name, double price, int count)
        {            
            Name = name;
            Price = price;
            Count = count;
        }
    }
}
