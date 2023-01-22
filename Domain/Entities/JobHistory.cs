using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;
using Domain.Entities;

public class JobHistory
{
    
    [Key]
    public int HistoryId { get; set; }
    public int EmployeeId { get; set; }
    public  Employee Employee { get; set; }
    public DateTime Startdate { get; set; }
    public DateTime Enddate { get; set; }
    
    public int JobId { get; set; }
    public Job Job { get; set; }

    public int DepartmentId { get; set; }
    public  Department Department { get; set; }
    
    
}