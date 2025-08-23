using ApiWithTokenJWT.Data;
using ApiWithTokenJWT.Dtos;
using ApiWithTokenJWT.Model;
using ApiWithTokenJWT.Services.PasswordService;
using Microsoft.EntityFrameworkCore;

namespace ApiWithTokenJWT.Services.AuthRegister;

public class UserRegisterService : IUserRegister
{
    private readonly AppDbContext _appDbContext;
    private readonly IPasswordHash _iPasswordHash;

    public UserRegisterService(AppDbContext appDbContext, IPasswordHash iPasswordHash)
    {
        _appDbContext = appDbContext;
        _iPasswordHash = iPasswordHash;
    }

    public async Task<Response<UsersDto>> Registrar(UsersDto users)
    {
        Response<UsersDto> response = new Response<UsersDto>();

        try
        {
            if (!EmailAndUserExist(users))
            {
                response.Dados = null;
                response.Message = "Já existe um usuário com esse email/usuario";
                
                return response;
            }
            
            _iPasswordHash.CreatePasswordHash(users.Password, out byte[] hashPassword, out byte[] saltPassword);

            User finalUser = new User
            {
                UserName = users.UserName,
                Email = users.Email,
                Role = users.Role,
                SenhaHash = hashPassword,
                SenhaSalt = saltPassword

            };
            _appDbContext.Add(finalUser);
            await _appDbContext.SaveChangesAsync();
            
            response.Status = true;
            response.Message = "Usuário criado com sucesso!";
        }
        catch (Exception e)
        {
            response.Dados = null;
            response.Message = e.Message;
            response.Status = false;
        }


       
        return response;
    }

    public bool EmailAndUserExist(UsersDto usersDto)
    {
       
        var user = _appDbContext.Users.FirstOrDefault(userDb => userDb.UserName == usersDto.UserName || userDb.Email == usersDto.Email);

        if(user != null)
        {
            return false;
        }

       
        return true;
    }
}

