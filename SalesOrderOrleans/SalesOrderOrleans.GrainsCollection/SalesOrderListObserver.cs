using System;
using System.Collections.Generic;
using System.Threading;
using SalesOrderOrleans.Contracts;

namespace SalesOrderOrleans.GrainsCollection
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

    public class OrdersDashboardObserver : ISalesOrdersObserver
    {
        private static volatile int _counter = 0;

        public void Notify(Guid salesOrderKey)
        {
            Interlocked.Increment(ref _counter);
            Console.WriteLine(_counter);
        }
    }
}