using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Data.ApiRequestModels;
using WebApplication.Data.Interfaces;
using WebApplication.Data.Models;

namespace WebApplication.Data.Repositories
{
    public class CarVariantRepository : ICarVariant
    {
        private readonly AppDBContent _appDBContent;
        public CarVariantRepository(AppDBContent appDBContent)
        {
            _appDBContent = appDBContent;
        }

        private IQueryable<CarVariant> All => _appDBContent.CarVariant.Include(c => c.CarTrim).Include(c => c.CarTrim.CarModel);

        public async Task<CarVariant> FindById(int id)
        {
            return await All.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<CarVariant>> GetWithFilter(ModelsApiRequest request)
        {
            IQueryable<CarVariant> variants = All;

            if (request.Brands != null) {
                variants = variants.Where(q => request.Brands.Contains(q.CarTrim.CarModel.BrandName));
            }
            if (request.Engines != null) {
                variants = variants.Where(q => request.Engines.Contains(q.Engine));
            }
            if (request.Years != null) {
                variants = variants.Where(q => request.Years.Contains(q.Year));
            }
            if (request.FuelTypes != null) {
                variants = variants.Where(q => request.FuelTypes.Contains((FuelTypes)q.FuelType));
            }
            if (request.GearTypes != null) {
                variants = variants.Where(q => request.GearTypes.Contains((GearTypes)q.GearType));
            }

            List<CarVariant> models = await variants.ToListAsync();
            return models;
        }
    }
}