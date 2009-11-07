using System;

namespace Sayso.Domain
{
    public class BusinessRule
    {
        private readonly ConsoleLogger logger = new ConsoleLogger();
        private readonly SmtpServer emailServer = new SmtpServer(ConfigurationManager.SmtpServer);

        /// <summary>
        /// Process Order
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="salesOrderId"></param>
        public void ProcessOrder(Guid customerId, Guid salesOrderId)
        {
            var customerRepository = new CustomerRepository();
            var salesOrderRepository = new SalesOrderRepository();

            logger.WriteLine("Get SalesOrder ID={0}", salesOrderId);
            var salesOrder = salesOrderRepository.GetById(salesOrderId);

            logger.WriteLine("Get Customer ID={0}", customerId);
            var currentCustomer = customerRepository.GetById(customerId);

            // Business Rules
            if(currentCustomer.CreditScore < 500)
            {
                logger.WriteLine("RequestApprovalForLowCreditScore");
                salesOrder.Status = SalesOrderStatus.Pending;
                emailServer.Send(currentCustomer.ApprovalManagerEmail, "Request Approval for low credit score");
            }
            else if( salesOrder.Total >= 1000D )
            {
                logger.WriteLine("RequestApprovalForLargeOrder");
                salesOrder.Status = SalesOrderStatus.LargeOrder;
                emailServer.Send(currentCustomer.ApprovalManagerEmail, "Request Approval for large order");
            }
            else
            {
                logger.WriteLine("CompleteOrder");
                salesOrder.Status = SalesOrderStatus.Completed;
                emailServer.Send(currentCustomer.EmailAddress, "Your order has been shipped");
            }

            customerRepository.Save(currentCustomer);
            salesOrderRepository.Save(salesOrder);
        }
    }
}