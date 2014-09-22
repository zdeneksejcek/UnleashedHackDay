using System.Threading.Tasks;
using Orleans;
using SalesOrderOrleans.Contracts.Domain;

namespace SalesOrderOrleans.Contracts
{
    public interface ICustomerGrain : IGrainWithGuidKey
    {
        Task<SalesTax> GetSaleTax();
    }
}