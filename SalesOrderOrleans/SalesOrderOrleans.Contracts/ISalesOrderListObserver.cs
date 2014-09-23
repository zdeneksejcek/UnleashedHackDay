using System;
using Orleans;

namespace SalesOrderOrleans.Contracts
{
    public interface ISalesOrderListObserver : IGrainObserver, IGrainWithIntegerKey
    {
        void Add(Guid salesOrderKey);
    }
}