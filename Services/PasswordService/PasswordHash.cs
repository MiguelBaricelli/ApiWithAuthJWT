using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using ApiWithTokenJWT.Dtos;
using ApiWithTokenJWT.Model;
using Microsoft.IdentityModel.Tokens;

namespace ApiWithTokenJWT.Services.PasswordService;

public class PasswordHash : IPasswordHash
{
    private readonly IConfiguration _configuration;

    public PasswordHash(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public void CreatePasswordHash(string password, out byte[] hashPassword, out byte[] saltPassword)
    {
        using (var hmac = new HMACSHA512())
        {
            saltPassword = hmac.Key; //Senha criptiografada
            
            hashPassword = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)); //criar criptografia em cima da senha salt
            
            
        }
    }

    public bool PasswordVerify(string password, byte[] hashPassword, byte[] saltPassword)
    {
        using (var hmac = new HMACSHA512(saltPassword))
        {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(hashPassword);
        }
    }


    public string CreateToken(User user)
    {
        List<Claim> claims = new List<Claim>()
        {
            new Claim("Role", user.Role.ToString()),
            new Claim("Email", user.Email),
            new Claim("Username", user.UserName)
        };


        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: cred
            );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        
        return jwt;
    }
}