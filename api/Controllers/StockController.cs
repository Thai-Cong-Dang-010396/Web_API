using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api;

[Route("api/stock")]
[ApiController]
public class StockController : ControllerBase
{
    private readonly ApplicationDBContext _context;
    private readonly IStockReponsitory _stockRepo;
    public StockController(ApplicationDBContext context, IStockReponsitory stockRepo)
    {
        _stockRepo = stockRepo;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() 
    {
        var stocks = await _stockRepo.GetAllAsync();
        var stockDto = stocks.Select(s => s.ToStockDto());

        return Ok(stockDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var stock = await _context.Stock.FindAsync(id);

        if(stock == null)
        {
            return NotFound();
        }
        return Ok(stock.ToStockDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
    {
        var stockModel = stockDto.ToStockFromCreateDto();
        await _context.Stock.AddAsync(stockModel);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
    {
        var stockModel = await _context.Stock.FirstOrDefaultAsync(x => x.Id == id);
        if (stockModel == null) {
            return NotFound();
        }

        stockModel.Symbol = updateDto.Symbol;
        stockModel.CompanyName = updateDto.CompanyName;
        stockModel.Purchase = updateDto.Purchase;
        stockModel.LastDiv = updateDto.LastDiv;
        stockModel.Industry = updateDto.Industry;
        stockModel.MarkerCap = updateDto.MarkerCap;
        await _context.SaveChangesAsync();
        return Ok(stockModel.ToStockDto());
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var stockModel = await _context.Stock.FirstOrDefaultAsync(x => x.Id == id);
        if (stockModel == null) {
            return NotFound();
        }
        _context.Stock.Remove(stockModel);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
