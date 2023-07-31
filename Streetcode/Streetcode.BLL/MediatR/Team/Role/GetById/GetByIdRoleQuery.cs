using FluentResults;
using MediatR;
using Streetcode.BLL.DTO.Team;

namespace Streetcode.BLL.MediatR.Team.GetById
{
    public record GetByIdRoleQuery(int Id) : IRequest<Result<RoleDTO>>;
}
