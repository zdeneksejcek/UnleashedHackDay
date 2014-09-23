using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SalesOrderOrleans.Contracts.Command;
using SalesOrderOrleans.Handlers;

namespace SalesOrderOrleans.UseCases
{
    public class CreateSalesOrdersUseCase
    {
        public IEnumerable<Guid> Execute(int number)
        {
            var salesOrderKeys = new List<Guid>();
            var tasks = new List<Task>();
            
            var handler = new CreateSalesOrderHandler();

            for (int i = 0; i < number; i++)
            {
                var salesOrderKey = Guid.NewGuid();

                Task createTask = handler.Execute(
                    new CreateSalesOrderCommand(salesOrderKey, Guid.NewGuid(), Guid.NewGuid()));

                tasks.Add(createTask);

                salesOrderKeys.Add(salesOrderKey);
            }

            Task.WaitAll(tasks.ToArray());

            return salesOrderKeys;
        }
    }
}
