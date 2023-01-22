using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class JobGrade
{

    
    [Key] public int Id { get; set; }
    public string Gradelevel { get; set; }
    public int Lowestsal { get; set; }
    public int Higestsal { get; set; }
    
    
}