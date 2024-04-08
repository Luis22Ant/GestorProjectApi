using Gestor.Communication.Response;
using Gestor.Exception;
using Gestor.Infra;
using Microsoft.EntityFrameworkCore;

namespace Gestor.Application.UseCase.Projeto.GetAll;

public class GetAllUseCase
{
    private readonly GestorDbContext _dbContext;

    public GetAllUseCase()
    {
        _dbContext = new GestorDbContext();
    }

    public async Task<ResponseAllProjetos> Execute()
    {
        var entity = await _dbContext.Projetos.ToListAsync();

        if (entity is null)
            throw new NotFoundException("Não foram encontrados projetos!");


        return new ResponseAllProjetos
        {
            Projeto = entity
        };
    }
}
