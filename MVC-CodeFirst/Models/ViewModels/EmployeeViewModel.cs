using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_CodeFirst.Models.ViewModels;

public class EmployeeViewModel
{
    public int? EmployeeId { get; set; }
    
    [DisplayName("Departamento")]
    [Required(ErrorMessage = "El departamento es requerido")]
    public string Department { get; set; }
    
    [DisplayName("Cargo/puesto")]
    [Required(ErrorMessage = "El cargo/puesto es requerido")]
    public string Charge { get; set; }
    
    [DisplayName("Salario")]
    [Required(ErrorMessage = "El salario es requerido")]
    public decimal Salary { get; set; }
    
    [DisplayName("Fecha de inicio")]
    [Required(ErrorMessage = "La fecha de inicio es requerida")]
    public DateTime StartedAt { get; set; }
    
    [DisplayName("Fecha de finalización")]
    [Required(ErrorMessage = "La fecha de finalización es requerida")]
    public DateTime FinishTime { get; set; }
    
    [DisplayName("Usuario")]
    [Required(ErrorMessage = "Es necesario seleccionar el usuario")]
    public int UserId { get; set; }
}