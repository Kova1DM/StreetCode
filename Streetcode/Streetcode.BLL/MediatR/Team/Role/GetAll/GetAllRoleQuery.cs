using FluentResults;
using MediatR;
using Streetcode.BLL.DTO.Team;

namespace Streetcode.BLL.MediatR.Team.GetAll
{
    public record GetAllRoleQuery : IRequest<Result<IEnumerable<RoleDTO>>>;
}
