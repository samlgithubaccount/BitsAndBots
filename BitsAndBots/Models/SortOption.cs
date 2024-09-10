using System.Linq.Expressions;

namespace BitsAndBots.Models
{
    public class SortOption<T, TKey>
    {
        public string DisplayName { get; set; }
        //public string Field { get; set; }
        public SortDirection SortDirection { get; set; }
        public Expression<Func<T, TKey>> KeySelector;
    }
}
