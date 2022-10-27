using api.Db;
using api.Queries.Interfaces;
using api.Requests;
using MediatR;

namespace api.Handlers;

public class GetItemsHandler : IRequestHandler<GetItemsRequest, IList<Item>>
{
    private readonly IGetItemsQuery _query;

    public GetItemsHandler(IGetItemsQuery query)
    {
        _query = query;
    }
    
    public Task<IList<Item>> Handle(GetItemsRequest request, CancellationToken cancellationToken)
    {
        return _query.ExecuteAsync();
    }
}
