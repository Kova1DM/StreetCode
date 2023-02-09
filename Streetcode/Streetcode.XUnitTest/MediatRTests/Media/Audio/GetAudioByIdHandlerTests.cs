﻿using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using Moq;
using Streetcode.BLL.DTO.Media;
using Streetcode.BLL.MediatR.Media.Audio.GetById;
using Streetcode.DAL.Repositories.Interfaces.Base;
using System.Linq.Expressions;
using Xunit;
using Model = Streetcode.DAL.Entities.Media.Audio;

namespace Streetcode.XUnitTest.MediatRTests.Media.Audio
{
    public class GetAudioByIdHandlerTests
    {
        private readonly Mock<IRepositoryWrapper> _repository;
        private readonly Mock<IMapper> _mapper;

        public GetAudioByIdHandlerTests()
        {
            _repository = new Mock<IRepositoryWrapper>();
            _mapper = new Mock<IMapper>();
        }

        [Theory]
        [InlineData(2)]
        public async Task Handle_ExistingId_Succcess(int id)
        {
            var testAudio = new Model() { Id = id };
            var testAudioDTO = new AudioDTO { Id = id };

            RepositorySetup(testAudio);
            MapperSetup(testAudioDTO);

            var handler = new GetAudioByIdHandler(_repository.Object, _mapper.Object);

            var result = await handler.Handle(new GetAudioByIdQuery(id), CancellationToken.None);

            Assert.Equal(id, result.Value.Id);
        }

        [Theory]
        [InlineData(1)]
        public async Task Handle_NonExistingId_ErrorHandling(int id)
        {
            string expectedErrorMessage = $"Cannot find an audio with corresponding id: {id}";

            var testAudioDTO = new AudioDTO { Id = id };

            RepositorySetup(null);
            MapperSetup(testAudioDTO);

            var handler = new GetAudioByIdHandler(_repository.Object, _mapper.Object);

            var result = await handler.Handle(new GetAudioByIdQuery(id), CancellationToken.None);

            Assert.Equal(expectedErrorMessage, result.Errors.First().Message);
        }

        [Theory]
        [InlineData(1)]
        public async Task Handle_ReturnCorrectType(int id)
        {
            var testAudio = new Model() { Id = id };

            var testAudioDTO = new AudioDTO { Id = id };

            RepositorySetup(testAudio);
            MapperSetup(testAudioDTO);

            var handler = new GetAudioByIdHandler(_repository.Object, _mapper.Object);

            var result = await handler.Handle(new GetAudioByIdQuery(id), CancellationToken.None);

            Assert.IsAssignableFrom<AudioDTO>(result.Value);
        }

        private void RepositorySetup(Model audio)
        {
            _repository.Setup(repo => repo.AudioRepository
                .GetFirstOrDefaultAsync(It.IsAny<Expression<Func<Model, bool>>>(), It.IsAny<Func<IQueryable<Model>, IIncludableQueryable<Model, Model>>?>()))
                .ReturnsAsync(audio);
        }

        private void MapperSetup(AudioDTO audioDTO)
        {
            _mapper.Setup(x => x.Map<AudioDTO>(It.IsAny<Model>()))
                .Returns(audioDTO);
        }
    }
}
