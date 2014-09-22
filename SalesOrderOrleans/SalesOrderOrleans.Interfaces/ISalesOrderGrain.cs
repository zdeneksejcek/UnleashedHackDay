using System.Threading.Tasks;
using Orleans;
using SalesOrderOrleans.Interfaces.Domain;
using SalesOrderOrleans.Interfaces.Messages;

namespace SalesOrderOrleans.Interfaces
{
    public interface ISalesOrderGrain : IGrainWithGuidKey
    {
        Task Create(CreateSalesOrderMessage message);
        //Task AssignCustomer(CustomerInfo customer);
        Task AssignTax(SalesTax tax);
    }
}
