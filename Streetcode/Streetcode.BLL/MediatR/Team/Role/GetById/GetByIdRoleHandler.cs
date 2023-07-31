using AutoMapper;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Streetcode.BLL.DTO.Partners;
using Streetcode.BLL.DTO.Team;
using Streetcode.BLL.Interfaces.Logging;
using Streetcode.BLL.MediatR.Partners.GetById;
using Streetcode.DAL.Repositories.Interfaces.Base;

namespace Streetcode.BLL.MediatR.Team.GetById
{
    public class GetByIdRoleHandler : IRequestHandler<GetByIdRoleQuery, Result<RoleDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly ILoggerService _logger;

        public GetByIdRoleHandler(IRepositoryWrapper repositoryWrapper, IMapper mapper, ILoggerService logger)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<RoleDTO>> Handle(GetByIdRoleQuery request, CancellationToken cancellationToken)
        {
            var role = await _repositoryWrapper
                .RoleRepository
                .GetSingleOrDefaultAsync(
                    predicate: p => p.Id == request.Id,
                    include: x => x.Include(x => x.TeamMember));

            if (role is null)
            {
                string errorMsg = $"Cannot find any role with corresponding id: {request.Id}";
                _logger.LogError(request, errorMsg);
                return Result.Fail(new Error(errorMsg));
            }

            return Result.Ok(_mapper.Map<RoleDTO>(role));
        }
    }
}