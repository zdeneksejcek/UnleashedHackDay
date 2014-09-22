using System;
using System.Threading.Tasks;
using Orleans;
using SalesOrderOrleans.Contracts;
using SalesOrderOrleans.Contracts.Domain;
using SalesOrderOrleans.Contracts.Messages;

namespace SalesOrderOrleans.GrainsCollection
{
    public class SalesOrderGrain : Grain, ISalesOrderGrain
    {
        private SalesOrder _salesOrder;

        public Task Create(CreateSalesOrderMessage message)
        {
            if (AlreadyExists())
                throw new Exception("Already exists");

            _salesOrder = new SalesOrder(message.SalesOrderKey, message.CustomerKey, message.WarehouseKey);

            return TaskDone.Done;
        }

        public Task AssignTax(SalesTax tax)
        {
            _salesOrder.SetTax(tax);
            return TaskDone.Done;
        }

        public Task AddLine(AddSalesOrderLineMessage message)
        {
            var line = new SalesOrderLine(message.ProductKey, message.Quantity, message.Price, message.Comment);
            _salesOrder.AddLine(line);
            return TaskDone.Done;
        }

        public Task Complete(CompleteSalesOrderMessage message)
        {
            if (_salesOrder.Status == SalesOrderStatus.Completed)
                throw new Exception("Order is already complete.");

            _salesOrder.ChangeStatus(SalesOrderStatus.Completed);

            return TaskDone.Done;
        }
        
        private bool AlreadyExists()
        {
            return _salesOrder != null;
        }
    }
}