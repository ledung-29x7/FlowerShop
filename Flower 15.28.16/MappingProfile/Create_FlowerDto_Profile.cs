using AutoMapper;
using Flower.Areas.Dtos;
using Flower.Areas.Manager.Models;

namespace Flower.MappingProfile
{
    public class Create_FlowerDto_Profile : Profile
    {
        public Create_FlowerDto_Profile() 
        {
            CreateMap<CreateFlowerDto, Flowers>();
            CreateMap<Flowers, CreateFlowerDto>();

            CreateMap<UpdateFlowerDto, Flowers>();
            CreateMap<Flowers, UpdateFlowerDto>();

        }
    }
}
