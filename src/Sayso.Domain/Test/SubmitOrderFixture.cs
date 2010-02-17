using System;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Sayso.Domain
{
    [TestFixture]
    public class VisitorFixture
    {
        [Test]
        public void ShouldVisit()
        {
            var order = new SalesOrder(Guid.NewGuid()) {Total = 100};
            order.ApplyTaxes(new IowaSalesTaxVisitor());

            Assert.That(order.Total, Is.EqualTo(107D));
        }        
    }


    public class IowaSalesTaxVisitor : IVisitor
    {
        public void Visit(SalesOrder objectToVisit)
        {
            objectToVisit.Total = objectToVisit.Total * 1.07;
        }

        public void Visit(object objectToVisit)
        {
            Visit(objectToVisit as SalesOrder);
        }
    }


    [TestFixture]
    [Ignore("unable to right tests for this ball of mud.")]
    public class SubmitOrderFixture
    {
        [Test]
        public void ShouldRequestApprovalWhenCreditScoreIs500OrLess()
        {
            Guid customerId = Guid.NewGuid();
            Guid salesOrderId = Guid.NewGuid();

            var rule = new BusinessRule();
            rule.ProcessOrder(customerId, salesOrderId);

        }

        [Test]
        public void ShouldRequestApprovalWhenOrderAmountIs1000OrLarger()
        {

        }

        [Test]
        public void ShouldAutomaticallyProcessWhenIsGoodCustomer()
        {
            // Accounts Receiveable <= 100
            // Credit Rating > 650
            
        }
    }
}