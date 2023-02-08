﻿using AutoMapper;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Streetcode.BLL.DTO.Streetcode;
using Streetcode.DAL.Entities.AdditionalContent;
using Streetcode.DAL.Entities.Streetcode;
using Streetcode.DAL.Repositories.Interfaces.Base;

namespace Streetcode.BLL.MediatR.Streetcode.RelatedFigure.GetByStreetcodeId;

public class GetRelatedFiguresByStreetcodeIdHandler : IRequestHandler<GetRelatedFigureByStreetcodeIdQuery, Result<IEnumerable<RelatedFigureDTO>>>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public GetRelatedFiguresByStreetcodeIdHandler(IMapper mapper, IRepositoryWrapper repositoryWrapper)
    {
        _mapper = mapper;
        _repositoryWrapper = repositoryWrapper;
    }

    public async Task<Result<IEnumerable<RelatedFigureDTO>>> Handle(GetRelatedFigureByStreetcodeIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var relatedFigureIds = GetRelatedFigureIdsByStreetcodeId(request.StreetcodeId);

            if (relatedFigureIds is null)
            {
                return Result.Fail(new Error($"Cannot find any related figures by a streetcode id: {request.StreetcodeId}"));
            }

            var relatedFigures = await _repositoryWrapper.StreetcodeRepository
                .GetAllAsync(
                    predicate: sc => relatedFigureIds.Any(id => id == sc.Id),
                    include: scl => scl
                        .Include(sc => sc.Images)
                        .Include(sc => sc.Tags));

            if (relatedFigures is null)
            {
                return Result.Fail(new Error($"Cannot find any related figures by a streetcode id: {request.StreetcodeId}"));
            }

            var mappedRelatedFigures = _mapper.Map<IEnumerable<RelatedFigureDTO>>(relatedFigures);
            return Result.Ok(mappedRelatedFigures);
        }
        catch (ArgumentNullException ex)
        {
            return Result.Fail(new Error(ex.Message));
        }
    }

    private IQueryable<int> GetRelatedFigureIdsByStreetcodeId(int StreetcodeId)
    {
        var observers = _repositoryWrapper.RelatedFigureRepository
            .FindAll(f => f.TargetId == StreetcodeId);

        var targets = _repositoryWrapper.RelatedFigureRepository
            .FindAll(f => f.ObserverId == StreetcodeId);

        if (observers == null || targets == null)
        {
            throw new ArgumentNullException(message: $"Cannot find any related figures by a streetcode id: {StreetcodeId}", innerException: null);
        }

        var observerIds = observers.Select(o => o.ObserverId);

        var targetIds = targets.Select(t => t.TargetId);

        return observerIds.Union(targetIds).Distinct();
    }
}