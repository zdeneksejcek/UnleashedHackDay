using System.Threading.Tasks;
using Orleans;
using SalesOrderOrleans.Contracts;
using SalesOrderOrleans.Contracts.Command;

namespace SalesOrderOrleans.Handlers
{
    public class CompleteSalesOrderHandler
    {
        public async Task Execute(CompleteSalesOrderCommand command)
        {
            var salesOrderGrain = GrainFactory.GetGrain<ISalesOrderGrain>(command.SalesOrderKey);

            await salesOrderGrain.Complete();
        }
    }
}
