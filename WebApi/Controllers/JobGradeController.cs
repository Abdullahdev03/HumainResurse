using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("controller")]
public class JobGradeController :ControllerBase
{

    private readonly JobGradeService _jobGradeService;

    public JobGradeController(JobGradeService jobGradeService)
    {
        _jobGradeService = jobGradeService;
    }

    [HttpGet("GetGrades")]
    public async Task<List<JobGrade>> GetGrade()
    {
        return await _jobGradeService.GetGrade();
    }

    [HttpPost("PostGrade")]
    public async Task AddGrade(JobGradeDto grade)
    {
        await _jobGradeService.AddGrade(grade);
    }

    [HttpPut("UpdateGrade")]
    public async Task UpdateGrade(JobGradeDto grade)
    {
        await _jobGradeService.UpdateGrade(grade);
    }

    [HttpDelete("DeleteGrade")]
    public async Task DeleteGrade(string level)
    {
        await _jobGradeService.DeleteGrade(level);
    }
}