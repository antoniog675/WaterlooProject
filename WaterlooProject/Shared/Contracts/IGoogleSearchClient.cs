using WaterlooProject.Models;

namespace WaterlooProject.Shared.Contracts
{
    public interface IGoogleSearchClient
    {
        Task<SearchResponse> SearchAsyc(string query);
    }
}
