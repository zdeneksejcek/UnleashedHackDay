using System;

namespace SalesOrderOrleans.Contracts.Messages
{
    public class AddSalesOrderLineMessage
    {
        public Guid SalesOrderKey { get; set; }
        public Guid ProductKey { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public string Comment { get; set; }

        public AddSalesOrderLineMessage(Guid salesOrderKey, Guid productKey, decimal quantity, decimal price, string comment = "")
        {
            SalesOrderKey = salesOrderKey;
            ProductKey = productKey;
            Quantity = quantity;
            Price = price;
            Comment = comment;
        }
    }
}