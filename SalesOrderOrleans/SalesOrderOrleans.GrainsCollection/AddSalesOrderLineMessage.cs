using System;

namespace SalesOrderOrleans.GrainsCollection
{
    public class AddSalesOrderLineMessage
    {
        public Guid ProductKey { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public string Comment { get; set; }
    }
}