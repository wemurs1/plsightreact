using Api.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public interface IHouseRepository
{
    Task<List<HouseDto>> GetAll();
    Task<HouseDetailsDto?> Get(int id);
}

public class HouseRepository : IHouseRepository
{
    private readonly HouseDbContext context;

    public HouseRepository(HouseDbContext context)
    {
        this.context = context;
    }

    public async Task<List<HouseDto>> GetAll()
    {
        return await context.Houses.Select(h => new HouseDto(h.Id, h.Address, h.Country, h.Price)).ToListAsync();
    }

    public async Task<HouseDetailsDto?> Get(int id)
    {
        var e = await context.Houses.SingleOrDefaultAsync(h => h.Id == id);
        if (e == null) return null;

        return new HouseDetailsDto(e.Id, e.Address, e.Country, e.Price, e.Description, e.Photo);
    }
}
