using api.Db;
using api.Queries.Interfaces;

namespace api.Queries.Implementations;

public class GetItemsQuery : IGetItemsQuery
{
    private readonly ItemContext _context;

    public GetItemsQuery(ItemContext context)
    {
        _context = context;
    }
    
    public async Task<IList<Item>> ExecuteAsync()
    {
        return _context.Items.ToList();
    }
}
