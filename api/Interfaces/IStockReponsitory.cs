namespace api;

public interface IStockReponsitory
{
    Task<List<Stock>> GetAllAsync();
}
