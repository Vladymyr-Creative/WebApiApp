using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApplication.Data.ApiRequestModels;
using WebApplication.Data.Interfaces;

namespace WebApplication.Controllers
{
    [ApiController]
    [ApiKeyAuth]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class BankLoanController : ControllerBase
    {
        private readonly IBankLoan _bankLoan;
        private readonly ILogger<BankLoanController> _logger;

        public BankLoanController(
            IBankLoan bankLoan,
            ILogger<BankLoanController> logger
            )
        {
            _bankLoan = bankLoan;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromQuery] BankLoanApiRequest request)
        {
            _logger.LogInformation($"Query with params: {JsonConvert.SerializeObject(request)}");
            var response = await _bankLoan.ApplyBankLoanAsync(request);

            if (response == null) {
                _logger.LogWarning($"VariantId: {request.VariantId} - NotFound.");
                return NotFound();
            }
            string responseString = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode) {
                _logger.LogWarning(responseString);
                HttpContext.Response.StatusCode = (int)response.StatusCode;
                return new JsonResult(JsonConvert.DeserializeObject<JObject>(responseString));
            }

            return new JsonResult(JsonConvert.DeserializeObject<JObject>(responseString));
        }
    }
}
