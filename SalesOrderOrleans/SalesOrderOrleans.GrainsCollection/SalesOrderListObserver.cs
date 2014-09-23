using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Orleans;
using SalesOrderOrleans.Contracts;

namespace SalesOrderOrleans.GrainsCollection
{
    public class SalesOrderListObserver : ISalesOrderListObserver
    {
        private static readonly IList<Guid> _salesOrderGuidList = new List<Guid>(); 

        public Task Add(Guid salesOrderKey)
        {
            _salesOrderGuidList.Add(salesOrderKey);
            Console.WriteLine(_salesOrderGuidList.Count);
            return TaskDone.Done;
        }

        public void Delete(Guid saleOrderGuid)
        {
            if (_salesOrderGuidList.Contains(saleOrderGuid))
                _salesOrderGuidList.Remove(saleOrderGuid);
        }
    }
}