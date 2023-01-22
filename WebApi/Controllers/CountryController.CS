using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("controller")]
public class CountryController : ControllerBase
{
    private readonly CountryService _countryService;

    public CountryController(CountryService countryService)
    {
        _countryService = countryService;
    }

    [HttpGet("GetCountries")]
    public async Task<List<CountryDto>> GetCountries()
    {
        return await _countryService.GetCountries();
    }

    [HttpPost("PostCountry")]
    public async Task AddCoutry(CountryDto country)
    {
        await _countryService.AddCountry(country);
    }

    [HttpPut("UpdateCountry")]
    public async Task UpdateCountry(CountryDto country)
    {
        await _countryService.UpdateCountry(country);
    }

    [HttpDelete("DeleteCountry")]
    public async Task Delete(int id)
    {
        await _countryService.DeleteCountry(id);
    }
}