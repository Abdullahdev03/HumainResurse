using Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
  public DataContext(DbContextOptions<DataContext> options) : base(options)
  {
  }

  public DbSet<Employee> Employees {get; set;}
  public DbSet<Job> Jobs {get; set;}
  public DbSet<JobHistory> JobHistories {get; set;}
  public DbSet<JobGrade> JobGrades {get; set;}
  public DbSet<Department> Departments {get; set;}
  public DbSet<Country> Countries {get; set;}
  public DbSet<Region> Regions {get; set;}
  public DbSet<Location> Locations {get; set;}
  
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<EmployeeJob>().HasKey(es => new
    {
      es.EmployeeId, es.JobId
    });
    base.OnModelCreating(modelBuilder);
  }

  
}
