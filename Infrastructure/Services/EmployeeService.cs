using Domain.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class EmployeeService
{

    private readonly DataContext _context;

    public EmployeeService(DataContext context)
    {
        _context = context;
    }

    
    
    public async Task<List<EmployeeDto>> GetEmployees()
    {
         
         var list =   await _context.Employees.Select(x =>
            new EmployeeDto()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                HireDate = x.HireDate,
                Salary = x.Salary,
                CommissionPct = x.CommissionPct,
                DepartmentId = x.DepartmentId,
                JobId = x.JobId
                
            }).ToListAsync();
         return new List<EmployeeDto>(list);
    }

    public async Task AddEmployee(EmployeeDto employee)
    {

            var list = new Employee()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                HireDate = employee.HireDate,
                Salary = employee.Salary,
                CommissionPct = employee.CommissionPct,
                ManagerId = employee.ManagerId,
                DepartmentId = employee.DepartmentId,
                JobId = employee.JobId
            };
            await _context.Employees.AddAsync(list);
            await _context.SaveChangesAsync();
    
    }

    public async Task UpdateEmployee(EmployeeDto employee)
    {
        try
        {var region = _context.Employees.Find(employee.Id);
            
                region.Id = employee.Id;
                region.FirstName = employee.FirstName;
                region.LastName = employee.LastName;
                region.Email = employee.Email;
                region.PhoneNumber = employee.PhoneNumber;
                region.HireDate = employee.HireDate;
                region.Salary = employee.Salary;
                region.CommissionPct = employee.CommissionPct;
                region.ManagerId = employee.ManagerId;
                region.DepartmentId = employee.DepartmentId;
                region.JobId = employee.JobId;
                await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task DeleteEmployee(int id)
    {
        var delete = await _context.Employees.FirstAsync(x => x.Id == id);
        _context.Employees.Remove(delete);
        await _context.SaveChangesAsync();
    }

}