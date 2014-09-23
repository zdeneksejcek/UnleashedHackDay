using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Orleans;
using SalesOrderOrleans.Contracts;

namespace SalesOrderOrleans.GrainsCollection
{
    public class SalesOrderCollectionGrain : Grain, ISalesOrderCollectionGrain
    {
        private IList<Guid> _orderGuids = new List<Guid>();

        public Task AddOrder(Guid saleOrderGuid)
        {
            _orderGuids.Add(saleOrderGuid);
            return TaskDone.Done;
        }
    }
}