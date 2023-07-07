﻿using AutoMapper;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Streetcode.BLL.DTO.Streetcode;
using Streetcode.BLL.MediatR.Streetcode.Streetcode.GetAllStreetcodesMainPage;
using Streetcode.BLL.SharedResource;
using Streetcode.DAL.Repositories.Interfaces.Base;

namespace Streetcode.BLL.MediatR.Streetcode.Streetcode.GetAllMainPage
{
    public class GetAllStreetcodesMainPageHandler : IRequestHandler<GetAllStreetcodesMainPageQuery,
        Result<IEnumerable<StreetcodeMainPageDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IStringLocalizer<NoSharedResource> _stringLocalizerNo;

        public GetAllStreetcodesMainPageHandler(IRepositoryWrapper repositoryWrapper, IMapper mapper, IStringLocalizer<NoSharedResource> stringLocalizerNo)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
            _stringLocalizerNo = stringLocalizerNo;
        }

        public async Task<Result<IEnumerable<StreetcodeMainPageDTO>>> Handle(GetAllStreetcodesMainPageQuery request, CancellationToken cancellationToken)
        {
            var streetcodes = await _repositoryWrapper.StreetcodeRepository.GetAllAsync(
                predicate: sc => sc.Status == DAL.Enums.StreetcodeStatus.Published,
                include: src => src.Include(item => item.Text).Include(item => item.Images));

            if (streetcodes != null)
            {
                return Result.Ok(_mapper.Map<IEnumerable<StreetcodeMainPageDTO>>(streetcodes));
            }

            return Result.Fail(_stringLocalizerNo["NoStreetcodesExistNow"].Value);
        }
    }
}
