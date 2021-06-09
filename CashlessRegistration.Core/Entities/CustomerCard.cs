using System;

namespace CashlessRegistration.Core.Entities
{
    public class CustomerCard
    {
        public CustomerCard(int customerId, long cardNumber)
        {
            CustomerId = customerId;
            CardNumber = cardNumber;
            RegistrationDate = DateTime.UtcNow;
        }

        public int Id { get; private set; }
        public int CustomerId { get; private set; }
        public long CardNumber { get; private set; }
        public DateTime RegistrationDate { get; private set; }
    }
}