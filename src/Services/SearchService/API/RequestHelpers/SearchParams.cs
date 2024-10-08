﻿namespace API.RequestHelpers
{
    public class SearchParams
    {
        public string? SearchTerm { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 4;
        public string? Seller { get; set; }
        public string? Buyer { get; set; }
        public string? OrderBy { get; set; }
        public string Status { get; set; } = "Live";
    }
}
