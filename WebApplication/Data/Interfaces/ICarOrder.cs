using System.Threading.Tasks;
using WebApplication.Data.Models;

namespace WebApplication.Data.Interfaces
{
    public interface ICarOrder
    {
        Task Create(CarOrder carOrder);
    }
}
