using AutoMapper;
using Flower.Areas.Admin.Models;
using Flower.Areas.Dtos;

namespace Flower.MappingProfile
{
    public class OccasionDto_Occasion : Profile
    {
        public OccasionDto_Occasion() 
        {
            CreateMap<Occasion, OccasionDto>();

            CreateMap<OccasionDto, Occasion>();
        }
    }
}
