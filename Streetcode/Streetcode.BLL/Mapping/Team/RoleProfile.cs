using AutoMapper;
using Streetcode.BLL.DTO.Team;
using Streetcode.DAL.Entities.Team;

namespace Streetcode.BLL.Mapping.Team
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleDTO>().ReverseMap();
        }
    }
}
