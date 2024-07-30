using AutoMapper;
using medic_api.Models.DTOs;
using medic_api.Models.Domain;
namespace medic_api.Mappings
{
    public class AutomapperProfiles:Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<User, UsersDTO>().ReverseMap();
            CreateMap<User, UsersDetailsDTO>().ReverseMap();
            CreateMap<User, RegisterUserDTO>().ReverseMap();
        }
    }
}
