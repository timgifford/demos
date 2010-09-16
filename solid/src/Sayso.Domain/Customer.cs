using System;

namespace Sayso.Domain
{
    public class Customer : Entity
    {
        public Customer(Guid id) : base(id)
        {
        }

        public int CreditScore { get; set; }

        public string ApprovalManagerEmail
        {
            get;set ;
        }

        public string EmailAddress { get; set; }
    }
}