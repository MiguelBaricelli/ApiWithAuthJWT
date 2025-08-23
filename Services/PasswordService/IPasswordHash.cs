using ApiWithTokenJWT.Dtos;
using ApiWithTokenJWT.Model;

namespace ApiWithTokenJWT.Services.PasswordService;

public interface IPasswordHash
{
    void CreatePasswordHash(string password, out byte[] hashPassword, out byte[] saltPassword);

    bool PasswordVerify(string password, byte[] hashPassword, byte[] saltPassword);

    string CreateToken(User user);

    
}