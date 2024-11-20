using AutoMapper;
using Flower.Areas.Dtos;
using Flower.Areas.Manager.Models;

namespace Flower.MappingProfile
{
    public class Flower_Profile : Profile
    {
        public Flower_Profile() 
        {
            CreateMap<Flowers, FlowerDetailDto>();
            CreateMap<FlowerDetailDto, Flowers>();
            CreateMap<UpdateFlowerDto, Flowers>();
            CreateMap<Flowers, UpdateFlowerDto>();

            CreateMap<FlowerWithImagesDto, FlowerDetailDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FlowerName))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.FlowerDescription))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.FlowerPrice))
            .ForMember(dest => dest.Occasion_id, opt => opt.MapFrom(src => src.OccasionId))
            .ForMember(dest => dest.Stock, opt => opt.MapFrom(src => src.FlowerStock))
            .ForMember(dest => dest.Images, opt => opt.Ignore()); // Xử lý thủ công danh sách Images

            CreateMap<FlowerWithImagesDto, ImageDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ImageName))
                .ForMember(dest => dest.Base64, opt => opt.MapFrom(src => src.ImageBase64));

        }
    }
}
