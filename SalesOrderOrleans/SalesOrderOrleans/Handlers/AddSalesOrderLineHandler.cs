using System.Threading.Tasks;
using Orleans;
using SalesOrderOrleans.Contracts;
using SalesOrderOrleans.Contracts.Command;
using SalesOrderOrleans.Contracts.Messages;

namespace SalesOrderOrleans.Handlers
{
    public class AddSalesOrderLineHandler
    {
        public async Task Execute(AddSalesOrderLineCommand command)
        {
            var message = new AddSalesOrderLineMessage(command.SalesOrderKey, command.ProductKey, command.Quantity, command.Price);

            var salesOrderGrain = GrainFactory.GetGrain<ISalesOrderGrain>(command.SalesOrderKey);

            await salesOrderGrain.AddLine(message);
        }
    }
}
