using Domain.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class JobHistoryService
{
    private readonly DataContext _context;

    public JobHistoryService(DataContext context)
    {
        _context = context;
    }

    
    
    public async Task<List<JobHistoryDto>> GetHistory()
    {
        return await _context.JobHistories.Select(x =>
            new JobHistoryDto()
            {
                HistoryId = x.HistoryId,
                Startdate = x.Startdate,
                Enddate = x.Enddate,
                EmployeeId = x.HistoryId,
                JobId = x.JobId,

            }).ToListAsync();
    }

    public async Task AddHistory(JobHistoryDto history)
    {
        try
        {

            var C = new JobHistory()
            {
                HistoryId = history.HistoryId,
                Startdate = history.Startdate,
                Enddate = history.Enddate,
                EmployeeId = history.EmployeeId,
                JobId = history.JobId,
                DepartmentId = history.DepartmentId,
            };
            await _context.JobHistories.AddAsync(C);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task UpdateHistory(JobHistoryDto history)
    {
        try
        {var region = _context.JobHistories.Find(history.HistoryId);
            
                region.HistoryId = history.HistoryId;
                region.Startdate = history.Startdate;
                region.Enddate = history.Enddate;
                region.EmployeeId = history.HistoryId;
                region.JobId = history.JobId;
            
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task DeleteHistory(int id)
    {
        var delete = await _context.JobHistories.FirstAsync(x => x.HistoryId == id);
        _context.JobHistories.Remove(delete);
        await _context.SaveChangesAsync();
    }
    
}