using System;

namespace SalesOrderOrleans.Contracts.Command
{
    public class AddSalesOrderLineCommand
    {
        public Guid SalesOrderKey { get; set; }
        public Guid ProductKey { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }
}