using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_CodeFirst.Models.ViewModels;

public class UserViewModel
{
    public int? UserId { get; set; }
    [DisplayName("Nombre completo")]
    [Required(ErrorMessage = "El nombre completo es requerido")]
    public string Fullname { get; set; }
    
    [DisplayName("Dirección")]
    [Required(ErrorMessage = "La dirección es requerido")]
    public string Address { get; set; }
    
    [DisplayName("Correo electrónico")]
    [Required(ErrorMessage = "El correo electrónico es requerido")]
    public string Email { get; set; }
    
    [DisplayName("Número de telefono")]
    [Required(ErrorMessage = "El número de telefono es requerido")]
    public string PhoneNumber { get; set; }
    
    [DisplayName("Estado civil")]
    [Required(ErrorMessage = "El estado civil es requerido es requerido")]
    public string CivilStatus { get; set; }
}