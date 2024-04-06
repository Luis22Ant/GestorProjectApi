
using Gestor.Communication.Response;
using Gestor.Exception;
using Gestor.Infra;
using Gestor.Infra.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gestor.Application.UseCase.Cliente.GetAll;

public class GetAllUseCase
{
    private readonly GestorDbContext _dbContext;

    public GetAllUseCase()
    {
        _dbContext = new GestorDbContext();
    }

    public async Task<ResponseAllClientes> Execute()
    {
        var entity = await _dbContext.Clientes.ToListAsync();

        if (entity is null)
            throw new NotFoundException("Não foram encontrados clientes!");


        return new ResponseAllClientes
        {
            Clientes = entity
        };
    }
}
