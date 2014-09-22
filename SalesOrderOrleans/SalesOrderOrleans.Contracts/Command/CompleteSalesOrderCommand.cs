using System;

namespace SalesOrderOrleans.Contracts.Command
{
    public class CompleteSalesOrderCommand
    {
        public CompleteSalesOrderCommand(Guid salesOrderKey)
        {
            SalesOrderKey = salesOrderKey;
        }

        public Guid SalesOrderKey { get; private set; }
    }
}