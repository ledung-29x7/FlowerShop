using AutoMapper;
using Flower.Areas.Auther.Models;
using Flower.Areas.Dtos;

namespace Flower.MappingProfile
{
    public class Regiter_User_Profile : Profile
    {
        public Regiter_User_Profile()
        {
            CreateMap<RegisterDto, User>()
                .ForMember(dest => dest.Password_hash, opt => opt.Ignore());
        }
    }
}
