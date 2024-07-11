using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Output
{
    public class SearchOutputDTO<T>
    {
        public IReadOnlyList<T>? Results { get; set; }
        public long TotalCount { get; set; }
        public int PageCount { get; set; }
    }
}
