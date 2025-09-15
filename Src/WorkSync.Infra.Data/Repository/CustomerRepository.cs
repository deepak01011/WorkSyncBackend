using System.Linq;

using WorkSync.Domain.Interfaces;
using WorkSync.Domain.Models;
using WorkSync.Infra.Data.Context;

using Microsoft.EntityFrameworkCore;

namespace WorkSync.Infra.Data.Repository;

public class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    public CustomerRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    public Customer GetByEmail(string email)
    {
        return _dbSet.AsNoTracking().FirstOrDefault(c => c.Email == email);
    }
}
