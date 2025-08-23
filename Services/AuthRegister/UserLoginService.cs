using ApiWithTokenJWT.Data;
using ApiWithTokenJWT.Dtos;
using ApiWithTokenJWT.Model;
using ApiWithTokenJWT.Services.PasswordService;
using Microsoft.EntityFrameworkCore;

namespace ApiWithTokenJWT.Services.AuthRegister;

public class UserLoginService : ILogin
{

    private readonly AppDbContext _appDbContext;
    private readonly IPasswordHash _passwordHash;



    public UserLoginService(AppDbContext dbContext, IPasswordHash iPasswordHash)
    {
        _appDbContext = dbContext;
        _passwordHash = iPasswordHash;
    }

    public async Task<Response<string>> Login(LoginDto loginDto)
    {
        Response<string> response = new Response<string>();

        try
        {
            var user = await _appDbContext.Users.FirstOrDefaultAsync(userDb => userDb.Email == loginDto.Email);

            if (user == null)
            {
                response.Message = "Credenciais inválidas";
                response.Status = false;

                return response;
            }

            if (_passwordHash.PasswordVerify(loginDto.Password, user.SenhaHash, user.SenhaSalt))
            {
                response.Message = "Credenciais inválidas";
                response.Status = false;

                return response;
            }

            var token = _passwordHash.CreateToken(user);

            response.Message = "Usuário logado com sucesso";
            response.Dados = token;
        }
        catch (Exception e)
        {
            response.Status = false;
            response.Message = "Não foi possível autenticar";

            return response;
        }

        return response;
    }

}