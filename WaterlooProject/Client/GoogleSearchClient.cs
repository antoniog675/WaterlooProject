using System.Net.Http;
using WaterlooProject.Models;
using WaterlooProject.Shared.Contracts;

namespace WaterlooProject.Client
{
    public class GoogleSearchClient : IGoogleSearchClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly ILogger<GoogleSearchClient> _logger;

        public GoogleSearchClient(HttpClient httpClient, IConfiguration config, ILogger<GoogleSearchClient> logger)
        {
            _httpClient = httpClient;
            _config = config;
            _logger = logger;
        }
        public async Task<SearchResponse> SearchAsyc(string query)
        {
            _logger.LogInformation("In the client, making request to SerpAPI");

            var apiKey = _config["SerpApi:ApiKey"];
            var url = String.Format(_config["SerpApi:SerpApiURL"], query, apiKey);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);

            try
            {
                var httpResponse = await _httpClient.SendAsync(request);
                var organicResult = httpResponse.Content.ReadFromJsonAsync<SearchResponse>().Result;

                return organicResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
