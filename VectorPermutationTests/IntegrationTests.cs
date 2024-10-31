using Microsoft.AspNetCore.Mvc.Testing;
using VectorApi;

namespace VectorPermutationTests
{
    public class IntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public IntegrationTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task NextPermutationEndpoint_ShouldReturnSuccess()
        {
            var vectorData = System.Text.Json.JsonSerializer.Serialize("{\"vector\": [0]}");
            HttpContent content = new StringContent(vectorData, encoding: System.Text.Encoding.UTF8, mediaType: "application/json");

            var response = await _client.PostAsync("/vector", content);
            response.EnsureSuccessStatusCode();
        }
    }
}
