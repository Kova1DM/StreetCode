﻿using AutoMapper;
using FluentResults;
using MediatR;
using Streetcode.BLL.DTO.Media.Images;
using Streetcode.DAL.Repositories.Interfaces.Base;

namespace Streetcode.BLL.MediatR.Media.Art.GetByStreetcodeId
{
    public class GetArtByStreetcodeIdQueryHandler : IRequestHandler<GetArtByStreetcodeIdQuery, Result<IEnumerable<ArtDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public GetArtByStreetcodeIdQueryHandler(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<ArtDTO>>> Handle(GetArtByStreetcodeIdQuery request, CancellationToken cancellationToken)
        {
            if ((await _repositoryWrapper.StreetcodeRepository.GetFirstOrDefaultAsync(s => s.Id == request.streetcodeId)) is null)
            {
                return Result.Fail(
                    new Error($"Cannot find a arts by a streetcode id: {request.streetcodeId}, because such streetcode doesn`t exist"));
            }

            var art = await _repositoryWrapper.ArtRepository
                .GetAllAsync(f => f.StreetcodeArts.Any(s => s.StreetcodeId == request.streetcodeId));

            if (art is null)
            {
                return Result.Fail(new Error($"Cannot find an art with corresponding streetcode id: {request.streetcodeId}"));
            }

            var artDto = _mapper.Map<IEnumerable<ArtDTO>>(art);
            return Result.Ok(artDto);
        }
    }
}
