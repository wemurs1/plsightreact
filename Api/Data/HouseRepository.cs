using Api.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public interface IHouseRepository
{
    Task<List<HouseDto>> GetAll();
    Task<HouseDetailsDto?> Get(int id);
    Task<HouseDetailsDto> Add(HouseDetailsDto dto);
    Task<HouseDetailsDto> Update(HouseDetailsDto dto);
    Task Delete(int id);
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

        return EntityToDetailDto(e);
    }

    public async Task<HouseDetailsDto> Add(HouseDetailsDto dto)
    {
        var entity = new HouseEntity();
        DtoToEntity(dto, entity);
        context.Houses.Add(entity);
        await context.SaveChangesAsync();
        return EntityToDetailDto(entity);
    }

    public async Task<HouseDetailsDto> Update(HouseDetailsDto dto)
    {
        var entity = await context.Houses.FindAsync(dto.Id);
        if (entity == null) throw new ArgumentException($"Error updating house {dto.Id}");
        DtoToEntity(dto, entity);
        context.Entry(entity).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return EntityToDetailDto(entity);
    }

    public async Task Delete(int id)
    {
        var entity = await context.Houses.FindAsync(id);
        if (entity == null) throw new ArgumentException($"Error deleting house {id}");
        context.Houses.Remove(entity);
        await context.SaveChangesAsync();
    }

    private static void DtoToEntity(HouseDetailsDto dto, HouseEntity e)
    {
        e.Address = dto.Address;
        e.Country = dto.Country;
        e.Description = dto.Description;
        e.Price = dto.Price;
        e.Photo = dto.Photo;
    }

    private static HouseDetailsDto EntityToDetailDto(HouseEntity e)
    {
        return new HouseDetailsDto(e.Id, e.Address, e.Country, e.Price, e.Description, e.Country);
    }
}
