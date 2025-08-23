using ApiWithTokenJWT.Enum;

namespace ApiWithTokenJWT.Model;

public class User
{
    public int Id { get; set; }
    
    public string Email { get; set; } = string.Empty;
    
    public string UserName { get; set; } = string.Empty;
    
    public RolesEnum Role { get; set; }

    public byte[] SenhaHash { get; set; }
    
    public byte[] SenhaSalt { get; set; }
    
     
    public DateTime TokenCreateDate { get; set; } = DateTime.Now;
}