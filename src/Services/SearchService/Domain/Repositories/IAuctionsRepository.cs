using Domain.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IAuctionsRepository
    {
        Task<SearchDto> SearchAll(int pageNumber, int pageSize);
        Task<SearchDto> SearchByTerm(string searchTerm, int pageNumber, int pageSize);
    }
}
