using ApiWithTokenJWT.Dtos;
using ApiWithTokenJWT.Model;

namespace ApiWithTokenJWT.Services.AuthRegister;

public interface IUserRegister
{
   Task<Response<UsersDto>> Registrar(UsersDto users);

   
}