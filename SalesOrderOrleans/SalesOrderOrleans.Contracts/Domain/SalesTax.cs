using System;

namespace SalesOrderOrleans.Contracts.Domain
{
    public class SalesTax
    {
        public Guid Key { get; set; }
        public decimal Rate { get; set; }
        public string Code { get; set; }
    }
}