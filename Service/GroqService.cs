using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.Extensions.Options;
using SmartMarketplace.Config;
using SmartMarketplace.DTO;
using SmartMarketplace.Service.Interface;

namespace SmartMarketplace.Service;

public class GroqService : IGroqService
{
    private readonly HttpClient _httpClient;
    private readonly GroqOptions _options;

    // Make constructor public
    public GroqService(HttpClient httpClient, IOptions<GroqOptions> options)
    {
        _httpClient = httpClient;
        _options = options.Value;
    }

    // PUBLIC async method to call the Groq API
    public async Task<AiResponseDto> CallGroqAsync(PromtRequest req)
    {
        var apiKey = _options.ApiKey;
        var baseUrl = _options.BaseUrl;

        var requestBody = GetGroqRequestPromt(req);
        var jsonString = requestBody.ToJsonString();

        var httpRequest = new HttpRequestMessage(HttpMethod.Post, baseUrl);
        httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
        httpRequest.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

        var response = await _httpClient.SendAsync(httpRequest);

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new ApplicationException($"Groq API error: {response.StatusCode}, Content: {errorContent}");
        }

        var responseContent = await response.Content.ReadAsStringAsync();
        GroqResponseDto parsedResponse = JsonSerializer.Deserialize<GroqResponseDto>(responseContent);
        AiResponseDto airesponse = new AiResponseDto
        {
          message = parsedResponse.Choices.First().Message.Content
        };
        return airesponse;
    }

    // Generates the prompt request body
    public JsonObject GetGroqRequestPromt(PromtRequest promt)
    {
        var name = promt.text;
        var systemContent = @$"I will give you a name and then you will return hi ""{name}"" in JSON format following this strict format
        {{
          text: 'hi {name}'
        }}";

        var request = new JsonObject
        {
            ["messages"] = new JsonArray
            {
                new JsonObject
                {
                    ["role"] = "system",
                    ["content"] = systemContent
                },
                new JsonObject
                {
                    ["role"] = "user",
                    ["content"] = name
                }
            },
            ["model"] = "llama-3.1-8b-instant",
            ["temperature"] = 1,
            ["max_completion_tokens"] = 1024,
            ["top_p"] = 1,
            ["stream"] = false,
            ["response_format"] = new JsonObject
            {
                ["type"] = "json_object"
            },
            ["stop"] = null
        };

        return request;
    }
}
