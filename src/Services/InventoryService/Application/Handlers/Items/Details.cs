using AutoMapper;
using Domain.DTOs.Output;
using Domain.DTOs.Output.Item;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.Items;

public class Details
{
    public class Query : IRequest<Result<ItemDto>>
    {
        public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<ItemDto>>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public Handler(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<Result<ItemDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var advertisement = await _itemRepository.DetailsItem(request.Id, cancellationToken);
            return Result<ItemDto>.Success(_mapper.Map<ItemDto>(advertisement));
        }
    }
}
