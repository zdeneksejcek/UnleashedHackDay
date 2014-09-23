using System;
using Orleans;

namespace SalesOrderOrleans.Contracts
{
    public interface ISalesOrdersObserver : IGrainObserver
    {
        void Notify(Guid salesOrderKey);
    }
}