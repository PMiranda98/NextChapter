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
        public class Query : IRequest<Result<GetAuctionsDTO>> 
        {
            public string? SearchTerm { get; set; }
            public int PageNumber { get; set; }
            public int PageSize { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<GetAuctionsDTO>>
        {
            private readonly IAuctionsRepository _auctionsRepository;

            public Handler(IAuctionsRepository auctionsRepository)
            {
                _auctionsRepository = auctionsRepository;
            }
            public async Task<Result<GetAuctionsDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                if(request.SearchTerm == null)
                {
                    var result = await _auctionsRepository.SearchAll(request.PageNumber, request.PageSize);
                    return Result<GetAuctionsDTO>.Success(result);
                }
                var termsResult = await _auctionsRepository.SearchTerm(request.SearchTerm, request.PageNumber, request.PageSize);
                return Result<GetAuctionsDTO>.Success(termsResult);
            }
        }
    }
}
