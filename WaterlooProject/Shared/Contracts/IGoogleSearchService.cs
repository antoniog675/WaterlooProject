using WaterlooProject.Models;

namespace WaterlooProject.Shared.Contracts
{
    public interface IGoogleSearchService
    {
        Task<QueryPositionsAndCount> SearchAsyc(string query);
    }
}
