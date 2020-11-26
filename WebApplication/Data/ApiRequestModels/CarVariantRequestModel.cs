using System.Collections.Generic;
using WebApplication.Data.Models;

namespace WebApplication.Data.ApiRequestModels
{
    public class ModelsApiRequest
    {
        public List<GearTypes> GearTypes { get; set; }
        public List<FuelTypes> FuelTypes { get; set; }
        public List<string> Brands { get; set; }
        public List<int> Years { get; set; }
        public List<string> Engines { get; set; }
    }
}
