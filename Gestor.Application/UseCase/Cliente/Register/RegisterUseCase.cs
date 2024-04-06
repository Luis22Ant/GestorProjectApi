using Gestor.Communication.Request;
using Gestor.Communication.Response;
using Gestor.Exception;
using Gestor.Infra;

namespace Gestor.Application.UseCase.Cliente.Register;

public class RegisterUseCase
{
    private readonly GestorDbContext _dbContext;

    public RegisterUseCase()
    {
        _dbContext = new GestorDbContext();
    }
    public async Task<ResponseCliente> Execute(RequestCliente request)
    {
        ValidateRequest(request);

        var entity = new Infra.Entities.Cliente
        {
            Nome = request.Nome,
            Endereco = request.Endereco,
            Categoria = request.Categoria,
            Telefone = request.Telefone
        };

        await _dbContext.Clientes.AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return new ResponseCliente
        {
            Id = entity.Id
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
