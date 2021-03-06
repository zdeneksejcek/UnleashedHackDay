﻿using System;
using System.Collections.Generic;

namespace SalesOrderOrleans.Contracts.Domain
{
    public class SalesOrder
    {
        private readonly IList<SalesOrderLine> _lines;
        public Guid Key { get; private set;}

        public Guid CustomerKey { get; private set; }

        public Guid WarehouseKey { get; private set; }

        public SalesTax Tax { get; private set; }

        public SalesOrderStatus Status { get; private set; }

        public SalesOrder(Guid key, Guid customerKey, Guid warehouseKey)
        {
            WarehouseKey = warehouseKey;
            CustomerKey = customerKey;
            Key = key;

            Tax = new SalesTax {Code = "ZERO", Key = Guid.NewGuid(), Rate = 0 };

            _lines = new List<SalesOrderLine>();
        }

        public void AddLine(SalesOrderLine line)
        {
            if (Status != SalesOrderStatus.Open)
                throw new Exception("Cannot be added");

            _lines.Add(line);
        }

        public void SetTax(SalesTax tax)
        {
            Tax = tax;
        }

        public void Complete()
        {
            Status = SalesOrderStatus.Completed;
        }

        public void ChangeStatus(SalesOrderStatus status)
        {
            Status = status;
        }
    }

    public enum SalesOrderStatus
    {
        Open,
        Completed
    }
}
