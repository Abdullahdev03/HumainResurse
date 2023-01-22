using Domain.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class DepartmentService
{
    private readonly DataContext _context;

    public DepartmentService(DataContext context)
    {
        _context = context;
    }

    
    
    public async Task<List<DepartmentDto>> GetDepartment()
    {
        return await _context.Departments
            .Select(x => new DepartmentDto()
            {
                DepartmentId = x.DepartmentId,
                DepartmentName = x.DepartmentName,
                ManagerId = x.ManagerId,
                LocationId = x.LocationId,
            }).ToListAsync();
    }

    public async Task AddDepartment(DepartmentDto department)
    {
        try
        {
            var D = new Department()
            {
                DepartmentId = department.DepartmentId,
                DepartmentName = department.DepartmentName,
                ManagerId = department.ManagerId,
                LocationId = department.LocationId
            };
            await _context.Departments.AddAsync(D);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            
        }
    }

    public async Task UpdateDepartment(DepartmentDto department)
    {
        try
        {var region = _context.Departments.Find(department.DepartmentId);

            region.DepartmentId = department.DepartmentId;
            region.DepartmentName = department.DepartmentName;
            region.ManagerId = department.ManagerId;
            region.LocationId = department.LocationId;
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task DeleteDepartment(int id)
    {
        var delete = await _context.Departments.FirstAsync(x => x.DepartmentId == id);
        _context.Departments.Remove(delete);
        await _context.SaveChangesAsync();
    }

}