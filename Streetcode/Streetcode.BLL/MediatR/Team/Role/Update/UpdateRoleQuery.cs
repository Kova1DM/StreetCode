using FluentResults;
using MediatR;
using Streetcode.BLL.DTO.Team;

namespace Streetcode.BLL.MediatR.Team.Update
{
    public record UpdateRoleQuery(RoleDTO role) : IRequest<Result<RoleDTO>>;
}
