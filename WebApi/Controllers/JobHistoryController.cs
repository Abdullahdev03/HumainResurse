using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("controller")]
public class JobHistoryController:ControllerBase
{
    private readonly JobHistoryService _historyService;

    public JobHistoryController(JobHistoryService historyService)
    {
        _historyService = historyService;
    }

    [HttpGet("GetHistories")]
    public async Task<List<JobHistoryDto>> GetHistory()
    {
        return await _historyService.GetHistory();
    }

    [HttpPost("PostHistory")]
    public async Task AddHistory(JobHistoryDto history)
    {
        await _historyService.AddHistory(history);
    }

    [HttpPut("UpdateHistory")]
    public async Task UpdateHistory(JobHistoryDto history)
    {
        await _historyService.UpdateHistory(history);
    }

    [HttpDelete("DeleteHistory")]
    public async Task DeleteHistory(int id)
    {
        await _historyService.DeleteHistory(id);
    }

}