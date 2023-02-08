﻿using AutoMapper;
using FluentResults;
using MediatR;
using Streetcode.BLL.DTO.Media.Images;
using Streetcode.DAL.Repositories.Interfaces.Base;

namespace Streetcode.BLL.MediatR.Media.Image.GetByStreetcodeId;

public class GetImageByStreetcodeIdHandler : IRequestHandler<GetImageByStreetcodeIdQuery, Result<IEnumerable<ImageDTO>>>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public GetImageByStreetcodeIdHandler(IRepositoryWrapper repositoryWrapper, IMapper mapper)
    {
        _repositoryWrapper = repositoryWrapper;
        _mapper = mapper;
    }

    public async Task<Result<IEnumerable<ImageDTO>>> Handle(GetImageByStreetcodeIdQuery request, CancellationToken cancellationToken)
    {
        var image = await _repositoryWrapper.ImageRepository
            .GetAllAsync(f => f.Streetcodes.Any(s => s.Id == request.StreetcodeId));

        if (image is null)
        {
            return Result.Fail(new Error($"Cannot find an image with the corresponding streetcode id: {request.StreetcodeId}"));
        }

        var imageDto = _mapper.Map<IEnumerable<ImageDTO>>(image);
        return Result.Ok(imageDto);
    }
}