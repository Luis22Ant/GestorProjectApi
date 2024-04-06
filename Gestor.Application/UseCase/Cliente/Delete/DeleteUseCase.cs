using Gestor.Communication.Response;
using Gestor.Exception;
using Gestor.Infra;

namespace Gestor.Application.UseCase.Cliente.Delete;

public class DeleteUseCase
{
    private readonly GestorDbContext _dbContext;

    public DeleteUseCase()
    {
        _dbContext = new GestorDbContext();
    }
    public async Task<ResponseCliente> Execute(Guid idCliente)
    {
        var entity = await _dbContext.Clientes.FindAsync(idCliente);

        if (entity is null)
            throw new NotFoundException("Cliente não encontrado!");

        _dbContext.Clientes.Remove(entity);
        await _dbContext.SaveChangesAsync();

        return new ResponseCliente
        {
            Id = idCliente
        };

    }
}
