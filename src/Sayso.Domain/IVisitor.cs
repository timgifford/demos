namespace Sayso.Domain
{
    public interface IVisitor
    {
        void Visit(object objectToVisit);
    }

    public class IowaSalesTaxVisitor : IVisitor {
        
        public void Visit(SalesOrder objectToVisit) {
            objectToVisit.Total = objectToVisit.Total * 1.07;
        }

        public void Visit(object objectToVisit) {
            Visit((SalesOrder)objectToVisit);
        }
    }
}