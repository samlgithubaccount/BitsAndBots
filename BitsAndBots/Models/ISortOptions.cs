namespace BitsAndBots.Models
{
    public interface ISortOptions<T, TKey>
    {
        public SortOption<T, TKey> GetDefault();
        public SortOption<T, TKey> GetByDisplayName(string displayName);
        public IEnumerable<SortOption<T, TKey>> GetAll();
    }
}
