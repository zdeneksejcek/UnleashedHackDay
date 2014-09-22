using System.Threading.Tasks;
using Orleans;

namespace SalesOrderOrleans.Interfaces
{
    public interface ISalesOrderGrain : IGrainWithGuidKey
    {
        Task AssignCustomer(CustomerInfo customer);
    }
}
