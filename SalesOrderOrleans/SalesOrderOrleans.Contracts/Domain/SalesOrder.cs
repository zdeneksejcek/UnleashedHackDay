using System;

namespace SalesOrderOrleans.Contracts.Domain
{
    public class SalesOrder
    {
        public Guid Key { get; private set;}

        public Guid CustomerKey { get; private set; }

        public Guid WarehouseKey { get; private set; }

        public SalesTax Tax { get; private set; }

        public SalesOrder(Guid key, Guid customerKey, Guid warehouseKey)
        {
            WarehouseKey = warehouseKey;
            CustomerKey = customerKey;
            Key = key;

            Tax = new SalesTax {Code = "ZERO", Key = Guid.NewGuid(), Rate = 0 };
        }

        public void SetTax(SalesTax tax)
        {
            Tax = tax;
        }
    }
}
