using System;

namespace SalesOrderOrleans.Contracts.Domain
{
    public class SalesOrderLine
    {
        public Guid ProductKey { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Price { get; private set; }

        public string Comment { get; private set; }

        public SalesOrderLine(Guid productKey, decimal quantity, decimal price, string comment = "")
        {
            Comment = comment;
            Price = price;
            Quantity = quantity;
            ProductKey = productKey;
        }
    }
}