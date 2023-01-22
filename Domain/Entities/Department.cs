using System.ComponentModel.DataAnnotations.Schema;

public class Department
{
    public Department()
    {
        
    }
    
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
    public int ManagerId { get; set; }
    public int LocationId { get; set; }
    public List<Location> Locations { get; set; }
    public List<JobHistory> JobHistories { get; set; }
    public List<Employee> Employees{ get; set; }
   
}