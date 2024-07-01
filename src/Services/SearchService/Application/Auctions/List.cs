using Application.Core;
using AutoMapper;
using Domain.DTOs;
using Domain.Models;
using Domain.Repositories;
using MediatR;
using MongoDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Auctions
{
    public class List
    {
        public class QueryParams
        {
            public string? SearchTerm { get; set; }
            public int PageNumber { get; set; }
            public int PageSize { get; set; }
            public string? Seller { get; set; }
            public string? Winner { get; set; }
            public string? OrderBy { get; set; }
            public string? FilterBy { get; set; }
        }
        public class Query : IRequest<Result<SearchDto>> 
        {
            public QueryParams QueryParams { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<SearchDto>>
        {
            private readonly IAuctionsRepository _auctionsRepository;

            public Handler(IAuctionsRepository auctionsRepository)
            {
                _auctionsRepository = auctionsRepository;
            }
            public async Task<Result<SearchDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                if(request.QueryParams.SearchTerm == null)
                {
                    var result = await _auctionsRepository.SearchAll(request.QueryParams.PageNumber, request.QueryParams.PageSize);
                    return Result<SearchDto>.Success(result);
                }
                var termsResult = await _auctionsRepository.SearchTerm(request.QueryParams.SearchTerm, request.QueryParams.PageNumber, request.QueryParams.PageSize);
                return Result<SearchDto>.Success(termsResult);
            }
        }
    }
}
