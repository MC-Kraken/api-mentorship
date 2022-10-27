using api.Db;

namespace api.Queries.Interfaces;

public interface IGetItemsQuery
{
    Task<IList<Item>> ExecuteAsync();
}