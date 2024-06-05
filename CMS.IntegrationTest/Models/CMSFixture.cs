using CMS.Application.Dtos.Users;
using CMS.WebApi;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace CMS.IntegrationTest.Models;

public class CMSFixture : IDisposable
{
    private readonly HttpClient _httpClient;
    private readonly string _url = "https://localhost:7096/api";
    private string _token = string.Empty;

    public CMSFixture()
    {
        var webApplicationFactory = new WebApplicationFactory<Program>();
        var options = new WebApplicationFactoryClientOptions
        {
            BaseAddress = new Uri(_url)
        };

        _httpClient = webApplicationFactory.CreateClient(options);

        if (_token == string.Empty)
            GenerateToken().Wait();

        else
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
    }

    private async Task GenerateToken()
    {
        var loginEndpoint = "Users/login";
        var loginRequest = new LoginDto
        {
            UserName = "admin@cms.com",
            Password = "Admin123!"
        };

        var response = await _httpClient.PostAsJsonAsync($"{_httpClient.BaseAddress}/{loginEndpoint}", loginRequest);
        response.EnsureSuccessStatusCode();

        _token = await response.Content.ReadAsStringAsync();

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
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
