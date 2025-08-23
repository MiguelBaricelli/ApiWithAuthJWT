using ApiWithTokenJWT.Dtos;
using ApiWithTokenJWT.Model;

namespace ApiWithTokenJWT.Services.AuthRegister;

public interface ILogin
{
    Task<Response<string>> Login(LoginDto loginDto);

}