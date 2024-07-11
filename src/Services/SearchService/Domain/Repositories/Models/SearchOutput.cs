namespace Domain.Repositories.Models
{
    public class SearchOutput<T>
    {
        public IReadOnlyList<T>? Results { get; set; }
        public long TotalCount { get; set; }
        public int PageCount { get; set; }
    }
}
