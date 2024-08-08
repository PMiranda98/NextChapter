using AutoMapper;
using Domain.DTOs.Output;
using Domain.DTOs.Output.Item;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.Items;

public class List
{
    public class Query : IRequest<Result<List<ItemDto>>> { }

    public class Handler : IRequestHandler<Query, Result<List<ItemDto>>>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public Handler(IItemRepository advertisementRepository, IMapper mapper)
        {
            _itemRepository = advertisementRepository;
            _mapper = mapper;
        }
        public async Task<Result<List<ItemDto>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var advertisements = await _itemRepository.ListItem(cancellationToken);
            return Result<List<ItemDto>>.Success(_mapper.Map<List<ItemDto>>(advertisements));
        }
    }
}
