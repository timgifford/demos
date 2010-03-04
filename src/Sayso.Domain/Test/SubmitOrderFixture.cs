using System;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Sayso.Domain
{
    [TestFixture]
    public class VisitorFixture
    {
        [Test]
        public void ShouldApplyStateOfIowaTax()
        {
            var order = new SalesOrder(Guid.NewGuid()) {Total = 100};
            order.ApplyTaxes(new IowaSalesTaxVisitor());

            Assert.That(order.Total, Is.EqualTo(107D));
        }        
    }



}