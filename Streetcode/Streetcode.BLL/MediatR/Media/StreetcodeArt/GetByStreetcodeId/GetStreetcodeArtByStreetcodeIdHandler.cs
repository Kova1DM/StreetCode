﻿using AutoMapper;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Streetcode.BLL.DTO.Media.Images;
using Streetcode.DAL.Repositories.Interfaces.Base;

namespace Streetcode.BLL.MediatR.Media.StreetcodeArt.GetByStreetcodeId
{
    public class GetStreetcodeArtByStreetcodeIdHandler : IRequestHandler<GetStreetcodeArtByStreetcodeIdQuery, Result<IEnumerable<StreetcodeArtDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public GetStreetcodeArtByStreetcodeIdHandler(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<StreetcodeArtDTO>>> Handle(GetStreetcodeArtByStreetcodeIdQuery request, CancellationToken cancellationToken)
        {
            var art = await _repositoryWrapper
            .StreetcodeArtRepository
            .GetAllAsync(
                predicate: s => s.StreetcodeId == request.StreetcodeId,
                include: art => art
                    .Include(a => a.Art)
                    .Include(i => i.Art.Image) !);

            if (art is null)
            {
                return Result.Fail(new Error($"Cannot find an art with corresponding streetcode id: {request.StreetcodeId}"));
            }

            var artDto = _mapper.Map<IEnumerable<StreetcodeArtDTO>>(art);
            return Result.Ok(artDto);
        }
    }
}
