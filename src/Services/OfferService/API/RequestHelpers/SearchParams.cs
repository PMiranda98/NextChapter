namespace API.RequestHelpers
{
    public class SearchParams
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 4;
        public string? OrderBy { get; set; }
        public required string Direction { get; set; }
    }
}
