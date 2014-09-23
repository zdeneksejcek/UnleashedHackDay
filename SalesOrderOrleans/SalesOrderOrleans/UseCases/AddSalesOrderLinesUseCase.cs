
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SalesOrderOrleans.Contracts.Messages;

namespace SalesOrderOrleans.UseCases
{
    public class AddSalesOrderLinesUseCase
    {
        public void Execute(IEnumerable<Guid> salesOrderKeys)
        {
            var tasks = new List<Task>();

            //var handler = new AddSalesOrderLineHandler();

            var rand = new Random();
            var numberOfLines = rand.Next(1, 100);

            for (var i = 1; i < numberOfLines; i++)
            {
                // pass in salesOrderKeys[i]
                //Task addLine = handler.Execute(new AddSalesOrderLineMessage());

                //tasks.Add(addLine);

            }
        }

    }
}
