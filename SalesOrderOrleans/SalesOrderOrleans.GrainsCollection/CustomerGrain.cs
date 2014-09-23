using System;
using System.Threading.Tasks;
using SalesOrderOrleans.Contracts;
using SalesOrderOrleans.Contracts.Domain;

namespace SalesOrderOrleans.GrainsCollection
{
    public class CustomerGrain : Orleans.Grain, ICustomerGrain
    {
        public Task<SalesTax> GetSaleTax()
        {
            return Task.FromResult(new SalesTax {Code = "GST", Key = Guid.NewGuid(), Rate = 0.15M});
        }
    }
}