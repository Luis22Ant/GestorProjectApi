using Gestor.Communication.Response;
using Gestor.Exception;
using Gestor.Infra;

namespace Gestor.Application.UseCase.Cliente.GetById;

public class GetByIdUseCase
{
    private readonly GestorDbContext _dbContext;

    public GetByIdUseCase()
    {
        _dbContext = new GestorDbContext();
    }

    public async Task<Infra.Entities.Cliente> Execute(Guid idCliente)
    {
        var entity = await _dbContext.Clientes.FindAsync(idCliente);

        if (entity is null)
            throw new NotFoundException("Não foram encontrados clientes!");


        return new Infra.Entities.Cliente
        {
            Id = entity.Id,
            Nome = entity.Nome,
            Categoria = entity.Categoria,
            Endereco = entity.Endereco,
            Telefone = entity.Telefone
        };
    }
}
