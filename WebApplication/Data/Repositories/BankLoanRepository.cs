using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WebApplication.Data.ApiRequestModels;
using WebApplication.Data.Interfaces;

namespace WebApplication.Data.Repositories
{
    public class BankLoanRepository : IBankLoan
    {
        private readonly IConfiguration _configuration;
        private readonly AppDBContent _appDBContent;

        public BankLoanRepository(AppDBContent appDBContent, IConfiguration configuration)
        {
            _appDBContent = appDBContent;
            _configuration = configuration;
        }

        public async Task<HttpResponseMessage> ApplyBankLoanAsync(BankLoanApiRequest request)
        {
            string apiKeyName = "x-api-key";
            HttpResponseMessage response = null;
            var carVariant = await _appDBContent.CarVariant.FirstOrDefaultAsync(c => c.Id == request.VariantId);
            if (carVariant == null || !carVariant.IsAvailable) {
                return response;
            }

            using (var client = new HttpClient()) {
                client.BaseAddress = new Uri(_configuration.GetValue<string>("bankLoanUrl"));
                client.DefaultRequestHeaders.Add("Accept", "aplication/json");
                client.DefaultRequestHeaders.Add(apiKeyName, _configuration.GetValue<string>(apiKeyName));

                response = await client.GetAsync($"/api/Loan?CarPrice={carVariant.Price}&UpFrontPayment={request.DownPayment}&BankLoanTerm={request.Duration}&CarBuildYear={carVariant.Year}");
            }
            return response;
        }

    }
}
