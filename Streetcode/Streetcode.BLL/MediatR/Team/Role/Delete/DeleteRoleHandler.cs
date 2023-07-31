using AutoMapper;
using FluentResults;
using MediatR;
using Streetcode.BLL.DTO.Partners;
using Streetcode.BLL.DTO.Team;
using Streetcode.BLL.Interfaces.Logging;
using Streetcode.BLL.MediatR.Partners.Delete;
using Streetcode.DAL.Repositories.Interfaces.Base;

namespace Streetcode.BLL.MediatR.Team.Delete
{
    public class DeleteRoleHandler : IRequestHandler<DeleteRoleQuery, Result<RoleDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly ILoggerService _logger;

        public DeleteRoleHandler(IRepositoryWrapper repositoryWrapper, IMapper mapper, ILoggerService logger)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<RoleDTO>> Handle(DeleteRoleQuery request, CancellationToken cancellationToken)
        {
            var role = await _repositoryWrapper.RoleRepository.GetFirstOrDefaultAsync(p => p.Id == request.id);
            if (role == null)
            {
                const string errorMsg = "No role with such id";
                _logger.LogError(request, errorMsg);
                return Result.Fail(errorMsg);
            }
            else
            {
                try
                {
                    _repositoryWrapper.RoleRepository.Delete(role);
                    _repositoryWrapper.SaveChanges();
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
}