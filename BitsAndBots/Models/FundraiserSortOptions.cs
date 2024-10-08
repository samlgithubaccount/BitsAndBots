
namespace BitsAndBots.Models
{
    public class FundraiserSortOptions : ISortOptions<Fundraiser, object>
    {
        private Dictionary<string, SortOption<Fundraiser, object>> SortOptions = new() {
            { "Title Ascending", new() { DisplayName = "Title Ascending", SortDirection = SortDirection.Ascending, KeySelector = p => p.Title } },
            { "Title Descending", new () { DisplayName = "Title Descending", SortDirection = SortDirection.Descending, KeySelector = p => p.Title } },
            { "Earliest First", new () { DisplayName = "Earliest First", SortDirection = SortDirection.Ascending, KeySelector = p => p.StartTime } }
        };

        public IEnumerable<SortOption<Fundraiser, object>> GetAll()
        {
            return SortOptions.Values;
        }

        public SortOption<Fundraiser, object> GetByDisplayName(string displayName)
        {
            return SortOptions[displayName];
        }

        public SortOption<Fundraiser, object> GetDefault()
        {
            return SortOptions["Earliest First"];
        }
    }
}
