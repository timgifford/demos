using System;

namespace Sayso.Domain
{
    public class SalesOrder : Entity
    {
        public SalesOrder(Guid id) : base(id)
        {
        }

        public SalesOrderStatus Status { get; set; }
        public double Total { get; set; }

        public void ApplyTaxes(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}