using AutoMapper;
using Domain.DTOs.Input;
using Domain.DTOs.Output;
using Domain.DTOs.Output.Item;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.Items;

public class List
{
    public class Query : IRequest<Result<SearchOutputDTO<ItemDto>>> 
    {
        public SearchInputDTO SearchInputDTO { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<SearchOutputDTO<ItemDto>>>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public Handler(IItemRepository advertisementRepository, IMapper mapper)
        {
            _itemRepository = advertisementRepository;
            _mapper = mapper;
        }
        public async Task<Result<SearchOutputDTO<ItemDto>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var items = await _itemRepository.ListItem(request.SearchInputDTO, cancellationToken);
            return Result<SearchOutputDTO<ItemDto>>.Success(_mapper.Map<SearchOutputDTO<ItemDto>>(items));
        }
    }
}
