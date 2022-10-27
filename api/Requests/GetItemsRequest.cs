using api.Db;
using MediatR;

namespace api.Requests;

public class GetItemsRequest : IRequest<IList<Item>>
{
}
