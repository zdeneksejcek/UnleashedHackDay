﻿using Orleans;
using SalesOrderOrleans.Interfaces;
using SalesOrderOrleans.Interfaces.Command;
using SalesOrderOrleans.Interfaces.Messages;

namespace SalesOrderOrleans.Handlers
{
    public class CreateSalesOrderHandler
    {
        public async void Execute(CreateSalesOrderCommand command)
        {
            var message = new CreateSalesOrderMessage(command.SalesOrderKey, command.CustomerKey, command.WarehouseKey);
            
            var salesOrderGrain = GrainFactory.GetGrain<ISalesOrderGrain>(command.SalesOrderKey);

            await salesOrderGrain.Create(message);

            var customerGrain = GrainFactory.GetGrain<ICustomerGrain>(command.CustomerKey);

            var tax = await customerGrain.GetSaleTax();

            await salesOrderGrain.AssignTax(tax);

        }
    }
}