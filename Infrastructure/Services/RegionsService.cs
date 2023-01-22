using Domain.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class RegionsService
{
    private readonly DataContext _context;

    public RegionsService(DataContext context)
    {
        _context = context;
    }

    
    
    public async Task<List<RegionDto>> Getregions()
    {
        return await _context.Regions.Select(x =>
            new RegionDto()
            {
                RegionId = x.RegionId,
                RegionName = x.RegionName,

            }).ToListAsync();
    }

    public async Task AddRegion(RegionDto region)
    {
        try
        {
            var C = new Region()
            {
                RegionId = region.RegionId,
                RegionName = region.RegionName,
            };
            await _context.Regions.AddAsync(C);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            
        }
    }

    public async Task UpdateRegion(RegionDto region)
    {
        try
        {var tt = _context.Regions.Find(region.RegionId);

            tt.RegionId = region.RegionId;
            tt.RegionName = region.RegionName;

            
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
        
    }

    public async Task DeleteRegion(int id)
    {
        var delete = await _context.Regions.FirstAsync(x => x.RegionId == id);
        _context.Regions.Remove(delete);
        await _context.SaveChangesAsync();
    }
    

}