using Gestor.Exception;
using Gestor.Infra;
using Gestor.Infra.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gestor.Application.UseCase.Demanda.GetAllDemandaFunc;

public class GetAllDemandaFuncUseCase
{
    private readonly GestorDbContext _dbContext;

    public GetAllDemandaFuncUseCase()
    {
        _dbContext = new GestorDbContext();
    }
    public async Task<Infra.Entities.Funcionario> Execute(Guid idFunc)
    {

        var entity = await _dbContext.Demandas.Where(d => d.IdFuncionario == idFunc).ToListAsync();

        if (entity is null)
            throw new NotFoundException("Não existem demandas para esse funcionário!");

        return new Infra.Entities.Funcionario
        {
            Demandas = entity
        };
    }
}
