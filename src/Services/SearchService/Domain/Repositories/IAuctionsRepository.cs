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
        Task<GetAuctionsDTO> SearchAll(int pageNumber, int pageSize);
        Task<GetAuctionsDTO> SearchTerm(string searchTerm, int pageNumber, int pageSize);
    }
}
