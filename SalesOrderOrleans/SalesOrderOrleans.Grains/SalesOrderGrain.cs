using System;
using System.Threading.Tasks;
using Orleans;
using SalesOrderOrleans.Interfaces;
using SalesOrderOrleans.Interfaces.Domain;
using SalesOrderOrleans.Interfaces.Messages;

namespace SalesOrderOrleans.Grains
{
    public class SalesOrderGrain : ISalesOrderGrain
    {
        //private CustomerInfo _customer;
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

        private bool AlreadyExists()
        {
            return _salesOrder != null;
        }

        //public Task AssignCustomer(CustomerInfo customer)
        //{
        //    _customer = customer;
        //    return TaskDone.Done;
        //}
    }
}