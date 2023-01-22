using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("controller")]
public class LocationController:ControllerBase
{

    private readonly LocationService _locationService;

    public LocationController(LocationService locationService)
    {
        _locationService = locationService;
    }

    [HttpGet("Getlocations")]
    public async Task<List<LocationDto>> GetLoc()
    {
        return await _locationService.GetLocation();
    }

    [HttpPost("Postlocation")]
    public async Task AddLocation(LocationDto loc)
    {
        await _locationService.AddLocation(loc);
    }

    [HttpPut("Updatelocation")]
    public async Task UpdateLocation(LocationDto loc)
    {
        await _locationService.UpdateLocation(loc);
    }

    [HttpDelete("Deletelocation")]
    public async Task DeleteGrade(int id)
    {
        await _locationService.Deletelocation(id);
    }
}