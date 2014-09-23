using System;
using System.Threading.Tasks;
using Orleans;

namespace SalesOrderOrleans.Contracts
{
    public interface ISalesOrderCollectionGrain : IGrain
    {
        Task AddOrder(Guid saleOrderGuid);
    }
}