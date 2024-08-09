namespace API.RequestHelpers
{
    public class SearchParams
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 4;
        public required string Owner { get; set; }
        public string? OrderBy { get; set; }
        public string? FilterBy { get; set; }
    }
}
