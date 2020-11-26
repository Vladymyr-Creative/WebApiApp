using System.Threading.Tasks;
using WebApplication.Data.Interfaces;
using WebApplication.Data.Models;

namespace WebApplication.Data.Repositories
{
    public class CarOrderRepository : ICarOrder
    {
        private readonly AppDBContent _appDBContent;        

        public CarOrderRepository(AppDBContent appDBContent)
        {
            _appDBContent = appDBContent;            
        }

        public async Task Create(CarOrder carOrder)
        {
            await _appDBContent.CarOrder.AddAsync(carOrder);
            await _appDBContent.SaveChangesAsync();
        }
    }
}
