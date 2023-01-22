using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("controller")]
public class DepartmentController : ControllerBase
{
    private readonly DepartmentService _departmentService;

    public DepartmentController(DepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [HttpGet("GetDepartments")]
    public async Task<List<DepartmentDto>> GetDepartment()
    {
        return await _departmentService.GetDepartment();
    }

    [HttpPost("PostDepartment")]
    public async Task AddDepartment(DepartmentDto department)
    {
        await _departmentService.AddDepartment(department);
    }

    [HttpPut("UpdateDepartment")]
    public async Task UpdateDepartment(DepartmentDto department)
    {
        await _departmentService.UpdateDepartment(department);
    }

    [HttpDelete("DeleteDepartment")]
    public async Task Delete(int id)
    {
        await _departmentService.DeleteDepartment(id);
    }
}