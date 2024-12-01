using AutoMapper;
using Flower.Areas.Admin.Models;
using Flower.Areas.Dtos;
using Flower.Areas.Manager.Models;

namespace Flower.MappingProfile
{
    public class StoreDto_Store : Profile
    {
        public StoreDto_Store() 
        {
            CreateMap<CreateStoreDto, Store>();
            CreateMap<Store, CreateStoreDto>();

            CreateMap<UpdateStoreDto, Store>();
            CreateMap<Store, UpdateStoreDto>();

        }
    }
}
