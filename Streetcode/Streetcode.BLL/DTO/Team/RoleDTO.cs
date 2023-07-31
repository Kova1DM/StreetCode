using Streetcode.BLL.DTO.Partners;
using Streetcode.BLL.DTO.Streetcode;

namespace Streetcode.BLL.DTO.Team
{
    public class RoleDTO
    {
        public int Id { get; set; }

        public string RoleName { get; set; }

        public List<TeamMemberDTO> TeamMember { get; set; } = new List<TeamMemberDTO>();
    }
}