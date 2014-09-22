using System;
using System.Threading.Tasks;
using Orleans;
using SalesOrderOrleans.Interfaces;

namespace SalesOrderOrleans.Grains
{
    public class SalesOrderGrain : ISalesOrder
    {
        private CustomerInfo _customer;
        public Task AssignCustomer(CustomerInfo customer)
        {
            _customer = customer;
            return TaskDone.Done;
        }
    }
}