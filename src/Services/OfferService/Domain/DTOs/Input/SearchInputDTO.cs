﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Input
{
    public class SearchInputDTO
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? OrderBy { get; set; }
        public required OfferStatus Status { get; set; }
        public required string Direction { get; set; }
    }
}
