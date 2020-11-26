using AutoMapper;
using WebApplication.Data.ApiRequestModels;
using WebApplication.Data.Models;

namespace WebApplication.AutoMapper
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<OrderRequestModel, Customer>()
                .ForMember("Name", opt => opt.MapFrom(c => c.CustomerName))
                .ForMember("Email", opt => opt.MapFrom(c => c.CustomerEmail))
                .ForMember("Phone", opt => opt.MapFrom(c => c.CustomerPhone)
            );
        }
    }

}