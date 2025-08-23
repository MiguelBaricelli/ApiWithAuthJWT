using System.ComponentModel.DataAnnotations;
using ApiWithTokenJWT.Enum;

namespace ApiWithTokenJWT.Dtos;

public class UsersDto
{
   [Required(ErrorMessage = "Campo usuário é obrigatório")]
    public string UserName { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Campo Email é obrigatório"), EmailAddress(ErrorMessage = "Email inválido")]
    public string Email { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Campo Senha é obrigatório")]
    public string Password { get; set; }
    
    [Compare("Password", ErrorMessage = "Senhas precisam ser iguais")]
    public string PasswordConfirm { get; set; }
    
    [Required(ErrorMessage = "Campo Cargo é obrigatório")]
    public RolesEnum Role { get; set; }
}