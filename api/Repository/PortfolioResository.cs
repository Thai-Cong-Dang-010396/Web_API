
using System.Net.NetworkInformation;
using Microsoft.EntityFrameworkCore;

namespace api;

public class PortfolioResository : IPortfolioRepository
{
    private readonly ApplicationDBContext _context;
    public PortfolioResository(ApplicationDBContext context)
    {
        _context = context;
    }

    public Task<List<Stock>> GetUserPortfolio(AppUser user)
    {
        return _context.Portfolios.Where(u => u.AppUserId == user.Id)
            .Select(stock => new Stock 
            {
                Id = stock.StockId,
                Symbol = stock.Stock.Symbol,
                CompanyName = stock.Stock.CompanyName,
                Purchase = stock.Stock.Purchase,
                LastDiv = stock.Stock.LastDiv,
                Industry = stock.Stock.Industry,
                MarkerCap = stock.Stock.MarkerCap,
            }).ToListAsync();
    }
}
