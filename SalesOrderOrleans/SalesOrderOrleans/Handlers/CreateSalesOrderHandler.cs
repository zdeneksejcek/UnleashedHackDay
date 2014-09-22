﻿using System.Threading.Tasks;
using Orleans;
using SalesOrderOrleans.Contracts;
using SalesOrderOrleans.Contracts.Command;
using SalesOrderOrleans.Contracts.Messages;

namespace SalesOrderOrleans.Handlers
{
    public class CreateSalesOrderHandler
    {
        public async Task Execute(CreateSalesOrderCommand command)
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