using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Behavioral.CommandPattern.Models
{
    public class Product
    {
        public string ArticleId { get; set; }
        public int Quantity { get; set; }
        public int AmountInStock { get; set; }
        public string Name { get; set; }
    }
}
