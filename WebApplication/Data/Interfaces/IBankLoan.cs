using System.Net.Http;
using System.Threading.Tasks;
using WebApplication.Data.ApiRequestModels;

namespace WebApplication.Data.Interfaces
{
    public interface IBankLoan
    {    
        Task<HttpResponseMessage> ApplyBankLoanAsync(BankLoanApiRequest request);
    }
}
