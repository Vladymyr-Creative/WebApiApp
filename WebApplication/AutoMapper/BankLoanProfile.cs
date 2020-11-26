using AutoMapper;
using WebApplication.Data.ApiRequestModels;

namespace WebApplication.AutoMapper
{
    public class BankLoanProfile : Profile
    {
        public BankLoanProfile()
        {
            CreateMap<OrderRequestModel, BankLoanApiRequest>()
                .ForMember("Duration", opt => opt.MapFrom(c => c.BankLoanDuration))
                .ForMember("DownPayment", opt => opt.MapFrom(c => c.BankLoanDownPayment));
        }
    }

}


