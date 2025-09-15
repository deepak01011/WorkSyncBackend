using WorkSync.Domain.Models;

namespace WorkSync.Domain.Interfaces;

public interface ICustomerRepository : IRepository<Customer>
{
    Customer GetByEmail(string email);
}
