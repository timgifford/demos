using System;
using NUnit.Framework;

namespace Sayso.Domain
{
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