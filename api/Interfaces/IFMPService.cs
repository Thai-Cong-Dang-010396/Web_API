namespace api;

public interface IFMPService
{
    Task<Stock> FindStockBySymbolAsync(string symbol);
}
