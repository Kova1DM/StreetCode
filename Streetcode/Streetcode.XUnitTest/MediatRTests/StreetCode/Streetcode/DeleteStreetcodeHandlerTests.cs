﻿using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using Moq;
using Streetcode.BLL.Interfaces.Logging;
using Streetcode.BLL.MediatR.Streetcode.Streetcode.Delete;
using Streetcode.DAL.Entities.Streetcode;
using Streetcode.DAL.Repositories.Interfaces.Base;
using System.Linq.Expressions;
using Xunit;

namespace Streetcode.XUnitTest.MediatRTests.StreetCode.Streetcode
{
    public class DeleteStreetcodeHandlerTests
    {   
        private readonly Mock<IRepositoryWrapper> _repository;
        private readonly Mock<ILoggerService> _mockLogger;
        public DeleteStreetcodeHandlerTests()
        {
            _repository = new Mock<IRepositoryWrapper>();
            _mockLogger = new Mock<ILoggerService>();
        }

        [Theory]
        [InlineData(1)]
        public async Task Handle_ReturnsSuccess(int id)
        {   
            // arrange
            var testStreetcode = new StreetcodeContent();
            var relatedFigure = new RelatedFigure();
            int testSaveChangesSuccess = 1;

            RepositorySetup(testStreetcode, relatedFigure, testSaveChangesSuccess);

            var handler = new DeleteStreetcodeHandler(_repository.Object, _mockLogger.Object);
            // act
            var result = await handler.Handle(new DeleteStreetcodeCommand(id), CancellationToken.None);
            // assert
            Assert.True(result.IsSuccess);
        }

        [Theory]
        [InlineData(1)]
        public async Task Handle_ReturnsNullError(int id)
        {   
            // arrange
            string expectedErrorMessage = $"Cannot find a streetcode with corresponding categoryId: {id}";
            int testSaveChangesSuccess = 1;
            var relatedFigure = new RelatedFigure();

            RepositorySetup(null, relatedFigure, testSaveChangesSuccess);

            var handler = new DeleteStreetcodeHandler(_repository.Object, _mockLogger.Object);
            // act
            var result = await handler.Handle(new DeleteStreetcodeCommand(id), CancellationToken.None);
            // assert
            Assert.Equal(expectedErrorMessage, result.Errors.Single().Message);
        }

        [Theory]
        [InlineData(1)]
        public async Task Handle_ReturnsSaveAsyncError(int id)
        {   
            // arrange
            var testStreetcode = new StreetcodeContent();
            string expectedErrorMessage = "Failed to delete a streetcode";
            int testSaveChangesFailed = -1;
            var relatedFigure = new RelatedFigure();

            RepositorySetup(testStreetcode, relatedFigure, testSaveChangesFailed);

            var handler = new DeleteStreetcodeHandler(_repository.Object, _mockLogger.Object);
            // act
            var result = await handler.Handle(new DeleteStreetcodeCommand(id), CancellationToken.None);
            // assert
            Assert.Equal(expectedErrorMessage, result.Errors.Single().Message);
        }

        private void RepositorySetup(StreetcodeContent streetcodeContent, RelatedFigure relatedFigure, int saveChangesVariable)
        {
            _repository.Setup(x => x.StreetcodeRepository.Delete(streetcodeContent));
            _repository.Setup(x => x.SaveChangesAsync()).ReturnsAsync(saveChangesVariable);
            _repository.Setup(x => x.StreetcodeRepository.GetFirstOrDefaultAsync(
                It.IsAny<Expression<Func<StreetcodeContent, bool>>>(),
                It.IsAny<Func<IQueryable<StreetcodeContent>, IIncludableQueryable<StreetcodeContent, object>>>()
            )).ReturnsAsync(streetcodeContent);

            _repository.Setup(x => x.RelatedFigureRepository.Delete(relatedFigure));
            _repository.Setup(x => x.SaveChangesAsync()).ReturnsAsync(saveChangesVariable);
            _repository.Setup(x => x.RelatedFigureRepository.GetFirstOrDefaultAsync(
                It.IsAny<Expression<Func<RelatedFigure, bool>>>(),
                It.IsAny<Func<IQueryable<RelatedFigure>, IIncludableQueryable<RelatedFigure, object>>>()
            )).ReturnsAsync(relatedFigure);
        }

    }
}
