using CMS.WebApi;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;
using System.Text.Json;

namespace CMS.IntegrationTest.Models;

public class CMSFixture : IDisposable
{
    private readonly HttpClient _httpClient;
    private readonly string _url = "https://localhost:7096/api";

    public CMSFixture()
    {
        var webApplicationFactory = new WebApplicationFactory<Program>();
        var options = new WebApplicationFactoryClientOptions
        {
            BaseAddress = new Uri(_url)
        };

        _httpClient = webApplicationFactory.CreateClient(options);
    }

    public async Task<TResponse> Act_PostAsync<TRequest, TResponse>(string endpoint, TRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync($"{_httpClient.BaseAddress}/{endpoint}", request);
        var result = await response.Content.ReadAsStringAsync();
        var responseObj = JsonSerializer.Deserialize<TResponse>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return responseObj!;
    }

    public void Dispose()
    {
    }
}
