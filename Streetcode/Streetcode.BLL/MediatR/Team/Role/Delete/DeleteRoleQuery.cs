using FluentResults;
using MediatR;
using Streetcode.BLL.DTO.Partners;
using Streetcode.BLL.DTO.Team;

namespace Streetcode.BLL.MediatR.Team.Delete
{
    public record DeleteRoleQuery(int id) : IRequest<Result<RoleDTO>>;
}