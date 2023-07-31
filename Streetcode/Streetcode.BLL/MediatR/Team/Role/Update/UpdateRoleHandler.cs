using AutoMapper;
using FluentResults;
using MediatR;
using Streetcode.BLL.DTO.Team;
using Streetcode.BLL.Interfaces.Logging;
using Streetcode.DAL.Entities.Team;
using Streetcode.DAL.Repositories.Interfaces.Base;

namespace Streetcode.BLL.MediatR.Team.Update
{
    public class UpdateRoleHandler : IRequestHandler<UpdateRoleQuery, Result<RoleDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repository;
        private readonly ILoggerService _logger;

        public UpdateRoleHandler(IMapper mapper, IRepositoryWrapper repository, ILoggerService logger)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
        }

        public async Task<Result<RoleDTO>> Handle(UpdateRoleQuery request, CancellationToken cancellationToken)
        {
            var role = _mapper.Map<Role>(request.role);
            try
            {
                _repository.RoleRepository.Update(role);
                _repository.SaveChanges();
                return Result.Ok(_mapper.Map<RoleDTO>(role));
            }
            catch (Exception ex)
            {
                _logger.LogError(request, ex.Message);
                return Result.Fail(ex.Message);
            }
        }
    }
}