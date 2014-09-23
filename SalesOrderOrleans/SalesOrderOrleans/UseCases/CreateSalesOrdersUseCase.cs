using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SalesOrderOrleans.Contracts;
using SalesOrderOrleans.Contracts.Command;
using SalesOrderOrleans.GrainsCollection.Observers;
using SalesOrderOrleans.Handlers;

namespace SalesOrderOrleans.UseCases
{
    public class CreateSalesOrdersUseCase
    {
        CreateSalesOrderHandler handler = new CreateSalesOrderHandler();

        public IEnumerable<Guid> Execute(int number)
        {
            var salesOrderKeys = new List<Guid>();
            var tasks = new List<Task>();
            
            for (int i = 0; i < number; i++)
            {
                var salesOrderKey = Guid.NewGuid();

                Task createTask = handler.Execute(new CreateSalesOrderCommand(salesOrderKey, Guid.NewGuid(), Guid.NewGuid()));

                tasks.Add(createTask);

                salesOrderKeys.Add(salesOrderKey);
            }

            Task.WaitAll(tasks.ToArray());

            return salesOrderKeys;
        }

        public void Subscribe(ISalesOrdersObserver observer)
        {
            handler.Subscribe(observer);
        }
    }
}
