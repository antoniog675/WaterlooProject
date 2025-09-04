using WaterlooProject.Models;
using WaterlooProject.Shared.Contracts;

namespace WaterlooProject.Services
{
    public class GoogleSearchService : IGoogleSearchService
    {
        private readonly IGoogleSearchClient _client;
        private readonly ILogger<GoogleSearchService> _logger;


        public GoogleSearchService(IGoogleSearchClient client, ILogger<GoogleSearchService> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<QueryPositionsAndCount> SearchAsyc(string query)
        {
            QueryPositionsAndCount queryPositionsAndCount = new QueryPositionsAndCount();

            var clientResponse = await _client.SearchAsyc(query);

            queryPositionsAndCount = GetPositionsAndCount(clientResponse);
            queryPositionsAndCount.Query = query;

            _logger.LogInformation("InfoTrack has been found in positions {0}, for a total of {1} many times", queryPositionsAndCount.Positions, queryPositionsAndCount.Count);

            return queryPositionsAndCount;
        }

        #region Private Method
        private QueryPositionsAndCount GetPositionsAndCount(SearchResponse clientResponse)
        {
            QueryPositionsAndCount positionsAndCount = new QueryPositionsAndCount();

            List<int> positions = new List<int>();
            int count = 0;

            foreach (var result in clientResponse.Organic_Results)
            {
                if (result.Title.Contains("InfoTrack") || result.Link.Contains("www.infotrack.co.uk"))
                {
                    positions.Add(result.Position);
                    count++;
                }
            }

            positionsAndCount.Positions = positions;
            positionsAndCount.Count = count;

            return positionsAndCount;
        }
        #endregion

    }
}
