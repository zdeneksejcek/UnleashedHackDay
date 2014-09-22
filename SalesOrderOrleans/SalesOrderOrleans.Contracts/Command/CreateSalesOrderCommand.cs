using System;

namespace SalesOrderOrleans.Contracts.Command
{
    public class CreateSalesOrderCommand
    {
        public CreateSalesOrderCommand(Guid salesOrderKey, Guid customerKey, Guid warehouseKey)
        {
            WarehouseKey = warehouseKey;
            CustomerKey = customerKey;
            SalesOrderKey = salesOrderKey;
        }

        public Guid SalesOrderKey { get; private set; } 
        public Guid CustomerKey { get; private set; } 
        public Guid WarehouseKey { get; private set; } 
    }
}