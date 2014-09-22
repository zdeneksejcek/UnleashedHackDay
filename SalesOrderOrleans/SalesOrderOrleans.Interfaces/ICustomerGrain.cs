using System.Threading.Tasks;
using Orleans;
using SalesOrderOrleans.Interfaces.Domain;

namespace SalesOrderOrleans.Interfaces
{
    public interface ICustomerGrain : IGrainWithGuidKey
    {
        Task<SalesTax> GetSaleTax();
    }
}