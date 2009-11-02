using System;

namespace Sayso.Domain
{
    public class BusinessRule
    {
        private readonly ConsoleLogger logger = new ConsoleLogger();
        private readonly SmtpServer emailServer = new SmtpServer(ConfigurationManager.SmtpServer);

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
                RequestApprovalForLowCreditScore(currentCustomer, salesOrder);
            }
            else if( salesOrder.Total >= 1000D )
            {
                RequestApprovalForLargeOrder(currentCustomer, salesOrder);
            }
            else
            {
                ProcessOrder(currentCustomer, salesOrder);
            }

            customerRepository.Save(currentCustomer);
            salesOrderRepository.Save(salesOrder);
        }

        private void RequestApprovalForLargeOrder(Customer customer, SalesOrder order)
        {
            logger.WriteLine("RequestApprovalForLargeOrder");
            order.Status = SalesOrderStatus.LargeOrder;
            emailServer.Send(customer.ApprovalManagerEmail, "Request Approval for large order");
        }

        private void ProcessOrder(Customer customer, SalesOrder order)
        {
            logger.WriteLine("ProcessOrder");
            order.Status = SalesOrderStatus.Completed;
            emailServer.Send(customer.EmailAddress, "Your order has been shipped");
        }

        private void RequestApprovalForLowCreditScore(Customer customer, SalesOrder salesOrder)
        {
            logger.WriteLine("RequestApprovalForLowCreditScore");
            salesOrder.Status = SalesOrderStatus.Pending;
            emailServer.Send(customer.ApprovalManagerEmail, "Request Approval for low credit score");
        }
    }

    public class ShippingWebService
    {
    }
}