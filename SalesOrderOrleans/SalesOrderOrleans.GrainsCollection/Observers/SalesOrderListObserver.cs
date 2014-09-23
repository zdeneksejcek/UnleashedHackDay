using System;
using System.Collections.Generic;
using SalesOrderOrleans.Contracts;

namespace SalesOrderOrleans.GrainsCollection.Observers
{
    public class SalesOrderListObserver : ISalesOrdersObserver
    {
        private static readonly IList<Guid> _salesOrderGuidList = new List<Guid>();
        private static volatile int _counter = 0;

        public void Notify(Guid salesOrderKey)
        {
            _salesOrderGuidList.Add(salesOrderKey);
        }

        public void Delete(Guid saleOrderGuid)
        {
            if (_salesOrderGuidList.Contains(saleOrderGuid))
                _salesOrderGuidList.Remove(saleOrderGuid);
        }
    }
}