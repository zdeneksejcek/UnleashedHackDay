using System.Threading.Tasks;
using Orleans;
using SalesOrderOrleans.Contracts.Domain;
using SalesOrderOrleans.Contracts.Messages;

namespace SalesOrderOrleans.Contracts
{
    public interface ISalesOrderGrain : IGrainWithGuidKey
    {
        Task Create(CreateSalesOrderMessage message);
        Task AssignTax(SalesTax tax);
        Task AddLine(AddSalesOrderLineMessage message);

        Task Complete();
    }
}
