using Domain.Dtos;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class JobService
{
    private readonly DataContext _context;

    public JobService(DataContext context)
    {
        _context = context;
    }

    
    
    public async Task<List<JobDto>> GetJobs()
    {
        return await _context.Jobs.Select(x =>
            new JobDto()
            {
                Id = x.Id,
                JobTitle = x.JobTitle,
                MinSalaray = x.MinSalaray,
                MaxSalary = x.MaxSalary,

            }).ToListAsync();
    }

    public async Task AddJob(JobDto job)
    {
        try
        {
            var C = new Job()
            {
                Id = job.Id,
                JobTitle = job.JobTitle,
                MinSalaray = job.MinSalaray,
                MaxSalary = job.MaxSalary,
                
            };
            await _context.Jobs.AddAsync(C);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            
        }
    }

    public async Task UpdateJob(JobDto job)
    {
        try
        {var region = _context.Jobs.Find(job.Id);
            
                region.Id = job.Id;
                region.JobTitle = job.JobTitle;
                region.MinSalaray = job.MinSalaray;
                region.MaxSalary = job.MaxSalary;
            
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task DeleteJob(int id)
    {
        var delete = await _context.Jobs.FirstAsync(x => x.Id == id);
        _context.Jobs.Remove(delete);
        await _context.SaveChangesAsync();
    }
    
}