using System;
using System.Threading;
using SalesOrderOrleans.Contracts;

namespace SalesOrderOrleans.GrainsCollection.Observers
{
    public class OrdersDashboardObserver : ISalesOrdersObserver
    {
        private static volatile int _counter = 0;

        public void Notify(Guid salesOrderKey)
        {
            Interlocked.Increment(ref _counter);
            Console.WriteLine("++++++++++++++++++++++++++++++++++ === " + _counter);
        }
    }
}