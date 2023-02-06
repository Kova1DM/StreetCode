﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Streetcode.BLL.DTO.Media;
using Streetcode.BLL.DTO.Media.Images;
using Streetcode.XIntegrationTest.ControllerTests.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Streetcode.XIntegrationTest.ControllerTests.Media
{
    public class AudioControllerTests:BaseControllerTests, IClassFixture<CustomWebApplicationFactory<Program>>
    {
        string secondPartUrl = "/api/Audio";
        public AudioControllerTests(CustomWebApplicationFactory<Program> factory) : base(factory)
        {

        }

        [Fact]
        public async Task AudioControllerTests_GetAllSuccessfulResult()
        {
            var responce = await _client.GetAsync($"{secondPartUrl}/GetAll");
            Assert.True(responce.IsSuccessStatusCode);
            var returnedValue = await responce.Content.ReadFromJsonAsync<IEnumerable<AudioDTO>>();

            responce.EnsureSuccessStatusCode(); 
            Assert.NotNull(returnedValue);

        }
        [Fact]
        public async Task AudioControllerTests_GetByIdSuccessfulResult()
        {
            int id = 1;
            var responce = await _client.GetAsync($"{secondPartUrl}/getById/{id}");

            var returnedValue = await responce.Content.ReadFromJsonAsync<AudioDTO>();

            Assert.Equal(id, returnedValue?.Id);
            Assert.True(responce.IsSuccessStatusCode);
        }

        [Fact]
        public async Task AudioControllerTests_GetByIdIncorectBadRequest()
        {
            int id = -100;
            var responce = await _client.GetAsync($"{secondPartUrl}/getById/{id}");

            Assert.Equal(System.Net.HttpStatusCode.BadRequest, responce.StatusCode);
            Assert.False(responce.IsSuccessStatusCode);
        }



        [Theory]
        [InlineData(1)]
        public async Task AudioControllerTests_GetByStreetcodeIdSuccessfulResult(int streetcodeId)
        {
            var responce = await _client.GetAsync($"{secondPartUrl}/getByStreetcodeId/{streetcodeId}");
            var returnedValue = await responce.Content.ReadFromJsonAsync<AudioDTO>();

            Assert.NotNull(returnedValue);
            Assert.True(returnedValue.StreetcodeId==streetcodeId);
            Assert.True(responce.IsSuccessStatusCode);
        }
        [Fact]
        public async Task AudioControllerTests_GetByStreetcodeIdIncorrectBadRequest()
        {
            int streetcodeId = -100;
            var responce = await _client.GetAsync($"{secondPartUrl}/getByStreetcodeId/{streetcodeId}");
           
         
            Assert.False(responce.IsSuccessStatusCode);
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, responce.StatusCode);
        }



    }

}
