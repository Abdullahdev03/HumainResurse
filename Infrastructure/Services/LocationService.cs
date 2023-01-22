using Domain.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class LocationService
{
    private readonly DataContext _context;

    public LocationService(DataContext context)
    {
        _context = context;
    }


    public async Task<List<LocationDto>> GetLocation()
    {
        var list =  await _context.Locations.Select(x => 
            new LocationDto()
            {
                LocationId = x.LocationId,
                StreetAddress = x.StreetAddress,
                PostalCode = x.PostalCode,
                City = x.City,
                StateProvince = x.StateProvince,
                CountryId = x.CountryId
            }).ToListAsync();
        return new List<LocationDto>(list);
    }

    public async Task AddLocation(LocationDto loc)
    {

        try
        {
            var C = new Location()
            {
                LocationId = loc.LocationId,
                StreetAddress = loc.StreetAddress,
                PostalCode = loc.PostalCode,
                StateProvince = loc.StateProvince,
                CountryId = loc.CountryId,
                City = loc.City,
                DepartmentId = loc.DepartmentId,
            };
            
            await _context.Locations.AddAsync(C);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    public async Task UpdateLocation(LocationDto loc)
    {
        try
        {var region = _context.Locations.Find(loc.LocationId);
            
                region.LocationId = loc.LocationId;
                region.StreetAddress = loc.StreetAddress;
                region.PostalCode = loc.PostalCode;
                region.StateProvince = loc.StateProvince;
            
            await _context.SaveChangesAsync();
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task Deletelocation(int id)
    {
        var delete = await _context.Locations.FirstAsync(x => x.LocationId == id);
        _context.Locations.Remove(delete);
        await _context.SaveChangesAsync();
    }
    

}