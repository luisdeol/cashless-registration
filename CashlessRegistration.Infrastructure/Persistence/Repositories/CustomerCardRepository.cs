using CashlessRegistration.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CashlessRegistration.Core.Entities;

namespace CashlessRegistration.Infrastructure.Persistence.Repositories
{
    public class CustomerCardRepository : ICustomerCardRepository
    {
        private readonly CashlessRegistrationDbContext _dbContext;
        public CustomerCardRepository(CashlessRegistrationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CustomerCard> GetById(int id, int customerId) {
            return await _dbContext.CustomerCards.SingleOrDefaultAsync(c => c.Id == id && c.CustomerId == customerId);
        }

        public async Task Add(CustomerCard customerCard) {
            await _dbContext.CustomerCards.AddAsync(customerCard);
            await _dbContext.SaveChangesAsync();
        }
    }
}