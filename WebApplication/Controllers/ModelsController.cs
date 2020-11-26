using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication.Data.Interfaces;
using WebApplication.Data.Models;
using WebApplication.Data.ApiRequestModels;
using WebApplication.Data.ApiResponseModels;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebApplication.Controllers
{
    [ApiController]
    [ApiKeyAuth]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ModelsController : ControllerBase
    {
        private readonly ICarVariant _context;
        private readonly ILogger<ModelsController> _logger;

        public ModelsController(
            ICarVariant carVariants, 
            ILogger<ModelsController> logger
            )
        {
            _context = carVariants;
            _logger = logger;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id, [FromQuery] ModelsApiRequest request)
        {
            _logger.LogInformation($"Query with params: id: {id}, {JsonConvert.SerializeObject(request)}");
            var model = await _context.FindById(id);
            if (model == null) {
                return NotFound();
            }
            return GetResponseJsonResult(new List<CarVariant> { model });
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromQuery] ModelsApiRequest request)
        {
            _logger.LogInformation($"Query with params: {JsonConvert.SerializeObject(request)}");
            var models = await _context.GetWithFilter(request);
            if (models == null) {
                return NotFound();
            }
            return GetResponseJsonResult(models);
        }

        private JsonResult GetResponseJsonResult(IEnumerable<CarVariant> modelsList)
        {
            var result = new ModelsApiResponse() {
                List = modelsList,
                Total = modelsList.Count()
            };

            return new JsonResult(result);
        }
    }   
}
