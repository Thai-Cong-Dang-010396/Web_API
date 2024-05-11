namespace api;

public static class StockMappers
{
    public static StockDto ToStockDto(this Stock stockModel) => new StockDto
    {
        Id = stockModel.Id,
        Symbol = stockModel.Symbol,
        CompanyName = stockModel.CompanyName,
        Purchase = stockModel.Purchase,
        LastDiv = stockModel.LastDiv,
        Industry = stockModel.Industry,
        MarkerCap = stockModel.MarkerCap,
        Comments = stockModel.Comments.Select(c => c.ToCommentDto()).ToList(),
    };

    public static Stock ToStockFromCreateDto(this CreateStockRequestDto stockDto)
    {
        return new Stock
        {
            Symbol = stockDto.Symbol,
            CompanyName = stockDto.CompanyName,
            Purchase = stockDto.Purchase,
            LastDiv = stockDto.LastDiv,
            Industry = stockDto.Industry,
            MarkerCap = stockDto.MarkerCap
        };
    }

    public static Stock ToStockFromFMP(this FMPStock fmpStock)
    {
        return new Stock
        {
            Symbol = fmpStock.symbol,
            CompanyName = fmpStock.companyName,
            Purchase = (decimal)fmpStock.price,
            LastDiv = (decimal)fmpStock.lastDiv,
            Industry = fmpStock.industry,
            MarkerCap = fmpStock.mktCap
        };
    }
}
