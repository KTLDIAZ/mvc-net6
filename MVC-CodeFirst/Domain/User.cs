namespace MVC_CodeFirst.Domain;

public class User
{
    public int UserId { get; set; }
    public string Fullname { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string CivilStatus { get; set; }
    public List<Employee> Employees { get; set; }
}