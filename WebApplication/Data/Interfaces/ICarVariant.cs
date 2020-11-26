using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Data.ApiRequestModels;
using WebApplication.Data.Models;

namespace WebApplication.Data.Interfaces
{
    public interface ICarVariant
    {
        Task<CarVariant> FindById(int id);

        Task<IEnumerable<CarVariant>> GetWithFilter(ModelsApiRequest request);
    }
}
