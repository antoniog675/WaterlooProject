using System.Net.Http;
using WaterlooProject.Shared.Contracts;

namespace WaterlooProject.Client
{
    public class BingSearchClient : IBingSearchClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly ILogger<BingSearchClient> _logger;

        public BingSearchClient(HttpClient httpClient, IConfiguration config, ILogger<BingSearchClient> logger)
        {
            _httpClient = httpClient;
            _config = config;
            _logger = logger;
        }
        public async Task<string> SearchAsyc(string query)
        {
            _logger.LogInformation("In the client, making request to google");

            var url = String.Format(_config["Serp"], query);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);

            request.Headers.Add("User-Agent", "Mozilla/5.0");

            try
            {
                var httpResponse = await _httpClient.SendAsync(request);
                httpResponse.EnsureSuccessStatusCode();
                string stringResponse = httpResponse.Content != null ? await httpResponse.Content.ReadAsStringAsync() : string.Empty;
                return stringResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
