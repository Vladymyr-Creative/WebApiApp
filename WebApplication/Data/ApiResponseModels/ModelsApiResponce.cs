using System.Collections.Generic;
using WebApplication.Data.Models;

namespace WebApplication.Data.ApiResponseModels
{
    class ModelsApiResponse
    {
        public int Total { get; set; }
        public IEnumerable<CarVariant> List { get; set; }
    }
}
