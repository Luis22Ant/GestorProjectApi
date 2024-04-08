using Gestor.Communication.Request;
using Gestor.Communication.Response;
using Gestor.Exception;
using Gestor.Infra;

namespace Gestor.Application.UseCase.Projeto.Register;

public class RegisterUseCase
{
    private readonly GestorDbContext _dbContext;

    public RegisterUseCase()
    {
        _dbContext = new GestorDbContext();
    }
    public async Task<ResponseProjeto> Execute(RequestProjeto request)
    {

        ValidateProjeto(request);

        var entity = new Infra.Entities.Projeto
        {
            IdCliente = request.IdCliente,
            Nome = request.Nome,
            Valor = request.Valor,
            DataInicio = request.DataInicio.Date,
            DataFim = request.DataFim.Date
        };

        await _dbContext.Projetos.AddAsync(entity);
        await _dbContext.SaveChangesAsync();


        return new ResponseProjeto
        {
            Id = entity.IdCliente
        };
    }

    private void ValidateProjeto(RequestProjeto request)
    {
        var cliente = _dbContext.Clientes.FirstOrDefault(c => c.Id == request.IdCliente);

        if (string.IsNullOrWhiteSpace(request.Nome))
            throw new ErrorBadRequestException("Nome é inválido!");

        if (cliente is null)
            throw new NotFoundException("Cliente não existe na base de dados!");

        if (request.DataInicio >= request.DataFim)
            throw new ErrorBadRequestException("Data inicial não pode ser maior ou igual a data final!");

        if (request.Valor <= 0)
            throw new ErrorBadRequestException("Valor é inválido!");

    }
}
