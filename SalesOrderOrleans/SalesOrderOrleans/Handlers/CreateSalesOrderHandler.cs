﻿using System.Threading.Tasks;
using Orleans;
using SalesOrderOrleans.Contracts;
using SalesOrderOrleans.Contracts.Command;
using SalesOrderOrleans.Contracts.Messages;
using SalesOrderOrleans.GrainsCollection;

namespace SalesOrderOrleans.Handlers
{
    public class CreateSalesOrderHandler
    {

        public async Task Execute(CreateSalesOrderCommand command)
        {
            var message = new CreateSalesOrderMessage(command.SalesOrderKey, command.CustomerKey, command.WarehouseKey);
            var salesOrderGrain = GrainFactory.GetGrain<ISalesOrderGrain>(command.SalesOrderKey);
            
            var referenceList = await SalesOrdersObserverFactory.CreateObjectReference(new SalesOrderListObserver());
            var referenceDashboard = await SalesOrdersObserverFactory.CreateObjectReference(new OrdersDashboardObserver());
            await salesOrderGrain.Subscribe(referenceList);
            await salesOrderGrain.Subscribe(referenceDashboard);
            
            await salesOrderGrain.Create(message);

            var customerGrain = GrainFactory.GetGrain<ICustomerGrain>(command.CustomerKey);
            var tax = await customerGrain.GetSaleTax();
            await salesOrderGrain.AssignTax(tax);

            await salesOrderGrain.Unsubscribe(referenceDashboard);
            await salesOrderGrain.Unsubscribe(referenceList);
        }
    }
}