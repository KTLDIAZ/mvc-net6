using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_CodeFirst.Domain;

public class Employee
{
    public int EmployeeId { get; set; }
    public string Department { get; set; }
    public string Charge { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public decimal Salary { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime FinishTime { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}