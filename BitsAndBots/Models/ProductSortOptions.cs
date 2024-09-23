
namespace BitsAndBots.Models
{
    public class ProductSortOptions : ISortOptions<Product, object>
    {
        private Dictionary<string, SortOption<Product, object>> SortOptions = new() {
            { "Title Ascending", new() { DisplayName = "Title Ascending", SortDirection = SortDirection.Ascending, KeySelector = p => p.Title } },
            { "Title Descending", new () { DisplayName = "Title Descending", SortDirection = SortDirection.Descending, KeySelector = p => p.Title } },
            { "Highest Price", new () { DisplayName = "Highest Price", SortDirection = SortDirection.Descending, KeySelector = p => p.Price } },
            { "Lowest Price", new() { DisplayName = "Lowest Price", SortDirection = SortDirection.Ascending, KeySelector = p => p.Price } }
            //,
            //new() { DisplayName = "Date Listed", /*Field = "Title",*/ SortDirection = Models.SortDirection.Descending, keySelector = p => p.CreatedTimestamp }
        };

        public IEnumerable<SortOption<Product, object>> GetAll()
        {
            return SortOptions.Values;
        }

        public SortOption<Product, object> GetByDisplayName(string displayName)
        {
            return SortOptions[displayName];
        }

        public SortOption<Product, object> GetDefault()
        {
            return SortOptions["Title Ascending"];
        }
    }
}
