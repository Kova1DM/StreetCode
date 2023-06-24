﻿using AutoMapper;
using FluentResults;
using MediatR;
using Streetcode.BLL.Interfaces.Logging;
using Streetcode.DAL.Repositories.Interfaces.Base;

namespace Streetcode.BLL.MediatR.Streetcode.Streetcode.WithIndexExist
{
    public class StreetcodeWithIndexExistHandler : IRequestHandler<StreetcodeWithIndexExistQuery, Result<bool>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly ILoggerService? _logger;

        public StreetcodeWithIndexExistHandler(IRepositoryWrapper repositoryWrapper, IMapper mapper, ILoggerService? logger = null)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<bool>> Handle(StreetcodeWithIndexExistQuery request, CancellationToken cancellationToken)
        {
            var streetcode = await _repositoryWrapper.StreetcodeRepository.GetFirstOrDefaultAsync(s => s.Index == request.index);
            if (streetcode == null)
            {
                _logger?.LogInformation($"StreetcodeWithIndexExistQuery handled successfully");
                return Result.Ok(false);
            }

            _logger?.LogInformation($"StreetcodeWithIndexExistQuery handled successfully");
            return Result.Ok(true);
        }
    }
}
