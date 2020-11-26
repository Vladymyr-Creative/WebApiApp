using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data.Interfaces;
using WebApplication.Data.Models;

namespace WebApplication.Data.Repositories
{
    public class CustomerRepository : ICustomer
    {
        private readonly AppDBContent _appDBContent;

        public CustomerRepository(AppDBContent appDBContent)
        {
            _appDBContent = appDBContent;
        }

        public async Task Create(Customer customer)
        {
            if (customer.Email == null || await GetByEmail(customer.Email) != null) {
                return;
            }
            await _appDBContent.Customer.AddAsync(customer);
            await _appDBContent.SaveChangesAsync();
        }

        public async Task<Customer> Get(int id)
        {
            return await _appDBContent.Customer.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Customer> GetByEmail(string email)
        {
            return await _appDBContent.Customer.FirstOrDefaultAsync(c => c.Email == email);
        }
    }
}
