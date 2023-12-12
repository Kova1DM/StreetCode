﻿using Newtonsoft.Json;
using Streetcode.BLL.DTO.AdditionalContent.Subtitles;
using Streetcode.BLL.DTO.AdditionalContent.Tag;
using Streetcode.BLL.DTO.Analytics.Update;
using Streetcode.BLL.DTO.Media.Art;
using Streetcode.BLL.DTO.Media.Audio;
using Streetcode.BLL.DTO.Media.Images;
using Streetcode.BLL.DTO.Media.Video;
using Streetcode.BLL.DTO.Partners.Update;
using Streetcode.BLL.DTO.Sources.Update;
using Streetcode.BLL.DTO.Streetcode.RelatedFigure;
using Streetcode.BLL.DTO.Streetcode.TextContent.Fact;
using Streetcode.BLL.DTO.Streetcode.Update;
using Streetcode.BLL.DTO.Timeline.Update;
using Streetcode.BLL.DTO.Toponyms;
using Streetcode.DAL.Entities.Streetcode;
using Streetcode.XIntegrationTest.ControllerTests.Utils;
using Streetcode.XIntegrationTest.ControllerTests.Utils.BeforeAndAfterTestAtribute.Streetcode;
using System.Net;
using Xunit;

namespace Streetcode.XIntegrationTest.ControllerTests.Streetcode
{
    public class StreetcodeControllerTests :
        BaseControllerTests, IClassFixture<CustomWebApplicationFactory<Program>>
    {
        public StreetcodeControllerTests(CustomWebApplicationFactory<Program> factory)
            : base(factory, "/api/Streetcode")
        {

        }

        [Fact]
        [ExtractTestStreetcode]
        public async Task Update_ReturnSuccessStatusCode()
        {
            StreetcodeContent expectedStreetcode = ExtractTestStreetcode.StreetcodeForTest;

            var updateStreetCodeDTO = this.CreateMoqStreetCodeDTO(expectedStreetcode.Id);
            var response = await this.client.UpdateAsync(updateStreetCodeDTO);

            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        [ExtractTestStreetcode]
        public async Task Update_ChangesTitleAndTransliterationUrl()
        {
            StreetcodeContent expectedStreetcode = ExtractTestStreetcode.StreetcodeForTest;

            var updateStreetCodeDTO = this.CreateMoqStreetCodeDTO(expectedStreetcode.Id);
            await this.client.UpdateAsync(updateStreetCodeDTO);

            var responseGetByIdUpdated = await client.GetByIdAsync(expectedStreetcode.Id);
            var responseContent = JsonConvert.DeserializeObject<StreetcodeContent>(responseGetByIdUpdated.Content);

            Assert.Multiple(() =>
            {
                Assert.Equal(updateStreetCodeDTO.Title, responseContent.Title);
                Assert.Equal(updateStreetCodeDTO.TransliterationUrl, responseContent.TransliterationUrl);
            });
        }

        [Fact]
        [ExtractTestStreetcode]
        public async Task Update_WithIncorrectId_ReturnsBadRequest()
        {

            StreetcodeContent expectedStreetcode = ExtractTestStreetcode.StreetcodeForTest;
            var updateStreetCodeDTO = this.CreateMoqStreetCodeDTO(expectedStreetcode.Id + 1);
            var response = await this.client.UpdateAsync(updateStreetCodeDTO);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        [ExtractTestStreetcode]
        public async Task Update_WithInvalidData_ReturnsBadRequest()
        {
            StreetcodeContent expectedStreetcode = ExtractTestStreetcode.StreetcodeForTest;
            var updateStreetCodeDTO = this.CreateMoqStreetCodeDTO(expectedStreetcode.Id);
            updateStreetCodeDTO.Title = String.IsNullOrEmpty; // Invalid data
            var response = await this.client.UpdateAsync(updateStreetCodeDTO);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        private StreetcodeUpdateDTO CreateMoqStreetCodeDTO(int id)
        {
            return new StreetcodeUpdateDTO
            {
                Id = id,
                Title = "New Title",
                TransliterationUrl = "new-transliteration-url",
                Tags = new List<StreetcodeTagUpdateDTO>(),
                Facts = new List<FactUpdateDto>(),
                Audios = new List<AudioUpdateDTO>(),
                Images = new List<ImageUpdateDTO>(),
                Videos = new List<VideoUpdateDTO>(),
                Partners = new List<PartnersUpdateDTO>(),
                Toponyms = new List<StreetcodeToponymUpdateDTO>(),
                Subtitles = new List<SubtitleUpdateDTO>(),
                DateString = "20 травня 2023",
                TimelineItems = new List<TimelineItemCreateUpdateDTO>(),
                RelatedFigures = new List<RelatedFigureUpdateDTO>(),
                StreetcodeArts = new List<StreetcodeArtCreateUpdateDTO>(),
                StatisticRecords = new List<StatisticRecordUpdateDTO>(),
                StreetcodeCategoryContents = new List<StreetcodeCategoryContentUpdateDTO>(),
            };
        }
    }
}
