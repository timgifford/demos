using System.Globalization;

namespace Sayso.Domain
{
    public interface IOrderProcessor {
        bool CanProcess(Customer customer, SalesOrder salesOrder);
        void Execute(Customer customer, SalesOrder salesOrder);
    }

    public abstract class OrderProcessor : IOrderProcessor
    {
        protected ConsoleLogger logger = new ConsoleLogger();
        protected SmtpServer emailServer = new SmtpServer(ConfigurationManager.SmtpServer);

        public abstract bool CanProcess(Customer customer, SalesOrder salesOrder);
        public abstract void Execute(Customer customer, SalesOrder salesOrder);
    }

    public class LowCreditScoreOrderProcessor : OrderProcessor {



        public override bool CanProcess(Customer customer, SalesOrder salesOrder) {
            return (customer.CreditScore < 500);
        }

        public override void Execute(Customer customer, SalesOrder salesOrder) {
            logger.WriteLine("RequestApprovalForLowCreditScore");
            salesOrder.Status = SalesOrderStatus.Pending;
            emailServer.Send(customer.ApprovalManagerEmail, "Request Approval for low credit score");
        }

    }

    public class LargeOrderProcessor : OrderProcessor {
        
        public override bool CanProcess(Customer customer, SalesOrder salesOrder) {
            return (salesOrder.Total >= 1000D);
        }

        public override void Execute(Customer customer, SalesOrder salesOrder) {
            logger.WriteLine("RequestApprovalForLargeOrder");
            salesOrder.Status = SalesOrderStatus.LargeOrder;
            emailServer.Send(customer.ApprovalManagerEmail, "Request Approval for large order");
        }
    }

    public class DefaultOrderProcessor : OrderProcessor {

        public override bool CanProcess(Customer customer, SalesOrder salesOrder) {
            return true;
        }

        public override void Execute(Customer customer, SalesOrder salesOrder) {
            logger.WriteLine("ProcessOrder");
            salesOrder.Status = SalesOrderStatus.Completed;
            emailServer.Send(customer.EmailAddress, "Your order has been shipped");
        }
    }

    // Add a new OrderProcessor
    public class DeniedOrderProcessor : OrderProcessor {
 
        public override bool CanProcess(Customer customer, SalesOrder salesOrder) {
            return (customer.CreditScore < 100);
        }
 
        public override void Execute(Customer customer, SalesOrder salesOrder) {
            logger.WriteLine("DeniedOrderProcessor");
            salesOrder.Status = SalesOrderStatus.Denied;
            emailServer.Send(customer.EmailAddress, "Your order has been denied");
        }
    }

}