namespace Domain.Dtos;

public class LocationDto
{

    public int LocationId { get; set; }
    public string StreetAddress { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }
    public string StateProvince { get; set; }
    public int CountryId { get; set; }
    public int DepartmentId { get; set; }
}