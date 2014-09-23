
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SalesOrderOrleans.Contracts.Command;
using SalesOrderOrleans.Handlers;

namespace SalesOrderOrleans.UseCases
{
    public class AddSalesOrderLinesUseCase
    {
        public void Execute(IEnumerable<Guid> salesOrderKeys)
        {
            var tasks = new List<Task>();

            var handler = new AddSalesOrderLineHandler();

            var rand = new Random();
            var numberOfLines = rand.Next(1, 100);

            foreach (var salesOrderKey in salesOrderKeys)
            {
                for (var i = 1; i < numberOfLines; i++)
                {
                    var task = handler.Execute(new AddSalesOrderLineCommand
                    {
                        SalesOrderKey = salesOrderKey,
                        Price = (decimal)rand.NextDouble(),
                        ProductKey = Guid.NewGuid(),
                        Quantity = (decimal)rand.NextDouble()
                    });

                    tasks.Add(task);
                }
            }

            Task.WaitAll(tasks.ToArray());
        }

    }
}
