namespace Domain.Dtos;

public class EmployeeDto
{
 
    
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime HireDate { get; set; }
    public int Salary { get; set; }
    public int CommissionPct { get; set; }
    public int ManagerId { get; set; }
    public int DepartmentId { get; set; }
    public int JobId { get; set; }
}