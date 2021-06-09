using System.Threading.Tasks;
using CashlessRegistration.Core.Entities;

namespace CashlessRegistration.Core.Repositories
{
    public interface ICustomerCardRepository
    {
        Task<CustomerCard> GetById(int id, int customerId);
        Task Add(CustomerCard customerCard);
    }
}