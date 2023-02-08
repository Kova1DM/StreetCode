﻿using AutoMapper;
using Moq;
using Streetcode.BLL.DTO.Streetcode.Types;
using Streetcode.BLL.MediatR.Streetcode.Streetcode.Update;
using Streetcode.DAL.Entities.Streetcode;
using Streetcode.DAL.Repositories.Interfaces.Base;
using Xunit;

namespace Streetcode.XUnitTest.MediatRTests.StreetCode.Streetcode
{
    public class UpdateStreetcodeHandlerTests
    {
        private readonly Mock<IRepositoryWrapper> _repository;
        private readonly Mock<IMapper> _mapper;
        public UpdateStreetcodeHandlerTests()
        {
            _repository = new Mock<IRepositoryWrapper>();
            _mapper = new Mock<IMapper>();
        }

        [Fact]
        public async Task Handle_ReturnsSuccess()
        {
            var testStreetcode = new StreetcodeContent();
            var testStreetcodeDTO = new EventStreetcodeDTO();

            RepositorySetup(testStreetcode, 1);
            MapperSetup(testStreetcode);

            var handler = new UpdateStreetcodeHandler(_repository.Object, _mapper.Object);

            var result = await handler.Handle(new UpdateStreetcodeCommand(testStreetcodeDTO), CancellationToken.None);

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task Handle_ReturnsMapNullError()
        {
            var testStreetcode = new StreetcodeContent();
            var testStreetcodeDTO = new EventStreetcodeDTO();
            string expectedErrorMessage = "Cannot convert null to Streetcode";

            RepositorySetup(testStreetcode, 1);
            MapperSetup(null);

            var handler = new UpdateStreetcodeHandler(_repository.Object, _mapper.Object);

            var result = await handler.Handle(new UpdateStreetcodeCommand(testStreetcodeDTO), CancellationToken.None);

            Assert.Equal(expectedErrorMessage, result.Errors.Single().Message);
        }

        [Fact]
        public async Task Handle_ReturnsSaveError()
        {
            var testStreetcode = new StreetcodeContent();
            var testStreetcodeDTO = new EventStreetcodeDTO();
            string expectedErrorMessage = "Failed to update a streetcode";

            RepositorySetup(testStreetcode, -1);
            MapperSetup(testStreetcode);

            var handler = new UpdateStreetcodeHandler(_repository.Object, _mapper.Object);

            var result = await handler.Handle(new UpdateStreetcodeCommand(testStreetcodeDTO), CancellationToken.None);

            Assert.Equal(expectedErrorMessage, result.Errors.Single().Message);
        }

        private void RepositorySetup(StreetcodeContent testStreetcode, int saveChangesVariable)
        {
            _repository.Setup(x => x.StreetcodeRepository.Update(testStreetcode));
            _repository.Setup(x => x.SaveChangesAsync()).ReturnsAsync(saveChangesVariable);
        }
        private void MapperSetup(StreetcodeContent testStreetcode)
        {
            _mapper.Setup(x => x.Map<StreetcodeContent>(It.IsAny<object>())).Returns(testStreetcode);
        }
    }
}
