using Gestor.Communication.Response;
using Gestor.Exception;
using Gestor.Infra;
using Microsoft.EntityFrameworkCore;

namespace Gestor.Application.UseCase.Projeto.GetProjectsClient;

public class GetProjectsClientUseCase
{
    private readonly GestorDbContext _dbContext;

    public GetProjectsClientUseCase()
    {
        _dbContext = new GestorDbContext();
    }
    public async Task<ResponseAllProjetos> Execute(Guid idCliente)
    {
        var entity = await _dbContext.Projetos.Where(p => p.IdCliente == idCliente).ToListAsync();

        if (entity is null)
            throw new NotFoundException("Nenhum projeto encontrado para o cliente informado!");

        return new ResponseAllProjetos
        {
            Projeto = entity
        };
    }
}
