using System.Threading.Tasks;
using Orleans;
using SalesOrderOrleans.Contracts;
using SalesOrderOrleans.Contracts.Command;
using SalesOrderOrleans.Contracts.Messages;

namespace SalesOrderOrleans.Handlers
{
    public class CompleteSalesOrderHandler
    {
        public async Task Execute(CompleteSalesOrderCommand command)
        {
            var message = new CompleteSalesOrderMessage(command.SalesOrderKey);

            var salesOrderGrain = GrainFactory.GetGrain<ISalesOrderGrain>(command.SalesOrderKey);

            await salesOrderGrain.Complete(message);
        }
    }
}
