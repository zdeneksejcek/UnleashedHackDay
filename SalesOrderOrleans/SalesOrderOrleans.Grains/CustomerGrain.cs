using System;
using System.Threading.Tasks;
using SalesOrderOrleans.Interfaces;
using SalesOrderOrleans.Interfaces.Domain;

namespace SalesOrderOrleans.Grains
{
    public class CustomerGrain : ICustomerGrain
    {
        public Task<SalesTax> GetSaleTax()
        {
            return Task.FromResult(new SalesTax {Code = "GST", Key = Guid.NewGuid(), Rate = 0.15M});
        }
    }
}