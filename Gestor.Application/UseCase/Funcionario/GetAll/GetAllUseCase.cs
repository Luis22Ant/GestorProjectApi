using Gestor.Communication.Response;
using Gestor.Exception;
using Gestor.Infra;
using Gestor.Infra.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gestor.Application.UseCase.Funcionario.GetAll;

public class GetAllUseCase
{
    private readonly GestorDbContext _dbContext;

    public GetAllUseCase()
    {
        _dbContext = new GestorDbContext();
    }
    public async Task<ResponseAllFuncionarios> Execute()
    {

        var entity = await _dbContext.Funcionarios.ToListAsync();

        if(entity is null)
        {
            throw new NotFoundException("Nenhum funcionário encontrado!");
        }
        return new ResponseAllFuncionarios
        {
            Funcionarios = entity
        };
    }
}
