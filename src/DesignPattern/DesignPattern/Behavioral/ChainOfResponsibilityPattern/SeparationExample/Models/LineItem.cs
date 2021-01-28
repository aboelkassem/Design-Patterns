using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Behavioral.ChainOfResponsibilityPattern.SeparationExample.Models
{
    public class LineItem
    {
        public string Id { get; }
        public string Name { get; }
        public decimal Price { get; }

        public LineItem(string id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
