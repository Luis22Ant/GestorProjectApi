using Gestor.Communication.Request;
using Gestor.Communication.Response;
using Gestor.Exception;
using Gestor.Infra;

namespace Gestor.Application.UseCase.Cliente.Update;

public class UpdateUseCase
{
    private readonly GestorDbContext _dbContext;

    public UpdateUseCase()
    {
        _dbContext = new GestorDbContext();
    }
    public async Task<ResponseCliente> Execute(Guid idCliente, RequestCliente request)
    {

        ValidateRequest(request);
        var entity = await _dbContext.Clientes.FindAsync(idCliente);


        if (entity is null)
            throw new NotFoundException("Cliente não encontrado!");

        entity.Nome = request.Nome;
        entity.Telefone = request.Telefone;
        entity.Categoria = request.Categoria;
        entity.Endereco = request.Endereco;

        _dbContext.Clientes.Update(entity);
        await _dbContext.SaveChangesAsync();

        return new ResponseCliente
        {
            Id = idCliente
        };
    }

    private void ValidateRequest(RequestCliente request)
    {


        if (string.IsNullOrWhiteSpace(request.Nome))
            throw new ErrorBadRequestException("Nome é inválido!");

        if (string.IsNullOrWhiteSpace(request.Telefone))
            throw new ErrorBadRequestException("Telefone é inválido!");

        if (string.IsNullOrWhiteSpace(request.Endereco))
            throw new ErrorBadRequestException("Endereco é inválido!");

        if (string.IsNullOrWhiteSpace(request.Categoria))
            throw new ErrorBadRequestException("Categoria é inválido!");
    }
}
