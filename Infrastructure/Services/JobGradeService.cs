using Domain.Dtos;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class JobGradeService
{
    private readonly DataContext _context;

    public JobGradeService(DataContext context)
    {
        _context = context;
    }

    
    
    public async Task<List<JobGrade>> GetGrade()
    {
        return await _context.JobGrades.Select(x =>
            new JobGrade()
            {
                Id = x.Id,
                Gradelevel = x.Gradelevel,
                Lowestsal = x.Lowestsal,
                Higestsal = x.Higestsal

            }).ToListAsync();
    }

    public async Task AddGrade(JobGradeDto jobGrade)
    {
        try
        {
            var job = new JobGrade()
            {
                Id = jobGrade.Id,
                Gradelevel = jobGrade.Gradelevel,
                Lowestsal = jobGrade.Lowestsal,
                Higestsal = jobGrade.Higestsal,
            };
            await _context.JobGrades.AddAsync(job);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            
        }
    }

    public async Task UpdateGrade(JobGradeDto jobGrade)
    {
        try
        {  var region = _context.JobGrades.Find(jobGrade.Id);
            
                region.Id = jobGrade.Id;
                region.Gradelevel = jobGrade.Gradelevel;
                region.Lowestsal = jobGrade.Lowestsal;
                region.Higestsal = jobGrade.Higestsal;
            
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task DeleteGrade(string level)
    {
        var delete = await _context.JobGrades.FirstAsync(x => x.Gradelevel == level);
        _context.JobGrades.Remove(delete);
        await _context.SaveChangesAsync();
    }
    
}