using System.ComponentModel.DataAnnotations;

namespace ApiWithTokenJWT.Dtos;

public class LoginDto
{
    [Required(ErrorMessage = "O campo email é obrigatório"), EmailAddress(ErrorMessage = "Email inválido")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo senha é obrigatório")]
    public string Password { get; set; } = string.Empty;
}