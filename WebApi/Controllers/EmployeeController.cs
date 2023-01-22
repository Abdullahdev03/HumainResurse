using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("Controller")]
public class EmployeeController : ControllerBase
{
    private readonly EmployeeService _employeeService;

    public EmployeeController(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet("GetEmplloyees")]
    public async Task<List<EmployeeDto>> GetEmployee()
    {
        return await _employeeService.GetEmployees();
    }

    [HttpPost("PostEmplloyee")]
    public async Task AddEmployee(EmployeeDto employee)
    {
        await _employeeService.AddEmployee(employee);
    }

    [HttpPut("UpdateEmplloyee")]
    public async Task UpdateEmployee(EmployeeDto employee)
    {
        await _employeeService.UpdateEmployee(employee);
    }

    [HttpDelete("DeleteEmplloyee")]
    public async Task Delete(int id)
    {
        await _employeeService.DeleteEmployee(id);
    }
}