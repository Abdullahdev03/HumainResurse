using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("Controller")]
public class JobController : ControllerBase
{
    private readonly JobService _jobService;

    public JobController(JobService jobService)
    {
        _jobService = jobService;
    }

    [HttpGet("GetJobs")]
    public async Task<List<JobDto>> GetJobs()
    {
        return await _jobService.GetJobs();
    }

    [HttpPost("PostJob")]
    public async Task AddJobs(JobDto job)
    {
        await _jobService.AddJob(job);
    }

    [HttpPut("UpdateJob")]
    public async Task UpdateJobs(JobDto job)
    {
        await _jobService.UpdateJob(job);
    }

    [HttpDelete("DeleteJob")]
    public async Task Delete(int id)
    {
        await _jobService.DeleteJob(id);
    }

}