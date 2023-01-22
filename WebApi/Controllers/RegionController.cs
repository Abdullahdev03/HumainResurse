namespace WebApi.Controllers;
using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("controller")]
public class RegionController:ControllerBase
{
    
    private readonly RegionsService _regionsService;

    public RegionController(RegionsService regionsService)
    {
        _regionsService = regionsService;
    }

    [HttpGet("GetRegions")]
    public async Task<List<RegionDto>> GetRegion()
    {
        return await _regionsService.Getregions();
    }

    [HttpPost("PostRegion")]
    public async Task AddRegion(RegionDto region)
    {
        await _regionsService.AddRegion(region);
    }

    [HttpPut("UpdateRegion")]
    public async Task UpdateRegion(RegionDto region)
    {
        await _regionsService.UpdateRegion(region);
    }

    [HttpDelete("DeleteRegion")]
    public async Task DeleteRegion(int id)
    {
        await _regionsService.DeleteRegion(id);
    }

}