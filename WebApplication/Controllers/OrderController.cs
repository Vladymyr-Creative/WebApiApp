using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApplication.Data.ApiRequestModels;
using WebApplication.Data.ApiResponseModels;
using WebApplication.Data.Interfaces;
using WebApplication.Data.Models;

namespace WebApplication.Controllers
{
    [ApiController]
    [ApiKeyAuth]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class OrderController : ControllerBase
    {
        private readonly IBankLoan _bankLoan;
        private readonly ICarVariant _variants;
        private readonly ICustomer _customer;
        private readonly ICarOrder _order;
        private readonly ILogger<OrderController> _logger;
        private readonly IMapper _mapper;

        public OrderController(
            ICarVariant carVariants,
            IBankLoan bankLoan,
            ICustomer customer,
            ICarOrder carOrder,
            ILogger<OrderController> logger,
            IMapper mapper
            )
        {
            _customer = customer;
            _bankLoan = bankLoan;
            _order = carOrder;
            _variants = carVariants;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] OrderRequestModel request)
        {
            /*Check if a car variant exists*/
            var carVariant = await _variants.FindById(request.VariantId);
            if (carVariant == null || !carVariant.IsAvailable) {
                _logger.LogWarning($"VariantId: {request.VariantId} - NotFound.");
                return NotFound();
            }

            /*Apply for bank loan*/           
            BankLoanApiRequest bankLoanApiRequest = _mapper.Map<BankLoanApiRequest>(request);

            var bankLoanResponce = await _bankLoan.ApplyBankLoanAsync(bankLoanApiRequest);

            if (bankLoanResponce == null) {
                return BadRequest();
            }
            string responseString = await bankLoanResponce.Content.ReadAsStringAsync();
            HttpContext.Response.StatusCode = (int)bankLoanResponce.StatusCode;
            if (!bankLoanResponce.IsSuccessStatusCode) {                
                return new JsonResult(JsonConvert.DeserializeObject<JObject>(responseString));
            }
            BankLoanApiResponce bankLoan = JsonConvert.DeserializeObject<BankLoanApiResponce>(responseString);

            /*Add Customer*/            
            Customer newCustomer = _mapper.Map<Customer>(request);
            await _customer.Create(newCustomer).ConfigureAwait(false);

            /*Add CarOrder*/            
            CarOrder order = _mapper.Map<CarOrder>(carVariant);

            Customer customer = await _customer.GetByEmail(request.CustomerEmail);
            order.Created = DateTime.Now;
            order.CustomerId = customer.Id;
            order.BankLoanDuration = request.BankLoanDuration;
            order.BankLoanDownPayment = request.BankLoanDownPayment;
            order.BankLoanMonthlyPayment = (decimal)bankLoan.MonthlyPayment;

            await _order.Create(order).ConfigureAwait(false);

            /*building response*/
            OrderApiResponce response = _mapper.Map<OrderApiResponce>(carVariant);
            response.BankLoanDuration = request.BankLoanDuration;
            response.BankLoanDownPament = request.BankLoanDownPayment;
            response.BankLoanMonthlyPayment = (decimal)bankLoan.MonthlyPayment;
            
            return new JsonResult(response);
        }
    }
}
