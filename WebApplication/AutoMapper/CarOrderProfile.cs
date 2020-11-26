using AutoMapper;
using WebApplication.Data.Models;

namespace WebApplication.AutoMapper
{
    public class CarOrderProfile : Profile
    {
        public CarOrderProfile()
        {
            CreateMap<CarVariant, CarOrder>()
                .ForMember("Id", opt => opt.Ignore())
                .ForMember("ModelName", opt => opt.MapFrom(c => c.CarTrim.CarModel.Name))
                .ForMember("TrimName", opt => opt.MapFrom(c => c.CarTrim.Name))
                .ForMember("FuelType", opt => opt.MapFrom(c => c.FuelType))
                .ForMember("GearType", opt => opt.MapFrom(c => c.GearType));
        }
    }

}


