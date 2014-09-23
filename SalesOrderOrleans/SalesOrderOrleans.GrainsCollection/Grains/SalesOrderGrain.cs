using System;
using System.Threading.Tasks;
using Orleans;
using SalesOrderOrleans.Contracts;
using SalesOrderOrleans.Contracts.Domain;
using SalesOrderOrleans.Contracts.Messages;

namespace SalesOrderOrleans.GrainsCollection.Grains
{
    public class SalesOrderGrain : Grain, ISalesOrderGrain
    {
        private SalesOrder _salesOrder;
//        private readonly ObserverSubscriptionManager<ISalesOrdersObserver> _subscribers = new ObserverSubscriptionManager<ISalesOrdersObserver>();

        public Task Create(CreateSalesOrderMessage message)
        {
            if (AlreadyExists())
                throw new Exception("Already exists");

            _salesOrder = new SalesOrder(message.SalesOrderKey, message.CustomerKey, message.WarehouseKey);

//            _subscribers.Notify(x => x.Notify(message.SalesOrderKey));

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

        public Task Complete()
        {
            _salesOrder.Complete();

            base.DeactivateOnIdle();

            return TaskDone.Done;
        }

        public Task Subscribe(ISalesOrdersObserver observer)
        {
//            _subscribers.Subscribe(observer);
            return TaskDone.Done;
        }

        public Task Unsubscribe(ISalesOrdersObserver observer)
        {
//            _subscribers.Unsubscribe(observer);
            return TaskDone.Done;
        }

        private bool AlreadyExists()
        {
            return _salesOrder != null;
        }
    }
}