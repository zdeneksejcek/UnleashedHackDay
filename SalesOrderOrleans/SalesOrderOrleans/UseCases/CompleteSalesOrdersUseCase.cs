using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SalesOrderOrleans.Contracts.Command;
using SalesOrderOrleans.Handlers;

namespace SalesOrderOrleans.UseCases
{
    public class CompleteSalesOrdersUseCase
    {
        public void Execute(IEnumerable<Guid> salesOrderKeys)
        {
            var tasks = new List<Task>();

            var handler = new CompleteSalesOrderHandler();

            foreach (var salesOrderKey in salesOrderKeys)
            {
                var task = handler.Execute(
                    new CompleteSalesOrderCommand(salesOrderKey));

                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());
        }
    }
}