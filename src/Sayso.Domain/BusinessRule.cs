using System;

namespace Sayso.Domain
{


    public class BusinessRule
    {
        private readonly ConsoleLogger logger = new ConsoleLogger();
        private readonly IOrderProcessor[] orderProcessors;

        public BusinessRule() : this(
            new IOrderProcessor[]
                {
                    new DefaultOrderProcessor(), 
                    new LargeOrderProcessor(), 
                    new LowCreditScoreOrderProcessor(), 
                    new DeniedOrderProcessor()
                })
        {
            
        }

        public BusinessRule(IOrderProcessor[] orderProcessors)
        {
            this.orderProcessors = orderProcessors;
        }
        
        public ValidationResult ValidateOrder(SalesOrder order)
        {
            return new ValidationResult();
        }

        public void ProcessOrder(Guid customerId, Guid salesOrderId)
        {
            var customerRepository = new CustomerRepository();
            var salesOrderRepository = new SalesOrderRepository();

            logger.WriteLine("Get SalesOrder ID={0}", salesOrderId);
            var salesOrder = salesOrderRepository.GetById(salesOrderId);

            logger.WriteLine("Get Customer ID={0}", customerId);
            var currentCustomer = customerRepository.GetById(customerId);
            
// Replace Conditional Logic
//            if(currentCustomer.CreditScore < 500)
//            {
//                RequestApprovalForLowCreditScore(currentCustomer, salesOrder);
//            }
//            else if( salesOrder.Total >= 1000D )
//            {
//                RequestApprovalForLargeOrder(currentCustomer, salesOrder);
//            }
//            else
//            {
//                ProcessOrder(currentCustomer, salesOrder);
//            }

            // Find the First processor that can process the customer and order
            IOrderProcessor orderProcessor = Array.Find(orderProcessors,
                                                        processor => processor.CanProcess(currentCustomer, salesOrder));

            orderProcessor.Execute(currentCustomer, salesOrder);

            customerRepository.Save(currentCustomer);
            salesOrderRepository.Save(salesOrder);
        }

        // REPLACED WITH ORDERPROCESSORS
//        private void RequestApprovalForLargeOrder(Customer customer, SalesOrder order)
//        {
//            logger.WriteLine("RequestApprovalForLargeOrder");
//            order.Status = SalesOrderStatus.LargeOrder;
//            emailServer.Send(customer.ApprovalManagerEmail, "Request Approval for large order");
//        }
//
//        private void ProcessOrder(Customer customer, SalesOrder order)
//        {
//            logger.WriteLine("ProcessOrder");
//            order.Status = SalesOrderStatus.Completed;
//            emailServer.Send(customer.EmailAddress, "Your order has been shipped");
//        }
//
//        private void RequestApprovalForLowCreditScore(Customer customer, SalesOrder salesOrder)
//        {
//            logger.WriteLine("RequestApprovalForLowCreditScore");
//            salesOrder.Status = SalesOrderStatus.Pending;
//            emailServer.Send(customer.ApprovalManagerEmail, "Request Approval for low credit score");
//        }
    }
}