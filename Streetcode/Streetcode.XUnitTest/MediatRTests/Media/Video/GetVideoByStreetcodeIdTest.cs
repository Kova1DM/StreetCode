﻿using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using Moq;
using Streetcode.BLL.DTO.Media;
using Streetcode.BLL.MediatR.Media.Video.GetByStreetcodeId;
using Streetcode.DAL.Entities.Media;
using Streetcode.DAL.Repositories.Interfaces.Base;
using System.Linq.Expressions;
using Xunit;

namespace Streetcode.XUnitTest.MediatRTests.Media.Videos;

public class GetVideoByStreetcodeIdTest
{
    private Mock<IRepositoryWrapper> _mockRepository;
    private Mock<IMapper> _mockMapper;

    public GetVideoByStreetcodeIdTest()
    {
        _mockRepository = new Mock<IRepositoryWrapper>();
        _mockMapper = new Mock<IMapper>();
    }

    [Theory]
    [InlineData(1)]
    public async Task ShouldReturnSuccessfully_ExistingId(int streetcodeId)
    {
        //Arrange
        _mockRepository.Setup(x => x.VideoRepository
            .GetFirstOrDefaultAsync(
               It.IsAny<Expression<Func<Video, bool>>>(),
                It.IsAny<Func<IQueryable<Video>,
                IIncludableQueryable<Video, object>>>()))
            .ReturnsAsync(new Video()
            {
                Id = streetcodeId
            });

        _mockMapper
            .Setup(x => x
            .Map<VideoDTO>(It.IsAny<Video>()))
            .Returns(new VideoDTO { Id = streetcodeId });

        //Act
        var handler = new GetVideoByStreetcodeIdHandler(_mockRepository.Object, _mockMapper.Object);

        var result = await handler.Handle(new GetVideoByStreetcodeIdQuery(streetcodeId), CancellationToken.None);

        //Assert
        Assert.Multiple(
            () => Assert.NotNull(result),
            () => Assert.True(result.IsSuccess),
            () => Assert.Equal(result.Value.Id, streetcodeId)
        );
    }

    [Theory]
    [InlineData(1)]
    public async Task ShouldThrowError_IdNotExist(int streetcodeId)
    {
        //Arrange
        _mockRepository.Setup(x => x.VideoRepository
            .GetFirstOrDefaultAsync(
               It.IsAny<Expression<Func<Video, bool>>>(),
                It.IsAny<Func<IQueryable<Video>,
                IIncludableQueryable<Video, object>>>()))
            .ReturnsAsync((Video)null);

        _mockMapper
            .Setup(x => x
            .Map<VideoDTO>(It.IsAny<Video>()))
            .Returns((DAL.Entities.Streetcode.TextContent.Fact video) =>
            {
                return new VideoDTO { Id = video.Id };
            });

        //Act
        var handler = new GetVideoByStreetcodeIdHandler(_mockRepository.Object, _mockMapper.Object);

        var result = await handler.Handle(new GetVideoByStreetcodeIdQuery(streetcodeId), CancellationToken.None);

        //Assert
        Assert.Multiple(
            () => Assert.NotNull(result),
            () => Assert.True(result.IsFailed),
            () => Assert.Equal($"Cannot find any video by the streetcode id: {streetcodeId}", result.Errors.First().Message)
        );
    }

    [Theory]
    [InlineData(1)]
    public async Task ShouldReturnSuccessfully_CorrectType(int streetcodeId)
    {
        //Arrange
        _mockRepository.Setup(x => x.VideoRepository
            .GetFirstOrDefaultAsync(
               It.IsAny<Expression<Func<Video, bool>>>(),
                It.IsAny<Func<IQueryable<Video>,
                IIncludableQueryable<Video, object>>>()))
            .ReturnsAsync(new Video()
            {
                Id = streetcodeId
            });

        _mockMapper
             .Setup(x => x
             .Map<VideoDTO>(It.IsAny<Video>()))
             .Returns(new VideoDTO { Id = streetcodeId });

        //Act
        var handler = new GetVideoByStreetcodeIdHandler(_mockRepository.Object, _mockMapper.Object);

        var result = await handler.Handle(new GetVideoByStreetcodeIdQuery(streetcodeId), CancellationToken.None);

        //Assert
        Assert.Multiple(
            () => Assert.NotNull(result.ValueOrDefault),
            () => Assert.IsType<VideoDTO>(result.ValueOrDefault)
        );
    }
}