using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Models
{
    public class SearchAuctionsParams
    {
        public string? SearchTerm { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Seller { get; set; }
        public string? Winner { get; set; }
        public string? OrderBy { get; set; }
        public string? FilterBy { get; set; }
    }
}
