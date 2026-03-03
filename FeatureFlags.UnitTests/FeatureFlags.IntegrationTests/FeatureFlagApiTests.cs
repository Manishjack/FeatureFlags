using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlags.UnitTests.FeatureFlags.IntegrationTests
{
    public class FeatureFlagApiTests : IClassFixture<WebApplicationFactory<Program>> 
    {
        private readonly HttpClient _client; 
        public FeatureFlagApiTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }
        [Fact]
        public async Task CreateFeatureFlag_ThenEvaluate_ReturnsExpectedResult() 
        { 
            var response = await _client.PostAsync("/features?name=TestFeature&defaultState=true", null); 
            response.EnsureSuccessStatusCode(); 
            var evalResponse = await _client.GetAsync("/features/TestFeature/evaluate"); 
            var result = await evalResponse.Content.ReadAsStringAsync(); 
            Assert.Contains("true", result); 
        }
    }
}
