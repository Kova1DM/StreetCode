using AutoMapper;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Streetcode.BLL.DTO.Team;
using Streetcode.BLL.Interfaces.Logging;
using Streetcode.DAL.Repositories.Interfaces.Base;

namespace Streetcode.BLL.MediatR.Team.GetAll
{
    public class GetAllRoleHandler : IRequestHandler<GetAllRoleQuery, Result<IEnumerable<RoleDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly ILoggerService _logger;

        public GetAllRoleHandler(IRepositoryWrapper repositoryWrapper, IMapper mapper, ILoggerService logger)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<IEnumerable<RoleDTO>>> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
        {
            var role = await _repositoryWrapper
                .RoleRepository
                .GetAllAsync(include: x => x.Include(x => x.TeamMember));

            if (role is null)
            {
                const string errorMsg = $"Cannot find any role";
                _logger.LogError(request, errorMsg);
                return Result.Fail(new Error(errorMsg));
            }

            return Result.Ok(_mapper.Map<IEnumerable<RoleDTO>>(role));
        }
    }
}