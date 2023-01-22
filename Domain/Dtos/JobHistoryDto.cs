namespace Domain.Dtos;

public class JobHistoryDto
{
    public int HistoryId { get; set; }
    public DateTime Startdate { get; set; }
    public DateTime Enddate { get; set; }
    public int EmployeeId { get; set; }
    public int JobId { get; set; }
    public int DepartmentId { get; set; }


}