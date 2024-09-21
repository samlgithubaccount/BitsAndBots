
namespace BitsAndBots.Models
{
    public class EventSortOptions : ISortOptions<Event, object>
    {
        private Dictionary<string, SortOption<Event, object>> SortOptions = new() {
            { "Title Ascending", new() { DisplayName = "Title Ascending", SortDirection = SortDirection.Ascending, KeySelector = p => p.Title } },
            { "Title Descending", new () { DisplayName = "Title Descending", SortDirection = SortDirection.Descending, KeySelector = p => p.Title } },
            { "Earliest First", new () { DisplayName = "Earliest First", SortDirection = SortDirection.Descending, KeySelector = p => p.StartTime } }
        };

        public IEnumerable<SortOption<Event, object>> GetAll()
        {
            return SortOptions.Values;
        }

        public SortOption<Event, object> GetByDisplayName(string displayName)
        {
            return SortOptions[displayName];
        }

        public SortOption<Event, object> GetDefault()
        {
            return SortOptions["Title Ascending"];
        }
    }
}
