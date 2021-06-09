using System;
using CashlessRegistration.Core.Entities;

namespace CashlessRegistration.Core.DomainServices
{
    public interface ITokenDomainService
    {
        long Generate(long cardNumber, int cvv);
        bool Validate(CustomerCard customerCard, long token, int cvv);
    }
}