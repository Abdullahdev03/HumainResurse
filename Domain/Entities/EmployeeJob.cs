namespace Domain.Entities;

public class EmployeeJob
{
    public int EmployeeId { get; set; }
    public int JobId { get; set; }
    public Employee Employee { get; set; }
    public Job Job { get; set; }
}