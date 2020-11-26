using System.Threading.Tasks;
using WebApplication.Data.Models;

namespace WebApplication.Data.Interfaces
{
    public interface ICustomer
    {
        Task Create(Customer customer);
        Task<Customer> Get(int id);
        Task<Customer> GetByEmail(string email);
    }
}
