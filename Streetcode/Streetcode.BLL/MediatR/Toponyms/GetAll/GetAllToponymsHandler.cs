﻿using AutoMapper;
using FluentResults;
using MediatR;
using Streetcode.BLL.DTO.Toponyms;
using Microsoft.EntityFrameworkCore;
using Streetcode.DAL.Repositories.Interfaces.Base;

namespace Streetcode.BLL.MediatR.Toponyms.GetAll;

public class GetAllToponymsHandler : IRequestHandler<GetAllToponymsQuery, Result<IEnumerable<ToponymDTO>>>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public GetAllToponymsHandler(IRepositoryWrapper repositoryWrapper, IMapper mapper)
    {
        _repositoryWrapper = repositoryWrapper;
        _mapper = mapper;
    }

    public async Task<Result<IEnumerable<ToponymDTO>>> Handle(GetAllToponymsQuery request, CancellationToken cancellationToken)
    {
        var toponyms = await _repositoryWrapper.ToponymRepository
            .GetAllAsync(include: scl => scl
                    .Include(sc => sc.Coordinate));

        if (toponyms is null)
        {
            return Result.Fail(new Error($"Cannot find any toponym"));
        }

        var toponymDtos = _mapper.Map<IEnumerable<ToponymDTO>>(toponyms);
        return Result.Ok(toponymDtos);
    }
}