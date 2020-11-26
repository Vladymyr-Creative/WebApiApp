using AutoMapper;
using WebApplication.Data.ApiResponseModels;
using WebApplication.Data.Models;

namespace WebApplication.AutoMapper
{
    public class OrderApiResponceProfile : Profile
    {
        public OrderApiResponceProfile()
        {
            CreateMap<CarVariant, OrderApiResponce>()
                .ForMember("Model", opt => opt.MapFrom(c => c.CarTrim.CarModel.Name))
                .ForMember("Brand", opt => opt.MapFrom(c => c.CarTrim.CarModel.BrandName))
                .ForMember("Trim", opt => opt.MapFrom(c => c.CarTrim.Name))
                .ForMember("FuelType", opt => opt.MapFrom(c => c.FuelType.ToString()))
                .ForMember("GearType", opt => opt.MapFrom(c => c.GearType.ToString()));
        }
    }
}


