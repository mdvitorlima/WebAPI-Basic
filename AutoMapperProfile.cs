using AutoMapper;
using BasicAPI.Entities;

namespace BasicAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

        }
    }
}
