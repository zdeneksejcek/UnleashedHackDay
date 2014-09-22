using System.Threading.Tasks;
using Orleans;
using SalesOrderOrleans.Contracts.Domain;
using SalesOrderOrleans.Contracts.Messages;

namespace SalesOrderOrleans.Contracts
{
    public interface ISalesOrderGrain : IGrainWithGuidKey
    {
        Task Create(CreateSalesOrderMessage message);
        //Task AssignCustomer(CustomerInfo customer);
        Task AssignTax(SalesTax tax);
    }
}
