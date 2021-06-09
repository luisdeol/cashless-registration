using CashlessRegistration.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashlessRegistration.Infrastructure.Persistence
{
    public class CashlessRegistrationDbContext : DbContext
    {
        public CashlessRegistrationDbContext(DbContextOptions<CashlessRegistrationDbContext> options) : base(options)
        {
            
        }

        public DbSet<CustomerCard> CustomerCards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<CustomerCard>()
            .HasKey(c => c.Id);
        }
    }
}