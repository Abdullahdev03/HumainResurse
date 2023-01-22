namespace Domain.Entities;

public class Job
{
    
    public int Id { get; set; }
    public string JobTitle { get; set; }
    public int MinSalaray { get; set; }
    public int MaxSalary { get; set; }
    public List<Employee> Employees { get; set; }
    public List<JobHistory> JobHistories { get; set; }
    public ICollection<EmployeeJob> EmployeeJobs { get; set; }

}
