using Gestor.Communication.Response;
using Gestor.Exception;
using Gestor.Infra;
using Microsoft.EntityFrameworkCore;

namespace Gestor.Application.UseCase.Login;

public class LoginUseCase
{
    private readonly GestorDbContext _dbContext;

    public LoginUseCase()
    {
        _dbContext = new GestorDbContext();
    }

    public async Task<ResponseLogin> Execute(string user,string senha)
    {
        var entity = await _dbContext.Funcionarios.FirstOrDefaultAsync(p => p.Usuario == user && p.Senha == senha);

        if (entity is null)
            throw new UnauthorizedAccess("Login ou senha incorretos!");


        return new ResponseLogin
        {
            Id = entity.Id
        };
    }
}
