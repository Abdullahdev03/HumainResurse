using Domain.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class CountryService
{
    private readonly DataContext _context;

    public CountryService(DataContext context)
    {
        _context = context;
    }

    
    
    public async Task<List<CountryDto>> GetCountries()
    {
        return await _context.Countries.Select(x =>new CountryDto()
        {
            CountryId = x.CountryId,
            CountryName = x.CountryName,
            RegionId = x.RegionId
        }).ToListAsync();
    }

    public async Task AddCountry(CountryDto country)
    {
        try
        {
            var C = new Country()
            {
                CountryId = country.CountryId,
                CountryName = country.CountryName,
                RegionId = country.RegionId,
            };
            await _context.Countries.AddAsync(C);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            
        }
    }

    public async Task UpdateCountry(CountryDto country)
    {
        try
        {
            var region = _context.Countries.Find(country.CountryId);
            if (region == null) Console.WriteLine("Not Found");
            ;
            region.RegionId = country.RegionId;
            region.CountryId = country.CountryId;
            region.CountryName = country.CountryName;
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task DeleteCountry(int id)
    {
        var delete = await _context.Countries.FirstAsync(x => x.CountryId == id);
        _context.Countries.Remove(delete);
        await _context.SaveChangesAsync();
    }
}