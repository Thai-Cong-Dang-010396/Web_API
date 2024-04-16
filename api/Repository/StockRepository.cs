using Microsoft.EntityFrameworkCore;

namespace api;

public class StockRepository : IStockReponsitory
{
    private readonly ApplicationDBContext _context;
    public StockRepository(ApplicationDBContext context)
    {
        _context = context;
    }
    public Task<List<Stock>> GetAllAsync()
    {
        
        return _context.Stock.ToListAsync();
    }
}
