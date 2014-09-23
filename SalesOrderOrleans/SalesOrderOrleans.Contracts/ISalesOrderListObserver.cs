using System;
using System.Threading.Tasks;
using Orleans;

namespace SalesOrderOrleans.Contracts
{
    public interface ISalesOrderListObserver : IGrainObserver, IGrainWithIntegerKey
    {
        Task Add(Guid salesOrderKey);
    }
}