namespace WaterlooProject.Shared.Contracts
{
    public interface IBingSearchClient
    {
        Task<string> SearchAsyc(string query);
    }
}
