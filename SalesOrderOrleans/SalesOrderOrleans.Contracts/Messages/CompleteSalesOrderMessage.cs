using System;

namespace SalesOrderOrleans.Contracts.Messages
{
    public class CompleteSalesOrderMessage
    {
        public CompleteSalesOrderMessage(Guid salesOrderKey)
        {
            SalesOrderKey = salesOrderKey;
        }

        public Guid SalesOrderKey { get; private set; }
    }
}
