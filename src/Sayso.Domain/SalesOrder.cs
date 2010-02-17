using System;

namespace Sayso.Domain
{
    public class SalesOrder : Entity
    {
        public SalesOrder(Guid id) : base(id)
        {
        }

        public SalesOrderStatus Status
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public double Total { get; set; }

        public void ApplyTaxes(IowaSalesTaxVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}